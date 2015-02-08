using System;
using System.Drawing;

namespace SLMath
{
	/// <summary>
	/// Trida na vypocty a vykresleni bezierovy krivky 
	/// </summary>
	public class SLBezier 
	{
		// Kresleni Bezierovy krivky
		public void DrawBezier(Graphics g, SLMath.SLValueList ValueList) 
		{

		}

		private static int faktorial(int n)
		{
			int s=1;
			for(int i=n;i>0;i--) 
			{
				s=s*i;
			}
			return s;
		}

		private static float mocnina(float x,int n)
		{
			float s1=1;
			for(int i=0;i<n;i++) 
			{
				s1=s1*x;
		 	}
			return s1;
		}

		public static float berstain(float t, int n, int i)
		{
			return (faktorial(n)/(faktorial(i)*faktorial(n-i)))*mocnina(t,i)*mocnina(1-t,n-i);
		}


	}

	/// <summary>
	/// Trida na vypocty
	/// </summary>
	public class SLCalculator
	{
		public SLMath.SLMathExp math = new SLMath.SLMathExp();

		public SLCalculator() 
		{

		}

		//lepsi nez EveluateFce
		// lze parametrizovat
		// --------------------
		public SLValueList EvalFunction(string expr, double xfrom, double xto, double step) 
		{
			if (xfrom >= xto)
				return null;
			if ((xto-xfrom) < step)
				return null;

			SLValueList newdata = new SLValueList();	
			newdata.Title = expr;
			math.Expresion = expr;
			MathVar var;

			var = math.Get("x");
			if (var == null)
				var = math.AddVariable("x", 0);

			for (double i = xfrom; i < xto+step; i+=(double)step) 
			{
				if (Math.Abs(i) < 0.00001)
					i = 0;

				i = Math.Round(i, 5);
				var.value = i;
				double x = i;
				double y = math.Evaluate();
				SLValueXY val = new SLValueXY();
				val.X = x;
				val.Y = y;
				newdata.Add(val);
			}

			//Add(newdata);
			return newdata;
		}

		// STATICKE FUNKCE
		public static SLValueList EvaluateFce(string expr, double xfrom, double xto, double step)
		{
			if (xfrom >= xto)
				return null;
			if ((xto-xfrom) < step)
				return null;

			SLValueList newdata = new SLValueList();	
			newdata.Title = expr;
			SLMath.SLMathExp math = new SLMathExp();
			math.Expresion = expr;
			MathVar var = math.AddVariable("x", 0);

			for (double i = xfrom; i < xto+step; i+=(double)step) 
			{
				if (Math.Abs(i) < 0.00001)
					i = 0;

				i = Math.Round(i, 5);
				var.value = i;
				double x = i;
				double y = math.Evaluate();
				SLValueXY val = new SLValueXY();
				val.X = x;
				val.Y = y;
				newdata.Add(val);
			}

			//Add(newdata);
			return newdata;
		}

