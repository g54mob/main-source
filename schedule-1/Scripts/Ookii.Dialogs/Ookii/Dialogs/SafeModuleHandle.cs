using System;
using System.Runtime.ConstrainedExecution;
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

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
