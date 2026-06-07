using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public class SparseCompressedRowMatrixStorage<T> : MatrixStorage<T> where T : struct, IEquatable<T>, IFormattable
	{
		[DataMember(Order = 1)]
		public readonly int[] RowPointers;

		[DataMember(Order = 2)]
		public int[] ColumnIndices;

		[DataMember(Order = 3)]
		public T[] Values;

		public int ValueCount => RowPointers[RowCount];

		public override bool IsDense => false;

		public override bool IsFullyMutable => true;

		internal SparseCompressedRowMatrixStorage(int rows, int columns)
			: base(rows, columns)
		{
			RowPointers = new int[rows + 1];
			ColumnIndices = Array.Empty<int>();
			Values = Array.Empty<T>();
		}

		internal SparseCompressedRowMatrixStorage(int rows, int columns, int[] rowPointers, int[] columnIndices, T[] values)
			: base(rows, columns)
		{
			RowPointers = rowPointers;
			ColumnIndices = columnIndices;
			Values = values;
			NormalizeOrdering();
			NormalizeDuplicates();
		}

		public override bool IsMutableAt(int row, int column)
		{
			return true;
		}

		public override T At(int row, int column)
		{
			int num = FindItem(row, column);
			if (num < 0)
			{
				return MatrixStorage<T>.Zero;
			}
			return Values[num];
		}

		public override void At(int row, int column, T value)
		{
			int num = FindItem(row, column);
			if (num >= 0)
			{
				if (MatrixStorage<T>.Zero.Equals(value))
				{
					RemoveAtIndexUnchecked(num, row);
				}
				else
				{
					Values[num] = value;
				}
			}
			else
			{
				if (MatrixStorage<T>.Zero.Equals(value))
				{
					return;
				}
				num = ~num;
				int num2 = RowPointers[RowPointers.Length - 1];
				if (num2 == Values.Length && num2 < (long)RowCount * (long)ColumnCount)
				{
					long num3 = Math.Min(Values.Length + GrowthSize(), (long)RowCount * (long)ColumnCount);
					if (num3 > int.MaxValue)
					{
						throw new NotSupportedException("We only support sparse matrix with less than int.MaxValue elements.");
					}
					Array.Resize(ref Values, (int)num3);
					Array.Resize(ref ColumnIndices, (int)num3);
				}
				Array.Copy(Values, num, Values, num + 1, num2 - num);
				Array.Copy(ColumnIndices, num, ColumnIndices, num + 1, num2 - num);
				Values[num] = value;
				ColumnIndices[num] = column;
				for (int i = row + 1; i < RowPointers.Length; i++)
				{
					RowPointers[i]++;
				}
			}
		}

		private void RemoveAtIndexUnchecked(int itemIndex, int row)
		{
			int num = RowPointers[RowPointers.Length - 1];
			Array.Copy(Values, itemIndex + 1, Values, itemIndex, num - itemIndex - 1);
			Array.Copy(ColumnIndices, itemIndex + 1, ColumnIndices, itemIndex, num - itemIndex - 1);
			for (int i = row + 1; i < RowPointers.Length; i++)
			{
				RowPointers[i]--;
			}
			num--;
			if (num > 1024 && num < Values.Length / 2)
			{
				Array.Resize(ref Values, num);
				Array.Resize(ref ColumnIndices, num);
			}
		}

		public int FindItem(int row, int column)
		{
			return Array.BinarySearch(ColumnIndices, RowPointers[row], RowPointers[row + 1] - RowPointers[row], column);
		}

		private int GrowthSize()
		{
			if (Values.Length > 1024)
			{
				return Values.Length / 4;
			}
			if (Values.Length > 256)
			{
				return 512;
			}
			return (Values.Length > 64) ? 128 : 32;
		}

		public void Normalize()
		{
			NormalizeOrdering();
			NormalizeZeros();
		}

		public void NormalizeOrdering()
		{
			for (int i = 0; i < RowCount; i++)
			{
				int num = RowPointers[i];
				int num2 = RowPointers[i + 1] - num;
				if (num2 > 1)
				{
					Sorting.Sort(ColumnIndices, Values, num, num2);
				}
			}
		}

		public void NormalizeZeros()
		{
			MapInplace((T x) => x, Zeros.AllowSkip);
		}

		public void NormalizeDuplicates()
		{
			MatrixBuilder<T> matrix = BuilderInstance<T>.Matrix;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < RowCount; i++)
			{
				int j = num2;
				num2 = RowPointers[i + 1];
				while (j < num2)
				{
					int num3 = ColumnIndices[j];
					T val = Values[j];
					for (j++; j < num2 && ColumnIndices[j] == num3; j++)
					{
						val = matrix.Add(val, Values[j]);
					}
					ColumnIndices[num] = num3;
					Values[num] = val;
					num++;
				}
				RowPointers[i + 1] = num;
			}
			Array.Resize(ref Values, num);
			Array.Resize(ref ColumnIndices, num);
		}

		public void PopulateExplicitZerosOnDiagonal()
		{
			int num = 0;
			for (int i = 0; i < RowCount; i++)
			{
				bool flag = false;
				for (int j = RowPointers[i]; j < RowPointers[i + 1]; j++)
				{
					if (ColumnIndices[j] == i)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num++;
				}
			}
			if (num <= 0)
			{
				return;
			}
			int num2 = Values.Length + num;
			if (num2 > int.MaxValue)
			{
				throw new NotSupportedException("We only support sparse matrix with less than int.MaxValue elements.");
			}
			int[] array = new int[RowCount + 1];
			int[] array2 = new int[num2];
			T[] array3 = new T[num2];
			num = 0;
			for (int k = 0; k < RowCount; k++)
			{
				bool flag2 = false;
				for (int l = RowPointers[k]; l < RowPointers[k + 1]; l++)
				{
					array2[l + num] = ColumnIndices[l];
					array3[l + num] = Values[l];
					if (ColumnIndices[l] == k)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					int num3 = RowPointers[k] + num;
					int num4 = RowPointers[k + 1] + num;
					int count = num4 - num3 + 1;
					array2[num4] = k;
					array3[num4] = MatrixStorage<T>.Zero;
					Sorting.Sort(array2, array3, num3, count);
					num++;
				}
				array[k + 1] = RowPointers[k + 1] + num;
			}
			Array.Copy(array, RowPointers, RowCount + 1);
			ColumnIndices = array2;
			Values = array3;
		}

		public override int GetHashCode()
		{
			T[] values = Values;
			int num = Math.Min(ValueCount, 25);
			int num2 = 17;
			for (int i = 0; i < num; i++)
			{
				num2 = num2 * 31 + values[i].GetHashCode();
			}
			return num2;
		}

		public override void Clear()
		{
			Array.Clear(RowPointers, 0, RowPointers.Length);
		}

		internal override void ClearUnchecked(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			if (rowIndex == 0 && columnIndex == 0 && rowCount == RowCount && columnCount == ColumnCount)
			{
				Clear();
				return;
			}
			int num = RowPointers[RowPointers.Length - 1];
			for (int num2 = rowIndex + rowCount - 1; num2 >= rowIndex; num2--)
			{
				int num3 = RowPointers[num2];
				int num4 = RowPointers[num2 + 1];
				if (num3 != num4)
				{
					int num5 = Array.BinarySearch(ColumnIndices, num3, num4 - num3, columnIndex);
					int num6 = Array.BinarySearch(ColumnIndices, num3, num4 - num3, columnIndex + columnCount - 1);
					if (num5 < 0)
					{
						num5 = ~num5;
					}
					if (num6 < 0)
					{
						num6 = ~num6 - 1;
					}
					int num7 = num6 - num5 + 1;
					if (num7 > 0)
					{
						Array.Copy(Values, num5 + num7, Values, num5, num - num5 - num7);
						Array.Copy(ColumnIndices, num5 + num7, ColumnIndices, num5, num - num5 - num7);
						for (int i = num2 + 1; i < RowPointers.Length; i++)
						{
							RowPointers[i] -= num7;
						}
						num -= num7;
					}
				}
			}
			if (num > 1024 && num < Values.Length / 2)
			{
				Array.Resize(ref Values, num);
				Array.Resize(ref ColumnIndices, num);
			}
		}

		internal override void ClearRowsUnchecked(int[] rowIndices)
		{
			bool[] rows = new bool[RowCount];
			for (int i = 0; i < rowIndices.Length; i++)
			{
				rows[rowIndices[i]] = true;
			}
			MapIndexedInplace((int num, int _, T x) => (!rows[num]) ? x : MatrixStorage<T>.Zero, Zeros.AllowSkip);
		}

		internal override void ClearColumnsUnchecked(int[] columnIndices)
		{
			bool[] columns = new bool[ColumnCount];
			for (int i = 0; i < columnIndices.Length; i++)
			{
				columns[columnIndices[i]] = true;
			}
			MapIndexedInplace((int _, int j, T x) => (!columns[j]) ? x : MatrixStorage<T>.Zero, Zeros.AllowSkip);
		}

		public static SparseCompressedRowMatrixStorage<T> OfMatrix(MatrixStorage<T> matrix)
		{
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(matrix.RowCount, matrix.ColumnCount);
			matrix.CopyToUnchecked(sparseCompressedRowMatrixStorage, ExistingData.AssumeZeros);
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfValue(int rows, int columns, T value)
		{
			if (MatrixStorage<T>.Zero.Equals(value))
			{
				return new SparseCompressedRowMatrixStorage<T>(rows, columns);
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			T[] array = new T[rows * columns];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			for (int j = 0; j <= rows; j++)
			{
				rowPointers[j] = j * columns;
			}
			int[] array2 = new int[array.Length];
			for (int k = 0; k < rows; k++)
			{
				int num = k * columns;
				for (int l = 0; l < columns; l++)
				{
					array2[num + l] = l;
				}
			}
			rowPointers[rows] = array.Length;
			sparseCompressedRowMatrixStorage.ColumnIndices = array2;
			sparseCompressedRowMatrixStorage.Values = array;
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfInit(int rows, int columns, Func<int, int, T> init)
		{
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < rows; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < columns; j++)
				{
					T val = init(i, j);
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfDiagonalInit(int rows, int columns, Func<int, T> init)
		{
			int num = Math.Min(rows, columns);
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>(num);
			List<T> list2 = new List<T>(num);
			for (int i = 0; i < num; i++)
			{
				rowPointers[i] = list2.Count;
				T val = init(i);
				if (!MatrixStorage<T>.Zero.Equals(val))
				{
					list2.Add(val);
					list.Add(i);
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfArray(T[,] array)
		{
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(array.GetLength(0), array.GetLength(1));
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < sparseCompressedRowMatrixStorage.ColumnCount; j++)
				{
					if (!MatrixStorage<T>.Zero.Equals(array[i, j]))
					{
						list2.Add(array[i, j]);
						list.Add(j);
					}
				}
			}
			rowPointers[sparseCompressedRowMatrixStorage.RowCount] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfRowArrays(T[][] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(data.Length, data[0].Length);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < sparseCompressedRowMatrixStorage.ColumnCount; j++)
				{
					T val = data[i][j];
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[sparseCompressedRowMatrixStorage.RowCount] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfColumnArrays(T[][] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(data[0].Length, data.Length);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < sparseCompressedRowMatrixStorage.ColumnCount; j++)
				{
					T val = data[j][i];
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[sparseCompressedRowMatrixStorage.RowCount] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfRowVectors(VectorStorage<T>[] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(data.Length, data[0].Length);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				VectorStorage<T> vectorStorage = data[i];
				rowPointers[i] = list2.Count;
				for (int j = 0; j < sparseCompressedRowMatrixStorage.ColumnCount; j++)
				{
					T val = vectorStorage.At(j);
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[sparseCompressedRowMatrixStorage.RowCount] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfColumnVectors(VectorStorage<T>[] data)
		{
			if (data.Length == 0)
			{
				throw new ArgumentOutOfRangeException("data", "Matrices can not be empty and must have at least one row and column.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(data[0].Length, data.Length);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < sparseCompressedRowMatrixStorage.RowCount; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < sparseCompressedRowMatrixStorage.ColumnCount; j++)
				{
					T val = data[j].At(i);
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[sparseCompressedRowMatrixStorage.RowCount] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<Tuple<int, int, T>> data)
		{
			List<Tuple<int, T>>[] array = new List<Tuple<int, T>>[rows];
			foreach (Tuple<int, int, T> datum in data)
			{
				datum.Deconstruct(out var item, out var item2, out var item3);
				int num = item;
				int item4 = item2;
				T val = item3;
				item3 = MatrixStorage<T>.Zero;
				if (!item3.Equals(val))
				{
					(array[num] ?? (array[num] = new List<Tuple<int, T>>())).Add(new Tuple<int, T>(item4, val));
				}
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			int num2 = 0;
			for (int i = 0; i < rows; i++)
			{
				rowPointers[i] = num2;
				List<Tuple<int, T>> list3 = array[i];
				if (list3 == null)
				{
					continue;
				}
				list3.Sort();
				foreach (Tuple<int, T> item5 in list3)
				{
					list2.Add(item5.Item2);
					list.Add(item5.Item1);
					num2++;
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfIndexedEnumerable(int rows, int columns, IEnumerable<(int, int, T)> data)
		{
			List<Tuple<int, T>>[] array = new List<Tuple<int, T>>[rows];
			foreach (var (num, item, val) in data)
			{
				if (!MatrixStorage<T>.Zero.Equals(val))
				{
					(array[num] ?? (array[num] = new List<Tuple<int, T>>())).Add(new Tuple<int, T>(item, val));
				}
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			int num2 = 0;
			for (int i = 0; i < rows; i++)
			{
				rowPointers[i] = num2;
				List<Tuple<int, T>> list3 = array[i];
				if (list3 == null)
				{
					continue;
				}
				list3.Sort();
				foreach (Tuple<int, T> item2 in list3)
				{
					list2.Add(item2.Item2);
					list.Add(item2.Item1);
					num2++;
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfRowEnumerables(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			using (IEnumerator<IEnumerable<T>> enumerator = data.GetEnumerator())
			{
				for (int i = 0; i < rows; i++)
				{
					if (!enumerator.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
					}
					rowPointers[i] = list2.Count;
					using IEnumerator<T> enumerator2 = enumerator.Current.GetEnumerator();
					for (int j = 0; j < columns; j++)
					{
						if (!enumerator2.MoveNext())
						{
							throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
						}
						if (!MatrixStorage<T>.Zero.Equals(enumerator2.Current))
						{
							list2.Add(enumerator2.Current);
							list.Add(j);
						}
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
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfColumnEnumerables(int rows, int columns, IEnumerable<IEnumerable<T>> data)
		{
			List<Tuple<int, T>>[] array = new List<Tuple<int, T>>[rows];
			using (IEnumerator<IEnumerable<T>> enumerator = data.GetEnumerator())
			{
				for (int i = 0; i < columns; i++)
				{
					if (!enumerator.MoveNext())
					{
						throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {columns}.");
					}
					using IEnumerator<T> enumerator2 = enumerator.Current.GetEnumerator();
					for (int j = 0; j < rows; j++)
					{
						if (!enumerator2.MoveNext())
						{
							throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {rows}.");
						}
						if (!MatrixStorage<T>.Zero.Equals(enumerator2.Current))
						{
							(array[j] ?? (array[j] = new List<Tuple<int, T>>())).Add(new Tuple<int, T>(i, enumerator2.Current));
						}
					}
				}
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			int num = 0;
			for (int k = 0; k < rows; k++)
			{
				rowPointers[k] = num;
				List<Tuple<int, T>> list3 = array[k];
				if (list3 == null)
				{
					continue;
				}
				list3.Sort();
				foreach (Tuple<int, T> item in list3)
				{
					list2.Add(item.Item2);
					list.Add(item.Item1);
					num++;
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfRowMajorEnumerable(int rows, int columns, IEnumerable<T> data)
		{
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			using (IEnumerator<T> enumerator = data.GetEnumerator())
			{
				for (int i = 0; i < rows; i++)
				{
					rowPointers[i] = list2.Count;
					for (int j = 0; j < columns; j++)
					{
						enumerator.MoveNext();
						if (!MatrixStorage<T>.Zero.Equals(enumerator.Current))
						{
							list2.Add(enumerator.Current);
							list.Add(j);
						}
					}
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfColumnMajorList(int rows, int columns, IList<T> data)
		{
			if (rows * columns != data.Count)
			{
				throw new ArgumentException("Matrix dimensions must agree.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < rows; i++)
			{
				rowPointers[i] = list2.Count;
				for (int j = 0; j < columns; j++)
				{
					T val = data[i + j * rows];
					if (!MatrixStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(j);
					}
				}
			}
			rowPointers[rows] = list2.Count;
			sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
			sparseCompressedRowMatrixStorage.Values = list2.ToArray();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfCompressedSparseRowFormat(int rows, int columns, int valueCount, int[] rowPointers, int[] columnIndices, T[] values)
		{
			if (values == null)
			{
				throw new NullReferenceException("values");
			}
			if (columnIndices == null)
			{
				throw new NullReferenceException("columnIndices");
			}
			if (rowPointers == null)
			{
				throw new NullReferenceException("rowPointers");
			}
			if (rowPointers.Length < rows)
			{
				throw new Exception($"The given array has the wrong length. Should be {rows + 1}.");
			}
			if (valueCount != rowPointers[rows])
			{
				throw new Exception(string.Format("{0} should be same to {1}", "valueCount", rowPointers[rows]));
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			T[] array = new T[valueCount];
			Array.Copy(values, array, valueCount);
			int[] array2 = new int[valueCount];
			Array.Copy(columnIndices, array2, valueCount);
			Array.Copy(rowPointers, sparseCompressedRowMatrixStorage.RowPointers, rows + 1);
			sparseCompressedRowMatrixStorage.ColumnIndices = array2;
			sparseCompressedRowMatrixStorage.Values = array;
			sparseCompressedRowMatrixStorage.NormalizeOrdering();
			sparseCompressedRowMatrixStorage.NormalizeDuplicates();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfCompressedSparseColumnFormat(int rows, int columns, int valueCount, int[] rowIndices, int[] columnPointers, T[] values)
		{
			if (values == null)
			{
				throw new NullReferenceException("values");
			}
			if (rowIndices == null)
			{
				throw new NullReferenceException("rowIndices");
			}
			if (columnPointers == null)
			{
				throw new NullReferenceException("columnPointers");
			}
			if (columnPointers.Length < columns)
			{
				throw new Exception($"The given array has the wrong length. Should be {columns + 1}.");
			}
			if (valueCount != columnPointers[columns])
			{
				throw new Exception(string.Format("{0} should be same to {1}", "valueCount", columnPointers[columns]));
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			T[] array = new T[valueCount];
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			int[] array2 = new int[valueCount];
			for (int i = 0; i < columns; i++)
			{
				for (int j = columnPointers[i]; j < columnPointers[i + 1]; j++)
				{
					rowPointers[rowIndices[j] + 1]++;
				}
			}
			for (int k = 1; k < rows + 1; k++)
			{
				rowPointers[k] += rowPointers[k - 1];
			}
			int[] array3 = new int[rows];
			for (int l = 0; l < columns; l++)
			{
				for (int m = columnPointers[l]; m < columnPointers[l + 1]; m++)
				{
					int num = rowPointers[rowIndices[m]] + array3[rowIndices[m]];
					array3[rowIndices[m]]++;
					array2[num] = l;
					array[num] = values[m];
				}
			}
			sparseCompressedRowMatrixStorage.ColumnIndices = array2;
			sparseCompressedRowMatrixStorage.Values = array;
			sparseCompressedRowMatrixStorage.NormalizeOrdering();
			sparseCompressedRowMatrixStorage.NormalizeDuplicates();
			return sparseCompressedRowMatrixStorage;
		}

		public static SparseCompressedRowMatrixStorage<T> OfCoordinateFormat(int rows, int columns, int valueCount, int[] rowIndices, int[] columnIndices, T[] values)
		{
			if (values == null)
			{
				throw new NullReferenceException("values");
			}
			if (rowIndices == null)
			{
				throw new NullReferenceException("rowIndices");
			}
			if (columnIndices == null)
			{
				throw new NullReferenceException("columnIndices");
			}
			if (rowIndices.Length < valueCount || columnIndices.Length < valueCount || values.Length < valueCount)
			{
				throw new Exception($"The given array has the wrong length. Should be {valueCount}.");
			}
			SparseCompressedRowMatrixStorage<T> sparseCompressedRowMatrixStorage = new SparseCompressedRowMatrixStorage<T>(rows, columns);
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			int[] array = new int[valueCount];
			T[] array2 = new T[valueCount];
			for (int i = 0; i < valueCount; i++)
			{
				rowPointers[rowIndices[i]]++;
			}
			int j = 0;
			int num = 0;
			for (; j < rows; j++)
			{
				int num2 = rowPointers[j];
				rowPointers[j] = num;
				num += num2;
			}
			rowPointers[rows] = valueCount;
			for (int k = 0; k < valueCount; k++)
			{
				int num3 = rowIndices[k];
				int num4 = rowPointers[num3];
				array[num4] = columnIndices[k];
				array2[num4] = values[k];
				rowPointers[num3]++;
			}
			int l = 0;
			int num5 = 0;
			for (; l <= rows; l++)
			{
				ref int reference = ref rowPointers[l];
				int num6 = num5;
				int num7 = rowPointers[l];
				reference = num6;
				num5 = num7;
			}
			sparseCompressedRowMatrixStorage.ColumnIndices = array;
			sparseCompressedRowMatrixStorage.Values = array2;
			sparseCompressedRowMatrixStorage.NormalizeOrdering();
			sparseCompressedRowMatrixStorage.NormalizeDuplicates();
			return sparseCompressedRowMatrixStorage;
		}

		internal override void CopyToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			if (target is SparseCompressedRowMatrixStorage<T> target2)
			{
				CopyToUnchecked(target2);
				return;
			}
			if (target is DenseColumnMajorMatrixStorage<T> target3)
			{
				CopyToUnchecked(target3, existingData);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			if (ValueCount == 0)
			{
				return;
			}
			for (int i = 0; i < RowCount; i++)
			{
				int num = RowPointers[i];
				int num2 = RowPointers[i + 1];
				for (int j = num; j < num2; j++)
				{
					target.At(i, ColumnIndices[j], Values[j]);
				}
			}
		}

		private void CopyToUnchecked(SparseCompressedRowMatrixStorage<T> target)
		{
			target.Values = new T[ValueCount];
			target.ColumnIndices = new int[ValueCount];
			if (ValueCount != 0)
			{
				Array.Copy(Values, 0, target.Values, 0, ValueCount);
				Buffer.BlockCopy(ColumnIndices, 0, target.ColumnIndices, 0, ValueCount * 4);
				Buffer.BlockCopy(RowPointers, 0, target.RowPointers, 0, (RowCount + 1) * 4);
			}
		}

		private void CopyToUnchecked(DenseColumnMajorMatrixStorage<T> target, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			if (ValueCount == 0)
			{
				return;
			}
			for (int i = 0; i < RowCount; i++)
			{
				int num = RowPointers[i];
				int num2 = RowPointers[i + 1];
				for (int j = num; j < num2; j++)
				{
					target.At(i, ColumnIndices[j], Values[j]);
				}
			}
		}

		internal override void CopySubMatrixToUnchecked(MatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (target is SparseCompressedRowMatrixStorage<T> target2)
			{
				CopySubMatrixToUnchecked(target2, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, existingData);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			int num = sourceRowIndex;
			int num2 = 0;
			while (num < sourceRowIndex + rowCount)
			{
				int num3 = RowPointers[num];
				int num4 = RowPointers[num + 1];
				for (int i = num3; i < num4; i++)
				{
					if (ColumnIndices[i] >= sourceColumnIndex && ColumnIndices[i] < sourceColumnIndex + columnCount)
					{
						int num5 = ColumnIndices[i] - sourceColumnIndex;
						target.At(targetRowIndex + num2, targetColumnIndex + num5, Values[i]);
					}
				}
				num++;
				num2++;
			}
		}

		private void CopySubMatrixToUnchecked(SparseCompressedRowMatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			int num = targetRowIndex - sourceRowIndex;
			int num2 = targetColumnIndex - sourceColumnIndex;
			if (target.ValueCount == 0)
			{
				List<T> list = new List<T>(ValueCount);
				List<int> list2 = new List<int>(ValueCount);
				int[] rowPointers = target.RowPointers;
				for (int i = sourceRowIndex; i < sourceRowIndex + rowCount; i++)
				{
					rowPointers[i + num] = list.Count;
					int num3 = RowPointers[i];
					int num4 = RowPointers[i + 1];
					for (int j = num3; j < num4; j++)
					{
						if (ColumnIndices[j] >= sourceColumnIndex && ColumnIndices[j] < sourceColumnIndex + columnCount)
						{
							list.Add(Values[j]);
							list2.Add(ColumnIndices[j] + num2);
						}
					}
				}
				for (int k = targetRowIndex + rowCount; k < rowPointers.Length; k++)
				{
					rowPointers[k] = list.Count;
				}
				target.RowPointers[target.RowCount] = list.Count;
				target.Values = list.ToArray();
				target.ColumnIndices = list2.ToArray();
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			int num5 = sourceRowIndex;
			for (int l = 0; l < rowCount; l++)
			{
				int num6 = RowPointers[num5];
				int num7 = RowPointers[num5 + 1];
				for (int m = num6; m < num7; m++)
				{
					if (ColumnIndices[m] >= sourceColumnIndex && ColumnIndices[m] < sourceColumnIndex + columnCount)
					{
						int num8 = ColumnIndices[m] - sourceColumnIndex;
						target.At(targetRowIndex + l, targetColumnIndex + num8, Values[m]);
					}
				}
				num5++;
			}
		}

		internal override void CopySubRowToUnchecked(VectorStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			int num = RowPointers[rowIndex];
			int num2 = RowPointers[rowIndex + 1];
			if (num == num2)
			{
				if (existingData == ExistingData.Clear)
				{
					target.Clear(targetColumnIndex, columnCount);
				}
			}
			else if (target is SparseVectorStorage<T> sparseVectorStorage)
			{
				if (sourceColumnIndex == 0 && targetColumnIndex == 0 && columnCount == ColumnCount && ColumnCount == sparseVectorStorage.Length)
				{
					sparseVectorStorage.ValueCount = num2 - num;
					sparseVectorStorage.Values = new T[sparseVectorStorage.ValueCount];
					sparseVectorStorage.Indices = new int[sparseVectorStorage.ValueCount];
					Array.Copy(ColumnIndices, num, sparseVectorStorage.Indices, 0, sparseVectorStorage.ValueCount);
					Array.Copy(Values, num, sparseVectorStorage.Values, 0, sparseVectorStorage.ValueCount);
					return;
				}
				int num3 = Array.BinarySearch(ColumnIndices, num, num2 - num, sourceColumnIndex);
				if (num3 < 0)
				{
					num3 = ~num3;
				}
				int num4 = Array.BinarySearch(ColumnIndices, num, num2 - num, sourceColumnIndex + columnCount);
				if (num4 < 0)
				{
					num4 = ~num4;
				}
				int num5 = num4 - num3;
				if (num5 > 0)
				{
					int num6 = Array.BinarySearch(sparseVectorStorage.Indices, 0, sparseVectorStorage.ValueCount, targetColumnIndex);
					if (num6 < 0)
					{
						num6 = ~num6;
					}
					int num7 = Array.BinarySearch(sparseVectorStorage.Indices, 0, sparseVectorStorage.ValueCount, targetColumnIndex + columnCount);
					if (num7 < 0)
					{
						num7 = Math.Max(~num7, num6);
					}
					int num8 = sparseVectorStorage.ValueCount - (num7 - num6) + num5;
					T[] array = new T[num8];
					int[] array2 = new int[num8];
					Array.Copy(sparseVectorStorage.Indices, 0, array2, 0, num6);
					Array.Copy(sparseVectorStorage.Values, 0, array, 0, num6);
					int num9 = targetColumnIndex - sourceColumnIndex;
					for (int i = 0; i < num5; i++)
					{
						array2[num6 + i] = ColumnIndices[num3 + i] + num9;
					}
					Array.Copy(Values, num3, array, num6, num5);
					Array.Copy(sparseVectorStorage.Indices, num7, array2, num5 + num6, sparseVectorStorage.ValueCount - num7);
					Array.Copy(sparseVectorStorage.Values, num7, array, num5 + num6, sparseVectorStorage.ValueCount - num7);
					sparseVectorStorage.Values = array;
					sparseVectorStorage.Indices = array2;
					sparseVectorStorage.ValueCount = num8;
				}
				else if (existingData == ExistingData.Clear)
				{
					target.Clear(targetColumnIndex, columnCount);
				}
			}
			else
			{
				if (existingData == ExistingData.Clear)
				{
					target.Clear(targetColumnIndex, columnCount);
				}
				int num10 = sourceColumnIndex;
				int num11 = 0;
				while (num10 < sourceColumnIndex + columnCount)
				{
					int num12 = FindItem(rowIndex, num10);
					target.At(num11, (num12 >= 0) ? Values[num12] : MatrixStorage<T>.Zero);
					num10++;
					num11++;
				}
			}
		}

		internal override void TransposeToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			if (target is SparseCompressedRowMatrixStorage<T> target2)
			{
				TransposeToUnchecked(target2);
				return;
			}
			if (target is DenseColumnMajorMatrixStorage<T> target3)
			{
				TransposeToUnchecked(target3, existingData);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			if (ValueCount == 0)
			{
				return;
			}
			for (int i = 0; i < RowCount; i++)
			{
				int num = RowPointers[i];
				int num2 = RowPointers[i + 1];
				for (int j = num; j < num2; j++)
				{
					target.At(ColumnIndices[j], i, Values[j]);
				}
			}
		}

		private void TransposeToUnchecked(SparseCompressedRowMatrixStorage<T> target)
		{
			target.Values = new T[ValueCount];
			target.ColumnIndices = new int[ValueCount];
			T[] values = target.Values;
			int[] rowPointers = target.RowPointers;
			int[] columnIndices = target.ColumnIndices;
			int[] array = new int[ColumnCount];
			for (int i = 0; i < RowPointers[RowCount]; i++)
			{
				array[ColumnIndices[i]]++;
			}
			int num = 0;
			for (int j = 0; j < ColumnCount; j++)
			{
				rowPointers[j] = num;
				num += array[j];
				array[j] = rowPointers[j];
			}
			rowPointers[ColumnCount] = num;
			for (int k = 0; k < RowCount; k++)
			{
				for (int l = RowPointers[k]; l < RowPointers[k + 1]; l++)
				{
					int num2 = array[ColumnIndices[l]]++;
					columnIndices[num2] = k;
					values[num2] = Values[l];
				}
			}
		}

		private void TransposeToUnchecked(DenseColumnMajorMatrixStorage<T> target, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			if (ValueCount == 0)
			{
				return;
			}
			T[] data = target.Data;
			for (int i = 0; i < RowCount; i++)
			{
				int num = i * ColumnCount;
				int num2 = RowPointers[i];
				int num3 = RowPointers[i + 1];
				for (int j = num2; j < num3; j++)
				{
					data[num + ColumnIndices[j]] = Values[j];
				}
			}
		}

		internal override void TransposeSquareInplaceUnchecked()
		{
			T[] array = new T[ValueCount];
			int[] array2 = new int[RowCount + 1];
			int[] array3 = new int[ValueCount];
			int[] array4 = new int[ColumnCount];
			for (int i = 0; i < RowPointers[RowCount]; i++)
			{
				array4[ColumnIndices[i]]++;
			}
			int num = 0;
			for (int j = 0; j < ColumnCount; j++)
			{
				array2[j] = num;
				num += array4[j];
				array4[j] = array2[j];
			}
			array2[ColumnCount] = num;
			for (int k = 0; k < RowCount; k++)
			{
				for (int l = RowPointers[k]; l < RowPointers[k + 1]; l++)
				{
					int num2 = array4[ColumnIndices[l]]++;
					array3[num2] = k;
					array[num2] = Values[l];
				}
			}
			Array.Copy(array, 0, Values, 0, ValueCount);
			Buffer.BlockCopy(array3, 0, ColumnIndices, 0, ValueCount * 4);
			Buffer.BlockCopy(array2, 0, RowPointers, 0, (RowCount + 1) * 4);
		}

		public override T[] ToRowMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			if (ValueCount != 0)
			{
				for (int i = 0; i < RowCount; i++)
				{
					int num = i * ColumnCount;
					int num2 = RowPointers[i];
					int num3 = RowPointers[i + 1];
					for (int j = num2; j < num3; j++)
					{
						array[num + ColumnIndices[j]] = Values[j];
					}
				}
			}
			return array;
		}

		public override T[] ToColumnMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			if (ValueCount != 0)
			{
				for (int i = 0; i < RowCount; i++)
				{
					int num = RowPointers[i];
					int num2 = RowPointers[i + 1];
					for (int j = num; j < num2; j++)
					{
						array[ColumnIndices[j] * RowCount + i] = Values[j];
					}
				}
			}
			return array;
		}

		public override T[][] ToRowArrays()
		{
			T[][] array = new T[RowCount][];
			if (ValueCount != 0)
			{
				for (int i = 0; i < RowCount; i++)
				{
					T[] array2 = new T[ColumnCount];
					int num = RowPointers[i];
					int num2 = RowPointers[i + 1];
					for (int j = num; j < num2; j++)
					{
						array2[ColumnIndices[j]] = Values[j];
					}
					array[i] = array2;
				}
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
			if (ValueCount != 0)
			{
				for (int j = 0; j < RowCount; j++)
				{
					int num = RowPointers[j];
					int num2 = RowPointers[j + 1];
					for (int k = num; k < num2; k++)
					{
						array[ColumnIndices[k]][j] = Values[k];
					}
				}
			}
			return array;
		}

		public override T[,] ToArray()
		{
			T[,] array = new T[RowCount, ColumnCount];
			if (ValueCount != 0)
			{
				for (int i = 0; i < RowCount; i++)
				{
					int num = RowPointers[i];
					int num2 = RowPointers[i + 1];
					for (int j = num; j < num2; j++)
					{
						array[i, ColumnIndices[j]] = Values[j];
					}
				}
			}
			return array;
		}

		public override IEnumerable<T> Enumerate()
		{
			int k = 0;
			for (int row = 0; row < RowCount; row++)
			{
				for (int col = 0; col < ColumnCount; col++)
				{
					yield return (k < RowPointers[row + 1] && ColumnIndices[k] == col) ? Values[k++] : MatrixStorage<T>.Zero;
				}
			}
		}

		public override IEnumerable<(int, int, T)> EnumerateIndexed()
		{
			int k = 0;
			for (int row = 0; row < RowCount; row++)
			{
				for (int col = 0; col < ColumnCount; col++)
				{
					yield return (row, col, (k < RowPointers[row + 1] && ColumnIndices[k] == col) ? Values[k++] : MatrixStorage<T>.Zero);
				}
			}
		}

		public override IEnumerable<T> EnumerateNonZero()
		{
			return from x in Values.Take(ValueCount)
				where !MatrixStorage<T>.Zero.Equals(x)
				select x;
		}

		public override IEnumerable<(int, int, T)> EnumerateNonZeroIndexed()
		{
			for (int row = 0; row < RowCount; row++)
			{
				int num = RowPointers[row];
				int endIndex = RowPointers[row + 1];
				for (int j = num; j < endIndex; j++)
				{
					if (!MatrixStorage<T>.Zero.Equals(Values[j]))
					{
						yield return (row, ColumnIndices[j], Values[j]);
					}
				}
			}
		}

		public override Tuple<int, int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			for (int i = 0; i < RowCount; i++)
			{
				int num = RowPointers[i];
				int num2 = RowPointers[i + 1];
				for (int j = num; j < num2; j++)
				{
					if (predicate(Values[j]))
					{
						return new Tuple<int, int, T>(i, ColumnIndices[j], Values[j]);
					}
				}
			}
			if (zeros == Zeros.Include && ValueCount < RowCount * ColumnCount && predicate(MatrixStorage<T>.Zero))
			{
				int num3 = 0;
				for (int k = 0; k < RowCount; k++)
				{
					for (int l = 0; l < ColumnCount; l++)
					{
						if (num3 < RowPointers[k + 1] && ColumnIndices[num3] == l)
						{
							num3++;
							continue;
						}
						return new Tuple<int, int, T>(k, l, MatrixStorage<T>.Zero);
					}
				}
			}
			return null;
		}

		internal override Tuple<int, int, T, TOther> Find2Unchecked<TOther>(MatrixStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros)
		{
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data })
			{
				int num = 0;
				for (int i = 0; i < RowCount; i++)
				{
					for (int j = 0; j < ColumnCount; j++)
					{
						bool flag = num < RowPointers[i + 1] && ColumnIndices[num] == j;
						if (predicate(flag ? Values[num++] : MatrixStorage<T>.Zero, data[j * RowCount + i]))
						{
							return new Tuple<int, int, T, TOther>(i, j, flag ? Values[num - 1] : MatrixStorage<T>.Zero, data[j * RowCount + i]);
						}
					}
				}
				return null;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data2 })
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				if (zeros == Zeros.Include && predicate(MatrixStorage<T>.Zero, zero))
				{
					int num2 = 0;
					for (int k = 0; k < RowCount; k++)
					{
						for (int l = 0; l < ColumnCount; l++)
						{
							bool flag2 = num2 < RowPointers[k + 1] && ColumnIndices[num2] == l;
							if (predicate(flag2 ? Values[num2++] : MatrixStorage<T>.Zero, (k == l) ? data2[k] : zero))
							{
								return new Tuple<int, int, T, TOther>(k, l, flag2 ? Values[num2 - 1] : MatrixStorage<T>.Zero, (k == l) ? data2[k] : zero);
							}
						}
					}
					return null;
				}
				for (int m = 0; m < RowCount; m++)
				{
					bool flag3 = false;
					int num3 = RowPointers[m];
					int num4 = RowPointers[m + 1];
					for (int n = num3; n < num4; n++)
					{
						if (ColumnIndices[n] == m)
						{
							flag3 = true;
							if (predicate(Values[n], data2[m]))
							{
								return new Tuple<int, int, T, TOther>(m, m, Values[n], data2[m]);
							}
						}
						else if (predicate(Values[n], zero))
						{
							return new Tuple<int, int, T, TOther>(m, ColumnIndices[n], Values[n], zero);
						}
					}
					if (!flag3 && m < ColumnCount && predicate(MatrixStorage<T>.Zero, data2[m]))
					{
						return new Tuple<int, int, T, TOther>(m, m, MatrixStorage<T>.Zero, data2[m]);
					}
				}
				return null;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values })
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				if (zeros == Zeros.Include)
				{
					int num5 = 0;
					int num6 = 0;
					for (int num7 = 0; num7 < RowCount; num7++)
					{
						for (int num8 = 0; num8 < ColumnCount; num8++)
						{
							bool flag4 = num5 < RowPointers[num7 + 1] && ColumnIndices[num5] == num8;
							bool flag5 = num6 < rowPointers[num7 + 1] && columnIndices[num6] == num8;
							if (predicate(flag4 ? Values[num5++] : MatrixStorage<T>.Zero, flag5 ? values[num6++] : zero2))
							{
								return new Tuple<int, int, T, TOther>(num7, num8, flag4 ? Values[num5 - 1] : MatrixStorage<T>.Zero, flag5 ? values[num6 - 1] : zero2);
							}
						}
					}
					return null;
				}
				for (int num9 = 0; num9 < RowCount; num9++)
				{
					int num10 = RowPointers[num9 + 1];
					int num11 = rowPointers[num9 + 1];
					int num12 = RowPointers[num9];
					int num13 = rowPointers[num9];
					while (num12 < num10 || num13 < num11)
					{
						if (num12 == num10 || (num13 < num11 && ColumnIndices[num12] > columnIndices[num13]))
						{
							if (predicate(MatrixStorage<T>.Zero, values[num13++]))
							{
								return new Tuple<int, int, T, TOther>(num9, columnIndices[num13 - 1], MatrixStorage<T>.Zero, values[num13 - 1]);
							}
						}
						else if (num13 == num11 || ColumnIndices[num12] < columnIndices[num13])
						{
							if (predicate(Values[num12++], zero2))
							{
								return new Tuple<int, int, T, TOther>(num9, ColumnIndices[num12 - 1], Values[num12 - 1], zero2);
							}
						}
						else if (predicate(Values[num12++], values[num13++]))
						{
							return new Tuple<int, int, T, TOther>(num9, ColumnIndices[num12 - 1], Values[num12 - 1], values[num13 - 1]);
						}
					}
				}
				return null;
			}
			return base.Find2Unchecked(other, predicate, zeros);
		}

		public override void MapInplace(Func<T, T> f, Zeros zeros)
		{
			if (zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(MatrixStorage<T>.Zero)))
			{
				int[] rowPointers = RowPointers;
				List<int> list = new List<int>(ColumnIndices.Length);
				List<T> list2 = new List<T>(Values.Length);
				int num = 0;
				for (int i = 0; i < RowCount; i++)
				{
					rowPointers[i] = list2.Count;
					for (int j = 0; j < ColumnCount; j++)
					{
						T val = ((num < RowPointers[i + 1] && ColumnIndices[num] == j) ? f(Values[num++]) : f(MatrixStorage<T>.Zero));
						if (!MatrixStorage<T>.Zero.Equals(val))
						{
							list2.Add(val);
							list.Add(j);
						}
					}
				}
				ColumnIndices = list.ToArray();
				Values = list2.ToArray();
				rowPointers[RowCount] = list2.Count;
				return;
			}
			int num2 = 0;
			for (int k = 0; k < RowCount; k++)
			{
				int num3 = RowPointers[k];
				int num4 = RowPointers[k + 1];
				RowPointers[k] = num2;
				for (int l = num3; l < num4; l++)
				{
					T val2 = f(Values[l]);
					if (!MatrixStorage<T>.Zero.Equals(val2))
					{
						Values[num2] = val2;
						ColumnIndices[num2] = ColumnIndices[l];
						num2++;
					}
				}
			}
			Array.Resize(ref ColumnIndices, num2);
			Array.Resize(ref Values, num2);
			RowPointers[RowCount] = num2;
		}

		public override void MapIndexedInplace(Func<int, int, T, T> f, Zeros zeros)
		{
			if (zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero)))
			{
				int[] rowPointers = RowPointers;
				List<int> list = new List<int>(ColumnIndices.Length);
				List<T> list2 = new List<T>(Values.Length);
				int num = 0;
				for (int i = 0; i < RowCount; i++)
				{
					rowPointers[i] = list2.Count;
					for (int j = 0; j < ColumnCount; j++)
					{
						T val = ((num < RowPointers[i + 1] && ColumnIndices[num] == j) ? f(i, j, Values[num++]) : f(i, j, MatrixStorage<T>.Zero));
						if (!MatrixStorage<T>.Zero.Equals(val))
						{
							list2.Add(val);
							list.Add(j);
						}
					}
				}
				ColumnIndices = list.ToArray();
				Values = list2.ToArray();
				rowPointers[RowCount] = list2.Count;
				return;
			}
			int num2 = 0;
			for (int k = 0; k < RowCount; k++)
			{
				int num3 = RowPointers[k];
				int num4 = RowPointers[k + 1];
				RowPointers[k] = num2;
				for (int l = num3; l < num4; l++)
				{
					T val2 = f(k, ColumnIndices[l], Values[l]);
					if (!MatrixStorage<T>.Zero.Equals(val2))
					{
						Values[num2] = val2;
						ColumnIndices[num2] = ColumnIndices[l];
						num2++;
					}
				}
			}
			Array.Resize(ref ColumnIndices, num2);
			Array.Resize(ref Values, num2);
			RowPointers[RowCount] = num2;
		}

		internal override void MapToUnchecked<TU>(MatrixStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData)
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(MatrixStorage<T>.Zero));
			if (target is SparseCompressedRowMatrixStorage<TU> { RowPointers: var rowPointers } sparseCompressedRowMatrixStorage)
			{
				List<int> list = new List<int>(ColumnIndices.Length);
				List<TU> list2 = new List<TU>(Values.Length);
				if (flag)
				{
					int num = 0;
					for (int i = 0; i < RowCount; i++)
					{
						rowPointers[i] = list2.Count;
						for (int j = 0; j < ColumnCount; j++)
						{
							TU val = ((num < RowPointers[i + 1] && ColumnIndices[num] == j) ? f(Values[num++]) : f(MatrixStorage<T>.Zero));
							if (!MatrixStorage<T>.Zero.Equals(val))
							{
								list2.Add(val);
								list.Add(j);
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < RowCount; k++)
					{
						rowPointers[k] = list2.Count;
						int num2 = RowPointers[k];
						int num3 = RowPointers[k + 1];
						for (int l = num2; l < num3; l++)
						{
							TU val2 = f(Values[l]);
							if (!MatrixStorage<T>.Zero.Equals(val2))
							{
								list2.Add(val2);
								list.Add(ColumnIndices[l]);
							}
						}
					}
				}
				sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
				sparseCompressedRowMatrixStorage.Values = list2.ToArray();
				rowPointers[RowCount] = list2.Count;
				return;
			}
			if (existingData == ExistingData.Clear && !flag)
			{
				target.Clear();
			}
			if (flag)
			{
				for (int m = 0; m < RowCount; m++)
				{
					int num4 = RowPointers[m];
					int num5 = RowPointers[m + 1];
					for (int n = 0; n < ColumnCount; n++)
					{
						if (num4 < num5 && n == ColumnIndices[num4])
						{
							target.At(m, n, f(Values[num4]));
							num4 = Math.Min(num4 + 1, num5);
						}
						else
						{
							target.At(m, n, f(MatrixStorage<T>.Zero));
						}
					}
				}
				return;
			}
			for (int num6 = 0; num6 < RowCount; num6++)
			{
				int num7 = RowPointers[num6];
				int num8 = RowPointers[num6 + 1];
				for (int num9 = num7; num9 < num8; num9++)
				{
					target.At(num6, ColumnIndices[num9], f(Values[num9]));
				}
			}
		}

		internal override void MapIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, Zeros zeros, ExistingData existingData)
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero));
			if (target is SparseCompressedRowMatrixStorage<TU> { RowPointers: var rowPointers } sparseCompressedRowMatrixStorage)
			{
				List<int> list = new List<int>(ColumnIndices.Length);
				List<TU> list2 = new List<TU>(Values.Length);
				if (flag)
				{
					int num = 0;
					for (int i = 0; i < RowCount; i++)
					{
						rowPointers[i] = list2.Count;
						for (int j = 0; j < ColumnCount; j++)
						{
							TU val = ((num < RowPointers[i + 1] && ColumnIndices[num] == j) ? f(i, j, Values[num++]) : f(i, j, MatrixStorage<T>.Zero));
							if (!MatrixStorage<T>.Zero.Equals(val))
							{
								list2.Add(val);
								list.Add(j);
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < RowCount; k++)
					{
						rowPointers[k] = list2.Count;
						int num2 = RowPointers[k];
						int num3 = RowPointers[k + 1];
						for (int l = num2; l < num3; l++)
						{
							TU val2 = f(k, ColumnIndices[l], Values[l]);
							if (!MatrixStorage<T>.Zero.Equals(val2))
							{
								list2.Add(val2);
								list.Add(ColumnIndices[l]);
							}
						}
					}
				}
				sparseCompressedRowMatrixStorage.ColumnIndices = list.ToArray();
				sparseCompressedRowMatrixStorage.Values = list2.ToArray();
				rowPointers[RowCount] = list2.Count;
				return;
			}
			if (existingData == ExistingData.Clear && !flag)
			{
				target.Clear();
			}
			if (flag)
			{
				for (int m = 0; m < RowCount; m++)
				{
					int num4 = RowPointers[m];
					int num5 = RowPointers[m + 1];
					for (int n = 0; n < ColumnCount; n++)
					{
						if (num4 < num5 && n == ColumnIndices[num4])
						{
							target.At(m, n, f(m, n, Values[num4]));
							num4 = Math.Min(num4 + 1, num5);
						}
						else
						{
							target.At(m, n, f(m, n, MatrixStorage<T>.Zero));
						}
					}
				}
				return;
			}
			for (int num6 = 0; num6 < RowCount; num6++)
			{
				int num7 = RowPointers[num6];
				int num8 = RowPointers[num6 + 1];
				for (int num9 = num7; num9 < num8; num9++)
				{
					target.At(num6, ColumnIndices[num9], f(num6, ColumnIndices[num9], Values[num9]));
				}
			}
		}

		internal override void MapSubMatrixIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData)
		{
			if (target is SparseCompressedRowMatrixStorage<TU> target2)
			{
				MapSubMatrixIndexedToUnchecked(target2, f, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, zeros, existingData);
				return;
			}
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero));
			if (existingData == ExistingData.Clear && !flag)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			if (flag)
			{
				int num = sourceRowIndex;
				int num2 = targetRowIndex;
				while (num < sourceRowIndex + rowCount)
				{
					int i = RowPointers[num];
					int num3;
					for (num3 = RowPointers[num + 1]; ColumnIndices[i] < sourceColumnIndex && i < num3; i++)
					{
					}
					int num4 = sourceColumnIndex;
					int num5 = targetColumnIndex;
					while (num4 < sourceColumnIndex + columnCount)
					{
						if (i < num3 && num4 == ColumnIndices[i])
						{
							target.At(num2, num5, f(num2, num5, Values[i]));
							i = Math.Min(i + 1, num3);
						}
						else
						{
							target.At(num2, num5, f(num2, num5, MatrixStorage<T>.Zero));
						}
						num4++;
						num5++;
					}
					num++;
					num2++;
				}
				return;
			}
			int num6 = targetColumnIndex - sourceColumnIndex;
			int num7 = sourceRowIndex;
			int num8 = targetRowIndex;
			while (num7 < sourceRowIndex + rowCount)
			{
				int num9 = RowPointers[num7];
				int num10 = RowPointers[num7 + 1];
				for (int j = num9; j < num10; j++)
				{
					if (ColumnIndices[j] >= sourceColumnIndex && ColumnIndices[j] < sourceColumnIndex + columnCount)
					{
						int num11 = ColumnIndices[j] + num6;
						target.At(num8, num11, f(num8, num11, Values[j]));
					}
				}
				num7++;
				num8++;
			}
		}

		private void MapSubMatrixIndexedToUnchecked<TU>(SparseCompressedRowMatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			bool flag = zeros == Zeros.Include || !MatrixStorage<T>.Zero.Equals(f(0, 1, MatrixStorage<T>.Zero));
			if (existingData == ExistingData.Clear && !flag)
			{
				target.ClearUnchecked(targetRowIndex, rowCount, targetColumnIndex, columnCount);
			}
			int num = targetRowIndex - sourceRowIndex;
			int num2 = targetColumnIndex - sourceColumnIndex;
			TU zero = Matrix<TU>.Zero;
			if (target.ValueCount == 0)
			{
				List<TU> list = new List<TU>(ValueCount);
				List<int> list2 = new List<int>(ValueCount);
				int[] rowPointers = target.RowPointers;
				if (flag)
				{
					for (int i = sourceRowIndex; i < sourceRowIndex + rowCount; i++)
					{
						int num3 = i + num;
						rowPointers[num3] = list.Count;
						int j = RowPointers[i];
						int num4;
						for (num4 = RowPointers[i + 1]; ColumnIndices[j] < sourceColumnIndex && j < num4; j++)
						{
						}
						int num5 = sourceColumnIndex;
						int num6 = targetColumnIndex;
						while (num5 < sourceColumnIndex + columnCount)
						{
							if (j < num4 && num5 == ColumnIndices[j])
							{
								TU val = f(num3, num6, Values[j]);
								if (!zero.Equals(val))
								{
									list.Add(val);
									list2.Add(num6);
								}
								j = Math.Min(j + 1, num4);
							}
							else
							{
								TU val2 = f(num3, num6, MatrixStorage<T>.Zero);
								if (!zero.Equals(val2))
								{
									list.Add(val2);
									list2.Add(num6);
								}
							}
							num5++;
							num6++;
						}
					}
				}
				else
				{
					for (int k = sourceRowIndex; k < sourceRowIndex + rowCount; k++)
					{
						int num7 = k + num;
						rowPointers[num7] = list.Count;
						int num8 = RowPointers[k];
						int num9 = RowPointers[k + 1];
						for (int l = num8; l < num9; l++)
						{
							if (ColumnIndices[l] >= sourceColumnIndex && ColumnIndices[l] < sourceColumnIndex + columnCount)
							{
								int num10 = ColumnIndices[l] + num2;
								TU val3 = f(num7, num10, Values[l]);
								if (!zero.Equals(val3))
								{
									list.Add(val3);
									list2.Add(num10);
								}
							}
						}
					}
				}
				for (int m = targetRowIndex + rowCount; m < rowPointers.Length; m++)
				{
					rowPointers[m] = list.Count;
				}
				target.RowPointers[target.RowCount] = list.Count;
				target.Values = list.ToArray();
				target.ColumnIndices = list2.ToArray();
				return;
			}
			if (flag)
			{
				int num11 = sourceRowIndex;
				int num12 = targetRowIndex;
				while (num11 < sourceRowIndex + rowCount)
				{
					int n = RowPointers[num11];
					int num13;
					for (num13 = RowPointers[num11 + 1]; ColumnIndices[n] < sourceColumnIndex && n < num13; n++)
					{
					}
					int num14 = sourceColumnIndex;
					int num15 = targetColumnIndex;
					while (num14 < sourceColumnIndex + columnCount)
					{
						if (n < num13 && num14 == ColumnIndices[n])
						{
							target.At(num12, num15, f(num12, num15, Values[n]));
							n = Math.Min(n + 1, num13);
						}
						else
						{
							target.At(num12, num15, f(num12, num15, MatrixStorage<T>.Zero));
						}
						num14++;
						num15++;
					}
					num11++;
					num12++;
				}
				return;
			}
			int num16 = sourceRowIndex;
			int num17 = targetRowIndex;
			while (num16 < sourceRowIndex + rowCount)
			{
				int num18 = RowPointers[num16];
				int num19 = RowPointers[num16 + 1];
				for (int num20 = num18; num20 < num19; num20++)
				{
					if (ColumnIndices[num20] >= sourceColumnIndex && ColumnIndices[num20] < sourceColumnIndex + columnCount)
					{
						int num21 = ColumnIndices[num20] + num2;
						target.At(num17, num21, f(num17, num21, Values[num20]));
					}
				}
				num16++;
				num17++;
			}
		}

		internal override void FoldByRowUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				for (int i = 0; i < RowCount; i++)
				{
					int num = RowPointers[i];
					int num2 = RowPointers[i + 1];
					TU arg = state[i];
					for (int j = num; j < num2; j++)
					{
						arg = f(arg, Values[j]);
					}
					target[i] = finalize(arg, num2 - num);
				}
				return;
			}
			for (int k = 0; k < RowCount; k++)
			{
				int num3 = RowPointers[k];
				int num4 = RowPointers[k + 1];
				TU arg2 = state[k];
				for (int l = 0; l < ColumnCount; l++)
				{
					if (num3 < num4 && l == ColumnIndices[num3])
					{
						arg2 = f(arg2, Values[num3]);
						num3 = Math.Min(num3 + 1, num4);
					}
					else
					{
						arg2 = f(arg2, MatrixStorage<T>.Zero);
					}
				}
				target[k] = finalize(arg2, ColumnCount);
			}
		}

		internal override void FoldByColumnUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (state != target)
			{
				Array.Copy(state, 0, target, 0, state.Length);
			}
			if (zeros == Zeros.AllowSkip)
			{
				int[] array = new int[ColumnCount];
				for (int i = 0; i < RowCount; i++)
				{
					int num = RowPointers[i];
					int num2 = RowPointers[i + 1];
					for (int j = num; j < num2; j++)
					{
						int num3 = ColumnIndices[j];
						target[num3] = f(target[num3], Values[j]);
						array[num3]++;
					}
				}
				for (int k = 0; k < ColumnCount; k++)
				{
					target[k] = finalize(target[k], array[k]);
				}
				return;
			}
			for (int l = 0; l < RowCount; l++)
			{
				int num4 = RowPointers[l];
				int num5 = RowPointers[l + 1];
				for (int m = 0; m < ColumnCount; m++)
				{
					if (num4 < num5 && m == ColumnIndices[num4])
					{
						target[m] = f(target[m], Values[num4]);
						num4 = Math.Min(num4 + 1, num5);
					}
					else
					{
						target[m] = f(target[m], MatrixStorage<T>.Zero);
					}
				}
			}
			for (int n = 0; n < ColumnCount; n++)
			{
				target[n] = finalize(target[n], RowCount);
			}
		}

		internal override TState Fold2Unchecked<TOther, TState>(MatrixStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros)
		{
			if (other is DenseColumnMajorMatrixStorage<TOther> { Data: var data })
			{
				int num = 0;
				for (int i = 0; i < RowCount; i++)
				{
					for (int j = 0; j < ColumnCount; j++)
					{
						bool flag = num < RowPointers[i + 1] && ColumnIndices[num] == j;
						state = f(state, flag ? Values[num++] : MatrixStorage<T>.Zero, data[j * RowCount + i]);
					}
				}
				return state;
			}
			if (other is DiagonalMatrixStorage<TOther> { Data: var data2 })
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				if (zeros == Zeros.Include)
				{
					int num2 = 0;
					for (int k = 0; k < RowCount; k++)
					{
						for (int l = 0; l < ColumnCount; l++)
						{
							bool flag2 = num2 < RowPointers[k + 1] && ColumnIndices[num2] == l;
							state = f(state, flag2 ? Values[num2++] : MatrixStorage<T>.Zero, (k == l) ? data2[k] : zero);
						}
					}
					return state;
				}
				for (int m = 0; m < RowCount; m++)
				{
					bool flag3 = false;
					int num3 = RowPointers[m];
					int num4 = RowPointers[m + 1];
					for (int n = num3; n < num4; n++)
					{
						if (ColumnIndices[n] == m)
						{
							flag3 = true;
							state = f(state, Values[n], data2[m]);
						}
						else
						{
							state = f(state, Values[n], zero);
						}
					}
					if (!flag3 && m < ColumnCount)
					{
						state = f(state, MatrixStorage<T>.Zero, data2[m]);
					}
				}
				return state;
			}
			if (other is SparseCompressedRowMatrixStorage<TOther> { RowPointers: var rowPointers, ColumnIndices: var columnIndices, Values: var values })
			{
				TOther zero2 = BuilderInstance<TOther>.Matrix.Zero;
				if (zeros == Zeros.Include)
				{
					int num5 = 0;
					int num6 = 0;
					for (int num7 = 0; num7 < RowCount; num7++)
					{
						for (int num8 = 0; num8 < ColumnCount; num8++)
						{
							bool flag4 = num5 < RowPointers[num7 + 1] && ColumnIndices[num5] == num8;
							bool flag5 = num6 < rowPointers[num7 + 1] && columnIndices[num6] == num8;
							state = f(state, flag4 ? Values[num5++] : MatrixStorage<T>.Zero, flag5 ? values[num6++] : zero2);
						}
					}
					return state;
				}
				for (int num9 = 0; num9 < RowCount; num9++)
				{
					int num10 = RowPointers[num9];
					int num11 = RowPointers[num9 + 1];
					int num12 = rowPointers[num9];
					int num13 = rowPointers[num9 + 1];
					int num14 = num10;
					int num15 = num12;
					while (num14 < num11 || num15 < num13)
					{
						state = ((num14 != num11 && (num15 >= num13 || ColumnIndices[num14] <= columnIndices[num15])) ? ((num15 != num13 && ColumnIndices[num14] >= columnIndices[num15]) ? f(state, Values[num14++], values[num15++]) : f(state, Values[num14++], zero2)) : f(state, MatrixStorage<T>.Zero, values[num15++]));
					}
				}
				return state;
			}
			return base.Fold2Unchecked(other, f, state, zeros);
		}
	}
}
