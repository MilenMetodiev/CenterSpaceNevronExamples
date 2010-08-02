using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ControlChartEngine;

// Nevron namespaces
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;

// CenterSpace namespaces
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Stats;

namespace ControlChartsExample
{
	/// <summary>
	/// Implements an Attribute Chart, either a np, n, c, or u-chart.
	/// These charts are for monitoring discrete defect or nonconformance counts for a process over time.
	/// </summary>
	public class AttributeChart
	{
		private Nevron.Chart.WinForm.NChartControl nControlChart;

		/// <summary>
		/// Builds an attribute quality control chart.
		/// </summary>
		/// <param name="AttributeStats">Specific statistics for quality chart</param>
		/// <param name="QualityControlChart">Nevron chart control</param>
		public AttributeChart(IAttributeChartStats AttributeStats, Nevron.Chart.WinForm.NChartControl QualityControlChart)
		{
			nControlChart = QualityControlChart;

			BuildChart(AttributeStats);
		}

		/// <summary>
		/// The attribute control chart
		/// </summary>
		public Nevron.Chart.WinForm.NChartControl Chart
		{
			get
			{
				return this.nControlChart;
			}
		}

		/// <summary>
		/// Builds the attribute chart
		/// </summary>
		/// <param name="attributes">statistics for an attribute chart</param>
		private void BuildChart(IAttributeChartStats stats)
		{
			int nppoints = stats.Statistic.Length;
			double xstart = stats.TimeStart;
			double xincrement = stats.TimeSampleInterval;

			this.nControlChart.Panels.Clear();

			//
			// Set up chart title.
			//
			NLabel title = new NLabel();
			this.nControlChart.Panels.Add(title);
			title.Dock = DockStyle.Top;
			title.Padding = new NMarginsL(5, 8, 5, 4);
			title.Text = stats.ChartTitle;
			title.TextStyle.FontStyle = new NFontStyle("Verdana", 12, FontStyle.Bold | FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(68, 90, 108));

			//
			// Set up the chart
			//
			NChart chart = new NCartesianChart();
			this.nControlChart.Charts.Add(chart);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Dock = DockStyle.Fill;
			chart.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(233, 233, 255));
			chart.Padding = new NMarginsL(
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage));

			SetupChartAxes(chart);

			//
			// First set up a point series for the outliers so it's on-top in z-order.
			//
			NPointSeries outlierPoints = new NPointSeries();
			chart.Series.Add(outlierPoints);

			// Name the series
			outlierPoints.Name = "Control Limit Violations";

			// Tell the series to regard the X values
			outlierPoints.UseXValues = true;

			// Points must fit in the chart area
			outlierPoints.InflateMargins = true;

			// No data labels
			outlierPoints.DataLabelStyle.Visible = false;

			// Set the point appearance properties
			outlierPoints.FillStyle = new NColorFillStyle(Color.Red);
			outlierPoints.BorderStyle = new NStrokeStyle(1.0f, Color.Black);
			outlierPoints.PointShape = PointShape.Cross;
			outlierPoints.Size = new NLength(6.0f);

			// Add the statistic
			for (int i = 0; i < nppoints; i++)
			{
				double statValue = stats.Statistic[i];

				// Do not display a marker if the point is an outlier
				if ((statValue > stats.UCL[i]) || (statValue < stats.LCL[i]))
				{
					outlierPoints.XValues.Add(xstart + xincrement * i);
					outlierPoints.Values.Add(statValue);
				}
			}
			
			//
			// Set up the statistic line series
			//
			NLineSeries line = new NLineSeries();
			chart.Series.Add(line);
			line.Name = "Statistic";
			line.UseXValues = true;
			line.InflateMargins = true;
			line.DataLabelStyle.Visible = false;
			line.BorderStyle = new NStrokeStyle(1.6f, Color.Tomato);
			
			// Set up the marker style for the regular points
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.FillStyle = new NColorFillStyle(Color.SkyBlue);
			line.MarkerStyle.BorderStyle = new NStrokeStyle(1.0f, Color.Tomato);
			line.MarkerStyle.PointShape = PointShape.Sphere;
			line.MarkerStyle.Width = new NLength(4.0f);
			line.MarkerStyle.Height = new NLength(4.0f);

			// Add the statistic
			for (int i = 0; i < nppoints; i++)
			{
				line.XValues.Add(xstart + xincrement * i);

				double statValue = stats.Statistic[i];

				// Do not display a marker if the point is an outlier
				if ((statValue > stats.UCL[i]) || (statValue < stats.LCL[i]))
				{
					NMarkerStyle outlierMarker = new NMarkerStyle();
					outlierMarker.Visible = false;
					line.MarkerStyles[i] = outlierMarker;
				}
			}

			line.Values.AddRange(stats.Statistic.DataBlock.Data);

