using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScrollChangedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public float ExtentHeight => 0f;

		public float ExtentHeightChange => 0f;

		public float ExtentWidth => 0f;

		public float ExtentWidthChange => 0f;

		public float HorizontalChange => 0f;

		public float HorizontalOffset => 0f;

		public float VerticalChange => 0f;

		public float VerticalOffset => 0f;

		public float ViewportHeight => 0f;

		public float ViewportHeightChange => 0f;

		public float ViewportWidth => 0f;

		public float ViewportWidthChange => 0f;

		internal ScrollChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScrollChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~ScrollChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ScrollChangedEventArgs(object source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
