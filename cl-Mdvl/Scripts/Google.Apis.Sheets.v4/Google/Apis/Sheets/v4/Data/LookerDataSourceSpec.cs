using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class LookerDataSourceSpec : IDirectResponseSchema
	{
		[JsonProperty("explore")]
		public virtual string Explore { get; set; }

		[JsonProperty("instanceUri")]
		public virtual string InstanceUri { get; set; }

		[JsonProperty("model")]
		public virtual string Model { get; set; }

		public virtual string ETag { get; set; }
	}
}
