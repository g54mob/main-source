using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DragCompletedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public bool Canceled => false;

		public float HorizontalChange => 0f;

		public float VerticalChange => 0f;

		internal DragCompletedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DragCompletedEventArgs obj)
		{
			return default(HandleRef);
		}

		~DragCompletedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public DragCompletedEventArgs(object source, bool canceled, float hChange, float vChange)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
