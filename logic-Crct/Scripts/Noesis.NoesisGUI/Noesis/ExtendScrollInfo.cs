using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendScrollInfo : BaseComponent
	{
		internal new static ExtendScrollInfo CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendScrollInfo(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendScrollInfo obj)
		{
			return default(HandleRef);
		}

		protected ExtendScrollInfo()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
