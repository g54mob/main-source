using System;
using System.Collections.Generic;
using System.Text;

namespace Febucci.Parsing
{
	public class RegionParameters : IEquatable<RegionParameters>
	{
		private readonly int stringsCount;

		private readonly int multFloatCount;

		private readonly int equalFloatCount;

		public readonly int keywordsCount;

		private readonly Dictionary<string, string> strings;

		private readonly Dictionary<string, float> equalFloats;

		private readonly Dictionary<string, float> multFloats;

		public readonly HashSet<string> keywords;

		private int? cachedHashCode;

		public RegionParameters(params string[] args)
		{
			equalFloats = new Dictionary<string, float>();
			multFloats = new Dictionary<string, float>();
			strings = new Dictionary<string, string>();
			keywords = new HashSet<string>();
			if (args == null || args.Length == 0)
			{
				return;
			}
			foreach (string text in args)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				bool flag = true;
				int num = text.IndexOf('=');
				if (num <= 0)
				{
					num = text.IndexOf('*');
					if (num <= 0)
					{
						keywords.Add(text);
						continue;
					}
					flag = false;
				}
				if (FormatUtils.TryGetFloat(text.Substring(num + 1), 0f, out var result))
				{
					if (flag)
					{
						equalFloats.TryAdd(text.Substring(0, num), result);
					}
					else
					{
						multFloats.TryAdd(text.Substring(0, num), result);
					}
				}
				else
				{
					strings.TryAdd(text.Substring(0, num), text.Substring(num + 1));
				}
			}
			keywordsCount = keywords.Count;
			stringsCount = strings.Count;
			multFloatCount = multFloats.Count;
			equalFloatCount = equalFloats.Count;
		}

		public float ModifyFloat(string name, float fallback)
		{
			float num = fallback;
			if (equalFloatCount > 0)
			{
				num = equalFloats.GetValueOrDefault(name, fallback);
			}
			if (multFloatCount > 0 && multFloats.TryGetValue(name, out var value))
			{
				num *= value;
			}
			return num;
		}

		public float GetFloatValueOrDefaults(string name, float defaultValue)
		{
			if (equalFloatCount == 0)
			{
				return defaultValue;
			}
			return equalFloats.GetValueOrDefault(name, defaultValue);
		}

		public string GetStringValueOrDefault(string name, string defaultValue)
		{
			if (stringsCount == 0)
			{
				return defaultValue;
			}
			return strings.GetValueOrDefault(name, defaultValue);
		}

		public bool HasFloat(string name)
		{
			if (equalFloatCount > 0)
			{
				return equalFloats.ContainsKey(name);
			}
			return false;
		}

		public bool HasString(string name)
		{
			if (stringsCount > 0)
			{
				return strings.ContainsKey(name);
			}
			return false;
		}

		public bool HasKeyword(string word)
		{
			if (keywordsCount > 0)
			{
				return keywords.Contains(word);
			}
			return false;
		}

		public bool Equals(RegionParameters other)
		{
			if (other == null)
			{
				return false;
			}
			if (keywords.Count != other.keywords.Count)
			{
				return false;
			}
			if (!keywords.SetEquals(other.keywords))
			{
				return false;
			}
			if (strings.Count != other.strings.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, string> @string in strings)
			{
				if (!other.strings.TryGetValue(@string.Key, out var value) || value != @string.Value)
				{
					return false;
				}
			}
			if (equalFloats.Count != other.equalFloats.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, float> equalFloat in equalFloats)
			{
				if (!other.equalFloats.TryGetValue(equalFloat.Key, out var value2) || value2 != equalFloat.Value)
				{
					return false;
				}
			}
			if (multFloats.Count != other.multFloats.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, float> multFloat in multFloats)
			{
				if (!other.multFloats.TryGetValue(multFloat.Key, out var value3) || value3 != multFloat.Value)
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is RegionParameters other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (cachedHashCode.HasValue)
			{
				return cachedHashCode.Value;
			}
			int num = 17;
			foreach (string keyword in keywords)
			{
				num = num * 31 + (keyword?.GetHashCode() ?? 0);
			}
			foreach (KeyValuePair<string, string> @string in strings)
			{
				num = num * 31 + (@string.Key?.GetHashCode() ?? 0);
				num = num * 31 + (@string.Value?.GetHashCode() ?? 0);
			}
			foreach (KeyValuePair<string, float> equalFloat in equalFloats)
			{
				num = num * 31 + (equalFloat.Key?.GetHashCode() ?? 0);
				num = num * 31 + equalFloat.Value.GetHashCode();
			}
			foreach (KeyValuePair<string, float> multFloat in multFloats)
			{
				num = num * 31 + (multFloat.Key?.GetHashCode() ?? 0);
				num = num * 31 + multFloat.Value.GetHashCode();
			}
			cachedHashCode = num;
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("RegionParameters");
			stringBuilder.Append('(');
			bool flag = false;
			if (keywords.Count > 0)
			{
				flag = true;
				stringBuilder.Append("Words:");
				foreach (string keyword in keywords)
				{
					stringBuilder.Append(keyword);
					stringBuilder.Append(',');
				}
			}
			if (strings.Count > 0)
			{
				if (flag)
				{
					stringBuilder.Append('\n');
				}
				flag = true;
				stringBuilder.Append("Strings:");
				foreach (KeyValuePair<string, string> @string in strings)
				{
					stringBuilder.Append("\n -");
					stringBuilder.Append(@string.Key);
					stringBuilder.Append('=');
					stringBuilder.Append(@string.Value);
				}
			}
			if (equalFloats.Count > 0)
			{
				if (flag)
				{
					stringBuilder.Append('\n');
				}
				flag = true;
				stringBuilder.Append("Floats:");
				foreach (KeyValuePair<string, float> equalFloat in equalFloats)
				{
					stringBuilder.Append("\n -");
					stringBuilder.Append(equalFloat.Key);
					stringBuilder.Append('=');
					stringBuilder.Append(equalFloat.Value);
				}
			}
			if (!flag)
			{
				stringBuilder.Append("Empty");
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}
	}
}
