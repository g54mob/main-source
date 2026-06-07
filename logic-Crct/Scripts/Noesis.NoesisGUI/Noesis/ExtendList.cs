using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendList : BaseComponent
	{
		internal new static ExtendList CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendList(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendList obj)
		{
			return default(HandleRef);
		}

		protected ExtendList()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
