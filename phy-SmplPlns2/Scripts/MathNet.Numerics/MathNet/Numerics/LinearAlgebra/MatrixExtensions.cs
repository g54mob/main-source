using System;
using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra
{
	public static class MatrixExtensions
	{
		public static Matrix<float> ToSingle(this Matrix<double> matrix)
		{
			return matrix.Map((double x) => (float)x);
		}

		public static Matrix<double> ToDouble(this Matrix<float> matrix)
		{
			return matrix.Map((Func<float, double>)((float x) => x), Zeros.AllowSkip);
		}

		public static Matrix<MathNet.Numerics.Complex32> ToComplex32(this Matrix<System.Numerics.Complex> matrix)
		{
			return matrix.Map((System.Numerics.Complex x) => new MathNet.Numerics.Complex32((float)x.Real, (float)x.Imaginary));
		}

		public static Matrix<System.Numerics.Complex> ToComplex(this Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return matrix.Map((MathNet.Numerics.Complex32 x) => new System.Numerics.Complex(x.Real, x.Imaginary));
		}

		public static Matrix<MathNet.Numerics.Complex32> ToComplex32(this Matrix<float> matrix)
		{
			return matrix.Map((float x) => new MathNet.Numerics.Complex32(x, 0f));
		}

		public static Matrix<System.Numerics.Complex> ToComplex(this Matrix<double> matrix)
		{
			return matrix.Map((double x) => new System.Numerics.Complex(x, 0.0));
		}

		public static Matrix<double> Real(this Matrix<System.Numerics.Complex> matrix)
		{
			return matrix.Map((System.Numerics.Complex x) => x.Real);
		}

		public static Matrix<float> Real(this Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return matrix.Map((MathNet.Numerics.Complex32 x) => x.Real);
		}

		public static Matrix<double> Imaginary(this Matrix<System.Numerics.Complex> matrix)
		{
			return matrix.Map((System.Numerics.Complex x) => x.Imaginary);
		}

		public static Matrix<float> Imaginary(this Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return matrix.Map((MathNet.Numerics.Complex32 x) => x.Imaginary);
		}
	}
}
