using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlChartEngine;
using CenterSpace.NMath.Core;

namespace ControlChartsExample
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			nButtonCChart_Click(null, null);
		}

		/// <summary>
		/// Example c-Chart
		/// </summary>
		private void nButtonCChart_Click(object sender, EventArgs e)
		{
			// c-Chart sample data
      // This data-set was copied from the 'pcmanufact' data set packaged with the R qcc package by Luca Scrucca
      //
      // Example Data Description
      // A personal computer manufacturer counts the number of nonconformities per unit on the final
      // assembly line. He collects data on 20 samples of 5 computers each.
      DoubleVector defects = new DoubleVector(10, 12,  8, 14, 10, 16, 11,  7, 10, 15,  9,  5,  7, 11, 12,  6,  8, 10,  7,  5);
      IAttributeChartStats stats_c = new Stats_c(defects, 3, "c-Chart pcmanufact dataset");

			// build the Nevron c-Chart visualization
			this.nQualityControlChart.AutoRefresh = true;
			this.nQualityControlChart.Clear();
			AttributeChart cChart = new AttributeChart(stats_c, this.nQualityControlChart);

		}

		/// <summary>
		/// Example u-Chart
		/// </summary>
		private void nButtonUChart_Click(object sender, EventArgs e)
		{
			// u-Chart sample data
			// This data-set was copied from the 'dyedcloth' data set packaged with the R qcc package by Luca Scrucca
			//
			// Example Data Description
			//In a textile finishing plant, dyed cloth is inspected for the occurrence of defects per 50 square meters.
			//The data on ten rolls of cloth are presenteds
			//    x number of nonconformities per 50 square meters (inspection units)
			//    samplesize number of inspection units in roll (variable sample size
			DoubleVector x = new DoubleVector(14, 12, 20, 11, 7, 10, 21, 16, 19, 23);
			DoubleVector samplesize = new DoubleVector(10.0, 8.0, 13.0, 10.0, 9.5, 10.0, 12.0, 10.5, 12.0, 12.5);
			IAttributeChartStats stats_u = new Stats_u(x, samplesize, 3, "u-Chart, dyedcloth dataset");

			// build the Nevron u-Chart visualization
			this.nQualityControlChart.AutoRefresh = true;
			this.nQualityControlChart.Clear();
			AttributeChart uChart = new AttributeChart(stats_u, this.nQualityControlChart);

		}

    /// <summary>
    /// Example p-Chart
    /// </summary>
    private void nButtonPChart_Click(object sender, EventArgs e)
    {
      // p-Chart sample data
      // This data-set was copied from the 'orangejuice' data set packaged with the R qcc package by Luca Scrucca
      //
      // Example Data Description
      // Frozen orange juice concentrate is packed in 6-oz cardboard cans. These cans are formed on a
      // inspected to determine whether, when filled, the liquid could possible leak either on the side seam or
      // around the bottom joint. If this occurs a can is considered nonconforming. The data were collected
      // as 30 samples of 50 cans each at half-hour intervals over a three-shift period in which the machine
      // was in continuous operation. From sample 15 used a new batch of cardboard stock was put into  
      // production. Sample 23 was obtained when an inexperienced operator was temporarily assigned to
      // the machine. After the first 30 samples, a machine adjustment was made. Then further 24 samples
      // were taken from the process.
      //    failuresPerSample number of failures per 50 cans of orange juice (inspection units)
      //    samplesize number of inspection units in roll (variable sample size
      DoubleVector failuresPerSample = new DoubleVector(12, 15,  8, 10,  4,  7, 16,  9, 14, 10,  5,  6, 17, 12, 22,  8, 10,  5, 13, 11, 20, 18, 24, 15,  9, 12,  7, 13,  9,  6);
      DoubleVector samplesize = new DoubleVector( 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 ,50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50);
      IAttributeChartStats stats_p = new Stats_p(failuresPerSample, samplesize, 3, "p-Chart OrangeJuice dataset", 0, 30, "Group sample every 30 minutes (minutes)", "Group Summary Statistics");

      // build the Nevron p-Chart visualization
      this.nQualityControlChart.AutoRefresh = true;
      this.nQualityControlChart.Clear();
      AttributeChart pChart = new AttributeChart(stats_p, this.nQualityControlChart);

    }

    /// <summary>
    /// Example np-Chart
    /// </summary>
    private void nButtonNPChart_Click(object sender, EventArgs e)
    {
      // np-Chart sample data
      // This data-set was copied from the 'orangejuice' data set packaged with the R qcc package by Luca Scrucca
      //
      // Example Data Description
      // Frozen orange juice concentrate is packed in 6-oz cardboard cans. These cans are formed on a
      // inspected to determine whether, when filled, the liquid could possible leak either on the side seam or
      // around the bottom joint. If this occurs a can is considered nonconforming. The data were collected
      // as 30 samples of 50 cans each at half-hour intervals over a three-shift period in which the machine
      // was in continuous operation. From sample 15 used a new batch of cardboard stock was put into  
      // production. Sample 23 was obtained when an inexperienced operator was temporarily assigned to
      // the machine. After the first 30 samples, a machine adjustment was made. Then further 24 samples
      // were taken from the process.
      //    failuresPerSample number of failures per 50 cans of orange juice (inspection units)
      //    samplesize number of inspection units in roll (variable sample size
      DoubleVector failuresPerSample = new DoubleVector(12, 15, 8, 10, 4, 7, 16, 9, 14, 10, 5, 6, 17, 12, 22, 8, 10, 5, 13, 11, 20, 18, 24, 15, 9, 12, 7, 13, 9, 6);
      int samplesize = 50;
      IAttributeChartStats stats_np = new Stats_np(failuresPerSample, samplesize, 3, "np-Chart OrangeJuice dataset", 0, 30, "Group sample every 30 minutes (minutes)", "Group Summary Statistics");

      // build the Nevron p-Chart visualization
      this.nQualityControlChart.AutoRefresh = true;
      this.nQualityControlChart.Clear();
      AttributeChart npChart = new AttributeChart(stats_np, this.nQualityControlChart);

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
			nQualityControlChart.ShowEditor();
		}
	}
}
