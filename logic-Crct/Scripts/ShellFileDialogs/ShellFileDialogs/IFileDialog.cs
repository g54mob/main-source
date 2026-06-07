using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("42F85136-DB7E-439C-85F1-E4075D135FC8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IFileDialog : IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new HResult Show([In] IntPtr parent);

		void SetFileTypes([In] uint cFileTypes, [In] FilterSpec[] rgFilterSpec);

		void SetFileTypeIndex([In] uint iFileType);

		void GetFileTypeIndex(out uint piFileType);

		void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		void Unadvise([In] uint dwCookie);

		void SetOptions([In] FileOpenOptions fos);

		void GetOptions(out FileOpenOptions pfos);

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

		void AddPlace([In] IShellItem psi, FileDialogAddPlacement fdap);

		void SetDefaultExtension([In] string pszDefaultExtension);

		void Close(int hr);

		void SetClientGuid([In] ref Guid guid);

		void ClearClientData();

		void SetFilter(IntPtr pFilter);
	}
}
