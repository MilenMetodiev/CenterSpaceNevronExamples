namespace CenterSpaceNevronExamples
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
			this.nChartControl1 = new Nevron.Chart.WinForm.NChartControl();
			this.nRichDescription = new Nevron.UI.WinForm.Controls.NRichTextBox();
			this.pictureBoxCenterSpace = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBoxNevron = new System.Windows.Forms.PictureBox();
			this.panelCenterSpace = new System.Windows.Forms.Panel();
			this.linkLabelCenterSpace = new System.Windows.Forms.LinkLabel();
			this.labelCenterSpace = new System.Windows.Forms.Label();
			this.panelNevron = new System.Windows.Forms.Panel();
			this.linkLabelNevron = new System.Windows.Forms.LinkLabel();
			this.labelNevron = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenterSpace)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNevron)).BeginInit();
			this.panelCenterSpace.SuspendLayout();
			this.panelNevron.SuspendLayout();
			this.SuspendLayout();
			// 
			// nChartControl1
			// 
			this.nChartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nChartControl1.AutoRefresh = false;
			this.nChartControl1.BackColor = System.Drawing.SystemColors.Control;
			this.nChartControl1.InputKeys = new System.Windows.Forms.Keys[0];
			this.nChartControl1.Location = new System.Drawing.Point(169, 11);
			this.nChartControl1.Name = "nChartControl1";
			this.nChartControl1.Size = new System.Drawing.Size(611, 423);
			this.nChartControl1.TabIndex = 4;
			this.nChartControl1.Text = "nChartControl1";
			// 
			// nRichDescription
			// 
			this.nRichDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nRichDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nRichDescription.Location = new System.Drawing.Point(169, 443);
			this.nRichDescription.Name = "nRichDescription";
			this.nRichDescription.Size = new System.Drawing.Size(259, 118);
			this.nRichDescription.TabIndex = 5;
			this.nRichDescription.TabStop = false;
			// 
			// pictureBoxCenterSpace
			// 
			this.pictureBoxCenterSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxCenterSpace.BackColor = System.Drawing.Color.White;
			this.pictureBoxCenterSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBoxCenterSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxCenterSpace.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBoxCenterSpace.Image = global::CenterSpaceNevronExamples.Properties.Resources.CenterSpace_Logo;
			this.pictureBoxCenterSpace.Location = new System.Drawing.Point(-1, 59);
			this.pictureBoxCenterSpace.Name = "pictureBoxCenterSpace";
			this.pictureBoxCenterSpace.Size = new System.Drawing.Size(177, 71);
			this.pictureBoxCenterSpace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCenterSpace.TabIndex = 0;
			this.pictureBoxCenterSpace.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(143, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "Data Smoothing";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 51);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(143, 30);
			this.button2.TabIndex = 1;
			this.button2.Text = "Linear Regression";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 91);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(143, 30);
			this.button3.TabIndex = 2;
			this.button3.Tag = "";
			this.button3.Text = "Polynomial Curve Fitting";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pictureBoxNevron
			// 
			this.pictureBoxNevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxNevron.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBoxNevron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxNevron.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBoxNevron.Image = global::CenterSpaceNevronExamples.Properties.Resources.Nevron_Logo;
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
			this.panelCenterSpace.TabIndex = 6;
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
			this.panelNevron.TabIndex = 7;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label2.Location = new System.Drawing.Point(23, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Click again for new data";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panelNevron);
			this.Controls.Add(this.panelCenterSpace);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.nRichDescription);
			this.Controls.Add(this.nChartControl1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MainForm";
			this.Text = "Curve Fitting";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenterSpace)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNevron)).EndInit();
			this.panelCenterSpace.ResumeLayout(false);
			this.panelCenterSpace.PerformLayout();
			this.panelNevron.ResumeLayout(false);
			this.panelNevron.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Nevron.UI.WinForm.Controls.NRichTextBox nRichDescription;
		private Nevron.Chart.WinForm.NChartControl nChartControl1;
		private System.Windows.Forms.PictureBox pictureBoxCenterSpace;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBoxNevron;
		private System.Windows.Forms.Panel panelCenterSpace;
		private System.Windows.Forms.LinkLabel linkLabelCenterSpace;
		private System.Windows.Forms.Label labelCenterSpace;
		private System.Windows.Forms.Panel panelNevron;
		private System.Windows.Forms.LinkLabel linkLabelNevron;
		private System.Windows.Forms.Label labelNevron;
		private System.Windows.Forms.Label label2;
	}
}

