using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ContextMenuEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public DependencyObject TargetElement => null;

		public float CursorLeft => 0f;

		public float CursorTop => 0f;

		internal ContextMenuEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ContextMenuEventArgs obj)
		{
			return default(HandleRef);
		}

		~ContextMenuEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ContextMenuEventArgs(object source, RoutedEvent arg1, float cursorLeft, float cursorTop)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ContextMenuEventArgs(object source, RoutedEvent arg1, float cursorLeft)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ContextMenuEventArgs(object source, RoutedEvent arg1)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
