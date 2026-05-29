using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("36116642-D713-4b97-9B83-7484A9D00433")]
	internal interface IFileDialogControlEvents
	{
		void OnItemSelected([In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] int dwIDItem);

		void OnButtonClicked([In] IFileDialogCustomize pfdc, [In] int dwIDCtl);

		void OnCheckButtonToggled([In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] bool bChecked);

		void OnControlActivating([In] IFileDialogCustomize pfdc, [In] int dwIDCtl);
	}
}
