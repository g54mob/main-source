using System.Text.RegularExpressions;

namespace Lexone.UnityTwitchChat
{
	internal static class ParseHelper
	{
		private static Regex symbolRegex = new Regex("^[a-zA-Z0-9_]+$", RegexOptions.Compiled);

		public static int IndexOfNth(this string source, char val, int nth = 0)
		{
			int num = source.IndexOf(val);
			for (int i = 0; i < nth; i++)
			{
				if (num == -1)
				{
					return -1;
				}
				num = source.IndexOf(val, num + 1);
			}
			return num;
		}

		public static bool CheckNameRegex(string displayName)
		{
			return symbolRegex.IsMatch(displayName);
		}

		public static IRCTags ParseTags(string tagString)
		{
			IRCTags iRCTags = new IRCTags();
			string[] array = tagString.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Substring(array[i].IndexOf('=') + 1);
				if (text.Length > 0)
				{
					switch (array[i].Substring(0, array[i].IndexOf('=')))
					{
					case "badges":
						iRCTags.badges = ParseBadges(text.Split(','));
						break;
					case "color":
						iRCTags.colorHex = text;
						break;
					case "display-name":
						iRCTags.displayName = text;
						break;
					case "emotes":
						iRCTags.emotes = ParseTwitchEmotes(text.Split('/'));
						break;
					case "room-id":
						iRCTags.channelId = text;
						break;
					case "user-id":
						iRCTags.userId = text;
						break;
					}
				}
			}
			return iRCTags;
		}

		public static string ParseLoginName(string ircString)
		{
			return ircString.Substring(1, ircString.IndexOf('!') - 1);
		}

		public static string ParseChannel(string ircString)
		{
			string text = ircString.Substring(ircString.IndexOf('#') + 1);
			int num = text.IndexOf(' ');
			if (num == -1)
			{
				return text;
			}
			return text.Substring(0, num);
		}

		public static string ParseMessage(string ircString)
		{
			return ircString.Substring(ircString.IndexOfNth(' ', 2) + 2);
		}

		public static ChatterEmote[] ParseTwitchEmotes(string[] splitEmotes)
		{
			ChatterEmote[] array = new ChatterEmote[splitEmotes.Length];
			for (int i = 0; i < splitEmotes.Length; i++)
			{
				string text = splitEmotes[i];
				string[] array2 = ((text.Substring(text.IndexOf(':') + 1).Length > 0) ? text.Substring(text.IndexOf(':') + 1).Split(',') : new string[0]);
				ChatterEmote.Index[] array3 = new ChatterEmote.Index[array2.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j].startIndex = int.Parse(array2[j].Substring(0, array2[j].IndexOf('-')));
					array3[j].endIndex = int.Parse(array2[j].Substring(array2[j].IndexOf('-') + 1));
				}
				array[i] = new ChatterEmote
				{
					id = text.Substring(0, text.IndexOf(':')),
					indexes = array3
				};
			}
			return array;
		}

		public static ChatterBadge[] ParseBadges(string[] splitBadges)
		{
			ChatterBadge[] array = new ChatterBadge[splitBadges.Length];
			for (int i = 0; i < splitBadges.Length; i++)
			{
				string text = splitBadges[i];
				array[i].id = text.Substring(0, text.IndexOf('/'));
				array[i].version = text.Substring(text.IndexOf('/') + 1);
			}
			return array;
		}
	}
}
