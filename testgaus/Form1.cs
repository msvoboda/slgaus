using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SLMath;

namespace testgaus
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form : System.Windows.Forms.Form
	{
		private SlGaus.DataListDlg dlg;
		private SlGaus.SLGaus slGaus1;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.ListBox listFce;
		private System.Windows.Forms.Label label1;
		private SlGaus.SLGaus slGaus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			dlg = new SlGaus.DataListDlg();

			SLMath.SLValueList data;
			data= SLMath.SLCalculator.EvaluateFce("3*cos(x)", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("3*sin(x)", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("x*x*x", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("exp(x)", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("ln(x)", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aLine;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("x*x*x/(x*x-4)", -10, 10, 0.05);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.ShowPoints = false;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aLine;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("x*x*x+5/(x*x-4)/2", -2, 2, 0.05);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.ShowPoints = false;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aLine;
			listFce.Items.Add(data);
			data= SLMath.SLCalculator.EvaluateFce("x*x*x+5/(x*x-4)/2", -2, 2, 0.05);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.ShowPoints = false;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aLine;
			listFce.Items.Add(data);
			//10*(1-2/(2-1.5)*exp(-[X]/2)+1.5/(2-1.5)*exp(-[X]/1.5))
			/*
			data= SLMath.ComputerFce.EvaluateFce("10*(1-2/(2-1.5)*exp(-x/2)+1.5/(2-1.5)*exp(-x/1.5))", -10, 10, 0.5);
			data.PointStyle = SLMath.SLValueList.PointStyles.Cross;
			data.PointSize = 5;
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);*/
			///// polarni //////////
			data = SLMath.SLCalculator.EvalPolarFce("2*(x-sin(x))", "2*(1-cos(x))", -10,10, 0.2);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.Title = "Cykloida";
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data = SLMath.SLCalculator.EvalPolarFce("10*sin(x)*sin(x)*sin(x)", "10*cos(x)*cos(x)*cos(x)", -10,10, 0.2);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.Title = "Asteroida";
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
			data = SLMath.SLCalculator.EvalPolarFce("10*sin(x)", "10*sin(x)*cos(x)", -10,10, 0.2);
			data.PointStyle = SLMath.SLValueList.PointStyles.Circle;
			data.PointSize = 2;
			data.Title = "Geronova lemniskáta";
			data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
			listFce.Items.Add(data);
            // lisajous
            data = SLMath.SLCalculator.EvalPolarFce("3*sin(3*x)", "3*cos(5*x)", 0, 10, 0.2);
            data.ShowPoints = false;
            data.Title = "Lissajousovy obrazce";
            data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
            listFce.Items.Add(data);
            // 
            data = SLMath.SLCalculator.EvalPolarFce("0.1*x*cos(x)", "0.1*x*sin(x)", 0, 100, 0.2);
            data.ShowPoints = false;
            data.Title = "Spirala";
            data.AproxStyle = SLMath.SLValueList.AproximationStyles.aSpline;
            listFce.Items.Add(data);
			//slGaus.DataList.Add(data);
			

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.slGaus1 = new SlGaus.SLGaus();
			this.slGaus = new SlGaus.SLGaus();
			this.listBox = new System.Windows.Forms.ListBox();
			this.listFce = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// slGaus1
			// 
			this.slGaus1.Axis_Font = new System.Drawing.Font("Arial", 10F);
			this.slGaus1.AxisWidth = 2F;
			this.slGaus1.AxisX = "x";
			this.slGaus1.AxisY = "y";
			this.slGaus1.GridColor = System.Drawing.Color.Gray;
			this.slGaus1.Location = new System.Drawing.Point(0, 0);
			this.slGaus1.MaxX = 2F;
			this.slGaus1.MaxY = 2F;
			this.slGaus1.MinX = -2F;
			this.slGaus1.MinY = -2F;
			this.slGaus1.Name = "slGaus1";
			this.slGaus1.ShowDataMan = false;
			this.slGaus1.ShowLegend = false;
			this.slGaus1.ShowXY = true;
			this.slGaus1.St_GridPen = System.Drawing.Drawing2D.DashStyle.Solid;
			this.slGaus1.StepUnitX = 0.5F;
			this.slGaus1.StepUnitY = 0.5F;
			this.slGaus1.TabIndex = 0;
			this.slGaus1.Title = "Title";
			this.slGaus1.XGrid = true;
			this.slGaus1.YGrid = true;
			// 
			// slGaus
			// 
			this.slGaus.Axis_Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.slGaus.AxisWidth = 2F;
			this.slGaus.AxisX = "x";
			this.slGaus.AxisY = "y";
			this.slGaus.BackColor = System.Drawing.Color.AliceBlue;
			this.slGaus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.slGaus.GridColor = System.Drawing.Color.MidnightBlue;
			this.slGaus.Location = new System.Drawing.Point(200, 0);
			this.slGaus.MaxX = 10F;
			this.slGaus.MaxY = 10F;
			this.slGaus.MinX = -10F;
			this.slGaus.MinY = -10F;
			this.slGaus.Name = "slGaus";
			this.slGaus.ShowDataMan = true;
			this.slGaus.ShowLegend = false;
			this.slGaus.ShowXY = true;
			this.slGaus.Size = new System.Drawing.Size(536, 496);
			this.slGaus.St_GridPen = System.Drawing.Drawing2D.DashStyle.Dash;
			this.slGaus.StepUnitX = 1F;
			this.slGaus.StepUnitY = 1F;
			this.slGaus.TabIndex = 1;
			this.slGaus.Text = "slGaus";
			this.slGaus.Title = "Graph";
			this.slGaus.XGrid = true;
			this.slGaus.YGrid = true;
			// 
			// listBox
			// 
			this.listBox.Location = new System.Drawing.Point(0, 0);
			this.listBox.Name = "listBox";
			this.listBox.TabIndex = 0;
			// 
			// listFce
			// 
			this.listFce.Location = new System.Drawing.Point(4, 32);
			this.listFce.Name = "listFce";
			this.listFce.Size = new System.Drawing.Size(188, 420);
			this.listFce.TabIndex = 2;
			this.listFce.SelectedIndexChanged += new System.EventHandler(this.listFce_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Funtions:";
			// 
			// Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 493);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listFce);
			this.Controls.Add(this.slGaus);
			this.Controls.Add(this.slGaus1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form";
			this.Text = "Graf";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form());
		}


		private void listFce_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (listFce.SelectedIndex == -1)
				return;

			SLValueList	val = (SLValueList) listFce.Items[listFce.SelectedIndex];	

			slGaus.DataList.Clear();
			slGaus.DataList.Add(val);
			slGaus.Invalidate();
		}
	}
}
