using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IFileDialogCustomize
	{
		void EnableOpenDropDown([In] int dwIDCtl);

		void _0024__Stripped0_AddMenu();

		void AddPushButton([In] int dwIDCtl, [In] string pszLabel);

		void _0024__Stripped1_AddComboBox();

		void _0024__Stripped2_AddRadioButtonList();

		void _0024__Stripped3_AddCheckButton();

		void _0024__Stripped4_AddEditBox();

		void _0024__Stripped5_AddSeparator();

		void AddText([In] int dwIDCtl, [In] string pszText);

		void _0024__Stripped6_SetControlLabel();

		void _0024__Stripped7_GetControlState();

		void _0024__Stripped8_SetControlState();

		void _0024__Stripped9_GetEditBoxText();

		void _0024__Stripped10_SetEditBoxText();

		void _0024__Stripped11_GetCheckButtonState();

		void _0024__Stripped12_SetCheckButtonState();

		void AddControlItem([In] int dwIDCtl, [In] int dwIDItem, [In] string pszLabel);

		void _0024__Stripped13_RemoveControlItem();

		void _0024__Stripped14_RemoveAllControlItems();

		void _0024__Stripped15_GetControlItemState();

		void _0024__Stripped16_SetControlItemState();

		void GetSelectedControlItem([In] int dwIDCtl, out int pdwIDItem);

		void _0024__Stripped17_SetSelectedControlItem();

		void _0024__Stripped18_StartVisualGroup();

		void _0024__Stripped19_EndVisualGroup();

		void _0024__Stripped20_MakeProminent();
	}
}
