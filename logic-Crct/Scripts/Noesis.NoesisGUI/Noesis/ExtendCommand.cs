using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendCommand : BaseComponent
	{
		internal new static ExtendCommand CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendCommand(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendCommand obj)
		{
			return default(HandleRef);
		}

		protected ExtendCommand()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
