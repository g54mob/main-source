using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	internal static class Comparers
	{
		[Serializable]
		private class KeyValueEqualityComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
		{
			private readonly IEqualityComparer<TKey> keyEqualityComparer;

			public KeyValueEqualityComparer(IEqualityComparer<TKey> keyEqualityComparer)
			{
			}

			public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return false;
			}

			public int GetHashCode(KeyValuePair<TKey, TValue> obj)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class KeyValueComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
		{
			private readonly IComparer<TKey> keyComparer;

			public KeyValueComparer(IComparer<TKey> keyComparer)
			{
			}

			public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class PairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
		{
			private readonly IComparer<TKey> keyComparer;

			private readonly IComparer<TValue> valueComparer;

			public PairComparer(IComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
			{
			}

			public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class ComparisonComparer<T> : IComparer<T>
		{
			private readonly Comparison<T> comparison;

			public ComparisonComparer(Comparison<T> comparison)
			{
			}

			public int Compare(T x, T y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class ComparisonKeyValueComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
		{
			private readonly Comparison<TKey> comparison;

			public ComparisonKeyValueComparer(Comparison<TKey> comparison)
			{
			}

			public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public static IComparer<T> ComparerFromComparison<T>(Comparison<T> comparison)
		{
			return null;
		}

		public static IComparer<KeyValuePair<TKey, TValue>> ComparerKeyValueFromComparerKey<TKey, TValue>(IComparer<TKey> keyComparer)
		{
			return null;
		}

		public static IEqualityComparer<KeyValuePair<TKey, TValue>> EqualityComparerKeyValueFromComparerKey<TKey, TValue>(IEqualityComparer<TKey> keyEqualityComparer)
		{
			return null;
		}

		public static IComparer<KeyValuePair<TKey, TValue>> ComparerPairFromKeyValueComparers<TKey, TValue>(IComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
		{
			return null;
		}

		public static IComparer<KeyValuePair<TKey, TValue>> ComparerKeyValueFromComparisonKey<TKey, TValue>(Comparison<TKey> keyComparison)
		{
			return null;
		}

		public static IComparer<T> DefaultComparer<T>()
		{
			return null;
		}

		public static IComparer<KeyValuePair<TKey, TValue>> DefaultKeyValueComparer<TKey, TValue>()
		{
			return null;
		}
	}
}