		public static SLValueList DerivateFce(SLValueList Fx)
		{
			SLValueList newdata = new SLValueList();
			
			for(int k = 0;k < Fx.Count-1;k++)
			{
				SLValueXY val1 = (SLMath.SLValueXY)Fx[k];
				SLValueXY val2 = (SLMath.SLValueXY)Fx[k+1];
				SLValueXY newval = new SLValueXY();

				float krok =  (float)val2.X - (float)val1.X; 
				newval.X = val1.X;
				newval.Y = ((float)val2.Y - (float)val1.Y)/krok; //!!!!!!!!!!


				newdata.Add(newval);
			}
			return newdata;
			
			/*double point = System.Convert.ToDouble(bod.Text);
			double krok1 = System.Convert.ToDouble(k1.Text);
			double krok2 = System.Convert.ToDouble(k2.Text);
			double krok3 = System.Convert.ToDouble(k3.Text);
			double krok4 = System.Convert.ToDouble(k4.Text);
			double krok5 = System.Convert.ToDouble(k5.Text);
			double[] prok1 = new double[2];
			double[] prok2 = new double[2];
			double[] prok3 = new double[2];
			double[] prok4 = new double[2];
			double[] prok5 = new double[2];


			if (puntik1.Checked == true)    // dvoubodovka prvni derivace
			{
				prok1[0] = (Fce(point+krok1) - Fce(point))/krok1;
				prok2[0] = (Fce(point+krok2) - Fce(point))/krok2;
				prok3[0] = (Fce(point+krok3) - Fce(point))/krok3;
				prok4[0] = (Fce(point+krok4) - Fce(point))/krok4;
				prok5[0] = (Fce(point+krok5) - Fce(point))/krok5;
			}

			if (puntik2.Checked == true)    // tribodovka prvni derivace
			{
				prok1[0] = (-3*Fce(point) + 4*Fce(point+krok1) - Fce(point+2*krok1))/2*krok1;
				prok2[0] = (-3*Fce(point) + 4*Fce(point+krok2) - Fce(point+2*krok2))/2*krok2;
				prok3[0] = (-3*Fce(point) + 4*Fce(point+krok3) - Fce(point+2*krok3))/2*krok3;
				prok4[0] = (-3*Fce(point) + 4*Fce(point+krok4) - Fce(point+2*krok4))/2*krok4;
				prok5[0] = (-3*Fce(point) + 4*Fce(point+krok5) - Fce(point+2*krok5))/2*krok5;
			}

			if (puntik3.Checked == true)    // ctyrbodovka prvni derivace
			{
				prok1[0] = (-11*Fce(point) + 18*Fce(point+krok1) - 9*Fce(point+2*krok1) + 2*Fce(point+3*krok1))/6*krok1;
				prok2[0] = (-11*Fce(point) + 18*Fce(point+krok2) - 9*Fce(point+2*krok2) + 2*Fce(point+3*krok2))/6*krok2;
				prok3[0] = (-11*Fce(point) + 18*Fce(point+krok3) - 9*Fce(point+2*krok3) + 2*Fce(point+3*krok3))/6*krok3;
				prok4[0] = (-11*Fce(point) + 18*Fce(point+krok4) - 9*Fce(point+2*krok4) + 2*Fce(point+3*krok4))/6*krok4;
				prok5[0] = (-11*Fce(point) + 18*Fce(point+krok5) - 9*Fce(point+2*krok5) + 2*Fce(point+3*krok5))/6*krok5;
			}

			if (puntik4.Checked == true)    // petibodovka prvni derivace
			{
				prok1[0] = (-25*Fce(point) + 48*Fce(point+krok1) - 36*Fce(point+2*krok1) + 16*Fce(point+3*krok1) - 3*Fce(point+4*krok1))/12*krok1;
				prok2[0] = (-25*Fce(point) + 48*Fce(point+krok2) - 36*Fce(point+2*krok2) + 16*Fce(point+3*krok2) - 3*Fce(point+4*krok2))/12*krok2;
				prok3[0] = (-25*Fce(point) + 48*Fce(point+krok3) - 36*Fce(point+2*krok3) + 16*Fce(point+3*krok3) - 3*Fce(point+4*krok3))/12*krok3;
				prok4[0] = (-25*Fce(point) + 48*Fce(point+krok4) - 36*Fce(point+2*krok4) + 16*Fce(point+3*krok4) - 3*Fce(point+4*krok4))/12*krok4;
				prok5[0] = (-25*Fce(point) + 48*Fce(point+krok5) - 36*Fce(point+2*krok5) + 16*Fce(point+3*krok5) - 3*Fce(point+4*krok5))/12*krok5;
			}

			if (puntik5.Checked == true)    // tribodovka druha derivace
			{
				prok1[1] = (Fce(point) - 2*Fce(point+krok1) + Fce(point+2*krok1))/krok1*krok1;
				prok2[1] = (Fce(point) - 2*Fce(point+krok2) + Fce(point+2*krok2))/krok2*krok2;
				prok3[1] = (Fce(point) - 2*Fce(point+krok3) + Fce(point+2*krok3))/krok3*krok3;
				prok4[1] = (Fce(point) - 2*Fce(point+krok4) + Fce(point+2*krok4))/krok4*krok4;
				prok5[1] = (Fce(point) - 2*Fce(point+krok5) + Fce(point+2*krok5))/krok5*krok5;
			}

			if (puntik6.Checked == true)    // ctyrbodovka druha derivace
			{
				prok1[1] = (2*Fce(point) - 5*Fce(point+krok1) + 4*Fce(point+2*krok1) + Fce(point+3*krok1))/krok1*krok1;
				prok2[1] = (2*Fce(point) - 5*Fce(point+krok2) + 4*Fce(point+2*krok2) + Fce(point+3*krok2))/krok2*krok2;
				prok3[1] = (2*Fce(point) - 5*Fce(point+krok3) + 4*Fce(point+2*krok3) + Fce(point+3*krok3))/krok3*krok3;
				prok4[1] = (2*Fce(point) - 5*Fce(point+krok4) + 4*Fce(point+2*krok4) + Fce(point+3*krok4))/krok4*krok4;
				prok5[1] = (2*Fce(point) - 5*Fce(point+krok5) + 4*Fce(point+2*krok5) + Fce(point+3*krok5))/krok5*krok5;
			}



			v1.Text = prok1[0].ToString();
			v2.Text = prok2[0].ToString();
			v3.Text = prok3[0].ToString();
			v4.Text = prok4[0].ToString();
			v5.Text = prok5[0].ToString();
			v6.Text = prok1[1].ToString();
			v7.Text = prok2[1].ToString();
			v8.Text = prok3[1].ToString();
			v9.Text = prok4[1].ToString();
			v10.Text = prok5[1].ToString();*/	
		}

