using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TouchEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public TouchDevice TouchDevice => null;

		internal TouchEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TouchEventArgs obj)
		{
			return default(HandleRef);
		}

		~TouchEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public Point GetTouchPoint(UIElement relativeTo)
		{
			return default(Point);
		}

		public TouchEventArgs(object source, RoutedEvent arg1, Point p, ulong device)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private ulong GetTouchDeviceId()
		{
			return 0uL;
		}
	}
}
