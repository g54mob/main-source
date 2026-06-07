using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class OrderedDictionary<TKey, TValue> : DictionaryBase<TKey, TValue>, ICloneable
	{
		[Serializable]
		public class View : DictionaryBase<TKey, TValue>
		{
			private readonly OrderedDictionary<TKey, TValue> myDictionary;

			private readonly RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

			public sealed override int Count => 0;

			public sealed override TValue Item
			{
				get
				{
					return default(TValue);
				}
				set
				{
				}
			}

			internal View(OrderedDictionary<TKey, TValue> myDictionary, RedBlackTree<KeyValuePair<TKey, TValue>>.RangeTester rangeTester, bool entireTree, bool reversed)
			{
			}

			private bool KeyInView(TKey key)
			{
				return false;
			}

			public sealed override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return null;
			}

			public sealed override bool ContainsKey(TKey key)
			{
				return false;
			}

			public sealed override bool TryGetValue(TKey key, out TValue value)
			{
				value = default(TValue);
				return false;
			}

			public sealed override bool Remove(TKey key)
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

		private IComparer<KeyValuePair<TKey, TValue>> pairComparer;

		private RedBlackTree<KeyValuePair<TKey, TValue>> tree;

		public IComparer<TKey> Comparer => null;

		public sealed override TValue Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public sealed override int Count => 0;

		private static KeyValuePair<TKey, TValue> NewPair(TKey key, TValue value)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		private static KeyValuePair<TKey, TValue> NewPair(TKey key)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public OrderedDictionary()
		{
		}

		public OrderedDictionary(IComparer<TKey> comparer)
		{
		}

		public OrderedDictionary(Comparison<TKey> comparison)
		{
		}

		public OrderedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> keysAndValues)
		{
		}

		public OrderedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> keysAndValues, IComparer<TKey> comparer)
		{
		}

		public OrderedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> keysAndValues, Comparison<TKey> comparison)
		{
		}

		private OrderedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> keysAndValues, IComparer<TKey> keyComparer, IComparer<KeyValuePair<TKey, TValue>> pairComparer)
		{
		}

		private OrderedDictionary(IComparer<TKey> keyComparer, IComparer<KeyValuePair<TKey, TValue>> pairComparer, RedBlackTree<KeyValuePair<TKey, TValue>> tree)
		{
		}

		public OrderedDictionary<TKey, TValue> Clone()
		{
			return null;
		}

		private static void NonCloneableType(Type t)
		{
		}

		public OrderedDictionary<TKey, TValue> CloneContents()
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

		public sealed override bool Remove(TKey key)
		{
			return false;
		}

		public sealed override void Clear()
		{
		}

		public bool GetValueElseAdd(TKey key, ref TValue value)
		{
			return false;
		}

		public sealed override void Add(TKey key, TValue value)
		{
		}

		public void Replace(TKey key, TValue value)
		{
		}

		public void AddMany(IEnumerable<KeyValuePair<TKey, TValue>> keysAndValues)
		{
		}

		public int RemoveMany(IEnumerable<TKey> keyCollectionToRemove)
		{
			return 0;
		}

		public sealed override bool ContainsKey(TKey key)
		{
			return false;
		}

		public sealed override bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public sealed override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}
	}
}
