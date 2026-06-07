using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToolTipEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		internal ToolTipEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToolTipEventArgs obj)
		{
			return default(HandleRef);
		}

		~ToolTipEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ToolTipEventArgs(object source, RoutedEvent arg1)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
