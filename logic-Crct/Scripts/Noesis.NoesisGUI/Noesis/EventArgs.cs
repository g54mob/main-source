using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EventArgs : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private static EventArgs _empty;

		public static EventArgs Empty => null;

		internal EventArgs(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(EventArgs obj)
		{
			return default(HandleRef);
		}

		~EventArgs()
		{
		}

		public virtual void Dispose()
		{
		}

		internal static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private static EventArgs GetEmptyHelper()
		{
			return null;
		}

		public EventArgs()
		{
		}
	}
}
