using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
	public static class DelimiterUtils
	{
		private static readonly char[] COMMON_DELIMITERS = new char[4] { ',', '\t', ';', '|' };

		public static Delimiter DetectDelimiterFromContent(string content)
		{
			if (string.IsNullOrWhiteSpace(content))
			{
				return Delimiter.Comma;
			}
			string firstLine = content.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None).FirstOrDefault((string line) => !string.IsNullOrWhiteSpace(line));
			if (string.IsNullOrWhiteSpace(firstLine))
			{
				return Delimiter.Comma;
			}
			KeyValuePair<char, int> keyValuePair = (from kvp in COMMON_DELIMITERS.ToDictionary((char d) => d, (char d) => firstLine.Count((char c) => c == d))
				orderby kvp.Value descending
				select kvp).First();
			if (keyValuePair.Value <= 1)
			{
				return Delimiter.Comma;
			}
			return CharToDelimiter(keyValuePair.Key);
		}

		public static char ToChar(this Delimiter delimiter)
		{
			return delimiter switch
			{
				Delimiter.Comma => ',', 
				Delimiter.Tab => '\t', 
				Delimiter.Semicolon => ';', 
				Delimiter.Pipe => '|', 
				_ => throw new ArgumentException($"Unsupported delimiter: {delimiter}"), 
			};
		}

		public static Delimiter CharToDelimiter(char delimiterChar)
		{
			return delimiterChar switch
			{
				',' => Delimiter.Comma, 
				'\t' => Delimiter.Tab, 
				';' => Delimiter.Semicolon, 
				'|' => Delimiter.Pipe, 
				_ => Delimiter.Comma, 
			};
		}
	}
}
