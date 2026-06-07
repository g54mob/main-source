using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public class DiagonalMatrixStorage<T> : MatrixStorage<T> where T : struct, IEquatable<T>, IFormattable
	{
		[DataMember(Order = 1)]
		public readonly T[] Data;

		public override bool IsDense => false;

		public override bool IsFullyMutable => false;

		internal DiagonalMatrixStorage(int rows, int columns)
			: base(rows, columns)
		{
			Data = new T[Math.Min(rows, columns)];
		}

		internal DiagonalMatrixStorage(int rows, int columns, T[] data)
			: base(rows, columns)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.Length != Math.Min(rows, columns))
			{
				throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {Math.Min(rows, columns)}.");
			}
			Data = data;
		}

		public override bool IsMutableAt(int row, int column)
		{
			return row == column;
		}

		public override T At(int row, int column)
		{
			if (row != column)
			{
				return MatrixStorage<T>.Zero;
			}
			return Data[row];
		}

		public override void At(int row, int column, T value)
		{
			if (row == column)
			{
				Data[row] = value;
			}
			else if (!MatrixStorage<T>.Zero.Equals(value))
			{
				throw new IndexOutOfRangeException("Cannot set an off-diagonal element in a diagonal matrix.");
			}
		}

		public override int GetHashCode()
		{
			int num = Math.Min(Data.Length, 25);
			int num2 = 17;
			for (int i = 0; i < num; i++)
			{
				num2 = num2 * 31 + Data[i].GetHashCode();
			}
			return num2;
		}

		public override void Clear()
		{
			Array.Clear(Data, 0, Data.Length);
		}

		internal override void ClearUnchecked(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			int num = Math.Max(rowIndex, columnIndex);
			int num2 = Math.Min(rowIndex + rowCount, columnIndex + columnCount);
			if (num2 > num)
			{
				Array.Clear(Data, num, num2 - num);
			}
		}

		internal override void ClearRowsUnchecked(int[] rowIndices)
		{
			for (int i = 0; i < rowIndices.Length; i++)
			{
				Data[rowIndices[i]] = MatrixStorage<T>.Zero;
			}
		}

		internal override void ClearColumnsUnchecked(int[] columnIndices)
		{
			for (int i = 0; i < columnIndices.Length; i++)
			{
				Data[columnIndices[i]] = MatrixStorage<T>.Zero;
			}
		}

		public static DiagonalMatrixStorage<T> OfMatrix(MatrixStorage<T> matrix)
		{
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(matrix.RowCount, matrix.ColumnCount);
			matrix.CopyToUnchecked(diagonalMatrixStorage, ExistingData.AssumeZeros);
			return diagonalMatrixStorage;
		}

		public static DiagonalMatrixStorage<T> OfArray(T[,] array)
		{
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(array.GetLength(0), array.GetLength(1));
			T[] data = diagonalMatrixStorage.Data;
			for (int i = 0; i < diagonalMatrixStorage.RowCount; i++)
			{
				for (int j = 0; j < diagonalMatrixStorage.ColumnCount; j++)
				{
					if (i == j)
					{
						data[i] = array[i, j];
					}
					else if (!MatrixStorage<T>.Zero.Equals(array[i, j]))
					{
						throw new ArgumentException("Cannot set an off-diagonal element in a diagonal matrix.");
					}
				}
			}
			return diagonalMatrixStorage;
		}

		public static DiagonalMatrixStorage<T> OfValue(int rows, int columns, T diagonalValue)
		{
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(rows, columns);
			T[] data = diagonalMatrixStorage.Data;
			for (int i = 0; i < diagonalMatrixStorage.Data.Length; i++)
			{
				data[i] = diagonalValue;
			}
			return diagonalMatrixStorage;
		}

		public static DiagonalMatrixStorage<T> OfInit(int rows, int columns, Func<int, T> init)
		{
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(rows, columns);
			T[] data = diagonalMatrixStorage.Data;
			for (int i = 0; i < diagonalMatrixStorage.Data.Length; i++)
			{
				data[i] = init(i);
			}
			return diagonalMatrixStorage;
		}

		public static DiagonalMatrixStorage<T> OfEnumerable(int rows, int columns, IEnumerable<T> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data is T[] array)
			{
				T[] array2 = new T[array.Length];
				Array.Copy(array, 0, array2, 0, array.Length);
				return new DiagonalMatrixStorage<T>(rows, columns, array2);
			}
			return new DiagonalMatrixStorage<T>(rows, columns, data.ToArray());
		}

		public static DiagonalMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<Tuple<int, T>> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(rows, columns);
			T[] data2 = diagonalMatrixStorage.Data;
			foreach (var (num2, val2) in data)
			{
				data2[num2] = val2;
			}
			return diagonalMatrixStorage;
		}

		public static DiagonalMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<(int, T)> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			DiagonalMatrixStorage<T> diagonalMatrixStorage = new DiagonalMatrixStorage<T>(rows, columns);
			T[] data2 = diagonalMatrixStorage.Data;
			foreach (var (num, val) in data)
			{
				data2[num] = val;
			}
			return diagonalMatrixStorage;
		}

		internal override void CopyToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			if (target is DiagonalMatrixStorage<T> target2)
			{
				CopyToUnchecked(target2);
				return;
			}
			if (target is DenseColumnMajorMatrixStorage<T> target3)
			{
				CopyToUnchecked(target3, existingData);
				return;
			}
			if (target is SparseCompressedRowMatrixStorage<T> target4)
			{
				CopyToUnchecked(target4, existingData);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			for (int i = 0; i < Data.Length; i++)
			{
				target.At(i, i, Data[i]);
			}
		}

		private void CopyToUnchecked(DiagonalMatrixStorage<T> target)
		{
			Array.Copy(Data, 0, target.Data, 0, Data.Length);
		}

		private void CopyToUnchecked(SparseCompressedRowMatrixStorage<T> target, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			for (int i = 0; i < Data.Length; i++)
			{
				target.At(i, i, Data[i]);
			}
		}

		private void CopyToUnchecked(DenseColumnMajorMatrixStorage<T> target, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			T[] data = target.Data;
			for (int i = 0; i < Data.Length; i++)
			{
				data[i * (target.RowCount + 1)] = Data[i];
			}
		}

		internal override void CopySubMatrixToUnchecked(MatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> target2)
			{
				CopySubMatrixToUnchecked(target2, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, existingData);
				return;
			}
			if (target is DiagonalMatrixStorage<T> target3)
			{
				CopySubMatrixToUnchecked(target3, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			if (sourceRowIndex == sourceColumnIndex)
			{
				for (int i = 0; i < Math.Min(columnCount, rowCount); i++)
				{
					target.At(targetRowIndex + i, targetColumnIndex + i, Data[sourceRowIndex + i]);
				}
			}
			else if (sourceRowIndex > sourceColumnIndex && sourceColumnIndex + columnCount > sourceRowIndex)
			{
				int num = sourceRowIndex - sourceColumnIndex;
				for (int j = 0; j < Math.Min(columnCount - num, rowCount); j++)
				{
					target.At(targetRowIndex + j, num + targetColumnIndex + j, Data[sourceRowIndex + j]);
				}
			}
			else if (sourceRowIndex < sourceColumnIndex && sourceRowIndex + rowCount > sourceColumnIndex)
			{
				int num2 = sourceColumnIndex - sourceRowIndex;
				for (int k = 0; k < Math.Min(columnCount, rowCount - num2); k++)
				{
					target.At(num2 + targetRowIndex + k, targetColumnIndex + k, Data[sourceColumnIndex + k]);
				}
			}
		}

		private void CopySubMatrixToUnchecked(DiagonalMatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount)
		{
			if (sourceRowIndex - sourceColumnIndex != targetRowIndex - targetColumnIndex)
			{
				if (Data.Any((T x) => !MatrixStorage<T>.Zero.Equals(x)))
				{
					throw new NotSupportedException();
				}
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
				return;
			}
			int num = Math.Max(sourceRowIndex, sourceColumnIndex);
			int num2 = Math.Min(sourceRowIndex + rowCount, sourceColumnIndex + columnCount);
			if (num2 > num)
			{
				int destinationIndex = Math.Max(targetRowIndex, targetColumnIndex);
				Array.Copy(Data, num, target.Data, destinationIndex, num2 - num);
			}
		}

		private void CopySubMatrixToUnchecked(DenseColumnMajorMatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			if (sourceRowIndex > sourceColumnIndex && sourceColumnIndex + columnCount > sourceRowIndex)
			{
				int num = sourceRowIndex - sourceColumnIndex;
				int num2 = (num + targetColumnIndex) * target.RowCount + targetRowIndex;
				int num3 = target.RowCount + 1;
				int num4 = Math.Min(columnCount - num, rowCount) + sourceRowIndex;
				T[] data = target.Data;
				int num5 = sourceRowIndex;
				int num6 = num2;
				while (num5 < num4)
				{
					data[num6] = Data[num5];
					num5++;
					num6 += num3;
				}
			}
			else if (sourceRowIndex < sourceColumnIndex && sourceRowIndex + rowCount > sourceColumnIndex)
			{
				int num7 = sourceColumnIndex - sourceRowIndex;
				int num8 = targetColumnIndex * target.RowCount + num7 + targetRowIndex;
				int num9 = target.RowCount + 1;
				int num10 = Math.Min(columnCount, rowCount - num7) + sourceColumnIndex;
				T[] data2 = target.Data;
				int num11 = sourceColumnIndex;
				int num12 = num8;
				while (num11 < num10)
				{
					data2[num12] = Data[num11];
					num11++;
					num12 += num9;
				}
			}
			else
			{
				int num13 = targetColumnIndex * target.RowCount + targetRowIndex;
				int num14 = target.RowCount + 1;
				int num15 = Math.Min(columnCount, rowCount) + sourceRowIndex;
				T[] data3 = target.Data;
				int num16 = sourceRowIndex;
				int num17 = num13;
				while (num16 < num15)
				{
					data3[num17] = Data[num16];
					num16++;
					num17 += num14;
				}
			}
		}

		internal override void CopySubRowToUnchecked(VectorStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear(targetColumnIndex, columnCount);
			}
			if (rowIndex >= sourceColumnIndex && rowIndex < sourceColumnIndex + columnCount && rowIndex < Data.Length)
			{
				target.At(rowIndex - sourceColumnIndex + targetColumnIndex, Data[rowIndex]);
			}
		}

		internal override void CopySubColumnToUnchecked(VectorStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear(targetRowIndex, rowCount);
			}
			if (columnIndex >= sourceRowIndex && columnIndex < sourceRowIndex + rowCount && columnIndex < Data.Length)
			{
				target.At(columnIndex - sourceRowIndex + targetRowIndex, Data[columnIndex]);
			}
		}

		internal override void TransposeToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			CopyToUnchecked(target, existingData);
		}

		internal override void TransposeSquareInplaceUnchecked()
		{
		}

		public override T[] ToRowMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			int num = ColumnCount + 1;
			for (int i = 0; i < Data.Length; i++)
			{
				array[i * num] = Data[i];
			}
			return array;
		}

		public override T[] ToColumnMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			int num = RowCount + 1;
			for (int i = 0; i < Data.Length; i++)
			{
				array[i * num] = Data[i];
			}
			return array;
		}

		public override T[][] ToRowArrays()
		{
			T[][] array = new T[RowCount][];
			for (int i = 0; i < RowCount; i++)
			{
				array[i] = new T[ColumnCount];
			}
			for (int j = 0; j < Data.Length; j++)
			{
				array[j][j] = Data[j];
			}
			return array;
		}

		public override T[][] ToColumnArrays()
		{
			T[][] array = new T[ColumnCount][];
			for (int i = 0; i < ColumnCount; i++)
			{
				array[i] = new T[RowCount];
			}
			for (int j = 0; j < Data.Length; j++)
			{
				array[j][j] = Data[j];
			}
			return array;
		}

		public override T[,] ToArray()
		{
			T[,] array = new T[RowCount, ColumnCount];
			for (int i = 0; i < Data.Length; i++)
			{
				array[i, i] = Data[i];
			}
			return array;
		}

		public override IEnumerable<T> Enumerate()
		{
			for (int j = 0; j < ColumnCount; j++)
			{
				for (int i = 0; i < RowCount; i++)
				{
					yield return (i == j) ? Data[i] : MatrixStorage<T>.Zero;
				}
			}
		}

		public override IEnumerable<(int, int, T)> EnumerateIndexed()
		{
			for (int j = 0; j < ColumnCount; j++)
			{
				for (int i = 0; i < RowCount; i++)
				{
					yield return (i, j, (i == j) ? Data[i] : MatrixStorage<T>.Zero);
				}
			}
		}

		public override IEnumerable<T> EnumerateNonZero()
		{
			return Data.Where((T x) => !MatrixStorage<T>.Zero.Equals(x));
		}

		public override IEnumerable<(int, int, T)> EnumerateNonZeroIndexed()
		{
			for (int i = 0; i < Data.Length; i++)
			{
				if (!MatrixStorage<T>.Zero.Equals(Data[i]))
				{
					yield return (i, i, Data[i]);
				}
			}
		}

		public override Tuple<int, int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			for (int i = 0; i < Data.Length; i++)
			{
				if (predicate(Data[i]))
				{
					return new Tuple<int, int, T>(i, i, Data[i]);
				}
			}
			if (zeros == Zeros.Include && (RowCount > 1 || ColumnCount > 1) && predicate(MatrixStorage<T>.Zero))
			{
				return new Tuple<int, int, T>((RowCount > 1) ? 1 : 0, (RowCount <= 1) ? 1 : 0, MatrixStorage<T>.Zero);
			}
			return null;
		}

		internal override Tuple<int, int, T, TOther> Find2Unchecked<TOther>(MatrixStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros)
		{
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data })
			{
				int num = 0;
				for (int i = 0; i < ColumnCount; i++)
				{
					for (int j = 0; j < RowCount; j++)
					{
						if (predicate((j == i) ? Data[j] : MatrixStorage<T>.Zero, data[num]))
						{
							return new Tuple<int, int, T, TOther>(j, i, (j == i) ? Data[j] : MatrixStorage<T>.Zero, data[num]);
						}
						num++;
					}
				}
				return null;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data2 })
			{
				for (int k = 0; k < Data.Length; k++)
				{
					if (predicate(Data[k], data2[k]))
					{
						return new Tuple<int, int, T, TOther>(k, k, Data[k], data2[k]);
					}
				}
				if (zeros == Zeros.Include && (RowCount > 1 || ColumnCount > 1))
				{
					TOther zero = BuilderInstance<TOther>.Matrix.Zero;
					if (predicate(MatrixStorage<T>.Zero, zero))
					{
						return new Tuple<int, int, T, TOther>((RowCount > 1) ? 1 : 0, (RowCount <= 1) ? 1 : 0, MatrixStorage<T>.Zero, zero);
					}
				}
				return null;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values } sparseCompressedRowMatrixStorage)
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				for (int l = 0; l < RowCount; l++)
				{
					bool flag = false;
					int num2 = rowPointers[l];
					int num3 = rowPointers[l + 1];
					for (int m = num2; m < num3; m++)
					{
						if (columnIndices[m] == l)
						{
							flag = true;
							if (predicate(Data[l], values[m]))
							{
								return new Tuple<int, int, T, TOther>(l, l, Data[l], values[m]);
							}
						}
						else if (predicate(MatrixStorage<T>.Zero, values[m]))
						{
							return new Tuple<int, int, T, TOther>(l, columnIndices[m], MatrixStorage<T>.Zero, values[m]);
						}
					}
					if (!flag && l < ColumnCount && predicate(Data[l], zero2))
					{
						return new Tuple<int, int, T, TOther>(l, l, Data[l], zero2);
					}
				}
				if (zeros == Zeros.Include && sparseCompressedRowMatrixStorage.ValueCount < RowCount * ColumnCount && predicate(MatrixStorage<T>.Zero, zero2))
				{
					int num4 = 0;
					for (int n = 0; n < RowCount; n++)
					{
						for (int num5 = 0; num5 < ColumnCount; num5++)
						{
							if (num4 < rowPointers[n + 1] && columnIndices[num4] == num5)
							{
								num4++;
							}
							else if (n != num5)
							{
								return new Tuple<int, int, T, TOther>(n, num5, MatrixStorage<T>.Zero, zero2);
							}
						}
					}
				}
				return null;
			}
			return base.Find2Unchecked(other, predicate, zeros);
		}

		public override void MapInplace(Func<T, T> f, Zeros zeros)
		{
			if (zeros == Zeros.Include)
			{
				throw new NotSupportedException("Cannot map non-zero off-diagonal values into a diagonal matrix");
			}
			CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					Data[i] = f(Data[i]);
				}
			});
		}

		public override void MapIndexedInplace(Func<int, int, T, T> f, Zeros zeros)
		{
			if (zeros == Zeros.Include)
			{
				throw new NotSupportedException("Cannot map non-zero off-diagonal values into a diagonal matrix");
			}
			CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					Data[i] = f(i, i, Data[i]);
				}
			});
		}

		internal override void MapToUnchecked<TU>(MatrixStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData)
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(MatrixStorage<T>.Zero));
			if (target is DiagonalMatrixStorage<TU> diagonalMatrixStorage)
			{
				if (flag)
				{
					throw new NotSupportedException("Cannot map non-zero off-diagonal values into a diagonal matrix");
				}
				TU[] diagonalTargetData = diagonalMatrixStorage.Data;
				CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						diagonalTargetData[i] = f(Data[i]);
					}
				});
				return;
			}
			if (existingData == ExistingData.Clear && !flag)
			{
				target.Clear();
			}
			if (flag)
			{
				for (int num = 0; num < ColumnCount; num++)
				{
					for (int num2 = 0; num2 < RowCount; num2++)
					{
						target.At(num2, num, f((num2 == num) ? Data[num2] : MatrixStorage<T>.Zero));
					}
				}
			}
			else
			{
				for (int num3 = 0; num3 < Data.Length; num3++)
				{
					target.At(num3, num3, f(Data[num3]));
				}
			}
		}

		internal override void MapIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, Zeros zeros, ExistingData existingData)
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero));
			if (target is DiagonalMatrixStorage<TU> diagonalMatrixStorage)
			{
				if (flag)
				{
					throw new NotSupportedException("Cannot map non-zero off-diagonal values into a diagonal matrix");
				}
				TU[] diagonalTargetData = diagonalMatrixStorage.Data;
				CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						diagonalTargetData[i] = f(i, i, Data[i]);
					}
				});
				return;
			}
			if (existingData == ExistingData.Clear && !flag)
			{
				target.Clear();
			}
			if (flag)
			{
				for (int num = 0; num < ColumnCount; num++)
				{
					for (int num2 = 0; num2 < RowCount; num2++)
					{
						target.At(num2, num, f(num2, num, (num2 == num) ? Data[num2] : MatrixStorage<T>.Zero));
					}
				}
			}
			else
			{
				for (int num3 = 0; num3 < Data.Length; num3++)
				{
					target.At(num3, num3, f(num3, num3, Data[num3]));
				}
			}
		}

		internal override void MapSubMatrixIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData)
		{
			if (target is DiagonalMatrixStorage<TU> target2)
			{
				MapSubMatrixIndexedToUnchecked(target2, f, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, zeros);
				return;
			}
			if (target is DenseColumnMajorMatrixStorage<TU> target3)
			{
				MapSubMatrixIndexedToUnchecked(target3, f, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, zeros, existingData);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			if (sourceRowIndex == sourceColumnIndex)
			{
				int num = targetRowIndex;
				int num2 = targetColumnIndex;
				for (int i = 0; i < Math.Min(columnCount, rowCount); i++)
				{
					target.At(num, num2, f(num, num2, Data[sourceRowIndex + i]));
					num++;
					num2++;
				}
			}
			else if (sourceRowIndex > sourceColumnIndex && sourceColumnIndex + columnCount > sourceRowIndex)
			{
				int num3 = sourceRowIndex - sourceColumnIndex;
				int num4 = targetRowIndex;
				int num5 = targetColumnIndex + num3;
				for (int j = 0; j < Math.Min(columnCount - num3, rowCount); j++)
				{
					target.At(num4, num5, f(num4, num5, Data[sourceRowIndex + j]));
					num4++;
					num5++;
				}
			}
			else if (sourceRowIndex < sourceColumnIndex && sourceRowIndex + rowCount > sourceColumnIndex)
			{
				int num6 = sourceColumnIndex - sourceRowIndex;
				int num7 = targetRowIndex + num6;
				int num8 = targetColumnIndex;
				for (int k = 0; k < Math.Min(columnCount, rowCount - num6); k++)
				{
					target.At(num7, num8, f(num7, num8, Data[sourceColumnIndex + k]));
					num7++;
					num8++;
				}
			}
		}

		private void MapSubMatrixIndexedToUnchecked<TU>(DiagonalMatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero)) || sourceRowIndex - sourceColumnIndex != targetRowIndex - targetColumnIndex)
			{
				throw new NotSupportedException("Cannot map non-zero off-diagonal values into a diagonal matrix");
			}
			int beginInclusive = Math.Max(sourceRowIndex, sourceColumnIndex);
			int num = Math.Min(sourceRowIndex + rowCount, sourceColumnIndex + columnCount) - beginInclusive;
			if (num <= 0)
			{
				return;
			}
			TU[] targetData = target.Data;
			int beginTarget = Math.Max(targetRowIndex, targetColumnIndex);
			CommonParallel.For(0, num, 4096, delegate(int a, int b)
			{
				int num2 = beginTarget + a;
				for (int i = a; i < b; i++)
				{
					targetData[num2] = f(num2, num2, Data[beginInclusive + i]);
					num2++;
				}
			});
		}

		private void MapSubMatrixIndexedToUnchecked<TU>(DenseColumnMajorMatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero));
			if (existingData == ExistingData.Clear && !flag)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			if (flag)
			{
				TU[] targetData = target.Data;
				CommonParallel.For(0, columnCount, Math.Max(4096 / rowCount, 32), delegate(int a, int b)
				{
					int num18 = sourceColumnIndex + a;
					int num19 = targetColumnIndex + a;
					for (int i = a; i < b; i++)
					{
						int num20 = targetRowIndex + (i + targetColumnIndex) * target.RowCount;
						int num21 = sourceRowIndex;
						int num22 = targetRowIndex;
						for (int j = 0; j < rowCount; j++)
						{
							targetData[num20++] = f(num22++, num19, (num21++ == num18) ? Data[num18] : MatrixStorage<T>.Zero);
						}
						num18++;
						num19++;
					}
				});
			}
			else if (sourceRowIndex > sourceColumnIndex && sourceColumnIndex + columnCount > sourceRowIndex)
			{
				int num = sourceRowIndex - sourceColumnIndex;
				int num2 = (num + targetColumnIndex) * target.RowCount + targetRowIndex;
				int num3 = target.RowCount + 1;
				int num4 = Math.Min(columnCount - num, rowCount);
				TU[] data = target.Data;
				int num5 = 0;
				int num6 = num2;
				for (; num5 < num4; num5++)
				{
					data[num6] = f(targetRowIndex + num5, targetColumnIndex + num + num5, Data[sourceRowIndex + num5]);
					num6 += num3;
				}
			}
			else if (sourceRowIndex < sourceColumnIndex && sourceRowIndex + rowCount > sourceColumnIndex)
			{
				int num7 = sourceColumnIndex - sourceRowIndex;
				int num8 = targetColumnIndex * target.RowCount + num7 + targetRowIndex;
				int num9 = target.RowCount + 1;
				int num10 = Math.Min(columnCount, rowCount - num7);
				TU[] data2 = target.Data;
				int num11 = 0;
				int num12 = num8;
				for (; num11 < num10; num11++)
				{
					data2[num12] = f(targetRowIndex + num7 + num11, targetColumnIndex + num11, Data[sourceColumnIndex + num11]);
					num12 += num9;
				}
			}
			else
			{
				int num13 = targetColumnIndex * target.RowCount + targetRowIndex;
				int num14 = target.RowCount + 1;
				int num15 = Math.Min(columnCount, rowCount);
				TU[] data3 = target.Data;
				int num16 = 0;
				int num17 = num13;
				for (; num16 < num15; num16++)
				{
					data3[num17] = f(targetRowIndex + num16, targetColumnIndex + num16, Data[sourceRowIndex + num16]);
					num17 += num14;
				}
			}
		}

		internal override void FoldByRowUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				for (int i = 0; i < Data.Length; i++)
				{
					target[i] = finalize(f(state[i], Data[i]), 1);
				}
				for (int j = Data.Length; j < RowCount; j++)
				{
					target[j] = finalize(state[j], 0);
				}
				return;
			}
			for (int k = 0; k < RowCount; k++)
			{
				TU arg = state[k];
				for (int l = 0; l < ColumnCount; l++)
				{
					arg = f(arg, (k == l) ? Data[k] : MatrixStorage<T>.Zero);
				}
				target[k] = finalize(arg, ColumnCount);
			}
		}

		internal override void FoldByColumnUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				for (int i = 0; i < Data.Length; i++)
				{
					target[i] = finalize(f(state[i], Data[i]), 1);
				}
				for (int j = Data.Length; j < ColumnCount; j++)
				{
					target[j] = finalize(state[j], 0);
				}
				return;
			}
			for (int k = 0; k < ColumnCount; k++)
			{
				TU arg = state[k];
				for (int l = 0; l < RowCount; l++)
				{
					arg = f(arg, (l == k) ? Data[l] : MatrixStorage<T>.Zero);
				}
				target[k] = finalize(arg, RowCount);
			}
		}

		internal override TState Fold2Unchecked<TOther, TState>(MatrixStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros)
		{
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data })
			{
				int num = 0;
				for (int i = 0; i < ColumnCount; i++)
				{
					for (int j = 0; j < RowCount; j++)
					{
						state = f(state, (j == i) ? Data[j] : MatrixStorage<T>.Zero, data[num]);
						num++;
					}
				}
				return state;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data2 })
			{
				for (int k = 0; k < Data.Length; k++)
				{
					state = f(state, Data[k], data2[k]);
				}
				if (zeros == Zeros.Include)
				{
					TOther zero = BuilderInstance<TOther>.Matrix.Zero;
					int num2 = RowCount * ColumnCount - Data.Length;
					for (int l = 0; l < num2; l++)
					{
						state = f(state, MatrixStorage<T>.Zero, zero);
					}
				}
				return state;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values })
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				if (zeros == Zeros.Include)
				{
					int num3 = 0;
					for (int m = 0; m < RowCount; m++)
					{
						for (int n = 0; n < ColumnCount; n++)
						{
							state = ((num3 >= rowPointers[m + 1] || columnIndices[num3] != n) ? f(state, (m == n) ? Data[m] : MatrixStorage<T>.Zero, zero2) : f(state, (m == n) ? Data[m] : MatrixStorage<T>.Zero, values[num3++]));
						}
					}
					return state;
				}
				for (int num4 = 0; num4 < RowCount; num4++)
				{
					bool flag = false;
					int num5 = rowPointers[num4];
					int num6 = rowPointers[num4 + 1];
					for (int num7 = num5; num7 < num6; num7++)
					{
						if (columnIndices[num7] == num4)
						{
							flag = true;
							state = f(state, Data[num4], values[num7]);
						}
						else
						{
							state = f(state, MatrixStorage<T>.Zero, values[num7]);
						}
					}
					if (!flag && num4 < ColumnCount)
					{
						state = f(state, Data[num4], zero2);
					}
				}
				return state;
			}
			return base.Fold2Unchecked(other, f, state, zeros);
		}
	}
}
