using Newtonsoft.Json;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Moderation.GetBannedUsers
{
	public class GetBannedUsersResponse
	{
		[JsonProperty(PropertyName = "data")]
		public BannedUserEvent[] Data { get; protected set; }

		[JsonProperty(PropertyName = "pagination")]
		public Pagination Pagination { get; protected set; }
	}
}
