using System;
using System.Collections.Generic;

namespace MiscUtil.Collections
{
	public sealed class ComparisonComparer<T> : IComparer<T>
	{
		private readonly Comparison<T> comparison;

		public ComparisonComparer(Comparison<T> comparison)
		{
			if (comparison == null)
			{
				throw new ArgumentNullException("comparison");
			}
			this.comparison = comparison;
		}

		public int Compare(T x, T y)
		{
			return comparison(x, y);
		}

		public static Comparison<T> CreateComparison(IComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			return (T x, T y) => comparer.Compare(x, y);
		}
	}
}
