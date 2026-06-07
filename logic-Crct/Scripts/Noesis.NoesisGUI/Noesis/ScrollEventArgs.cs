using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScrollEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public float NewValue => 0f;

		public ScrollEventType ScrollEventType => default(ScrollEventType);

		internal ScrollEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScrollEventArgs obj)
		{
			return default(HandleRef);
		}

		~ScrollEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ScrollEventArgs(object source, float value, ScrollEventType type)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
