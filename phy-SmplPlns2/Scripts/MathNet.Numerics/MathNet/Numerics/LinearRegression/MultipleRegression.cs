using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.LinearRegression
{
	public static class MultipleRegression
	{
		public static Vector<T> DirectMethod<T>(Matrix<T> x, Vector<T> y, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations) where T : struct, IEquatable<T>, IFormattable
		{
			return method switch
			{
				DirectRegressionMethod.NormalEquations => NormalEquations(x, y), 
				DirectRegressionMethod.QR => QR(x, y), 
				DirectRegressionMethod.Svd => Svd(x, y), 
				_ => throw new NotSupportedException(method.ToString()), 
			};
		}

		public static Matrix<T> DirectMethod<T>(Matrix<T> x, Matrix<T> y, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations) where T : struct, IEquatable<T>, IFormattable
		{
			return method switch
			{
				DirectRegressionMethod.NormalEquations => NormalEquations(x, y), 
				DirectRegressionMethod.QR => QR(x, y), 
				DirectRegressionMethod.Svd => Svd(x, y), 
				_ => throw new NotSupportedException(method.ToString()), 
			};
		}

		public static T[] DirectMethod<T>(T[][] x, T[] y, bool intercept = false, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations) where T : struct, IEquatable<T>, IFormattable
		{
			return method switch
			{
				DirectRegressionMethod.NormalEquations => NormalEquations(x, y, intercept), 
				DirectRegressionMethod.QR => QR(x, y, intercept), 
				DirectRegressionMethod.Svd => Svd(x, y, intercept), 
				_ => throw new NotSupportedException(method.ToString()), 
			};
		}

		public static T[] DirectMethod<T>(IEnumerable<Tuple<T[], T>> samples, bool intercept = false, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations) where T : struct, IEquatable<T>, IFormattable
		{
			return method switch
			{
				DirectRegressionMethod.NormalEquations => NormalEquations(samples, intercept), 
				DirectRegressionMethod.QR => QR(samples, intercept), 
				DirectRegressionMethod.Svd => Svd(samples, intercept), 
				_ => throw new NotSupportedException(method.ToString()), 
			};
		}

		public static Vector<T> NormalEquations<T>(Matrix<T> x, Vector<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.Count)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.Count} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.Count)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.Count} samples have been provided.");
			}
			return x.TransposeThisAndMultiply(x).Cholesky().Solve(x.TransposeThisAndMultiply(y));
		}

		public static Matrix<T> NormalEquations<T>(Matrix<T> x, Matrix<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.RowCount)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.RowCount} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.RowCount)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.RowCount} samples have been provided.");
			}
			return x.TransposeThisAndMultiply(x).Cholesky().Solve(x.TransposeThisAndMultiply(y));
		}

		public static T[] NormalEquations<T>(T[][] x, T[] y, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.DenseOfRowArrays(x);
			if (intercept)
			{
				matrix = matrix.InsertColumn(0, Vector<T>.Build.Dense(matrix.RowCount, Vector<T>.One));
			}
			if (matrix.RowCount != y.Length)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {matrix.RowCount} and {y.Length} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (matrix.ColumnCount > y.Length)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {matrix.ColumnCount} samples. Only {y.Length} samples have been provided.");
			}
			Vector<T> rightSide = Vector<T>.Build.Dense(y);
			return matrix.TransposeThisAndMultiply(matrix).Cholesky().Solve(matrix.TransposeThisAndMultiply(rightSide))
				.ToArray();
		}

		public static T[] NormalEquations<T>(IEnumerable<Tuple<T[], T>> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return NormalEquations(x, y, intercept);
		}

		public static T[] NormalEquations<T>(IEnumerable<(T[], T)> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return NormalEquations(x, y, intercept);
		}

		public static Vector<T> QR<T>(Matrix<T> x, Vector<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.Count)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.Count} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.Count)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.Count} samples have been provided.");
			}
			return x.QR().Solve(y);
		}

		public static Matrix<T> QR<T>(Matrix<T> x, Matrix<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.RowCount)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.RowCount} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.RowCount)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.RowCount} samples have been provided.");
			}
			return x.QR().Solve(y);
		}

		public static T[] QR<T>(T[][] x, T[] y, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.DenseOfRowArrays(x);
			if (intercept)
			{
				matrix = matrix.InsertColumn(0, Vector<T>.Build.Dense(matrix.RowCount, Vector<T>.One));
			}
			if (matrix.RowCount != y.Length)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {matrix.RowCount} and {y.Length} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (matrix.ColumnCount > y.Length)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {matrix.ColumnCount} samples. Only {y.Length} samples have been provided.");
			}
			return matrix.QR().Solve(Vector<T>.Build.Dense(y)).ToArray();
		}

		public static T[] QR<T>(IEnumerable<Tuple<T[], T>> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return QR(x, y, intercept);
		}

		public static T[] QR<T>(IEnumerable<(T[], T)> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return QR(x, y, intercept);
		}

		public static Vector<T> Svd<T>(Matrix<T> x, Vector<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.Count)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.Count} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.Count)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.Count} samples have been provided.");
			}
			return x.Svd().Solve(y);
		}

		public static Matrix<T> Svd<T>(Matrix<T> x, Matrix<T> y) where T : struct, IEquatable<T>, IFormattable
		{
			if (x.RowCount != y.RowCount)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.RowCount} and {y.RowCount} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.ColumnCount > y.RowCount)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {x.ColumnCount} samples. Only {y.RowCount} samples have been provided.");
			}
			return x.Svd().Solve(y);
		}

		public static T[] Svd<T>(T[][] x, T[] y, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			Matrix<T> matrix = Matrix<T>.Build.DenseOfRowArrays(x);
			if (intercept)
			{
				matrix = matrix.InsertColumn(0, Vector<T>.Build.Dense(matrix.RowCount, Vector<T>.One));
			}
			if (matrix.RowCount != y.Length)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {matrix.RowCount} and {y.Length} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (matrix.ColumnCount > y.Length)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {matrix.ColumnCount} samples. Only {y.Length} samples have been provided.");
			}
			return matrix.Svd().Solve(Vector<T>.Build.Dense(y)).ToArray();
		}

		public static T[] Svd<T>(IEnumerable<Tuple<T[], T>> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return Svd(x, y, intercept);
		}

		public static T[] Svd<T>(IEnumerable<(T[], T)> samples, bool intercept = false) where T : struct, IEquatable<T>, IFormattable
		{
			var (x, y) = samples.UnpackSinglePass();
			return Svd(x, y, intercept);
		}
	}
}