			//
			// Set up the UCL and LCL lines
			//
			if (stats.ConstControlLimits)
			{
				bool showLCL = (stats.LCL.Length > 0);
				bool showUCL = (stats.UCL.Length > 0);

				if (showLCL)
				{
					double lclValue = stats.LCL[0];

					// Set up the LCL const line
					NAxisConstLine lcl = new NAxisConstLine();
					lcl.StrokeStyle = new NStrokeStyle(1.0f, Color.Gray, LinePattern.Dash);
					lcl.Value = lclValue;
					lcl.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
					chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(lcl);

					// Show LCL label
					SetValueLabel(chart, lclValue, "LCL", true);
				}

				if (showUCL)
				{
					double uclValue = stats.UCL[0];

					// Set up the UCL const line
					NAxisConstLine ucl = new NAxisConstLine();
					ucl.Value = uclValue;
					ucl.StrokeStyle = new NStrokeStyle(1.0f, Color.Gray, LinePattern.Dash);
					ucl.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
					chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(ucl);

					// Show UCL label
					SetValueLabel(chart, uclValue, "UCL", true);
				}

				// Ensure that the UCL and LCL values are visible
				NRange1DD clRange = new NRange1DD();

				if (showLCL && showUCL)
				{
					clRange.Begin = stats.LCL[0];
					clRange.End = stats.UCL[0];
				}
				else if (showLCL)
				{
					clRange.End = clRange.Begin = stats.LCL[0];
				}
				else if (showUCL)
				{
					clRange.End = clRange.Begin = stats.UCL[0];
				}

				clRange.Inflate(0.5);

				chart.Axis(StandardAxis.PrimaryY).UpdateScale();
				chart.Axis(StandardAxis.PrimaryY).SynchronizeScaleWithConfigurator = false;

				// custom tick inflator
				NCustomRangeInflator inflator = new NCustomRangeInflator(new NRange1DD[] { clRange });
				inflator.InflateBegin = true;
				inflator.InflateEnd = true;
				chart.Axis(StandardAxis.PrimaryY).Scale.ContentRangeInflators.Add(inflator);
			}
			else
			{
				// Set up the UCL line series
				AddStepLineSeries(chart, "UCL", stats.UCL, xstart, xincrement);

				// Set up the LCL line series
				AddStepLineSeries(chart, "LCL", stats.LCL, xstart, xincrement);

				// Show UCL label
				if (stats.UCL.Length > 0)
				{
					int lastIndexUCL = stats.UCL.Length - 1;
					SetValueLabel(chart, stats.UCL[lastIndexUCL], "UCL", false);
				}

				// Show LCL label
				if (stats.LCL.Length > 0)
				{
					int lastIndexLCL = stats.LCL.Length - 1;
					SetValueLabel(chart, stats.LCL[lastIndexLCL], "LCL", false);
				}
			}

			//
			// Set up the center line
			//
			NAxisConstLine cl1 = new NAxisConstLine();
			cl1.StrokeStyle = new NStrokeStyle(1.0f, Color.DodgerBlue, LinePattern.Dot);
			cl1.Value = stats.CenterLine;
			cl1.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(cl1);

			// Show CL label
			SetValueLabel(chart, stats.CenterLine, "CL", true);
		}

		/// <summary>
		/// Adds a step line series to the chart
		/// </summary>
		/// <param name="chart"></param>
		/// <param name="name"></param>
		/// <param name="vector"></param>
		/// <param name="xstart"></param>
		/// <param name="xincrement"></param>
		void AddStepLineSeries(NChart chart, string name, DoubleVector vector, double xstart, double xincrement)
		{
			NStepLineSeries stepline = new NStepLineSeries();
			chart.Series.Add(stepline);

			// Name the line
			stepline.Name = name;

			// Tell the series to regard the X values
			stepline.UseXValues = true;

			// No data labels
			stepline.DataLabelStyle.Visible = false;

			// Set the line color
			stepline.BorderStyle = new NStrokeStyle(1.0f, Color.Gray, LinePattern.Dash);

			// Fill X values
			for (int i = 0; i < vector.Length; i++)
			{
				stepline.XValues.Add(xstart + xincrement * i);
			}

			// Fill Y values
			stepline.Values.AddRange(vector.DataBlock.Data);
		}

		/// <summary>
		/// Configures the axis
		/// </summary>
		/// <param name="chart"></param>
		void SetupChartAxes(NChart chart)
		{
			NAxis axisY1 = chart.Axis(StandardAxis.PrimaryY);
			NAxis axisY2 = chart.Axis(StandardAxis.SecondaryY);
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);

			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.Title.Text = "Group";
			scaleX.Title.TextStyle.FontStyle = new NFontStyle("Arial", 9, FontStyle.Bold);
			scaleX.ViewRangeInflateMode = ScaleViewRangeInflateMode.Logical;
			scaleX.LogicalInflate = new NRange1DD(0.5, 0.5);
			axisX.ScaleConfigurator = scaleX;

			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Visible = false;
			scaleY.Title.Text = "Group Summary Statistics";
			scaleY.Title.TextStyle.FontStyle = new NFontStyle("Arial", 9, FontStyle.Bold);
			axisY1.ScaleConfigurator = scaleY;

			NLinearScaleConfigurator scaleY2 = new NLinearScaleConfigurator();
			scaleY2.OuterMajorTickStyle.Visible = false;
			scaleY2.InnerMajorTickStyle.Visible = false;
			scaleY2.RulerStyle.BorderStyle.Width = new NLength(0);
			scaleY2.AutoLabels = false;
			axisY2.ScaleConfigurator = scaleY2;
			axisY2.Visible = true;

			// the scale of the secodary Y axis must be the same as the primary Y axis scale
			axisY1.Slaves.Add(axisY2);
		}

		/// <summary>
		/// Displays a custom label at the secondary Y axis
		/// </summary>
		/// <param name="chart"></param>
		/// <param name="value"></param>
		/// <param name="label"></param>
		void SetValueLabel(NChart chart, double value, string label, bool showValue)
		{
			NScaleConfigurator scaleY2 = chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator;

			string text = showValue ? string.Format("{0} = {1:0.###}", label, value) : label;

			NCustomValueLabel cl = new NCustomValueLabel(value, text);
			cl.Style.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			cl.Style.ContentAlignment = ContentAlignment.TopCenter;
			scaleY2.CustomLabels.Add(cl);
		}
	}
}
