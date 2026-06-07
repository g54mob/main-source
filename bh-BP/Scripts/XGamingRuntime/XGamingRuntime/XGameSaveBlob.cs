using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveBlob
	{
		public XGameSaveBlobInfo Info;

		public byte[] Data;

		internal XGameSaveBlob(XGamingRuntime.Interop.XGameSaveBlob interopBlob)
		{
		}
	}
}
