using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ListBoxItem : ContentControl
	{
		public static DependencyProperty IsSelectedProperty => null;

		public static RoutedEvent SelectedEvent => null;

		public static RoutedEvent UnselectedEvent => null;

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

		internal new static ListBoxItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ListBoxItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ListBoxItem obj)
		{
			return default(HandleRef);
		}

		public ListBoxItem()
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
