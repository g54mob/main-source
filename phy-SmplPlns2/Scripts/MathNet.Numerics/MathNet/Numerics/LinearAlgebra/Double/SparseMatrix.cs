using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	[Serializable]
	[DebuggerDisplay("SparseMatrix {RowCount}x{ColumnCount}-Double {NonZerosCount}-NonZero")]
	public class SparseMatrix : Matrix
	{
		private readonly SparseCompressedRowMatrixStorage<double> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseMatrix(SparseCompressedRowMatrixStorage<double> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseMatrix(int order)
			: this(order, order)
		{
		}

		public SparseMatrix(int rows, int columns)
			: this(new SparseCompressedRowMatrixStorage<double>(rows, columns))
		{
		}

		public static SparseMatrix OfMatrix(Matrix<double> matrix)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfMatrix(matrix.Storage));
		}

		public static SparseMatrix OfArray(double[,] array)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfArray(array));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, double>> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, double)> enumerable)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static SparseMatrix OfRowMajor(int rows, int columns, IEnumerable<double> rowMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowMajorEnumerable(rows, columns, rowMajor));
		}

		public static SparseMatrix OfColumnMajor(int rows, int columns, IList<double> columnMajor)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnMajorList(rows, columns, columnMajor));
		}

		public static SparseMatrix OfColumns(IEnumerable<IEnumerable<double>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<double> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<double>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfColumnArrays(params double[][] columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnArrays(columns));
		}

		public static SparseMatrix OfColumnArrays(IEnumerable<double[]> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnArrays((columns as double[][]) ?? columns.ToArray()));
		}

		public static SparseMatrix OfColumnVectors(params Vector<double>[] columns)
		{
			VectorStorage<double>[] array = new VectorStorage<double>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnVectors(array));
		}

		public static SparseMatrix OfColumnVectors(IEnumerable<Vector<double>> columns)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfColumnVectors(columns.Select((Vector<double> c) => c.Storage).ToArray()));
		}

		public static SparseMatrix OfRows(IEnumerable<IEnumerable<double>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<double> v) => v.ToArray()).ToArray());
		}

		public static SparseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<double>> data)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowEnumerables(rows, columns, data));
		}

		public static SparseMatrix OfRowArrays(params double[][] rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowArrays(rows));
		}

		public static SparseMatrix OfRowArrays(IEnumerable<double[]> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowArrays((rows as double[][]) ?? rows.ToArray()));
		}

		public static SparseMatrix OfRowVectors(params Vector<double>[] rows)
		{
			VectorStorage<double>[] array = new VectorStorage<double>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowVectors(array));
		}

		public static SparseMatrix OfRowVectors(IEnumerable<Vector<double>> rows)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfRowVectors(rows.Select((Vector<double> r) => r.Storage).ToArray()));
		}

		public static SparseMatrix OfDiagonalVector(Vector<double> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Count, diagonal.Count);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalVector(int rows, int columns, Vector<double> diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(double[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(diagonal.Length, diagonal.Length);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix OfDiagonalArray(int rows, int columns, double[] diagonal)
		{
			SparseMatrix sparseMatrix = new SparseMatrix(rows, columns);
			sparseMatrix.SetDiagonal(diagonal);
			return sparseMatrix;
		}

		public static SparseMatrix Create(int rows, int columns, double value)
		{
			if (value == 0.0)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfValue(rows, columns, value));
		}

		public static SparseMatrix Create(int rows, int columns, Func<int, int, double> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfInit(rows, columns, init));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, double value)
		{
			if (value == 0.0)
			{
				return new SparseMatrix(rows, columns);
			}
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static SparseMatrix CreateDiagonal(int rows, int columns, Func<int, double> init)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfDiagonalInit(rows, columns, init));
		}

		public static SparseMatrix CreateIdentity(int order)
		{
			return new SparseMatrix(SparseCompressedRowMatrixStorage<double>.OfDiagonalInit(order, order, (int _) => Matrix<double>.One));
		}

		public override Matrix<double> LowerTriangle()
		{
			Matrix<double> result = Matrix<double>.Build.SameAs(this);
			LowerTriangleImpl(result);
			return result;
		}

		public override void LowerTriangle(Matrix<double> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<double> matrix = Matrix<double>.Build.SameAs(result);
				LowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				LowerTriangleImpl(result);
			}
		}

		private void LowerTriangleImpl(Matrix<double> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
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

		public override Matrix<double> UpperTriangle()
		{
			Matrix<double> result = Matrix<double>.Build.SameAs(this);
			UpperTriangleImpl(result);
			return result;
		}

		public override void UpperTriangle(Matrix<double> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<double> matrix = Matrix<double>.Build.SameAs(result);
				UpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				UpperTriangleImpl(result);
			}
		}

		private void UpperTriangleImpl(Matrix<double> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
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

		public override Matrix<double> StrictlyLowerTriangle()
		{
			Matrix<double> result = Matrix<double>.Build.SameAs(this);
			StrictlyLowerTriangleImpl(result);
			return result;
		}

		public override void StrictlyLowerTriangle(Matrix<double> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<double> matrix = Matrix<double>.Build.SameAs(result);
				StrictlyLowerTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyLowerTriangleImpl(result);
			}
		}

		private void StrictlyLowerTriangleImpl(Matrix<double> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
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

		public override Matrix<double> StrictlyUpperTriangle()
		{
			Matrix<double> result = Matrix<double>.Build.SameAs(this);
			StrictlyUpperTriangleImpl(result);
			return result;
		}

		public override void StrictlyUpperTriangle(Matrix<double> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this == result)
			{
				Matrix<double> matrix = Matrix<double>.Build.SameAs(result);
				StrictlyUpperTriangle(matrix);
				matrix.CopyTo(result);
			}
			else
			{
				result.Clear();
				StrictlyUpperTriangleImpl(result);
			}
		}

		private void StrictlyUpperTriangleImpl(Matrix<double> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
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

		protected override void DoNegate(Matrix<double> result)
		{
			CopyTo(result);
			DoMultiply(-1.0, result);
		}

		public override double InfinityNorm()
		{
			int[] rowPointers = _storage.RowPointers;
			double[] values = _storage.Values;
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
						num4 += Math.Abs(values[j]);
					}
					num = Math.Max(num, num4);
				}
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			SparseCompressedRowMatrixStorage<double> sparseCompressedRowMatrixStorage = (SparseCompressedRowMatrixStorage<double>)(this * Transpose()).Storage;
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			int[] columnIndices = sparseCompressedRowMatrixStorage.ColumnIndices;
			double[] values = sparseCompressedRowMatrixStorage.Values;
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
						num += Math.Abs(values[j]);
					}
				}
			}
			return Math.Sqrt(num);
		}

		protected override void DoAdd(Matrix<double> other, Matrix<double> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				if (this == other)
				{
					if (this != result)
					{
						CopyTo(result);
					}
					LinearAlgebraControl.Provider.ScaleArray(2.0, sparseMatrix2._storage.Values, sparseMatrix2._storage.Values);
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
				SparseCompressedRowMatrixStorage<double> storage = sparseMatrix3._storage;
				int[] rowPointers = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				double[] values = storage.Values;
				for (int i = 0; i < storage.RowCount; i++)
				{
					int num = rowPointers[i + 1];
					for (int j = rowPointers[i]; j < num; j++)
					{
						int column = columnIndices[j];
						double value = values[j] + result.At(i, column);
						result.At(i, column, value);
					}
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(Matrix<double> other, Matrix<double> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				if (this == other)
				{
					result.Clear();
					return;
				}
				SparseCompressedRowMatrixStorage<double> storage = sparseMatrix._storage;
				int[] rowPointers = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				double[] values = storage.Values;
				if (this == sparseMatrix2)
				{
					for (int i = 0; i < storage.RowCount; i++)
					{
						int num = rowPointers[i + 1];
						for (int j = rowPointers[i]; j < num; j++)
						{
							int column = columnIndices[j];
							double value = sparseMatrix2.At(i, column) - values[j];
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
				double[] values2 = _storage.Values;
				for (int k = 0; k < base.RowCount; k++)
				{
					int num2 = rowPointers2[k + 1];
					for (int l = rowPointers2[k]; l < num2; l++)
					{
						int column2 = columnIndices2[l];
						double value2 = sparseMatrix2.At(k, column2) + values2[l];
						result.At(k, column2, value2);
					}
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoMultiply(double scalar, Matrix<double> result)
		{
			if (scalar == 1.0)
			{
				CopyTo(result);
				return;
			}
			if (scalar == 0.0 || NonZerosCount == 0)
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
			double[] values = _storage.Values;
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

		protected override void DoMultiply(Matrix<double> other, Matrix<double> result)
		{
			SparseMatrix sparseMatrix = result as SparseMatrix;
			if (other is SparseMatrix other2 && sparseMatrix != null)
			{
				DoMultiplySparse(other2, sparseMatrix);
				return;
			}
			if (other.Storage is DiagonalMatrixStorage<double> diagonalMatrixStorage && sparseMatrix != null)
			{
				double[] diagonal = diagonalMatrixStorage.Data;
				if (other.ColumnCount == other.RowCount)
				{
					base.Storage.MapIndexedTo(result.Storage, (int _, int j, double x) => x * diagonal[j], Zeros.AllowSkip, ExistingData.Clear);
					return;
				}
				result.Storage.Clear();
				base.Storage.MapSubMatrixIndexedTo(result.Storage, (int _, int j, double x) => x * diagonal[j], 0, 0, base.RowCount, 0, 0, Math.Min(base.ColumnCount, other.ColumnCount), Zeros.AllowSkip, ExistingData.AssumeZeros);
				return;
			}
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			if (other.Storage is DenseColumnMajorMatrixStorage<double> { Data: var data })
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
						double num6 = 0.0;
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
					double num12 = 0.0;
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
			double[] values = _storage.Values;
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values2 = other._storage.Values;
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
			double[] array3 = new double[num];
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
					double num7 = values[num5];
					for (int num8 = rowPointers2[num6]; num8 < rowPointers2[num6 + 1]; num8++)
					{
						int num9 = columnIndices2[num8];
						double num10 = values2[num8];
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

		protected override void DoMultiply(Vector<double> rightSide, Vector<double> result)
		{
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					double num3 = 0.0;
					for (int j = num; j < num2; j++)
					{
						num3 += values[j] * rightSide[columnIndices[j]];
					}
					result[i] = num3;
				}
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			if (other is SparseMatrix sparseMatrix && result is SparseMatrix sparseMatrix2)
			{
				sparseMatrix2.Clear();
				int[] rowPointers = _storage.RowPointers;
				double[] values = _storage.Values;
				SparseCompressedRowMatrixStorage<double> storage = sparseMatrix._storage;
				int[] rowPointers2 = storage.RowPointers;
				int[] columnIndices = storage.ColumnIndices;
				double[] values2 = storage.Values;
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
						double num5 = 0.0;
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

		protected override void DoTransposeThisAndMultiply(Vector<double> rightSide, Vector<double> result)
		{
			result.Clear();
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i];
				int num2 = rowPointers[i + 1];
				if (num != num2)
				{
					double num3 = rightSide[i];
					for (int j = num; j < num2; j++)
					{
						result[columnIndices[j]] += values[j] * num3;
					}
				}
			}
		}

		protected override void DoPointwiseMultiply(Matrix<double> other, Matrix<double> result)
		{
			if (this != result)
			{
				result.Clear();
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					double num2 = values[j] * other.At(i, columnIndices[j]);
					if (num2 != 0.0)
					{
						result.At(i, columnIndices[j], num2);
					}
				}
			}
		}

		protected override void DoPointwiseDivide(Matrix<double> divisor, Matrix<double> result)
		{
			if (this != result)
			{
				result.Clear();
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (values[j] != 0.0)
					{
						result.At(i, columnIndices[j], values[j] / divisor.At(i, columnIndices[j]));
					}
				}
			}
		}

		public override void KroneckerProduct(Matrix<double> other, Matrix<double> result)
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, result);
			}
			int[] rowPointers = _storage.RowPointers;
			int[] columnIndices = _storage.ColumnIndices;
			double[] values = _storage.Values;
			for (int i = 0; i < base.RowCount; i++)
			{
				int num = rowPointers[i + 1];
				for (int j = rowPointers[i]; j < num; j++)
				{
					if (values[j] != 0.0)
					{
						result.SetSubMatrix(i * other.RowCount, other.RowCount, columnIndices[j] * other.ColumnCount, other.ColumnCount, values[j] * other);
					}
				}
			}
		}

		protected override void DoModulus(double divisor, Matrix<double> result)
		{
			if (result is SparseMatrix sparseMatrix)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				SparseCompressedRowMatrixStorage<double> storage = sparseMatrix._storage;
				double[] values = storage.Values;
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

		protected override void DoRemainder(double divisor, Matrix<double> result)
		{
			if (result is SparseMatrix sparseMatrix)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				SparseCompressedRowMatrixStorage<double> storage = sparseMatrix._storage;
				double[] values = storage.Values;
				for (int i = 0; i < storage.Values.Length; i++)
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
			double[] values = _storage.Values;
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static SparseMatrix operator *(SparseMatrix leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Multiply(rightSide);
		}

		public static SparseMatrix operator *(double leftSide, SparseMatrix rightSide)
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static SparseMatrix operator %(SparseMatrix leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseMatrix)leftSide.Remainder(rightSide);
		}

		public override string ToTypeString()
		{
			return FormattableString.Invariant($"SparseMatrix {base.RowCount}x{base.ColumnCount}-Double {(double)NonZerosCount / ((double)base.RowCount * (double)base.ColumnCount):P2} Filled");
		}
	}
}
