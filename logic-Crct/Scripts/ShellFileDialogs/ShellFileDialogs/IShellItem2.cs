using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ShellFileDialogs
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93")]
	internal interface IShellItem2 : IShellItem
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new HResult BindToHandler([In] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, out IShellFolder ppv);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new HResult GetParent(out IShellItem ppsi);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetDisplayName([In] ShellItemDesignNameOptions sigdnName, out string ppszName);

		new void GetAttributes([In] ShellFileGetAttributesOptions sfgaoMask, out ShellFileGetAttributesOptions psfgaoAttribs);

		void Compare([In] IShellItem psi, [In] uint hint, out int piOrder);

		void GetPropertyStoreWithCreateObject([In] GetPropertyStoreOptions Flags, [In] object punkCreateObject, [In] ref Guid riid, out IntPtr ppv);

		void GetPropertyDescriptionList([In] ref PropertyKey keyType, [In] ref Guid riid, out IntPtr ppv);

		HResult Update([In] IBindCtx pbc);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		int GetPropertyStore([In] GetPropertyStoreOptions Flags, [In] ref Guid riid, out IntPtr ppv);

		void GetProperty([In] ref PropertyKey key, [Out] IntPtr ppropvar);

		void GetPropertyStoreForKeys([In] ref PropertyKey rgKeys, [In] uint cKeys, [In] GetPropertyStoreOptions Flags, [In] ref Guid riid, out IntPtr ppv);

		void GetCLSID([In] ref PropertyKey key, out Guid pclsid);

		void GetFileTime([In] ref PropertyKey key, out FILETIME pft);

		void GetInt32([In] ref PropertyKey key, out int pi);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetString([In] ref PropertyKey key, out string ppsz);

		void GetUInt32([In] ref PropertyKey key, out uint pui);

		void GetUInt64([In] ref PropertyKey key, out ulong pull);

		void GetBool([In] ref PropertyKey key, out int pf);
	}
}
