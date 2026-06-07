using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class SkipList<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly IComparer<TKey> comparerToUse;

		private readonly int maximumLevelToUse;

		private readonly double probabilityToUse;

		private readonly SkipListNode<TKey, TValue>[] headNodes;

		private readonly SkipListNode<TKey, TValue> tail = new SkipListNode<TKey, TValue>();

		internal const int defaultMaximumLevel = 16;

		internal const double defaultProbability = 0.5;

		private readonly Random rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % int.MaxValue));

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public int Count { get; private set; }

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				SkipListNode<TKey, TValue> skipListNode = headNodes[0];
				TKey[] array = new TKey[Count];
				for (int i = 0; i < Count; i++)
				{
					skipListNode = skipListNode.Right;
					array[i] = skipListNode.Key;
				}
				return array;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				SkipListNode<TKey, TValue> skipListNode = headNodes[0];
				TValue[] array = new TValue[Count];
				for (int i = 0; i < Count; i++)
				{
					skipListNode = skipListNode.Right;
					array[i] = skipListNode.Value;
				}
				return array;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				SkipListNode<TKey, TValue> skipListNode = Find(key);
				if (skipListNode == null)
				{
					throw new KeyNotFoundException("key");
				}
				return skipListNode.Value;
			}
			set
			{
				SkipListNode<TKey, TValue> skipListNode = Find(key);
				if (skipListNode == null)
				{
					throw new KeyNotFoundException("key");
				}
				skipListNode.Value = value;
			}
		}

		public IComparer<TKey> Comparer
		{
			get
			{
				return comparerToUse;
			}
		}

		public double Probability
		{
			get
			{
				return probabilityToUse;
			}
		}

		public int MaximumListLevel
		{
			get
			{
				return maximumLevelToUse;
			}
		}

		public int CurrentListLevel { get; private set; }

		public SkipList()
			: this(16, 0.5, (IComparer<TKey>)Comparer<TKey>.Default)
		{
		}

		public SkipList(IComparer<TKey> comparer)
			: this(16, 0.5, comparer)
		{
		}

		public SkipList(Comparison<TKey> comparison)
			: this(16, 0.5, (IComparer<TKey>)new ComparisonComparer<TKey>(comparison))
		{
		}

		public SkipList(int maximumLevel, double probability, Comparison<TKey> comparison)
			: this(maximumLevel, probability, (IComparer<TKey>)new ComparisonComparer<TKey>(comparison))
		{
		}

		public SkipList(int maximumLevel, double probability, IComparer<TKey> comparer)
		{
			if (maximumLevel < 1)
			{
				throw new ArgumentOutOfRangeException("maximumLevel", "The maximum level must be bigger than 0.");
			}
			Guard.ArgumentNotNull(comparer, "comparer");
			if (probability > 0.9 || probability < 0.1)
			{
				throw new ArgumentOutOfRangeException("probability", "The probability must be between 0.1 and 0.9");
			}
			comparerToUse = comparer;
			maximumLevelToUse = maximumLevel;
			probabilityToUse = probability;
			headNodes = new SkipListNode<TKey, TValue>[maximumLevel];
			headNodes[0] = new SkipListNode<TKey, TValue>
			{
				Right = tail
			};
			for (int i = 1; i < maximumLevel; i++)
			{
				headNodes[i] = new SkipListNode<TKey, TValue>
				{
					Down = headNodes[i - 1],
					Right = tail
				};
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			for (int i = 0; i < maximumLevelToUse; i++)
			{
				headNodes[i].Right = tail;
			}
			Count = 0;
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			SkipListNode<TKey, TValue> skipListNode = Find(item.Key);
			if (skipListNode != null)
			{
				return skipListNode.Value.Equals(item.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<TKey, TValue> current = enumerator.Current;
					array.SetValue(current, arrayIndex++);
				}
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public void Add(TKey key, TValue value)
		{
			AddItem(key, value);
		}

		protected virtual void AddItem(TKey key, TValue value)
		{
			SkipListNode<TKey, TValue>[] array = FindRightMostNodes(key);
			if (array[0].Right != tail && comparerToUse.Compare(array[0].Right.Key, key) == 0)
			{
				throw new ArgumentException("The item is already in the list.", "key");
			}
			int num = PickRandomLevel();
			if (num > CurrentListLevel)
			{
				for (int i = CurrentListLevel + 1; i <= num; i++)
				{
					array[i] = headNodes[i];
				}
				CurrentListLevel = num;
			}
			SkipListNode<TKey, TValue> skipListNode = new SkipListNode<TKey, TValue>(key, value)
			{
				Right = array[0].Right
			};
			array[0].Right = skipListNode;
			for (int j = 1; j <= CurrentListLevel; j++)
			{
				SkipListNode<TKey, TValue> down = skipListNode;
				skipListNode = new SkipListNode<TKey, TValue>(key, value)
				{
					Right = array[j].Right
				};
				array[j].Right = skipListNode;
				skipListNode.Down = down;
			}
			Count++;
		}

		public bool ContainsKey(TKey key)
		{
			return Find(key) != null;
		}

		public bool Remove(TKey key)
		{
			return RemoveItem(key);
		}

		protected virtual bool RemoveItem(TKey key)
		{
			SkipListNode<TKey, TValue>[] array = FindRightMostNodes(key);
			if (array[0].Right != tail && comparerToUse.Compare(array[0].Right.Key, key) == 0)
			{
				for (int i = 0; i <= CurrentListLevel && array[i].Right != tail && comparerToUse.Compare(array[i].Right.Key, key) == 0; i++)
				{
					array[i].Right = array[i].Right.Right;
				}
				Count--;
				return true;
			}
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			SkipListNode<TKey, TValue> skipListNode = Find(key);
			if (skipListNode == null)
			{
				value = default(TValue);
				return false;
			}
			value = skipListNode.Value;
			return true;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			SkipListNode<TKey, TValue> startNode = headNodes[0];
			while (startNode.Right != tail)
			{
				startNode = startNode.Right;
				yield return new KeyValuePair<TKey, TValue>(startNode.Key, startNode.Value);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private SkipListNode<TKey, TValue> Find(TKey key)
		{
			if (Count == 0)
			{
				return null;
			}
			SkipListNode<TKey, TValue> skipListNode = headNodes[CurrentListLevel];
			while (true)
			{
				if (skipListNode.Right != tail && comparerToUse.Compare(skipListNode.Right.Key, key) < 0)
				{
					skipListNode = skipListNode.Right;
					continue;
				}
				if (skipListNode.Down == null)
				{
					break;
				}
				skipListNode = skipListNode.Down;
			}
			if (comparerToUse.Compare(skipListNode.Right.Key, key) == 0)
			{
				return skipListNode.Right;
			}
			return null;
		}

		private int PickRandomLevel()
		{
			int num = 0;
			while (rand.NextDouble() < probabilityToUse && num <= CurrentListLevel + 1 && num < maximumLevelToUse)
			{
				num++;
			}
			return num;
		}

		private SkipListNode<TKey, TValue>[] FindRightMostNodes(TKey key)
		{
			SkipListNode<TKey, TValue>[] array = new SkipListNode<TKey, TValue>[maximumLevelToUse];
			SkipListNode<TKey, TValue> skipListNode = headNodes[CurrentListLevel];
			for (int num = CurrentListLevel; num >= 0; num--)
			{
				while (skipListNode.Right != tail && comparerToUse.Compare(skipListNode.Right.Key, key) < 0)
				{
					skipListNode = skipListNode.Right;
				}
				array[num] = skipListNode;
				if (num > 0)
				{
					skipListNode = skipListNode.Down;
				}
			}
			return array;
		}
	}
}
