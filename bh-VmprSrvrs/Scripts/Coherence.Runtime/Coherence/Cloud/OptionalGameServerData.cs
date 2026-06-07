using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct OptionalGameServerData
	{
		[JsonProperty("gameserver")]
		public GameServerData? GameServerData;
	}
}
