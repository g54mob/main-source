using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InputEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		internal InputEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(InputEventArgs obj)
		{
			return default(HandleRef);
		}

		~InputEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		public InputEventArgs(object source, RoutedEvent arg1)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
