using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using ObservableCollections.Internal;

namespace ObservableCollections
{
	internal sealed class FiltableSynchronizedViewList<T, TView> : NotifyCollectionChangedSynchronizedViewList<TView>
	{
		private static readonly PropertyChangedEventArgs CountPropertyChangedEventArgs = new PropertyChangedEventArgs("Count");

		private static readonly Action<NotifyCollectionChangedEventArgs> raiseChangedEventInvoke = RaiseChangedEvent;

		private readonly ISynchronizedView<T, TView> parent;

		private readonly AlternateIndexList<TView> listView;

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
					throw new NotSupportedException("This CollectionView does not support Set. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
				}
				IWritableSynchronizedView<T, TView> writableSynchronizedView = parent as IWritableSynchronizedView<T, TView>;
				int alternateIndex = listView.GetAlternateIndex(index);
				T item = writableSynchronizedView.GetAt(alternateIndex).Value;
				writableSynchronizedView.SetViewAt(alternateIndex, value);
				listView[index] = value;
				bool setValue = true;
				T value2 = converter(value, item, ref setValue);
				if (setValue)
				{
					writableSynchronizedView.SetToSourceCollection(alternateIndex, value2);
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

		public FiltableSynchronizedViewList(ISynchronizedView<T, TView> parent, bool isSupportRangeFeature, ICollectionEventDispatcher? eventDispatcher = null, WritableViewChangedEventHandler<T, TView>? converter = null)
		{
			this.parent = parent;
			this.isSupportRangeFeature = isSupportRangeFeature;
			this.eventDispatcher = eventDispatcher ?? InlineCollectionEventDispatcher.Instance;
			this.converter = converter;
			lock (parent.SyncRoot)
			{
				listView = new AlternateIndexList<TView>(IterateFilteredIndexedViewsOfParent());
				parent.ViewChanged += Parent_ViewChanged;
				parent.RejectedViewChanged += Parent_RejectedViewChanged;
			}
		}

		private IEnumerable<(int, TView)> IterateFilteredIndexedViewsOfParent()
		{
			ISynchronizedViewFilter<T, TView> filter = parent.Filter;
			int index = 0;
			if (filter.IsNullFilter())
			{
				foreach (var item in parent.Unfiltered)
				{
					yield return (index, item.View);
					index++;
				}
				yield break;
			}
			foreach (var item2 in parent.Unfiltered)
			{
				if (filter.IsMatch(item2))
				{
					yield return (index, item2.View);
				}
				index++;
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
							listView.Insert(count, e.NewItem.View);
							args = e.WithNewStartingIndex(count);
							OnCollectionChanged(in args);
						}
						else
						{
							int newStartingIndex2 = listView.Insert(e.NewStartingIndex, e.NewItem.View);
							args = e.WithNewStartingIndex(newStartingIndex2);
							OnCollectionChanged(in args);
						}
						return;
					}
					if (isSupportRangeFeature)
					{
						using (CloneCollection<TView> cloneCollection = new CloneCollection<TView>(e.NewViews))
						{
							int newStartingIndex3 = listView.InsertRange(e.NewStartingIndex, cloneCollection.AsEnumerable());
							args = e.WithNewStartingIndex(newStartingIndex3);
							OnCollectionChanged(in args);
							return;
						}
					}
					ReadOnlySpan<TView> newViews = e.NewViews;
					for (int k = 0; k < newViews.Length; k++)
					{
						int num = listView.Insert(e.NewStartingIndex + k, newViews[k]);
						NotifyCollectionChangedAction action2 = e.Action;
						(T, TView) newItem = (e.NewValues[k], newViews[k]);
						int i = num;
						OnCollectionChanged(new SynchronizedViewChangedEventArgs<T, TView>(action2, isSingleItem: true, newItem, default((T, TView)), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), i));
					}
					return;
				}
				case NotifyCollectionChangedAction.Remove:
				{
					int oldStartingIndex2 = e.OldStartingIndex;
					if (e.IsSingleItem)
					{
						oldStartingIndex2 = ((e.OldStartingIndex != -1) ? listView.RemoveAt(e.OldStartingIndex) : listView.Remove(e.OldItem.View));
					}
					else
					{
						if (e.OldStartingIndex == -1)
						{
							ReadOnlySpan<TView> oldViews = e.OldViews;
							for (int i = 0; i < oldViews.Length; i++)
							{
								TView value = oldViews[i];
								listView.Remove(value);
								args = e.WithOldStartingIndex(oldStartingIndex2);
								OnCollectionChanged(in args);
							}
							return;
						}
						if (!isSupportRangeFeature)
						{
							ReadOnlySpan<TView> oldViews2 = e.OldViews;
							for (int j = 0; j < oldViews2.Length; j++)
							{
								oldStartingIndex2 = listView.RemoveAt(e.OldStartingIndex);
								NotifyCollectionChangedAction action = e.Action;
								(T, TView) oldItem = (e.OldValues[j], oldViews2[j]);
								int i = oldStartingIndex2;
								OnCollectionChanged(new SynchronizedViewChangedEventArgs<T, TView>(action, isSingleItem: true, default((T, TView)), oldItem, default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), default(ReadOnlySpan<T>), default(ReadOnlySpan<TView>), -1, i));
							}
							return;
						}
						oldStartingIndex2 = listView.RemoveRange(e.OldStartingIndex, e.OldViews.Length);
					}
					args = e.WithOldStartingIndex(oldStartingIndex2);
					OnCollectionChanged(in args);
					return;
				}
				case NotifyCollectionChangedAction.Replace:
				{
					int setIndex;
					if (e.NewStartingIndex == -1)
					{
						if (listView.TryReplaceByValue(e.OldItem.View, e.NewItem.View, out var replacedIndex))
						{
							args = e.WithNewAndOldStartingIndex(replacedIndex, replacedIndex);
							OnCollectionChanged(in args);
						}
					}
					else if (listView.TrySetAtAlternateIndex(e.NewStartingIndex, e.NewItem.View, out setIndex))
					{
						args = e.WithNewAndOldStartingIndex(setIndex, setIndex);
						OnCollectionChanged(in args);
					}
					return;
				}
				case NotifyCollectionChangedAction.Move:
				{
					if (e.NewStartingIndex == -1)
					{
						return;
					}
					int oldStartingIndex = listView.RemoveAt(e.OldStartingIndex);
					int newStartingIndex = listView.Insert(e.NewStartingIndex, e.NewItem.View);
					args = e.WithNewAndOldStartingIndex(newStartingIndex, oldStartingIndex);
					OnCollectionChanged(in args);
					break;
				}
				case NotifyCollectionChangedAction.Reset:
					listView.Clear(IterateFilteredIndexedViewsOfParent());
					break;
				}
				OnCollectionChanged(in e);
			}
		}

		private void Parent_RejectedViewChanged(RejectedViewChangedAction arg1, int index, int oldIndex)
		{
			if (index == -1)
			{
				return;
			}
			lock (gate)
			{
				switch (arg1)
				{
				case RejectedViewChangedAction.Add:
					listView.UpdateAlternateIndex(index, 1);
					break;
				case RejectedViewChangedAction.Remove:
					listView.UpdateAlternateIndex(index, -1);
					break;
				case RejectedViewChangedAction.Move:
					if (oldIndex != -1 && listView.TryReplaceAlternateIndex(oldIndex, index))
					{
						OnCollectionChanged(new SynchronizedViewChangedEventArgs<T, TView>(NotifyCollectionChangedAction.Reset, isSingleItem: true));
					}
					break;
				}
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
			FiltableSynchronizedViewList<T, TView> filtableSynchronizedViewList = (FiltableSynchronizedViewList<T, TView>)obj.Collection;
			if (obj.IsInvokeCollectionChanged)
			{
				filtableSynchronizedViewList.CollectionChanged?.Invoke(filtableSynchronizedViewList, e);
			}
			if (obj.IsInvokePropertyChanged)
			{
				filtableSynchronizedViewList.PropertyChanged?.Invoke(filtableSynchronizedViewList, CountPropertyChangedEventArgs);
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
				throw new NotSupportedException("This CollectionView does not support Add. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
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
				throw new NotSupportedException("This CollectionView does not support Insert. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
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
				throw new NotSupportedException("This CollectionView does not support Remove. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
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
				throw new NotSupportedException("This CollectionView does not support RemoveAt. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
			}
			(parent as IWritableSynchronizedView<T, TView>).RemoveAtSourceCollection(index);
		}

		public override void Clear()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This CollectionView does not support Clear. If base type is ObservableList<T>, you can use CreateWritableView and ToWritableNotifyCollectionChanged.");
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
			parent.RejectedViewChanged -= Parent_RejectedViewChanged;
		}
	}
}
