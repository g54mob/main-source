using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DragDeltaEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public float HorizontalChange => 0f;

		public float VerticalChange => 0f;

		internal DragDeltaEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DragDeltaEventArgs obj)
		{
			return default(HandleRef);
		}

		~DragDeltaEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public DragDeltaEventArgs(object source, float hChange, float vChange)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
