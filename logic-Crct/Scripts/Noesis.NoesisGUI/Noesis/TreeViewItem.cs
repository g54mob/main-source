using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TreeViewItem : HeaderedItemsControl
	{
		public static DependencyProperty IsExpandedProperty => null;

		public static DependencyProperty IsSelectedProperty => null;

		public static DependencyProperty IsSelectionActiveProperty => null;

		public static RoutedEvent CollapsedEvent => null;

		public static RoutedEvent ExpandedEvent => null;

		public static RoutedEvent SelectedEvent => null;

		public static RoutedEvent UnselectedEvent => null;

		public bool IsExpanded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelectionActive => false;

		public event RoutedEventHandler Collapsed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Expanded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Selected
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Unselected
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static TreeViewItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TreeViewItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TreeViewItem obj)
		{
			return default(HandleRef);
		}

		public TreeViewItem()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
