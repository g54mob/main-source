using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ListBox : Selector
	{
		public IList SelectedItems => null;

		public static DependencyProperty SelectedItemsProperty => null;

		public static DependencyProperty SelectionModeProperty => null;

		public SelectionMode SelectionMode
		{
			get
			{
				return default(SelectionMode);
			}
			set
			{
			}
		}

		internal new static ListBox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ListBox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ListBox obj)
		{
			return default(HandleRef);
		}

		public ListBox()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void SelectAll()
		{
		}

		public void UnselectAll()
		{
		}

		public void ScrollIntoView(object item)
		{
		}

		private object GetSelectedItemsHelper()
		{
			return null;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
