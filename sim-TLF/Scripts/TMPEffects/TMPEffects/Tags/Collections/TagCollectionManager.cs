using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

namespace TMPEffects.Tags.Collections
{
	internal class TagCollectionManager<TKey> : ITagCollection, IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable, ITagCollectionManager<TKey>, IReadOnlyDictionary<TKey, ObservableTagCollection>, IEnumerable<KeyValuePair<TKey, ObservableTagCollection>>, IReadOnlyCollection<KeyValuePair<TKey, ObservableTagCollection>>, INotifyCollectionChanged where TKey : ITMPPrefixSupplier, ITMPTagValidator
	{
		private class NonAdjustingTagCollection : ObservableTagCollection
		{
			public NonAdjustingTagCollection(ITMPTagValidator validator = null)
				: base(validator)
			{
			}

			internal bool SetOrder(TMPEffectTag tag, TMPEffectTagIndices indices, int newOrder)
			{
				int num;
				if ((num = BinarySearchIndexOf(indices)) < 0)
				{
					return false;
				}
				while (tag != tags[num].Tag && tags[num].Indices.StartIndex == indices.StartIndex)
				{
					num++;
					if (num >= tags.Count)
					{
						break;
					}
				}
				if (num == tags.Count || tags[num].Indices.StartIndex != indices.StartIndex)
				{
					return false;
				}
				TMPEffectTagTuple tMPEffectTagTuple = tags[num];
				tags[num] = new TMPEffectTagTuple(tag, new TMPEffectTagIndices(indices.StartIndex, indices.EndIndex, newOrder));
				InvokeEvent(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, tMPEffectTagTuple, tags[num], num));
				return true;
			}

			public override bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
			{
				if (validator != null && !validator.ValidateTag(tag))
				{
					return false;
				}
				int num;
				if ((num = BinarySearchIndexOf(indices)) < 0)
				{
					num = ~num;
				}
				tags.Insert(num, new TMPEffectTagTuple(tag, indices));
				InvokeEvent(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, tags[num], num));
				return true;
			}

