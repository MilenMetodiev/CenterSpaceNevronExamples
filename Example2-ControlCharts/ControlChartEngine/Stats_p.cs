using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Stats;

namespace ControlChartEngine
{

	/// <summary>
	/// Computes the statistics for a quality control p-Chart.  The p-Chart is used for
  /// monitoring the proportion of non-conforming units in a sample.  The p-Chart is 
  /// designed only for pass/fail inspection types where the pass or fail is determined
  /// by one or more go / no-go tests.
	/// </summary>
	class Stats_p : IAttributeChartStats
	{
		#region Ctor -------------------------------------------------------

		/// <summary>
		/// Creates statistics for the p-chart.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSizes">Size of each sample</param>
    /// <param name="Stds">Number of standard deviations, either 1, 2, or 3 to use for control limits</param>
    /// <param name="ChartTitle">Title of chart.</param>
    /// <param name="TimeStart">The start time of the data.</param>
    /// <param name="TimeInterval">Time interval between each sample group.</param>
    /// <param name="TimeAxisLabel">Horizontal axis label.</param>
    /// <param name="StatisticsLabel">Vertical axis label.</param>
		public Stats_p(DoubleVector DefectCountInSample, DoubleVector SampleSizes, Double Stds, String ChartTitle, Double TimeStart, Double TimeInterval, String TimeAxisLabel, String StatisticsLabel)
		{
			if (Stds == 1 || Stds == 2 || Stds == 3)
			{
				if (DefectCountInSample.Length == SampleSizes.Length)
				{

					this.CenterLine = StatsFunctions.Sum(DefectCountInSample) / StatsFunctions.Sum(SampleSizes);

					this.ConstControlLimits = false;
					this.UCL = this.CenterLine + Stds * StatsFunctions.Sqrt( (new DoubleVector(SampleSizes.Length, this.CenterLine)) * (new DoubleVector(SampleSizes.Length, 1.0 - this.CenterLine)) ) / StatsFunctions.Sqrt(SampleSizes);
          this.LCL = this.CenterLine - Stds * StatsFunctions.Sqrt( (new DoubleVector(SampleSizes.Length, this.CenterLine)) * (new DoubleVector(SampleSizes.Length, 1.0 - this.CenterLine)) ) / StatsFunctions.Sqrt(SampleSizes);
					
          for (int i = 0; i < this.LCL.Length; i++)
					{
						if (this.LCL[i] < 0)
							this.LCL[i] = 0;
					}

					this.Statistic = DefectCountInSample / SampleSizes; ;

					this.TimeStart = TimeStart;
					this.TimeSampleInterval = TimeInterval;
					this.TimeLabel = TimeAxisLabel;
					this.DefectLabel = StatisticsLabel;

          this.ChartTitle = ChartTitle;
				}
				else
				{
					throw new ArgumentException("In Stats_p, the defect count and sample size vectors much have the same length");
				}
			}
			else
			{
				throw new ArgumentException("In Stats_p, the number of standard deviations must be either 1, 2, or 3");
			}
		}

		/// <summary>
		/// Creates statistics for the p-chart, with a given number of standard deviations for
		/// the upper and lower control limits.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSizes">Size of each sample</param>
    /// <param name="Stds">Number of standard deviations, either 1, 2, or 3 to use for control limits</param>
    /// <param name="ChartTitle">Title of chart.</param>
    public Stats_p(DoubleVector DefectCountInSample, DoubleVector SampleSizes, int Stds, string ChartTitle)
      : this(DefectCountInSample, SampleSizes, Stds, ChartTitle, 1, 1, "Group", "Group Summary Statistics")
		{
			;
		}

		/// <summary>
		/// Creates statistics for the p-chart.
		/// </summary>
    /// <param name="DefectCountInSample">Count of failed samples per-sample.</param>
    /// <param name="SampleSizes">Size of each sample</param>
    public Stats_p(DoubleVector DefectCountInSample, DoubleVector SampleSizes)
      : this(DefectCountInSample, SampleSizes, 3, "p-Chart")
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
