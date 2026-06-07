using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MouseWheelEventArgs : MouseEventArgs
	{
		private HandleRef swigCPtr;

		public int Delta => 0;

		public Orientation Orientation => default(Orientation);

		internal MouseWheelEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MouseWheelEventArgs obj)
		{
			return default(HandleRef);
		}

		~MouseWheelEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public MouseWheelEventArgs(object source, RoutedEvent arg1, int rotation, Orientation orientation)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public MouseWheelEventArgs(object source, RoutedEvent arg1, int rotation)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
