using System;

namespace Gilzoide.UpdateManager
{
	public class ReversedSortedList<T> : SortedList<T> where T : IComparable<T>
	{
		public override int Compare(T x, T y)
		{
			return -x.CompareTo(y);
		}
	}
}
