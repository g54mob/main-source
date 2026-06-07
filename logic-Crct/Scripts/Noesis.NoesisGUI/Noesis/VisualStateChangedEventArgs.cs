using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualStateChangedEventArgs : EventArgs
	{
		private HandleRef swigCPtr;

		public VisualState OldState => null;

		public VisualState NewState => null;

		public FrameworkElement Control => null;

		public FrameworkElement StateGroupsRoot => null;

		internal VisualStateChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualStateChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~VisualStateChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}
	}
}
