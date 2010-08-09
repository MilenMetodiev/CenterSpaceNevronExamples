using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Stats;

namespace ControlChartEngine
{

	/// <summary>
	/// Computes the statistics for a quality control np-Chart.  The np-Chart is used for
  /// monitoring the proportion of non-conforming units in a sample.  The np-Chart is 
  /// designed only for pass/fail inspection types where the pass or fail is determined
  /// by one or more go / no-go tests.  The np-Chart is a variant of the p-Chart that
  /// uses a statistic in concrete units, instead of a more abstract proportion used by
  /// the p-Chart.
	/// </summary>
  /// <remarks>Sample size is constant.</remarks>
	class Stats_np : IAttributeChartStats
	{
		#region Ctor -------------------------------------------------------

		/// <summary>
		/// Creates statistics for the np-chart.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSize">Size of each sample</param>
    /// <param name="Stds">Number of standard deviations, either 1, 2, or 3 to use for control limits</param>
    /// <param name="ChartTitle">Title of chart.</param>
    /// <param name="TimeStart">The start time of the data.</param>
    /// <param name="TimeInterval">Time interval between each sample group.</param>
    /// <param name="TimeAxisLabel">Horizontal axis label.</param>
    /// <param name="StatisticsLabel">Vertical axis label.</param>
		public Stats_np(DoubleVector DefectCountInSample, int SampleSize, Double Stds, String ChartTitle, Double TimeStart, Double TimeInterval, String TimeAxisLabel, String StatisticsLabel)
		{
      double pbar;

			if (Stds == 1 || Stds == 2 || Stds == 3)
			{

        pbar = StatsFunctions.Sum(DefectCountInSample) / (SampleSize * DefectCountInSample.Length);
        this.CenterLine = pbar * SampleSize;

				this.ConstControlLimits = true;
        this.UCL = new DoubleVector(DefectCountInSample.Length, this.CenterLine + Stds * StatsFunctions.Sqrt( SampleSize * pbar * (1 - pbar) ));
        this.LCL = new DoubleVector(DefectCountInSample.Length, this.CenterLine - Stds * StatsFunctions.Sqrt( SampleSize * pbar * (1 - pbar) ));
				
        for (int i = 0; i < this.LCL.Length; i++)
				{
					if (this.LCL[i] < 0)
						this.LCL[i] = 0;
				}

				this.Statistic = DefectCountInSample;

				this.TimeStart = TimeStart;
				this.TimeSampleInterval = TimeInterval;
				this.TimeLabel = TimeAxisLabel;
				this.DefectLabel = StatisticsLabel;

        this.ChartTitle = ChartTitle;
			
			}
			else
			{
				throw new ArgumentException("In Stats_np, the number of standard deviations must be either 1, 2, or 3");
			}
		}

		/// <summary>
		/// Creates statistics for the np-chart, with a given number of standard deviations for
		/// the upper and lower control limits.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSize">Size of each sample</param>
    /// <param name="Stds">Number of standard deviations, either 1, 2, or 3 to use for control limits</param>
    /// <param name="ChartTitle">Title of chart.</param>
    public Stats_np(DoubleVector DefectCountInSample, int SampleSize, int Stds, string ChartTitle)
      : this(DefectCountInSample, SampleSize, Stds, ChartTitle, 1, 1, "Group", "Group Summary Statistics")
		{
			;
		}

		/// <summary>
		/// Creates statistics for the np-chart.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSize">Size of each sample</param>
    public Stats_np(DoubleVector DefectCountInSample, int SampleSize)
      : this(DefectCountInSample, SampleSize, 3, "np-Chart")
		{
			;
		}


		#endregion

		#region Public Properties ------------------------------------------

		public double CenterLine { get; private set; }
		public DoubleVector UCL { get; private set; }
		public DoubleVector LCL { get; private set; }
		public DoubleVector Statistic { get; private set; }
		public bool ConstControlLimits { get; private set; }

		public double TimeStart { get; set; }
		public double TimeSampleInterval { get; set; }
		public String TimeLabel { get; set; }
		public String DefectLabel { get; set; }
		public String ChartTitle { get; private set; }

		#endregion
	}
}
