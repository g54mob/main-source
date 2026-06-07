using System;
using System.Collections;

namespace PlatformSupport.Collections.Specialized
{
	public class NotifyCollectionChangedEventArgs : EventArgs
	{
		private NotifyCollectionChangedAction _action;

		private IList _newItems;

		private IList _oldItems;

		private int _newStartingIndex;

		private int _oldStartingIndex;

		public NotifyCollectionChangedAction Action => default(NotifyCollectionChangedAction);

		public IList NewItems => null;

		public IList OldItems => null;

		public int NewStartingIndex => 0;

		public int OldStartingIndex => 0;

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int startingIndex)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, int index)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index, int oldIndex)
		{
		}

		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int index, int oldIndex)
		{
		}

		internal NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int newIndex, int oldIndex)
		{
		}

		private void InitializeAddOrRemove(NotifyCollectionChangedAction action, IList changedItems, int startingIndex)
		{
		}

		private void InitializeAdd(NotifyCollectionChangedAction action, IList newItems, int newStartingIndex)
		{
		}

		private void InitializeRemove(NotifyCollectionChangedAction action, IList oldItems, int oldStartingIndex)
		{
		}

		private void InitializeMoveOrReplace(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex, int oldStartingIndex)
		{
		}
	}
}
