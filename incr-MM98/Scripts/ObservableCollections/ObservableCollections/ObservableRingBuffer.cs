using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	public class ObservableRingBuffer<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IObservableCollection<T>
	{
		internal sealed class View<TView> : ISynchronizedView<T, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
		{
			private readonly IObservableCollection<T> source;

			private readonly Func<T, TView> selector;

			private readonly RingBuffer<(T, TView)> ringBuffer;

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
						return ringBuffer.Count;
					}
				}
			}

			public IEnumerable<(T Value, TView View)> Filtered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (var item in ringBuffer)
						{
							if (filter.IsMatch(item))
							{
								yield return item;
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
						foreach (var item in ringBuffer)
						{
							yield return item;
						}
					}
				}
			}

			public event NotifyViewChangedEventHandler<T, TView>? ViewChanged;

			public event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

			public event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

			public View(IObservableCollection<T> source, Func<T, TView> selector)
			{
				this.source = source;
				this.selector = selector;
				filter = SynchronizedViewFilter<T, TView>.Null;
				SyncRoot = new object();
				lock (source.SyncRoot)
				{
					ringBuffer = new RingBuffer<(T, TView)>(source.Select<T, (T, TView)>((T x) => (x: x, selector(x))));
					filteredCount = ringBuffer.Count;
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
					for (int i = 0; i < ringBuffer.Count; i++)
					{
						var (value, view) = ringBuffer[i];
						if (filter.IsMatch(value, view))
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
					filteredCount = ringBuffer.Count;
					this.ViewChanged?.Invoke(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
				}
			}

			public ISynchronizedViewList<TView> ToViewList()
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: true);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged()
			{
				lock (SyncRoot)
				{
					return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false);
				}
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher)
			{
				lock (SyncRoot)
				{
					return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, collectionEventDispatcher);
				}
			}

			public IEnumerator<TView> GetEnumerator()
			{
				lock (SyncRoot)
				{
					foreach (var item in ringBuffer)
					{
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
						if (e.NewStartingIndex == 0 && ringBuffer.Count != 0)
						{
							if (e.IsSingleItem)
							{
								(T, TView) tuple = (e.NewItem, selector(e.NewItem));
								ringBuffer.AddFirst(tuple);
								this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple, 0);
								break;
							}
							ReadOnlySpan<T> newItems = e.NewItems;
							for (int k = 0; k < newItems.Length; k++)
							{
								T val = newItems[k];
								(T, TView) tuple2 = (val, selector(val));
								ringBuffer.AddFirst(tuple2);
								this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple2, 0);
							}
						}
						else if (e.IsSingleItem)
						{
							(T, TView) tuple3 = (e.NewItem, selector(e.NewItem));
							ringBuffer.AddLast(tuple3);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple3, ringBuffer.Count - 1);
						}
						else
						{
							ReadOnlySpan<T> newItems = e.NewItems;
							for (int k = 0; k < newItems.Length; k++)
							{
								T val2 = newItems[k];
								(T, TView) tuple4 = (val2, selector(val2));
								ringBuffer.AddLast(tuple4);
								this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple4, ringBuffer.Count - 1);
							}
						}
						break;
					case NotifyCollectionChangedAction.Remove:
						if (e.OldStartingIndex == 0)
						{
							if (e.IsSingleItem)
							{
								(T, TView) value2 = ringBuffer.RemoveFirst();
								this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value2, 0);
								break;
							}
							for (int i = 0; i < e.OldItems.Length; i++)
							{
								(T, TView) value3 = ringBuffer.RemoveFirst();
								this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value3, 0);
							}
						}
						else if (e.IsSingleItem)
						{
							int oldIndex = ringBuffer.Count - 1;
							(T, TView) value4 = ringBuffer.RemoveLast();
							this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value4, oldIndex);
						}
						else
						{
							for (int j = 0; j < e.OldItems.Length; j++)
							{
								int oldIndex2 = ringBuffer.Count - 1;
								(T, TView) value5 = ringBuffer.RemoveLast();
								this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value5, oldIndex2);
							}
						}
						break;
					case NotifyCollectionChangedAction.Reset:
						ringBuffer.Clear();
						this.InvokeOnReset(ref filteredCount, this.ViewChanged);
						break;
					case NotifyCollectionChangedAction.Replace:
					{
						(T, TView) oldValue = ringBuffer[e.OldStartingIndex];
						(T, TView) value = (e.NewItem, selector(e.NewItem));
						ringBuffer[e.NewStartingIndex] = value;
						this.InvokeOnReplace(ref filteredCount, this.ViewChanged, value, oldValue, e.NewStartingIndex);
						break;
					}
					}
					this.CollectionStateChanged?.Invoke(e.Action);
				}
			}
		}

		private readonly RingBuffer<T> buffer;

		public bool IsReadOnly => false;

		public object SyncRoot { get; } = new object();

		public T this[int index]
		{
			get
			{
				lock (SyncRoot)
				{
					return buffer[index];
				}
			}
			set
			{
				lock (SyncRoot)
				{
					T oldItem = buffer[index];
					buffer[index] = value;
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Replace(value, oldItem, index, index));
				}
			}
		}

		public int Count
		{
			get
			{
				lock (SyncRoot)
				{
					return buffer.Count;
				}
			}
		}

		public event NotifyCollectionChangedEventHandler<T>? CollectionChanged;

		public ObservableRingBuffer()
		{
			buffer = new RingBuffer<T>();
		}

		public ObservableRingBuffer(IEnumerable<T> collection)
		{
			buffer = new RingBuffer<T>(collection);
		}

		public void AddFirst(T item)
		{
			lock (SyncRoot)
			{
				buffer.AddFirst(item);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, 0));
			}
		}

		public void AddLast(T item)
		{
			lock (SyncRoot)
			{
				buffer.AddLast(item);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, buffer.Count - 1));
			}
		}

		public T RemoveFirst()
		{
			lock (SyncRoot)
			{
				T val = buffer.RemoveFirst();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(val, 0));
				return val;
			}
		}

		public T RemoveLast()
		{
			lock (SyncRoot)
			{
				int oldStartingIndex = buffer.Count - 1;
				T val = buffer.RemoveLast();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(val, oldStartingIndex));
				return val;
			}
		}

		public void AddLastRange(IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				int count = buffer.Count;
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(items);
				ReadOnlySpan<T> span = cloneCollection.Span;
				for (int i = 0; i < span.Length; i++)
				{
					T item = span[i];
					buffer.AddLast(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(cloneCollection.Span, count));
			}
		}

		public void AddLastRange(T[] items)
		{
			lock (SyncRoot)
			{
				int count = buffer.Count;
				foreach (T item in items)
				{
					buffer.AddLast(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, count));
			}
		}

		public void AddLastRange(ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				int count = buffer.Count;
				ReadOnlySpan<T> readOnlySpan = items;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					T item = readOnlySpan[i];
					buffer.AddLast(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, count));
			}
		}

		public int IndexOf(T item)
		{
			lock (SyncRoot)
			{
				return buffer.IndexOf(item);
			}
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		void IList<T>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<T>.Add(T item)
		{
			AddLast(item);
		}

		public void Clear()
		{
			lock (SyncRoot)
			{
				buffer.Clear();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reset());
			}
		}

		public bool Contains(T item)
		{
			lock (SyncRoot)
			{
				return buffer.Contains(item);
			}
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			lock (SyncRoot)
			{
				buffer.CopyTo(array, arrayIndex);
			}
		}

		public T[] ToArray()
		{
			lock (SyncRoot)
			{
				return buffer.ToArray();
			}
		}

		public int BinarySearch(T item)
		{
			lock (SyncRoot)
			{
				return buffer.BinarySearch(item);
			}
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			lock (SyncRoot)
			{
				return buffer.BinarySearch(item, comparer);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			lock (SyncRoot)
			{
				foreach (T item in buffer)
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
