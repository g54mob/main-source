using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
	internal interface IShellItemArray
	{
		void BindToHandler([In] IntPtr pbc, [In] ref Guid rbhid, [In] ref Guid riid, out IntPtr ppvOut);

		void GetPropertyStore([In] int Flags, [In] ref Guid riid, out IntPtr ppv);

		void GetPropertyDescriptionList([In] ref NativeMethods.PROPERTYKEY keyType, [In] ref Guid riid, out IntPtr ppv);

		void GetAttributes([In] NativeMethods.SIATTRIBFLAGS dwAttribFlags, [In] uint sfgaoMask, out uint psfgaoAttribs);

		void GetCount(out uint pdwNumItems);

		void GetItemAt([In] uint dwIndex, out IShellItem ppsi);

		void EnumItems(out IntPtr ppenumShellItems);
	}
}
