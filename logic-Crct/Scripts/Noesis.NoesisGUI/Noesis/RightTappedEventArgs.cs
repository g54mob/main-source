using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RightTappedEventArgs : TouchEventArgs
	{
		private HandleRef swigCPtr;

		internal RightTappedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RightTappedEventArgs obj)
		{
			return default(HandleRef);
		}

		~RightTappedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public RightTappedEventArgs(object source, RoutedEvent arg1, Point p, ulong device)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
