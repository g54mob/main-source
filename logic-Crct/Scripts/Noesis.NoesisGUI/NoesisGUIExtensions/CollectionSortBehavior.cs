using System.Collections;
using System.Collections.Specialized;
using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class CollectionSortBehavior : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty ComparerProperty;

		public static readonly DependencyProperty ItemsSourceProperty;

		public static readonly DependencyProperty SortedItemsProperty;

		public SortComparer Comparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public SortedCollection SortedItems
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public new CollectionSortBehavior Clone()
		{
			return null;
		}

		public new CollectionSortBehavior CloneCurrentValue()
		{
			return null;
		}

		private int BinarySearch(SortComparer comparer, SortedCollection list, object item, int low, int high)
		{
			return 0;
		}

		private void SortItems()
		{
		}

		private void OnSortRequired()
		{
		}

		private static void OnComparerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private void RegisterComparer(SortComparer comparer)
		{
		}

		private void UnregisterComparer(SortComparer comparer)
		{
		}

		private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private void AddSortedItem(SortComparer comparer, SortedCollection list, object item)
		{
		}

		private void RemSortedItem(SortComparer comparer, SortedCollection list, object item)
		{
		}

		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private void RegisterItemsSource(IEnumerable source)
		{
		}

		private void UnregisterItemsSource(IEnumerable source)
		{
		}
	}
}
