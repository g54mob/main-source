using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class ChatMessage
	{
		[JsonProperty("role")]
		public string Role;

		[JsonProperty("content")]
		public string? Content;
	}
}
