using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearRegression;

namespace MathNet.Numerics
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class Polynomial : IFormattable, IEquatable<Polynomial>, ICloneable
	{
		[DataMember(Order = 2)]
		public string VariableName = "x";

		[DataMember(Order = 1)]
		public double[] Coefficients { get; private set; }

		public int Degree => EvaluateDegree(Coefficients);

		public static Polynomial Zero => new Polynomial();

		public Polynomial(int n)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "n must be non-negative");
			}
			Coefficients = new double[n];
		}

		public Polynomial()
		{
			Coefficients = Array.Empty<double>();
		}

		public Polynomial(double coefficient)
		{
			if (coefficient == 0.0)
			{
				Coefficients = Array.Empty<double>();
				return;
			}
			Coefficients = new double[1] { coefficient };
		}

		public Polynomial(params double[] coefficients)
		{
			Coefficients = coefficients;
		}

		public Polynomial(IEnumerable<double> coefficients)
			: this(coefficients.ToArray())
		{
		}

		public static Polynomial Fit(double[] x, double[] y, int order, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			return new Polynomial(MathNet.Numerics.Fit.Polynomial(x, y, order, method));
		}

		private static int EvaluateDegree(double[] coefficients)
		{
			for (int num = coefficients.Length - 1; num >= 0; num--)
			{
				if (coefficients[num] != 0.0)
				{
					return num;
				}
			}
			return -1;
		}

		public static double Evaluate(double z, params double[] coefficients)
		{
			if (coefficients == null)
			{
				throw new ArgumentNullException("coefficients");
			}
			int num = coefficients.Length;
			if (num == 0)
			{
				return 0.0;
			}
			double num2 = coefficients[num - 1];
			for (int num3 = num - 2; num3 >= 0; num3--)
			{
				num2 *= z;
				num2 += coefficients[num3];
			}
			return num2;
		}

		public static Complex Evaluate(Complex z, params double[] coefficients)
		{
			if (coefficients == null)
			{
				throw new ArgumentNullException("coefficients");
			}
			int num = coefficients.Length;
			if (num == 0)
			{
				return 0;
			}
			Complex result = coefficients[num - 1];
			for (int num2 = num - 2; num2 >= 0; num2--)
			{
				result *= z;
				result += (Complex)coefficients[num2];
			}
			return result;
		}

		public static Complex Evaluate(Complex z, params Complex[] coefficients)
		{
			if (coefficients == null)
			{
				throw new ArgumentNullException("coefficients");
			}
			int num = coefficients.Length;
			if (num == 0)
			{
				return 0;
			}
			Complex result = coefficients[num - 1];
			for (int num2 = num - 2; num2 >= 0; num2--)
			{
				result *= z;
				result += coefficients[num2];
			}
			return result;
		}

		public double Evaluate(double z)
		{
			return Evaluate(z, Coefficients);
		}

		public Complex Evaluate(Complex z)
		{
			return Evaluate(z, Coefficients);
		}

		public IEnumerable<double> Evaluate(IEnumerable<double> z)
		{
			return z.Select(Evaluate);
		}

		public IEnumerable<Complex> Evaluate(IEnumerable<Complex> z)
		{
			return z.Select(Evaluate);
		}

		public Polynomial Differentiate()
		{
			int degree = Degree;
			if (degree < 0)
			{
				return this;
			}
			if (degree == 0)
			{
				return Zero;
			}
			double[] array = new double[degree];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Coefficients[i + 1] * (double)(i + 1);
			}
			return new Polynomial(array);
		}

		public Polynomial Integrate()
		{
			int degree = Degree;
			if (degree < 0)
			{
				return this;
			}
			double[] array = new double[degree + 2];
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = Coefficients[i - 1] / (double)i;
			}
			return new Polynomial(array);
		}

		public Complex[] Roots()
		{
			switch (Degree)
			{
			case -1:
			case 0:
				return Array.Empty<Complex>();
			case 1:
				return new Complex[1]
				{
					new Complex((0.0 - Coefficients[0]) / Coefficients[1], 0.0)
				};
			default:
				return EigenvalueMatrix().Evd(Symmetricity.Asymmetric).EigenValues.AsArray();
			}
		}

		public DenseMatrix EigenvalueMatrix()
		{
			int degree = Degree;
			if (degree < 2)
			{
				return null;
			}
			double num = Coefficients[degree];
			double[] array = new double[degree];
			for (int num2 = degree - 1; num2 >= 0; num2--)
			{
				array[num2] = (0.0 - Coefficients[num2]) / num;
			}
			DenseMatrix subMatrix = DenseMatrix.CreateDiagonal(degree - 1, degree - 1, 1.0);
			DenseMatrix denseMatrix = new DenseMatrix(degree);
			denseMatrix.SetSubMatrix(1, 0, subMatrix);
			denseMatrix.SetRow(0, array.Reverse().ToArray());
			return denseMatrix;
		}

		public static Polynomial Add(Polynomial a, Polynomial b)
		{
			double[] coefficients = a.Coefficients;
			double[] coefficients2 = b.Coefficients;
			double[] array = new double[Math.Max(a.Degree, b.Degree) + 1];
			int num = Math.Min(Math.Min(coefficients.Length, coefficients2.Length), array.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = coefficients[i] + coefficients2[i];
			}
			int num2 = Math.Min(coefficients.Length, array.Length);
			for (int j = num; j < num2; j++)
			{
				array[j] = coefficients[j];
			}
			int num3 = Math.Min(coefficients2.Length, array.Length);
			for (int k = num; k < num3; k++)
			{
				array[k] = coefficients2[k];
			}
			return new Polynomial(array);
		}

		public static Polynomial Add(Polynomial a, double b)
		{
			double[] coefficients = a.Coefficients;
			double[] array = new double[Math.Max(a.Degree, 0) + 1];
			int num = Math.Min(coefficients.Length, array.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = coefficients[i];
			}
			array[0] += b;
			return new Polynomial(array);
		}

		public static Polynomial Subtract(Polynomial a, Polynomial b)
		{
			double[] coefficients = a.Coefficients;
			double[] coefficients2 = b.Coefficients;
			double[] array = new double[Math.Max(a.Degree, b.Degree) + 1];
			int num = Math.Min(Math.Min(coefficients.Length, coefficients2.Length), array.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = coefficients[i] - coefficients2[i];
			}
			int num2 = Math.Min(coefficients.Length, array.Length);
			for (int j = num; j < num2; j++)
			{
				array[j] = coefficients[j];
			}
			int num3 = Math.Min(coefficients2.Length, array.Length);
			for (int k = num; k < num3; k++)
			{
				array[k] = 0.0 - coefficients2[k];
			}
			return new Polynomial(array);
		}

		public static Polynomial Subtract(Polynomial a, double b)
		{
			return Add(a, 0.0 - b);
		}

		public static Polynomial Subtract(double b, Polynomial a)
		{
			double[] coefficients = a.Coefficients;
			double[] array = new double[Math.Max(a.Degree, 0) + 1];
			int num = Math.Min(coefficients.Length, array.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = 0.0 - coefficients[i];
			}
			array[0] += b;
			return new Polynomial(array);
		}

		public static Polynomial Negate(Polynomial a)
		{
			double[] coefficients = a.Coefficients;
			double[] array = new double[a.Degree + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.0 - coefficients[i];
			}
			return new Polynomial(array);
		}

		public static Polynomial Multiply(Polynomial a, Polynomial b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			int degree = a.Degree;
			int degree2 = b.Degree;
			if (degree < 0 || degree2 < 0)
			{
				return Zero;
			}
			double[] coefficients = a.Coefficients;
			double[] coefficients2 = b.Coefficients;
			double[] array = new double[degree + degree2 + 1];
			for (int i = 0; i <= degree; i++)
			{
				for (int j = 0; j <= degree2; j++)
				{
					array[i + j] += coefficients[i] * coefficients2[j];
				}
			}
			return new Polynomial(array);
		}

		public static Polynomial Multiply(Polynomial a, double k)
		{
			double[] coefficients = a.Coefficients;
			double[] array = new double[a.Degree + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = coefficients[i] * k;
			}
			return new Polynomial(array);
		}

		public static Polynomial Divide(Polynomial a, double k)
		{
			double[] coefficients = a.Coefficients;
			double[] array = new double[a.Degree + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = coefficients[i] / k;
			}
			return new Polynomial(array);
		}

		public static (Polynomial, Polynomial) DivideRemainder(Polynomial a, Polynomial b)
		{
			int degree = b.Degree;
			if (degree < 0)
			{
				throw new DivideByZeroException("b polynomial ends with zero");
			}
			int degree2 = a.Degree;
			if (degree2 < 0)
			{
				return (a, a);
			}
			if (degree == 0)
			{
				return (Divide(a, b.Coefficients[0]), Zero);
			}
			if (degree2 < degree)
			{
				return (Zero, a);
			}
			double[] array = a.Coefficients.ToArray();
			double[] array2 = b.Coefficients.ToArray();
			double num = array2[degree];
			double[] array3 = new double[degree];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = array2[i] / num;
			}
			int num2 = degree2 - degree;
			int num3 = degree2;
			while (num2 >= 0)
			{
				double num4 = array[num3];
				for (int j = num2; j < num3; j++)
				{
					array[j] -= array3[j - num2] * num4;
				}
				num2--;
				num3--;
			}
			int num5 = num3 + 1;
			int num6 = degree2 - num3;
			double[] array4 = new double[num6];
			for (int k = 0; k < num6; k++)
			{
				array4[k] = array[k + num5] / num;
			}
			double[] array5 = new double[num5];
			for (int l = 0; l < num5; l++)
			{
				array5[l] = array[l];
			}
			return (new Polynomial(array4), new Polynomial(array5));
		}

		public static Polynomial PointwiseDivide(Polynomial a, Polynomial b)
		{
			double[] coefficients = a.Coefficients;
			double[] coefficients2 = b.Coefficients;
			double[] array = new double[a.Degree + 1];
			int num = Math.Min(Math.Min(coefficients.Length, coefficients2.Length), array.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = coefficients[i] / coefficients2[i];
			}
			for (int j = num; j < array.Length; j++)
			{
				array[j] = coefficients[j] / 0.0;
			}
			return new Polynomial(array);
		}

		public static Polynomial PointwiseMultiply(Polynomial a, Polynomial b)
		{
			double[] coefficients = a.Coefficients;
			double[] coefficients2 = b.Coefficients;
			double[] array = new double[Math.Min(a.Degree, b.Degree) + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = coefficients[i] * coefficients2[i];
			}
			return new Polynomial(array);
		}

		public (Polynomial, Polynomial) DivideRemainder(Polynomial b)
		{
			return DivideRemainder(this, b);
		}

		public static Polynomial operator +(Polynomial a, Polynomial b)
		{
			return Add(a, b);
		}

		public static Polynomial operator +(Polynomial a, double k)
		{
			return Add(a, k);
		}

		public static Polynomial operator +(double k, Polynomial a)
		{
			return Add(a, k);
		}

		public static Polynomial operator -(Polynomial a, Polynomial b)
		{
			return Subtract(a, b);
		}

		public static Polynomial operator -(Polynomial a, double k)
		{
			return Subtract(a, k);
		}

		public static Polynomial operator -(double k, Polynomial a)
		{
			return Subtract(k, a);
		}

		public static Polynomial operator -(Polynomial a)
		{
			return Negate(a);
		}

		public static Polynomial operator *(Polynomial a, Polynomial b)
		{
			return Multiply(a, b);
		}

		public static Polynomial operator *(Polynomial a, double k)
		{
			return Multiply(a, k);
		}

		public static Polynomial operator *(double k, Polynomial a)
		{
			return Multiply(a, k);
		}

		public static Polynomial operator /(Polynomial a, double k)
		{
			return Divide(a, k);
		}

		public override string ToString()
		{
			return ToString("G", CultureInfo.CurrentCulture);
		}

		public string ToStringDescending()
		{
			return ToStringDescending("G", CultureInfo.CurrentCulture);
		}

		public string ToString(string format)
		{
			return ToString(format, CultureInfo.CurrentCulture);
		}

		public string ToStringDescending(string format)
		{
			return ToStringDescending(format, CultureInfo.CurrentCulture);
		}

		public string ToString(IFormatProvider formatProvider)
		{
			return ToString("G", formatProvider);
		}

		public string ToStringDescending(IFormatProvider formatProvider)
		{
			return ToStringDescending("G", formatProvider);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (Degree < 0)
			{
				return "0";
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			for (int i = 0; i < Coefficients.Length; i++)
			{
				double num = Coefficients[i];
				if (num == 0.0)
				{
					continue;
				}
				if (flag)
				{
					stringBuilder.Append(num.ToString(format, formatProvider));
					if (i > 0)
					{
						stringBuilder.Append(VariableName);
					}
					if (i > 1)
					{
						stringBuilder.Append("^");
						stringBuilder.Append(i);
					}
					flag = false;
					continue;
				}
				if (num < 0.0)
				{
					stringBuilder.Append(" - ");
					stringBuilder.Append((0.0 - num).ToString(format, formatProvider));
				}
				else
				{
					stringBuilder.Append(" + ");
					stringBuilder.Append(num.ToString(format, formatProvider));
				}
				if (i > 0)
				{
					stringBuilder.Append(VariableName);
				}
				if (i > 1)
				{
					stringBuilder.Append("^");
					stringBuilder.Append(i);
				}
			}
			return stringBuilder.ToString();
		}

		public string ToStringDescending(string format, IFormatProvider formatProvider)
		{
			if (Degree < 0)
			{
				return "0";
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			for (int num = Coefficients.Length - 1; num >= 0; num--)
			{
				double num2 = Coefficients[num];
				if (num2 != 0.0)
				{
					if (flag)
					{
						stringBuilder.Append(num2.ToString(format, formatProvider));
						if (num > 0)
						{
							stringBuilder.Append(VariableName);
						}
						if (num > 1)
						{
							stringBuilder.Append("^");
							stringBuilder.Append(num);
						}
						flag = false;
					}
					else
					{
						if (num2 < 0.0)
						{
							stringBuilder.Append(" - ");
							stringBuilder.Append((0.0 - num2).ToString(format, formatProvider));
						}
						else
						{
							stringBuilder.Append(" + ");
							stringBuilder.Append(num2.ToString(format, formatProvider));
						}
						if (num > 0)
						{
							stringBuilder.Append(VariableName);
						}
						if (num > 1)
						{
							stringBuilder.Append("^");
							stringBuilder.Append(num);
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		public bool Equals(Polynomial other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			int degree = Degree;
			if (degree != other.Degree)
			{
				return false;
			}
			for (int i = 0; i <= degree; i++)
			{
				if (!Coefficients[i].Equals(other.Coefficients[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != typeof(Polynomial))
			{
				return false;
			}
			return Equals((Polynomial)obj);
		}

		public override int GetHashCode()
		{
			int num = Math.Min(Degree + 1, 25);
			int num2 = 17;
			for (int i = 0; i < num; i++)
			{
				num2 = num2 * 31 + Coefficients[i].GetHashCode();
			}
			return num2;
		}

		public Polynomial Clone()
		{
			double[] array = new double[EvaluateDegree(Coefficients) + 1];
			Array.Copy(Coefficients, array, array.Length);
			return new Polynomial(array);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}
	}
}
