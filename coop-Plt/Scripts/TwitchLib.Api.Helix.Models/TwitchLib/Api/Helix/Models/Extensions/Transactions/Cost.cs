using Newtonsoft.Json;

namespace TwitchLib.Api.Helix.Models.Extensions.Transactions
{
	public class Cost
	{
		[JsonProperty(PropertyName = "amount")]
		public int Amount { get; protected set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; protected set; }
	}
}
