using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("000214E6-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComConversionLoss]
	internal interface IShellFolder
	{
		void ParseDisplayName(IntPtr hwnd, [In] IBindCtx pbc, [In] string pszDisplayName, [In][Out] ref uint pchEaten, [Out] IntPtr ppidl, [In][Out] ref uint pdwAttributes);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult EnumObjects([In] IntPtr hwnd, [In] ShellFolderEnumerationOptions grfFlags, out IEnumIDList ppenumIDList);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult BindToObject([In] IntPtr pidl, IntPtr pbc, [In] ref Guid riid, out IShellFolder ppv);

		void BindToStorage([In] ref IntPtr pidl, [In] IBindCtx pbc, [In] ref Guid riid, out IntPtr ppv);

		void CompareIDs([In] IntPtr lParam, [In] ref IntPtr pidl1, [In] ref IntPtr pidl2);

		void CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid, out IntPtr ppv);

		void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In][Out] ref uint rgfInOut);

		void GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [In] ref Guid riid, [In][Out] ref uint rgfReserved, out IntPtr ppv);

		void GetDisplayNameOf([In] ref IntPtr pidl, [In] uint uFlags, out IntPtr pName);

		void SetNameOf([In] IntPtr hwnd, [In] ref IntPtr pidl, [In] string pszName, [In] uint uFlags, [Out] IntPtr ppidlOut);
	}
}
