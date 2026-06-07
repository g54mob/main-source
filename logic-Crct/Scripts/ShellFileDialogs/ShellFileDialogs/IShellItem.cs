using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IShellItem
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult BindToHandler([In] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, out IShellFolder ppv);

		void GetParent(out IShellItem ppsi);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetDisplayName([In] ShellItemDesignNameOptions sigdnName, out IntPtr ppszName);

		void GetAttributes([In] ShellFileGetAttributesOptions sfgaoMask, out ShellFileGetAttributesOptions psfgaoAttribs);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult Compare([In] IShellItem psi, [In] SICHINTF hint, out int piOrder);
	}
}
