using System;
using System.Collections.Generic;

namespace ObservableCollections
{
	public readonly struct SortOperation<T>
	{
		private sealed class ReverseSentinel : IComparer<T>
		{
			public static IComparer<T> Instance = new ReverseSentinel();

			public int Compare(T? x, T? y)
			{
				throw new NotImplementedException();
			}
		}

		private sealed class NullComparerSentinel : IComparer<T>
		{
			public static IComparer<T> Instance = new NullComparerSentinel();

			public int Compare(T? x, T? y)
			{
				return Comparer<T>.Default.Compare(x, y);
			}
		}

		public readonly int Index;

		public readonly int Count;

		public readonly IComparer<T>? Comparer;

		public bool IsReverse => Comparer == ReverseSentinel.Instance;

		public bool IsClear => Comparer == null;

		public bool IsSort
		{
			get
			{
				if (!IsClear)
				{
					return !IsReverse;
				}
				return false;
			}
		}

		public SortOperation(int index, int count, IComparer<T>? comparer)
		{
			Index = index;
			Count = count;
			Comparer = comparer ?? NullComparerSentinel.Instance;
		}

		public (int Index, int Count, IComparer<T>? Comparer) AsTuple()
		{
			return (Index: Index, Count: Count, Comparer: Comparer);
		}

		public static SortOperation<T> CreateReverse(int index, int count)
		{
			return new SortOperation<T>(index, count, ReverseSentinel.Instance);
		}
	}
}
