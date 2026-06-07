using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	internal interface IShellItem
	{
		void _0024__Stripped0_BindToHandler();

		void _0024__Stripped1_GetParent();

		void GetDisplayName([In] NativeMethods.SIGDN sigdnName, out string ppszName);

		void _0024__Stripped2_GetAttributes();

		void _0024__Stripped3_Compare();
	}
}
