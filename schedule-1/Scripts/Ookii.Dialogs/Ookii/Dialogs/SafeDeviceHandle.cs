using System;
using Microsoft.Win32.SafeHandles;

namespace Ookii.Dialogs
{
	internal class SafeDeviceHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		internal SafeDeviceHandle()
			: base(ownsHandle: false)
		{
		}

		internal SafeDeviceHandle(IntPtr existingHandle, bool ownsHandle)
			: base(ownsHandle: false)
		{
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
