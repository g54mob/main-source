using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

namespace TMPEffects.Tags.Collections
{
	internal class CachedCollection<T> : IEnumerable<T>, IEnumerable where T : ITagWrapper
	{
		public class MinMax
		{
			public int MaxIndex;

			public int MinIndex;

			public MinMax(int textIndex)
			{
				MaxIndex = textIndex;
				MinIndex = textIndex;
			}
		}

		public struct StructReversedContainingEnumerable
		{
			private readonly List<T> pool;

			private int containedIndex;

			private int minIndex;

			private int maxIndex;

			public StructReversedContainingEnumerable(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = pool;
				this.containedIndex = containedIndex;
				this.minIndex = minIndex;
				this.maxIndex = maxIndex;
			}

			public StructReversedContainingEnumerator GetEnumerator()
			{
				return new StructReversedContainingEnumerator(pool, containedIndex, maxIndex, minIndex);
			}
		}

		public struct StructContainingEnumerable
		{
			private readonly List<T> pool;

			private int containedIndex;

			private int minIndex;

			private int maxIndex;

			public StructContainingEnumerable(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = pool;
				this.containedIndex = containedIndex;
				this.minIndex = minIndex;
				this.maxIndex = maxIndex;
			}

			public StructContainingEnumerator GetEnumerator()
			{
				return new StructContainingEnumerator(pool, containedIndex, maxIndex, minIndex);
			}
		}

		public struct StructReversedContainingEnumerator
		{
			private readonly List<T> pool;

			private readonly int containedIndex;

			private readonly int maxIndex;

			private readonly int minIndex;

			private int index;

			public T Current => pool[index];

			internal StructReversedContainingEnumerator(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = pool;
				this.containedIndex = containedIndex;
				index = maxIndex + 1;
				this.maxIndex = maxIndex;
				this.minIndex = minIndex;
			}

			public bool MoveNext()
			{
				if (pool == null)
				{
					return false;
				}
				while (--index >= minIndex && !pool[index].Indices.Contains(containedIndex))
				{
				}
				return minIndex <= index;
			}

			public void Reset()
			{
				index = maxIndex + 1;
			}
		}

		public struct StructContainingEnumerator
		{
			private readonly List<T> pool;

			private readonly int containedIndex;

			private readonly int maxIndex;

			private readonly int minIndex;

			private int index;

			public T Current => pool[index];

			internal StructContainingEnumerator(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = pool;
				this.containedIndex = containedIndex;
				index = minIndex - 1;
				this.maxIndex = maxIndex;
				this.minIndex = minIndex;
			}

			public bool MoveNext()
			{
				if (pool == null)
				{
					return false;
				}
				while (++index <= maxIndex && !pool[index].Indices.Contains(containedIndex))
				{
				}
				return maxIndex >= index;
			}

			public void Reset()
			{
				index = minIndex - 1;
			}
		}

		private Dictionary<int, MinMax> minMax = new Dictionary<int, MinMax>();

		private List<T> cache = new List<T>();

		private ITagCacher<T> cacher;

		private int max = int.MinValue;

		private int min = int.MaxValue;

		public int Count => cache.Count;

		public T this[int index] => cache[index];

		public CachedCollection(ITagCacher<T> cacher, ObservableTagCollection tagCollection)
		{
			if (cacher == null)
			{
				throw new ArgumentNullException("cacher");
			}
			if (tagCollection == null)
			{
				throw new ArgumentNullException("tagCollection");
			}
			this.cacher = cacher;
			List<T> list = new List<T>();
			foreach (TMPEffectTagTuple item in tagCollection)
			{
				list.Add(cacher.CacheTag(item.Tag, item.Indices));
			}
			int num = 0;
			foreach (TMPEffectTagTuple item2 in tagCollection)
			{
				_ = item2;
				Add(num, list[num]);
				num++;
			}
			tagCollection.CollectionChanged += OnCollectionChanged;
		}

		public MinMax MinMaxAt(int textIndex)
		{
			if (!minMax.TryGetValue(textIndex, out var value))
			{
				return null;
			}
			return value;
		}

		public bool HasAny()
		{
			return cache.Count > 0;
		}

		public bool HasAnyContaining(int textIndex)
		{
			if (textIndex < min)
			{
				return false;
			}
			if (textIndex > max)
			{
				return false;
			}
			return minMax.ContainsKey(textIndex);
		}

