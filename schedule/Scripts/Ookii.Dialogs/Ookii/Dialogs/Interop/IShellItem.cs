using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
	internal interface IShellItem
	{
		void BindToHandler([In] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, out IntPtr ppv);

		void GetParent(out IShellItem ppsi);

		void GetDisplayName([In] NativeMethods.SIGDN sigdnName, out string ppszName);

		void GetAttributes([In] uint sfgaoMask, out uint psfgaoAttribs);

		void Compare([In] IShellItem psi, [In] uint hint, out int piOrder);
	}
}
