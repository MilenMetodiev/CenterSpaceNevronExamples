using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Stats;

namespace ControlChartEngine
{

	/// <summary>
	/// Computes the statistics for a quality control u-Chart
	/// </summary>
	class Stats_u : IAttributeChartStats
	{
		#region Ctor -------------------------------------------------------

		/// <summary>
		/// Creates statistics for the u-chart
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity  per-sample period</param>
		public Stats_u(DoubleVector Defects, DoubleVector SampleSizes, int Stds, Double TimeStart, Double TimeInterval, String TimeAxisLabel, String StatisticsLabel)
		{
			if (Stds == 1 || Stds == 2 || Stds == 3)
			{
				if (Defects.Length == SampleSizes.Length)
				{

					this.CenterLine = StatsFunctions.Sum(Defects) / StatsFunctions.Sum(SampleSizes);

					this.ConstControlLimits = false;
					this.UCL = this.CenterLine + Stds * StatsFunctions.Sqrt(new DoubleVector(SampleSizes.Length, this.CenterLine) / SampleSizes);
					this.LCL = this.CenterLine - Stds * StatsFunctions.Sqrt(new DoubleVector(SampleSizes.Length, this.CenterLine) / SampleSizes);
					for (int i = 0; i < this.LCL.Length; i++)
					{
						if (this.LCL[i] < 0)
							this.LCL[i] = 0;
					}

					this.Statistic = Defects / SampleSizes; ;

					this.TimeStart = TimeStart;
					this.TimeSampleInterval = TimeInterval;
					this.TimeLabel = TimeAxisLabel;
					this.DefectLabel = StatisticsLabel;

					this.ChartTitle = "u Chart";
				}
				else
				{
					throw new ArgumentException("In Stats_u, the defect count and sample size vectors much have the same length");
				}
			}
			else
			{
				throw new ArgumentException("In Stats_u, the number of standard deviations must be either 1, 2, or 3");
			}
		}

		/// <summary>
		/// Creates statistics for the u-chart, with a given number of standard deviations for
		/// the limits.
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity  per-sample period</param>
		/// <param name="stds">Number of standard deviations, either 1, 2, or 3.</param>
		public Stats_u(DoubleVector Defects, DoubleVector SampleSizes, int Stds)
			: this(Defects, SampleSizes, Stds, 1, 1, "Group", "Group Summary Statistics")
		{
			;
		}

		/// <summary>
		/// Creates statistics for the u-chart
		/// </summary>
		/// <param name="defects">Count of defect / nonconformity  per-sample period</param>
		public Stats_u(DoubleVector Defects, DoubleVector SampleSizes)
			: this(Defects, SampleSizes, 3)
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
