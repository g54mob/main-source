using UnityEngine;

namespace Jundroo.SocialPlatforms
{
	public class UserProfile : IUserProfile
	{
		public string id { get; set; }

		public Texture2D image { get; set; }

		public bool isFriend { get; set; }

		public UserState state { get; set; }

		public string userName { get; set; }
	}
}
