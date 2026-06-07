using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoesisGUIExtensions
{
	public abstract class FilterPredicate
	{
		private IEnumerable _itemsSource;

		public IEnumerable ItemsSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event FilterRequiredEventHandler FilterRequired
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract bool Matches(object item);

		public abstract bool NeedsRefresh(object item, string propertyName);

		public void Refresh()
		{
		}

		private void RegisterItemsSource(IEnumerable source)
		{
		}

		private void UnregisterItemsSource(IEnumerable source)
		{
		}

		private void RegisterItems(IEnumerable source)
		{
		}

		private void UnregisterItems(IEnumerable source)
		{
		}

		private void RegisterItem(object item)
		{
		}

		private void UnregisterItem(object item)
		{
		}

		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private void OnItemChanged(object item, PropertyChangedEventArgs e)
		{
		}
	}
}
