using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XAppCaptureTakeScreenshotResult
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
		internal readonly byte[] localId;

		internal XAppCaptureScreenshotFormatFlag availableScreenshotFormats;
	}
}
