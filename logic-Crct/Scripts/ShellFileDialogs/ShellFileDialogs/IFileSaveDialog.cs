using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IFileSaveDialog : IFileDialog, IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new HResult Show([In] IntPtr parent);

		void SetFileTypes([In] uint cFileTypes, [In] ref FilterSpec rgFilterSpec);

		new void SetFileTypeIndex([In] uint iFileType);

		new void GetFileTypeIndex(out uint piFileType);

		new void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		new void Unadvise([In] uint dwCookie);

		new void SetOptions([In] FileOpenOptions fos);

		new void GetOptions(out FileOpenOptions pfos);

		new void SetDefaultFolder([In] IShellItem psi);

		new void SetFolder([In] IShellItem psi);

		new void GetFolder(out IShellItem ppsi);

		new void GetCurrentSelection(out IShellItem ppsi);

		new void SetFileName([In] string pszName);

		new void GetFileName(out string pszName);

		new void SetTitle([In] string pszTitle);

		new void SetOkButtonLabel([In] string pszText);

		new void SetFileNameLabel([In] string pszLabel);

		new void GetResult(out IShellItem ppsi);

		new void AddPlace([In] IShellItem psi, FileDialogAddPlacement fdap);

		new void SetDefaultExtension([In] string pszDefaultExtension);

		new void Close(int hr);

		new void SetClientGuid([In] ref Guid guid);

		new void ClearClientData();

		new void SetFilter(IntPtr pFilter);

		void SetSaveAsItem([In] IShellItem psi);

		void SetProperties([In] IntPtr pStore);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		int SetCollectedProperties([In] IntPtr pList, [In] bool fAppendDefault);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HResult GetProperties(out IntPtr ppStore);

		void ApplyProperties([In] IShellItem psi, [In] IntPtr pStore, [In][ComAliasName("ShellObjects.wireHWND")] ref IntPtr hwnd, [In] IntPtr pSink);
	}
}
