using System.Text.RegularExpressions;

namespace Lexone.UnityTwitchChat
{
	internal static class ParseHelper
	{
		private static Regex symbolRegex;

		public static int IndexOfNth(this string source, char val, int nth = 0)
		{
			return 0;
		}

		public static bool CheckNameRegex(string displayName)
		{
			return false;
		}

		public static IRCTags ParseTags(string tagString)
		{
			return null;
		}

		public static string ParseLoginName(string ircString)
		{
			return null;
		}

		public static string ParseChannel(string ircString)
		{
			return null;
		}

		public static string ParseMessage(string ircString)
		{
			return null;
		}

		public static ChatterEmote[] ParseTwitchEmotes(string[] splitEmotes)
		{
			return null;
		}

		public static ChatterBadge[] ParseBadges(string[] splitBadges)
		{
			return null;
		}
	}
}
