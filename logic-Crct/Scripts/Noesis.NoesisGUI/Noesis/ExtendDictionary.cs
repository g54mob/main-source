using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendDictionary : BaseComponent
	{
		internal new static ExtendDictionary CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendDictionary(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendDictionary obj)
		{
			return default(HandleRef);
		}

		protected ExtendDictionary()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
