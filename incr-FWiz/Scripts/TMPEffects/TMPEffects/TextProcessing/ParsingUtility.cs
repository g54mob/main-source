using System;
using System.Collections.Generic;

namespace TMPEffects.TextProcessing
{
	public static class ParsingUtility
	{
		[Flags]
		public enum TagType
		{
			Open = 1,
			Close = 2
		}

		public class TagInfo
		{
			public TagType type;

			public char prefix;

			public string name;

			public string parameterString;

			public int startIndex;

			public int endIndex;

			public TagInfo(int startIndex, int endIndex, TagType type, char prefix, string name, string parameterString)
			{
			}

			public TagInfo()
			{
			}
		}

		public static bool GetNextTag(string text, int startIndex, ref TagInfo tag, TagType type = TagType.Open | TagType.Close)
		{
			return false;
		}

		public static bool TryParseTag(string text, int startIndex, int endIndex, ref TagInfo tag, TagType type = TagType.Open | TagType.Close)
		{
			return false;
		}

		public static bool IsTag(string text, int startIndex, int maxIndex = -1, TagType type = TagType.Open | TagType.Close)
		{
			return false;
		}

		public static bool IsTag(string tag, TagType type = TagType.Open | TagType.Close)
		{
			return false;
		}

		public static Dictionary<string, string> GetTagParametersDict(string tag)
		{
			return null;
		}

		private static bool TryParseTagName(string text, int startIndex, ref string name)
		{
			return false;
		}

		private static void ParseKeyValue(string text, out string key, out string value, out int endValue)
		{
			key = null;
			value = null;
			endValue = default(int);
		}

		private static bool HasTagPrefix(string text, int index)
		{
			return false;
		}

		private static TagType GetTagType(string text, int start)
		{
			return default(TagType);
		}

		private static bool IsWellFormed(string text, int start, int end, TagType type = TagType.Open | TagType.Close)
		{
			return false;
		}
	}
}
