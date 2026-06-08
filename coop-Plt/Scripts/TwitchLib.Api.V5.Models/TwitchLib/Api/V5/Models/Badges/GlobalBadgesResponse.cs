using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Badges
{
	public class GlobalBadgesResponse
	{
		[JsonProperty(PropertyName = "badge_sets")]
		public Dictionary<string, Badge> Sets { get; protected set; }
	}
}
