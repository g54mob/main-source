using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DV
{
	public class PooledArray<T> : IDisposable, ICollection, IEnumerable, IReadOnlyCollection<T>, IEnumerable<T>
	{
		public static readonly PooledArray<T> Empty = new PooledArray<T>(0);

		private readonly T[] array;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.Length;
			}
		}

		public T this[int i]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array[i];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				array[i] = value;
			}
		}

		public int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Length;
			}
		}

		public bool IsSynchronized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.IsSynchronized;
			}
		}

		public object SyncRoot
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.SyncRoot;
			}
		}

		internal PooledArray(int length)
		{
			array = ((length == 0) ? Array.Empty<T>() : new T[length]);
		}

		public static implicit operator T[](PooledArray<T> value)
		{
			return value.array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IEnumerator GetEnumerator()
		{
			return array.GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return ((IEnumerable<T>)array).GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(Array array, int index)
		{
			this.array.CopyTo(array, index);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
			ArrayPool<T>.Free(this);
		}

		~PooledArray()
		{
			if (Application.isPlaying && !UnloadWatcher.isQuitting)
			{
				Debug.LogError($"{GetType().Name}<{GetType().GetGenericArguments()[0].Name}>[{array.Length}] was destroyed! This should never happen, ensure it gets returned to the pool!");
			}
		}
	}
}
