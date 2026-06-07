using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RequestNavigateEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public string Uri => null;

		public string Target => null;

		internal RequestNavigateEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RequestNavigateEventArgs obj)
		{
			return default(HandleRef);
		}

		~RequestNavigateEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public RequestNavigateEventArgs(object source, RoutedEvent arg1, string uri, string target)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
