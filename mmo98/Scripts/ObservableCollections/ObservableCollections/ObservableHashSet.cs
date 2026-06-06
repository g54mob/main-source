using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	public class ObservableHashSet<T> : IReadOnlySet<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IObservableCollection<T> where T : notnull
	{
		private sealed class View<TView> : ISynchronizedView<T, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
		{
			private readonly ObservableHashSet<T> source;

			private readonly Func<T, TView> selector;

			private readonly Dictionary<T, (T, TView)> dict;

			private int filteredCount;

			private ISynchronizedViewFilter<T, TView> filter;

			public ISynchronizedViewFilter<T, TView> Filter
			{
				get
				{
					lock (SyncRoot)
					{
						return filter;
					}
				}
			}

			public object SyncRoot { get; }

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

			public IEnumerable<(T Value, TView View)> Filtered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (KeyValuePair<T, (T, TView)> item in dict)
						{
							if (filter.IsMatch(item.Value))
							{
								yield return item.Value;
							}
						}
					}
				}
			}

			public IEnumerable<(T Value, TView View)> Unfiltered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (KeyValuePair<T, (T, TView)> item in dict)
						{
							yield return item.Value;
						}
					}
				}
			}

			public event NotifyViewChangedEventHandler<T, TView>? ViewChanged;

			public event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

			public event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

			public View(ObservableHashSet<T> source, Func<T, TView> selector)
			{
				this.source = source;
				this.selector = selector;
				filter = SynchronizedViewFilter<T, TView>.Null;
				SyncRoot = new object();
				lock (source.SyncRoot)
				{
					dict = source.set.ToDictionary<T, T, (T, TView)>((T x) => x, (T x) => (x: x, selector(x)));
					filteredCount = dict.Count;
					this.source.CollectionChanged += SourceCollectionChanged;
				}
			}

			public void AttachFilter(ISynchronizedViewFilter<T, TView> filter)
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
					foreach (KeyValuePair<T, (T, TView)> item in dict)
					{
						item.Deconstruct(out var _, out var value);
						var (value2, view) = value;
						if (filter.IsMatch(value2, view))
						{
							filteredCount++;
						}
					}
					this.ViewChanged?.Invoke(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
				}
			}

			public void ResetFilter()
			{
				lock (SyncRoot)
				{
					filter = SynchronizedViewFilter<T, TView>.Null;
					filteredCount = dict.Count;
					this.ViewChanged?.Invoke(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
				}
			}

			public ISynchronizedViewList<TView> ToViewList()
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: true);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged()
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher)
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, collectionEventDispatcher);
			}

			public IEnumerator<TView> GetEnumerator()
			{
				lock (SyncRoot)
				{
					foreach (KeyValuePair<T, (T, TView)> item in dict)
					{
						if (filter.IsMatch(item.Value))
						{
							yield return item.Value.Item2;
						}
					}
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Dispose()
			{
				source.CollectionChanged -= SourceCollectionChanged;
			}

			private void SourceCollectionChanged(in NotifyCollectionChangedEventArgs<T> e)
			{
				lock (SyncRoot)
				{
					switch (e.Action)
					{
					case NotifyCollectionChangedAction.Add:
					{
						if (e.IsSingleItem)
						{
							(T, TView) value3 = (e.NewItem, selector(e.NewItem));
							dict.Add(e.NewItem, value3);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value3, -1);
							break;
						}
						int newStartingIndex = e.NewStartingIndex;
						ReadOnlySpan<T> oldItems = e.NewItems;
						for (int i = 0; i < oldItems.Length; i++)
						{
							T val = oldItems[i];
							(T, TView) value4 = (val, selector(val));
							dict.Add(val, value4);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value4, newStartingIndex++);
						}
						break;
					}
					case NotifyCollectionChangedAction.Remove:
					{
						if (e.IsSingleItem)
						{
							if (dict.Remove(e.OldItem, out var value))
							{
								this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value, -1);
							}
							break;
						}
						ReadOnlySpan<T> oldItems = e.OldItems;
						for (int i = 0; i < oldItems.Length; i++)
						{
							T key = oldItems[i];
							if (dict.Remove(key, out var value2))
							{
								this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value2, -1);
							}
						}
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

		private readonly HashSet<T> set;

		public object SyncRoot { get; } = new object();

		public int Count
		{
			get
			{
				lock (SyncRoot)
				{
					return set.Count;
				}
			}
		}

		public bool IsReadOnly => false;

		public IEqualityComparer<T> Comparer
		{
			get
			{
				lock (SyncRoot)
				{
					return set.Comparer;
				}
			}
		}

		public event NotifyCollectionChangedEventHandler<T>? CollectionChanged;

		public ObservableHashSet()
		{
			set = new HashSet<T>();
		}

		public ObservableHashSet(IEqualityComparer<T>? comparer)
		{
			set = new HashSet<T>(comparer);
		}

		public ObservableHashSet(int capacity)
		{
			set = new HashSet<T>(capacity);
		}

		public ObservableHashSet(int capacity, IEqualityComparer<T>? comparer)
		{
			set = new HashSet<T>(capacity, comparer);
		}

		public ObservableHashSet(IEnumerable<T> collection)
		{
			set = new HashSet<T>(collection);
		}

		public ObservableHashSet(IEnumerable<T> collection, IEqualityComparer<T>? comparer)
		{
			set = new HashSet<T>(collection, comparer);
		}

		public bool Add(T item)
		{
			lock (SyncRoot)
			{
				if (set.Add(item))
				{
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, -1));
					return true;
				}
				return false;
			}
		}

		public void AddRange(IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				if (!items.TryGetNonEnumeratedCount(out var count))
				{
					count = 4;
				}
				using ResizableArray<T> resizableArray = new ResizableArray<T>(count);
				foreach (T item in items)
				{
					if (set.Add(item))
					{
						resizableArray.Add(item);
					}
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(resizableArray.Span, -1));
			}
		}

		public void AddRange(T[] items)
		{
			AddRange(items.AsSpan());
		}

		public void AddRange(ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				using ResizableArray<T> resizableArray = new ResizableArray<T>(items.Length);
				ReadOnlySpan<T> readOnlySpan = items;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					T item = readOnlySpan[i];
					if (set.Add(item))
					{
						resizableArray.Add(item);
					}
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(resizableArray.Span, -1));
			}
		}

		public bool Remove(T item)
		{
			lock (SyncRoot)
			{
				if (set.Remove(item))
				{
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(item, -1));
					return true;
				}
				return false;
			}
		}

		public void RemoveRange(IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				if (!items.TryGetNonEnumeratedCount(out var count))
				{
					count = 4;
				}
				using ResizableArray<T> resizableArray = new ResizableArray<T>(count);
				foreach (T item in items)
				{
					if (set.Remove(item))
					{
						resizableArray.Add(item);
					}
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(resizableArray.Span, -1));
			}
		}

		public void RemoveRange(T[] items)
		{
			RemoveRange(items.AsSpan());
		}

		public void RemoveRange(ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				using ResizableArray<T> resizableArray = new ResizableArray<T>(items.Length);
				ReadOnlySpan<T> readOnlySpan = items;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					T item = readOnlySpan[i];
					if (set.Remove(item))
					{
						resizableArray.Add(item);
					}
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(resizableArray.Span, -1));
			}
		}

		public void Clear()
		{
			lock (SyncRoot)
			{
				set.Clear();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reset());
			}
		}

		public bool TryGetValue(T equalValue, [MaybeNullWhen(false)] out T actualValue)
		{
			lock (SyncRoot)
			{
				return set.TryGetValue(equalValue, out actualValue);
			}
		}

		public bool Contains(T item)
		{
			lock (SyncRoot)
			{
				return set.Contains(item);
			}
		}

		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.IsProperSubsetOf(other);
			}
		}

		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.IsProperSupersetOf(other);
			}
		}

		public bool IsSubsetOf(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.IsSubsetOf(other);
			}
		}

		public bool IsSupersetOf(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.IsSupersetOf(other);
			}
		}

		public bool Overlaps(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.Overlaps(other);
			}
		}

		public bool SetEquals(IEnumerable<T> other)
		{
			lock (SyncRoot)
			{
				return set.SetEquals(other);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			lock (SyncRoot)
			{
				foreach (T item in set)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public ISynchronizedView<T, TView> CreateView<TView>(Func<T, TView> transform)
		{
			return new View<TView>(this, transform);
		}
	}
}
