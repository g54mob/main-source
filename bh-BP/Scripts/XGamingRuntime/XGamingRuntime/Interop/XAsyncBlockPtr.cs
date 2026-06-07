using System;

namespace XGamingRuntime.Interop
{
	public struct XAsyncBlockPtr
	{
		internal readonly IntPtr IntPtr;

		internal XAsyncBlockPtr(IntPtr intPtr)
		{
			IntPtr = (IntPtr)0;
		}
	}
}
