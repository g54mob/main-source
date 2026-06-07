using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DoubleTappedEventArgs : TouchEventArgs
	{
		private HandleRef swigCPtr;

		internal DoubleTappedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DoubleTappedEventArgs obj)
		{
			return default(HandleRef);
		}

		~DoubleTappedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public DoubleTappedEventArgs(object source, RoutedEvent arg1, Point p, ulong device)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
