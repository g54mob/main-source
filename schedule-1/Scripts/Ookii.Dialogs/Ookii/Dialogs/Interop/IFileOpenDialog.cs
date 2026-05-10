using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IFileOpenDialog : IFileDialog, IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new int Show([In] IntPtr parent);

		void SetFileTypes([In] uint cFileTypes, [In] ref NativeMethods.COMDLG_FILTERSPEC rgFilterSpec);

		new void SetFileTypeIndex([In] uint iFileType);

		new void GetFileTypeIndex(out uint piFileType);

		new void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		new void Unadvise([In] uint dwCookie);

		new void SetOptions([In] NativeMethods.FOS fos);

		new void GetOptions(out NativeMethods.FOS pfos);

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

		new void AddPlace([In] IShellItem psi, NativeMethods.FDAP fdap);

		new void SetDefaultExtension([In] string pszDefaultExtension);

		new void Close(int hr);

		new void SetClientGuid([In] ref Guid guid);

		new void ClearClientData();

		new void SetFilter(IntPtr pFilter);

		void GetResults(out IShellItemArray ppenum);

		void GetSelectedItems(out IShellItemArray ppsai);
	}
}
