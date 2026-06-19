using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TMPEffects.Tags.Collections
{
	internal class TagCollectionManager<TKey> : ITagCollection, IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable, ITagCollectionManager<TKey>, IReadOnlyDictionary<TKey, ObservableTagCollection>, IEnumerable<KeyValuePair<TKey, ObservableTagCollection>>, IReadOnlyCollection<KeyValuePair<TKey, ObservableTagCollection>>, INotifyCollectionChanged where TKey : ITMPPrefixSupplier, ITMPTagValidator
	{
		private class NonAdjustingTagCollection : ObservableTagCollection
		{
			public NonAdjustingTagCollection(ITMPTagValidator validator = null)
				: base(null, null)
			{
			}

			internal bool SetOrder(TMPEffectTag tag, TMPEffectTagIndices indices, int newOrder)
			{
				return false;
			}

			public override bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
			{
				return false;
			}

			public override bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
			{
				return false;
			}

			internal void SetItems(IEnumerable<TMPEffectTagTuple> items)
			{
			}
		}

		private NonAdjustingTagCollection union;

		private readonly Dictionary<TKey, ObservableTagCollection> collections;

		private readonly Dictionary<char, TKey> prefixToKey;

		private bool autoSync;

		public IEnumerable<TKey> Keys => null;

		public IEnumerable<ObservableTagCollection> Values => null;

		public int KeyCount => 0;

		int IReadOnlyCollection<KeyValuePair<TKey, ObservableTagCollection>>.Count => 0;

		ITagCollection ITagCollectionManager<TKey>.this[TKey key] => null;

		public ObservableTagCollection this[TKey key] => null;

		public int TagCount => 0;

		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public TagCollectionManager()
		{
		}

		public TagCollectionManager(params KeyValuePair<TKey, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>[] entries)
		{
		}

		ITagCollection ITagCollectionManager<TKey>.AddKey(TKey key)
		{
			return null;
		}

		public ObservableTagCollection AddKey(TKey key)
		{
			return null;
		}

		public bool RemoveKey(TKey key)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out ObservableTagCollection value)
		{
			value = null;
			return false;
		}

		IEnumerator<KeyValuePair<TKey, ObservableTagCollection>> IEnumerable<KeyValuePair<TKey, ObservableTagCollection>>.GetEnumerator()
		{
			return null;
		}

		public bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return false;
		}

		public bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
		{
			return false;
		}

		public int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			return 0;
		}

		public bool RemoveAt(int startIndex, int? order = null)
		{
			return false;
		}

		public bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public void Clear()
		{
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			return null;
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			return 0;
		}

		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			return null;
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			return null;
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private void ValidateIndices(int index)
		{
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
		}
	}
}
