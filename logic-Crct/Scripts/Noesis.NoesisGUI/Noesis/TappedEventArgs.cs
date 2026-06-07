using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TappedEventArgs : TouchEventArgs
	{
		private HandleRef swigCPtr;

		internal TappedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TappedEventArgs obj)
		{
			return default(HandleRef);
		}

		~TappedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public TappedEventArgs(object source, RoutedEvent arg1, Point p, ulong device)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
