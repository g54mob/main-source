using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ObservableCollections
{
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyObservableDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IObservableCollection<KeyValuePair<TKey, TValue>> where TKey : notnull
	{
		private class View<TView> : ISynchronizedView<KeyValuePair<TKey, TValue>, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
		{
			private readonly ObservableDictionary<TKey, TValue> source;

			private readonly Func<KeyValuePair<TKey, TValue>, TView> selector;

			private ISynchronizedViewFilter<KeyValuePair<TKey, TValue>, TView> filter;

			private readonly Dictionary<TKey, (TValue, TView)> dict;

			private int filteredCount;

			public object SyncRoot { get; }

			public ISynchronizedViewFilter<KeyValuePair<TKey, TValue>, TView> Filter
			{
				get
				{
					lock (SyncRoot)
					{
						return filter;
					}
				}
			}

			public int Count
			{
				get
				{
					lock (SyncRoot)
					{
						return filteredCount;
					}
				}
			}

			public int UnfilteredCount
			{
				get
				{
					lock (SyncRoot)
					{
						return dict.Count;
					}
				}
			}

			public IEnumerable<(KeyValuePair<TKey, TValue> Value, TView View)> Filtered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (KeyValuePair<TKey, (TValue, TView)> item in dict)
						{
							(KeyValuePair<TKey, TValue>, TView) tuple = (new KeyValuePair<TKey, TValue>(item.Key, item.Value.Item1), item.Value.Item2);
							if (filter.IsMatch(tuple))
							{
								yield return tuple;
							}
						}
					}
				}
			}

			public IEnumerable<(KeyValuePair<TKey, TValue> Value, TView View)> Unfiltered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (KeyValuePair<TKey, (TValue, TView)> item in dict)
						{
							yield return (Value: new KeyValuePair<TKey, TValue>(item.Key, item.Value.Item1), View: item.Value.Item2);
						}
					}
				}
			}

			public event NotifyViewChangedEventHandler<KeyValuePair<TKey, TValue>, TView>? ViewChanged;

			public event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

			public event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

			public View(ObservableDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TView> selector)
			{
				this.source = source;
				this.selector = selector;
				filter = SynchronizedViewFilter<KeyValuePair<TKey, TValue>, TView>.Null;
				SyncRoot = new object();
				lock (source.SyncRoot)
				{
					dict = source.dictionary.ToDictionary<KeyValuePair<TKey, TValue>, TKey, (TValue, TView)>((KeyValuePair<TKey, TValue> x) => x.Key, (KeyValuePair<TKey, TValue> x) => (Value: x.Value, selector(x)));
					filteredCount = dict.Count;
					this.source.CollectionChanged += SourceCollectionChanged;
				}
			}

			public void Dispose()
			{
				source.CollectionChanged -= SourceCollectionChanged;
			}

			public void AttachFilter(ISynchronizedViewFilter<KeyValuePair<TKey, TValue>, TView> filter)
			{
				if (filter.IsNullFilter())
				{
					ResetFilter();
					return;
				}
				lock (SyncRoot)
				{
					this.filter = filter;
					filteredCount = 0;
					foreach (KeyValuePair<TKey, (TValue, TView)> item in dict)
					{
						KeyValuePair<TKey, TValue> value = new KeyValuePair<TKey, TValue>(item.Key, item.Value.Item1);
						if (filter.IsMatch(value, item.Value.Item2))
						{
							filteredCount++;
						}
					}
					this.ViewChanged?.Invoke(new SynchronizedViewChangedEventArgs<KeyValuePair<TKey, TValue>, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
				}
			}

			public void ResetFilter()
			{
				lock (SyncRoot)
				{
					filter = SynchronizedViewFilter<KeyValuePair<TKey, TValue>, TView>.Null;
					filteredCount = dict.Count;
					this.ViewChanged?.Invoke(new SynchronizedViewChangedEventArgs<KeyValuePair<TKey, TValue>, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
				}
			}

			public ISynchronizedViewList<TView> ToViewList()
			{
				return new FiltableSynchronizedViewList<KeyValuePair<TKey, TValue>, TView>(this, isSupportRangeFeature: true);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged()
			{
				return new FiltableSynchronizedViewList<KeyValuePair<TKey, TValue>, TView>(this, isSupportRangeFeature: false);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher)
			{
				return new FiltableSynchronizedViewList<KeyValuePair<TKey, TValue>, TView>(this, isSupportRangeFeature: false, collectionEventDispatcher);
			}

			public IEnumerator<TView> GetEnumerator()
			{
				lock (SyncRoot)
				{
					foreach (KeyValuePair<TKey, (TValue, TView)> item2 in dict)
					{
						(KeyValuePair<TKey, TValue>, TView) item = (new KeyValuePair<TKey, TValue>(item2.Key, item2.Value.Item1), item2.Value.Item2);
						if (filter.IsMatch(item))
						{
							yield return item.Item2;
						}
					}
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			private void SourceCollectionChanged(in NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>> e)
			{
				lock (SyncRoot)
				{
					switch (e.Action)
					{
					case NotifyCollectionChangedAction.Add:
					{
						TView val2 = selector(e.NewItem);
						dict.Add(e.NewItem.Key, (e.NewItem.Value, val2));
						this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, e.NewItem, val2, -1);
						break;
					}
					case NotifyCollectionChangedAction.Remove:
					{
						if (dict.Remove(e.OldItem.Key, out var value2))
						{
							this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, e.OldItem, value2.Item2, -1);
						}
						break;
					}
					case NotifyCollectionChangedAction.Replace:
					{
						TView val = selector(e.NewItem);
						dict.Remove(e.OldItem.Key, out var value);
						dict[e.NewItem.Key] = (e.NewItem.Value, val);
						this.InvokeOnReplace(ref filteredCount, this.ViewChanged, e.NewItem, val, e.OldItem, value.Item2, -1);
						break;
					}
					case NotifyCollectionChangedAction.Reset:
						dict.Clear();
						this.InvokeOnReset(ref filteredCount, this.ViewChanged);
						break;
					}
					this.CollectionStateChanged?.Invoke(e.Action);
				}
			}
		}

		private readonly Dictionary<TKey, TValue> dictionary;

		public object SyncRoot { get; } = new object();

		public TValue this[TKey key]
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary[key];
				}
			}
			set
			{
				lock (SyncRoot)
				{
					if (dictionary.TryGetValue(key, out var value2))
					{
						dictionary[key] = value;
						this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>>.Replace(new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, value2), -1, -1));
					}
					else
					{
						Add(key, value);
					}
				}
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Keys;
				}
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Values;
				}
			}
		}

		public int Count
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Count;
				}
			}
		}

		public bool IsReadOnly => false;

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Keys;
				}
			}
		}

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Values;
				}
			}
		}

		public IEqualityComparer<TKey> Comparer
		{
			get
			{
				lock (SyncRoot)
				{
					return dictionary.Comparer;
				}
			}
		}

		public event NotifyCollectionChangedEventHandler<KeyValuePair<TKey, TValue>>? CollectionChanged;

		public ObservableDictionary()
		{
			dictionary = new Dictionary<TKey, TValue>();
		}

		public ObservableDictionary(IEqualityComparer<TKey>? comparer)
		{
			dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey>? comparer)
		{
			dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
			: this(collection, (IEqualityComparer<TKey>?)null)
		{
		}

		public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer)
		{
			dictionary = new Dictionary<TKey, TValue>(collection, comparer);
		}

		public void Add(TKey key, TValue value)
		{
			lock (SyncRoot)
			{
				dictionary.Add(key, value);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>>.Add(new KeyValuePair<TKey, TValue>(key, value), -1));
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			lock (SyncRoot)
			{
				dictionary.Clear();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>>.Reset());
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			lock (SyncRoot)
			{
				return ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Contains(item);
			}
		}

		public bool ContainsKey(TKey key)
		{
			lock (SyncRoot)
			{
				return ((IDictionary<TKey, TValue>)dictionary).ContainsKey(key);
			}
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			lock (SyncRoot)
			{
				((ICollection<KeyValuePair<TKey, TValue>>)dictionary).CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(TKey key)
		{
			lock (SyncRoot)
			{
				if (dictionary.Remove(key, out var value))
				{
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>>.Remove(new KeyValuePair<TKey, TValue>(key, value), -1));
					return true;
				}
				return false;
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			lock (SyncRoot)
			{
				if (dictionary.TryGetValue(item.Key, out var value) && EqualityComparer<TValue>.Default.Equals(value, item.Value) && dictionary.Remove(item.Key, out var value2))
				{
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<KeyValuePair<TKey, TValue>>.Remove(new KeyValuePair<TKey, TValue>(item.Key, value2), -1));
					return true;
				}
				return false;
			}
		}

		public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
		{
			lock (SyncRoot)
			{
				return dictionary.TryGetValue(key, out value);
			}
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			lock (SyncRoot)
			{
				foreach (KeyValuePair<TKey, TValue> item in dictionary)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public ISynchronizedView<KeyValuePair<TKey, TValue>, TView> CreateView<TView>(Func<KeyValuePair<TKey, TValue>, TView> transform)
		{
			return new View<TView>(this, transform);
		}
	}
}
