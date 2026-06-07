using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GiveFeedbackEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public DragDropEffects Effects => default(DragDropEffects);

		public bool UseDefaultCursors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal GiveFeedbackEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GiveFeedbackEventArgs obj)
		{
			return default(HandleRef);
		}

		~GiveFeedbackEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private DragDropEffects GetEffectsHelper()
		{
			return default(DragDropEffects);
		}
	}
}
