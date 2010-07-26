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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nButtonCChart_Click(object sender, EventArgs e)
		{
			// c-Chart sample data
			IAttributeChartStats stats_c = new Stats_c(new CenterSpace.NMath.Core.DoubleVector(1, 2, 12, 3, 2, 1, 2, 3, 2, 5, 4, 0, -3));

			// build the Nevron c-Chart visualization
			this.nQualityControlChart.AutoRefresh = true;
			this.nQualityControlChart.Clear();
			AttributeChart cChart = new AttributeChart(stats_c, this.nQualityControlChart);

		}

		/// <summary>
		/// Example u-Chart
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			IAttributeChartStats stats_u = new Stats_u(x, samplesize);

			// build the Nevron u-Chart visualization
			this.nQualityControlChart.AutoRefresh = true;
			this.nQualityControlChart.Clear();
			AttributeChart cChart = new AttributeChart(stats_u, this.nQualityControlChart);

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
