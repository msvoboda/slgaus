using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SlGaus
{
	/// <summary>
	/// Summary description for AddValueList.
	/// </summary>
	public class AddValueList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelF;
		private System.Windows.Forms.TextBox textFce;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonStorno;
		private System.Windows.Forms.Label labelFr;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.Label labelSt;
		private System.Windows.Forms.NumericUpDown numFrom;
		private System.Windows.Forms.NumericUpDown numTo;
		private System.Windows.Forms.NumericUpDown numStep;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private SLMath.SLValueList m_list;

		public AddValueList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.textFce = new System.Windows.Forms.TextBox();
			this.labelF = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.numStep = new System.Windows.Forms.NumericUpDown();
			this.labelSt = new System.Windows.Forms.Label();
			this.numTo = new System.Windows.Forms.NumericUpDown();
			this.numFrom = new System.Windows.Forms.NumericUpDown();
			this.labelTo = new System.Windows.Forms.Label();
			this.labelFr = new System.Windows.Forms.Label();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonStorno = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFrom)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textFce);
			this.panel1.Controls.Add(this.labelF);
			this.panel1.Location = new System.Drawing.Point(0, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 31);
			this.panel1.TabIndex = 1;
			// 
			// textFce
			// 
			this.textFce.Location = new System.Drawing.Point(123, 4);
			this.textFce.Name = "textFce";
			this.textFce.Size = new System.Drawing.Size(293, 20);
			this.textFce.TabIndex = 1;
			this.textFce.Text = "";
			// 
			// labelF
			// 
			this.labelF.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.labelF.Location = new System.Drawing.Point(8, 7);
			this.labelF.Name = "labelF";
			this.labelF.Size = new System.Drawing.Size(104, 17);
			this.labelF.TabIndex = 0;
			this.labelF.Text = "Function y=f(x):";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.numStep);
			this.panel2.Controls.Add(this.labelSt);
			this.panel2.Controls.Add(this.numTo);
			this.panel2.Controls.Add(this.numFrom);
			this.panel2.Controls.Add(this.labelTo);
			this.panel2.Controls.Add(this.labelFr);
			this.panel2.Location = new System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(432, 112);
			this.panel2.TabIndex = 2;
			// 
			// numStep
			// 
			this.numStep.DecimalPlaces = 2;
			this.numStep.Location = new System.Drawing.Point(18, 72);
			this.numStep.Name = "numStep";
			this.numStep.Size = new System.Drawing.Size(88, 20);
			this.numStep.TabIndex = 5;
			this.numStep.Value = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  65536});
			// 
			// labelSt
			// 
			this.labelSt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.labelSt.Location = new System.Drawing.Point(16, 56);
			this.labelSt.Name = "labelSt";
			this.labelSt.Size = new System.Drawing.Size(96, 16);
			this.labelSt.TabIndex = 4;
			this.labelSt.Text = "Step";
			// 
			// numTo
			// 
			this.numTo.DecimalPlaces = 2;
			this.numTo.Location = new System.Drawing.Point(138, 24);
			this.numTo.Maximum = new System.Decimal(new int[] {
																  1000,
																  0,
																  0,
																  0});
			this.numTo.Minimum = new System.Decimal(new int[] {
																  1000,
																  0,
																  0,
																  -2147483648});
			this.numTo.Name = "numTo";
			this.numTo.Size = new System.Drawing.Size(88, 20);
			this.numTo.TabIndex = 3;
			this.numTo.Value = new System.Decimal(new int[] {
																1,
																0,
																0,
																0});
			// 
			// numFrom
			// 
			this.numFrom.DecimalPlaces = 2;
			this.numFrom.Location = new System.Drawing.Point(18, 24);
			this.numFrom.Maximum = new System.Decimal(new int[] {
																	1000,
																	0,
																	0,
																	0});
			this.numFrom.Minimum = new System.Decimal(new int[] {
																	1000,
																	0,
																	0,
																	-2147483648});
			this.numFrom.Name = "numFrom";
			this.numFrom.Size = new System.Drawing.Size(88, 20);
			this.numFrom.TabIndex = 2;
			this.numFrom.Value = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  -2147483648});
			// 
			// labelTo
			// 
			this.labelTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.labelTo.Location = new System.Drawing.Point(136, 8);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(96, 16);
			this.labelTo.TabIndex = 1;
			this.labelTo.Text = "To";
			// 
			// labelFr
			// 
			this.labelFr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.labelFr.Location = new System.Drawing.Point(16, 8);
			this.labelFr.Name = "labelFr";
			this.labelFr.Size = new System.Drawing.Size(96, 16);
			this.labelFr.TabIndex = 0;
			this.labelFr.Text = "From";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(247, 160);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(88, 31);
			this.buttonAdd.TabIndex = 3;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonStorno
			// 
			this.buttonStorno.Location = new System.Drawing.Point(343, 160);
			this.buttonStorno.Name = "buttonStorno";
			this.buttonStorno.Size = new System.Drawing.Size(88, 31);
			this.buttonStorno.TabIndex = 4;
			this.buttonStorno.Text = "Cancel";
			this.buttonStorno.Click += new System.EventHandler(this.buttonStorno_Click);
			// 
			// AddValueList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 197);
			this.Controls.Add(this.buttonStorno);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "AddValueList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddValueList";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFrom)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonStorno_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void buttonAdd_Click(object sender, System.EventArgs e)
		{
			// zadna funkce
			if (textFce.Text.Length == 0) 
			{
				MessageBox.Show("Write function y=f(x)", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (numFrom.Value > numTo.Value) 
			{
				MessageBox.Show("To value must be greather than From value", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (numStep.Value > (numTo.Value-numFrom.Value)*2) 
			{
				MessageBox.Show("To value must be greather than From value", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			} 
			if (numStep.Value == 0) 
			{
				MessageBox.Show("Step value is ZERO. Why?", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try 
			{
				m_list = SLMath.SLCalculator.EvaluateFce(textFce.Text, (double) numFrom.Value, (double) numTo.Value, (double) numStep.Value);
				m_list.Title = textFce.Text;
			}
			catch
			{
				m_list = null;
			}
			Close();
		}

		public SLMath.SLValueList GetValueList()
		{
			return m_list;
		}
	}
}
