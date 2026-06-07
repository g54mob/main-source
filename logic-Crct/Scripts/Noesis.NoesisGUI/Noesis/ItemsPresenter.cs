using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemsPresenter : FrameworkElement
	{
		internal new static ItemsPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ItemsPresenter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemsPresenter obj)
		{
			return default(HandleRef);
		}

		public ItemsPresenter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
