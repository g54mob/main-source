using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	internal sealed class NonFilteredSynchronizedViewList<T, TView> : NotifyCollectionChangedSynchronizedViewList<TView>
	{
		private sealed class ViewComparer : IComparer<TView>
		{
			private readonly IComparer<T> comparer;

			public ViewComparer(IComparer<T> comparer)
			{
				this.comparer = comparer;
			}

			public int Compare(TView? x, TView? y)
			{
				T x2 = Unsafe.As<TView, T>(ref x);
				T y2 = Unsafe.As<TView, T>(ref y);
				return comparer.Compare(x2, y2);
			}
		}

		private static readonly PropertyChangedEventArgs CountPropertyChangedEventArgs = new PropertyChangedEventArgs("Count");

		private static readonly Action<NotifyCollectionChangedEventArgs> raiseChangedEventInvoke = RaiseChangedEvent;

		private readonly ISynchronizedView<T, TView> parent;

		private readonly List<TView> listView;

		private readonly bool isSupportRangeFeature;

		private readonly ICollectionEventDispatcher eventDispatcher;

		private readonly WritableViewChangedEventHandler<T, TView>? converter;

		public override TView this[int index]
		{
			get
			{
				lock (gate)
				{
					return listView[index];
				}
			}
			set
			{
				if (IsReadOnly)
				{
					throw new NotSupportedException("This CollectionView does not support set. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
				}
				IWritableSynchronizedView<T, TView> writableSynchronizedView = parent as IWritableSynchronizedView<T, TView>;
				T item = writableSynchronizedView.GetAt(index).Value;
				writableSynchronizedView.SetViewAt(index, value);
				listView[index] = value;
				bool setValue = true;
				T value2 = converter(value, item, ref setValue);
				if (setValue)
				{
					writableSynchronizedView.SetToSourceCollection(index, value2);
				}
			}
		}

		public override int Count
		{
			get
			{
				lock (gate)
				{
					return listView.Count;
				}
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				if (converter != null)
				{
					return !(parent is IWritableSynchronizedView<T, TView>);
				}
				return true;
			}
		}

		public override event NotifyCollectionChangedEventHandler? CollectionChanged;

		public override event PropertyChangedEventHandler? PropertyChanged;

		public NonFilteredSynchronizedViewList(ISynchronizedView<T, TView> parent, bool isSupportRangeFeature, ICollectionEventDispatcher? eventDispatcher, WritableViewChangedEventHandler<T, TView>? converter)
		{
			this.parent = parent;
			this.isSupportRangeFeature = isSupportRangeFeature;
			this.eventDispatcher = eventDispatcher ?? InlineCollectionEventDispatcher.Instance;
			this.converter = converter;
			lock (parent.SyncRoot)
			{
				listView = parent.ToList();
				parent.ViewChanged += Parent_ViewChanged;
			}
		}

		private void Parent_ViewChanged(in SynchronizedViewChangedEventArgs<T, TView> e)
		{
			lock (gate)
			{
				SynchronizedViewChangedEventArgs<T, TView> args;
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
				{
					if (e.IsSingleItem)
					{
						if (e.NewStartingIndex == -1)
						{
							int count = listView.Count;
							listView.Add(e.NewItem.View);
							args = e.WithNewStartingIndex(count);
							OnCollectionChanged(in args);
							return;
						}
						listView.Insert(e.NewStartingIndex, e.NewItem.View);
						break;
					}
					if (isSupportRangeFeature)
					{
						using (CloneCollection<TView> cloneCollection = new CloneCollection<TView>(e.NewViews))
						{
							listView.InsertRange(e.NewStartingIndex, cloneCollection.AsEnumerable());
						}
						break;
					}
					ReadOnlySpan<TView> newViews = e.NewViews;
					for (int i = 0; i < newViews.Length; i++)
					{
						int num = e.NewStartingIndex + i;
						listView.Insert(num, newViews[i]);
						NotifyCollectionChangedAction action = e.Action;
						(T, TView) newItem = (e.NewValues[i], newViews[i]);
						int newStartingIndex = num;
						OnCollectionChanged(new SynchronizedViewChangedEventArgs<T, TView>(action, isSingleItem: true, newItem, default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), newStartingIndex));
					}
					return;
				}
				case NotifyCollectionChangedAction.Remove:
				{
					if (e.IsSingleItem)
					{
						if (e.OldStartingIndex == -1)
						{
							int num3 = listView.IndexOf(e.OldItem.View);
							listView.RemoveAt(num3);
							args = e.WithOldStartingIndex(num3);
							OnCollectionChanged(in args);
							return;
						}
						listView.RemoveAt(e.OldStartingIndex);
						break;
					}
					if (e.OldStartingIndex == -1)
					{
						ReadOnlySpan<TView> oldViews = e.OldViews;
						for (int newStartingIndex = 0; newStartingIndex < oldViews.Length; newStartingIndex++)
						{
							TView item = oldViews[newStartingIndex];
							int num4 = listView.IndexOf(item);
							listView.RemoveAt(num4);
							args = e.WithOldStartingIndex(num4);
							OnCollectionChanged(in args);
						}
						return;
					}
					if (isSupportRangeFeature)
					{
						listView.RemoveRange(e.OldStartingIndex, e.OldViews.Length);
						break;
					}
					ReadOnlySpan<TView> oldViews2 = e.OldViews;
					for (int j = 0; j < oldViews2.Length; j++)
					{
						listView.RemoveAt(e.OldStartingIndex);
						NotifyCollectionChangedAction action2 = e.Action;
						(T, TView) oldItem = (e.OldValues[j], oldViews2[j]);
						int newStartingIndex = e.OldStartingIndex;
						OnCollectionChanged(new SynchronizedViewChangedEventArgs<T, TView>(action2, isSingleItem: true, default((T, TView)), oldItem, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, newStartingIndex));
					}
					return;
				}
				case NotifyCollectionChangedAction.Replace:
					if (e.NewStartingIndex == -1)
					{
						int num2 = listView.IndexOf(e.OldItem.View);
						if (num2 != -1)
						{
							listView[num2] = e.NewItem.View;
							args = e.WithNewAndOldStartingIndex(num2, num2);
							OnCollectionChanged(in args);
						}
						return;
					}
					listView[e.NewStartingIndex] = e.NewItem.View;
					break;
				case NotifyCollectionChangedAction.Move:
					if (e.NewStartingIndex == -1)
					{
						return;
					}
					listView.RemoveAt(e.OldStartingIndex);
					listView.Insert(e.NewStartingIndex, e.NewItem.View);
					break;
				case NotifyCollectionChangedAction.Reset:
					if (e.SortOperation.IsClear)
					{
						listView.Clear();
						foreach (var item2 in parent.Unfiltered)
						{
							listView.Add(item2.View);
						}
						break;
					}
					if (e.SortOperation.IsReverse)
					{
						listView.Reverse(e.SortOperation.Index, e.SortOperation.Count);
						break;
					}
					listView.Clear();
					foreach (var item3 in parent.Unfiltered)
					{
						listView.Add(item3.View);
					}
					break;
				}
				OnCollectionChanged(in e);
			}
		}

		private void OnCollectionChanged(in SynchronizedViewChangedEventArgs<T, TView> args)
		{
			if (CollectionChanged == null && PropertyChanged == null)
			{
				return;
			}
			switch (args.Action)
			{
			case NotifyCollectionChangedAction.Add:
				if (args.IsSingleItem)
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Add, args.NewItem.View, args.NewStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				else
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Add, args.NewViews.ToArray(), args.NewStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				if (args.IsSingleItem)
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Remove, args.OldItem.View, args.OldStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				else
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Remove, args.OldViews.ToArray(), args.OldStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				break;
			case NotifyCollectionChangedAction.Reset:
				eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Reset)
				{
					Collection = this,
					Invoker = raiseChangedEventInvoke,
					IsInvokeCollectionChanged = true,
					IsInvokePropertyChanged = true
				});
				break;
			case NotifyCollectionChangedAction.Replace:
				eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Replace, args.NewItem.View, args.OldItem.View, args.NewStartingIndex)
				{
					Collection = this,
					Invoker = raiseChangedEventInvoke,
					IsInvokeCollectionChanged = true,
					IsInvokePropertyChanged = false
				});
				break;
			case NotifyCollectionChangedAction.Move:
				eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Move, args.NewItem.View, args.NewStartingIndex, args.OldStartingIndex)
				{
					Collection = this,
					Invoker = raiseChangedEventInvoke,
					IsInvokeCollectionChanged = true,
					IsInvokePropertyChanged = false
				});
				break;
			}
		}

		private static void RaiseChangedEvent(NotifyCollectionChangedEventArgs e)
		{
			CollectionEventDispatcherEventArgs obj = (CollectionEventDispatcherEventArgs)e;
			NonFilteredSynchronizedViewList<T, TView> nonFilteredSynchronizedViewList = (NonFilteredSynchronizedViewList<T, TView>)obj.Collection;
			if (obj.IsInvokeCollectionChanged)
			{
				nonFilteredSynchronizedViewList.CollectionChanged?.Invoke(nonFilteredSynchronizedViewList, e);
			}
			if (obj.IsInvokePropertyChanged)
			{
				nonFilteredSynchronizedViewList.PropertyChanged?.Invoke(nonFilteredSynchronizedViewList, CountPropertyChangedEventArgs);
			}
		}

		public override IEnumerator<TView> GetEnumerator()
		{
			lock (gate)
			{
				foreach (TView item in listView)
				{
					yield return item;
				}
			}
		}

		public override void Add(TView item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support Add. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
			}
			IWritableSynchronizedView<T, TView> writableSynchronizedView = parent as IWritableSynchronizedView<T, TView>;
			if (typeof(T) == typeof(TView) && item is T)
			{
				T value = (T)((((object)item) is T) ? ((object)item) : null);
				writableSynchronizedView.AddToSourceCollection(value);
			}
			else
			{
				bool setValue = false;
				T value2 = converter(item, default(T), ref setValue);
				writableSynchronizedView.AddToSourceCollection(value2);
			}
		}

		public override void Insert(int index, TView item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support Insert. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
			}
			IWritableSynchronizedView<T, TView> writableSynchronizedView = parent as IWritableSynchronizedView<T, TView>;
			if (typeof(T) == typeof(TView) && item is T)
			{
				T value = (T)((((object)item) is T) ? ((object)item) : null);
				writableSynchronizedView.InsertIntoSourceCollection(index, value);
			}
			else
			{
				bool setValue = false;
				T value2 = converter(item, default(T), ref setValue);
				writableSynchronizedView.InsertIntoSourceCollection(index, value2);
			}
		}

		public override bool Remove(TView item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support Remove. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
			}
			IWritableSynchronizedView<T, TView> writableSynchronizedView = parent as IWritableSynchronizedView<T, TView>;
			if (typeof(T) == typeof(TView) && item is T)
			{
				T value = (T)((((object)item) is T) ? ((object)item) : null);
				return writableSynchronizedView.RemoveFromSourceCollection(value);
			}
			bool setValue = false;
			T value2 = converter(item, default(T), ref setValue);
			return writableSynchronizedView.RemoveFromSourceCollection(value2);
		}

		public override void RemoveAt(int index)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support RemoveAt. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
			}
			(parent as IWritableSynchronizedView<T, TView>).RemoveAtSourceCollection(index);
		}

		public override void Clear()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support Clear. If base type is ObservableList<T>, you can use ToWritableNotifyCollectionChanged.");
			}
			(parent as IWritableSynchronizedView<T, TView>).ClearSourceCollection();
		}

		public override bool Contains(TView item)
		{
			lock (gate)
			{
				foreach (TView item2 in listView)
				{
					if (EqualityComparer<TView>.Default.Equals(item2, item))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override int IndexOf(TView item)
		{
			lock (gate)
			{
				int num = 0;
				foreach (TView item2 in listView)
				{
					if (EqualityComparer<TView>.Default.Equals(item2, item))
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		public override void Dispose()
		{
			parent.ViewChanged -= Parent_ViewChanged;
			parent.Dispose();
		}
	}
}
