using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Aggro.Core
{
	public struct ValueTypeList4<T> : IValueTypeList<T>, IEnumerable where T : struct
	{
		private T _value0;

		private T _value1;

		private T _value2;

		private T _value3;

		public const int MAX_SIZE = 4;

		private int _count;

		private const int NO_INDEX = -1;

		public unsafe T this[int index]
		{
			get
			{
				return UnsafeUtility.ReadArrayElement<T>(UnsafeUtility.AddressOf(ref _value0), index);
			}
			set
			{
				UnsafeUtility.WriteArrayElement(UnsafeUtility.AddressOf(ref _value0), index, value);
			}
		}

		public int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _count;
			}
		}

		public bool IsFull => _count == 4;

		public int MaxCapacity => 4;

		public ValueTypeList4(T[] arr)
		{
			this = default(ValueTypeList4<T>);
			AddRange(arr);
		}

		public ValueTypeList4(List<T> list)
		{
			this = default(ValueTypeList4<T>);
			AddRange(list);
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public unsafe void Add(T item)
		{
			UnsafeUtility.WriteArrayElement(UnsafeUtility.AddressOf(ref _value0), _count, item);
			_count++;
		}

		public void AddRange(T[] arr)
		{
			int num = arr.Length;
			for (int i = 0; i < num; i++)
			{
				Add(arr[i]);
			}
		}

		public void AddRange(List<T> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Add(list[i]);
			}
		}

		public void AddRange(NativeArray<T> arr)
		{
			int length = arr.Length;
			for (int i = 0; i < length; i++)
			{
				Add(arr[i]);
			}
		}

		public void AddRange<T_List>(T_List list) where T_List : struct, IValueTypeList<T>
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Add(list[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			_count = 0;
		}

		public bool Contains<TE>(TE item) where TE : IEquatable<T>
		{
			return IndexOf(item) != -1;
		}

		public unsafe void CopyTo(T[] array, int arrayIndex)
		{
			void* source = UnsafeUtility.AddressOf(ref _value0);
			for (int i = 0; i < _count; i++)
			{
				array[arrayIndex + i] = UnsafeUtility.ReadArrayElement<T>(source, i);
			}
		}

		public bool Remove<TE>(TE item) where TE : IEquatable<T>
		{
			int num = IndexOf(item);
			if (num != -1)
			{
				RemoveAt(num);
				return true;
			}
			return false;
		}

		public int IndexOf<TE>(TE item) where TE : IEquatable<T>
		{
			for (int i = 0; i < _count; i++)
			{
				if (item.Equals(this[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public unsafe void Insert(int index, T item)
		{
			int num = UnsafeUtility.SizeOf<T>();
			byte* ptr = (byte*)UnsafeUtility.AddressOf(ref _value0) + index * num;
			UnsafeUtility.MemMove(ptr + num, ptr, num * (_count - index));
			this[index] = item;
			_count++;
		}

		public unsafe void RemoveAt(int index)
		{
			int num = UnsafeUtility.SizeOf<T>();
			byte* ptr = (byte*)UnsafeUtility.AddressOf(ref _value0) + index * num;
			UnsafeUtility.MemMove(ptr, ptr + num, num * (_count - index - 1));
			_count--;
		}

		public void RemoveAtSwapBack(int index)
		{
			this[index] = this[_count - 1];
			_count--;
		}

		public bool Equals<TL, TI>(TL other) where TL : struct, IValueTypeList<TI> where TI : struct, IEquatable<T>
		{
			if (_count != other.Count)
			{
				return false;
			}
			for (int i = 0; i < _count; i++)
			{
				if (!other[i].Equals(this[i]))
				{
					return false;
				}
			}
			return true;
		}

		public void Randomize(int seed)
		{
			Unity.Mathematics.Random random = MathUtil.GetRandom(seed);
			int count = _count;
			while (count > 1)
			{
				int index = random.NextInt(0, count--);
				T value = this[count];
				this[count] = this[index];
				this[index] = value;
			}
		}

		public unsafe void* GetUnsafePtr()
		{
			return UnsafeUtility.AddressOf(ref _value0);
		}
	}
}
