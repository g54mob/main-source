using System;
using UnityEngine;

namespace Lexone.UnityTwitchChat
{
	[Serializable]
	public class Chatter
	{
		public string login;

		public string channel;

		public string message;

		public IRCTags tags;

		public Chatter(string login, string channel, string message, IRCTags tags)
		{
		}

		public Color GetNameColor(bool normalize = true)
		{
			return default(Color);
		}

		public bool IsDisplayNameFontSafe()
		{
			return false;
		}

		public bool ContainsEmote(string emoteId)
		{
			return false;
		}

		public bool HasBadge(string badgeName)
		{
			return false;
		}
	}
}
