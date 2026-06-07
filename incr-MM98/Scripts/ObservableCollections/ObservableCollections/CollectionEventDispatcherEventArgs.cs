using System;
using System.Collections;
using System.Collections.Specialized;

namespace ObservableCollections
{
	public class CollectionEventDispatcherEventArgs : NotifyCollectionChangedEventArgs
	{
		public object Collection { get; set; }

		public bool IsInvokeCollectionChanged { get; set; }

		public bool IsInvokePropertyChanged { get; set; }

		internal Action<CollectionEventDispatcherEventArgs> Invoker { get; set; }

		public void Invoke()
		{
			Invoker(this);
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action)
			: base(action)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, IList? changedItems)
			: base(action, changedItems)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, object? changedItem)
			: base(action, changedItem)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems)
			: base(action, newItems, oldItems)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int startingIndex)
			: base(action, changedItems, startingIndex)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index)
			: base(action, changedItem, index)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, object? newItem, object? oldItem)
			: base(action, newItem, oldItem)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex)
			: base(action, newItems, oldItems, startingIndex)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int index, int oldIndex)
			: base(action, changedItems, index, oldIndex)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index, int oldIndex)
			: base(action, changedItem, index, oldIndex)
		{
		}

		public CollectionEventDispatcherEventArgs(NotifyCollectionChangedAction action, object? newItem, object? oldItem, int index)
			: base(action, newItem, oldItem, index)
		{
		}
	}
}
