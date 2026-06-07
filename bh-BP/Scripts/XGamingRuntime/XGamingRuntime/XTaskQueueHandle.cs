using System;

namespace XGamingRuntime
{
	public class XTaskQueueHandle : SafeEquatableHandle
	{
		public override bool IsInvalid => false;

		public XTaskQueueHandle(IntPtr handle)
			: base((IntPtr)0, ownsHandle: false, (IntPtr)0)
		{
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
