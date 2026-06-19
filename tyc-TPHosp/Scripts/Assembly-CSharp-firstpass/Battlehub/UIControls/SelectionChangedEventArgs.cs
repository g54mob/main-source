using System;

namespace Battlehub.UIControls
{
	public class SelectionChangedEventArgs : EventArgs
	{
		public object[] OldItems { get; private set; }

		public object[] NewItems { get; private set; }

		public object OldItem
		{
			get
			{
				if (OldItems == null)
				{
					return null;
				}
				return OldItems[0];
			}
		}

		public object NewItem
		{
			get
			{
				if (NewItems == null)
				{
					return null;
				}
				return NewItems[0];
			}
		}

		public SelectionChangedEventArgs(object[] oldItems, object[] newItems)
		{
			OldItems = oldItems;
			NewItems = newItems;
		}

		public SelectionChangedEventArgs(object oldItem, object newItem)
		{
			OldItems = new object[1] { oldItem };
			NewItems = new object[1] { newItem };
		}
	}
}
