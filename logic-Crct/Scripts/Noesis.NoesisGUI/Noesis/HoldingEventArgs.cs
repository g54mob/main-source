using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class HoldingEventArgs : TouchEventArgs
	{
		private HandleRef swigCPtr;

		public HoldingState HoldingState => default(HoldingState);

		internal HoldingEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(HoldingEventArgs obj)
		{
			return default(HandleRef);
		}

		~HoldingEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public HoldingEventArgs(object source, RoutedEvent arg1, Point p, ulong device, HoldingState holdingState)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
