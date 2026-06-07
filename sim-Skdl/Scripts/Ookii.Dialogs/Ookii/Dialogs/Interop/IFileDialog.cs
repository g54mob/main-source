using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
	internal interface IFileDialog : IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new int Show([In] IntPtr parent);

		void SetFileTypes([In] uint cFileTypes, [In] NativeMethods.COMDLG_FILTERSPEC[] rgFilterSpec);

		void SetFileTypeIndex([In] uint iFileType);

		void GetFileTypeIndex(out uint piFileType);

		void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		void Unadvise([In] uint dwCookie);

		void SetOptions([In] NativeMethods.FOS fos);

		void GetOptions(out NativeMethods.FOS pfos);

		void SetDefaultFolder([In] IShellItem psi);

		void SetFolder([In] IShellItem psi);

		void GetFolder(out IShellItem ppsi);

		void GetCurrentSelection(out IShellItem ppsi);

		void SetFileName([In] string pszName);

		void GetFileName(out string pszName);

		void SetTitle([In] string pszTitle);

		void SetOkButtonLabel([In] string pszText);

		void SetFileNameLabel([In] string pszLabel);

		void GetResult(out IShellItem ppsi);

		void AddPlace([In] IShellItem psi, NativeMethods.FDAP fdap);

		void SetDefaultExtension([In] string pszDefaultExtension);

		void Close(int hr);

		void SetClientGuid([In] ref Guid guid);

		void ClearClientData();

		void SetFilter(IntPtr pFilter);
	}
}
