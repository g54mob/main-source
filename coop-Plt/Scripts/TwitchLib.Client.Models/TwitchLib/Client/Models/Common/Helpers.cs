using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitchLib.Client.Models.Common
{
	public static class Helpers
	{
		public static List<string> ParseQuotesAndNonQuotes(string message)
		{
			List<string> list = new List<string>();
			if (message == "")
			{
				return new List<string>();
			}
			bool flag = message[0] != '"';
			string[] array = message.Split('"');
			foreach (string text in array)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				if (!flag)
				{
					list.Add(text);
					flag = true;
				}
				else
				{
					if (!text.Contains(" "))
					{
						continue;
					}
					string[] array2 = text.Split(' ');
					foreach (string text2 in array2)
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							list.Add(text2);
							flag = false;
						}
					}
				}
			}
			return list;
		}

		public static List<KeyValuePair<string, string>> ParseBadges(string badgesStr)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (badgesStr.Contains('/'))
			{
				if (!badgesStr.Contains(","))
				{
					list.Add(new KeyValuePair<string, string>(badgesStr.Split('/')[0], badgesStr.Split('/')[1]));
				}
				else
				{
					string[] array = badgesStr.Split(',');
					foreach (string text in array)
					{
						list.Add(new KeyValuePair<string, string>(text.Split('/')[0], text.Split('/')[1]));
					}
				}
			}
			return list;
		}

		public static string ParseToken(string token, string message)
		{
			string result = string.Empty;
			for (int num = message.IndexOf(token, StringComparison.InvariantCultureIgnoreCase); num > -1; num = message.IndexOf(token, num + token.Length, StringComparison.InvariantCultureIgnoreCase))
			{
				result = new string(message.Substring(num).TakeWhile((char x) => x != ';' && x != ' ').ToArray()).Split('=').LastOrDefault();
			}
			return result;
		}

		public static bool ConvertToBool(string data)
		{
			return data == "1";
		}
	}
}
