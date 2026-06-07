using Newtonsoft.Json;

namespace Coherence.Transport.Web
{
	public struct JsError
	{
		[JsonProperty("statusCode")]
		public int StatusCode;

		[JsonProperty("errorMessage")]
		public string ErrorMessage;

		[JsonProperty("errorResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ErrorResponse ErrorResponse;

		[JsonProperty("errorType", NullValueHandling = NullValueHandling.Ignore)]
		public ErrorType ErrorType;
	}
}
