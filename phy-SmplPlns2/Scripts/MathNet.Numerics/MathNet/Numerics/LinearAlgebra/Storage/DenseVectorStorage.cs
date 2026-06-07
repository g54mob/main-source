using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public class DenseVectorStorage<T> : VectorStorage<T> where T : struct, IEquatable<T>, IFormattable
	{
		[DataMember(Order = 1)]
		public readonly T[] Data;

		public override bool IsDense => true;

		internal DenseVectorStorage(int length)
			: base(length)
		{
			Data = new T[length];
		}

		internal DenseVectorStorage(int length, T[] data)
			: base(length)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.Length != length)
			{
				throw new ArgumentOutOfRangeException("data", $"The given array has the wrong length. Should be {length}.");
			}
			Data = data;
		}

		public override T At(int index)
		{
			return Data[index];
		}

		public override void At(int index, T value)
		{
			Data[index] = value;
		}

		public override void Clear()
		{
			Array.Clear(Data, 0, Data.Length);
		}

		public override void Clear(int index, int count)
		{
			Array.Clear(Data, index, count);
		}

		public static DenseVectorStorage<T> OfVector(VectorStorage<T> vector)
		{
			DenseVectorStorage<T> denseVectorStorage = new DenseVectorStorage<T>(vector.Length);
			vector.CopyToUnchecked(denseVectorStorage, ExistingData.AssumeZeros);
			return denseVectorStorage;
		}

		public static DenseVectorStorage<T> OfValue(int length, T value)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Value must not be negative (zero is ok).");
			}
			T[] data = new T[length];
			CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					data[i] = value;
				}
			});
			return new DenseVectorStorage<T>(length, data);
		}

		public static DenseVectorStorage<T> OfInit(int length, Func<int, T> init)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Value must not be negative (zero is ok).");
			}
			T[] data = new T[length];
			CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					data[i] = init(i);
				}
			});
			return new DenseVectorStorage<T>(length, data);
		}

		public static DenseVectorStorage<T> OfEnumerable(IEnumerable<T> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data is T[] array)
			{
				T[] array2 = new T[array.Length];
				Array.Copy(array, 0, array2, 0, array.Length);
				return new DenseVectorStorage<T>(array2.Length, array2);
			}
			T[] array3 = data.ToArray();
			return new DenseVectorStorage<T>(array3.Length, array3);
		}

		public static DenseVectorStorage<T> OfIndexedEnumerable(int length, IEnumerable<Tuple<int, T>> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			T[] array = new T[length];
			foreach (var (num2, val2) in data)
			{
				array[num2] = val2;
			}
			return new DenseVectorStorage<T>(array.Length, array);
		}

		public static DenseVectorStorage<T> OfIndexedEnumerable(int length, IEnumerable<(int, T)> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			T[] array = new T[length];
			foreach (var (num, val) in data)
			{
				array[num] = val;
			}
			return new DenseVectorStorage<T>(array.Length, array);
		}

		internal override void CopyToUnchecked(VectorStorage<T> target, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseVectorStorage<T> denseVectorStorage)
			{
				if (this != denseVectorStorage)
				{
					Array.Copy(data, 0, denseVectorStorage.Data, 0, data.Length);
				}
			}
			else if (target is SparseVectorStorage<T> sparseVectorStorage)
			{
				List<int> list = new List<int>();
				List<T> list2 = new List<T>();
				for (int i = 0; i < data.Length; i++)
				{
					T val = data[i];
					if (!VectorStorage<T>.Zero.Equals(val))
					{
						list2.Add(val);
						list.Add(i);
					}
				}
				sparseVectorStorage.Indices = list.ToArray();
				sparseVectorStorage.Values = list2.ToArray();
				sparseVectorStorage.ValueCount = list2.Count;
			}
			else
			{
				for (int j = 0; j < data.Length; j++)
				{
					target.At(j, data[j]);
				}
			}
		}

		internal override void CopyToRowUnchecked(MatrixStorage<T> target, int rowIndex, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseColumnMajorMatrixStorage<T> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					data2[i * target.RowCount + rowIndex] = data[i];
				}
			}
			else
			{
				for (int j = 0; j < Length; j++)
				{
					target.At(rowIndex, j, data[j]);
				}
			}
		}

		internal override void CopyToColumnUnchecked(MatrixStorage<T> target, int columnIndex, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage)
			{
				Array.Copy(Data, 0, denseColumnMajorMatrixStorage.Data, columnIndex * denseColumnMajorMatrixStorage.RowCount, Data.Length);
				return;
			}
			T[] data = Data;
			for (int i = 0; i < Length; i++)
			{
				target.At(i, columnIndex, data[i]);
			}
		}

		internal override void CopySubVectorToUnchecked(VectorStorage<T> target, int sourceIndex, int targetIndex, int count, ExistingData existingData)
		{
			if (target is DenseVectorStorage<T> denseVectorStorage)
			{
				Array.Copy(Data, sourceIndex, denseVectorStorage.Data, targetIndex, count);
			}
			else
			{
				base.CopySubVectorToUnchecked(target, sourceIndex, targetIndex, count, existingData);
			}
		}

		internal override void CopyToSubRowUnchecked(MatrixStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseColumnMajorMatrixStorage<T> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					data2[(i + targetColumnIndex) * target.RowCount + rowIndex] = data[i + sourceColumnIndex];
				}
				return;
			}
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				target.At(rowIndex, num2, data[num]);
				num++;
				num2++;
			}
		}

		internal override void CopyToSubColumnUnchecked(MatrixStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData)
		{
			if (target is DenseColumnMajorMatrixStorage<T> denseColumnMajorMatrixStorage)
			{
				Array.Copy(Data, sourceRowIndex, denseColumnMajorMatrixStorage.Data, columnIndex * denseColumnMajorMatrixStorage.RowCount + targetRowIndex, rowCount);
				return;
			}
			T[] data = Data;
			int num = sourceRowIndex;
			int num2 = targetRowIndex;
			while (num < sourceRowIndex + rowCount)
			{
				target.At(num2, columnIndex, data[num]);
				num++;
				num2++;
			}
		}

		public override T[] ToArray()
		{
			T[] array = new T[Data.Length];
			Array.Copy(Data, 0, array, 0, Data.Length);
			return array;
		}

		public override T[] AsArray()
		{
			return Data;
		}

		public override IEnumerable<T> Enumerate()
		{
			return Data;
		}

		public override IEnumerable<(int, T)> EnumerateIndexed()
		{
			return Data.Select((T t, int i) => (i: i, t: t));
		}

		public override IEnumerable<T> EnumerateNonZero()
		{
			return Data.Where((T x) => !VectorStorage<T>.Zero.Equals(x));
		}

		public override IEnumerable<(int, T)> EnumerateNonZeroIndexed()
		{
			T[] data = Data;
			for (int i = 0; i < data.Length; i++)
			{
				if (!VectorStorage<T>.Zero.Equals(data[i]))
				{
					yield return (i, data[i]);
				}
			}
		}

		public override Tuple<int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			T[] data = Data;
			for (int i = 0; i < data.Length; i++)
			{
				if (predicate(data[i]))
				{
					return new Tuple<int, T>(i, data[i]);
				}
			}
			return null;
		}

		internal override Tuple<int, T, TOther> Find2Unchecked<TOther>(VectorStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros)
		{
			T[] data = Data;
			if (other is DenseVectorStorage<TOther> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					if (predicate(data[i], data2[i]))
					{
						return new Tuple<int, T, TOther>(i, data[i], data2[i]);
					}
				}
				return null;
			}
			if (other is SparseVectorStorage<TOther> { Indices: var indices, Values: var values, ValueCount: var valueCount })
			{
				TOther zero = BuilderInstance<TOther>.Matrix.Zero;
				int num = 0;
				for (int j = 0; j < data.Length; j++)
				{
					if (num < valueCount && indices[num] == j)
					{
						if (predicate(data[j], values[num]))
						{
							return new Tuple<int, T, TOther>(j, data[j], values[num]);
						}
						num++;
					}
					else if (predicate(data[j], zero))
					{
						return new Tuple<int, T, TOther>(j, data[j], zero);
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

		public override void MapIndexedInplace(Func<int, T, T> f, Zeros zeros)
		{
			CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
			{
				T[] data = Data;
				for (int i = a; i < b; i++)
				{
					data[i] = f(i, data[i]);
				}
			});
		}

		internal override void MapToUnchecked<TU>(VectorStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseVectorStorage<TU> denseVectorStorage)
			{
				TU[] targetData = denseVectorStorage.Data;
				CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						targetData[i] = f(data[i]);
					}
				});
			}
			else
			{
				for (int num = 0; num < Length; num++)
				{
					target.At(num, f(data[num]));
				}
			}
		}

		internal override void MapIndexedToUnchecked<TU>(VectorStorage<TU> target, Func<int, T, TU> f, Zeros zeros, ExistingData existingData)
		{
			T[] data = Data;
			if (target is DenseVectorStorage<TU> denseVectorStorage)
			{
				TU[] targetData = denseVectorStorage.Data;
				CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						targetData[i] = f(i, data[i]);
					}
				});
			}
			else
			{
				for (int num = 0; num < Length; num++)
				{
					target.At(num, f(num, data[num]));
				}
			}
		}

		internal override void Map2ToUnchecked(VectorStorage<T> target, VectorStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			if (target is SparseVectorStorage<T>)
			{
				DenseVectorStorage<T> denseVectorStorage = new DenseVectorStorage<T>(target.Length);
				Map2ToUnchecked(denseVectorStorage, other, f, zeros, ExistingData.AssumeZeros);
				denseVectorStorage.CopyTo(target, existingData);
				return;
			}
			T[] data = Data;
			DenseVectorStorage<T> denseVectorStorage2 = target as DenseVectorStorage<T>;
			if (denseVectorStorage2 != null && other is DenseVectorStorage<T> denseVectorStorage3)
			{
				T[] targetData = denseVectorStorage2.Data;
				T[] otherData = denseVectorStorage3.Data;
				CommonParallel.For(0, Data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						targetData[i] = f(data[i], otherData[i]);
					}
				});
			}
			else if (denseVectorStorage2 != null && other is SparseVectorStorage<T> sparseVectorStorage)
			{
				T[] data2 = denseVectorStorage2.Data;
				int[] indices = sparseVectorStorage.Indices;
				T[] values = sparseVectorStorage.Values;
				int valueCount = sparseVectorStorage.ValueCount;
				int num = 0;
				for (int num2 = 0; num2 < data.Length; num2++)
				{
					if (num < valueCount && indices[num] == num2)
					{
						data2[num2] = f(data[num2], values[num]);
						num++;
					}
					else
					{
						data2[num2] = f(data[num2], VectorStorage<T>.Zero);
					}
				}
			}
			else
			{
				base.Map2ToUnchecked(target, other, f, zeros, existingData);
			}
		}

		internal override TState Fold2Unchecked<TOther, TState>(VectorStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros)
		{
			T[] data = Data;
			if (other is DenseVectorStorage<TOther> { Data: var data2 })
			{
				for (int i = 0; i < data.Length; i++)
				{
					state = f(state, data[i], data2[i]);
				}
				return state;
			}
			if (other is SparseVectorStorage<TOther> { Indices: var indices, Values: var values, ValueCount: var valueCount })
			{
				TOther zero = BuilderInstance<TOther>.Vector.Zero;
				int num = 0;
				for (int j = 0; j < data.Length; j++)
				{
					if (num < valueCount && indices[num] == j)
					{
						state = f(state, data[j], values[num]);
						num++;
					}
					else
					{
						state = f(state, data[j], zero);
					}
				}
				return state;
			}
			return base.Fold2Unchecked(other, f, state, zeros);
		}
	}
}
