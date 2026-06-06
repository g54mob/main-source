using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ObservableCollections
{
	internal sealed class ObservableListSynchronizedViewList<T> : NotifyCollectionChangedSynchronizedViewList<T>
	{
		private static readonly PropertyChangedEventArgs CountPropertyChangedEventArgs = new PropertyChangedEventArgs("Count");

		private static readonly Action<NotifyCollectionChangedEventArgs> raiseChangedEventInvoke = RaiseChangedEvent;

		private readonly ObservableList<T> parent;

		private readonly ICollectionEventDispatcher eventDispatcher;

		public override T this[int index]
		{
			get
			{
				return parent[index];
			}
			set
			{
				parent[index] = value;
			}
		}

		public override int Count => parent.Count;

		public override event NotifyCollectionChangedEventHandler? CollectionChanged;

		public override event PropertyChangedEventHandler? PropertyChanged;

		public ObservableListSynchronizedViewList(ObservableList<T> parent, ICollectionEventDispatcher? eventDispatcher)
		{
			this.parent = parent;
			this.eventDispatcher = eventDispatcher ?? InlineCollectionEventDispatcher.Instance;
			parent.CollectionChanged += Parent_CollectionChanged;
		}

		private void Parent_CollectionChanged(in NotifyCollectionChangedEventArgs<T> args)
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
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Add, args.NewItem, args.NewStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				else
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Add, args.NewItems.ToArray(), args.NewStartingIndex)
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
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Remove, args.OldItem, args.OldStartingIndex)
					{
						Collection = this,
						Invoker = raiseChangedEventInvoke,
						IsInvokeCollectionChanged = true,
						IsInvokePropertyChanged = true
					});
				}
				else
				{
					eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Remove, args.OldItems.ToArray(), args.OldStartingIndex)
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
				eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Replace, args.NewItem, args.OldItem, args.NewStartingIndex)
				{
					Collection = this,
					Invoker = raiseChangedEventInvoke,
					IsInvokeCollectionChanged = true,
					IsInvokePropertyChanged = false
				});
				break;
			case NotifyCollectionChangedAction.Move:
				eventDispatcher.Post(new CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction.Move, args.NewItem, args.NewStartingIndex, args.OldStartingIndex)
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
			ObservableListSynchronizedViewList<T> observableListSynchronizedViewList = (ObservableListSynchronizedViewList<T>)obj.Collection;
			if (obj.IsInvokeCollectionChanged)
			{
				observableListSynchronizedViewList.CollectionChanged?.Invoke(observableListSynchronizedViewList, e);
			}
			if (obj.IsInvokePropertyChanged)
			{
				observableListSynchronizedViewList.PropertyChanged?.Invoke(observableListSynchronizedViewList, CountPropertyChangedEventArgs);
			}
		}

		public override IEnumerator<T> GetEnumerator()
		{
			return parent.GetEnumerator();
		}

		public override void Dispose()
		{
			parent.CollectionChanged -= Parent_CollectionChanged;
		}

		public override void Add(T item)
		{
			parent.Add(item);
		}

		public override void Insert(int index, T item)
		{
			parent.Insert(index, item);
		}

		public override bool Remove(T item)
		{
			return parent.Remove(item);
		}

		public override void RemoveAt(int index)
		{
			parent.RemoveAt(index);
		}

		public override void Clear()
		{
			parent.Clear();
		}

		public override bool Contains(T item)
		{
			return parent.Contains(item);
		}

		public override int IndexOf(T item)
		{
			return parent.IndexOf(item);
		}
	}
}
