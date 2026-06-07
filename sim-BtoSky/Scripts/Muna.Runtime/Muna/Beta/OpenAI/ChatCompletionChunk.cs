using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class ChatCompletionChunk
	{
		public sealed class Choice
		{
			public sealed class MessageDelta
			{
				[JsonProperty("role")]
				public string? Role;

				[JsonProperty("content")]
				public string? Content;
			}

			[JsonProperty("index")]
			public int Index;

			[JsonProperty("delta")]
			public MessageDelta? Delta;

			[JsonProperty("finish_reason")]
			public string? FinishReason;
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
		public ChatCompletion.UsageInfo? Usage;
	}
}
