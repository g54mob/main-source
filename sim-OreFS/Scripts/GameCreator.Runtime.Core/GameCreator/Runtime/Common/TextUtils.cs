using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GameCreator.Runtime.Common
{
	public static class TextUtils
	{
		private static readonly Regex RX_VAR_NAME = new Regex("[^\\p{L}\\p{Nd}-_]");

		private static readonly Regex RX_VAR_PATH = new Regex("[^\\p{L}\\p{Nd}-_\\/]");

		private static readonly TextInfo TXT = CultureInfo.InvariantCulture.TextInfo;

		public static string Humanize(string source)
		{
			char[] array = source?.ToCharArray() ?? Array.Empty<char>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == '-')
				{
					array[i] = ' ';
				}
				if (array[i] == '_')
				{
					array[i] = ' ';
				}
			}
			source = new string(array);
			source = TXT.ToTitleCase(source);
			return source;
		}

		public static string Humanize(object source)
		{
			return Humanize(source?.ToString());
		}

		public static string ProcessID(string text, bool isPath = false)
		{
			if (!isPath)
			{
				return RX_VAR_NAME.Replace(text, "-");
			}
			return RX_VAR_PATH.Replace(text, "-");
		}

		public static string ProcessScriptName(string text)
		{
			return text.Replace(" ", string.Empty);
		}

		public static string ProcessNamespace(string text)
		{
			text = text.Replace(".", " ");
			text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);
			return text.Split(' ')[^1];
		}
	}
}
