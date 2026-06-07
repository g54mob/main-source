using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendMultiConverter : BaseComponent
	{
		internal new static ExtendMultiConverter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendMultiConverter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendMultiConverter obj)
		{
			return default(HandleRef);
		}

		protected ExtendMultiConverter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
