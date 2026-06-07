using System;
using System.Runtime.InteropServices;

namespace Ookii.Dialogs
{
	internal class SafeModuleHandle : SafeHandle
	{
		public override bool IsInvalid => false;

		public SafeModuleHandle()
			: base((IntPtr)0, ownsHandle: false)
		{
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
