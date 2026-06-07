using System;

namespace XGamingRuntime
{
	public class XUserHandle : SafeEquatableHandle
	{
		public override bool IsInvalid => false;

		internal XUserHandle(IntPtr interopHandle)
			: base((IntPtr)0, ownsHandle: false, (IntPtr)0)
		{
		}

		internal XUserHandle(IntPtr interopHandle, bool ownsHandle)
			: base((IntPtr)0, ownsHandle: false, (IntPtr)0)
		{
		}

		internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out XUserHandle handle)
		{
			handle = null;
			return 0;
		}

		protected override bool ReleaseHandle()
		{
			return false;
		}
	}
}
