using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TriggerAction : DependencyObject
	{
		internal new static TriggerAction CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TriggerAction(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TriggerAction obj)
		{
			return default(HandleRef);
		}

		protected TriggerAction()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
