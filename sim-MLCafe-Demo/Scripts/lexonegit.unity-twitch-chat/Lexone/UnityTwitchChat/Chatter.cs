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

		public float cooldownTime;

		public Chatter(string login, string channel, string message, IRCTags tags)
		{
			this.login = login;
			this.channel = channel;
			this.message = message;
			this.tags = tags;
		}

		public void SetCooldown(float cooldown)
		{
			cooldownTime = cooldown;
		}

		public Color GetNameColor(bool normalize = true)
		{
			if (ColorUtility.TryParseHtmlString(tags.colorHex, out var color))
			{
				if (normalize)
				{
					return ChatColors.NormalizeColor(color);
				}
				return color;
			}
			return Color.white;
		}

		public bool IsDisplayNameFontSafe()
		{
			return ParseHelper.CheckNameRegex(tags.displayName);
		}

		public bool ContainsEmote(string emoteId)
		{
			return tags.ContainsEmote(emoteId);
		}

		public bool HasBadge(string badgeName)
		{
			return tags.HasBadge(badgeName);
		}
	}
}
