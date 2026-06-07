using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LitMotion.Collections
{
	[StructLayout(LayoutKind.Auto)]
	public struct FastListCore<T>
	{
		private const int InitialCapacity = 8;

		public static readonly FastListCore<T> Empty;

		private T[] array;

		private int tailIndex;

		public readonly T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array[index];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				array[index] = value;
			}
		}

		public readonly int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return tailIndex;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(T element)
		{
			if (array == null)
			{
				array = new T[8];
			}
			else if (array.Length == tailIndex)
			{
				Array.Resize(ref array, tailIndex * 2);
			}
			array[tailIndex] = element;
			tailIndex++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveAtSwapback(int index)
		{
			Error.IsNull(array);
			CheckIndex(index);
			array[index] = array[tailIndex - 1];
			array[tailIndex - 1] = default(T);
			tailIndex--;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(bool removeArray = false)
		{
			if (array != null)
			{
				array.AsSpan().Clear();
				tailIndex = 0;
				if (removeArray)
				{
					array = null;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EnsureCapacity(int capacity)
		{
			if (array == null)
			{
				array = new T[8];
			}
			while (array.Length < capacity)
			{
				Array.Resize(ref array, array.Length * 2);
			}
		}

		public readonly Span<T> AsSpan()
		{
			if (array != null)
			{
				return array.AsSpan(0, tailIndex);
			}
			return Span<T>.Empty;
		}

		public readonly T[] AsArray()
		{
			return array;
		}

		private readonly void CheckIndex(int index)
		{
			if (index < 0 || index > tailIndex)
			{
				throw new IndexOutOfRangeException();
			}
		}
	}
}
