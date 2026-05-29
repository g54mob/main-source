using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IPropertyStore
	{
		void GetCount(out uint cProps);

		void GetAt([In] uint iProp, out NativeMethods.PROPERTYKEY pkey);

		void GetValue([In] ref NativeMethods.PROPERTYKEY key, out object pv);

		void SetValue([In] ref NativeMethods.PROPERTYKEY key, [In] ref object pv);

		void Commit();
	}
}
