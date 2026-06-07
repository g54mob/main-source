using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	[DebuggerDisplay("SparseMatrix {RowCount}x{ColumnCount}-Single {NonZerosCount}-NonZero")]
	public class SparseMatrix : Matrix
	{
		private readonly SparseCompressedRowMatrixStorage<float> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseMatrix(SparseCompressedRowMatrixStorage<float> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseMatrix(int order)
			: this(order, order)
		{
		}

		public SparseMatrix(int rows, int columns)
			: this(new SparseCompressedRowMatrixStorage<float>(rows, columns))
		{
		}

		public static SparseMatrix OfMatrix(Matrix<float> matrix)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfMatrix(matrix.Storage));
		}

		public static SparseMatrix OfArray(float[,] array)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfArray(array));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, float>> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, float)> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfRowMajor(int rows, int columns, IEnumerable<float> rowMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowMajorEnumerable(rows, columns, rowMajor));
		}

		public static SparseMatrix OfColumnMajor(int rows, int columns, IList<float> columnMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnMajorList(rows, columns, columnMajor));
		}

		public static SparseMatrix OfColumns(IEnumerable<IEnumerable<float>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<float> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<float>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfColumnArrays(params float[][] columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnArrays(columns));
		}

		public static SparseMatrix OfColumnArrays(IEnumerable<float[]> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnArrays((columns as float[][]) ?? columns.ToArray()));
		}

		public static SparseMatrix OfColumnVectors(params Vector<float>[] columns)
		{
			VectorStorage<float>[] array = new VectorStorage<float>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnVectors(array));
		}

		public static SparseMatrix OfColumnVectors(IEnumerable<Vector<float>> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfColumnVectors(columns.Select((Vector<float> c) => c.Storage).ToArray()));
		}

		public static SparseMatrix OfRows(IEnumerable<IEnumerable<float>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<float> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<float>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfRowArrays(params float[][] rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowArrays(rows));
		}

		public static SparseMatrix OfRowArrays(IEnumerable<float[]> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowArrays((rows as float[][]) ?? rows.ToArray()));
		}

		public static SparseMatrix OfRowVectors(params Vector<float>[] rows)
		{
			VectorStorage<float>[] array = new VectorStorage<float>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowVectors(array));
		}

		public static SparseMatrix OfRowVectors(IEnumerable<Vector<float>> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfRowVectors(rows.Select((Vector<float> r) => r.Storage).ToArray()));
		}

		public static SparseMatrix OfDiagonalVector(Vector<float> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Count, diagonal.Count);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalVector(int rows, int columns, Vector<float> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(float[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Length, diagonal.Length);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(int rows, int columns, float[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix Create(int rows, int columns, float value)
		{
			if (value == 0f)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfValue(rows, columns, value));
		}

		public static SparseMatrix Create(int rows, int columns, Func<int, int, float> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfInit(rows, columns, init));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, float value)
		{
			if (value == 0f)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, Func<int, float> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfDiagonalInit(rows, columns, init));
		}

		public static SparseMatrix CreateIdentity(int order)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<float>.OfDiagonalInit(order, order, (int _) => Matrix<float>.One));
		}

		public override Matrix<float> LowerTriangle()
		{
			Matrix<float> result = Matrix<float>.Build.SameAs(this);
			LowerTriangleImpl(result);
			return result;
		}

		public override void LowerTriangle(Matrix<float> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<float> matrix = Matrix<float>.Build.SameAs(result);
				LowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				LowerTriangleImpl(result);
			}
		}

		private void LowerTriangleImpl(Matrix<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
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

		public override Matrix<float> UpperTriangle()
		{
			Matrix<float> result = Matrix<float>.Build.SameAs(this);
			UpperTriangleImpl(result);
			return result;
		}

		public override void UpperTriangle(Matrix<float> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<float> matrix = Matrix<float>.Build.SameAs(result);
				UpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				UpperTriangleImpl(result);
			}
		}

		private void UpperTriangleImpl(Matrix<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
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

		public override Matrix<float> StrictlyLowerTriangle()
		{
			Matrix<float> result = Matrix<float>.Build.SameAs(this);
			StrictlyLowerTriangleImpl(result);
			return result;
		}

		public override void StrictlyLowerTriangle(Matrix<float> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<float> matrix = Matrix<float>.Build.SameAs(result);
				StrictlyLowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyLowerTriangleImpl(result);
			}
		}

		private void StrictlyLowerTriangleImpl(Matrix<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
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

		public override Matrix<float> StrictlyUpperTriangle()
		{
			Matrix<float> result = Matrix<float>.Build.SameAs(this);
			StrictlyUpperTriangleImpl(result);
			return result;
		}

		public override void StrictlyUpperTriangle(Matrix<float> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<float> matrix = Matrix<float>.Build.SameAs(result);
				StrictlyUpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyUpperTriangleImpl(result);
			}
		}

		private void StrictlyUpperTriangleImpl(Matrix<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
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

		protected override void DoNegate(Matrix<float> result)
		{
			CopyTo(result);
			DoMultiply(-1f, result);
		}

		public override double InfinityNorm()
		{
			int[] rowPointers = _storage.RowPointers;
			float[] values = _storage.Values;
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
						num4 += (double)Math.Abs(values[j]);
					}
					num = Math.Max(num, num4);
				}
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			SparseCompressedRowMatrixStorage<float> sparseCompressedRowMatrixStorage = (SparseCompressedRowMatrixStorage<float>)(this * Transpose()).Storage;
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			int[] columnIndices = sparseCompressedRowMatrixStorage.ColumnIndices;
			float[] values = sparseCompressedRowMatrixStorage.Values;
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
					if (i == columnIndices[j])
					{
						num += (double)Math.Abs(values[j]);
					}
				}
			}
			return Math.Sqrt(num);
		}

		protected override void DoAdd(Matrix<float> other, Matrix<float> result)
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
				SparseCompressedRowMatrixStorage<float> storage = sparseMatrix3._storage;
				int[] rowPointers = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				float[] values = storage.Values;
				for (int i = 0; i < storage.RowCount; i++)
				{
					int num = rowPointers[i + 1];
					for (int j = rowPointers[i]; j < num; j++)
					{
						int column = columnIndices[j];
						float value = values[j] + result.At(i, column);
						result.At(i, column, value);
					}
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(Matrix<float> other, Matrix<float> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				if (this == other)
				{
					result.Clear();
					return;
				}
				SparseCompressedRowMatrixStorage<float> storage = sparseMatrix._storage;
				int[] rowPointers = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				float[] values = storage.Values;
				if (this == sparseMatrix2)
				{
					for (int i = 0; i < storage.RowCount; i++)
					{
						int num = rowPointers[i + 1];
						for (int j = rowPointers[i]; j < num; j++)
						{
							int column = columnIndices[j];
							float value = sparseMatrix2.At(i, column) - values[j];
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
				float[] values2 = _storage.Values;
				for (int k = 0; k < base.RowCount; k++)
				{
					int num2 = rowPointers2[k + 1];
					for (int l = rowPointers2[k]; l < num2; l++)
					{
						int column2 = columnIndices2[l];
						float value2 = sparseMatrix2.At(k, column2) + values2[l];
						result.At(k, column2, value2);
					}
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoMultiply(float scalar, Matrix<float> result)
		{
			if ((double)scalar == 1.0)
			{
				CopyTo(result);
				return;
			}
			if ((double)scalar == 0.0 || NonZerosCount == 0)
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
			float[] values = _storage.Values;
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

		protected override void DoMultiply(Matrix<float> other, Matrix<float> result)
		{
			SparseMatrix sparseMatrix = result as SparseMatrix;
			if (other is SparseMatrix other2 && sparseMatrix != null)
			{
				DoMultiplySparse(other2, sparseMatrix);
				return;
			}
			if (other.Storage is DiagonalMatrixStorage<float> diagonalMatrixStorage && sparseMatrix != null)
			{
				float[] diagonal = diagonalMatrixStorage.Data;
				if (other.ColumnCount == other.RowCount)
				{
					base.Storage.MapIndexedTo(result.Storage, (int _, int j, float x) => x * diagonal[j], Zeros.AllowSkip, ExistingData.Clear);
					return;
				}
				result.Storage.Clear();
				base.Storage.MapSubMatrixIndexedTo(result.Storage, (int _, int j, float x) => x * diagonal[j], 0, 0, base.RowCount, 0, 0, Math.Min(base.ColumnCount, other.ColumnCount), Zeros.AllowSkip, ExistingData.AssumeZeros);
				return;
			}
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			if (other.Storage is DenseColumnMajorMatrixStorage<float> { Data: var data })
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
						float num6 = 0f;
						for (int num7 = num2; num7 < num3; num7++)
						{
							num6 += values[num7] * data[num5 + columnIndices[num7]];
						}
						result.At(num, num4, num6);
					}
				}
				return;
			}
			DenseVector denseVector = new DenseVector(other.RowCount);
			for (int num8 = 0; num8 < base.RowCount; num8++)
			{
				int num9 = rowPointers[num8];
				int num10 = rowPointers[num8 + 1];
				if (num9 == num10)
				{
					continue;
				}
				for (int num11 = 0; num11 < other.ColumnCount; num11++)
				{
					other.Column(num11, denseVector);
					float num12 = 0f;
					for (int num13 = num9; num13 < num10; num13++)
					{
						num12 += values[num13] * denseVector[columnIndices[num13]];
					}
					result.At(num8, num11, num12);
				}
			}
		}

		private void DoMultiplySparse(SparseMatrix other, SparseMatrix result)
		{
			result.Clear();
			float[] values = _storage.Values;
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values2 = other._storage.Values;
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
			float[] array3 = new float[num];
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
					float num7 = values[num5];
					for (int num8 = rowPointers2[num6]; num8 < rowPointers2[num6 + 1]; num8++)
					{
						int num9 = columnIndices2[num8];
						float num10 = values2[num8];
						if (array[num9] < num4)
						{
							array[num9] = num;
							array2[array[num9]] = num9;
							array3[array[num9]] = num7 * num10;
							num++;
						}
						else
						{
							array3[array[num9]] += num7 * num10;
						}
					}
				}
			}
			result._storage.Values = array3;
			result._storage.ColumnIndices = array2;
			result._storage.Normalize();
		}

		protected override void DoMultiply(Vector<float> rightSide, Vector<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					float num3 = 0f;
					for (int j = num; j < num2; j++)
					{
						num3 += values[j] * rightSide[columnIndices[j]];
					}
					result[i] = num3;
				}
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				sparseMatrix2.Clear();
				int[] rowPointers = _storage.RowPointers;
				float[] values = _storage.Values;
				SparseCompressedRowMatrixStorage<float> storage = sparseMatrix._storage;
				int[] rowPointers2 = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				float[] values2 = storage.Values;
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
						float num5 = 0f;
						for (int k = num; k < num2; k++)
						{
							int num6 = _storage.FindItem(j, columnIndices[k]);
							if (num6 >= 0)
							{
								num5 += values2[k] * values[num6];
							}
						}
						sparseMatrix2._storage.At(j, i, num5 + result.At(j, i));
					}
				}
			}
			else
			{
				base.DoTransposeAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<float> rightSide, Vector<float> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					float num3 = rightSide[i];
					for (int j = num; j < num2; j++)
					{
						result[columnIndices[j]] += values[j] * num3;
					}
				}
			}
		}

		protected override void DoPointwiseMultiply(Matrix<float> other, Matrix<float> result)
		{
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					float num2 = values[j] * other.At(i, columnIndices[j]);
					if (num2 != 0f)
					{
						result.At(i, columnIndices[j], num2);
					}
				}
			}
		}

		protected override void DoPointwiseDivide(Matrix<float> divisor, Matrix<float> result)
		{
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (values[j] != 0f)
					{
						result.At(i, columnIndices[j], values[j] / divisor.At(i, columnIndices[j]));
					}
				}
			}
		}

		public override void KroneckerProduct(Matrix<float> other, Matrix<float> result)
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, result);
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			float[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (values[j] != 0f)
					{
						result.SetSubMatrix(i * other.RowCount, other.RowCount, columnIndices[j] * other.ColumnCount, other.ColumnCount, values[j] * other);
					}
				}
			}
		}

		protected override void DoModulus(float divisor, Matrix<float> result)
		{
			if (result is SparseMatrix sparseMatrix)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				SparseCompressedRowMatrixStorage<float> storage = sparseMatrix._storage;
				float[] values = storage.Values;
				for (int i = 0; i < storage.Values.Length; i++)
				{
					values[i] = Euclid.Modulus(values[i], divisor);
				}
			}
			else
			{
				base.DoModulus(divisor, result);
			}
		}

		protected override void DoRemainder(float divisor, Matrix<float> result)
		{
			if (result is SparseMatrix sparseMatrix)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				float[] values = sparseMatrix._storage.Values;
				for (int i = 0; i < values.Length; i++)
				{
					values[i] %= divisor;
				}
			}
			else
			{
				base.DoRemainder(divisor, result);
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
			float[] values = _storage.Values;
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
					float obj = At(row, i);
					if (!values[j].Equals(obj))
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static SparseMatrix operator *(SparseMatrix leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Multiply(rightSide);
		}

		public static SparseMatrix operator *(float leftSide, SparseMatrix rightSide)
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static SparseMatrix operator %(SparseMatrix leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Remainder(rightSide);
		}

		public override string ToTypeString()
		{
			return FormattableString.Invariant($"SparseMatrix {base.RowCount}x{base.ColumnCount}-Single {(double)NonZerosCount / ((double)base.RowCount * (double)base.ColumnCount):P2} Filled");
		}
	}
}
