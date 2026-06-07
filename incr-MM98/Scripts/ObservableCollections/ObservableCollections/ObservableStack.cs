using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	public class ObservableStack<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IObservableCollection<T>
	{
		private class View<TView> : ISynchronizedView<T, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
		{
			private readonly ObservableStack<T> source;

			private readonly Func<T, TView> selector;

			protected readonly Stack<(T, TView)> stack;

			private int filteredCount;

			private ISynchronizedViewFilter<T, TView> filter;

			public object SyncRoot { get; }

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
						return stack.Count;
					}
				}
			}

			public IEnumerable<(T Value, TView View)> Filtered
			{
				get
				{
					lock (SyncRoot)
					{
						foreach (var item in stack)
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
						foreach (var item in stack)
						{
							yield return item;
						}
					}
				}
			}

			public event NotifyViewChangedEventHandler<T, TView>? ViewChanged;

			public event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

			public event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

			public View(ObservableStack<T> source, Func<T, TView> selector)
			{
				this.source = source;
				this.selector = selector;
				filter = SynchronizedViewFilter<T, TView>.Null;
				SyncRoot = new object();
				lock (source.SyncRoot)
				{
					stack = new Stack<(T, TView)>(source.stack.Select<T, (T, TView)>((T x) => (x: x, selector(x))));
					filteredCount = stack.Count;
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
					foreach (var (value, view) in stack)
					{
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
					filteredCount = stack.Count;
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
					foreach (var item in stack)
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
							(T, TView) tuple3 = (e.NewItem, selector(e.NewItem));
							stack.Push(tuple3);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple3, 0);
							break;
						}
						ReadOnlySpan<T> newItems = e.NewItems;
						for (int j = 0; j < newItems.Length; j++)
						{
							T val = newItems[j];
							(T, TView) tuple4 = (val, selector(val));
							stack.Push(tuple4);
							this.InvokeOnAdd(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple4, 0);
						}
						break;
					}
					case NotifyCollectionChangedAction.Remove:
					{
						if (e.IsSingleItem)
						{
							(T, TView) tuple = stack.Pop();
							this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple.Item1, tuple.Item2, 0);
							break;
						}
						int length = e.OldItems.Length;
						for (int i = 0; i < length; i++)
						{
							(T, TView) tuple2 = stack.Pop();
							this.InvokeOnRemove(ref filteredCount, this.ViewChanged, this.RejectedViewChanged, tuple2.Item1, tuple2.Item2, 0);
						}
						break;
					}
					case NotifyCollectionChangedAction.Reset:
						stack.Clear();
						this.InvokeOnReset(ref filteredCount, this.ViewChanged);
						break;
					}
					this.CollectionStateChanged?.Invoke(e.Action);
				}
			}
		}

		private readonly Stack<T> stack;

		public object SyncRoot { get; } = new object();

		public int Count
		{
			get
			{
				lock (SyncRoot)
				{
					return stack.Count;
				}
			}
		}

		public event NotifyCollectionChangedEventHandler<T>? CollectionChanged;

		public ObservableStack()
		{
			stack = new Stack<T>();
		}

		public ObservableStack(int capacity)
		{
			stack = new Stack<T>(capacity);
		}

		public ObservableStack(IEnumerable<T> collection)
		{
			stack = new Stack<T>(collection);
		}

		public void Push(T item)
		{
			lock (SyncRoot)
			{
				stack.Push(item);
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(item, 0));
			}
		}

		public void PushRange(IEnumerable<T> items)
		{
			lock (SyncRoot)
			{
				using CloneCollection<T> cloneCollection = new CloneCollection<T>(items);
				ReadOnlySpan<T> span = cloneCollection.Span;
				for (int i = 0; i < span.Length; i++)
				{
					T item = span[i];
					stack.Push(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(cloneCollection.Span, 0));
			}
		}

		public void PushRange(T[] items)
		{
			lock (SyncRoot)
			{
				foreach (T item in items)
				{
					stack.Push(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, 0));
			}
		}

		public void PushRange(ReadOnlySpan<T> items)
		{
			lock (SyncRoot)
			{
				ReadOnlySpan<T> readOnlySpan = items;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					T item = readOnlySpan[i];
					stack.Push(item);
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Add(items, 0));
			}
		}

		public T Pop()
		{
			lock (SyncRoot)
			{
				T val = stack.Pop();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(val, 0));
				return val;
			}
		}

		public bool TryPop([MaybeNullWhen(false)] out T result)
		{
			lock (SyncRoot)
			{
				if (stack.Count != 0)
				{
					result = stack.Pop();
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(result, 0));
					return true;
				}
				result = default(T);
				return false;
			}
		}

		public void PopRange(int count)
		{
			lock (SyncRoot)
			{
				T[] array = ArrayPool<T>.Shared.Rent(count);
				try
				{
					for (int i = 0; i < count; i++)
					{
						array[i] = stack.Pop();
					}
					this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(array.AsSpan(0, count), 0));
				}
				finally
				{
					ArrayPool<T>.Shared.Return(array, RuntimeHelpersEx.IsReferenceOrContainsReferences<T>());
				}
			}
		}

		public void PopRange(Span<T> dest)
		{
			lock (SyncRoot)
			{
				for (int i = 0; i < dest.Length; i++)
				{
					dest[i] = stack.Pop();
				}
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Remove(dest, 0));
			}
		}

		public void Clear()
		{
			lock (SyncRoot)
			{
				stack.Clear();
				this.CollectionChanged?.Invoke(NotifyCollectionChangedEventArgs<T>.Reset());
			}
		}

		public T Peek()
		{
			lock (SyncRoot)
			{
				return stack.Peek();
			}
		}

		public bool TryPeek([MaybeNullWhen(false)] out T result)
		{
			lock (SyncRoot)
			{
				if (stack.Count != 0)
				{
					result = stack.Peek();
					return true;
				}
				result = default(T);
				return false;
			}
		}

		public T[] ToArray()
		{
			lock (SyncRoot)
			{
				return stack.ToArray();
			}
		}

		public void TrimExcess()
		{
			lock (SyncRoot)
			{
				stack.TrimExcess();
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			lock (SyncRoot)
			{
				foreach (T item in stack)
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
