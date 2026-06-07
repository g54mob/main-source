using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class Embedding
	{
		[JsonProperty("object")]
		public string Object;

		[JsonProperty("embedding")]
		public float[]? Floats;

		[JsonProperty("index")]
		public int Index;

		[JsonIgnore]
		public string? Base64;
	}
}
