using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[ComImport]
	[Guid("D57C7288-D4AD-4768-BE02-9D969532D960")]
	[CoClass(typeof(FileOpenDialogRCW))]
	internal interface NativeFileOpenDialog : IFileOpenDialog, IFileDialog, IModalWindow
	{
	}
}
