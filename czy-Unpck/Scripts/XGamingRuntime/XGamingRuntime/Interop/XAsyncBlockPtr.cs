using System;

namespace XGamingRuntime.Interop
{
	internal struct XAsyncBlockPtr
	{
		internal readonly IntPtr IntPtr;

		internal XAsyncBlockPtr(IntPtr intPtr)
		{
			IntPtr = intPtr;
		}
	}
}
