using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ListViewItem : ListBoxItem
	{
		internal new static ListViewItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ListViewItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ListViewItem obj)
		{
			return default(HandleRef);
		}

		public ListViewItem()
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
