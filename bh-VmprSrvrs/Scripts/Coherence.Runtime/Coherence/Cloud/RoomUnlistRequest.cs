using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RoomUnlistRequest
	{
		[JsonProperty("secret")]
		public string Secret;
	}
}
