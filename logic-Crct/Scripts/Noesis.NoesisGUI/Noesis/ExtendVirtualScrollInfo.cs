using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendVirtualScrollInfo : BaseComponent
	{
		internal new static ExtendVirtualScrollInfo CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendVirtualScrollInfo(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendVirtualScrollInfo obj)
		{
			return default(HandleRef);
		}

		protected ExtendVirtualScrollInfo()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
