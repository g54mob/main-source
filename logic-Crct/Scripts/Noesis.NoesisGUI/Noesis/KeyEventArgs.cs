using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class KeyEventArgs : KeyboardEventArgs
	{
		private HandleRef swigCPtr;

		public Key Key => default(Key);

		public Key OriginalKey => default(Key);

		public KeyStates KeyStates => default(KeyStates);

		public bool IsDown => false;

		public bool IsUp => false;

		public bool IsRepeat => false;

		public bool IsToggled => false;

		internal KeyEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyEventArgs obj)
		{
			return default(HandleRef);
		}

		~KeyEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public KeyEventArgs(object source, RoutedEvent arg1, Key key, KeyStates keyStates)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
