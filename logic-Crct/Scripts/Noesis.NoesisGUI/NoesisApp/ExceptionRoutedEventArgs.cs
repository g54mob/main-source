using System;
using Noesis;

namespace NoesisApp
{
	public class ExceptionRoutedEventArgs : RoutedEventArgs
	{
		public Exception ErrorException { get; private set; }

		public ExceptionRoutedEventArgs(RoutedEvent ev, object source, Exception err)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ExceptionRoutedEventArgs(IntPtr cPtr, bool ownMemory)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}
	}
}
