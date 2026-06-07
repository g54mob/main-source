using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MouseButtonEventArgs : MouseEventArgs
	{
		private HandleRef swigCPtr;

		public int ClickCount => 0;

		public MouseButton ChangedButton => default(MouseButton);

		public MouseButtonState ButtonState => default(MouseButtonState);

		internal MouseButtonEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MouseButtonEventArgs obj)
		{
			return default(HandleRef);
		}

		~MouseButtonEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public MouseButtonEventArgs(object source, RoutedEvent arg1, MouseButton button, MouseButtonState state, uint clickCount)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private int GetClickCountHelper()
		{
			return 0;
		}
	}
}
