using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MouseEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public MouseButtonState LeftButton => default(MouseButtonState);

		public MouseButtonState MiddleButton => default(MouseButtonState);

		public MouseButtonState RightButton => default(MouseButtonState);

		public MouseButtonState XButton1 => default(MouseButtonState);

		public MouseButtonState XButton2 => default(MouseButtonState);

		internal MouseEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MouseEventArgs obj)
		{
			return default(HandleRef);
		}

		~MouseEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public MouseEventArgs(object source, RoutedEvent arg1)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Point GetPosition(UIElement relativeTo)
		{
			return default(Point);
		}
	}
}
