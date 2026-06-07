using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Coherence.Runtime
{
	internal struct ErrorResponse
	{
		[JsonProperty("error_code")]
		public ErrorCode ErrorCode;

		[JsonProperty("hint")]
		public string Hint;

		[OnError]
		internal void OnError(StreamingContext _, ErrorContext errorContext)
		{
		}
	}
}
