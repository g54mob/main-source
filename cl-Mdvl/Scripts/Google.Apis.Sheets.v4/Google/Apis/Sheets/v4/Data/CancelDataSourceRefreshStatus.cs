using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class CancelDataSourceRefreshStatus : IDirectResponseSchema
	{
		[JsonProperty("reference")]
		public virtual DataSourceObjectReference Reference { get; set; }

		[JsonProperty("refreshCancellationStatus")]
		public virtual RefreshCancellationStatus RefreshCancellationStatus { get; set; }

		public virtual string ETag { get; set; }
	}
}
