using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

// Nevron namespaces
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;

// CenterSpace namespaces
using CenterSpace.NMath.Core;      // always needed
using CenterSpace.NMath.Stats;     // needed for linear regression
using CenterSpace.NMath.Analysis;  // needed for polynomial fitting

namespace CenterSpaceNevronExamples
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Variance to random normal noise use for generating noisy example data.
		/// </summary>
		private Double noiselevel_ = 10.0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DataSmoothing();
		}

		/// <summary>
		/// Demonstrates the use of Savitzky-Golay smoothing filter.
		/// </summary>
		void DataSmoothing()
		{
			// Set up example description
			nRichDescription.Text = "Smoothing discrete data with random normal noise using a 5th degree Savitzky-Golay filter. \n\nWhen using the Savitzky-Golay filter class, both the degree of the fitting polynomial and the filter width can be easily controlled.  Good defaults are available.";

			// Create an interesting noisy sampled signal to smooth.
			DoubleVector xs = new DoubleVector(50, 0, Math.PI / 25);
			RandomNumberGenerator rand = new RandGenNormal(0.0, noiselevel_);
			DoubleVector raw_data = 10.0 * NMathFunctions.Tanh(NMathFunctions.Sin(xs)) + 0.2 * new DoubleVector(xs.Length, rand);

			// Create the filter and smooth the data
			MovingWindowFilter filter = new MovingWindowFilter(10, 10, MovingWindowFilter.SavitzkyGolayCoefficients(10, 10, 5));
			DoubleVector smoothed_data = filter.Filter(raw_data, MovingWindowFilter.BoundaryOption.PadWithZeros);

			SetupChartLayout("Data Smoothing");

			NChart chart = nChartControl1.Charts[0];

			SetupChartAxes(chart);

			// Create a point series to display the raw data
			NPointSeries point = new NPointSeries();
			chart.Series.Add(point);

			// Tell the series to regard the X values
			point.UseXValues = true;

			// Points must fit in the chart area
			point.InflateMargins = true;

			// No data labels
			point.DataLabelStyle.Visible = false;

			// Set up the data look and feel
			point.FillStyle = new NColorFillStyle(Color.SkyBlue);
			point.BorderStyle = new NStrokeStyle(1.0f, Color.DarkGray);
			point.PointShape = PointShape.Ellipse;
			point.Size = new NLength(4.0f);

			// Name points
			point.Name = "Observations";

			// Load data into points collection
			point.XValues.AddRange(xs.DataBlock.Data);
			point.Values.AddRange(raw_data.DataBlock.Data);

			// Create a line series to display the smoothed data
			NLineSeries smoothline = new NLineSeries();
			chart.Series.Add(smoothline);
			smoothline.UseXValues = true;
			smoothline.DataLabelStyle.Visible = false;
			smoothline.BorderStyle = new NStrokeStyle(2.0f, Color.Tomato);

			// Name smooth line
			smoothline.Name = "Savitzky-Golay Smoothed Data";

			// Load the smoothed data into the line series
			smoothline.XValues.AddRange(xs.DataBlock.Data);
			smoothline.Values.AddRange(smoothed_data.DataBlock.Data);

			nChartControl1.Refresh();
		}

		/// <summary>
		/// Demonstrates linear reression in two dimensions.
		/// </summary>
		void LinearRegression()
		{
			// Set up example description
			nRichDescription.Text = "A linear regression model is computed from the sample data containing random normal noise. \n\nA point is then predicted from the model with a 95% confidence interval - meaning the predicted point is expected to lie within the confidence interval 95% of the time.";

			// First read in the independent (or predictor) values. This is a matrix
			// with one column and a row for each amounts measurement.
			DoubleVector raw_data = new DoubleVector(25, 0, 1);
			DoubleMatrix measurements = new DoubleMatrix(raw_data);

			// Next, read in the responses
			// Build a linear polynomial and add noise for interest
			RandomNumberGenerator rand = new RandGenNormal(0, noiselevel_);
			Polynomial poly = new Polynomial(new DoubleVector("0, 1"));
			DoubleVector responses = poly.Evaluate(raw_data) + new DoubleVector(raw_data.Length, rand); ;

			// Construct a linear regression. If we want our regression to calculate a
			// y-intercept we must send in true for the "addIntercept" parameter (the
			// third paramameter in the constructor).
			LinearRegression regression = new LinearRegression(measurements, responses, true);
			DoubleVector residues = regression.Residuals;

			// Use the linear regression class to make a prediction according to the model
			DoubleVector xvalues = new DoubleVector("30"); // Use the model to predict the observation at 30.
			Interval pi = regression.PredictionInterval(xvalues, 0.95);

			// Build some data points along the regression line for display
			DoubleMatrix abcissae = new DoubleMatrix(new DoubleVector(raw_data));
			DoubleVector predicted_ys = regression.PredictedObservations(abcissae);

			// Build the chart
			SetupChartLayout("Linear Regression");

			NChart chart = nChartControl1.Charts[0];

			SetupChartAxes(chart);

			// Set up the line series
			NLineSeries line = new NLineSeries();
			chart.Series.Add(line);

			// tell the series to regard the X values
			line.UseXValues = true;

			// no data labels
			line.DataLabelStyle.Visible = false;

			// Set the line color
			line.BorderStyle = new NStrokeStyle(2.0f, Color.Tomato);

			// name data set
			line.Name = "Linear Regression";

			// Add the the Linear Regression line data to the line series
			line.XValues.AddRange(abcissae.DataBlock.Data);
			line.Values.AddRange(predicted_ys.DataBlock.Data);

			// Draw the raw data points
			NPointSeries point = new NPointSeries();
			chart.Series.Add(point);

			point.UseXValues = true;
			point.DataLabelStyle.Visible = false;

			// Set the point appearance properties
			point.FillStyle = new NColorFillStyle(Color.SkyBlue);
			point.BorderStyle = new NStrokeStyle(1.0f,Color.DarkGray);
			point.PointShape = PointShape.Cross;
			point.Size = new NLength(6.0f);

			// Points must fit in the chart area
			point.InflateMargins = true;

			// Name point set
			point.Name = "Observations";

			// set the point data
			point.Values.AddRange(responses.DataBlock.Data);
			point.XValues.AddRange(measurements.DataBlock.Data);

			double m = (pi.Min + pi.Max) / 2.0;

			// Display the predicted value with an error bar series
			NErrorBarSeries predicted_points = new NErrorBarSeries();
			chart.Series.Add(predicted_points);
			predicted_points.Name = "Predicted Point";
			predicted_points.UseXValues = true;
			predicted_points.InflateMargins = true;
			predicted_points.FillStyle = new NColorFillStyle(Color.Crimson);
			predicted_points.BorderStyle = new NStrokeStyle(1.0f, Color.DarkGray);
			predicted_points.DataLabelStyle.Visible = false;
			predicted_points.MarkerStyle.Visible = true;
			predicted_points.MarkerStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			predicted_points.MarkerStyle.BorderStyle = new NStrokeStyle(1.0f, Color.DarkGray);
			predicted_points.MarkerStyle.PointShape = PointShape.Bar;
			predicted_points.MarkerStyle.Width = new NLength(5);
			predicted_points.MarkerStyle.Height = new NLength(5);
			predicted_points.SizeY = new NLength(5);

			// Fill the data for the predicted point
			predicted_points.XValues.AddRange(xvalues.DataBlock.Data);
			predicted_points.Values.Add(m);
			predicted_points.UpperErrorsY.Add(pi.Max - m);
			predicted_points.LowerErrorsY.Add(m - pi.Min);

			// Create a label to display the predicted value
			NLabel label = new NLabel();
			label.BoundsMode = BoundsMode.None;
			label.ContentAlignment = ContentAlignment.BottomLeft;
			label.Location = new NPointL(
				new NLength(87, NRelativeUnit.ParentPercentage),
				new NLength(3, NRelativeUnit.ParentPercentage));

			label.TextStyle.TextFormat = TextFormat.XML;
			label.TextStyle.FontStyle = new NFontStyle("Arial", 9);
			label.TextStyle.StringFormatStyle.HorzAlign = Nevron.HorzAlign.Right;
			label.TextStyle.BackplaneStyle.Visible = true;
			label.TextStyle.BackplaneStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(130, 255, 255, 255), Color.FromArgb(130, 233, 233, 255));
			label.TextStyle.BackplaneStyle.Shape = BackplaneShape.SmoothEdgeRectangle;
			label.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.White;
			label.Text = "<font color = 'crimson'>" + m.ToString("0.###") + "</font> - predicted value with 95% confidence interval";

			chart.ChildPanels.Add(label);

			nChartControl1.Refresh();
		}

		/// <summary>
		/// Demonstrates polynomial least squares curve fitting
		/// </summary>
		void CurveFitting()
		{
			// Set up example description
			nRichDescription.Text = "A 4th degree polynomial is fitted to the noisy sampled data.  \n\nFitting a polynomial of any degree is accomplished in one line of code specifing the polynomial degree, and arrays of the x and y values. ";

			// Build the data sets using some random normal noise
			DoubleVector x = new DoubleVector("[0 0.1 0.2 0.3 0.4 0.5 0.6 0.7 0.8 0.9 1 1.1 1.2 1.3 1.4 1.5 1.6 1.7 1.8 1.9 2 2.1 2.2 2.3 2.4 2.5]");
			DoubleVector y = new DoubleVector("[0 0.112462916018285 0.222702589210478 0.328626759459127 0.428392355046668 0.520499877813047 0.603856090847926 0.677801193837419 0.742100964707661 0.796908212422832 0.842700792949715 0.880205069574082 0.910313978229635 0.934007944940652 0.952285119762649 0.966105146475311 0.976348383344644 0.983790458590775 0.989090501635731 0.992790429235257 0.995322265018953 0.997020533343667 0.998137153702018 0.998856823402643 0.999311486103355 0.999593047982555]");

			RandomNumberGenerator rand = new RandGenNormal(0.0, noiselevel_);
			y = y + 0.025 * (new DoubleVector(y.Length, rand));

			// Build the least squares polynomial fit and make readable display label
			int polynomialdeg = 4;
			PolynomialLeastSquares pls = new PolynomialLeastSquares(polynomialdeg, x, y);

			// Build fitted polynomial
			DoubleVector xs = new DoubleVector(100, 0, 0.025);
			DoubleVector ys = pls.FittedPolynomial.Evaluate(xs);

			// Build the chart
			SetupChartLayout("Curve Fitting");

			NChart chart = nChartControl1.Charts[0];

			SetupChartAxes(chart);
		   
			// Draw the raw data points
			NPointSeries point = new NPointSeries();
			chart.Series.Add(point);
			point.UseXValues = true;
			point.DataLabelStyle.Visible = false;

			// set some appearance properties
			point.FillStyle = new NColorFillStyle(Color.SkyBlue);
			point.BorderStyle = new NStrokeStyle(1.0f, Color.DarkGray);
			point.PointShape = PointShape.Star;
			point.Size = new NLength(6.0f);

			// Points must fit in the chart area
			point.InflateMargins = true;

			// Name points data set
			point.Name = "Observations";

			// Add data points from the NMath DoubleVectors to the point series
			point.Values.AddRange(y.DataBlock.Data);
			point.XValues.AddRange(x.DataBlock.Data);

			// Build polynomial line series and style it
			NLineSeries polyline = new NLineSeries();
			chart.Series.Add(polyline);
			polyline.UseXValues = true;
			polyline.DataLabelStyle.Visible = false;
			polyline.BorderStyle = new NStrokeStyle(2.0f, Color.Tomato);

			// Name polynomial fit
			polyline.Name = polynomialdeg.ToString() + "th Degree Polynomial";

			// Load the polynomial data into the line series
			polyline.XValues.AddRange(xs.DataBlock.Data);
			polyline.Values.AddRange(ys.DataBlock.Data);

			// Create a label to display the polynomial
			NLabel label = new NLabel();
			label.BoundsMode = BoundsMode.None;
			label.ContentAlignment = ContentAlignment.MiddleLeft;
			label.Location = new NPointL(
				new NLength(92, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			label.TextStyle.TextFormat = TextFormat.XML;
			label.TextStyle.FontStyle = new NFontStyle("Arial", 9);
			label.TextStyle.StringFormatStyle.HorzAlign = Nevron.HorzAlign.Center;
			label.TextStyle.BackplaneStyle.Visible = true;
			label.TextStyle.BackplaneStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(180, 255, 255, 255), Color.FromArgb(180, 233, 233, 255));
			label.TextStyle.BackplaneStyle.Shape = BackplaneShape.Rectangle;
			label.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.FromArgb(200, 200, 255);

			label.Text = "Equation for fitted polynomial:<br /><font size='10' color = 'tomato'><b>";
			label.Text += FormatPolymonial(pls.FittedPolynomial.Coeff.ToArray());
			label.Text += "</b></font>";

			chart.ChildPanels.Add(label);

			nChartControl1.Refresh();
		}

		void SetupChartLayout(string titleText)
		{
			nChartControl1.Panels.Clear();

			NLabel title = new NLabel();
			nChartControl1.Panels.Add(title);
			title.Dock = DockStyle.Top;
			title.Padding = new NMarginsL(5, 8, 5, 4);
			title.Text = titleText;
			title.TextStyle.FontStyle = new NFontStyle("Verdana", 12, FontStyle.Bold | FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(68, 90, 108));

			NLegend legend = new NLegend();
			nChartControl1.Panels.Add(legend);
			legend.Dock = DockStyle.Bottom;
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;
			legend.Data.MarkSize = new NSizeL(new NLength(8), new NLength(8));
			legend.Data.CellMargins = new NMarginsL(5, 3, 5, 3);
			legend.Padding = new NMarginsL(1, 1, 1, 7);

			NChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);
			chart.DisplayOnLegend = legend;
			chart.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(233, 233, 255));
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Dock = DockStyle.Fill;
			chart.PositionChildPanelsInContentBounds = true;
			chart.Padding = new NMarginsL(
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage),
					new NLength(6, NRelativeUnit.ParentPercentage));
		}
		void SetupChartAxes(NChart chart)
		{
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Visible = false;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.InnerMajorTickStyle.Visible = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
		}
		string FormatPolymonial(double[] coeff)
		{
			StringBuilder sb = new StringBuilder();

			int last = coeff.Length - 1;

			for(int i = last; i >= 0; i--)
			{
				double c = coeff[i];

				if (i == last)
				{
					if (c < 0)
						sb.Append("-");
				}
				else
				{
					sb.Append((c >= 0) ? " + " : " - ");
				}

				sb.Append(Math.Abs(c).ToString("0.###"));

				if (i > 0)
				{
					sb.Append("x");

					if (i > 1)
					{
						sb.Append("<sup>");
						sb.Append(i.ToString());
						sb.Append("</sup>");
					}
				}				
			}

			return sb.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			nChartControl1.Clear();

			DataSmoothing();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			nChartControl1.Clear();

			LinearRegression();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			nChartControl1.Clear();

			CurveFitting();
		}
		private void linkLabelCenterSpace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.centerspace.net");
		}
		private void linkLabelNevron_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.nevron.com");
		}

		private void pictureBoxNevron_Click(object sender, EventArgs e)
		{
			nChartControl1.ShowEditor();
		}
	}
}
