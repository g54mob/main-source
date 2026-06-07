using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB")]
	[CoClass(typeof(FileSaveDialogRCW))]
	internal interface NativeFileSaveDialog : IFileSaveDialog, IFileDialog, IModalWindow
	{
	}
}
