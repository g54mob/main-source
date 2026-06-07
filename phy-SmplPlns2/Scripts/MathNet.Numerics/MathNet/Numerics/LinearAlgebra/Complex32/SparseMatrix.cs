using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	[Serializable]
	[DebuggerDisplay("SparseMatrix {RowCount}x{ColumnCount}-Complex32 {NonZerosCount}-NonZero")]
	public class SparseMatrix : Matrix
	{
		private readonly SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseMatrix(int order)
			: this(order, order)
		{
		}

		public SparseMatrix(int rows, int columns)
			: this(new SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>(rows, columns))
		{
		}

		public static SparseMatrix OfMatrix(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfMatrix(matrix.Storage));
		}

		public static SparseMatrix OfArray(MathNet.Numerics.Complex32[,] array)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfArray(array));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, MathNet.Numerics.Complex32>> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, MathNet.Numerics.Complex32)> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfRowMajor(int rows, int columns, IEnumerable<MathNet.Numerics.Complex32> rowMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowMajorEnumerable(rows, columns, rowMajor));
		}

		public static SparseMatrix OfColumnMajor(int rows, int columns, IList<MathNet.Numerics.Complex32> columnMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnMajorList(rows, columns, columnMajor));
		}

		public static SparseMatrix OfColumns(IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<MathNet.Numerics.Complex32> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfColumnArrays(params MathNet.Numerics.Complex32[][] columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnArrays(columns));
		}

		public static SparseMatrix OfColumnArrays(IEnumerable<MathNet.Numerics.Complex32[]> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnArrays((columns as MathNet.Numerics.Complex32[][]) ?? columns.ToArray()));
		}

		public static SparseMatrix OfColumnVectors(params Vector<MathNet.Numerics.Complex32>[] columns)
		{
			VectorStorage<MathNet.Numerics.Complex32>[] array = new VectorStorage<MathNet.Numerics.Complex32>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnVectors(array));
		}

		public static SparseMatrix OfColumnVectors(IEnumerable<Vector<MathNet.Numerics.Complex32>> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfColumnVectors(columns.Select((Vector<MathNet.Numerics.Complex32> c) => c.Storage).ToArray()));
		}

		public static SparseMatrix OfRows(IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<MathNet.Numerics.Complex32> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfRowArrays(params MathNet.Numerics.Complex32[][] rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowArrays(rows));
		}

		public static SparseMatrix OfRowArrays(IEnumerable<MathNet.Numerics.Complex32[]> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowArrays((rows as MathNet.Numerics.Complex32[][]) ?? rows.ToArray()));
		}

		public static SparseMatrix OfRowVectors(params Vector<MathNet.Numerics.Complex32>[] rows)
		{
			VectorStorage<MathNet.Numerics.Complex32>[] array = new VectorStorage<MathNet.Numerics.Complex32>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowVectors(array));
		}

		public static SparseMatrix OfRowVectors(IEnumerable<Vector<MathNet.Numerics.Complex32>> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfRowVectors(rows.Select((Vector<MathNet.Numerics.Complex32> r) => r.Storage).ToArray()));
		}

		public static SparseMatrix OfDiagonalVector(Vector<MathNet.Numerics.Complex32> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Count, diagonal.Count);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalVector(int rows, int columns, Vector<MathNet.Numerics.Complex32> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(MathNet.Numerics.Complex32[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Length, diagonal.Length);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(int rows, int columns, MathNet.Numerics.Complex32[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix Create(int rows, int columns, MathNet.Numerics.Complex32 value)
		{
			if (value == MathNet.Numerics.Complex32.Zero)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfValue(rows, columns, value));
		}

		public static SparseMatrix Create(int rows, int columns, Func<int, int, MathNet.Numerics.Complex32> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfInit(rows, columns, init));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, MathNet.Numerics.Complex32 value)
		{
			if (value == MathNet.Numerics.Complex32.Zero)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, Func<int, MathNet.Numerics.Complex32> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(rows, columns, init));
		}

		public static SparseMatrix CreateIdentity(int order)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(order, order, (int _) => Matrix<MathNet.Numerics.Complex32>.One));
		}

		public override Matrix<MathNet.Numerics.Complex32> LowerTriangle()
		{
			Matrix<MathNet.Numerics.Complex32> result = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this);
			LowerTriangleImpl(result);
			return result;
		}

		public override void LowerTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(result);
				LowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				LowerTriangleImpl(result);
			}
		}

		private void LowerTriangleImpl(Matrix<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < result.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (i >= columnIndices[j])
					{
						result.At(i, columnIndices[j], values[j]);
					}
				}
			}
		}

		public override Matrix<MathNet.Numerics.Complex32> UpperTriangle()
		{
			Matrix<MathNet.Numerics.Complex32> result = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this);
			UpperTriangleImpl(result);
			return result;
		}

		public override void UpperTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(result);
				UpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				UpperTriangleImpl(result);
			}
		}

		private void UpperTriangleImpl(Matrix<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < result.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (i <= columnIndices[j])
					{
						result.At(i, columnIndices[j], values[j]);
					}
				}
			}
		}

		public override Matrix<MathNet.Numerics.Complex32> StrictlyLowerTriangle()
		{
			Matrix<MathNet.Numerics.Complex32> result = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this);
			StrictlyLowerTriangleImpl(result);
			return result;
		}

		public override void StrictlyLowerTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(result);
				StrictlyLowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyLowerTriangleImpl(result);
			}
		}

		private void StrictlyLowerTriangleImpl(Matrix<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < result.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (i > columnIndices[j])
					{
						result.At(i, columnIndices[j], values[j]);
					}
				}
			}
		}

		public override Matrix<MathNet.Numerics.Complex32> StrictlyUpperTriangle()
		{
			Matrix<MathNet.Numerics.Complex32> result = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this);
			StrictlyUpperTriangleImpl(result);
			return result;
		}

		public override void StrictlyUpperTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(result);
				StrictlyUpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyUpperTriangleImpl(result);
			}
		}

		private void StrictlyUpperTriangleImpl(Matrix<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < result.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (i < columnIndices[j])
					{
						result.At(i, columnIndices[j], values[j]);
					}
				}
			}
		}

		protected override void DoNegate(Matrix<MathNet.Numerics.Complex32> result)
		{
			CopyTo(result);
			DoMultiply(-1, result);
		}

		public override double InfinityNorm()
		{
			int[] rowPointers = _storage.RowPointers;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num2 = rowPointers[i];
				int num3 = rowPointers[i + 1];
				if (num2 != num3)
				{
					double num4 = 0.0;
					for (int j = num2; j < num3; j++)
					{
						num4 += (double)values[j].Magnitude;
					}
					num = Math.Max(num, num4);
				}
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> sparseCompressedRowMatrixStorage = (SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32>)(this * ConjugateTranspose()).Storage;
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			MathNet.Numerics.Complex32[] values = sparseCompressedRowMatrixStorage.Values;
			double num = 0.0;
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				int num2 = rowPointers[i];
				int num3 = rowPointers[i + 1];
				if (num2 == num3)
				{
					continue;
				}
				for (int j = num2; j < num3; j++)
				{
					if (i == sparseCompressedRowMatrixStorage.ColumnIndices[j])
					{
						num += (double)values[j].Magnitude;
					}
				}
			}
			return Math.Sqrt(num);
		}

		protected override void DoAdd(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				if (this == other)
				{
					if (this != result)
					{
						CopyTo(result);
					}
					LinearAlgebraControl.Provider.ScaleArray(2f, sparseMatrix2._storage.Values, sparseMatrix2._storage.Values);
					return;
				}
				SparseMatrix sparseMatrix3;
				if (sparseMatrix == sparseMatrix2)
				{
					sparseMatrix3 = this;
				}
				else if (this == sparseMatrix2)
				{
					sparseMatrix3 = sparseMatrix;
				}
				else
				{
					CopyTo(sparseMatrix2);
					sparseMatrix3 = sparseMatrix;
				}
				SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> storage = sparseMatrix3._storage;
				int[] rowPointers = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				MathNet.Numerics.Complex32[] values = storage.Values;
				for (int i = 0; i < storage.RowCount; i++)
				{
					int num = rowPointers[i + 1];
					for (int j = rowPointers[i]; j < num; j++)
					{
						int column = columnIndices[j];
						MathNet.Numerics.Complex32 value = values[j] + result.At(i, column);
						result.At(i, column, value);
					}
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				if (this == other)
				{
					result.Clear();
					return;
				}
				if (this == sparseMatrix2)
				{
					SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> storage = sparseMatrix._storage;
					int[] rowPointers = storage.RowPointers;
					int[] columnIndices = storage.ColumnIndices;
					MathNet.Numerics.Complex32[] values = storage.Values;
					for (int i = 0; i < storage.RowCount; i++)
					{
						int num = rowPointers[i + 1];
						for (int j = rowPointers[i]; j < num; j++)
						{
							int column = columnIndices[j];
							MathNet.Numerics.Complex32 value = sparseMatrix2.At(i, column) - values[j];
							result.At(i, column, value);
						}
					}
					return;
				}
				if (sparseMatrix != sparseMatrix2)
				{
					sparseMatrix.CopyTo(sparseMatrix2);
				}
				sparseMatrix2.Negate(sparseMatrix2);
				int[] rowPointers2 = _storage.RowPointers;
				int[] columnIndices2 = _storage.ColumnIndices;
				MathNet.Numerics.Complex32[] values2 = _storage.Values;
				for (int k = 0; k < base.RowCount; k++)
				{
					int num2 = rowPointers2[k + 1];
					for (int l = rowPointers2[k]; l < num2; l++)
					{
						int column2 = columnIndices2[l];
						MathNet.Numerics.Complex32 value2 = sparseMatrix2.At(k, column2) + values2[l];
						result.At(k, column2, value2);
					}
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoMultiply(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (scalar == 1f)
			{
				CopyTo(result);
				return;
			}
			if (scalar == 0f || NonZerosCount == 0)
			{
				result.Clear();
				return;
			}
			if (result is SparseMatrix sparseMatrix)
			{
				if (this != result)
				{
					CopyTo(sparseMatrix);
				}
				LinearAlgebraControl.Provider.ScaleArray(scalar, sparseMatrix._storage.Values, sparseMatrix._storage.Values);
				return;
			}
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					for (int j = num; j < num2; j++)
					{
						int column = columnIndices[j];
						result.At(i, column, values[j] * scalar);
					}
				}
			}
		}

		protected override void DoMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			SparseMatrix sparseMatrix = result as SparseMatrix;
			if (other is SparseMatrix other2 && sparseMatrix != null)
			{
				DoMultiplySparse(other2, sparseMatrix);
				return;
			}
			if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> diagonalMatrixStorage && sparseMatrix != null)
			{
				MathNet.Numerics.Complex32[] diagonal = diagonalMatrixStorage.Data;
				if (other.ColumnCount == other.RowCount)
				{
					base.Storage.MapIndexedTo(result.Storage, (int _, int j, MathNet.Numerics.Complex32 x) => x * diagonal[j], Zeros.AllowSkip, ExistingData.Clear);
					return;
				}
				result.Storage.Clear();
				base.Storage.MapSubMatrixIndexedTo(result.Storage, (int _, int j, MathNet.Numerics.Complex32 x) => x * diagonal[j], 0, 0, base.RowCount, 0, 0, Math.Min(base.ColumnCount, other.ColumnCount), Zeros.AllowSkip, ExistingData.AssumeZeros);
				return;
			}
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				for (int num = 0; num < base.RowCount; num++)
				{
					int num2 = rowPointers[num];
					int num3 = rowPointers[num + 1];
					if (num2 == num3)
					{
						continue;
					}
					for (int num4 = 0; num4 < other.ColumnCount; num4++)
					{
						int num5 = num4 * other.RowCount;
						MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
						for (int num6 = num2; num6 < num3; num6++)
						{
							zero += values[num6] * data[num5 + columnIndices[num6]];
						}
						result.At(num, num4, zero);
					}
				}
				return;
			}
			DenseVector denseVector = new DenseVector(other.RowCount);
			for (int num7 = 0; num7 < base.RowCount; num7++)
			{
				int num8 = rowPointers[num7];
				int num9 = rowPointers[num7 + 1];
				if (num8 == num9)
				{
					continue;
				}
				for (int num10 = 0; num10 < other.ColumnCount; num10++)
				{
					other.Column(num10, denseVector);
					MathNet.Numerics.Complex32 zero2 = MathNet.Numerics.Complex32.Zero;
					for (int num11 = num8; num11 < num9; num11++)
					{
						zero2 += values[num11] * denseVector[columnIndices[num11]];
					}
					result.At(num7, num10, zero2);
				}
			}
		}

		private void DoMultiplySparse(SparseMatrix other, SparseMatrix result)
		{
			result.Clear();
			MathNet.Numerics.Complex32[] values = _storage.Values;
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values2 = other._storage.Values;
			int[] rowPointers2 = other._storage.RowPointers;
			int[] columnIndices2 = other._storage.ColumnIndices;
			int rowCount = base.RowCount;
			int columnCount = other.ColumnCount;
			int[] rowPointers3 = result._storage.RowPointers;
			int[] array = new int[columnCount];
			for (int i = 0; i < columnCount; i++)
			{
				array[i] = -1;
			}
			int num = 0;
			for (int j = 0; j < rowCount; j++)
			{
				for (int k = rowPointers[j]; k < rowPointers[j + 1]; k++)
				{
					int num2 = columnIndices[k];
					for (int l = rowPointers2[num2]; l < rowPointers2[num2 + 1]; l++)
					{
						int num3 = columnIndices2[l];
						if (array[num3] != j)
						{
							array[num3] = j;
							num++;
						}
					}
				}
				rowPointers3[j + 1] = num;
			}
			int[] array2 = new int[num];
			MathNet.Numerics.Complex32[] array3 = new MathNet.Numerics.Complex32[num];
			for (int m = 0; m < columnCount; m++)
			{
				array[m] = -1;
			}
			num = 0;
			for (int n = 0; n < rowCount; n++)
			{
				int num4 = rowPointers3[n];
				for (int num5 = rowPointers[n]; num5 < rowPointers[n + 1]; num5++)
				{
					int num6 = columnIndices[num5];
					MathNet.Numerics.Complex32 complex = values[num5];
					for (int num7 = rowPointers2[num6]; num7 < rowPointers2[num6 + 1]; num7++)
					{
						int num8 = columnIndices2[num7];
						MathNet.Numerics.Complex32 complex2 = values2[num7];
						if (array[num8] < num4)
						{
							array[num8] = num;
							array2[array[num8]] = num8;
							array3[array[num8]] = complex * complex2;
							num++;
						}
						else
						{
							array3[array[num8]] += complex * complex2;
						}
					}
				}
			}
			result._storage.Values = array3;
			result._storage.ColumnIndices = array2;
			result._storage.Normalize();
		}

		protected override void DoMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int j = num; j < num2; j++)
					{
						zero += values[j] * rightSide[columnIndices[j]];
					}
					result[i] = zero;
				}
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				sparseMatrix2.Clear();
				int[] rowPointers = _storage.RowPointers;
				MathNet.Numerics.Complex32[] values = _storage.Values;
				SparseCompressedRowMatrixStorage<MathNet.Numerics.Complex32> storage = sparseMatrix._storage;
				int[] rowPointers2 = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				MathNet.Numerics.Complex32[] values2 = storage.Values;
				for (int i = 0; i < base.RowCount; i++)
				{
					int num = rowPointers2[i];
					int num2 = rowPointers2[i + 1];
					if (num == num2)
					{
						continue;
					}
					for (int j = 0; j < base.RowCount; j++)
					{
						int num3 = rowPointers[j];
						int num4 = rowPointers[j + 1];
						if (num3 == num4)
						{
							continue;
						}
						MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
						for (int k = num; k < num2; k++)
						{
							int num5 = _storage.FindItem(j, columnIndices[k]);
							if (num5 >= 0)
							{
								zero += values2[k] * values[num5];
							}
						}
						sparseMatrix2._storage.At(j, i, zero + result.At(j, i));
					}
				}
			}
			else
			{
				base.DoTransposeAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					MathNet.Numerics.Complex32 complex = rightSide[i];
					for (int j = num; j < num2; j++)
					{
						result[columnIndices[j]] += values[j] * complex;
					}
				}
			}
		}

		protected override void DoPointwiseMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					MathNet.Numerics.Complex32 value = values[j] * other.At(i, columnIndices[j]);
					if (!value.IsZero())
					{
						result.At(i, columnIndices[j], value);
					}
				}
			}
		}

		protected override void DoPointwiseDivide(Matrix<MathNet.Numerics.Complex32> divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (!values[j].IsZero())
					{
						result.At(i, columnIndices[j], values[j] / divisor.At(i, columnIndices[j]));
					}
				}
			}
		}

		public override void KroneckerProduct(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount * other.RowCount || result.ColumnCount != base.ColumnCount * other.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, result);
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (!values[j].IsZero())
					{
						result.SetSubMatrix(i * other.RowCount, other.RowCount, columnIndices[j] * other.ColumnCount, other.ColumnCount, values[j] * other);
					}
				}
			}
		}

		public override bool IsSymmetric()
		{
			if (base.RowCount != base.ColumnCount)
			{
				return false;
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num == num2)
				{
					continue;
				}
				for (int j = num; j < num2; j++)
				{
					int row = columnIndices[j];
					if (!values[j].Equals(At(row, i)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override bool IsHermitian()
		{
			if (base.RowCount != base.ColumnCount)
			{
				return false;
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			MathNet.Numerics.Complex32[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num == num2)
				{
					continue;
				}
				for (int j = num; j < num2; j++)
				{
					int row = columnIndices[j];
					if (!values[j].Equals(At(row, i).Conjugate()))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static SparseMatrix operator +(SparseMatrix leftSide, SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (leftSide.RowCount != rightSide.RowCount || leftSide.ColumnCount != rightSide.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
			}
			return (SparseMatrix)leftSide.Add(rightSide);
		}

		public static SparseMatrix operator +(SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseMatrix)rightSide.Clone();
		}

		public static SparseMatrix operator -(SparseMatrix leftSide, SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (leftSide.RowCount != rightSide.RowCount || leftSide.ColumnCount != rightSide.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
			}
			return (SparseMatrix)leftSide.Subtract(rightSide);
		}

		public static SparseMatrix operator -(SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseMatrix)rightSide.Negate();
		}

		public static SparseMatrix operator *(SparseMatrix leftSide, MathNet.Numerics.Complex32 rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Multiply(rightSide);
		}

		public static SparseMatrix operator *(MathNet.Numerics.Complex32 leftSide, SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseMatrix)rightSide.Multiply(leftSide);
		}

		public static SparseMatrix operator *(SparseMatrix leftSide, SparseMatrix rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide.ColumnCount != rightSide.RowCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
			}
			return (SparseMatrix)leftSide.Multiply(rightSide);
		}

		public static SparseVector operator *(SparseMatrix leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Multiply(rightSide);
		}

		public static SparseVector operator *(SparseVector leftSide, SparseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseVector)rightSide.LeftMultiply(leftSide);
		}

		public static SparseMatrix operator %(SparseMatrix leftSide, MathNet.Numerics.Complex32 rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Remainder(rightSide);
		}

		public override string ToTypeString()
		{
			return $"SparseMatrix {base.RowCount}x{base.ColumnCount}-Complex32 {(double)NonZerosCount / ((double)base.RowCount * (double)base.ColumnCount):P2} Filled";
		}
	}
}
