using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XAppCaptureTakeScreenshotResult
	{
		public string LocalId { get; }

		public XAppCaptureScreenshotFormatFlag AvailableScreenshotFormats { get; }

		internal XAppCaptureTakeScreenshotResult(XGamingRuntime.Interop.XAppCaptureTakeScreenshotResult interopScreenshotResult)
		{
			LocalId = Converters.ByteArrayToString(interopScreenshotResult.localId);
			AvailableScreenshotFormats = interopScreenshotResult.availableScreenshotFormats;
		}
	}
}
