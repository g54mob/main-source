using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public class SparseVectorStorage<T> : VectorStorage<T> where T : struct, IEquatable<T>, IFormattable
	{
		[DataMember(Order = 1)]
		public int[] Indices;

		[DataMember(Order = 2)]
		public T[] Values;

		[DataMember(Order = 3)]
		public int ValueCount;

		public override bool IsDense => false;

		internal SparseVectorStorage(int length)
			: base(length)
		{
			Indices = Array.Empty<int>();
			Values = Array.Empty<T>();
			ValueCount = 0;
		}

		public override T At(int index)
		{
			int num = Array.BinarySearch(Indices, 0, ValueCount, index);
			if (num < 0)
			{
				return VectorStorage<T>.Zero;
			}
			return Values[num];
		}

		public override void At(int index, T value)
		{
			int num = Array.BinarySearch(Indices, 0, ValueCount, index);
			if (num >= 0)
			{
				if (VectorStorage<T>.Zero.Equals(value))
				{
					RemoveAtIndexUnchecked(num);
				}
				else
				{
					Values[num] = value;
				}
			}
			else if (!VectorStorage<T>.Zero.Equals(value))
			{
				InsertAtIndexUnchecked(~num, index, value);
			}
		}

		internal void InsertAtIndexUnchecked(int itemIndex, int index, T value)
		{
			if (ValueCount == Values.Length && ValueCount < Length)
			{
				int newSize = Math.Min(Values.Length + GrowthSize(), Length);
				Array.Resize(ref Values, newSize);
				Array.Resize(ref Indices, newSize);
			}
			Array.Copy(Values, itemIndex, Values, itemIndex + 1, ValueCount - itemIndex);
			Array.Copy(Indices, itemIndex, Indices, itemIndex + 1, ValueCount - itemIndex);
			Values[itemIndex] = value;
			Indices[itemIndex] = index;
			ValueCount++;
		}

		internal void RemoveAtIndexUnchecked(int itemIndex)
		{
			Array.Copy(Values, itemIndex + 1, Values, itemIndex, ValueCount - itemIndex - 1);
			Array.Copy(Indices, itemIndex + 1, Indices, itemIndex, ValueCount - itemIndex - 1);
			ValueCount--;
			if (ValueCount > 1024 && ValueCount < Indices.Length / 2)
			{
				Array.Resize(ref Values, ValueCount);
				Array.Resize(ref Indices, ValueCount);
			}
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

		public override bool Equals(VectorStorage<T> other)
		{
			if (other == null || Length != other.Length)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (other is SparseVectorStorage<T> { Indices: var indices, Values: var values } sparseVectorStorage)
			{
				int num = 0;
				int num2 = 0;
				while (num < ValueCount || num2 < sparseVectorStorage.ValueCount)
				{
					if (num2 >= sparseVectorStorage.ValueCount || (num < ValueCount && Indices[num] < indices[num2]))
					{
						if (!VectorStorage<T>.Zero.Equals(Values[num++]))
						{
							return false;
						}
						continue;
					}
					if (num >= ValueCount || (num2 < sparseVectorStorage.ValueCount && indices[num2] < Indices[num]))
					{
						if (!VectorStorage<T>.Zero.Equals(values[num2++]))
						{
							return false;
						}
						continue;
					}
					if (!Values[num].Equals(values[num2]))
					{
						return false;
					}
					num++;
					num2++;
				}
				return true;
			}
			return base.Equals(other);
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
			ValueCount = 0;
		}

		public override void Clear(int index, int count)
		{
			if (index == 0 && count == Length)
			{
				Clear();
				return;
			}
			int num = Array.BinarySearch(Indices, 0, ValueCount, index);
			int num2 = Array.BinarySearch(Indices, 0, ValueCount, index + count - 1);
			if (num < 0)
			{
				num = ~num;
			}
			if (num2 < 0)
			{
				num2 = ~num2 - 1;
			}
			int num3 = num2 - num + 1;
			if (num3 > 0)
			{
				Array.Copy(Values, num + num3, Values, num, ValueCount - num - num3);
				Array.Copy(Indices, num + num3, Indices, num, ValueCount - num - num3);
				ValueCount -= num3;
			}
			if (ValueCount > 1024 && ValueCount < Indices.Length / 2)
			{
				Array.Resize(ref Values, ValueCount);
				Array.Resize(ref Indices, ValueCount);
			}
		}

		public static SparseVectorStorage<T> OfVector(VectorStorage<T> vector)
		{
			SparseVectorStorage<T> sparseVectorStorage = new SparseVectorStorage<T>(vector.Length);
			vector.CopyToUnchecked(sparseVectorStorage, ExistingData.AssumeZeros);
			return sparseVectorStorage;
		}

		public static SparseVectorStorage<T> OfValue(int length, T value)
		{
			if (VectorStorage<T>.Zero.Equals(value))
			{
				return new SparseVectorStorage<T>(length);
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Value must not be negative (zero is ok).");
			}
			int[] array = new int[length];
			T[] array2 = new T[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = i;
				array2[i] = value;
			}
			return new SparseVectorStorage<T>(length)
			{
				Indices = array,
				Values = array2,
				ValueCount = length
			};
		}

		public static SparseVectorStorage<T> OfInit(int length, Func<int, T> init)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Value must not be negative (zero is ok).");
			}
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			for (int i = 0; i < length; i++)
			{
				T val = init(i);
				if (!VectorStorage<T>.Zero.Equals(val))
				{
					list2.Add(val);
					list.Add(i);
				}
			}
			return new SparseVectorStorage<T>(length)
			{
				Indices = list.ToArray(),
				Values = list2.ToArray(),
				ValueCount = list2.Count
			};
		}

		public static SparseVectorStorage<T> OfEnumerable(IEnumerable<T> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			int num = 0;
			foreach (T datum in data)
			{
				if (!VectorStorage<T>.Zero.Equals(datum))
				{
					list2.Add(datum);
					list.Add(num);
				}
				num++;
			}
			return new SparseVectorStorage<T>(num)
			{
				Indices = list.ToArray(),
				Values = list2.ToArray(),
				ValueCount = list2.Count
			};
		}

		public static SparseVectorStorage<T> OfIndexedEnumerable(int length, IEnumerable<Tuple<int, T>> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			foreach (Tuple<int, T> datum in data)
			{
				datum.Deconstruct(out var item, out var item2);
				int item3 = item;
				T val = item2;
				item2 = VectorStorage<T>.Zero;
				if (!item2.Equals(val))
				{
					list2.Add(val);
					list.Add(item3);
				}
			}
			int[] array = list.ToArray();
			T[] array2 = list2.ToArray();
			Sorting.Sort(array, array2);
			return new SparseVectorStorage<T>(length)
			{
				Indices = array,
				Values = array2,
				ValueCount = list2.Count
			};
		}

		public static SparseVectorStorage<T> OfIndexedEnumerable(int length, IEnumerable<(int, T)> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			List<int> list = new List<int>();
			List<T> list2 = new List<T>();
			foreach (var (item, val) in data)
			{
				if (!VectorStorage<T>.Zero.Equals(val))
				{
					list2.Add(val);
					list.Add(item);
				}
			}
			int[] array = list.ToArray();
			T[] array2 = list2.ToArray();
			Sorting.Sort(array, array2);
			return new SparseVectorStorage<T>(length)
			{
				Indices = array,
				Values = array2,
				ValueCount = list2.Count
			};
		}

		internal override void CopyToUnchecked(VectorStorage<T> target, ExistingData existingData)
		{
			if (target is SparseVectorStorage<T> target2)
			{
				CopyToUnchecked(target2);
				return;
			}
			if (existingData == ExistingData.Clear)
			{
				target.Clear();
			}
			if (ValueCount != 0)
			{
				for (int i = 0; i < ValueCount; i++)
				{
					target.At(Indices[i], Values[i]);
				}
			}
		}

		private void CopyToUnchecked(SparseVectorStorage<T> target)
		{
			if (this != target)
			{
				if (Length != target.Length)
				{
					throw new ArgumentException($"Matrix dimensions must agree: op1 is {Length}, op2 is {target.Length}.", "target");
				}
				target.ValueCount = ValueCount;
				target.Values = new T[ValueCount];
				target.Indices = new int[ValueCount];
				if (ValueCount != 0)
				{
					Array.Copy(Values, 0, target.Values, 0, ValueCount);
					Buffer.BlockCopy(Indices, 0, target.Indices, 0, ValueCount * 4);
				}
			}
		}

		internal override void CopyToRowUnchecked(MatrixStorage<T> target, int rowIndex, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(rowIndex, 1, 0, Length);
			}
			if (ValueCount != 0)
			{
				for (int i = 0; i < ValueCount; i++)
				{
					target.At(rowIndex, Indices[i], Values[i]);
				}
			}
		}

		internal override void CopyToColumnUnchecked(MatrixStorage<T> target, int columnIndex, ExistingData existingData)
		{
			if (existingData == ExistingData.Clear)
			{
				target.ClearUnchecked(0, Length, columnIndex, 1);
			}
			if (ValueCount != 0)
			{
				for (int i = 0; i < ValueCount; i++)
				{
					target.At(Indices[i], columnIndex, Values[i]);
				}
			}
		}

		internal override void CopySubVectorToUnchecked(VectorStorage<T> target, int sourceIndex, int targetIndex, int count, ExistingData existingData)
		{
			if (target is SparseVectorStorage<T> target2)
			{
				CopySubVectorToUnchecked(target2, sourceIndex, targetIndex, count, existingData);
				return;
			}
			int num = targetIndex - sourceIndex;
			int num2 = Array.BinarySearch(Indices, 0, ValueCount, sourceIndex);
			int num3 = Array.BinarySearch(Indices, 0, ValueCount, sourceIndex + count - 1);
			if (num2 < 0)
			{
				num2 = ~num2;
			}
			if (num3 < 0)
			{
				num3 = ~num3 - 1;
			}
			if (existingData == ExistingData.Clear)
			{
				target.Clear(targetIndex, count);
			}
			for (int i = num2; i <= num3; i++)
			{
				target.At(Indices[i] + num, Values[i]);
			}
		}

		private void CopySubVectorToUnchecked(SparseVectorStorage<T> target, int sourceIndex, int targetIndex, int count, ExistingData existingData)
		{
			int num = targetIndex - sourceIndex;
			int num2 = Array.BinarySearch(Indices, 0, ValueCount, sourceIndex);
			int num3 = Array.BinarySearch(Indices, 0, ValueCount, sourceIndex + count - 1);
			if (num2 < 0)
			{
				num2 = ~num2;
			}
			if (num3 < 0)
			{
				num3 = ~num3 - 1;
			}
			int num4 = num3 - num2 + 1;
			if (this == target)
			{
				T[] array = new T[num4];
				int[] array2 = new int[num4];
				Array.Copy(Values, num2, array, 0, num4);
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = Indices[i + num2];
				}
				if (existingData == ExistingData.Clear)
				{
					Clear(targetIndex, count);
				}
				for (int j = num2; j <= num3; j++)
				{
					At(array2[j] + num, array[j]);
				}
			}
			else if (target.ValueCount == 0)
			{
				T[] array3 = new T[num4];
				int[] array4 = new int[num4];
				Array.Copy(Values, num2, array3, 0, num4);
				for (int k = 0; k < array4.Length; k++)
				{
					array4[k] = Indices[k + num2] + num;
				}
				target.ValueCount = num4;
				target.Values = array3;
				target.Indices = array4;
			}
			else
			{
				if (existingData == ExistingData.Clear)
				{
					target.Clear(targetIndex, count);
				}
				for (int l = num2; l <= num3; l++)
				{
					target.At(Indices[l] + num, Values[l]);
				}
			}
		}

		public override T[] ToArray()
		{
			T[] array = new T[Length];
			for (int i = 0; i < ValueCount; i++)
			{
				array[Indices[i]] = Values[i];
			}
			return array;
		}

		public override IEnumerable<T> Enumerate()
		{
			int k = 0;
			for (int i = 0; i < Length; i++)
			{
				yield return (k < ValueCount && Indices[k] == i) ? Values[k++] : VectorStorage<T>.Zero;
			}
		}

		public override IEnumerable<(int, T)> EnumerateIndexed()
		{
			int k = 0;
			for (int i = 0; i < Length; i++)
			{
				yield return (i, (k < ValueCount && Indices[k] == i) ? Values[k++] : VectorStorage<T>.Zero);
			}
		}

		public override IEnumerable<T> EnumerateNonZero()
		{
			return from x in Values.Take(ValueCount)
				where !VectorStorage<T>.Zero.Equals(x)
				select x;
		}

		public override IEnumerable<(int, T)> EnumerateNonZeroIndexed()
		{
			for (int i = 0; i < ValueCount; i++)
			{
				if (!VectorStorage<T>.Zero.Equals(Values[i]))
				{
					yield return (Indices[i], Values[i]);
				}
			}
		}

		public override Tuple<int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			for (int i = 0; i < ValueCount; i++)
			{
				if (predicate(Values[i]))
				{
					return new Tuple<int, T>(Indices[i], Values[i]);
				}
			}
			if (zeros == Zeros.Include && ValueCount < Length && predicate(VectorStorage<T>.Zero))
			{
				for (int j = 0; j < Length; j++)
				{
					if (j >= ValueCount || Indices[j] != j)
					{
						return new Tuple<int, T>(j, VectorStorage<T>.Zero);
					}
				}
			}
			return null;
		}

		internal override Tuple<int, T, TOther> Find2Unchecked<TOther>(VectorStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros)
		{
			if (other is DenseVectorStorage<TOther> { Data: var data })
			{
				int num = 0;
				for (int i = 0; i < data.Length; i++)
				{
					if (num < ValueCount && Indices[num] == i)
					{
						if (predicate(Values[num], data[i]))
						{
							return new Tuple<int, T, TOther>(i, Values[num], data[i]);
						}
						num++;
					}
					else if (predicate(VectorStorage<T>.Zero, data[i]))
					{
						return new Tuple<int, T, TOther>(i, VectorStorage<T>.Zero, data[i]);
					}
				}
				return null;
			}
			if (other is SparseVectorStorage<TOther> { Indices: var indices, Values: var values, ValueCount: var valueCount } sparseVectorStorage)
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				int num2 = 0;
				int num3 = 0;
				if (zeros == Zeros.Include && ValueCount < Length && sparseVectorStorage.ValueCount < Length && predicate(VectorStorage<T>.Zero, zero))
				{
					for (int j = 0; j < Length; j++)
					{
						T val = ((num2 < ValueCount && Indices[num2] == j) ? Values[num2++] : VectorStorage<T>.Zero);
						TOther val2 = ((num3 < valueCount && indices[num3] == j) ? values[num3++] : zero);
						if (predicate(val, val2))
						{
							return new Tuple<int, T, TOther>(j, val, val2);
						}
					}
					return null;
				}
				num2 = 0;
				num3 = 0;
				while (num2 < ValueCount || num3 < valueCount)
				{
					if (num2 == ValueCount || (num3 < valueCount && Indices[num2] > indices[num3]))
					{
						if (predicate(VectorStorage<T>.Zero, values[num3++]))
						{
							return new Tuple<int, T, TOther>(indices[num3 - 1], VectorStorage<T>.Zero, values[num3 - 1]);
						}
					}
					else if (num3 == valueCount || Indices[num2] < indices[num3])
					{
						if (predicate(Values[num2++], zero))
						{
							return new Tuple<int, T, TOther>(Indices[num2 - 1], Values[num2 - 1], zero);
						}
					}
					else if (predicate(Values[num2++], values[num3++]))
					{
						return new Tuple<int, T, TOther>(Indices[num2 - 1], Values[num2 - 1], values[num3 - 1]);
					}
				}
				return null;
			}
			return base.Find2Unchecked(other, predicate, zeros);
		}

		public override void MapInplace(Func<T, T> f, Zeros zeros)
		{
			List<int> list = new List<int>();
			List<T> list2 = new List<T>(ValueCount);
			if (zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(VectorStorage<T>.Zero)))
			{
				int num = 0;
				for (int i = 0; i < Length; i++)
				{
					T val = ((num < ValueCount && Indices[num] == i) ? f(Values[num++]) : f(VectorStorage<T>.Zero));
					if (!VectorStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < ValueCount; j++)
				{
					T val2 = f(Values[j]);
					if (!VectorStorage<T>.Zero.Equals(val2))
					{
						list2.Add(val2);
						list.Add(Indices[j]);
					}
				}
			}
			Indices = list.ToArray();
			Values = list2.ToArray();
			ValueCount = list2.Count;
		}

		public override void MapIndexedInplace(Func<int, T, T> f, Zeros zeros)
		{
			List<int> list = new List<int>();
			List<T> list2 = new List<T>(ValueCount);
			if (zeros == Zeros.Include)
			{
				int num = 0;
				for (int i = 0; i < Length; i++)
				{
					T val = ((num < ValueCount && Indices[num] == i) ? f(i, Values[num++]) : f(i, VectorStorage<T>.Zero));
					if (!VectorStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < ValueCount; j++)
				{
					T val2 = f(Indices[j], Values[j]);
					if (!VectorStorage<T>.Zero.Equals(val2))
					{
						list2.Add(val2);
						list.Add(Indices[j]);
					}
				}
			}
			Indices = list.ToArray();
			Values = list2.ToArray();
			ValueCount = list2.Count;
		}

		internal override void MapToUnchecked<TU>(VectorStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData)
		{
			if (target is SparseVectorStorage<TU> sparseVectorStorage)
			{
				List<int> list = new List<int>();
				List<TU> list2 = new List<TU>();
				if (zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(VectorStorage<T>.Zero)))
				{
					int num = 0;
					for (int i = 0; i < Length; i++)
					{
						TU val = ((num < ValueCount && Indices[num] == i) ? f(Values[num++]) : f(VectorStorage<T>.Zero));
						if (!VectorStorage<T>.Zero.Equals(val))
						{
							list2.Add(val);
							list.Add(i);
						}
					}
				}
				else
				{
					for (int j = 0; j < ValueCount; j++)
					{
						TU val2 = f(Values[j]);
						if (!VectorStorage<T>.Zero.Equals(val2))
						{
							list2.Add(val2);
							list.Add(Indices[j]);
						}
					}
				}
				sparseVectorStorage.Indices = list.ToArray();
				sparseVectorStorage.Values = list2.ToArray();
				sparseVectorStorage.ValueCount = list2.Count;
			}
			else if (target is DenseVectorStorage<TU> denseVectorStorage)
			{
				if (existingData == ExistingData.Clear)
				{
					denseVectorStorage.Clear();
				}
				TU[] denseTargetData = denseVectorStorage.Data;
				if (zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(VectorStorage<T>.Zero)))
				{
					int num2 = 0;
					for (int k = 0; k < Length; k++)
					{
						denseTargetData[k] = ((num2 < ValueCount && Indices[num2] == k) ? f(Values[num2++]) : f(VectorStorage<T>.Zero));
					}
					return;
				}
				CommonParallel.For(0, ValueCount, 4096, delegate(int a, int b)
				{
					for (int l = a; l < b; l++)
					{
						denseTargetData[Indices[l]] = f(Values[l]);
					}
				});
			}
			else
			{
				base.MapToUnchecked(target, f, zeros, existingData);
			}
		}

		internal override void MapIndexedToUnchecked<TU>(VectorStorage<TU> target, Func<int, T, TU> f, Zeros zeros, ExistingData existingData)
		{
			if (target is SparseVectorStorage<TU> sparseVectorStorage)
			{
				List<int> list = new List<int>();
				List<TU> list2 = new List<TU>();
				if (zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(0, VectorStorage<T>.Zero)))
				{
					int num = 0;
					for (int i = 0; i < Length; i++)
					{
						TU val = ((num < ValueCount && Indices[num] == i) ? f(i, Values[num++]) : f(i, VectorStorage<T>.Zero));
						if (!VectorStorage<T>.Zero.Equals(val))
						{
							list2.Add(val);
							list.Add(i);
						}
					}
				}
				else
				{
					for (int j = 0; j < ValueCount; j++)
					{
						TU val2 = f(Indices[j], Values[j]);
						if (!VectorStorage<T>.Zero.Equals(val2))
						{
							list2.Add(val2);
							list.Add(Indices[j]);
						}
					}
				}
				sparseVectorStorage.Indices = list.ToArray();
				sparseVectorStorage.Values = list2.ToArray();
				sparseVectorStorage.ValueCount = list2.Count;
			}
			else if (target is DenseVectorStorage<TU> denseVectorStorage)
			{
				if (existingData == ExistingData.Clear)
				{
					denseVectorStorage.Clear();
				}
				TU[] denseTargetData = denseVectorStorage.Data;
				if (zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(0, VectorStorage<T>.Zero)))
				{
					int num2 = 0;
					for (int k = 0; k < Length; k++)
					{
						denseTargetData[k] = ((num2 < ValueCount && Indices[num2] == k) ? f(k, Values[num2++]) : f(k, VectorStorage<T>.Zero));
					}
					return;
				}
				CommonParallel.For(0, ValueCount, 4096, delegate(int a, int b)
				{
					for (int l = a; l < b; l++)
					{
						denseTargetData[Indices[l]] = f(Indices[l], Values[l]);
					}
				});
			}
			else
			{
				base.MapIndexedToUnchecked(target, f, zeros, existingData);
			}
		}

		internal override void Map2ToUnchecked(VectorStorage<T> target, VectorStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			bool flag = zeros == Zeros.Include || !VectorStorage<T>.Zero.Equals(f(VectorStorage<T>.Zero, VectorStorage<T>.Zero));
			DenseVectorStorage<T> denseVectorStorage = target as DenseVectorStorage<T>;
			DenseVectorStorage<T> denseVectorStorage2 = other as DenseVectorStorage<T>;
			if (denseVectorStorage == null && (denseVectorStorage2 != null || flag))
			{
				DenseVectorStorage<T> denseVectorStorage3 = new DenseVectorStorage<T>(target.Length);
				Map2ToUnchecked(denseVectorStorage3, other, f, zeros, ExistingData.AssumeZeros);
				denseVectorStorage3.CopyTo(target, existingData);
				return;
			}
			if (denseVectorStorage2 != null)
			{
				T[] data = denseVectorStorage.Data;
				T[] data2 = denseVectorStorage2.Data;
				int num = 0;
				for (int i = 0; i < data2.Length; i++)
				{
					if (num < ValueCount && Indices[num] == i)
					{
						data[i] = f(Values[num], data2[i]);
						num++;
					}
					else
					{
						data[i] = f(VectorStorage<T>.Zero, data2[i]);
					}
				}
				return;
			}
			SparseVectorStorage<T> sparseVectorStorage = other as SparseVectorStorage<T>;
			if (sparseVectorStorage != null && denseVectorStorage != null)
			{
				T[] data3 = denseVectorStorage.Data;
				int[] indices = sparseVectorStorage.Indices;
				T[] values = sparseVectorStorage.Values;
				int valueCount = sparseVectorStorage.ValueCount;
				if (flag)
				{
					int num2 = 0;
					int num3 = 0;
					for (int j = 0; j < data3.Length; j++)
					{
						T arg = ((num2 < ValueCount && Indices[num2] == j) ? Values[num2++] : VectorStorage<T>.Zero);
						T arg2 = ((num3 < valueCount && indices[num3] == j) ? values[num3++] : VectorStorage<T>.Zero);
						data3[j] = f(arg, arg2);
					}
					return;
				}
				if (existingData == ExistingData.Clear)
				{
					denseVectorStorage.Clear();
				}
				int num4 = 0;
				int num5 = 0;
				while (num4 < ValueCount || num5 < valueCount)
				{
					if (num5 >= valueCount || (num4 < ValueCount && Indices[num4] < indices[num5]))
					{
						data3[Indices[num4]] = f(Values[num4], VectorStorage<T>.Zero);
						num4++;
					}
					else if (num4 >= ValueCount || (num5 < valueCount && Indices[num4] > indices[num5]))
					{
						data3[indices[num5]] = f(VectorStorage<T>.Zero, values[num5]);
						num5++;
					}
					else
					{
						data3[Indices[num4]] = f(Values[num4], values[num5]);
						num4++;
						num5++;
					}
				}
			}
			else if (sparseVectorStorage != null && target is SparseVectorStorage<T> sparseVectorStorage2)
			{
				List<int> list = new List<int>();
				List<T> list2 = new List<T>();
				int[] indices2 = sparseVectorStorage.Indices;
				T[] values2 = sparseVectorStorage.Values;
				int valueCount2 = sparseVectorStorage.ValueCount;
				int num6 = 0;
				int num7 = 0;
				while (num6 < ValueCount || num7 < valueCount2)
				{
					if (num7 >= valueCount2 || (num6 < ValueCount && Indices[num6] < indices2[num7]))
					{
						T val = f(Values[num6], VectorStorage<T>.Zero);
						if (!VectorStorage<T>.Zero.Equals(val))
						{
							list.Add(Indices[num6]);
							list2.Add(val);
						}
						num6++;
						continue;
					}
					if (num6 >= ValueCount || (num7 < valueCount2 && Indices[num6] > indices2[num7]))
					{
						T val2 = f(VectorStorage<T>.Zero, values2[num7]);
						if (!VectorStorage<T>.Zero.Equals(val2))
						{
							list.Add(indices2[num7]);
							list2.Add(val2);
						}
						num7++;
						continue;
					}
					T val3 = f(Values[num6], values2[num7]);
					if (!VectorStorage<T>.Zero.Equals(val3))
					{
						list.Add(Indices[num6]);
						list2.Add(val3);
					}
					num6++;
					num7++;
				}
				sparseVectorStorage2.Indices = list.ToArray();
				sparseVectorStorage2.Values = list2.ToArray();
				sparseVectorStorage2.ValueCount = list2.Count;
			}
			else
			{
				base.Map2ToUnchecked(target, other, f, zeros, existingData);
			}
		}

		internal override TState Fold2Unchecked<TOther, TState>(VectorStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros)
		{
			if (other is SparseVectorStorage<TOther> { Indices: var indices, Values: var values, ValueCount: var valueCount })
			{
				TOther zero = BuilderInstance<TOther>.Vector.Zero;
				if (zeros == Zeros.Include)
				{
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < Length; i++)
					{
						T arg = ((num < ValueCount && Indices[num] == i) ? Values[num++] : VectorStorage<T>.Zero);
						TOther arg2 = ((num2 < valueCount && indices[num2] == i) ? values[num2++] : zero);
						state = f(state, arg, arg2);
					}
				}
				else
				{
					int num3 = 0;
					int num4 = 0;
					while (num3 < ValueCount || num4 < valueCount)
					{
						if (num4 >= valueCount || (num3 < ValueCount && Indices[num3] < indices[num4]))
						{
							state = f(state, Values[num3], zero);
							num3++;
						}
						else if (num3 >= ValueCount || (num4 < valueCount && Indices[num3] > indices[num4]))
						{
							state = f(state, VectorStorage<T>.Zero, values[num4]);
							num4++;
						}
						else
						{
							state = f(state, Values[num3], values[num4]);
							num3++;
							num4++;
						}
					}
				}
				return state;
			}
			if (other is DenseVectorStorage<TOther> { Data: var data })
			{
				int num5 = 0;
				for (int j = 0; j < data.Length; j++)
				{
					if (num5 < ValueCount && Indices[num5] == j)
					{
						state = f(state, Values[num5], data[j]);
						num5++;
					}
					else
					{
						state = f(state, VectorStorage<T>.Zero, data[j]);
					}
				}
				return state;
			}
			return base.Fold2Unchecked(other, f, state, zeros);
		}
	}
}
