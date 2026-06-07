using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.LinearAlgebra
{
	public abstract class MatrixBuilder<T> where T : struct, IEquatable<T>, IFormattable
	{
		public abstract T Zero { get; }

		public abstract T One { get; }

		internal abstract T Add(T x, T y);

		public Matrix<T> OfStorage(MatrixStorage<T> storage)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (storage is DenseColumnMajorMatrixStorage<T> storage2)
			{
				return Dense(storage2);
			}
			if (storage is SparseCompressedRowMatrixStorage<T> storage3)
			{
				return Sparse(storage3);
			}
			if (storage is DiagonalMatrixStorage<T> storage4)
			{
				return Diagonal(storage4);
			}
			throw new NotSupportedException(FormattableString.Invariant($"Matrix storage type '{storage.GetType().Name}' is not supported. Only DenseColumnMajorMatrixStorage, SparseCompressedRowMatrixStorage and DiagonalMatrixStorage are supported as this point."));
		}

		public Matrix<T> SameAs<TU>(Matrix<TU> example, int rows, int columns, bool fullyMutable = false) where TU : struct, IEquatable<TU>, IFormattable
		{
			MatrixStorage<TU> storage = example.Storage;
			if (storage is DenseColumnMajorMatrixStorage<T>)
			{
				return Dense(rows, columns);
			}
			if (storage is DiagonalMatrixStorage<T>)
			{
				if (!fullyMutable)
				{
					return Diagonal(rows, columns);
				}
				return Sparse(rows, columns);
			}
			if (storage is SparseCompressedRowMatrixStorage<T>)
			{
				return Sparse(rows, columns);
			}
			return Dense(rows, columns);
		}

		public Matrix<T> SameAs<TU>(Matrix<TU> example) where TU : struct, IEquatable<TU>, IFormattable
		{
			return SameAs(example, example.RowCount, example.ColumnCount);
		}

		public Matrix<T> SameAs(Vector<T> example, int rows, int columns)
		{
			if (!example.Storage.IsDense)
			{
				return Sparse(rows, columns);
			}
			return Dense(rows, columns);
		}

		public Matrix<T> SameAs(Matrix<T> example, Matrix<T> otherExample, int rows, int columns, bool fullyMutable = false)
		{
			MatrixStorage<T> storage = example.Storage;
			MatrixStorage<T> storage2 = otherExample.Storage;
			if (storage is DenseColumnMajorMatrixStorage<T> || storage2 is DenseColumnMajorMatrixStorage<T>)
			{
				return Dense(rows, columns);
			}
			if (storage is DiagonalMatrixStorage<T> && storage2 is DiagonalMatrixStorage<T>)
			{
				if (!fullyMutable)
				{
					return Diagonal(rows, columns);
				}
				return Sparse(rows, columns);
			}
			if (storage is SparseCompressedRowMatrixStorage<T> || storage2 is SparseCompressedRowMatrixStorage<T>)
			{
				return Sparse(rows, columns);
			}
			return Dense(rows, columns);
		}

		public Matrix<T> SameAs(Matrix<T> example, Matrix<T> otherExample)
		{
			return SameAs(example, otherExample, example.RowCount, example.ColumnCount);
		}

		public abstract Matrix<T> Random(int rows, int columns, IContinuousDistribution distribution);

		public Matrix<T> Random(int rows, int columns)
		{
			return Random(rows, columns, new Normal(SystemRandomSource.Default));
		}

		public Matrix<T> Random(int rows, int columns, int seed)
		{
			return Random(rows, columns, new Normal(new SystemRandomSource(seed, threadSafe: true)));
		}

		public Matrix<T> RandomPositiveDefinite(int order, IContinuousDistribution distribution)
		{
			Matrix<T> matrix = Random(order, order, distribution);
			return matrix.ConjugateTransposeThisAndMultiply(matrix);
		}

		public Matrix<T> RandomPositiveDefinite(int order)
		{
			Matrix<T> matrix = Random(order, order, new Normal(SystemRandomSource.Default));
			return matrix.ConjugateTransposeThisAndMultiply(matrix);
		}

		public Matrix<T> RandomPositiveDefinite(int order, int seed)
		{
			Matrix<T> matrix = Random(order, order, new Normal(new SystemRandomSource(seed, threadSafe: true)));
			return matrix.ConjugateTransposeThisAndMultiply(matrix);
		}

		public abstract Matrix<T> Dense(DenseColumnMajorMatrixStorage<T> storage);

		public Matrix<T> Dense(int rows, int columns)
		{
			return Dense(new DenseColumnMajorMatrixStorage<T>(rows, columns));
		}

		public Matrix<T> Dense(int rows, int columns, T[] storage)
		{
			return Dense(new DenseColumnMajorMatrixStorage<T>(rows, columns, storage));
		}

		public Matrix<T> Dense(int rows, int columns, T value)
		{
			if (Zero.Equals(value))
			{
				return Dense(rows, columns);
			}
			return Dense(DenseColumnMajorMatrixStorage<T>.OfValue(rows, columns, value));
		}

		public Matrix<T> Dense(int rows, int columns, Func<int, int, T> init)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfInit(rows, columns, init));
		}

		public Matrix<T> DenseDiagonal(int rows, int columns, T value)
		{
			if (Zero.Equals(value))
			{
				return Dense(rows, columns);
			}
			return Dense(DenseColumnMajorMatrixStorage<T>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public Matrix<T> DenseDiagonal(int order, T value)
		{
			if (Zero.Equals(value))
			{
				return Dense(order, order);
			}
			return Dense(DenseColumnMajorMatrixStorage<T>.OfDiagonalInit(order, order, (int _) => value));
		}

		public Matrix<T> DenseDiagonal(int rows, int columns, Func<int, T> init)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfDiagonalInit(rows, columns, init));
		}

		public Matrix<T> DenseIdentity(int rows, int columns)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfDiagonalInit(rows, columns, (int _) => One));
		}

		public Matrix<T> DenseIdentity(int order)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfDiagonalInit(order, order, (int _) => One));
		}

		public Matrix<T> DenseOfMatrix(Matrix<T> matrix)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfMatrix(matrix.Storage));
		}

		public Matrix<T> DenseOfArray(T[,] array)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfArray(array));
		}

		public Matrix<T> DenseOfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, T>> enumerable)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public Matrix<T> DenseOfIndexed(int rows, int columns, IEnumerable<(int, int, T)> enumerable)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public Matrix<T> DenseOfColumnMajor(int rows, int columns, IEnumerable<T> columnMajor)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnMajorEnumerable(rows, columns, columnMajor));
		}

		public Matrix<T> DenseOfColumns(IEnumerable<IEnumerable<T>> data)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnArrays(data.Select((IEnumerable<T> v) => (v as T[]) ?? v.ToArray()).ToArray()));
		}

		public Matrix<T> DenseOfColumns(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnEnumerables(rows, columns, data));
		}

		public Matrix<T> DenseOfColumnArrays(params T[][] columns)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnArrays(columns));
		}

		public Matrix<T> DenseOfColumnArrays(IEnumerable<T[]> columns)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnArrays((columns as T[][]) ?? columns.ToArray()));
		}

		public Matrix<T> DenseOfColumnVectors(params Vector<T>[] columns)
		{
			VectorStorage<T>[] array = new VectorStorage<T>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnVectors(array));
		}

		public Matrix<T> DenseOfColumnVectors(IEnumerable<Vector<T>> columns)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfColumnVectors(columns.Select((Vector<T> c) => c.Storage).ToArray()));
		}

		public Matrix<T> DenseOfRowMajor(int rows, int columns, IEnumerable<T> columnMajor)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowMajorEnumerable(rows, columns, columnMajor));
		}

		public Matrix<T> DenseOfRows(IEnumerable<IEnumerable<T>> data)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowArrays(data.Select((IEnumerable<T> v) => (v as T[]) ?? v.ToArray()).ToArray()));
		}

		public Matrix<T> DenseOfRows(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowEnumerables(rows, columns, data));
		}

		public Matrix<T> DenseOfRowArrays(params T[][] rows)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowArrays(rows));
		}

		public Matrix<T> DenseOfRowArrays(IEnumerable<T[]> rows)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowArrays((rows as T[][]) ?? rows.ToArray()));
		}

		public Matrix<T> DenseOfRowVectors(params Vector<T>[] rows)
		{
			VectorStorage<T>[] array = new VectorStorage<T>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowVectors(array));
		}

		public Matrix<T> DenseOfRowVectors(IEnumerable<Vector<T>> rows)
		{
			return Dense(DenseColumnMajorMatrixStorage<T>.OfRowVectors(rows.Select((Vector<T> r) => r.Storage).ToArray()));
		}

		public Matrix<T> DenseOfDiagonalVector(Vector<T> diagonal)
		{
			Matrix<T> matrix = Dense(diagonal.Count, diagonal.Count);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DenseOfDiagonalVector(int rows, int columns, Vector<T> diagonal)
		{
			Matrix<T> matrix = Dense(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DenseOfDiagonalArray(T[] diagonal)
		{
			Matrix<T> matrix = Dense(diagonal.Length, diagonal.Length);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DenseOfDiagonalArray(int rows, int columns, T[] diagonal)
		{
			Matrix<T> matrix = Dense(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DenseOfMatrixArray(Matrix<T>[,] matrices)
		{
			int[] array = new int[matrices.GetLength(0)];
			int[] array2 = new int[matrices.GetLength(1)];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array2.Length; j++)
				{
					array[i] = Math.Max(array[i], matrices[i, j].RowCount);
					array2[j] = Math.Max(array2[j], matrices[i, j].ColumnCount);
				}
			}
			Matrix<T> matrix = Dense(array.Sum(), array2.Sum());
			int num = 0;
			for (int k = 0; k < array.Length; k++)
			{
				int num2 = 0;
				for (int l = 0; l < array2.Length; l++)
				{
					matrix.SetSubMatrix(num, num2, matrices[k, l]);
					num2 += array2[l];
				}
				num += array[k];
			}
			return matrix;
		}

		public abstract Matrix<T> Sparse(SparseCompressedRowMatrixStorage<T> storage);

		public Matrix<T> Sparse(int rows, int columns)
		{
			return Sparse(new SparseCompressedRowMatrixStorage<T>(rows, columns));
		}

		public Matrix<T> Sparse(int rows, int columns, T value)
		{
			if (Zero.Equals(value))
			{
				return Sparse(rows, columns);
			}
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfValue(rows, columns, value));
		}

		public Matrix<T> Sparse(int rows, int columns, Func<int, int, T> init)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfInit(rows, columns, init));
		}

		public Matrix<T> SparseDiagonal(int rows, int columns, T value)
		{
			if (Zero.Equals(value))
			{
				return Sparse(rows, columns);
			}
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public Matrix<T> SparseDiagonal(int order, T value)
		{
			if (Zero.Equals(value))
			{
				return Sparse(order, order);
			}
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfDiagonalInit(order, order, (int _) => value));
		}

		public Matrix<T> SparseDiagonal(int rows, int columns, Func<int, T> init)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfDiagonalInit(rows, columns, init));
		}

		public Matrix<T> SparseIdentity(int rows, int columns)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfDiagonalInit(rows, columns, (int _) => One));
		}

		public Matrix<T> SparseIdentity(int order)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfDiagonalInit(order, order, (int _) => One));
		}

		public Matrix<T> SparseOfMatrix(Matrix<T> matrix)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfMatrix(matrix.Storage));
		}

		public Matrix<T> SparseOfArray(T[,] array)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfArray(array));
		}

		public Matrix<T> SparseOfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, T>> enumerable)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public Matrix<T> SparseOfIndexed(int rows, int columns, IEnumerable<(int, int, T)> enumerable)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public Matrix<T> SparseOfRowMajor(int rows, int columns, IEnumerable<T> rowMajor)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowMajorEnumerable(rows, columns, rowMajor));
		}

		public Matrix<T> SparseOfColumnMajor(int rows, int columns, IList<T> columnMajor)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnMajorList(rows, columns, columnMajor));
		}

		public Matrix<T> SparseOfColumns(IEnumerable<IEnumerable<T>> data)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnArrays(data.Select((IEnumerable<T> v) => (v as T[]) ?? v.ToArray()).ToArray()));
		}

		public Matrix<T> SparseOfColumns(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnEnumerables(rows, columns, data));
		}

		public Matrix<T> SparseOfColumnArrays(params T[][] columns)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnArrays(columns));
		}

		public Matrix<T> SparseOfColumnArrays(IEnumerable<T[]> columns)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnArrays((columns as T[][]) ?? columns.ToArray()));
		}

		public Matrix<T> SparseOfColumnVectors(params Vector<T>[] columns)
		{
			VectorStorage<T>[] array = new VectorStorage<T>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnVectors(array));
		}

		public Matrix<T> SparseOfColumnVectors(IEnumerable<Vector<T>> columns)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfColumnVectors(columns.Select((Vector<T> c) => c.Storage).ToArray()));
		}

		public Matrix<T> SparseOfRows(IEnumerable<IEnumerable<T>> data)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowArrays(data.Select((IEnumerable<T> v) => (v as T[]) ?? v.ToArray()).ToArray()));
		}

		public Matrix<T> SparseOfRows(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowEnumerables(rows, columns, data));
		}

		public Matrix<T> SparseOfRowArrays(params T[][] rows)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowArrays(rows));
		}

		public Matrix<T> SparseOfRowArrays(IEnumerable<T[]> rows)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowArrays((rows as T[][]) ?? rows.ToArray()));
		}

		public Matrix<T> SparseOfRowVectors(params Vector<T>[] rows)
		{
			VectorStorage<T>[] array = new VectorStorage<T>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowVectors(array));
		}

		public Matrix<T> SparseOfRowVectors(IEnumerable<Vector<T>> rows)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfRowVectors(rows.Select((Vector<T> r) => r.Storage).ToArray()));
		}

		public Matrix<T> SparseOfDiagonalVector(Vector<T> diagonal)
		{
			Matrix<T> matrix = Sparse(diagonal.Count, diagonal.Count);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> SparseOfDiagonalVector(int rows, int columns, Vector<T> diagonal)
		{
			Matrix<T> matrix = Sparse(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> SparseOfDiagonalArray(T[] diagonal)
		{
			Matrix<T> matrix = Sparse(diagonal.Length, diagonal.Length);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> SparseOfDiagonalArray(int rows, int columns, T[] diagonal)
		{
			Matrix<T> matrix = Sparse(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> SparseOfMatrixArray(Matrix<T>[,] matrices)
		{
			int[] array = new int[matrices.GetLength(0)];
			int[] array2 = new int[matrices.GetLength(1)];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array2.Length; j++)
				{
					array[i] = Math.Max(array[i], matrices[i, j].RowCount);
					array2[j] = Math.Max(array2[j], matrices[i, j].ColumnCount);
				}
			}
			Matrix<T> matrix = Sparse(array.Sum(), array2.Sum());
			int num = 0;
			for (int k = 0; k < array.Length; k++)
			{
				int num2 = 0;
				for (int l = 0; l < array2.Length; l++)
				{
					matrix.SetSubMatrix(num, num2, matrices[k, l]);
					num2 += array2[l];
				}
				num += array[k];
			}
			return matrix;
		}

		public Matrix<T> SparseFromCoordinateFormat(int rows, int columns, int valueCount, int[] rowIndices, int[] columnIndices, T[] values)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfCoordinateFormat(rows, columns, valueCount, rowIndices, columnIndices, values));
		}

		public Matrix<T> SparseFromCompressedSparseRowFormat(int rows, int columns, int valueCount, int[] rowPointers, int[] columnIndices, T[] values)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfCompressedSparseRowFormat(rows, columns, valueCount, rowPointers, columnIndices, values));
		}

		public Matrix<T> SparseFromCompressedSparseColumnFormat(int rows, int columns, int valueCount, int[] rowIndices, int[] columnPointers, T[] values)
		{
			return Sparse(SparseCompressedRowMatrixStorage<T>.OfCompressedSparseColumnFormat(rows, columns, valueCount, rowIndices, columnPointers, values));
		}

		public abstract Matrix<T> Diagonal(DiagonalMatrixStorage<T> storage);

		public Matrix<T> Diagonal(int rows, int columns)
		{
			return Diagonal(new DiagonalMatrixStorage<T>(rows, columns));
		}

		public Matrix<T> Diagonal(int rows, int columns, T[] storage)
		{
			return Diagonal(new DiagonalMatrixStorage<T>(rows, columns, storage));
		}

		public Matrix<T> Diagonal(T[] storage)
		{
			return Diagonal(new DiagonalMatrixStorage<T>(storage.Length, storage.Length, storage));
		}

		public Matrix<T> Diagonal(int rows, int columns, T value)
		{
			if (Zero.Equals(value))
			{
				return Diagonal(rows, columns);
			}
			return Diagonal(DiagonalMatrixStorage<T>.OfValue(rows, columns, value));
		}

		public Matrix<T> Diagonal(int rows, int columns, Func<int, T> init)
		{
			return Diagonal(DiagonalMatrixStorage<T>.OfInit(rows, columns, init));
		}

		public Matrix<T> DiagonalIdentity(int rows, int columns)
		{
			return Diagonal(DiagonalMatrixStorage<T>.OfValue(rows, columns, One));
		}

		public Matrix<T> DiagonalIdentity(int order)
		{
			return Diagonal(DiagonalMatrixStorage<T>.OfValue(order, order, One));
		}

		public Matrix<T> DiagonalOfDiagonalVector(Vector<T> diagonal)
		{
			Matrix<T> matrix = Diagonal(diagonal.Count, diagonal.Count);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DiagonalOfDiagonalVector(int rows, int columns, Vector<T> diagonal)
		{
			Matrix<T> matrix = Diagonal(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DiagonalOfDiagonalArray(T[] diagonal)
		{
			Matrix<T> matrix = Diagonal(diagonal.Length, diagonal.Length);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public Matrix<T> DiagonalOfDiagonalArray(int rows, int columns, T[] diagonal)
		{
			Matrix<T> matrix = Diagonal(rows, columns);
			matrix.SetDiagonal(diagonal);
			return matrix;
		}

		public abstract IIterationStopCriterion<T>[] IterativeSolverStopCriteria(int maxIterations = 1000);
	}
}