			public override bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
			{
				if (validator != null && !validator.ValidateTag(tag))
				{
					return false;
				}
				int num;
				TMPEffectTagIndices indices;
				if (!orderAtIndex.HasValue)
				{
					num = BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex));
					if (num < 0)
					{
						num = ~num;
						indices = new TMPEffectTagIndices(startIndex, endIndex, 0);
					}
					else
					{
						indices = new TMPEffectTagIndices(startIndex, endIndex, tags[num].Indices.OrderAtIndex - 1);
					}
				}
				else
				{
					num = BinarySearchIndexOf(new TempIndices(startIndex, orderAtIndex.Value));
					indices = new TMPEffectTagIndices(startIndex, endIndex, orderAtIndex.Value);
					if (num < 0)
					{
						num = ~num;
					}
				}
				tags.Insert(num, new TMPEffectTagTuple(tag, indices));
				InvokeEvent(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, tags[num], num));
				return true;
			}

			internal void SetItems(IEnumerable<TMPEffectTagTuple> items)
			{
				tags.Clear();
				foreach (TMPEffectTagTuple item in items)
				{
					tags.Add(item);
				}
			}
		}

		private NonAdjustingTagCollection union;

		private readonly Dictionary<TKey, ObservableTagCollection> collections;

		private readonly Dictionary<char, TKey> prefixToKey;

		private bool autoSync;

		public IEnumerable<TKey> Keys => collections.Keys;

		public IEnumerable<ObservableTagCollection> Values => collections.Values;

		public int KeyCount => collections.Count;

		int IReadOnlyCollection<KeyValuePair<TKey, ObservableTagCollection>>.Count => collections.Count;

		ITagCollection ITagCollectionManager<TKey>.this[TKey key] => collections[key];

		public ObservableTagCollection this[TKey key] => collections[key];

		public int TagCount => union.TagCount;

		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			add
			{
				union.CollectionChanged += value;
			}
			remove
			{
				union.CollectionChanged -= value;
			}
		}

		public TagCollectionManager()
		{
			union = new NonAdjustingTagCollection();
			collections = new Dictionary<TKey, ObservableTagCollection>();
			prefixToKey = new Dictionary<char, TKey>();
			autoSync = false;
		}

		public TagCollectionManager(params KeyValuePair<TKey, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>[] entries)
		{
			List<TMPEffectTagTuple> list = new List<TMPEffectTagTuple>();
			KeyValuePair<TKey, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>[] array = entries;
			foreach (KeyValuePair<TKey, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair in array)
			{
				foreach (KeyValuePair<TMPEffectTagIndices, TMPEffectTag> item in keyValuePair.Value)
				{
					list.Add(new TMPEffectTagTuple(item.Value, item.Key));
				}
			}
			list = list.OrderBy((TMPEffectTagTuple x) => x.Indices).ToList();
			union = new NonAdjustingTagCollection();
			union.SetItems(list);
			collections = new Dictionary<TKey, ObservableTagCollection>();
			prefixToKey = new Dictionary<char, TKey>();
			array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<TKey, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair2 = array[i];
				if (keyValuePair2.Key == null)
				{
					throw new ArgumentNullException("Key");
				}
				if (collections.ContainsKey(keyValuePair2.Key))
				{
					throw new ArgumentException("Key");
				}
				if (prefixToKey.ContainsKey(keyValuePair2.Key.Prefix))
				{
					throw new ArgumentException("Prefix");
				}
				NonAdjustingTagCollection nonAdjustingTagCollection = new NonAdjustingTagCollection(keyValuePair2.Key);
				nonAdjustingTagCollection.SetItems(keyValuePair2.Value.Select((KeyValuePair<TMPEffectTagIndices, TMPEffectTag> x) => new TMPEffectTagTuple(x.Value, x.Key)));
				prefixToKey.Add(keyValuePair2.Key.Prefix, keyValuePair2.Key);
				collections.Add(keyValuePair2.Key, nonAdjustingTagCollection);
				nonAdjustingTagCollection.CollectionChanged += OnCollectionChanged;
			}
		}

		ITagCollection ITagCollectionManager<TKey>.AddKey(TKey key)
		{
			return AddKey(key);
		}

		public ObservableTagCollection AddKey(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (collections.ContainsKey(key))
			{
				throw new ArgumentException("key");
			}
			if (prefixToKey.ContainsKey(key.Prefix))
			{
				throw new ArgumentException("Prefix");
			}
			ObservableTagCollection observableTagCollection = new NonAdjustingTagCollection(key);
			observableTagCollection.CollectionChanged += OnCollectionChanged;
			prefixToKey.Add(key.Prefix, key);
			collections.Add(key, observableTagCollection);
			return observableTagCollection;
		}

		public bool RemoveKey(TKey key)
		{
			if (!collections.ContainsKey(key))
			{
				return false;
			}
			collections[key].CollectionChanged -= OnCollectionChanged;
			collections.Remove(key);
			prefixToKey.Remove(key.Prefix);
			return true;
		}

		public bool ContainsKey(TKey key)
		{
			return collections.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out ObservableTagCollection value)
		{
			return collections.TryGetValue(key, out value);
		}

		IEnumerator<KeyValuePair<TKey, ObservableTagCollection>> IEnumerable<KeyValuePair<TKey, ObservableTagCollection>>.GetEnumerator()
		{
			return collections.GetEnumerator();
		}

		public bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return TryAdd(tag, indices.StartIndex, indices.EndIndex, indices.OrderAtIndex);
		}

		public bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
		{
			try
			{
				autoSync = true;
				if (!prefixToKey.TryGetValue(tag.Prefix, out var value))
				{
					return false;
				}
				if (!collections[value].TryAdd(tag, startIndex, endIndex, orderAtIndex))
				{
					return false;
				}
				if (!union.TryAdd(tag, startIndex, endIndex, orderAtIndex))
				{
					Debug.LogError("Added to collection but failed to add to union; now undefined");
					return false;
				}
				ValidateIndices(startIndex);
				return true;
			}
			finally
			{
				autoSync = false;
			}
		}

		public int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			try
			{
				autoSync = true;
				foreach (ObservableTagCollection value in collections.Values)
				{
					value.RemoveAllAt(startIndex);
				}
				return union.RemoveAllAt(startIndex, buffer, bufferIndex);
			}
			finally
			{
				autoSync = false;
			}
		}

		public bool RemoveAt(int startIndex, int? order = null)
		{
			TMPEffectTag tMPEffectTag = union.TagAt(startIndex, order);
			if (tMPEffectTag == null)
			{
				return false;
			}
			return Remove(tMPEffectTag);
		}

		public bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			if (!prefixToKey.TryGetValue(tag.Prefix, out var value))
			{
				return false;
			}
			try
			{
				autoSync = true;
				if (collections[value].Remove(tag, indices))
				{
					if (!union.Remove(tag, indices))
					{
						Debug.LogError("Failed to remove from union but did remove from subcollection; now undefined");
					}
					return true;
				}
				return false;
			}
			finally
			{
				autoSync = false;
			}
		}

		public void Clear()
		{
			try
			{
				autoSync = true;
				union.Clear();
				foreach (ObservableTagCollection value in collections.Values)
				{
					value.Clear();
				}
			}
			finally
			{
				autoSync = false;
			}
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return union.Contains(tag, indices);
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			return union.IndicesOf(tag);
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			return union.TagsAt(startIndex, buffer, bufferIndex);
		}

		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			return union.TagsAt(startIndex);
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			return union.TagAt(startIndex, order);
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return union.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return union.GetEnumerator();
		}

		private void ValidateIndices(int index)
		{
			List<TMPEffectTagTuple> list = union.ToList();
			if (list.Count == 0)
			{
				return;
			}
			bool flag = autoSync;
			try
			{
				autoSync = true;
				int i;
				for (i = 0; i < list.Count && list[i].Indices.StartIndex != index; i++)
				{
					if (list[i].Indices.StartIndex > index)
					{
						return;
					}
				}
				int num = list[i].Indices.OrderAtIndex;
				for (i++; i < list.Count; i++)
				{
					TMPEffectTagTuple tMPEffectTagTuple = list[i];
					if (tMPEffectTagTuple.Indices.StartIndex != index)
					{
						break;
					}
					if (tMPEffectTagTuple.Indices.OrderAtIndex <= num)
					{
						num++;
						if (!union.SetOrder(tMPEffectTagTuple.Tag, tMPEffectTagTuple.Indices, num))
						{
							Debug.LogError("Failed to set order in union; now undefined");
						}
						if (!(collections[prefixToKey[tMPEffectTagTuple.Tag.Prefix]] as NonAdjustingTagCollection).SetOrder(tMPEffectTagTuple.Tag, tMPEffectTagTuple.Indices, num))
						{
							Debug.LogError("Failed to set order in subcollection; now undefined");
						}
					}
					else
					{
						num = tMPEffectTagTuple.Indices.OrderAtIndex;
					}
				}
			}
			finally
			{
				autoSync = flag;
			}
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (autoSync)
			{
				return;
			}
			switch (args.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				TMPEffectTagTuple tMPEffectTagTuple = (TMPEffectTagTuple)args.NewItems[0];
				if (!union.TryAdd(tMPEffectTagTuple.Tag, tMPEffectTagTuple.Indices))
				{
					Debug.LogError("Failed to add to union; now undefined");
				}
				ValidateIndices(((TMPEffectTagTuple)args.NewItems[0]).Indices.StartIndex);
				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				foreach (TMPEffectTagTuple oldItem in args.OldItems)
				{
					if (!union.RemoveAt(oldItem.Indices.StartIndex, oldItem.Indices.OrderAtIndex))
					{
						Debug.LogError("Failed to remove from union; now undefined");
					}
				}
				break;
			}
			case NotifyCollectionChangedAction.Reset:
			{
				IEnumerable<TMPEffectTagTuple> enumerable = new List<TMPEffectTagTuple>();
				foreach (ObservableTagCollection value in collections.Values)
				{
					enumerable.Concat(value);
				}
				enumerable = enumerable.OrderBy((TMPEffectTagTuple x) => x.Indices).ToList();
				union = new NonAdjustingTagCollection();
				{
					foreach (TMPEffectTagTuple item in enumerable)
					{
						if (!union.TryAdd(item.Tag, item.Indices))
						{
							Debug.LogError("Failed to add tag to union; Now undefined");
						}
					}
					break;
				}
			}
			case NotifyCollectionChangedAction.Move:
				throw new NotImplementedException();
			case NotifyCollectionChangedAction.Replace:
				throw new NotImplementedException();
			}
		}
	}
}
