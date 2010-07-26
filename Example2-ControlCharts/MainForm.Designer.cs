namespace ControlChartsExample
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		this.nButtonUChart = new System.Windows.Forms.Button();
		this.nButtonCChart = new System.Windows.Forms.Button();
		this.nQualityControlChart = new Nevron.Chart.WinForm.NChartControl();
		this.panelNevron = new System.Windows.Forms.Panel();
		this.linkLabelNevron = new System.Windows.Forms.LinkLabel();
		this.labelNevron = new System.Windows.Forms.Label();
		this.pictureBoxNevron = new System.Windows.Forms.PictureBox();
		this.panelCenterSpace = new System.Windows.Forms.Panel();
		this.linkLabelCenterSpace = new System.Windows.Forms.LinkLabel();
		this.labelCenterSpace = new System.Windows.Forms.Label();
		this.pictureBoxCenterSpace = new System.Windows.Forms.PictureBox();
		this.nRichDescription = new Nevron.UI.WinForm.Controls.NRichTextBox();
		this.panelNevron.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.pictureBoxNevron)).BeginInit();
		this.panelCenterSpace.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenterSpace)).BeginInit();
		this.SuspendLayout();
		// 
		// nButtonUChart
		// 
		this.nButtonUChart.Location = new System.Drawing.Point(12, 51);
		this.nButtonUChart.Name = "nButtonUChart";
		this.nButtonUChart.Size = new System.Drawing.Size(143, 30);
		this.nButtonUChart.TabIndex = 1;
		this.nButtonUChart.Text = "u Chart";
		this.nButtonUChart.UseVisualStyleBackColor = false;
		this.nButtonUChart.Click += new System.EventHandler(this.nButtonUChart_Click);
		// 
		// nButtonCChart
		// 
		this.nButtonCChart.Location = new System.Drawing.Point(12, 12);
		this.nButtonCChart.Name = "nButtonCChart";
		this.nButtonCChart.Size = new System.Drawing.Size(143, 30);
		this.nButtonCChart.TabIndex = 0;
		this.nButtonCChart.Text = "c Chart";
		this.nButtonCChart.UseVisualStyleBackColor = false;
		this.nButtonCChart.Click += new System.EventHandler(this.nButtonCChart_Click);
		// 
		// nQualityControlChart
		// 
		this.nQualityControlChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.nQualityControlChart.AutoRefresh = false;
		this.nQualityControlChart.BackColor = System.Drawing.SystemColors.Control;
		this.nQualityControlChart.InputKeys = new System.Windows.Forms.Keys[0];
		this.nQualityControlChart.Location = new System.Drawing.Point(169, 12);
		this.nQualityControlChart.Name = "nQualityControlChart";
		this.nQualityControlChart.Size = new System.Drawing.Size(611, 423);
		this.nQualityControlChart.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("nQualityControlChart.State")));
		this.nQualityControlChart.TabIndex = 2;
		this.nQualityControlChart.Text = "Quality Control Chart";
		// 
		// panelNevron
		// 
		this.panelNevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.panelNevron.BackColor = System.Drawing.Color.Gray;
		this.panelNevron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelNevron.Controls.Add(this.linkLabelNevron);
		this.panelNevron.Controls.Add(this.labelNevron);
		this.panelNevron.Controls.Add(this.pictureBoxNevron);
		this.panelNevron.Location = new System.Drawing.Point(610, 443);
		this.panelNevron.Name = "panelNevron";
		this.panelNevron.Size = new System.Drawing.Size(170, 117);
		this.panelNevron.TabIndex = 5;
		// 
		// linkLabelNevron
		// 
		this.linkLabelNevron.AutoSize = true;
		this.linkLabelNevron.ForeColor = System.Drawing.Color.White;
		this.linkLabelNevron.LinkColor = System.Drawing.Color.White;
		this.linkLabelNevron.Location = new System.Drawing.Point(40, 32);
		this.linkLabelNevron.Name = "linkLabelNevron";
		this.linkLabelNevron.Size = new System.Drawing.Size(90, 13);
		this.linkLabelNevron.TabIndex = 1;
		this.linkLabelNevron.TabStop = true;
		this.linkLabelNevron.Text = "www.nevron.com";
		this.linkLabelNevron.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNevron_LinkClicked);
		// 
		// labelNevron
		// 
		this.labelNevron.AutoSize = true;
		this.labelNevron.ForeColor = System.Drawing.Color.White;
		this.labelNevron.Location = new System.Drawing.Point(26, 13);
		this.labelNevron.Name = "labelNevron";
		this.labelNevron.Size = new System.Drawing.Size(117, 13);
		this.labelNevron.TabIndex = 0;
		this.labelNevron.Text = "Visualization by Nevron";
		// 
		// pictureBoxNevron
		// 
		this.pictureBoxNevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.pictureBoxNevron.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.pictureBoxNevron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pictureBoxNevron.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureBoxNevron.Image = global::ControlChartsExample.Properties.Resources.Nevron_Logo;
		this.pictureBoxNevron.Location = new System.Drawing.Point(-1, 59);
		this.pictureBoxNevron.Name = "pictureBoxNevron";
		this.pictureBoxNevron.Size = new System.Drawing.Size(170, 58);
		this.pictureBoxNevron.TabIndex = 0;
		this.pictureBoxNevron.TabStop = false;
		this.pictureBoxNevron.Click += new System.EventHandler(this.pictureBoxNevron_Click);
		// 
		// panelCenterSpace
		// 
		this.panelCenterSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.panelCenterSpace.BackColor = System.Drawing.Color.Gray;
		this.panelCenterSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelCenterSpace.Controls.Add(this.linkLabelCenterSpace);
		this.panelCenterSpace.Controls.Add(this.labelCenterSpace);
		this.panelCenterSpace.Controls.Add(this.pictureBoxCenterSpace);
		this.panelCenterSpace.Location = new System.Drawing.Point(434, 443);
		this.panelCenterSpace.Name = "panelCenterSpace";
		this.panelCenterSpace.Size = new System.Drawing.Size(170, 117);
		this.panelCenterSpace.TabIndex = 4;
		// 
		// linkLabelCenterSpace
		// 
		this.linkLabelCenterSpace.AutoSize = true;
		this.linkLabelCenterSpace.ForeColor = System.Drawing.Color.White;
		this.linkLabelCenterSpace.LinkColor = System.Drawing.Color.White;
		this.linkLabelCenterSpace.Location = new System.Drawing.Point(31, 32);
		this.linkLabelCenterSpace.Name = "linkLabelCenterSpace";
		this.linkLabelCenterSpace.Size = new System.Drawing.Size(111, 13);
		this.linkLabelCenterSpace.TabIndex = 1;
		this.linkLabelCenterSpace.TabStop = true;
		this.linkLabelCenterSpace.Text = "www.centerspace.net";
		this.linkLabelCenterSpace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCenterSpace_LinkClicked);
		// 
		// labelCenterSpace
		// 
		this.labelCenterSpace.AutoSize = true;
		this.labelCenterSpace.ForeColor = System.Drawing.Color.White;
		this.labelCenterSpace.Location = new System.Drawing.Point(12, 13);
		this.labelCenterSpace.Name = "labelCenterSpace";
		this.labelCenterSpace.Size = new System.Drawing.Size(145, 13);
		this.labelCenterSpace.TabIndex = 0;
		this.labelCenterSpace.Text = "Computation by CenterSpace";
		// 
		// pictureBoxCenterSpace
		// 
		this.pictureBoxCenterSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.pictureBoxCenterSpace.BackColor = System.Drawing.Color.White;
		this.pictureBoxCenterSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.pictureBoxCenterSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pictureBoxCenterSpace.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureBoxCenterSpace.Image = global::ControlChartsExample.Properties.Resources.CenterSpace_Logo;
		this.pictureBoxCenterSpace.Location = new System.Drawing.Point(-1, 59);
		this.pictureBoxCenterSpace.Name = "pictureBoxCenterSpace";
		this.pictureBoxCenterSpace.Size = new System.Drawing.Size(177, 71);
		this.pictureBoxCenterSpace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBoxCenterSpace.TabIndex = 0;
		this.pictureBoxCenterSpace.TabStop = false;
		// 
		// nRichDescription
		// 
		this.nRichDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.nRichDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
		this.nRichDescription.Location = new System.Drawing.Point(169, 443);
		this.nRichDescription.Name = "nRichDescription";
		this.nRichDescription.Size = new System.Drawing.Size(259, 118);
		this.nRichDescription.TabIndex = 3;
		this.nRichDescription.TabStop = false;
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(792, 573);
		this.Controls.Add(this.panelNevron);
		this.Controls.Add(this.panelCenterSpace);
		this.Controls.Add(this.nRichDescription);
		this.Controls.Add(this.nQualityControlChart);
		this.Controls.Add(this.nButtonUChart);
		this.Controls.Add(this.nButtonCChart);
		this.MinimumSize = new System.Drawing.Size(800, 600);
		this.Name = "MainForm";
		this.Text = "Control Charts";
		this.Load += new System.EventHandler(this.MainForm_Load);
		this.panelNevron.ResumeLayout(false);
		this.panelNevron.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.pictureBoxNevron)).EndInit();
		this.panelCenterSpace.ResumeLayout(false);
		this.panelCenterSpace.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenterSpace)).EndInit();
		this.ResumeLayout(false);

    }

    #endregion

	private Nevron.UI.WinForm.Controls.NRichTextBox nRichDescription;
	private Nevron.Chart.WinForm.NChartControl nQualityControlChart;
	private System.Windows.Forms.Button nButtonUChart;
	private System.Windows.Forms.Button nButtonCChart;
	private System.Windows.Forms.Panel panelNevron;
	private System.Windows.Forms.LinkLabel linkLabelNevron;
	private System.Windows.Forms.Label labelNevron;
	private System.Windows.Forms.PictureBox pictureBoxNevron;
	private System.Windows.Forms.Panel panelCenterSpace;
	private System.Windows.Forms.LinkLabel linkLabelCenterSpace;
	private System.Windows.Forms.Label labelCenterSpace;
	private System.Windows.Forms.PictureBox pictureBoxCenterSpace;
	
  }
}