using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QueryCursorEventArgs : MouseEventArgs
	{
		private HandleRef swigCPtr;

		public Cursor Cursor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal QueryCursorEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QueryCursorEventArgs obj)
		{
			return default(HandleRef);
		}

		~QueryCursorEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public QueryCursorEventArgs(object source, RoutedEvent arg1)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
