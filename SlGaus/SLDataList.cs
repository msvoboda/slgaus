using System;
using System.Windows.Forms;
using System.Drawing;


namespace SLMath
{
	public class SLValueXY : Object 
	{
		public double X;
		public double Y;

		public bool isValid() 
		{
			if (System.Double.IsNaN(X) == true || System.Double.IsNaN(Y) == true)
				return false;
			if (System.Double.IsInfinity(X) == true || System.Double.IsInfinity(Y) == true)
				return false;

			return true;
		}
	}

	public class SLValueList : System.Collections.ArrayList
	{
		public enum PointStyles {Circle, Cube, Cross,  Triangle, Diamond};
		public enum AproximationStyles {aLine, aBezier, aSpline};

		private bool   m_showline;
		private bool   m_showpoints;
		private Color  m_colorline;
		private Color  m_colorpoint;
		private int    m_sizepoint;
		private string m_title;
		private PointStyles m_pointstyle;	
		private AproximationStyles m_aproxstyles;
		
		public SLValueList() 
		{
			m_colorline = Color.Black;
			m_colorpoint = Color.Black;
			m_sizepoint = 2;
			m_showpoints = true;
			m_showline = true;
			m_pointstyle = SLMath.SLValueList.PointStyles.Cross;
			m_aproxstyles = SLMath.SLValueList.AproximationStyles.aLine;
			m_title = "noname";
		}
		
		public override string ToString() 
		{
			return this.Title;
		}

		//data MEMBERS
		//vraci data
		public SLValueXY this[int index] 
		{
			get
			{
				return (SLValueXY) base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		// prida dalsi polozku k datum
		public int Add(SLValueXY data) 
		{
			return base.Add(data);
		}

		public int Add(double x, double y) 
		{
			SLValueXY val = new SLValueXY();
			val.X = x;
			val.Y = y;
			return Add(val);
		}
		// prida polozku
		public void Insert(int index, SLValueXY data) 
		{
			base.Insert(index, data);
		}
		// smaze polozku
		public void Remove(SLValueXY data) 
		{
			base.Remove(data);
		}

		public bool ShowPoints
		{
			get
			{
				return m_showpoints;
			}
			set
			{
				m_showpoints = value;
			}
		}

		public bool ShowLine
		{
			get
			{
				return m_showline;
			}
			set
			{
				m_showline = value;
			}
		}
		
		// barva cary
		public Color ColorLine
		{
			get
			{
				return m_colorline;
			}
			set
			{
				m_colorline = value;
			}
		}

		public Color ColorPoint
		{
			get
			{
				return m_colorpoint;
			}
			set
			{
				m_colorpoint = value;
			}
		}
		public int PointSize
		{
			get
			{
				return m_sizepoint;
			}
			set
			{
				m_sizepoint = value;
			}
		}
		// titulek
		public String Title
		{
			get
			{
				return m_title;
			}
			set
			{
				m_title = value;
			}
		}

		public bool SaveToFile(string fname)
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fname))
			{
				for (int i = 0; i < this.Count; i++) 
				{
					SLValueXY val = (SLValueXY) this[i];
					sw.WriteLine("{0};{1}", val.X, val.Y);
				}
			}

			return true;
		}

		// styl bodu v datove rade
		public PointStyles PointStyle
		{
			get
			{
				return m_pointstyle;
			}
			set
			{
				m_pointstyle = value;
			}
		}

		public AproximationStyles AproxStyle  
		{
			get
			{
				return m_aproxstyles;
			}
			set
			{
				m_aproxstyles = value;
			}
		}


	}
	/// <summary>
	/// SLDataList
	/// </summary>
	public class SLDataList : System.Collections.ArrayList
	{
		
		private Color []FunctionClr;

		public SLDataList()
		{
			FunctionClr = new Color[]{Color.Red,Color.Blue,Color.Green,Color.Yellow,Color.Magenta,
										 Color.Aqua,Color.Brown,Color.Cyan,Color.Maroon, Color.Pink};
		}
		
		//vraci data
		public SLValueList this[int index] 
		{
			get
			{
				return (SLValueList) base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		// prida dalsi polozku k datum
		public int Add(SLValueList data) 
		{
			int idx = base.Add(data);
			int zbytek = idx % FunctionClr.Length;
			data.ColorLine = FunctionClr[zbytek];
			data.ColorPoint = FunctionClr[zbytek]; 
			return idx;
		}
		// prida polozku
		public void Insert(int index, SLValueList data) 
		{
			base.Insert(index, data);
		}
		// smaze polozku
		public void Remove(SLValueList data) 
		{
			base.Remove(data);
		}

	}
}
