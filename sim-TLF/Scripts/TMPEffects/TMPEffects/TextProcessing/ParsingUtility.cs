using System;
using System.Collections.Generic;
using UnityEngine;

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
				this.startIndex = startIndex;
				this.endIndex = endIndex;
				this.type = type;
				this.prefix = prefix;
				this.name = name;
				this.parameterString = parameterString;
			}

			public TagInfo()
			{
			}
		}

		public static bool GetNextTag(string text, int startIndex, ref TagInfo tag, TagType type = TagType.Open | TagType.Close)
		{
			int num = startIndex - 1;
			int length = text.Length;
			if (num >= length - 3)
			{
				return false;
			}
			int num2;
			int num3;
			do
			{
				num++;
				num2 = text.IndexOf('<', num);
				if (num2 == -1 || num2 == length - 1)
				{
					return false;
				}
				num3 = text.IndexOf('>', num2 + 1);
				if (num3 == -1)
				{
					return false;
				}
			}
			while (!TryParseTag(text, num2, num3, ref tag, type));
			return true;
		}

		public static bool TryParseTag(string text, int startIndex, int endIndex, ref TagInfo tag, TagType type = TagType.Open | TagType.Close)
		{
			if (!IsWellFormed(text, startIndex, endIndex, type))
			{
				return false;
			}
			char prefix = '\0';
			string name = "";
			TagType tagType = GetTagType(text, startIndex);
			if ((type & tagType) == 0)
			{
				return false;
			}
			int num = startIndex + 1;
			if (tagType == TagType.Close)
			{
				num++;
			}
			if (HasTagPrefix(text, num))
			{
				prefix = text[num++];
			}
			if (!TryParseTagName(text, num, ref name) || (tagType == TagType.Open && string.IsNullOrWhiteSpace(name)))
			{
				return false;
			}
			string parameterString = text.Substring(num, endIndex - num);
			tag.startIndex = startIndex;
			tag.endIndex = endIndex;
			tag.type = tagType;
			tag.prefix = prefix;
			tag.name = name;
			tag.parameterString = parameterString;
			return true;
		}

		public static bool IsTag(string text, int startIndex, int maxIndex = -1, TagType type = TagType.Open | TagType.Close)
		{
			_ = text.Length;
			if (maxIndex == -1)
			{
				maxIndex = text.Length - 1;
			}
			if (startIndex >= maxIndex)
			{
				throw new IndexOutOfRangeException();
			}
			if (text[startIndex] != '<')
			{
				return false;
			}
			int num = text.IndexOf('<', startIndex + 1);
			int num2 = text.IndexOf('>', startIndex + 1);
			if (type.HasFlag(TagType.Close) && !type.HasFlag(TagType.Open))
			{
				if (text[startIndex + 1] != '/')
				{
					return false;
				}
			}
			else if (!type.HasFlag(TagType.Close) && type.HasFlag(TagType.Open) && text[startIndex + 1] == '/')
			{
				return false;
			}
			if (num != -1 && num2 > num)
			{
				return false;
			}
			if (num2 == -1)
			{
				return false;
			}
			return true;
		}

		public static bool IsTag(string tag, TagType type = TagType.Open | TagType.Close)
		{
			int num = tag.LastIndexOf('>');
			if (num == -1 || num != tag.Length - 1)
			{
				return false;
			}
			return IsTag(tag, 0, tag.Length, type);
		}

		public static Dictionary<string, string> GetTagParametersDict(string tag)
		{
			if (string.IsNullOrWhiteSpace(tag))
			{
				return new Dictionary<string, string> { { "", "" } };
			}
			tag = tag.Trim();
			if (tag[0] == '<')
			{
				if (!IsTag(tag))
				{
					throw new ArgumentException("tag");
				}
				tag = tag.Substring(1, tag.Length - 2);
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ParseKeyValue(tag, out var key, out var value, out var endValue);
			dictionary.Add("", value);
			tag = tag.Remove(0, Mathf.Min(endValue, tag.Length)).Trim();
			while (tag.Length > 0)
			{
				ParseKeyValue(tag, out key, out value, out endValue);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, value);
				}
				tag = tag.Remove(0, Mathf.Min(endValue, tag.Length)).Trim();
			}
			return dictionary;
		}

		private static bool TryParseTagName(string text, int startIndex, ref string name)
		{
			int length = text.Length;
			char c = '\0';
			int i;
			for (i = startIndex; i < length; i++)
			{
				c = text[i];
				if (char.IsWhiteSpace(c) || c == '=' || c == '>')
				{
					break;
				}
			}
			if (i >= length)
			{
				return false;
			}
			name = text.Substring(startIndex, i - startIndex);
			return true;
		}

		private static void ParseKeyValue(string text, out string key, out string value, out int endValue)
		{
			int i = 0;
			int length = text.Length;
			bool flag = false;
			for (; i < length; i++)
			{
				char c = text[i];
				if (c == '=')
				{
					flag = true;
					break;
				}
				if (char.IsWhiteSpace(c) || c == '>')
				{
					break;
				}
			}
			key = text.Substring(0, i);
			i = (endValue = i + 1);
			value = "";
			if (!flag || i == 0 || i == length)
			{
				return;
			}
			bool flag2 = false;
			if (text[i] == '"')
			{
				i++;
				flag2 = true;
			}
			int num = i;
			for (; i < length; i++)
			{
				char c = text[i];
				if (c == '"' || c == '>' || (!flag2 && c == ' '))
				{
					break;
				}
			}
			endValue = i + 1;
			value = text.Substring(num, i - num);
		}

		private static bool HasTagPrefix(string text, int index)
		{
			if (!char.IsLetter(text[index]))
			{
				return text[index] != '>';
			}
			return false;
		}

		private static TagType GetTagType(string text, int start)
		{
			if (text[start + 1] == '/')
			{
				return TagType.Close;
			}
			return TagType.Open;
		}

		private static bool IsWellFormed(string text, int start, int end, TagType type = TagType.Open | TagType.Close)
		{
			if (start < 0 || end <= 0)
			{
				return false;
			}
			if (text[start] != '<')
			{
				return false;
			}
			if (text[end] != '>')
			{
				return false;
			}
			if (end <= start + 1)
			{
				return false;
			}
			if ((type & GetTagType(text, start + 1)) == 0)
			{
				return false;
			}
			int num = text.IndexOf('<', start + 1);
			if (num != -1 && end > num)
			{
				return false;
			}
			return true;
		}
	}
}
