using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using SLMath;

namespace SlGaus
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SLGaus : System.Windows.Forms.Control
	{
		private float Max_X; // ukladam rozsah os
		private float Min_X;
		private float Max_Y;
		private float Min_Y;
		private float Unit_X;
		private float Unit_Y;
		private float Relative0_X;
		private float Relative0_Y;
		private float Step_X;
		private float Step_Y;
		private const int m_axmargin = 10;
		private int m_lmargin = 20;
		private int m_rmargin = 20;
		private int m_tmargin = 20;
		private int m_bmargin = 20;
		
		private string m_title;
		private string m_axisx;
		private string m_axisy;
		// mouse realne hodnoty prepoc z pixelu
		private float RealMouseX;
		private float RealMouseY;
		private bool m_showxy;
		private bool m_showdataman;
		private DataListDlg m_datadlg;

		private bool GRID_X = true;
		private bool GRID_Y = true;
		private bool m_showlegend = false;
		private float Axis_W = 2;
		private Font AxisFont;
		private DashStyle GridStyle = System.Drawing.Drawing2D.DashStyle.Solid;
		private Color color_Grid = System.Drawing.Color.Gray;
		public SLMath.SLDataList DataList;
		//private Color []FunctionClr;


		public SLGaus()
		{
			Max_X = 2F;
			Min_X = -2F;
			Max_Y = 2F;
			Min_Y = -2F;
			Step_X = 0.5F;
			Step_Y = 0.5F;
			DataList = new SLDataList();
			AxisFont = new Font("Arial", 10);
			m_axisx = "x";
			m_axisy = "y";
			m_title = "Title";
			m_showxy = true;
			m_showdataman = false;
			m_datadlg =	new DataListDlg();

			//*************************
			//FunctionClr = new Color[]{Color.Red,Color.Blue,Color.Green,Color.Yellow,Color.Magenta,
				//					 Color.Aqua,Color.Brown,Color.Cyan,Color.Maroon, Color.Pink};

		}
	
		protected override void OnResize(EventArgs e) 
		{
			base.OnResize(e);
			TransformXY(Max_X,Min_X,Max_Y,Min_Y);
			Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{			
			RealMouseX = this.Real_X(e.X);
			RealMouseY = this.Real_Y(e.Y);
			
			Rectangle rect = new Rectangle((int)x_abs(this.Min_X)+6, (int)y_abs(this.Min_Y)+2,60,25);
			Invalidate(rect);
			rect = new Rectangle(e.X-5, e.Y-5,10,10);
			Invalidate(rect);
			//Invalidate();
			base.OnMouseMove(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{			

			if (e.Button == MouseButtons.Right && m_showdataman == true) 
			{
				m_datadlg.SetDataList(DataList);
				m_datadlg.ShowDialog();
				Invalidate();
				return;
			}
			base.OnMouseMove(e);
		}


		protected override void OnPaint( PaintEventArgs e )
		{
			
			Graphics g = e.Graphics;
			///Font a = new Font("Arial", 10);
			Brush black = System.Drawing.SystemBrushes.WindowText;
			Brush podklad = new SolidBrush(this.BackColor);
			Pen gridPen = new Pen(color_Grid,1);
			gridPen.DashStyle = GridStyle;
			Pen pen = new Pen(System.Drawing.Color.Black,Axis_W);
			Pen blue = System.Drawing.Pens.Blue;
			
			// LEGENDA KE GRAFU
			// vypocet maximalni sirky legendy
			if (m_showlegend == true) 
			{
				SizeF sizel =new SizeF(0,0);
				SizeF tm;
				for (int i = 0; i < DataList.Count;i++)
				{
					SLMath.SLValueList ValueList = DataList[i];
					tm = e.Graphics.MeasureString(ValueList.Title, AxisFont);
					if (tm.Width > sizel.Width) 
					{
						sizel = tm;
					}
				}
				m_rmargin = ((int)sizel.Width)+20;
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
			}

			e.Graphics.FillRectangle(podklad, e.ClipRectangle);
			//e.Graphics.DrawString(Title, a,black,10,10);
			e.Graphics.DrawLine(pen, Relative0_X, m_tmargin, Relative0_X, this.Height-m_bmargin); //y
			e.Graphics.DrawLine(pen, m_lmargin, Relative0_Y, this.Width - m_rmargin,Relative0_Y); //x
			
			// zobrazeni titulku
			if (m_title.Length != 0)
				e.Graphics.DrawString(m_title, Font, new SolidBrush(ForeColor), x_abs(Min_X), 3);
			// zobrazeni popisku osy x
			if (m_axisx.Length != 0) 
			{
				SizeF del = e.Graphics.MeasureString(m_axisx, AxisFont);
				e.Graphics.DrawString(m_axisx, AxisFont, black, x_abs(0)-del.Width/2, y_abs(Min_Y)+5);
			}
			if (m_axisy.Length != 0) 
			{
				StringFormat StrForm = new StringFormat();
				SizeF del = e.Graphics.MeasureString(m_axisx, AxisFont);
				StrForm.FormatFlags = StringFormatFlags.DirectionVertical;
				e.Graphics.DrawString(m_axisy, AxisFont, black, x_abs(Min_X)-del.Height-8, y_abs(0)-del.Width/2, StrForm);
			}
			// zobrazeni legendy
			if (m_showlegend == true) 
			{
				for (int i = 0; i < DataList.Count;i++)
				{
					SLMath.SLValueList ValueList = DataList[i];
					Pen legpen = new Pen(ValueList.ColorLine, 2);
					SizeF posun = e.Graphics.MeasureString("A", AxisFont);
					e.Graphics.DrawLine(legpen, x_abs(this.Max_X)+6, y_abs(this.Max_Y)+posun.Height/2+(posun.Height+2)*i, x_abs(this.Max_X)+12, y_abs(this.Max_Y)+posun.Height/2+(posun.Height+2)*i);
					e.Graphics.DrawString(ValueList.Title, AxisFont,black, x_abs(this.Max_X)+15, y_abs(this.Max_Y)+(posun.Height+2)*i);
				}
			}
			//grid ////////////
			if(GRID_Y == true)
			{
				for (float r = 0 + Step_Y ; r <= Max_Y; r += Step_Y)
				{
					e.Graphics.DrawLine(gridPen, m_lmargin, y_abs(r),this.Width - m_rmargin, y_abs(r));
					//string hodnota = r.ToString();
					//e.Graphics.DrawString(hodnota, a,black,Relative0_X + 10, y_abs(r)- m_margin);
				}

				for (float r = 0 - Step_Y; r >= Min_Y; r -= Step_Y)
				{
					e.Graphics.DrawLine(gridPen, m_lmargin, y_abs(r),this.Width - m_rmargin, y_abs(r));
					//string hodnota = r.ToString();
					//e.Graphics.DrawString(hodnota, a,black,Relative0_X +10, y_abs(r)- m_margin);
				}
			}
			if(GRID_X == true)
			{
				for (float s = 0 + Step_X; s <= Max_X; s += Step_X)
				{
					e.Graphics.DrawLine(gridPen, x_abs(s), m_tmargin, x_abs(s), this.Height - m_bmargin);
					//string hodnota = s.ToString();
					//e.Graphics.DrawString(hodnota, a,black, x_abs(s)-m_margin,Relative0_Y + 10);
				}

				for (float s = 0 - Step_X; s >= Min_X; s -= Step_X)
				{
					e.Graphics.DrawLine(gridPen, x_abs(s), m_tmargin, x_abs(s), this.Height - m_bmargin);
					//string hodnota = s.ToString();
					//e.Graphics.DrawString(hodnota, a,black, x_abs(s)- m_margin,Relative0_Y + 10);
				}
			}
			////////////////////////
			
			//popis os ///////////////////////
			
			for (float s = 0; s <= Max_X; s += Step_X)
			{
				e.Graphics.DrawLine(pen, x_abs(s), Relative0_Y - 3, x_abs(s), Relative0_Y + 3);
				string hodnota = s.ToString();
				e.Graphics.DrawString(hodnota, AxisFont,black, x_abs(s)-m_axmargin,Relative0_Y + 5);
			}

			for (float s = 0 - Step_X; s >= Min_X; s -= Step_X)
			{
				e.Graphics.DrawLine(pen, x_abs(s), Relative0_Y - 3, x_abs(s), Relative0_Y + 3);
				string hodnota = s.ToString();
				e.Graphics.DrawString(hodnota, AxisFont,black, x_abs(s)- m_axmargin,Relative0_Y + 5);
			}

			for (float r = 0 + Step_Y ; r <= Max_Y; r += Step_Y)
			{
				e.Graphics.DrawLine(pen, Relative0_X - 3, y_abs(r),Relative0_X + 3, y_abs(r));
				string hodnota = r.ToString();
				e.Graphics.DrawString(hodnota, AxisFont,black,Relative0_X + 10, y_abs(r)- m_axmargin);
			}

			for (float r = 0 - Step_Y; r >= Min_Y; r -= Step_Y)
			{
				e.Graphics.DrawLine(pen, Relative0_X - 3, y_abs(r),Relative0_X + 3, y_abs(r));
				string hodnota = r.ToString();
				e.Graphics.DrawString(hodnota, AxisFont,black,Relative0_X +10, y_abs(r)- m_axmargin);
			}
			////////////////////////////////
			// kresleni dat
			PaintDataList(e);
			//
			if (m_showxy == true) 
			{
				System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo( "en-US", false ).NumberFormat;
				nfi.NumberDecimalDigits = 2;
				string xy = "x="+RealMouseX.ToString("N", nfi)+"\ny="+RealMouseY.ToString( "N", nfi);
				Font fnt =new Font("Verdana", 8);
				e.Graphics.DrawString(xy, fnt,black, x_abs(this.Min_X)+6, y_abs(this.Min_Y)+2);
			}
			
		}

		//*********** kresleni dat **********
		protected void PaintDataList( PaintEventArgs e )
		{
			for (int i = 0; i < DataList.Count;i++)
			{
				SLMath.SLValueList ValueList = DataList[i];
				int navic = 3 - (ValueList.Count-4) % 3;
				Point[] points = new Point[ValueList.Count+navic];
				Pen barva = new Pen(ValueList.ColorLine);
				Brush BrBarva = new SolidBrush(ValueList.ColorLine);

				if (ValueList.ShowPoints == false && ValueList.ShowLine == false) 
					continue;

				for (int j = 0;j < ValueList.Count;j++)
				{
					//int pocetF = ValueList.Count;
					SLMath.SLValueXY valXY = (SLMath.SLValueXY)ValueList[j];
					if (valXY.isValid() == false)
						continue;


					int bodX1 = (int)(x_abs((float)valXY.X));
					int bodY1 = (int)(y_abs((float)valXY.Y));

					points[j] = new Point(bodX1,bodY1);
						
					if (j == ValueList.Count-1) 
					{
						for (int c = 0; c < navic; c++)
							points[ValueList.Count+c] = new Point(bodX1, bodY1);
					}

					// kresli kolecka ... pokud najedeme mysi na bod
					/*
					if ((RealMouseX >= (float)valXY.X-0.1 && RealMouseX <= (float)valXY.X+0.1) && (RealMouseY >= (float)valXY.Y-0.1 && RealMouseY <= (float)valXY.Y+0.1))
						e.Graphics.FillEllipse(BrBarva,bodX1-ValueList.PointSize-1,bodY1-ValueList.PointSize-1,2*ValueList.PointSize+2,2*ValueList.PointSize+2);*/
					//
					if (ValueList.ShowPoints == true) 
					{
						if (ValueList.PointStyle == SLMath.SLValueList.PointStyles.Cross) 
						{
							e.Graphics.DrawLine(barva,bodX1-ValueList.PointSize,bodY1,bodX1+ValueList.PointSize,bodY1);
							e.Graphics.DrawLine(barva,bodX1,bodY1-ValueList.PointSize,bodX1,bodY1+ValueList.PointSize);
						}
						if (ValueList.PointStyle == SLMath.SLValueList.PointStyles.Circle) 
						{
							e.Graphics.FillEllipse(BrBarva,bodX1-ValueList.PointSize,bodY1-ValueList.PointSize,2*ValueList.PointSize+1,2*ValueList.PointSize+1);
						}
						if (ValueList.PointStyle == SLMath.SLValueList.PointStyles.Cube) 
						{
							e.Graphics.FillRectangle(BrBarva,bodX1-ValueList.PointSize,bodY1-ValueList.PointSize,ValueList.PointSize*2+1, ValueList.PointSize*2+1);
						}
						if (ValueList.PointStyle == SLMath.SLValueList.PointStyles.Diamond) 
						{
							// Create points that define polygon.
							Point point1 = new Point(bodX1-ValueList.PointSize, bodY1);
							Point point2 = new Point(bodX1, bodY1-ValueList.PointSize);
							Point point3 = new Point(bodX1+ValueList.PointSize,  bodY1);
							Point point4 = new Point(bodX1, bodY1+ValueList.PointSize);
							Point[] diamPoints = { point1,point2,point3,point4};
							// Draw polygon to screen.
							e.Graphics.FillPolygon(BrBarva, diamPoints);
						}
						if (ValueList.PointStyle == SLMath.SLValueList.PointStyles.Triangle) 
						{
							// Create points that define polygon.
							Point point1 = new Point(bodX1-(2*ValueList.PointSize/3)-1, (bodY1+ValueList.PointSize/3)+1);
							Point point2 = new Point(bodX1+(2*ValueList.PointSize/3)+1, (bodY1+ValueList.PointSize/3)+1);
							Point point3 = new Point(bodX1, (bodY1-2*ValueList.PointSize/3)-1);
							Point point4 = new Point(bodX1-(2*ValueList.PointSize/3)-1, (bodY1+ValueList.PointSize/3)-1);
							Point[] tryPoints = { point1,point2,point3, point4};
							// Draw polygon to screen.
							e.Graphics.FillPolygon(BrBarva, tryPoints);
						}
					}
					/*
					if (ValueList.ShowLine == true) 
					{
						if (ValueList.AproxStyle == SLMath.SLValueList.AproximationStyles.aLine) 
						{
							e.Graphics.DrawLine(barva,bodX1,bodY1,bodX2,bodY2);
						}
						if (ValueList.AproxStyle == SLMath.SLValueList.AproximationStyles.aBezier) 
						{
							
						}
					}*/
				}
				if (ValueList.ShowLine == true) 
				{
					if (ValueList.AproxStyle == SLMath.SLValueList.AproximationStyles.aLine) 
					{
						e.Graphics.DrawLines(barva, points);
					}
					if (ValueList.AproxStyle == SLMath.SLValueList.AproximationStyles.aBezier) 
					{
						e.Graphics.DrawBeziers(barva, points);	
					}
					if (ValueList.AproxStyle == SLMath.SLValueList.AproximationStyles.aSpline) 
					{
						e.Graphics.DrawCurve(barva, points);	
					}
				}

			}

		}

		[
		Category("GausOptions"),
		Description("Maximum X value")
		]
		public float MaxX
		{
			get
			{
				return Max_X;
			}
			set
			{
				Max_X = value;
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Minimum X value")
		]
		public float MinX
		{
			get
			{
				return Min_X;
			}
			set
			{
				Min_X = value;
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Maximum Y value")
		]
		public float MaxY
		{
			get
			{
				return Max_Y;
			}
			set
			{
				Max_Y = value;
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Minimum Y value")
		]
		public float MinY
		{
			get
			{
				return Min_Y;
			}
			set
			{
				Min_Y = value;
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
		}

		public void TransformXY(float maximX, float minimX, float maximY, float minimY)
		{
			Max_X = maximX; Min_X = minimX; Max_Y = maximY; Min_Y = minimY;

			Unit_X = (this.Width-m_lmargin-m_rmargin)/(Max_X - Min_X);
			Unit_Y = (this.Height-m_tmargin-m_bmargin)/(Max_Y - Min_Y);

			Relative0_X = - Min_X * Unit_X + m_lmargin;
			Relative0_Y = Max_Y * Unit_Y + m_tmargin;
		}

		[
		Category("GausOptions"),
		Description("Step value for X marks")
		]
		public float StepUnitX
		{
			get
			{
				return Step_X;
			}
			set
			{
				Step_X = value;
			}
		}

		[
		Category("GausOptions"),
		Description("Step value for Y marks")
		]
		public float StepUnitY
		{
			get
			{
				return Step_Y;
			}
			set
			{
				Step_Y = value;
			}
		}
		
		// transformace z realneho cisla na pixel v ose x
		public float x_abs(float realx) 
		{
			return Relative0_X + Unit_X*realx;
		}
		// transformace z realneho cisla na pixel v ose y
		public float y_abs(float realy) 
		{
			return Relative0_Y - Unit_Y*realy;
		}
		// vrati realnou hodnotu se zadaneho pixelu
		public float Real_X(float pocpicx)
		{
			return (float) ((pocpicx - Relative0_X)/Unit_X);
		}
		public float Real_Y(float pocpicy)
		{
			return (float) ((Relative0_Y - pocpicy)/Unit_Y);
		}


		[
		Category("GausOptions"),
		Description("Grid X")
		]
		/// <summary>
		/// Grid X Line
		/// </summary>
		public bool XGrid
		{
			get
			{
				return GRID_X;
			}
			set
			{
				GRID_X = value;
				Invalidate();
			}
		}


		[
		Category("GausOptions"),
		Description("Grid Y")
		]
		/// <summary>
		/// Grid Y Line
		/// </summary>
		public bool YGrid
		{
			get
			{
				return GRID_Y;
			}
			set
			{
				GRID_Y = value;
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Set Axis Width")
		]
		/// <summary>
		/// set Axis Width
		/// </summary>
		public float AxisWidth
		{
			get
			{
				return Axis_W;
			}
			set
			{
				Axis_W = value;
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Set style of Grid")
		]
		public DashStyle St_GridPen
		{
			get
			{
				return GridStyle;
			}
			set
			{
				GridStyle = value;
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Set Color of Grid")
		]
		public Color GridColor
		{
			get
			{
				return color_Grid;
			}
			set
			{
				color_Grid = value;
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Set Axis Font")
		]
		public Font Axis_Font
		{
			get
			{
				return AxisFont;
			}
			set
			{
				AxisFont = value;
				Invalidate();
			}
		}

		
		[
		Category("GausOptions"),
		Description("ShowLegend")
		]
			/// <summary>
			/// Zobrazit legendu
			/// </summary>
		public bool ShowLegend
		{
			get
			{
				return m_showlegend;
			}
			set
			{
				m_showlegend = value;
				if (m_showlegend == false) 
				{
					m_rmargin=20;
					TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				}
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("ShowXY")
		]
			/// <summary>
			/// Zobrazit XY mouse
			/// </summary>
		public bool ShowXY
		{
			get
			{
				return m_showxy;
			}
			set
			{
				m_showxy = value;
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("Show DataList manager")
		]
			/// <summary>
			/// Zobrazit XY mouse
			/// </summary>
		public bool ShowDataMan
		{
			get
			{
				return m_showdataman;
			}
			set
			{
				m_showdataman = value;
			}
		}

		[
		Category("GausOptions"),
		Description("Graph title")
		]
			/// <summary>
			/// Titulek grafu
			/// pro titulek se pouziva font Font
			/// </summary>
		public string Title 
		{
			get
			{
				return m_title;
			}
			set
			{
				m_title = value;
				if (m_title.Length == 0) 
				{
					m_tmargin = 20;
				}
				else 
				{							
					m_tmargin = 20 +(int) this.Font.Size + 5;
				}
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
		}

		[
		Category("GausOptions"),
		Description("AxisX")
		]
			/// <summary>
			/// Titulek osyX
			/// </summary>
		public string AxisX 
		{
			get 
			{
				return m_axisx;
			}
			set 
			{
				m_axisx = value;
				if (m_axisx.Length == 0) 
				{
					m_bmargin = 20;
				}
				else 
				{							
					m_bmargin = 20 +(int) AxisFont.Size + 5;
				}
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);
				Invalidate();
			}
			
		}

		[
		Category("GausOptions"),
		Description("AxisY")
		]
			/// <summary>
			/// Titulek osyX
			/// </summary>
		public string AxisY 
		{
			get 
			{
				return m_axisy;
			}
			set 
			{
				m_axisy = value;				
				if (m_axisy.Length == 0) 
				{
					m_lmargin = 20;
				}
				else 
				{							
					m_lmargin = 20 +(int) AxisFont.Size + 5;

				}
				TransformXY(Max_X,Min_X,Max_Y,Min_Y);				
				Invalidate();
			}
			
		}
	}
}
