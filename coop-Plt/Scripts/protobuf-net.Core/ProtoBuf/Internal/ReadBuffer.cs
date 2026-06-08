using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProtoBuf.Internal
{
	[StructLayout(LayoutKind.Auto)]
	internal struct ReadBuffer<T> : IDisposable, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
	{
		private T[] _arr;

		private int _count;

		bool ICollection<T>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => _arr;

		public bool IsEmpty => _count == 0;

		public int Count => _count;

		public ArraySegment<T> Segment => new ArraySegment<T>(_arr, 0, _count);

		public Span<T> Span => new Span<T>(_arr, 0, _count);

		public void Clear()
		{
			_count = 0;
		}

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			Array.Copy(_arr, 0, array, arrayIndex, _count);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			Array.Copy(_arr, 0, array, index, _count);
		}

		public T[] ToArray()
		{
			if (_count == 0)
			{
				return Array.Empty<T>();
			}
			T[] array = new T[_count];
			CopyTo(array);
			return array;
		}

		public T[] ToArray(T[] prepend)
		{
			int num = ((prepend != null) ? prepend.Length : 0);
			if (num == 0)
			{
				return ToArray();
			}
			if (_count == 0)
			{
				return prepend ?? Array.Empty<T>();
			}
			T[] array = new T[num + _count];
			Array.Copy(prepend, 0, array, 0, num);
			Array.Copy(_arr, 0, array, num, _count);
			return array;
		}

		bool ICollection<T>.Contains(T item)
		{
			return Array.IndexOf(_arr, item, 0, _count) >= 0;
		}

		bool ICollection<T>.Remove(T item)
		{
			int num = Array.IndexOf(_arr, item, 0, _count);
			if (num < 0)
			{
				return false;
			}
			_count--;
			Array.Copy(_arr, num + 1, _arr, num, _count - num);
			return true;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _arr.Take(_count).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private ReadBuffer(int minimumLength)
		{
			_arr = ArrayPool<T>.Shared.Rent(minimumLength);
			_count = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadBuffer<T> Create(int minimumLength = 16)
		{
			return new ReadBuffer<T>(minimumLength);
		}

		private static void Recyle(ref T[] array)
		{
			if (array != null)
			{
				bool clearArray = !typeof(T).IsValueType;
				ArrayPool<T>.Shared.Return(array, clearArray);
				array = null;
			}
		}

		public void Dispose()
		{
			_count = 0;
			Recyle(ref _arr);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Grow()
		{
			uint num = (uint)_arr.Length;
			uint num2 = Math.Min(num * 2, 2146435071u);
			if (num == num2)
			{
				ThrowHelper.ThrowInvalidOperationException("maximum array size exceeded");
			}
			T[] array = ArrayPool<T>.Shared.Rent((int)num2);
			Array.Copy(_arr, 0, array, 0, _arr.Length);
			Recyle(ref _arr);
			_arr = array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(T value)
		{
			int num = _count++;
			if (num == _arr.Length)
			{
				Grow();
			}
			_arr[num] = value;
		}
	}
}
