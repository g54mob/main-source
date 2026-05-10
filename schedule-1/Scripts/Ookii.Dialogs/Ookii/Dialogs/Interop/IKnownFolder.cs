using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("38521333-6A87-46A7-AE10-0F16706816C3")]
	internal interface IKnownFolder
	{
		void GetId(out Guid pkfid);

		void spacer1();

		void GetShellItem([In] uint dwFlags, ref Guid riid, out IShellItem ppv);

		void GetPath([In] uint dwFlags, out string ppszPath);

		void SetPath([In] uint dwFlags, [In] string pszPath);

		void GetLocation([In] uint dwFlags, [Out][ComAliasName("Interop.wirePIDL")] IntPtr ppidl);

		void GetFolderType(out Guid pftid);

		void GetRedirectionCapabilities(out uint pCapabilities);

		void spacer2();
	}
}
