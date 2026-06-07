using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QueryContinueDragEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public DragDropKeyStates KeyStates => default(DragDropKeyStates);

		public bool EscapePressed => false;

		public DragAction Action
		{
			get
			{
				return default(DragAction);
			}
			set
			{
			}
		}

		internal QueryContinueDragEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QueryContinueDragEventArgs obj)
		{
			return default(HandleRef);
		}

		~QueryContinueDragEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private DragDropKeyStates GetKeyStatesHelper()
		{
			return default(DragDropKeyStates);
		}
	}
}
