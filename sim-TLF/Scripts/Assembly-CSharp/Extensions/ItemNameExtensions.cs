using System.Text;
using System.Text.RegularExpressions;

namespace Extensions
{
	public static class ItemNameExtensions
	{
		public static string RemoveCloned(this string name)
		{
			return Regex.Replace(name, "\\s*\\(Clone\\)", string.Empty).Trim();
		}

		public static string RemoveDigits(this string name)
		{
			return Regex.Replace(name, "\\d", string.Empty);
		}

		public static string RemoveBrackets(this string name)
		{
			return Regex.Replace(Regex.Replace(name, "\\(.*?\\)|\\[.*?\\]|\\{.*?\\}", string.Empty), "[\\(\\)\\[\\]\\{\\}]", string.Empty).Trim();
		}

		public static string ReplaceSeparator(this string name, char separator = '_')
		{
			return name.Replace(separator, ' ');
		}

		public static string ToTitleCase(this string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return name;
			}
			string[] array = name.Split(' ');
			StringBuilder stringBuilder = new StringBuilder();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(' ');
					}
					stringBuilder.Append(char.ToUpper(text[0]));
					if (text.Length > 1)
					{
						stringBuilder.Append(text.Substring(1).ToLower());
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static string NormalizeSpaces(this string name)
		{
			return Regex.Replace(name.Trim(), "\\s{2,}", " ");
		}

		public static string ToCleanName(this string name)
		{
			return name.RemoveCloned().RemoveBrackets().RemoveDigits()
				.ReplaceSeparator()
				.NormalizeSpaces()
				.ToTitleCase();
		}
	}
}
