using System;
using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra
{
	public static class VectorExtensions
	{
		public static Vector<float> ToSingle(this Vector<double> vector)
		{
			return vector.Map((double x) => (float)x);
		}

		public static Vector<double> ToDouble(this Vector<float> vector)
		{
			return vector.Map((Func<float, double>)((float x) => x), Zeros.AllowSkip);
		}

		public static Vector<MathNet.Numerics.Complex32> ToComplex32(this Vector<System.Numerics.Complex> vector)
		{
			return vector.Map((System.Numerics.Complex x) => new MathNet.Numerics.Complex32((float)x.Real, (float)x.Imaginary));
		}

		public static Vector<System.Numerics.Complex> ToComplex(this Vector<MathNet.Numerics.Complex32> vector)
		{
			return vector.Map((MathNet.Numerics.Complex32 x) => new System.Numerics.Complex(x.Real, x.Imaginary));
		}

		public static Vector<MathNet.Numerics.Complex32> ToComplex32(this Vector<float> vector)
		{
			return vector.Map((float x) => new MathNet.Numerics.Complex32(x, 0f));
		}

		public static Vector<System.Numerics.Complex> ToComplex(this Vector<double> vector)
		{
			return vector.Map((double x) => new System.Numerics.Complex(x, 0.0));
		}

		public static Vector<double> Real(this Vector<System.Numerics.Complex> vector)
		{
			return vector.Map((System.Numerics.Complex x) => x.Real);
		}

		public static Vector<float> Real(this Vector<MathNet.Numerics.Complex32> vector)
		{
			return vector.Map((MathNet.Numerics.Complex32 x) => x.Real);
		}

		public static Vector<double> Imaginary(this Vector<System.Numerics.Complex> vector)
		{
			return vector.Map((System.Numerics.Complex x) => x.Imaginary);
		}

		public static Vector<float> Imaginary(this Vector<MathNet.Numerics.Complex32> vector)
		{
			return vector.Map((MathNet.Numerics.Complex32 x) => x.Imaginary);
		}
	}
}
