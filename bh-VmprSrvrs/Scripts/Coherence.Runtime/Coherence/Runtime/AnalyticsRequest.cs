using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public struct AnalyticsRequest
	{
		[JsonProperty("timestamp_ms")]
		public long TimestampMs;

		[JsonProperty("analytics_id")]
		public string AnalyticsId;

		[JsonProperty("event_name")]
		public string EventName;

		[JsonProperty("sdk_ver")]
		public string SDKVersion;

		[JsonProperty("rs_ver")]
		public string EngineVersion;

		[JsonProperty("sim_slug")]
		public string SimSlug;

		[JsonProperty("schema_id")]
		public string SchemaId;

		public override string ToString()
		{
			return null;
		}
	}
}
