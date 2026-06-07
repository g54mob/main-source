using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IFileDialogControlEvents
	{
		void OnItemSelected([In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] int dwIDItem);

		void OnButtonClicked([In] IFileDialogCustomize pfdc, [In] int dwIDCtl);

		void OnCheckButtonToggled([In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] bool bChecked);

		void OnControlActivating([In] IFileDialogCustomize pfdc, [In] int dwIDCtl);
	}
}
