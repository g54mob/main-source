using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public struct KvPair
	{
		[JsonProperty("key")]
		public string Key;

		[JsonProperty("value")]
		public string Value;
	}
}
