using Newtonsoft.Json;

namespace TwitchLib.Api.Core.Models.Root
{
	public class Root
	{
		[JsonProperty(PropertyName = "token")]
		public RootToken Token { get; protected set; }
	}
}
