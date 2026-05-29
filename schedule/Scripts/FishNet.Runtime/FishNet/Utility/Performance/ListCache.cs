using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FishNet.Utility.Performance
{
	[Obsolete("Use CollectionCache<T> instead.")]
	public class ListCache<T>
	{
		public List<T> Collection;

		private Stack<T> _cache;

		public int Written => 0;

		public ListCache()
		{
		}

		public ListCache(int capacity)
		{
		}

		private T Retrieve()
		{
			return default(T);
		}

		private void Store(T value)
		{
		}

		public T AddReference()
		{
			return default(T);
		}

		public T InsertReference(int index)
		{
			return default(T);
		}

		public void AddValue(T value)
		{
		}

		public void InsertValue(int index, T value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(ListCache<T> values)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(T[] values)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(List<T> values)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(HashSet<T> values)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(ISet<T> values)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddValues(IReadOnlyCollection<T> values)
		{
		}

		public void Reset()
		{
		}
	}
}
