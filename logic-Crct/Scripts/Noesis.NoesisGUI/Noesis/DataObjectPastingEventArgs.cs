using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DataObjectPastingEventArgs : DataObjectEventArgs
	{
		private HandleRef swigCPtr;

		public IDataObject SourceDataObject => null;

		public IDataObject DataObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal DataObjectPastingEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DataObjectPastingEventArgs obj)
		{
			return default(HandleRef);
		}

		~DataObjectPastingEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private object GetSourceDataObjectHelper()
		{
			return null;
		}

		private object GetDataObjectHelper()
		{
			return null;
		}

		private void SetDataObjectHelper(object data)
		{
		}
	}
}
