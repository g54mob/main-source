using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IShellItemArray
	{
		void _0024__Stripped0_BindToHandler();

		void _0024__Stripped1_GetPropertyStore();

		void _0024__Stripped2_GetPropertyDescriptionList();

		void _0024__Stripped3_GetAttributes();

		void GetCount(out uint pdwNumItems);

		void GetItemAt([In] uint dwIndex, out IShellItem ppsi);

		void _0024__Stripped4_EnumItems();
	}
}
