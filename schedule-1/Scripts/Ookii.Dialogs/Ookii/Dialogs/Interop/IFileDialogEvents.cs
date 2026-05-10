using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("973510DB-7D7F-452B-8975-74A85828D354")]
	internal interface IFileDialogEvents
	{
		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HRESULT OnFileOk([In] IFileDialog pfd);

		[MethodImpl(MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
		HRESULT OnFolderChanging([In] IFileDialog pfd, [In] IShellItem psiFolder);

		void OnFolderChange([In] IFileDialog pfd);

		void OnSelectionChange([In] IFileDialog pfd);

		void OnShareViolation([In] IFileDialog pfd, [In] IShellItem psi);

		void OnTypeChange([In] IFileDialog pfd);

		void OnOverwrite([In] IFileDialog pfd, [In] IShellItem psi);
	}
}
