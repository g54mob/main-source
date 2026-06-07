using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Selector : ItemsControl
	{
		public static DependencyProperty IsSelectedProperty => null;

		public static DependencyProperty IsSelectionActiveProperty => null;

		public static DependencyProperty IsSynchronizedWithCurrentItemProperty => null;

		public static DependencyProperty SelectedIndexProperty => null;

		public static DependencyProperty SelectedItemProperty => null;

		public static DependencyProperty SelectedValueProperty => null;

		public static DependencyProperty SelectedValuePathProperty => null;

		public static RoutedEvent SelectedEvent => null;

		public static RoutedEvent SelectionChangedEvent => null;

		public static RoutedEvent UnselectedEvent => null;

		public bool? IsSynchronizedWithCurrentItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SelectedIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public object SelectedItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object SelectedValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SelectedValuePath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event SelectionChangedEventHandler SelectionChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Selector CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Selector(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Selector obj)
		{
			return default(HandleRef);
		}

		protected Selector()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static bool GetIsSelected(DependencyObject element)
		{
			return false;
		}

		public static void SetIsSelected(DependencyObject element, bool value)
		{
		}

		public static bool GetIsSelectionActive(UIElement element)
		{
			return false;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
