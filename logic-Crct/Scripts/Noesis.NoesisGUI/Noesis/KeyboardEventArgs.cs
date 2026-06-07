using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class KeyboardEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		internal KeyboardEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyboardEventArgs obj)
		{
			return default(HandleRef);
		}

		~KeyboardEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		public KeyboardEventArgs(object s, RoutedEvent e)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
