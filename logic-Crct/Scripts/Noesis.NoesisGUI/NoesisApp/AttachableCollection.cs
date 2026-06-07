using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Noesis;

namespace NoesisApp
{
	public abstract class AttachableCollection<T> : FreezableCollection<T>, IAttachedObject where T : Freezable
	{
		private IntPtr _associatedObject;

		private List<T> _items;

		protected DependencyObject AssociatedObject => null;

		DependencyObject IAttachedObject.AssociatedObject => null;

		public void Attach(DependencyObject associatedObject)
		{
		}

		public void Detach()
		{
		}

		protected virtual void OnAttached()
		{
		}

		protected virtual void OnDetaching()
		{
		}

		protected virtual void ItemAdded(T item)
		{
		}

		protected virtual void ItemRemoved(T item)
		{
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}
	}
}
