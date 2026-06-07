using System.Collections;
using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class CollectionFilterBehavior : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty PredicateProperty;

		public static readonly DependencyProperty ItemsSourceProperty;

		public static readonly DependencyProperty FilteredItemsProperty;

		public FilterPredicate Predicate
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

		public FilteredCollection FilteredItems
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public new CollectionFilterBehavior Clone()
		{
			return null;
		}

		public new CollectionFilterBehavior CloneCurrentValue()
		{
			return null;
		}

		private void FilterItems()
		{
		}

		private void OnFilterRequired()
		{
		}

		private static void OnPredicateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private void RegisterPredicate(FilterPredicate predicate)
		{
		}

		private void UnregisterPredicate(FilterPredicate predicate)
		{
		}

		private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
}
