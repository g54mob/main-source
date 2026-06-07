using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.LinearRegression
{
	public static class WeightedRegression
	{
		public static Vector<T> Weighted<T>(Matrix<T> x, Vector<T> y, Matrix<T> w) where T : struct, IEquatable<T>, IFormattable
		{
			return x.TransposeThisAndMultiply(w * x).Cholesky().Solve(x.TransposeThisAndMultiply(w * y));
		}

		public static Matrix<T> Weighted<T>(Matrix<T> x, Matrix<T> y, Matrix<T> w) where T : struct, IEquatable<T>, IFormattable
		{
			return x.TransposeThisAndMultiply(w * x).Cholesky().Solve(x.TransposeThisAndMultiply(w * y));
		}

		public static T[] Weighted<T>(T[][] x, T[] y, T[] w, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.DenseOfRowArrays(x);
			if (intercept)
			{
				matrix = matrix.InsertColumn(0, Vector<T>.Build.Dense(matrix.RowCount, Vector<T>.One));
			}
			Vector<T> vector = Vector<T>.Build.Dense(y);
			Matrix<T> matrix2 = Matrix<T>.Build.Diagonal(w);
			return matrix.TransposeThisAndMultiply(matrix2 * matrix).Cholesky().Solve(matrix.TransposeThisAndMultiply(matrix2 * vector))
				.ToArray();
		}

		public static T[] Weighted<T>(IEnumerable<Tuple<T[], T>> samples, T[] weights, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return Weighted(x, y, weights, intercept);
		}

		public static T[] Weighted<T>(IEnumerable<(T[], T)> samples, T[] weights, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return Weighted(x, y, weights, intercept);
		}

		[Obsolete("Warning: This function is here to stay but its signature will likely change. Opting out from semantic versioning.")]
		public static Vector<T> Local<T>(Matrix<T> x, Vector<T> y, Vector<T> t, double radius, Func<double, T> kernel) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.Dense(x.RowCount, x.RowCount);
			for (int i = 0; i < x.RowCount; i++)
			{
				matrix.At(i, i, kernel(Distance.Euclidean(t, x.Row(i)) / radius));
			}
			return Weighted(x, y, matrix);
		}

		[Obsolete("Warning: This function is here to stay but its signature will likely change. Opting out from semantic versioning.")]
		public static Matrix<T> Local<T>(Matrix<T> x, Matrix<T> y, Vector<T> t, double radius, Func<double, T> kernel) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.Dense(x.RowCount, x.RowCount);
			for (int i = 0; i < x.RowCount; i++)
			{
				matrix.At(i, i, kernel(Distance.Euclidean(t, x.Row(i)) / radius));
			}
			return Weighted(x, y, matrix);
		}

		[Obsolete("Warning: This function is here to stay but will likely be refactored and/or moved to another place. Opting out from semantic versioning.")]
		public static double GaussianKernel(double normalizedDistance)
		{
			return Math.Exp(-0.5 * normalizedDistance * normalizedDistance);
		}
	}
}
