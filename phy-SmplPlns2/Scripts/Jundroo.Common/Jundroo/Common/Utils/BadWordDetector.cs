using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Jundroo.Common.Utils
{
	public class BadWordDetector
	{
		private static readonly List<Regex> _badWordMatchers;

		private static readonly string[] WordDefinitions;

		static BadWordDetector()
		{
			_badWordMatchers = new List<Regex>();
			WordDefinitions = new string[42]
			{
				"*nigger*", "*nigga*", "*kike*", "*faggot*", "*kys*", "white power", "88", "HH", "hitler", "kill jews",
				"kill the jews", "kill all jews", "kill all the jews", "gas the jews", "kill blacks", "kill the blacks", "kill all blacks", "kill all the blacks", "kill gays", "kill the gays",
				"kill all gays", "kill all the gays", "die jews", "die blacks", "die gays", "rape", "raping", "rapist", "chink", "gook",
				"wetback", "beaner", "fag", "dyke", "tranny", "shemale", "cunt", "whore", "slut", "bullshit",
				"fuck", "motherfucker"
			};
			string[] wordDefinitions = WordDefinitions;
			foreach (string definition in wordDefinitions)
			{
				_badWordMatchers.Add(GenerateRegexForWord(definition));
			}
		}

		public static string CleanText(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return input;
			}
			string text = input;
			foreach (Regex badWordMatcher in _badWordMatchers)
			{
				text = badWordMatcher.Replace(text, (Match m) => new string('*', m.Length));
			}
			return text;
		}

		public static bool IsTextClean(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return true;
			}
			string input2 = StripRichText(input);
			foreach (Regex badWordMatcher in _badWordMatchers)
			{
				if (badWordMatcher.IsMatch(input2))
				{
					return false;
				}
			}
			return true;
		}

		public static string StripRichText(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}
			return Regex.Replace(input, "<(?:\\/?[A-Za-z]|#)[^>]*>", string.Empty);
		}

		private static Regex GenerateRegexForWord(string definition)
		{
			bool flag = definition.StartsWith("*") && definition.EndsWith("*");
			string text = definition.Replace("*", string.Empty).Replace(" ", string.Empty);
			string text2 = (flag ? string.Empty : "\\b");
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				text2 += GetCharPattern(c);
				if (i < text.Length - 1)
				{
					text2 += "[\\W_]*";
				}
			}
			text2 += (flag ? string.Empty : "\\b");
			return new Regex(text2, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		private static string GetCharPattern(char c)
		{
			c = char.ToLowerInvariant(c);
			return c switch
			{
				'a' => "[aA4@^]", 
				'b' => "[bB8]", 
				'c' => "[cCkK(<]", 
				'e' => "[eE3]", 
				'g' => "[gG69q]", 
				'i' => "[iI1l!|]", 
				'k' => "[kKcC(<]", 
				'l' => "[lL1|]", 
				'o' => "[oO0]", 
				's' => "[sS5$zZ]", 
				't' => "[tT7+]", 
				'u' => "[uUvV]", 
				_ => Regex.Escape(c.ToString()), 
			};
		}
	}
}
