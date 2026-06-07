using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Mouse : BaseComponent
	{
		public Point Position => default(Point);

		public static RoutedEvent GotMouseCaptureEvent => null;

		public static RoutedEvent LostMouseCaptureEvent => null;

		public static RoutedEvent MouseDownEvent => null;

		public static RoutedEvent MouseEnterEvent => null;

		public static RoutedEvent MouseLeaveEvent => null;

		public static RoutedEvent MouseMoveEvent => null;

		public static RoutedEvent MouseUpEvent => null;

		public static RoutedEvent MouseWheelEvent => null;

		public static RoutedEvent PreviewMouseDownEvent => null;

		public static RoutedEvent PreviewMouseMoveEvent => null;

		public static RoutedEvent PreviewMouseUpEvent => null;

		public static RoutedEvent PreviewMouseWheelEvent => null;

		public static RoutedEvent QueryCursorEvent => null;

		public UIElement Captured => null;

		internal new static Mouse CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Mouse(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Mouse obj)
		{
			return default(HandleRef);
		}

		protected Mouse()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Point GetPosition(UIElement relativeTo)
		{
			return default(Point);
		}

		public MouseButtonState GetButtonState(MouseButton button)
		{
			return default(MouseButtonState);
		}

		public bool Capture(UIElement element, CaptureMode mode)
		{
			return false;
		}

		public bool Capture(UIElement element)
		{
			return false;
		}

		private void GetPositionHelper(out Point pos)
		{
			pos = default(Point);
		}
	}
}
