using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	public class ObservableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyObservableList<T>, IReadOnlyList<T>, IReadOnlyCollection<T>, IObservableCollection<T>
	{
		internal sealed class View<TView> : ISynchronizedView<T, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable, IWritableSynchronizedView<T, TView>
		{
			private sealed class IgnoreViewComparer : IComparer<(T, TView)>
			{
				private readonly IComparer<T> comparer;

				public IgnoreViewComparer(IComparer<T> comparer)
				{
					this.comparer = comparer;
				}

				public int Compare((T, TView) x, (T, TView) y)
				{
					return comparer.Compare(x.Item1, y.Item1);
				}
			}

			private readonly ObservableList<T> source;

			private readonly Func<T, TView> selector;

			internal readonly List<(T, TView)> list;

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
						return list.Count;
					}
				}
			}

			public IEnumerable<(T Value, TView View)> Filtered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (var item in list)
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
						foreach (var item in list)
						{
							yield return item;
						}
					}
				}
			}

			public event NotifyViewChangedEventHandler<T, TView>? ViewChanged;

			public event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

			public event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

			public View(ObservableList<T> source, Func<T, TView> selector)
			{
				this.source = source;
				this.selector = selector;
				filter = SynchronizedViewFilter<T, TView>.Null;
				SyncRoot = new object();
				lock (source.SyncRoot)
				{
					list = source.list.Select<T, (T, TView)>((T x) => (x: x, selector(x))).ToList();
					filteredCount = list.Count;
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
					for (int i = 0; i < list.Count; i++)
					{
						if (filter.IsMatch(list[i]))
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
					filteredCount = list.Count;
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
					foreach (var item in list)
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
					{
						if (e.IsSingleItem)
						{
							(T, TView) tuple = (e.NewItem, selector(e.NewItem));
							list.Insert(e.NewStartingIndex, tuple);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple, e.NewStartingIndex);
							break;
						}
						ReadOnlySpan<T> newItems = e.NewItems;
						int length = newItems.Length;
						FixedArray<(T, TView)> fixedArray = new FixedArray<(T, TView)>(length);
						try
						{
							FixedArray<TView> fixedArray2 = new FixedArray<TView>(length);
							try
							{
								Span<bool> scratchBuffer = ((length >= 128) ? default(Span<bool>) : stackalloc bool[length]);
								FixedBoolArray fixedBoolArray = new FixedBoolArray(scratchBuffer, length);
								try
								{
									bool isMatchAll = true;
									for (int i = 0; i < newItems.Length; i++)
									{
										T val = newItems[i];
										TView val2 = selector(val);
										fixedArray2.Span[i] = val2;
										fixedArray.Span[i] = (val, val2);
										if (fixedBoolArray.Span[i] = Filter.IsMatch(val, val2))
										{
											filteredCount++;
										}
										else
										{
											isMatchAll = false;
										}
									}
									list.InsertRange(e.NewStartingIndex, fixedArray.Span);
									this.InvokeOnAddRange(this.ViewChanged, this.RejectedViewChanged, e.NewItems, fixedArray2.Span, isMatchAll, fixedBoolArray.Span, e.NewStartingIndex);
								}
								finally
								{
									fixedBoolArray.Dispose();
								}
							}
							finally
							{
								fixedArray2.Dispose();
							}
						}
						finally
						{
							fixedArray.Dispose();
						}
						break;
					}
					case NotifyCollectionChangedAction.Remove:
					{
						if (e.IsSingleItem)
						{
							(T, TView) value = list[e.OldStartingIndex];
							list.RemoveAt(e.OldStartingIndex);
							this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, value, e.OldStartingIndex);
							break;
						}
						int length2 = e.OldItems.Length;
						FixedArray<T> fixedArray3 = new FixedArray<T>(length2);
						try
						{
							FixedArray<TView> fixedArray4 = new FixedArray<TView>(length2);
							try
							{
								Span<bool> scratchBuffer = ((length2 >= 128) ? default(Span<bool>) : stackalloc bool[length2]);
								FixedBoolArray fixedBoolArray2 = new FixedBoolArray(scratchBuffer, length2);
								try
								{
									bool isMatchAll2 = true;
									int num = e.OldStartingIndex + length2;
									int num2 = 0;
									for (int j = e.OldStartingIndex; j < num; j++)
									{
										(T, TView) item = list[j];
										fixedArray3.Span[num2] = item.Item1;
										fixedArray4.Span[num2] = item.Item2;
										if (fixedBoolArray2.Span[num2] = Filter.IsMatch(item))
										{
											filteredCount--;
										}
										else
										{
											isMatchAll2 = false;
										}
										num2++;
									}
									list.RemoveRange(e.OldStartingIndex, e.OldItems.Length);
									this.InvokeOnRemoveRange(this.ViewChanged, this.RejectedViewChanged, fixedArray3.Span, fixedArray4.Span, isMatchAll2, fixedBoolArray2.Span, e.OldStartingIndex);
								}
								finally
								{
									fixedBoolArray2.Dispose();
								}
							}
							finally
							{
								fixedArray4.Dispose();
							}
						}
						finally
						{
							fixedArray3.Dispose();
						}
						break;
					}
					case NotifyCollectionChangedAction.Replace:
					{
						(T, TView) value2 = (e.NewItem, selector(e.NewItem));
						(T, TView) oldValue = (e.OldItem, list[e.OldStartingIndex].Item2);
						list[e.NewStartingIndex] = value2;
						this.InvokeOnReplace(ref filteredCount, this.ViewChanged, value2, oldValue, e.NewStartingIndex);
						break;
					}
					case NotifyCollectionChangedAction.Move:
					{
						(T, TView) tuple2 = list[e.OldStartingIndex];
						list.RemoveAt(e.OldStartingIndex);
						list.Insert(e.NewStartingIndex, tuple2);
						this.InvokeOnMove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple2, e.NewStartingIndex, e.OldStartingIndex);
						break;
					}
					case NotifyCollectionChangedAction.Reset:
						if (e.SortOperation.IsClear)
						{
							list.Clear();
							this.InvokeOnReset(ref filteredCount, this.ViewChanged);
						}
						else if (e.SortOperation.IsReverse)
						{
							list.Reverse(e.SortOperation.Index, e.SortOperation.Count);
							this.InvokeOnReverseOrSort(this.ViewChanged, e.SortOperation);
						}
						else
						{
							list.Sort(e.SortOperation.Index, e.SortOperation.Count, new IgnoreViewComparer(e.SortOperation.Comparer ?? Comparer<T>.Default));
							this.InvokeOnReverseOrSort(this.ViewChanged, e.SortOperation);
						}
						break;
					}
					this.CollectionStateChanged?.Invoke(e.Action);
				}
			}

			public (T Value, TView View) GetAt(int index)
			{
				lock (SyncRoot)
				{
					return list[index];
				}
			}

			public void SetViewAt(int index, TView view)
			{
				lock (SyncRoot)
				{
					(T, TView) tuple = list[index];
					list[index] = (tuple.Item1, view);
				}
			}

			public void SetToSourceCollection(int index, T value)
			{
				lock (SyncRoot)
				{
					source[index] = value;
				}
			}

			public void AddToSourceCollection(T value)
			{
				lock (SyncRoot)
				{
					source.Add(value);
				}
			}

			public void InsertIntoSourceCollection(int index, T value)
			{
				lock (SyncRoot)
				{
					source.Insert(index, value);
				}
			}

			public bool RemoveFromSourceCollection(T value)
			{
				lock (SyncRoot)
				{
					return source.Remove(value);
				}
			}

			public void RemoveAtSourceCollection(int index)
			{
				lock (SyncRoot)
				{
					source.RemoveAt(index);
				}
			}

			public void ClearSourceCollection()
			{
				lock (SyncRoot)
				{
					source.Clear();
				}
			}

			public IWritableSynchronizedViewList<TView> ToWritableViewList(WritableViewChangedEventHandler<T, TView> converter)
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: true, null, converter);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged()
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, null, delegate(TView newView, T originalValue, ref bool setValue)
				{
					setValue = true;
					return originalValue;
				});
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(WritableViewChangedEventHandler<T, TView> converter)
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, null, converter);
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher)
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, collectionEventDispatcher, delegate(TView newView, T originalValue, ref bool setValue)
				{
					setValue = true;
					return originalValue;
				});
			}

			public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(WritableViewChangedEventHandler<T, TView> converter, ICollectionEventDispatcher? collectionEventDispatcher)
			{
				return new FiltableSynchronizedViewList<T, TView>(this, isSupportRangeFeature: false, collectionEventDispatcher, converter);
			}
		}

		private readonly List<T> list;

		public object SyncRoot { get; } = new object();

		public T this[int index]
		{
			get
			{
				lock (SyncRoot)
				{
					return list[index];
				}
			}
			set
			{
				lock (SyncRoot)
				{
					T oldItem = list[index];
					list[index] = value;
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
					return list.Count;
				}
			}
		}

		public bool IsReadOnly => false;

		public event NotifyCollectionChangedEventHandler<T>? CollectionChanged;

		public ObservableList()
		{
			list = new List<T>();
		}

		public ObservableList(int capacity)
		{
			list = new List<T>(capacity);
		}

		public ObservableList(IEnumerable<T> collection)
		{
			list = collection.ToList();
		}

		public void Add(T item)
		{
			lock (SyncRoot)
			{
				int count = list.Count;
				list.Add(item);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, count));
			}
		}

		public void AddRange(IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				int count = list.Count;
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(items);
				list.AddRange(cloneCollection.AsEnumerable());
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(cloneCollection.Span, count));
			}
		}

		public void AddRange(T[] items)
		{
			lock (SyncRoot)
			{
				int count = list.Count;
				list.AddRange(items);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, count));
			}
		}

		public void AddRange(ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				int count = list.Count;
				ReadOnlySpan<T> readOnlySpan = items;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					T item = readOnlySpan[i];
					list.Add(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, count));
			}
		}

		public void Clear()
		{
			lock (SyncRoot)
			{
				list.Clear();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reset());
			}
		}

		public bool Contains(T item)
		{
			lock (SyncRoot)
			{
				return list.Contains(item);
			}
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			lock (SyncRoot)
			{
				list.CopyTo(array, arrayIndex);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			lock (SyncRoot)
			{
				foreach (T item in list)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void ForEach(Action<T> action)
		{
			lock (SyncRoot)
			{
				foreach (T item in list)
				{
					action(item);
				}
			}
		}

		public int IndexOf(T item)
		{
			lock (SyncRoot)
			{
				return list.IndexOf(item);
			}
		}

		public void Insert(int index, T item)
		{
			lock (SyncRoot)
			{
				list.Insert(index, item);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, index));
			}
		}

		public void InsertRange(int index, T[] items)
		{
			lock (SyncRoot)
			{
				list.InsertRange(index, items);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, index));
			}
		}

		public void InsertRange(int index, IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(items);
				list.InsertRange(index, cloneCollection.AsEnumerable());
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(cloneCollection.Span, index));
			}
		}

		public void InsertRange(int index, ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(items);
				list.InsertRange(index, cloneCollection.AsEnumerable());
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(cloneCollection.Span, index));
			}
		}

		public bool Remove(T item)
		{
			lock (SyncRoot)
			{
				int num = list.IndexOf(item);
				if (num >= 0)
				{
					list.RemoveAt(num);
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(item, num));
					return true;
				}
				return false;
			}
		}

		public void RemoveAt(int index)
		{
			lock (SyncRoot)
			{
				T oldItem = list[index];
				list.RemoveAt(index);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(oldItem, index));
			}
		}

		public void RemoveRange(int index, int count)
		{
			lock (SyncRoot)
			{
				Span<T> span = CollectionsMarshal.AsSpan(list).Slice(index, count);
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(span);
				list.RemoveRange(index, count);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(cloneCollection.Span, index));
			}
		}

		public void Move(int oldIndex, int newIndex)
		{
			lock (SyncRoot)
			{
				T val = list[oldIndex];
				list.RemoveAt(oldIndex);
				list.Insert(newIndex, val);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Move(val, newIndex, oldIndex));
			}
		}

		public void Sort()
		{
			lock (SyncRoot)
			{
				list.Sort();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Sort(0, list.Count, null));
			}
		}

		public void Sort(IComparer<T> comparer)
		{
			lock (SyncRoot)
			{
				list.Sort(comparer);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Sort(0, list.Count, comparer));
			}
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			lock (SyncRoot)
			{
				list.Sort(index, count, comparer);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Sort(index, count, comparer));
			}
		}

		public void Reverse()
		{
			lock (SyncRoot)
			{
				list.Reverse();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reverse(0, list.Count));
			}
		}

		public void Reverse(int index, int count)
		{
			lock (SyncRoot)
			{
				list.Reverse(index, count);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reverse(index, count));
			}
		}

		public NotifyCollectionChangedSynchronizedViewList<T> ToNotifyCollectionChangedSlim()
		{
			return new ObservableListSynchronizedViewList<T>(this, null);
		}

		public NotifyCollectionChangedSynchronizedViewList<T> ToNotifyCollectionChangedSlim(ICollectionEventDispatcher? collectionEventDispatcher)
		{
			return new ObservableListSynchronizedViewList<T>(this, collectionEventDispatcher);
		}

		public ISynchronizedView<T, TView> CreateView<TView>(Func<T, TView> transform)
		{
			return new View<TView>(this, transform);
		}

		public IWritableSynchronizedView<T, TView> CreateWritableView<TView>(Func<T, TView> transform)
		{
			return new View<TView>(this, transform);
		}

		public NotifyCollectionChangedSynchronizedViewList<T> ToWritableNotifyCollectionChanged()
		{
			return ToWritableNotifyCollectionChanged(null);
		}

		public NotifyCollectionChangedSynchronizedViewList<T> ToWritableNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher)
		{
			return ToWritableNotifyCollectionChanged((T x) => x, delegate(T newView, T originalValue, ref bool setValue)
			{
				setValue = true;
				return newView;
			}, collectionEventDispatcher);
		}

		public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged<TView>(Func<T, TView> transform, WritableViewChangedEventHandler<T, TView>? converter)
		{
			return ToWritableNotifyCollectionChanged(transform, converter, null);
		}

		public NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged<TView>(Func<T, TView> transform, WritableViewChangedEventHandler<T, TView>? converter, ICollectionEventDispatcher? collectionEventDispatcher)
		{
			return new NonFilteredSynchronizedViewList<T, TView>(CreateView(transform), isSupportRangeFeature: false, collectionEventDispatcher, converter);
		}
	}
}
