using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ViewBase : Animatable
	{
		internal new static ViewBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ViewBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ViewBase obj)
		{
			return default(HandleRef);
		}

		protected ViewBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual void ClearItem(ListViewItem item)
		{
		}

		public virtual void PrepareItem(ListViewItem item)
		{
		}
	}
}
