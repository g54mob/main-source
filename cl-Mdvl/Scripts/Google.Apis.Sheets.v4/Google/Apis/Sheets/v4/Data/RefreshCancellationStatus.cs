using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class RefreshCancellationStatus : IDirectResponseSchema
	{
		[JsonProperty("errorCode")]
		public virtual string ErrorCode { get; set; }

		[JsonProperty("state")]
		public virtual string State { get; set; }

		public virtual string ETag { get; set; }
	}
}
