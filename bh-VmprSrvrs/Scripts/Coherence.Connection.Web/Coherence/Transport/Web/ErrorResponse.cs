using Newtonsoft.Json;

namespace Coherence.Transport.Web
{
	public struct ErrorResponse
	{
		[JsonProperty("errorCode", NullValueHandling = NullValueHandling.Ignore)]
		public ErrorCode ErrorCode;
	}
}
