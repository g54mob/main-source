using System;
using Microsoft.Win32.SafeHandles;

namespace Ookii.Dialogs
{
	internal class SafeGDIHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		internal SafeGDIHandle()
			: base(ownsHandle: false)
		{
		}

		internal SafeGDIHandle(IntPtr existingHandle, bool ownsHandle)
			: base(ownsHandle: false)
		{
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
