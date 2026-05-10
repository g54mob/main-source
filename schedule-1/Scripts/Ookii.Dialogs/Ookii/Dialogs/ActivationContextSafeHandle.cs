using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace Ookii.Dialogs
{
	internal class ActivationContextSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		public ActivationContextSafeHandle()
			: base(ownsHandle: false)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
