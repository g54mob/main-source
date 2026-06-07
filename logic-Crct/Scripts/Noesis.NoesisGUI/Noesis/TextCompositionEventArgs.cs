using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextCompositionEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public string Text => null;

		internal TextCompositionEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextCompositionEventArgs obj)
		{
			return default(HandleRef);
		}

		~TextCompositionEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public TextCompositionEventArgs(object source, RoutedEvent arg1, uint ch)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private uint GetTextHelper()
		{
			return 0u;
		}
	}
}
