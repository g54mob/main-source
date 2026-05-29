using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IFileSaveDialog : IFileDialog, IModalWindow
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		new int Show([In] IntPtr parent);

		void _0024__Stripped0_SetFileTypes();

		new void SetFileTypeIndex([In] uint iFileType);

		void _0024__Stripped1_GetFileTypeIndex();

		new void Advise([In] IFileDialogEvents pfde, out uint pdwCookie);

		void _0024__Stripped2_Unadvise();

		new void SetOptions([In] NativeMethods.FOS fos);

		void _0024__Stripped3_GetOptions();

		new void SetDefaultFolder([In] IShellItem psi);

		new void SetFolder([In] IShellItem psi);

		void _0024__Stripped4_GetFolder();

		void _0024__Stripped5_GetCurrentSelection();

		new void SetFileName([In] string pszName);

		void _0024__Stripped6_GetFileName();

		new void SetTitle([In] string pszTitle);

		void _0024__Stripped7_SetOkButtonLabel();

		void _0024__Stripped8_SetFileNameLabel();

		new void GetResult(out IShellItem ppsi);

		void _0024__Stripped9_AddPlace();

		new void SetDefaultExtension([In] string pszDefaultExtension);

		void _0024__Stripped10_Close();

		void _0024__Stripped11_SetClientGuid();

		void _0024__Stripped12_ClearClientData();

		void _0024__Stripped13_SetFilter();

		void _0024__Stripped14_SetSaveAsItem();

		void _0024__Stripped15_SetProperties();

		void _0024__Stripped16_SetCollectedProperties();

		void _0024__Stripped17_GetProperties();

		void _0024__Stripped18_ApplyProperties();
	}
}
