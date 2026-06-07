using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendConverter : BaseComponent
	{
		internal new static ExtendConverter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendConverter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendConverter obj)
		{
			return default(HandleRef);
		}

		protected ExtendConverter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
