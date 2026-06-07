using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class ChatCompletion
	{
		public sealed class Choice
		{
			[JsonProperty("index")]
			public int Index;

			[JsonProperty("message")]
			public ChatMessage Message;

			[JsonProperty("finish_reason")]
			public string? FinishReason;
		}

		public struct UsageInfo
		{
			[JsonProperty("completion_tokens")]
			public int CompletionTokens;

			[JsonProperty("prompt_tokens")]
			public int PromptTokens;

			[JsonProperty("total_tokens")]
			public int TotalTokens;
		}

		[JsonProperty("object")]
		public string Object;

		[JsonProperty("id")]
		public string Id;

		[JsonProperty("model")]
		public string Model;

		[JsonProperty("choices")]
		public Choice[] Choices;

		[JsonProperty("created")]
		public long Created;

		[JsonProperty("usage")]
		public UsageInfo Usage;
	}
}
