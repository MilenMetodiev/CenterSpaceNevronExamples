using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CenterSpace.NMath.Core;

namespace ControlChartEngine
{
	/// <summary>
	/// An Attribute Chart interface for either a np, n, c, or u-chart.
	/// Attribute charts are for monitoring discrete defect or nonconformance counts for a process over time.
	/// </summary>
	public interface IAttributeChartStats
	{
		/// <summary>
		/// The statistics that is plotted
		/// </summary>
		DoubleVector Statistic { get; }

		/// <summary>
		/// Starting time of data
		/// </summary>
		double TimeStart { get; }

		/// <summary>
		/// Time sample interval of data
		/// </summary>
		double TimeSampleInterval { get; }

		/// <summary>
		/// Text label for horizontal time axis
		/// </summary>
		String TimeLabel { get; }

		/// <summary>
		/// Text label for the vertical defect count 
		/// </summary>
		String DefectLabel { get; }

		/// <summary>
		/// Chart title
		/// </summary>
		String ChartTitle { get; }

		/// <summary>
		/// Upper control limit
		/// </summary>
		DoubleVector UCL { get; }

		/// <summary>
		/// Lower control limit
		/// </summary>
		DoubleVector LCL { get; }

		/// <summary>
		/// True if the control limits are constant
		/// </summary>
		bool ConstControlLimits { get; }

		/// <summary>
		/// Center line
		/// </summary>
		double CenterLine { get; }

	}
}
