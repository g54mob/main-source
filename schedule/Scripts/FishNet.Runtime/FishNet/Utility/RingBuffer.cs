using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;

namespace FishNet.Utility
{
	public class RingBuffer<T>
	{
		[APIExclude]
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> _rollingCollection;

			private readonly T[] _collection;

			private int _read;

			private int _startIndex;

			public T Current { get; private set; }

			public int ActualIndex => 0;

			public int SimulatedIndex => 0;

			object IEnumerator.Current => null;

			public Enumerator(RingBuffer<T> c)
			{
				Current = default(T);
				_rollingCollection = null;
				_collection = null;
				_read = 0;
				_startIndex = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void SetStartIndex(int index)
			{
			}

			public void AddStartIndex(int value)
			{
			}

			public void ResetRead()
			{
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		public T[] Collection;

		private int _written;

		private Enumerator _enumerator;

		public int WriteIndex { get; private set; }

		public int Count => 0;

		public int Capacity => 0;

		public bool Initialized { get; private set; }

		public T this[int simulatedIndex]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void Initialize(int capacity)
		{
		}

		public void Clear()
		{
		}

		public void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Add(T data)
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public void RemoveRange(bool fromStart, int length)
		{
		}

		private bool IsInitializedWithError()
		{
			return false;
		}
	}
}
