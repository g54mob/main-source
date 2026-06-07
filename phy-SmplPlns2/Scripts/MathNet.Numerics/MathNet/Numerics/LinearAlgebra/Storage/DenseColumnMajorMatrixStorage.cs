using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public class DenseColumnMajorMatrixStorage<T> : MatrixStorage<T> where T : struct, IEquatable<T>, IFormattable
	{
		[DataMember(Order = 1)]
		public readonly T[] Data;

		public override bool IsDense => true;

		public override bool IsFullyMutable => true;

		internal DenseColumnMajorMatrixStorage(int rows, int columns)
			: base(rows, columns)
		{
			Data = new T[rows * columns];
		}

		internal DenseColumnMajorMatrixStorage(int rows, int columns, T[] data)
			: base(rows, columns)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.Length != rows * columns)
			{
				throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows * columns}.");
			}
			Data = data;
		}

		public override bool IsMutableAt(int row, int column)
		{
			return true;
		}

		public override T At(int row, int column)
		{
			return Data[column * RowCount + row];
		}

		public override void At(int row, int column, T value)
		{
			Data[column * RowCount + row] = value;
		}

		private void RowColumnAtIndex(int index, out int row, out int column)
		{
			column = Math.DivRem(index, RowCount, out row);
		}

		public override void Clear()
		{
			Array.Clear(Data, 0, Data.Length);
		}

		internal override void ClearUnchecked(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			if (rowIndex == 0 && columnIndex == 0 && rowCount == RowCount && columnCount == ColumnCount)
			{
				Array.Clear(Data, 0, Data.Length);
				return;
			}
			for (int i = columnIndex; i < columnIndex + columnCount; i++)
			{
				Array.Clear(Data, i * RowCount + rowIndex, rowCount);
			}
		}

		internal override void ClearRowsUnchecked(int[] rowIndices)
		{
			T[] data = Data;
			for (int i = 0; i < ColumnCount; i++)
			{
				int num = i * RowCount;
				for (int j = 0; j < rowIndices.Length; j++)
				{
					data[num + rowIndices[j]] = MatrixStorage<T>.Zero;
				}
			}
		}

		internal override void ClearColumnsUnchecked(int[] columnIndices)
		{
			for (int i = 0; i < columnIndices.Length; i++)
			{
				Array.Clear(Data, columnIndices[i] * RowCount, RowCount);
			}
		}

		public static DenseColumnMajorMatrixStorage<T> OfMatrix(MatrixStorage<T> matrix)
		{
			DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage = new DenseColumnMajorMatrixStorage<T>(matrix.RowCount, matrix.ColumnCount);
			matrix.CopyToUnchecked(denseColumnMajorMatrixStorage, ExistingData.AssumeZeros);
			return denseColumnMajorMatrixStorage;
		}

		public static DenseColumnMajorMatrixStorage<T> OfValue(int rows, int columns, T value)
		{
			DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage = new DenseColumnMajorMatrixStorage<T>(rows, columns);
			T[] data = denseColumnMajorMatrixStorage.Data;
			CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					data[i] = value;
				}
			});
			return denseColumnMajorMatrixStorage;
		}

		public static DenseColumnMajorMatrixStorage<T> OfInit(int rows, int columns, Func<int, int, T> init)
		{
			DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage = new DenseColumnMajorMatrixStorage<T>(rows, columns);
			T[] data = denseColumnMajorMatrixStorage.Data;
			int num = 0;
			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					data[num++] = init(j, i);
				}
			}
			return denseColumnMajorMatrixStorage;
		}

		public static DenseColumnMajorMatrixStorage<T> OfDiagonalInit(int rows, int columns, Func<int, T> init)
		{
			DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage = new DenseColumnMajorMatrixStorage<T>(rows, columns);
			T[] data = denseColumnMajorMatrixStorage.Data;
			int num = 0;
			int num2 = rows + 1;
			for (int i = 0; i < Math.Min(rows, columns); i++)
			{
				data[num] = init(i);
				num += num2;
			}
			return denseColumnMajorMatrixStorage;
		}

		public static DenseColumnMajorMatrixStorage<T> OfArray(T[,] array)
		{
			DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage = new DenseColumnMajorMatrixStorage<T>(array.GetLength(0), array.GetLength(1));
			T[] data = denseColumnMajorMatrixStorage.Data;
			int num = 0;
			for (int i = 0; i < denseColumnMajorMatrixStorage.ColumnCount; i++)
			{
				for (int j = 0; j < denseColumnMajorMatrixStorage.RowCount; j++)
				{
					data[num++] = array[j, i];
				}
			}
			return denseColumnMajorMatrixStorage;
		}

		public static DenseColumnMajorMatrixStorage<T> OfColumnArrays(T[][] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			int num = data.Length;
			int num2 = data[0].Length;
			T[] array = new T[num2 * num];
			for (int i = 0; i < data.Length; i++)
			{
				Array.Copy(data[i], 0, array, i * num2, num2);
			}
			return new DenseColumnMajorMatrixStorage<T>(num2, num, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfRowArrays(T[][] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			int num = data.Length;
			int num2 = data[0].Length;
			T[] array = new T[num * num2];
			for (int i = 0; i < num2; i++)
			{
				int num3 = i * num;
				for (int j = 0; j < num; j++)
				{
					array[num3 + j] = data[j][i];
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(num, num2, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfColumnMajorArray(int rows, int columns, T[] data)
		{
			T[] array = new T[rows * columns];
			Array.Copy(data, 0, array, 0, Math.Min(array.Length, data.Length));
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfRowMajorArray(int rows, int columns, T[] data)
		{
			T[] array = new T[rows * columns];
			for (int i = 0; i < rows; i++)
			{
				int num = i * columns;
				for (int j = 0; j < columns; j++)
				{
					array[j * rows + i] = data[num + j];
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfColumnVectors(VectorStorage<T>[] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			int num = data.Length;
			int length = data[0].Length;
			T[] array = new T[length * num];
			for (int i = 0; i < data.Length; i++)
			{
				VectorStorage<T> vectorStorage = data[i];
				if (vectorStorage is DenseVectorStorage<T> denseVectorStorage)
				{
					Array.Copy(denseVectorStorage.Data, 0, array, i * length, length);
					continue;
				}
				int num2 = i * length;
				for (int j = 0; j < length; j++)
				{
					array[num2 + j] = vectorStorage.At(j);
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(length, num, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfRowVectors(VectorStorage<T>[] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			int num = data.Length;
			int length = data[0].Length;
			T[] array = new T[num * length];
			for (int i = 0; i < length; i++)
			{
				int num2 = i * num;
				for (int j = 0; j < num; j++)
				{
					array[num2 + j] = data[j].At(i);
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(num, length, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<Tuple<int, int, T>> data)
		{
			T[] array = new T[rows * columns];
			foreach (var (num3, num4, val2) in data)
			{
				array[num4 * rows + num3] = val2;
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<(int, int, T)> data)
		{
			T[] array = new T[rows * columns];
			foreach (var (num, num2, val) in data)
			{
				array[num2 * rows + num] = val;
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfColumnMajorEnumerable(int rows, int columns, IEnumerable<T> data)
		{
			if (data is T[] data2)
			{
				return OfColumnMajorArray(rows, columns, data2);
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, data.ToArray());
		}

		public static DenseColumnMajorMatrixStorage<T> OfRowMajorEnumerable(int rows, int columns, IEnumerable<T> data)
		{
			return OfRowMajorArray(rows, columns, (data as T[]) ?? data.ToArray());
		}

		public static DenseColumnMajorMatrixStorage<T> OfColumnEnumerables(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			T[] array = new T[rows * columns];
			using (IEnumerator<IEnumerable<T>> enumerator = data.GetEnumerator())
			{
				for (int i = 0; i < columns; i++)
				{
					if (!enumerator.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
					}
					if (enumerator.Current is T[] sourceArray)
					{
						Array.Copy(sourceArray, 0, array, i * rows, rows);
						continue;
					}
					using IEnumerator<T> enumerator2 = enumerator.Current.GetEnumerator();
					int num = (i + 1) * rows;
					for (int j = i * rows; j < num; j++)
					{
						if (!enumerator2.MoveNext())
						{
							throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
						}
						array[j] = enumerator2.Current;
					}
					if (enumerator2.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
					}
				}
				if (enumerator.MoveNext())
				{
					throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		public static DenseColumnMajorMatrixStorage<T> OfRowEnumerables(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			T[] array = new T[rows * columns];
			using (IEnumerator<IEnumerable<T>> enumerator = data.GetEnumerator())
			{
				for (int i = 0; i < rows; i++)
				{
					if (!enumerator.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
					}
					using IEnumerator<T> enumerator2 = enumerator.Current.GetEnumerator();
					for (int j = i; j < array.Length; j += rows)
					{
						if (!enumerator2.MoveNext())
						{
							throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
						}
						array[j] = enumerator2.Current;
					}
					if (enumerator2.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
					}
				}
				if (enumerator.MoveNext())
				{
					throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
				}
			}
			return new DenseColumnMajorMatrixStorage<T>(rows, columns, array);
		}

		internal override void CopyToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> target2)
			{
				CopyToUnchecked(target2);
				return;
			}
			int num = 0;
			int num2 = 0;
			while (num < ColumnCount)
			{
				for (int i = 0; i < RowCount; i++)
				{
					target.At(i, num, Data[i + num2]);
				}
				num++;
				num2 += RowCount;
			}
		}

		private void CopyToUnchecked(DenseColumnMajorMatrixStorage<T> target)
		{
			Array.Copy(Data, 0, target.Data, 0, Data.Length);
		}

		internal override void CopySubMatrixToUnchecked(MatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> target2)
			{
				CopySubMatrixToUnchecked(target2, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount);
				return;
			}
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				int num3 = sourceRowIndex + num * RowCount;
				for (int i = targetRowIndex; i < targetRowIndex + rowCount; i++)
				{
					target.At(i, num2, Data[num3++]);
				}
				num++;
				num2++;
			}
		}

		private void CopySubMatrixToUnchecked(DenseColumnMajorMatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount)
		{
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				Array.Copy(Data, num * RowCount + sourceRowIndex, target.Data, num2 * target.RowCount + targetRowIndex, rowCount);
				num++;
				num2++;
			}
		}

		internal override void CopySubRowToUnchecked(VectorStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseVectorStorage<T> { Data: var data2 })
			{
				for (int i = 0; i < columnCount; i++)
				{
					data2[i + targetColumnIndex] = data[(i + sourceColumnIndex) * RowCount + rowIndex];
				}
				return;
			}
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				target.At(num2, data[num * RowCount + rowIndex]);
				num++;
				num2++;
			}
		}

		internal override void CopySubColumnToUnchecked(VectorStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData)
		{
			if (target is DenseVectorStorage<T> denseVectorStorage)
			{
				Array.Copy(Data, columnIndex * RowCount + sourceRowIndex, denseVectorStorage.Data, targetRowIndex, rowCount);
				return;
			}
			T[] data = Data;
			int num = columnIndex * RowCount;
			int num2 = sourceRowIndex;
			int num3 = targetRowIndex;
			while (num2 < sourceRowIndex + rowCount)
			{
				target.At(num3, data[num + num2]);
				num2++;
				num3++;
			}
		}

		internal override void TransposeToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> target2)
			{
				TransposeToUnchecked(target2);
				return;
			}
			if (target is SparseCompressedRowMatrixStorage<T> target3)
			{
				TransposeToUnchecked(target3);
				return;
			}
			T[] data = Data;
			int num = 0;
			int num2 = 0;
			while (num < ColumnCount)
			{
				for (int i = 0; i < RowCount; i++)
				{
					target.At(num, i, data[i + num2]);
				}
				num++;
				num2 += RowCount;
			}
		}

		private void TransposeToUnchecked(DenseColumnMajorMatrixStorage<T> target)
		{
			T[] data = target.Data;
			for (int i = 0; i < ColumnCount; i++)
			{
				int num = i * RowCount;
				for (int j = 0; j < RowCount; j++)
				{
					data[j * ColumnCount + i] = Data[num + j];
				}
			}
		}

		private void TransposeToUnchecked(SparseCompressedRowMatrixStorage<T> target)
		{
			int[] rowPointers = target.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < ColumnCount; i++)
			{
				rowPointers[i] = list2.Count;
				int num = i * RowCount;
				for (int j = 0; j < RowCount; j++)
				{
					if (!MatrixStorage<T>.Zero.Equals(Data[num + j]))
					{
						list2.Add(Data[num + j]);
						list.Add(j);
					}
				}
			}
			rowPointers[ColumnCount] = list2.Count;
			target.ColumnIndices = list.ToArray();
			target.Values = list2.ToArray();
		}

		internal override void TransposeSquareInplaceUnchecked()
		{
			T[] data = Data;
			for (int i = 0; i < ColumnCount; i++)
			{
				int num = i * RowCount;
				for (int j = 0; j < i; j++)
				{
					T[] array = data;
					int num2 = num + j;
					T[] array2 = data;
					int num3 = j * ColumnCount + i;
					T val = data[j * ColumnCount + i];
					T val2 = data[num + j];
					array[num2] = val;
					array2[num3] = val2;
				}
			}
		}

		public override T[] ToRowMajorArray()
		{
			T[] data = Data;
			T[] array = new T[data.Length];
			for (int i = 0; i < RowCount; i++)
			{
				int num = i * ColumnCount;
				for (int j = 0; j < ColumnCount; j++)
				{
					array[num + j] = data[j * RowCount + i];
				}
			}
			return array;
		}

		public override T[] ToColumnMajorArray()
		{
			T[] array = new T[Data.Length];
			Array.Copy(Data, 0, array, 0, Data.Length);
			return array;
		}

		public override T[][] ToRowArrays()
		{
			T[][] ret = new T[RowCount][];
			CommonParallel.For(0, RowCount, Math.Max(4096 / ColumnCount, 32), delegate(int a, int b)
			{
				T[] data = Data;
				for (int i = a; i < b; i++)
				{
					T[] array = new T[ColumnCount];
					for (int j = 0; j < ColumnCount; j++)
					{
						array[j] = data[j * RowCount + i];
					}
					ret[i] = array;
				}
			});
			return ret;
		}

		public override T[][] ToColumnArrays()
		{
			T[][] ret = new T[ColumnCount][];
			CommonParallel.For(0, ColumnCount, Math.Max(4096 / RowCount, 32), delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					T[] array = new T[RowCount];
					Array.Copy(Data, i * RowCount, array, 0, RowCount);
					ret[i] = array;
				}
			});
			return ret;
		}

		public override T[,] ToArray()
		{
			T[] data = Data;
			T[,] array = new T[RowCount, ColumnCount];
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					array[i, j] = data[j * RowCount + i];
				}
			}
			return array;
		}

		public override T[] AsColumnMajorArray()
		{
			return Data;
		}

		public override IEnumerable<T> Enumerate()
		{
			return Data;
		}

		public override IEnumerable<(int, int, T)> EnumerateIndexed()
		{
			T[] data = Data;
			int index = 0;
			for (int j = 0; j < ColumnCount; j++)
			{
				for (int i = 0; i < RowCount; i++)
				{
					yield return (i, j, data[index]);
					index++;
				}
			}
		}

		public override IEnumerable<T> EnumerateNonZero()
		{
			return Data.Where((T x) => !MatrixStorage<T>.Zero.Equals(x));
		}

		public override IEnumerable<(int, int, T)> EnumerateNonZeroIndexed()
		{
			T[] data = Data;
			int index = 0;
			for (int j = 0; j < ColumnCount; j++)
			{
				for (int i = 0; i < RowCount; i++)
				{
					T val = data[index];
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						yield return (i, j, val);
					}
					index++;
				}
			}
		}

		public override Tuple<int, int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			T[] data = Data;
			for (int i = 0; i < data.Length; i++)
			{
				if (predicate(data[i]))
				{
					RowColumnAtIndex(i, out var row, out var column);
					return new Tuple<int, int, T>(row, column, data[i]);
				}
			}
			return null;
		}

		internal override Tuple<int, int, T, TOther> Find2Unchecked<TOther>(MatrixStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros)
		{
			T[] data = Data;
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					if (predicate(data[i], data2[i]))
					{
						RowColumnAtIndex(i, out var row, out var column);
						return new Tuple<int, int, T, TOther>(row, column, data[i], data2[i]);
					}
				}
				return null;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data3 })
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				int num = 0;
				for (int j = 0; j < ColumnCount; j++)
				{
					for (int k = 0; k < RowCount; k++)
					{
						if (predicate(data[num], (k == j) ? data3[k] : zero))
						{
							return new Tuple<int, int, T, TOther>(k, j, data[num], (k == j) ? data3[k] : zero);
						}
						num++;
					}
				}
				return null;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values })
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				int num2 = 0;
				for (int l = 0; l < RowCount; l++)
				{
					for (int m = 0; m < ColumnCount; m++)
					{
						if (num2 < rowPointers[l + 1] && columnIndices[num2] == m)
						{
							if (predicate(data[m * RowCount + l], values[num2]))
							{
								return new Tuple<int, int, T, TOther>(l, m, data[m * RowCount + l], values[num2]);
							}
							num2++;
						}
						else if (predicate(Data[m * RowCount + l], zero2))
						{
							return new Tuple<int, int, T, TOther>(l, m, data[m * RowCount + l], values[num2]);
						}
					}
				}
				return null;
			}
			return base.Find2Unchecked(other, predicate, zeros);
		}

		public override void MapInplace(Func<T, T> f, Zeros zeros)
		{
			CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
			{
				T[] data = Data;
				for (int i = a; i < b; i++)
				{
					data[i] = f(data[i]);
				}
			});
		}

		public override void MapIndexedInplace(Func<int, int, T, T> f, Zeros zeros)
		{
			CommonParallel.For(0, ColumnCount, Math.Max(4096 / RowCount, 32), delegate(int a, int b)
			{
				T[] data = Data;
				int num = a * RowCount;
				for (int i = a; i < b; i++)
				{
					for (int j = 0; j < RowCount; j++)
					{
						data[num] = f(j, i, data[num]);
						num++;
					}
				}
			});
		}

		internal override void MapToUnchecked<TU>(MatrixStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseColumnMajorMatrixStorage<TU> denseColumnMajorMatrixStorage)
			{
				TU[] targetData = denseColumnMajorMatrixStorage.Data;
				CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						targetData[i] = f(data[i]);
					}
				});
				return;
			}
			int num = 0;
			for (int num2 = 0; num2 < ColumnCount; num2++)
			{
				for (int num3 = 0; num3 < RowCount; num3++)
				{
					target.At(num3, num2, f(data[num++]));
				}
			}
		}

		internal override void MapIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, Zeros zeros, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseColumnMajorMatrixStorage<TU> denseColumnMajorMatrixStorage)
			{
				TU[] targetData = denseColumnMajorMatrixStorage.Data;
				CommonParallel.For(0, ColumnCount, Math.Max(4096 / RowCount, 32), delegate(int a, int b)
				{
					int num4 = a * RowCount;
					for (int i = a; i < b; i++)
					{
						for (int j = 0; j < RowCount; j++)
						{
							targetData[num4] = f(j, i, data[num4]);
							num4++;
						}
					}
				});
				return;
			}
			int num = 0;
			for (int num2 = 0; num2 < ColumnCount; num2++)
			{
				for (int num3 = 0; num3 < RowCount; num3++)
				{
					target.At(num3, num2, f(num3, num2, data[num++]));
				}
			}
		}

		internal override void MapSubMatrixIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseColumnMajorMatrixStorage<TU> denseColumnMajorMatrixStorage)
			{
				TU[] targetData = denseColumnMajorMatrixStorage.Data;
				CommonParallel.For(0, columnCount, Math.Max(4096 / rowCount, 32), delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						int num5 = sourceRowIndex + (i + sourceColumnIndex) * RowCount;
						int num6 = targetRowIndex + (i + targetColumnIndex) * target.RowCount;
						for (int j = 0; j < rowCount; j++)
						{
							targetData[num6++] = f(targetRowIndex + j, targetColumnIndex + i, data[num5++]);
						}
					}
				});
				return;
			}
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				int num3 = sourceRowIndex + num * RowCount;
				for (int num4 = targetRowIndex; num4 < targetRowIndex + rowCount; num4++)
				{
					target.At(num4, num2, f(num4, num2, data[num3++]));
				}
				num++;
				num2++;
			}
		}

		internal override void FoldByRowUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			T[] data = Data;
			for (int i = 0; i < RowCount; i++)
			{
				TU arg = state[i];
				for (int j = 0; j < ColumnCount; j++)
				{
					arg = f(arg, data[j * RowCount + i]);
				}
				target[i] = finalize(arg, ColumnCount);
			}
		}

		internal override void FoldByColumnUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			T[] data = Data;
			for (int i = 0; i < ColumnCount; i++)
			{
				int num = i * RowCount;
				TU arg = state[i];
				for (int j = 0; j < RowCount; j++)
				{
					arg = f(arg, data[num + j]);
				}
				target[i] = finalize(arg, RowCount);
			}
		}

		internal override TState Fold2Unchecked<TOther, TState>(MatrixStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros)
		{
			T[] data = Data;
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					state = f(state, data[i], data2[i]);
				}
				return state;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data3 })
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				int num = 0;
				for (int j = 0; j < ColumnCount; j++)
				{
					for (int k = 0; k < RowCount; k++)
					{
						state = f(state, data[num], (k == j) ? data3[k] : zero);
						num++;
					}
				}
				return state;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values })
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				int num2 = 0;
				for (int l = 0; l < RowCount; l++)
				{
					for (int m = 0; m < ColumnCount; m++)
					{
						state = ((num2 >= rowPointers[l + 1] || columnIndices[num2] != m) ? f(state, data[m * RowCount + l], zero2) : f(state, data[m * RowCount + l], values[num2++]));
					}
				}
				return state;
			}
			return base.Fold2Unchecked(other, f, state, zeros);
		}
	}
}
