using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct LinkSteamRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("ticket")]
		public string Ticket;

		[JsonProperty("identity")]
		public string Identity;

		[JsonProperty("force")]
		public bool Force;
	}
}