		public static SLValueList EvalPolarFce(string xexpr, string yexpr, double from, double to, double step) 
		{
			if (from >= to)
				return null;
			if ((to-from) < step)
				return null;

			SLValueList newdata = new SLValueList();	
			SLMath.SLMathExp mathx = new SLMathExp();
			SLMath.SLMathExp mathy= new SLMathExp();
			mathx.Expresion = xexpr;
			mathy.Expresion = yexpr;
			MathVar var1 = mathx.AddVariable("x", 0);
			MathVar var2 = mathy.AddVariable("x", 0);

			for (double i = from; i < to+step; i+=(double)step) 
			{
				if (Math.Abs(i) < 0.00001)
					i = 0;

				i = Math.Round(i, 5);
				var1.value = i;
				var2.value = i;
				double x = mathx.Evaluate();
				double y = mathy.Evaluate();
				SLValueXY val = new SLValueXY();
				val.X = x;
				val.Y = y;
				newdata.Add(val);
			}

			//Add(newdata);
			return newdata;
		}

	}
	/// <summary>
	/// Trida na statistickou analyzu 
	/// </summary>
	public class SLStatistic 
	{
		// linearni regrese
		// y=ax+b
		public static void LinearRegresion(SLValueList list, ref double a, ref double b)  
		{
			SLValueList newlist = new SLValueList();
			double sumax = 0;
			double suma2x = 0;
			double sumaxy = 0;
			double sumay = 0;
			double suma2y = 0;
			double prumx = 0;
			double prumy = 0;

			
			for (int i = 0; i < list.Count; i++) 
			{
				SLValueXY val = list[i];
				sumax+=val.X;
				suma2x += val.X*val.X;
				sumay += val.Y;
				suma2y += val.Y*val.Y;
				sumaxy += val.X*val.Y;
			}

			prumx = sumax/list.Count;
			prumy = sumay/list.Count;

			double sx = (1/(float)list.Count*suma2x)-prumx*prumx;
			double sy = (1/(float)list.Count*suma2y)-prumy*prumy;
			double sxy = (1/(float)list.Count*sumaxy)-prumx*prumy;
			
			b = sxy/sx;
			a = prumy-b*prumx;
		}
	}
}
