using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class KeyboardFocusChangedEventArgs : KeyboardEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement OldFocus => null;

		public UIElement NewFocus => null;

		internal KeyboardFocusChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyboardFocusChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~KeyboardFocusChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public KeyboardFocusChangedEventArgs(object source, RoutedEvent arg1, UIElement oldFocus, UIElement newFocus)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
