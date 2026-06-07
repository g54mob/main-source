using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SetterBase : BaseComponent
	{
		internal new static SetterBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SetterBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SetterBase obj)
		{
			return default(HandleRef);
		}

		protected SetterBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
