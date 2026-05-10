using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[Guid("e6fdd21a-163f-4975-9c8c-a69f1ba37034")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IFileDialogCustomize
	{
		void EnableOpenDropDown([In] int dwIDCtl);

		void AddMenu([In] int dwIDCtl, [In] string pszLabel);

		void AddPushButton([In] int dwIDCtl, [In] string pszLabel);

		void AddComboBox([In] int dwIDCtl);

		void AddRadioButtonList([In] int dwIDCtl);

		void AddCheckButton([In] int dwIDCtl, [In] string pszLabel, [In] bool bChecked);

		void AddEditBox([In] int dwIDCtl, [In] string pszText);

		void AddSeparator([In] int dwIDCtl);

		void AddText([In] int dwIDCtl, [In] string pszText);

		void SetControlLabel([In] int dwIDCtl, [In] string pszLabel);

		void GetControlState([In] int dwIDCtl, out NativeMethods.CDCONTROLSTATE pdwState);

		void SetControlState([In] int dwIDCtl, [In] NativeMethods.CDCONTROLSTATE dwState);

		void GetEditBoxText([In] int dwIDCtl, [Out] IntPtr ppszText);

		void SetEditBoxText([In] int dwIDCtl, [In] string pszText);

		void GetCheckButtonState([In] int dwIDCtl, out bool pbChecked);

		void SetCheckButtonState([In] int dwIDCtl, [In] bool bChecked);

		void AddControlItem([In] int dwIDCtl, [In] int dwIDItem, [In] string pszLabel);

		void RemoveControlItem([In] int dwIDCtl, [In] int dwIDItem);

		void RemoveAllControlItems([In] int dwIDCtl);

		void GetControlItemState([In] int dwIDCtl, [In] int dwIDItem, out NativeMethods.CDCONTROLSTATE pdwState);

		void SetControlItemState([In] int dwIDCtl, [In] int dwIDItem, [In] NativeMethods.CDCONTROLSTATE dwState);

		void GetSelectedControlItem([In] int dwIDCtl, out int pdwIDItem);

		void SetSelectedControlItem([In] int dwIDCtl, [In] int dwIDItem);

		void StartVisualGroup([In] int dwIDCtl, [In] string pszLabel);

		void EndVisualGroup();

		void MakeProminent([In] int dwIDCtl);
	}
}
