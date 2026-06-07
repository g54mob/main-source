using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public struct ConnectionClosedResponse
	{
		[JsonProperty("reason")]
		public string ConnectionClosedReason;
	}
}
