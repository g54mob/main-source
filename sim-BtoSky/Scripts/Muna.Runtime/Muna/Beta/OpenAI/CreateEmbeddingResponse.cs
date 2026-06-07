using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class CreateEmbeddingResponse
	{
		public struct UsageInfo
		{
			[JsonProperty("prompt_tokens")]
			public int PromptTokens;

			[JsonProperty("total_tokens")]
			public int TotalTokens;
		}

		[JsonProperty("object")]
		public string Object;

		[JsonProperty("model")]
		public string Model;

		[JsonProperty("data")]
		public Embedding[] Data;

		[JsonProperty("usage")]
		public UsageInfo Usage;
	}
}
