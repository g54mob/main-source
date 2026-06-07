using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataObjectEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public bool CommandCancelled => false;

		public bool IsDragDrop => false;

		internal DataObjectEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataObjectEventArgs obj)
		{
			return default(HandleRef);
		}

		~DataObjectEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		public void CancelCommand()
		{
		}
	}
}
