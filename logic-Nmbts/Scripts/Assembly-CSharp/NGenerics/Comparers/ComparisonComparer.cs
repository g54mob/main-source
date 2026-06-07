using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Comparers
{
	[Serializable]
	public sealed class ComparisonComparer<T> : IComparer<T>
	{
		private Comparison<T> comparison;

		public Comparison<T> Comparison
		{
			get
			{
				return comparison;
			}
			set
			{
				Guard.ArgumentNotNull(value, "value");
				comparison = value;
			}
		}

		public ComparisonComparer(Comparison<T> comparison)
		{
			Guard.ArgumentNotNull(comparison, "comparison");
			this.comparison = comparison;
		}

		public int Compare(T x, T y)
		{
			return comparison(x, y);
		}
	}
}
