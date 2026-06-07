using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct ResponseMeta
	{
		[Deprecated("01/07/2022", 0, 9, 0, Reason = "Replaced by `RequestId`")]
		[JsonProperty("id")]
		public int Id;

		[JsonProperty("requestId")]
		public string RequestId;

		[JsonProperty("code")]
		public int StatusCode;

		[JsonProperty("ts")]
		public long Timestamp;

		[JsonProperty("resume_id")]
		public string ResumeId;

		[Deprecated("01/07/2022", 0, 9, 0, Reason = "Replaced by `RequestId`")]
		[JsonProperty("logId")]
		public string LogId
		{
			set
			{
			}
		}
	}
}
