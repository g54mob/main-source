using Newtonsoft.Json;

namespace Muna.Beta.OpenAI
{
	public sealed class Transcription
	{
		public struct UsageInfo
		{
			[JsonProperty("type")]
			public string Type;

			[JsonProperty("seconds")]
			public float Seconds;
		}

		[JsonProperty("text")]
		public string Text;

		[JsonProperty("usage")]
		public UsageInfo Usage;
	}
}
