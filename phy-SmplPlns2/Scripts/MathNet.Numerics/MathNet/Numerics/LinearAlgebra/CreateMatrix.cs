using System;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra
{
	public static class CreateMatrix
	{
		public static Matrix<T> WithStorage<T>(MatrixStorage<T> storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.OfStorage(storage);
		}

		public static Matrix<T> SameAs<T, TU>(Matrix<TU> example, int rows, int columns, bool fullyMutable = false) where T : struct, IEquatable<T>, IFormattable where TU : struct, IEquatable<TU>, IFormattable
		{
			return Matrix<T>.Build.SameAs(example, rows, columns, fullyMutable);
		}

		public static Matrix<T> SameAs<T, TU>(Matrix<TU> example) where T : struct, IEquatable<T>, IFormattable where TU : struct, IEquatable<TU>, IFormattable
		{
			return Matrix<T>.Build.SameAs(example);
		}

		public static Matrix<T> SameAs<T>(Vector<T> example, int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SameAs(example, rows, columns);
		}

		public static Matrix<T> SameAs<T>(Matrix<T> example, Matrix<T> otherExample, int rows, int columns, bool fullyMutable = false) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SameAs(example, otherExample, rows, columns, fullyMutable);
		}

		public static Matrix<T> SameAs<T>(Matrix<T> example, Matrix<T> otherExample) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SameAs(example, otherExample);
		}

		public static Matrix<T> Random<T>(int rows, int columns, IContinuousDistribution distribution) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Random(rows, columns, distribution);
		}

		public static Matrix<T> Random<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Random(rows, columns);
		}

		public static Matrix<T> Random<T>(int rows, int columns, int seed) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Random(rows, columns, seed);
		}

		public static Matrix<T> RandomPositiveDefinite<T>(int order, IContinuousDistribution distribution) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.RandomPositiveDefinite(order, distribution);
		}

		public static Matrix<T> RandomPositiveDefinite<T>(int order) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.RandomPositiveDefinite(order);
		}

		public static Matrix<T> RandomPositiveDefinite<T>(int order, int seed) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.RandomPositiveDefinite(order, seed);
		}

		public static Matrix<T> Dense<T>(DenseColumnMajorMatrixStorage<T> storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Dense(storage);
		}

		public static Matrix<T> Dense<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Dense(rows, columns);
		}

		public static Matrix<T> Dense<T>(int rows, int columns, T[] storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Dense(rows, columns, storage);
		}

		public static Matrix<T> Dense<T>(int rows, int columns, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Dense(rows, columns, value);
		}

		public static Matrix<T> Dense<T>(int rows, int columns, Func<int, int, T> init) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Dense(rows, columns, init);
		}

		public static Matrix<T> DenseDiagonal<T>(int rows, int columns, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseDiagonal(rows, columns, value);
		}

		public static Matrix<T> DenseDiagonal<T>(int order, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseDiagonal(order, value);
		}

		public static Matrix<T> DenseDiagonal<T>(int rows, int columns, Func<int, T> init) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseDiagonal(rows, columns, init);
		}

		public static Matrix<T> DenseIdentity<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseIdentity(rows, columns);
		}

		public static Matrix<T> DenseIdentity<T>(int order) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseIdentity(order);
		}

		public static Matrix<T> DenseOfMatrix<T>(Matrix<T> matrix) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfMatrix(matrix);
		}

		public static Matrix<T> DenseOfArray<T>(T[,] array) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfArray(array);
		}

		public static Matrix<T> DenseOfIndexed<T>(int rows, int columns, IEnumerable<Tuple<int, int, T>> enumerable) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfIndexed(rows, columns, enumerable);
		}

		public static Matrix<T> DenseOfIndexed<T>(int rows, int columns, IEnumerable<(int, int, T)> enumerable) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfIndexed(rows, columns, enumerable);
		}

		public static Matrix<T> DenseOfColumnMajor<T>(int rows, int columns, IEnumerable<T> columnMajor) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumnMajor(rows, columns, columnMajor);
		}

		public static Matrix<T> DenseOfColumns<T>(IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumns(data);
		}

		public static Matrix<T> DenseOfColumns<T>(int rows, int columns, IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumns(rows, columns, data);
		}

		public static Matrix<T> DenseOfColumnArrays<T>(params T[][] columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumnArrays(columns);
		}

		public static Matrix<T> DenseOfColumnArrays<T>(IEnumerable<T[]> columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumnArrays(columns);
		}

		public static Matrix<T> DenseOfColumnVectors<T>(params Vector<T>[] columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumnVectors(columns);
		}

		public static Matrix<T> DenseOfColumnVectors<T>(IEnumerable<Vector<T>> columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfColumnVectors(columns);
		}

		public static Matrix<T> DenseOfRows<T>(IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRows(data);
		}

		public static Matrix<T> DenseOfRows<T>(int rows, int columns, IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRows(rows, columns, data);
		}

		public static Matrix<T> DenseOfRowArrays<T>(params T[][] rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRowArrays(rows);
		}

		public static Matrix<T> DenseOfRowArrays<T>(IEnumerable<T[]> rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRowArrays(rows);
		}

		public static Matrix<T> DenseOfRowVectors<T>(params Vector<T>[] rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRowVectors(rows);
		}

		public static Matrix<T> DenseOfRowVectors<T>(IEnumerable<Vector<T>> rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfRowVectors(rows);
		}

		public static Matrix<T> DenseOfDiagonalVector<T>(Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfDiagonalVector(diagonal);
		}

		public static Matrix<T> DenseOfDiagonalVector<T>(int rows, int columns, Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfDiagonalVector(rows, columns, diagonal);
		}

		public static Matrix<T> DenseOfDiagonalArray<T>(T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfDiagonalArray(diagonal);
		}

		public static Matrix<T> DenseOfDiagonalArray<T>(int rows, int columns, T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfDiagonalArray(rows, columns, diagonal);
		}

		public static Matrix<T> DenseOfMatrixArray<T>(Matrix<T>[,] matrices) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DenseOfMatrixArray(matrices);
		}

		public static Matrix<T> Sparse<T>(SparseCompressedRowMatrixStorage<T> storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Sparse(storage);
		}

		public static Matrix<T> Sparse<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Sparse(rows, columns);
		}

		public static Matrix<T> Sparse<T>(int rows, int columns, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Sparse(rows, columns, value);
		}

		public static Matrix<T> Sparse<T>(int rows, int columns, Func<int, int, T> init) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Sparse(rows, columns, init);
		}

		public static Matrix<T> SparseDiagonal<T>(int rows, int columns, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseDiagonal(rows, columns, value);
		}

		public static Matrix<T> SparseDiagonal<T>(int order, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseDiagonal(order, value);
		}

		public static Matrix<T> SparseDiagonal<T>(int rows, int columns, Func<int, T> init) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseDiagonal(rows, columns, init);
		}

		public static Matrix<T> SparseIdentity<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseIdentity(rows, columns);
		}

		public static Matrix<T> SparseIdentity<T>(int order) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseIdentity(order);
		}

		public static Matrix<T> SparseOfMatrix<T>(Matrix<T> matrix) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfMatrix(matrix);
		}

		public static Matrix<T> SparseOfArray<T>(T[,] array) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfArray(array);
		}

		public static Matrix<T> SparseOfIndexed<T>(int rows, int columns, IEnumerable<Tuple<int, int, T>> enumerable) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfIndexed(rows, columns, enumerable);
		}

		public static Matrix<T> SparseOfIndexed<T>(int rows, int columns, IEnumerable<(int, int, T)> enumerable) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfIndexed(rows, columns, enumerable);
		}

		public static Matrix<T> SparseOfRowMajor<T>(int rows, int columns, IEnumerable<T> rowMajor) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRowMajor(rows, columns, rowMajor);
		}

		public static Matrix<T> SparseOfColumnMajor<T>(int rows, int columns, IList<T> columnMajor) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumnMajor(rows, columns, columnMajor);
		}

		public static Matrix<T> SparseOfColumns<T>(IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumns(data);
		}

		public static Matrix<T> SparseOfColumns<T>(int rows, int columns, IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumns(rows, columns, data);
		}

		public static Matrix<T> SparseOfColumnArrays<T>(params T[][] columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumnArrays(columns);
		}

		public static Matrix<T> SparseOfColumnArrays<T>(IEnumerable<T[]> columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumnArrays(columns);
		}

		public static Matrix<T> SparseOfColumnVectors<T>(params Vector<T>[] columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumnVectors(columns);
		}

		public static Matrix<T> SparseOfColumnVectors<T>(IEnumerable<Vector<T>> columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfColumnVectors(columns);
		}

		public static Matrix<T> SparseOfRows<T>(IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRows(data);
		}

		public static Matrix<T> SparseOfRows<T>(int rows, int columns, IEnumerable<IEnumerable<T>> data) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRows(rows, columns, data);
		}

		public static Matrix<T> SparseOfRowArrays<T>(params T[][] rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRowArrays(rows);
		}

		public static Matrix<T> SparseOfRowArrays<T>(IEnumerable<T[]> rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRowArrays(rows);
		}

		public static Matrix<T> SparseOfRowVectors<T>(params Vector<T>[] rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRowVectors(rows);
		}

		public static Matrix<T> SparseOfRowVectors<T>(IEnumerable<Vector<T>> rows) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfRowVectors(rows);
		}

		public static Matrix<T> SparseOfDiagonalVector<T>(Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfDiagonalVector(diagonal);
		}

		public static Matrix<T> SparseOfDiagonalVector<T>(int rows, int columns, Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfDiagonalVector(rows, columns, diagonal);
		}

		public static Matrix<T> SparseOfDiagonalArray<T>(T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfDiagonalArray(diagonal);
		}

		public static Matrix<T> SparseOfDiagonalArray<T>(int rows, int columns, T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfDiagonalArray(rows, columns, diagonal);
		}

		public static Matrix<T> SparseOfMatrixArray<T>(Matrix<T>[,] matrices) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseOfMatrixArray(matrices);
		}

		public static Matrix<T> SparseFromCoordinateFormat<T>(int rows, int columns, int valueCount, int[] rowIndices, int[] columnIndices, T[] values) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseFromCoordinateFormat(rows, columns, valueCount, rowIndices, columnIndices, values);
		}

		public static Matrix<T> SparseFromCompressedSparseRowFormat<T>(int rows, int columns, int valueCount, int[] rowPointers, int[] columnIndices, T[] values) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseFromCompressedSparseRowFormat(rows, columns, valueCount, rowPointers, columnIndices, values);
		}

		public static Matrix<T> SparseFromCompressedSparseColumnFormat<T>(int rows, int columns, int valueCount, int[] rowIndices, int[] columnPointers, T[] values) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.SparseFromCompressedSparseColumnFormat(rows, columns, valueCount, rowIndices, columnPointers, values);
		}

		public static Matrix<T> Diagonal<T>(DiagonalMatrixStorage<T> storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(storage);
		}

		public static Matrix<T> Diagonal<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(rows, columns);
		}

		public static Matrix<T> Diagonal<T>(int rows, int columns, T[] storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(rows, columns, storage);
		}

		public static Matrix<T> Diagonal<T>(T[] storage) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(storage);
		}

		public static Matrix<T> Diagonal<T>(int rows, int columns, T value) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(rows, columns, value);
		}

		public static Matrix<T> Diagonal<T>(int rows, int columns, Func<int, T> init) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.Diagonal(rows, columns, init);
		}

		public static Matrix<T> DiagonalIdentity<T>(int rows, int columns) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalIdentity(rows, columns);
		}

		public static Matrix<T> DiagonalIdentity<T>(int order) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalIdentity(order);
		}

		public static Matrix<T> DiagonalOfDiagonalVector<T>(Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalOfDiagonalVector(diagonal);
		}

		public static Matrix<T> DiagonalOfDiagonalVector<T>(int rows, int columns, Vector<T> diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalOfDiagonalVector(rows, columns, diagonal);
		}

		public static Matrix<T> DiagonalOfDiagonalArray<T>(T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalOfDiagonalArray(diagonal);
		}

		public static Matrix<T> DiagonalOfDiagonalArray<T>(int rows, int columns, T[] diagonal) where T : struct, IEquatable<T>, IFormattable
		{
			return Matrix<T>.Build.DiagonalOfDiagonalArray(rows, columns, diagonal);
		}
	}
}
