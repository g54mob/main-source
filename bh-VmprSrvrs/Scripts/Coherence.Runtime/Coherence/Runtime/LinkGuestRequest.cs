using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct LinkGuestRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("guest_id")]
		public string GuestId;

		[JsonProperty("force")]
		public bool Force;
	}
}
