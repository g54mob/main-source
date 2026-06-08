using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XAsyncCompletionRoutine(XAsyncBlockPtr asyncBlock);
}
