using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataObjectCopyingEventArgs : DataObjectEventArgs
	{
		private HandleRef swigCPtr;

		public IDataObject DataObject => null;

		internal DataObjectCopyingEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataObjectCopyingEventArgs obj)
		{
			return default(HandleRef);
		}

		~DataObjectCopyingEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private object GetDataObjectHelper()
		{
			return null;
		}
	}
}
