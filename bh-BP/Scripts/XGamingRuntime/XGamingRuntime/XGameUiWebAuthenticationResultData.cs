using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameUiWebAuthenticationResultData
	{
		public int responseStatus;

		public ulong responseCompletionUriSize;

		public string responseCompletionUri;

		internal XGameUiWebAuthenticationResultData(XGamingRuntime.Interop.XGameUiWebAuthenticationResultData interopResult)
		{
		}
	}
}
