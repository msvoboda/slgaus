using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SlGaus
{
	/// <summary>
	/// Summary description for ValueListDlg.
	/// </summary>
	public class DataListDlg : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.PropertyGrid property;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ContextMenu popUp;
		private System.Windows.Forms.MenuItem menuDel;
		private System.Windows.Forms.MenuItem menuAdd;
		private SLMath.SLDataList DataList;
		private System.Windows.Forms.MenuItem menuDeriv;

		private AddValueList m_dlgadd;

		public DataListDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_dlgadd = new AddValueList();

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
			this.label = new System.Windows.Forms.Label();
			this.property = new System.Windows.Forms.PropertyGrid();
			this.listBox = new System.Windows.Forms.ListBox();
			this.popUp = new System.Windows.Forms.ContextMenu();
			this.menuAdd = new System.Windows.Forms.MenuItem();
			this.menuDel = new System.Windows.Forms.MenuItem();
			this.menuDeriv = new System.Windows.Forms.MenuItem();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(400, 24);
			this.panel1.TabIndex = 0;
			// 
			// label
			// 
			this.label.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.label.Location = new System.Drawing.Point(0, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(144, 15);
			this.label.TabIndex = 0;
			this.label.Text = "Data list ...";
			// 
			// property
			// 
			this.property.CommandsVisibleIfAvailable = true;
			this.property.LargeButtons = false;
			this.property.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.property.Location = new System.Drawing.Point(200, 24);
			this.property.Name = "property";
			this.property.Size = new System.Drawing.Size(200, 404);
			this.property.TabIndex = 1;
			this.property.Text = "PropertyGrid";
			this.property.ViewBackColor = System.Drawing.SystemColors.Window;
			this.property.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// listBox
			// 
			this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.listBox.ItemHeight = 16;
			this.listBox.Location = new System.Drawing.Point(0, 24);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(200, 404);
			this.listBox.TabIndex = 4;
			this.listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
			this.listBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseMove);
			this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// popUp
			// 
			this.popUp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.menuAdd,
																				  this.menuDel,
																				  this.menuDeriv});
			// 
			// menuAdd
			// 
			this.menuAdd.Index = 0;
			this.menuAdd.Text = "Add";
			this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
			// 
			// menuDel
			// 
			this.menuDel.Index = 1;
			this.menuDel.Text = "Delete";
			this.menuDel.Click += new System.EventHandler(this.menuDel_Click);
			// 
			// menuDeriv
			// 
			this.menuDeriv.Index = 2;
			this.menuDeriv.Text = "Derivate";
			this.menuDeriv.Click += new System.EventHandler(this.menuDeriv_Click);
			// 
			// btnClose
			// 
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(305, 433);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(95, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// DataListDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 455);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.property);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DataListDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ValueListDlg";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void SetDataList(SLMath.SLDataList list)
		{
			DataList = list;
			listBox.Items.Clear();
			for (int i = 0; i < DataList.Count; i++) 
			{
				listBox.Items.Add((object) DataList[i]);
			}

		}

		private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			property.SelectedObject = listBox.Items[listBox.SelectedIndex];
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();		
		}

		private void listBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			SLMath.SLValueList list = (SLMath.SLValueList) listBox.Items[e.Index];
			Rectangle rect = new Rectangle(e.Bounds.Left, e.Bounds.Top+1, e.Bounds.Width-2, e.Bounds.Height-2);
        	Pen pen = Pens.Navy;
			Brush brush;
			brush = new SolidBrush(Color.Black);
		
			e.Graphics.FillRectangle( new SolidBrush(Color.White), e.Bounds);
			if ( (e.State & DrawItemState.Selected) == DrawItemState.Selected ) 
			{
				e.Graphics.DrawRectangle(pen, rect);
			}
			
			Pen lpen = new Pen(list.ColorLine, 2);
			e.Graphics.DrawLine(lpen, rect.Left+4, rect.Top+8, rect.Left+10, rect.Top+8);
						
			e.Graphics.DrawString(list.Title, listBox.Font, brush, new Point(rect.Left+12,rect.Top+1));
		}

		private void menuDel_Click(object sender, System.EventArgs e)
		{
			int idx = listBox.SelectedIndex;
			if (idx != -1) 
			{
				if (MessageBox.Show("Do you want delete data?", "Question?",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
				{
					// smazat data
					listBox.BeginUpdate();
					DataList.RemoveAt(idx);
					this.SetDataList(DataList);
					listBox.EndUpdate();
					listBox.Invalidate();

				}				
			}
		}

		private void listBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{

		}

		private void listBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int idx = listBox.IndexFromPoint(e.X, e.Y);
			if(idx>=0 && e.Button == MouseButtons.Right) 
			{
				listBox.SelectedIndex = idx;				
			}			
			if (e.Button == MouseButtons.Right) 
			{
				popUp.Show(listBox, new Point(e.X, e.Y));
			}
		}

		private void menuAdd_Click(object sender, System.EventArgs e)
		{
			
			m_dlgadd.ShowDialog();
			SLMath.SLValueList val;
			val = m_dlgadd.GetValueList();
			if (val != null) 
			{
				DataList.Add(val);
				listBox.BeginUpdate();
				listBox.Items.Add(val);
				listBox.EndUpdate();
				listBox.Invalidate();
			}
		}

		private void menuDeriv_Click(object sender, System.EventArgs e)
		{
			int idx = listBox.SelectedIndex;
			if (idx != -1) 
			{
				if (MessageBox.Show("Do you want detivate selected valuelist?", "Question?",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
				{
					SLMath.SLValueList val = SLMath.SLCalculator.DerivateFce((SLMath.SLValueList) listBox.Items[idx]);
					val.Title = "Derivation:" + ((SLMath.SLValueList) listBox.Items[idx]).Title;
					DataList.Add(val);
					listBox.BeginUpdate();
					listBox.Items.Add(val);
					listBox.EndUpdate();
					listBox.Invalidate();	
				}				
			}
		}

	}
}
