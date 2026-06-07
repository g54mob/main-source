using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface NativeFileSaveDialog : IFileSaveDialog, IFileDialog, IModalWindow
	{
	}
}
