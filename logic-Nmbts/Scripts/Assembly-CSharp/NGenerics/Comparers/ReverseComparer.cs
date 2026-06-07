using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Comparers
{
	[Serializable]
	public sealed class ReverseComparer<T> : IComparer<T>
	{
		private IComparer<T> comparerToUse;

		public IComparer<T> Comparer
		{
			get
			{
				return comparerToUse;
			}
			set
			{
				Guard.ArgumentNotNull(value, "value");
				comparerToUse = value;
			}
		}

		public ReverseComparer()
		{
			comparerToUse = Comparer<T>.Default;
		}

		public ReverseComparer(IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			comparerToUse = comparer;
		}

		public int Compare(T x, T y)
		{
			return comparerToUse.Compare(y, x);
		}
	}
}
