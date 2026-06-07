using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RoutedEventArgs : EventArgs
	{
		private HandleRef swigCPtr;

		public object Source => null;

		public RoutedEvent RoutedEvent => null;

		public bool Handled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected internal RoutedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RoutedEventArgs obj)
		{
			return default(HandleRef);
		}

		~RoutedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public RoutedEventArgs(RoutedEvent routedEvent, object source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
