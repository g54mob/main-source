using System;
using System.Collections.Generic;

namespace NGenerics.Comparers
{
	[Serializable]
	public class KeyValuePairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
	{
		private readonly IComparer<TKey> comparer;

		public KeyValuePairComparer()
		{
			comparer = Comparer<TKey>.Default;
		}

		public KeyValuePairComparer(IComparer<TKey> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			this.comparer = comparer;
		}

		public KeyValuePairComparer(Comparison<TKey> comparison)
		{
			if (comparison == null)
			{
				throw new ArgumentNullException("comparison");
			}
			comparer = new ComparisonComparer<TKey>(comparison);
		}

		public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
		{
			return comparer.Compare(x.Key, y.Key);
		}

		public int Compare(TKey x, TKey y)
		{
			return comparer.Compare(x, y);
		}
	}
}
