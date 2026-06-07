using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeChangedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public Size NewSize => default(Size);

		public Size PreviousSize => default(Size);

		public bool WidthChanged => false;

		public bool HeightChanged => false;

		internal SizeChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SizeChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~SizeChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public SizeChangedEventArgs(object source, RoutedEvent arg1, SizeChangedInfo info)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
