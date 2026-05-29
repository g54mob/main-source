using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs.Interop
{
	[ComImport]
	[Guid("EBBC7C04-315E-11d2-B62F-006097DF5BD4")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IProgressDialog
	{
		[PreserveSig]
		void StartProgressDialog(IntPtr hwndParent, object punkEnableModless, ProgressDialogFlags dwFlags, IntPtr pvResevered);

		[PreserveSig]
		void StopProgressDialog();

		[PreserveSig]
		void SetTitle(string pwzTitle);

		[PreserveSig]
		void SetAnimation(SafeModuleHandle hInstAnimation, ushort idAnimation);

		[PreserveSig]
		bool HasUserCancelled();

		[PreserveSig]
		void SetProgress(uint dwCompleted, uint dwTotal);

		[PreserveSig]
		void SetProgress64(ulong ullCompleted, ulong ullTotal);

		[PreserveSig]
		void SetLine(uint dwLineNum, string pwzString, bool fCompactPath, IntPtr pvResevered);

		[PreserveSig]
		void SetCancelMsg(string pwzCancelMsg, object pvResevered);

		[PreserveSig]
		void Timer(uint dwTimerAction, object pvResevered);
	}
}
