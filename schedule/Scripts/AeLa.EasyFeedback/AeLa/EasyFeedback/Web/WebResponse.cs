namespace AeLa.EasyFeedback.Web
{
	internal readonly struct WebResponse
	{
		public readonly string Text;

		public readonly bool IsError;

		public readonly long HTTPStatusCode;

		public static WebResponse GetResponse(AsyncWebRequestData requestData)
		{
			return default(WebResponse);
		}

		public WebResponse(string text, bool isError, long httpStatusCode)
		{
			Text = null;
			IsError = false;
			HTTPStatusCode = 0L;
		}
	}
}
