using System;
using System.Numerics;

namespace MathNet.Numerics
{
	public static class Trig
	{
		private const double DegreeToGradConstant = 1.1111111111111112;

		public static double DegreeToGrad(double degree)
		{
			return degree * 1.1111111111111112;
		}

		public static double DegreeToRadian(double degree)
		{
			return degree * (Math.PI / 180.0);
		}

		public static double GradToDegree(double grad)
		{
			return grad * 0.9;
		}

		public static double GradToRadian(double grad)
		{
			return grad * (Math.PI / 200.0);
		}

		public static double RadianToDegree(double radian)
		{
			return radian / (Math.PI / 180.0);
		}

		public static double RadianToGrad(double radian)
		{
			return radian / (Math.PI / 200.0);
		}

		public static double Sinc(double x)
		{
			double num = Math.PI * x;
			if (!num.AlmostEqual(0.0, 15))
			{
				return Math.Sin(num) / num;
			}
			return 1.0;
		}

		public static double Sin(double radian)
		{
			return Math.Sin(radian);
		}

		public static Complex Sin(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Sin(value.Real), 0.0);
			}
			return new Complex(Sin(value.Real) * Cosh(value.Imaginary), Cos(value.Real) * Sinh(value.Imaginary));
		}

		public static double Cos(double radian)
		{
			return Math.Cos(radian);
		}

		public static Complex Cos(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Cos(value.Real), 0.0);
			}
			return new Complex(Cos(value.Real) * Cosh(value.Imaginary), (0.0 - Sin(value.Real)) * Sinh(value.Imaginary));
		}

		public static double Tan(double radian)
		{
			return Math.Tan(radian);
		}

		public static Complex Tan(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Tan(value.Real), 0.0);
			}
			Complex complex = new Complex(0.0 - value.Imaginary, value.Real).Tanh();
			return new Complex(complex.Imaginary, 0.0 - complex.Real);
		}

		public static double Cot(double radian)
		{
			return 1.0 / Math.Tan(radian);
		}

		public static Complex Cot(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Cot(value.Real), 0.0);
			}
			Complex complex = new Complex(value.Imaginary, 0.0 - value.Real).Coth();
			return new Complex(complex.Imaginary, 0.0 - complex.Real);
		}

		public static double Sec(double radian)
		{
			return 1.0 / Math.Cos(radian);
		}

		public static Complex Sec(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Sec(value.Real), 0.0);
			}
			double num = Cos(value.Real);
			double num2 = Sinh(value.Imaginary);
			double num3 = num * num + num2 * num2;
			return new Complex(num * Cosh(value.Imaginary) / num3, Sin(value.Real) * num2 / num3);
		}

		public static double Csc(double radian)
		{
			return 1.0 / Math.Sin(radian);
		}

		public static Complex Csc(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Csc(value.Real), 0.0);
			}
			double num = Sin(value.Real);
			double num2 = Sinh(value.Imaginary);
			double num3 = num * num + num2 * num2;
			return new Complex(num * Cosh(value.Imaginary) / num3, (0.0 - Cos(value.Real)) * num2 / num3);
		}

		public static double Asin(double opposite)
		{
			return Math.Asin(opposite);
		}

		public static Complex Asin(this Complex value)
		{
			if (value.Imaginary > 0.0 || (value.Imaginary == 0.0 && value.Real < 0.0))
			{
				return -(-value).Asin();
			}
			return -Complex.ImaginaryOne * ((1 - value.Square()).SquareRoot() + Complex.ImaginaryOne * value).Ln();
		}

		public static double Acos(double adjacent)
		{
			return Math.Acos(adjacent);
		}

		public static Complex Acos(this Complex value)
		{
			if (value.Imaginary < 0.0 || (value.Imaginary == 0.0 && value.Real > 0.0))
			{
				return Math.PI - (-value).Acos();
			}
			return -Complex.ImaginaryOne * (value + Complex.ImaginaryOne * (1 - value.Square()).SquareRoot()).Ln();
		}

		public static double Atan(double opposite)
		{
			return Math.Atan(opposite);
		}

		public static Complex Atan(this Complex value)
		{
			Complex complex = new Complex(0.0 - value.Imaginary, value.Real);
			return new Complex(0.0, 0.5) * ((1 - complex).Ln() - (1 + complex).Ln());
		}

		public static double Acot(double adjacent)
		{
			return Math.Atan(1.0 / adjacent);
		}

		public static Complex Acot(this Complex value)
		{
			if (value.IsZero())
			{
				return Math.PI / 2.0;
			}
			Complex complex = Complex.ImaginaryOne / value;
			return Complex.ImaginaryOne * 0.5 * ((1.0 - complex).Ln() - (1.0 + complex).Ln());
		}

		public static double Asec(double hypotenuse)
		{
			return Math.Acos(1.0 / hypotenuse);
		}

		public static Complex Asec(this Complex value)
		{
			Complex complex = 1 / value;
			return -Complex.ImaginaryOne * (complex + Complex.ImaginaryOne * (1 - complex.Square()).SquareRoot()).Ln();
		}

		public static double Acsc(double hypotenuse)
		{
			return Math.Asin(1.0 / hypotenuse);
		}

		public static Complex Acsc(this Complex value)
		{
			Complex complex = 1 / value;
			return -Complex.ImaginaryOne * (Complex.ImaginaryOne * complex + (1 - complex.Square()).SquareRoot()).Ln();
		}

		public static double Sinh(double angle)
		{
			return (Math.Exp(angle) - Math.Exp(0.0 - angle)) / 2.0;
		}

		public static Complex Sinh(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Sinh(value.Real), 0.0);
			}
			if (Math.Abs(value.Real) >= 22.0)
			{
				double num = Math.Exp(Math.Abs(value.Real)) * 0.5;
				return new Complex((double)Math.Sign(value.Real) * num * Cos(value.Imaginary), num * Sin(value.Imaginary));
			}
			return new Complex(Sinh(value.Real) * Cos(value.Imaginary), Cosh(value.Real) * Sin(value.Imaginary));
		}

		public static double Cosh(double angle)
		{
			return (Math.Exp(angle) + Math.Exp(0.0 - angle)) / 2.0;
		}

		public static Complex Cosh(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Cosh(value.Real), 0.0);
			}
			if (Math.Abs(value.Real) >= 22.0)
			{
				double num = Math.Exp(Math.Abs(value.Real)) * 0.5;
				return new Complex(num * Cos(value.Imaginary), (double)Math.Sign(value.Real) * num * Sin(value.Imaginary));
			}
			return new Complex(Cosh(value.Real) * Cos(value.Imaginary), Sinh(value.Real) * Sin(value.Imaginary));
		}

		public static double Tanh(double angle)
		{
			if (angle > 19.1)
			{
				return 1.0;
			}
			if (angle < -19.1)
			{
				return -1.0;
			}
			double num = Math.Exp(angle);
			double num2 = Math.Exp(0.0 - angle);
			return (num - num2) / (num + num2);
		}

		public static Complex Tanh(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Tanh(value.Real), 0.0);
			}
			if (Math.Abs(value.Real) >= 22.0)
			{
				double num = Math.Exp(0.0 - Math.Abs(value.Real));
				if (num != 0.0)
				{
					return new Complex(Math.Sign(value.Real), 4.0 * Math.Cos(value.Imaginary) * Math.Sin(value.Imaginary) * num * num);
				}
				return new Complex(Math.Sign(value.Real), 0.0);
			}
			double num2 = Tan(value.Imaginary);
			double num3 = 1.0 + num2 * num2;
			double num4 = Sinh(value.Real);
			double num5 = Cosh(value.Real);
			if (double.IsInfinity(num2))
			{
				return new Complex(num5 / num4, 0.0);
			}
			double num6 = 1.0 + num3 * num4 * num4;
			return new Complex(num3 * num5 * num4 / num6, num2 / num6);
		}

		public static double Coth(double angle)
		{
			if (angle > 19.115)
			{
				return 1.0;
			}
			if (angle < -19.115)
			{
				return -1.0;
			}
			double num = Math.Exp(angle);
			double num2 = Math.Exp(0.0 - angle);
			return (num + num2) / (num - num2);
		}

		public static Complex Coth(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Coth(value.Real), 0.0);
			}
			return Complex.One / value.Tanh();
		}

		public static double Sech(double angle)
		{
			return 1.0 / Cosh(angle);
		}

		public static Complex Sech(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Sech(value.Real), 0.0);
			}
			double num = Tan(value.Imaginary);
			double num2 = Cos(value.Imaginary);
			double num3 = 1.0 + num * num;
			double num4 = Math.Sinh(value.Real);
			double num5 = Math.Cosh(value.Real);
			if (Math.Abs(value.Real) >= 22.0)
			{
				double num6 = Math.Exp(0.0 - Math.Abs(value.Real));
				if (num6 != 0.0)
				{
					return new Complex(4.0 * num5 * num2 * num6 * num6, -4.0 * num4 * num * num2 * num6 * num6);
				}
				return new Complex(0.0, 0.0);
			}
			if (double.IsInfinity(num))
			{
				return new Complex(0.0, (double)(-Math.Sign(num)) / num4);
			}
			double num7 = 1.0 + num3 * num4 * num4;
			return new Complex(num5 / num2 / num7, (0.0 - num4) * num / num2 / num7);
		}

		public static double Csch(double angle)
		{
			return 1.0 / Sinh(angle);
		}

		public static Complex Csch(this Complex value)
		{
			if (value.IsReal())
			{
				return new Complex(Csch(value.Real), 0.0);
			}
			double num = Cot(value.Imaginary);
			double num2 = Sin(value.Imaginary);
			double num3 = 1.0 + num * num;
			double num4 = Sinh(value.Real);
			double num5 = Cosh(value.Real);
			if (Math.Abs(value.Real) >= 22.0)
			{
				double num6 = Math.Exp(0.0 - Math.Abs(value.Real));
				if (num6 != 0.0)
				{
					return new Complex(4.0 * num4 * num * num2 * num6 * num6, -4.0 * num5 * num2 * num6 * num6);
				}
				return new Complex(0.0, 0.0);
			}
			if (double.IsInfinity(num))
			{
				return new Complex((double)Math.Sign(num) / num4, 0.0);
			}
			double num7 = 1.0 + num3 * num4 * num4;
			return new Complex(num4 * num / num2 / num7, (0.0 - num5) / num2 / num7);
		}

		public static double Asinh(double value)
		{
			if (Math.Abs(value) >= 268435456.0)
			{
				return (double)Math.Sign(value) * (Math.Log(Math.Abs(value)) + Math.Log(2.0));
			}
			return (double)Math.Sign(value) * Math.Log(Math.Abs(value) + Math.Sqrt(value * value + 1.0));
		}

		public static Complex Asinh(this Complex value)
		{
			return (value + (value.Square() + 1).SquareRoot()).Ln();
		}

		public static double Acosh(double value)
		{
			if (Math.Abs(value) >= 268435456.0)
			{
				return Math.Log(value) + Math.Log(2.0);
			}
			return Math.Log(value + Math.Sqrt(value - 1.0) * Math.Sqrt(value + 1.0), Math.E);
		}

		public static Complex Acosh(this Complex value)
		{
			return (value + (value - 1).SquareRoot() * (value + 1).SquareRoot()).Ln();
		}

		public static double Atanh(double value)
		{
			return 0.5 * Math.Log((1.0 + value) / (1.0 - value), Math.E);
		}

		public static Complex Atanh(this Complex value)
		{
			return 0.5 * ((1 + value).Ln() - (1 - value).Ln());
		}

		public static double Acoth(double value)
		{
			return 0.5 * Math.Log((value + 1.0) / (value - 1.0), Math.E);
		}

		public static Complex Acoth(this Complex value)
		{
			Complex complex = 1.0 / value;
			return 0.5 * ((1.0 + complex).Ln() - (1.0 - complex).Ln());
		}

		public static double Asech(double value)
		{
			return Acosh(1.0 / value);
		}

		public static Complex Asech(this Complex value)
		{
			Complex complex = 1 / value;
			return (complex + (complex - 1).SquareRoot() * (complex + 1).SquareRoot()).Ln();
		}

		public static double Acsch(double value)
		{
			return Asinh(1.0 / value);
		}

		public static Complex Acsch(this Complex value)
		{
			Complex complex = 1 / value;
			return (complex + (complex.Square() + 1).SquareRoot()).Ln();
		}
	}
}
