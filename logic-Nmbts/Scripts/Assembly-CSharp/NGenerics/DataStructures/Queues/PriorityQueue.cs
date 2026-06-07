using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NGenerics.Util;

namespace NGenerics.DataStructures.Queues
{
	[Serializable]
	public class PriorityQueue<TValue, TPriority> : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, IQueue<TValue>
	{
		private readonly RedBlackTreeList<TPriority, TValue> tree;

		private TPriority defaultPriority;

		private readonly PriorityQueueType queueType;

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public int Count { get; private set; }

		public TPriority DefaultPriority
		{
			get
			{
				return defaultPriority;
			}
			set
			{
				defaultPriority = value;
			}
		}

		public PriorityQueue(PriorityQueueType queueType)
			: this(queueType, (IComparer<TPriority>)Comparer<TPriority>.Default)
		{
		}

		public PriorityQueue(PriorityQueueType queueType, IComparer<TPriority> comparer)
		{
			if (queueType != PriorityQueueType.Minimum && queueType != PriorityQueueType.Maximum)
			{
				throw new ArgumentOutOfRangeException("queueType");
			}
			this.queueType = queueType;
			tree = new RedBlackTreeList<TPriority, TValue>(comparer);
		}

		public PriorityQueue(PriorityQueueType queueType, Comparison<TPriority> comparison)
			: this(queueType, (IComparer<TPriority>)new ComparisonComparer<TPriority>(comparison))
		{
		}

		public void Enqueue(TValue item)
		{
			Add(item);
		}

		public void Enqueue(TValue item, TPriority priority)
		{
			Add(item, priority);
		}

		public TValue Dequeue()
		{
			TPriority priority;
			return Dequeue(out priority);
		}

		public TValue Peek()
		{
			return GetNextItem().Value.First.Value;
		}

		public TValue Peek(out TPriority priority)
		{
			KeyValuePair<TPriority, LinkedList<TValue>> nextItem = GetNextItem();
			TValue value = nextItem.Value.First.Value;
			priority = nextItem.Key;
			return value;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return tree.GetValueEnumerator();
		}

		public bool Contains(TValue item)
		{
			return tree.ContainsValue(item);
		}

		public void CopyTo(TValue[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			foreach (KeyValuePair<TPriority, LinkedList<TValue>> item in tree)
			{
				foreach (TValue item2 in item.Value)
				{
					array.SetValue(item2, arrayIndex++);
				}
			}
		}

		public void Add(TValue item)
		{
			Add(item, defaultPriority);
		}

		public void Add(TValue item, TPriority priority)
		{
			AddItem(item, priority);
		}

		public bool Remove(TValue item)
		{
			TPriority priority;
			return Remove(item, out priority);
		}

		public IEnumerator<KeyValuePair<TPriority, TValue>> GetKeyEnumerator()
		{
			return tree.GetKeyEnumerator();
		}

		public void Clear()
		{
			ClearItems();
		}

		public TValue Dequeue(out TPriority priority)
		{
			return DequeueItem(out priority);
		}

		protected virtual TValue DequeueItem(out TPriority priority)
		{
			KeyValuePair<TPriority, LinkedList<TValue>> nextItem = GetNextItem();
			TValue value = nextItem.Value.First.Value;
			nextItem.Value.RemoveFirst();
			TPriority key = nextItem.Key;
			if (nextItem.Value.Count == 0)
			{
				tree.Remove(nextItem.Key);
			}
			Count--;
			priority = key;
			return value;
		}

		public bool Remove(TValue item, out TPriority priority)
		{
			return RemoveItem(item, out priority);
		}

		protected virtual bool RemoveItem(TValue item, out TPriority priority)
		{
			bool num = tree.Remove(item, out priority);
			if (num)
			{
				Count--;
			}
			return num;
		}

		public bool RemovePriorityGroup(TPriority priority)
		{
			return RemoveItems(priority);
		}

		protected virtual bool RemoveItems(TPriority priority)
		{
			LinkedList<TValue> value;
			if (tree.TryGetValue(priority, out value))
			{
				tree.Remove(priority);
				Count -= value.Count;
				return true;
			}
			return false;
		}

		public IList<TValue> GetPriorityGroup(TPriority priority)
		{
			LinkedList<TValue> value;
			if (!tree.TryGetValue(priority, out value))
			{
				return new List<TValue>();
			}
			return new List<TValue>(value);
		}

		public void AddPriorityGroup(IList<TValue> items, TPriority priority)
		{
			Guard.ArgumentNotNull(items, "items");
			AddPriorityGroupItem(items, priority);
		}

		protected virtual void AddPriorityGroupItem(IList<TValue> items, TPriority priority)
		{
			LinkedList<TValue> value;
			if (tree.TryGetValue(priority, out value))
			{
				for (int i = 0; i < items.Count; i++)
				{
					value.AddLast(items[i]);
				}
			}
			else
			{
				value = new LinkedList<TValue>(items);
				tree.Add(priority, value);
			}
		}

		protected virtual void AddItem(TValue item, TPriority priority)
		{
			LinkedList<TValue> value;
			if (tree.TryGetValue(priority, out value))
			{
				value.AddLast(item);
			}
			else
			{
				value = new LinkedList<TValue>();
				value.AddLast(item);
				tree.Add(priority, value);
			}
			Count++;
		}

		protected virtual void ClearItems()
		{
			tree.Clear();
			Count = 0;
		}

		private void CheckTreeNotEmpty()
		{
			if (tree.Count == 0)
			{
				throw new InvalidOperationException("The Priority Queue is empty.");
			}
		}

		private KeyValuePair<TPriority, LinkedList<TValue>> GetNextItem()
		{
			CheckTreeNotEmpty();
			if (queueType != PriorityQueueType.Maximum)
			{
				return tree.Minimum;
			}
			return tree.Maximum;
		}
	}
}
