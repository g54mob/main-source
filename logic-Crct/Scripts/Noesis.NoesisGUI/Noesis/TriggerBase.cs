using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TriggerBase : DependencyObject
	{
		public TriggerActionCollection EnterActions => null;

		public TriggerActionCollection ExitActions => null;

		internal new static TriggerBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TriggerBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TriggerBase obj)
		{
			return default(HandleRef);
		}

		protected TriggerBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
