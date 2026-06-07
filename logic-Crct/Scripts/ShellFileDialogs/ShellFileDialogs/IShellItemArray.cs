using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
	internal interface IShellItemArray
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult BindToHandler([In] IntPtr pbc, [In] ref Guid rbhid, [In] ref Guid riid, out IntPtr ppvOut);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetPropertyStore([In] int Flags, [In] ref Guid riid, out IntPtr ppv);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetPropertyDescriptionList([In] IntPtr keyType, [In] ref Guid riid, out IntPtr ppv);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetAttributes([In] ShellItemAttributeOptions dwAttribFlags, [In] ShellFileGetAttributesOptions sfgaoMask, out ShellFileGetAttributesOptions psfgaoAttribs);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetCount(out uint pdwNumItems);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetItemAt([In] uint dwIndex, out IShellItem ppsi);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult EnumItems(out IntPtr ppenumShellItems);
	}
}
