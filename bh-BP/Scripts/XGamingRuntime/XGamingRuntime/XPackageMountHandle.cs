using System;

namespace XGamingRuntime
{
	public class XPackageMountHandle : SafeEquatableHandle
	{
		public override bool IsInvalid => false;

		public XPackageMountHandle(IntPtr handle)
			: base((IntPtr)0, ownsHandle: false, (IntPtr)0)
		{
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