		public bool HasAnyAt(int index)
		{
			if (!minMax.TryGetValue(index, out var value))
			{
				return false;
			}
			for (int i = value.MinIndex; i <= value.MaxIndex; i++)
			{
				if (cache[i].Indices.StartIndex == index)
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<T> GetContaining(int textIndex)
		{
			if (!minMax.TryGetValue(textIndex, out var mm))
			{
				yield break;
			}
			for (int i = mm.MinIndex; i <= mm.MaxIndex; i++)
			{
				T val = cache[i];
				if (val.Indices.StartIndex > textIndex)
				{
					break;
				}
				if (val.Indices.Contains(textIndex))
				{
					yield return val;
				}
			}
		}

		public IEnumerable<T> GetAt(int textIndex)
		{
			if (!minMax.TryGetValue(textIndex, out var mm))
			{
				yield break;
			}
			for (int i = mm.MinIndex; i <= mm.MaxIndex; i++)
			{
				T val = cache[i];
				if (val.Indices.StartIndex > textIndex)
				{
					break;
				}
				if (val.Indices.StartIndex == textIndex)
				{
					yield return val;
				}
			}
		}

		public StructContainingEnumerable GetContaining_NonAlloc(int textIndex)
		{
			if (!minMax.TryGetValue(textIndex, out var value))
			{
				return new StructContainingEnumerable(null, 0, 0, 0);
			}
			return new StructContainingEnumerable(cache, textIndex, value.MaxIndex, value.MinIndex);
		}

		public StructReversedContainingEnumerable GetContainingReversed_NonAlloc(int textIndex)
		{
			if (!minMax.TryGetValue(textIndex, out var value))
			{
				return new StructReversedContainingEnumerable(null, 0, 0, 0);
			}
			return new StructReversedContainingEnumerable(cache, textIndex, value.MaxIndex, value.MinIndex);
		}

		private void Add(int cachedIndex, T tuple)
		{
			foreach (KeyValuePair<int, MinMax> item in minMax)
			{
				if (item.Value.MinIndex >= cachedIndex)
				{
					item.Value.MinIndex++;
				}
				if (item.Value.MaxIndex >= cachedIndex)
				{
					item.Value.MaxIndex++;
				}
			}
			for (int i = tuple.Indices.StartIndex; i < tuple.Indices.EndIndex; i++)
			{
				if (!minMax.TryGetValue(i, out var value))
				{
					minMax.Add(i, new MinMax(cachedIndex));
					continue;
				}
				if (value.MaxIndex < cachedIndex)
				{
					value.MaxIndex = cachedIndex;
				}
				if (value.MinIndex > cachedIndex)
				{
					value.MinIndex = cachedIndex;
				}
			}
			if (tuple.Indices.EndIndex > max)
			{
				max = tuple.Indices.EndIndex;
			}
			if (tuple.Indices.StartIndex < min)
			{
				min = tuple.Indices.StartIndex;
			}
			cache.Insert(cachedIndex, tuple);
		}

		private void Remove(int cachedIndex)
		{
			T val = cache[cachedIndex];
			for (int i = val.Indices.StartIndex; i < val.Indices.EndIndex; i++)
			{
				MinMax minMax = this.minMax[i];
				if (minMax.MinIndex == cachedIndex)
				{
					if (minMax.MaxIndex == cachedIndex)
					{
						this.minMax.Remove(i);
						continue;
					}
					bool flag = false;
					for (int j = minMax.MinIndex + 1; j <= minMax.MaxIndex; j++)
					{
						if (cache[j].Indices.Contains(i))
						{
							minMax.MinIndex = j;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						TMPEffectsBugReport.BugReportPrompt("Failed to find new min tag:\n" + new StackTrace());
					}
				}
				else
				{
					if (minMax.MaxIndex != cachedIndex)
					{
						continue;
					}
					bool flag2 = false;
					for (int num = minMax.MaxIndex - 1; num >= minMax.MinIndex; num--)
					{
						if (cache[num].Indices.Contains(i))
						{
							minMax.MaxIndex = num;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						TMPEffectsBugReport.BugReportPrompt("Failed to find new max tag:\n" + new StackTrace());
					}
				}
			}
			foreach (KeyValuePair<int, MinMax> item in this.minMax)
			{
				if (item.Value.MinIndex > cachedIndex)
				{
					item.Value.MinIndex--;
				}
				if (item.Value.MaxIndex > cachedIndex)
				{
					item.Value.MaxIndex--;
				}
			}
			cache.RemoveAt(cachedIndex);
			if (cache.Count == 0)
			{
				max = int.MinValue;
				min = int.MaxValue;
				return;
			}
			min = cache[0].Indices.StartIndex;
			if (val.Indices.EndIndex != max)
			{
				return;
			}
			max = int.MinValue;
			foreach (T item2 in cache)
			{
				if (item2.Indices.EndIndex > max)
				{
					max = item2.Indices.EndIndex;
				}
			}
		}

		private void Set(int cachedIndex, T tuple)
		{
			Remove(cachedIndex);
			Add(cachedIndex, tuple);
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				if (e.NewItems.Count > 1)
				{
					UnityEngine.Debug.LogWarning("Added more than one element; Should be impossible");
				}
				TMPEffectTagTuple tMPEffectTagTuple = (TMPEffectTagTuple)e.NewItems[0];
				Add(e.NewStartingIndex, cacher.CacheTag(tMPEffectTagTuple.Tag, tMPEffectTagTuple.Indices));
				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				int newStartingIndex = e.OldStartingIndex;
				for (int j = 0; j < e.OldItems.Count; j++)
				{
					Remove(newStartingIndex);
				}
				break;
			}
			case NotifyCollectionChangedAction.Reset:
				cache.TrimExcess();
				minMax.TrimExcess();
				cache.Clear();
				minMax.Clear();
				break;
			case NotifyCollectionChangedAction.Move:
				throw new NotImplementedException();
			case NotifyCollectionChangedAction.Replace:
			{
				int newStartingIndex = e.NewStartingIndex;
				for (int i = 0; i < e.NewItems.Count; i++)
				{
					TMPEffectTagTuple tMPEffectTagTuple = (TMPEffectTagTuple)e.NewItems[i];
					Set(newStartingIndex + i, cacher.CacheTag(tMPEffectTagTuple.Tag, tMPEffectTagTuple.Indices));
				}
				break;
			}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return cache.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return cache.GetEnumerator();
		}
	}
}
