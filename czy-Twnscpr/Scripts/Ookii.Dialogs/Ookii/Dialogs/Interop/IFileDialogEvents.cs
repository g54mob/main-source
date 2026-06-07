using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
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
