using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendStream : BaseComponent
	{
		internal new static ExtendStream CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendStream(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendStream obj)
		{
			return default(HandleRef);
		}

		protected ExtendStream()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
