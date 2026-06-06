using System;

namespace Lexone.UnityTwitchChat
{
	[Serializable]
	public class IRCTags
	{
		public string colorHex = string.Empty;

		public string displayName = string.Empty;

		public string channelId = string.Empty;

		public string userId = string.Empty;

		public ChatterBadge[] badges = new ChatterBadge[0];

		public ChatterEmote[] emotes = new ChatterEmote[0];

		public bool ContainsEmote(string emoteId)
		{
			ChatterEmote[] array = emotes;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id == emoteId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasBadge(string badge)
		{
			ChatterBadge[] array = badges;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id == badge)
				{
					return true;
				}
			}
			return false;
		}
	}
}
