using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface NativeFileOpenDialog : IFileOpenDialog, IFileDialog, IModalWindow
	{
	}
}
