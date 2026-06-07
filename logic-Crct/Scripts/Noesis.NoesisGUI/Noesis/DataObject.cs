using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public struct DataObject : IDataObject
	{
		private object _data;

		public static RoutedEvent CopyingEvent => null;

		public static RoutedEvent PastingEvent => null;

		public DataObject(object data)
		{
			_data = null;
		}

		public DataObject(Type type, object data)
		{
			_data = null;
		}

		public static void AddCopyingHandler(DependencyObject d, DataObjectCopyingEventHandler handler)
		{
		}

		public static void AddPastingHandler(DependencyObject d, DataObjectPastingEventHandler handler)
		{
		}

		public static void RemoveCopyingHandler(DependencyObject d, DataObjectCopyingEventHandler handler)
		{
		}

		public static void RemovePastingHandler(DependencyObject d, DataObjectPastingEventHandler handler)
		{
		}

		public object GetData(Type format)
		{
			return null;
		}

		public bool GetDataPresent(Type format)
		{
			return false;
		}

		public void SetData(Type format, object data)
		{
		}

		[PreserveSig]
		private static extern IntPtr DataObject_CopyingEvent_get();

		[PreserveSig]
		private static extern IntPtr DataObject_PastingEvent_get();
	}
}
