using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RequestBringIntoViewEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public DependencyObject TargetObject => null;

		public Rect TargetRect => default(Rect);

		internal RequestBringIntoViewEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RequestBringIntoViewEventArgs obj)
		{
			return default(HandleRef);
		}

		~RequestBringIntoViewEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public RequestBringIntoViewEventArgs(object source, DependencyObject arg1, Rect targetRect)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
