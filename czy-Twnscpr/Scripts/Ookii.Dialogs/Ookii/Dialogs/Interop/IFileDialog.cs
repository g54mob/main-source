using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IFileDialog : IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new int Show([In] IntPtr parent);

		void SetFileTypes([In] uint cFileTypes, [In] NativeMethods.COMDLG_FILTERSPEC[] rgFilterSpec);

		void SetFileTypeIndex([In] uint iFileType);

		void _0024__Stripped0_GetFileTypeIndex();

		void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		void _0024__Stripped1_Unadvise();

		void SetOptions([In] NativeMethods.FOS fos);

		void _0024__Stripped2_GetOptions();

		void SetDefaultFolder([In] IShellItem psi);

		void SetFolder([In] IShellItem psi);

		void _0024__Stripped3_GetFolder();

		void _0024__Stripped4_GetCurrentSelection();

		void SetFileName([In] string pszName);

		void _0024__Stripped5_GetFileName();

		void SetTitle([In] string pszTitle);

		void _0024__Stripped6_SetOkButtonLabel();

		void _0024__Stripped7_SetFileNameLabel();

		void GetResult(out IShellItem ppsi);

		void _0024__Stripped8_AddPlace();

		void SetDefaultExtension([In] string pszDefaultExtension);

		void _0024__Stripped9_Close();

		void _0024__Stripped10_SetClientGuid();

		void _0024__Stripped11_ClearClientData();

		void _0024__Stripped12_SetFilter();
	}
}
