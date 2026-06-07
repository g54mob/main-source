using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class OrderedMultiDictionary<TKey, TValue> : MultiDictionaryBase<TKey, TValue>, ICloneable
	{
		[Serializable]
		private sealed class KeyValuePairsCollection : ReadOnlyCollectionBase<KeyValuePair<TKey, TValue>>
		{
			private readonly OrderedMultiDictionary<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeyValuePairsCollection(OrderedMultiDictionary<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(KeyValuePair<TKey, TValue> pair)
			{
				return false;
			}
		}

		[Serializable]
		public class View : MultiDictionaryBase<TKey, TValue>
		{
			private readonly OrderedMultiDictionary<TKey, TValue> myDictionary;

			private readonly RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

			public sealed override int Count => 0;

			internal View(OrderedMultiDictionary<TKey, TValue> myDictionary, RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester rangeTester, bool entireTree, bool reversed)
			{
			}

			private bool KeyInView(TKey key)
			{
				return false;
			}

			protected sealed override IEnumerator<TKey> EnumerateKeys()
			{
				return null;
			}

			protected sealed override bool TryEnumerateValuesForKey(TKey key, out IEnumerator<TValue> values)
			{
				values = null;
				return false;
			}

			public sealed override bool ContainsKey(TKey key)
			{
				return false;
			}

			public sealed override bool Contains(TKey key, TValue value)
			{
				return false;
			}

			protected sealed override int CountValues(TKey key)
			{
				return 0;
			}

			public sealed override void Add(TKey key, TValue value)
			{
			}

			public sealed override bool Remove(TKey key)
			{
				return false;
			}

			public sealed override bool Remove(TKey key, TValue value)
			{
				return false;
			}

			public sealed override void Clear()
			{
			}

			public View Reversed()
			{
				return null;
			}
		}

		private readonly IComparer<TKey> keyComparer;

		private readonly IComparer<TValue> valueComparer;

		private readonly IComparer<KeyValuePair<TKey, TValue>> comparer;

		private RedBlackTree<KeyValuePair<TKey, TValue>> tree;

		private readonly bool allowDuplicateValues;

		private int keyCount;

		public IComparer<TKey> KeyComparer => null;

		public IComparer<TValue> ValueComparer => null;

		public sealed override int Count => 0;

		public sealed override ICollection<KeyValuePair<TKey, TValue>> KeyValuePairs => null;

		private static KeyValuePair<TKey, TValue> NewPair(TKey key, TValue value)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		private RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester KeyRange(TKey key)
		{
			return null;
		}

		private RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester DoubleBoundedKeyRangeTester(TKey first, bool firstInclusive, TKey last, bool lastInclusive)
		{
			return null;
		}

		private RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester LowerBoundedKeyRangeTester(TKey first, bool inclusive)
		{
			return null;
		}

		private RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester UpperBoundedKeyRangeTester(TKey last, bool inclusive)
		{
			return null;
		}

		public OrderedMultiDictionary(bool allowDuplicateValues)
		{
		}

		public OrderedMultiDictionary(bool allowDuplicateValues, Comparison<TKey> keyComparison)
		{
		}

		public OrderedMultiDictionary(bool allowDuplicateValues, Comparison<TKey> keyComparison, Comparison<TValue> valueComparison)
		{
		}

		public OrderedMultiDictionary(bool allowDuplicateValues, IComparer<TKey> keyComparer)
		{
		}

		public OrderedMultiDictionary(bool allowDuplicateValues, IComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
		{
		}

		private OrderedMultiDictionary(bool allowDuplicateValues, int keyCount, IComparer<TKey> keyComparer, IComparer<TValue> valueComparer, IComparer<KeyValuePair<TKey, TValue>> comparer, RedBlackTree<KeyValuePair<TKey, TValue>> tree)
		{
		}

		public sealed override void Add(TKey key, TValue value)
		{
		}

		public sealed override bool Remove(TKey key, TValue value)
		{
			return false;
		}

		public sealed override bool Remove(TKey key)
		{
			return false;
		}

		public sealed override void Clear()
		{
		}

		protected sealed override bool EqualValues(TValue value1, TValue value2)
		{
			return false;
		}

		public sealed override bool Contains(TKey key, TValue value)
		{
			return false;
		}

		public sealed override bool ContainsKey(TKey key)
		{
			return false;
		}

		private IEnumerator<TKey> EnumerateKeys(RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester rangeTester, bool reversed)
		{
			return null;
		}

		private IEnumerator<TValue> EnumerateValuesForKey(TKey key)
		{
			return null;
		}

		protected sealed override bool TryEnumerateValuesForKey(TKey key, out IEnumerator<TValue> values)
		{
			values = null;
			return false;
		}

		protected sealed override IEnumerator<TKey> EnumerateKeys()
		{
			return null;
		}

		protected sealed override int CountValues(TKey key)
		{
			return 0;
		}

		protected sealed override int CountAllValues()
		{
			return 0;
		}

		public OrderedMultiDictionary<TKey, TValue> Clone()
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}

		private static void NonCloneableType(Type t)
		{
		}

		public OrderedMultiDictionary<TKey, TValue> CloneContents()
		{
			return null;
		}

		public View Reversed()
		{
			return null;
		}

		public View Range(TKey from, bool fromInclusive, TKey to, bool toInclusive)
		{
			return null;
		}

		public View RangeFrom(TKey from, bool fromInclusive)
		{
			return null;
		}

		public View RangeTo(TKey to, bool toInclusive)
		{
			return null;
		}
	}
}
