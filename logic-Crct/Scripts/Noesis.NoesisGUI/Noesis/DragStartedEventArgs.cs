using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DragStartedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public float HorizontalOffset => 0f;

		public float VerticalOffset => 0f;

		internal DragStartedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DragStartedEventArgs obj)
		{
			return default(HandleRef);
		}

		~DragStartedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public DragStartedEventArgs(object source, float hOffset, float voffset)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
