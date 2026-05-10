using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("44BEAAEC-24F4-4E90-B3F0-23D258FBB146")]
	internal interface IKnownFolderManager
	{
		void FolderIdFromCsidl([In] int nCsidl, out Guid pfid);

		void FolderIdToCsidl([In] ref Guid rfid, out int pnCsidl);

		void GetFolderIds([Out] IntPtr ppKFId, [In][Out] ref uint pCount);

		void GetFolder([In] ref Guid rfid, out IKnownFolder ppkf);

		void GetFolderByName([In] string pszCanonicalName, out IKnownFolder ppkf);

		void RegisterFolder([In] ref Guid rfid, [In] ref NativeMethods.KNOWNFOLDER_DEFINITION pKFD);

		void UnregisterFolder([In] ref Guid rfid);

		void FindFolderFromPath([In] string pszPath, [In] NativeMethods.FFFP_MODE mode, out IKnownFolder ppkf);

		void FindFolderFromIDList([In] IntPtr pidl, out IKnownFolder ppkf);

		void Redirect([In] ref Guid rfid, [In] IntPtr hwnd, [In] uint Flags, [In] string pszTargetPath, [In] uint cFolders, [In] ref Guid pExclusion, out string ppszError);
	}
}
