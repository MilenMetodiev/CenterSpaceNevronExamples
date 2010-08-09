using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Stats;

namespace ControlChartEngine
{

	/// <summary>
	/// Class for computing the statistics for the c-chart
	/// </summary>
	class Stats_c : IAttributeChartStats
	{

		#region Ctor -------------------------------------------------------

		/// <summary>
		/// Creates statistics for the c-chart
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity per-sample period</param>
    /// <param name="Stds">Number of standard deviations, either 1, 2, or 3 to use for control limits</param>
    /// <param name="ChartTitle">Title of chart.</param>
    /// <param name="TimeStart">The start time of the data.</param>
    /// <param name="TimeInterval">Time interval between each sample group.</param>
    /// <param name="TimeAxisLabel">Horizontal axis label.</param>
    /// <param name="StatisticsLabel">Vertical axis label.</param>
    public Stats_c(DoubleVector Defects, int Stds, String ChartTitle, Double TimeStart, Double TimeInterval, String TimeAxisLabel, String StatisticsLabel)
		{
			if (Stds == 1 || Stds == 2 || Stds == 3)
			{
				this.CenterLine = StatsFunctions.Mean(Defects);

				this.ConstControlLimits = true;
				this.UCL = new DoubleVector(Defects.Length, this.CenterLine + Stds * Math.Sqrt(this.CenterLine));

        if(this.CenterLine - Stds * Math.Sqrt(this.CenterLine) > 0)
          this.LCL = new DoubleVector(Defects.Length, this.CenterLine - Stds * Math.Sqrt(this.CenterLine));
        else
          this.LCL = new DoubleVector(Defects.Length, 0);
        
				this.Statistic = Defects;

				this.TimeStart = TimeStart;
				this.TimeSampleInterval = TimeInterval;
				this.TimeLabel = TimeAxisLabel;
				this.DefectLabel = StatisticsLabel;

        this.ChartTitle = ChartTitle;

			}
			else
			{
				throw new ArgumentException("In stats_c, the number of standard deviations must be either 1, 2, or 3");
			}
		}

		/// <summary>
		/// Creates statistics for the c-chart, with a given number of standard deviations for
		/// the limits.
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity  per-sample period</param>
		/// <param name="stds">Number of standard deviations, either 1, 2, or 3.</param>
    /// <param name="ChartTitle">Title of chart.</param>
		public Stats_c(DoubleVector Defects, int Stds, String ChartTitle)
			: this(Defects, Stds, ChartTitle, 1, 1, "Group", "Group Summary Statistics")
		{
			;
		}

		/// <summary>
		/// Creates statistics for the c-chart
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity  per-sample period</param>
		public Stats_c(DoubleVector Defects)
			: this(Defects, 3, "c-Chart")
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
