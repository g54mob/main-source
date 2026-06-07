using System;

namespace Lexone.UnityTwitchChat
{
	[Serializable]
	public class IRCTags
	{
		public string colorHex;

		public string displayName;

		public string channelId;

		public string userId;

		public ChatterBadge[] badges;

		public ChatterEmote[] emotes;

		public bool ContainsEmote(string emoteId)
		{
			return false;
		}

		public bool HasBadge(string badge)
		{
			return false;
		}
	}
}
