using System.Collections.Generic;
using System.Text;

public static class RichTextTagStripper
{
	private static readonly string[] Tags;

	private static readonly Dictionary<char, List<string>> TagDict;

	private static StringBuilder _sb;

	static RichTextTagStripper()
	{
		Tags = new string[6] { "b", "i", "size", "color", "material", "quad" };
		TagDict = new Dictionary<char, List<string>>();
		_sb = new StringBuilder();
		string[] tags = Tags;
		foreach (string text in tags)
		{
			List<string> value;
			if (!TagDict.TryGetValue(text[0], out value))
			{
				value = new List<string>();
				TagDict[text[0]] = value;
			}
			value.Add(text);
		}
	}

	private static string MatchTag(string input, int from)
	{
		char key = char.ToLower(input[from]);
		List<string> value;
		if (TagDict.TryGetValue(key, out value))
		{
			int num = input.Length - from;
			for (int i = 0; i < value.Count; i++)
			{
				string text = value[i];
				if (num < text.Length)
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < text.Length; j++)
				{
					if (char.ToLower(input[from + j]) != text[j])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return text;
				}
			}
		}
		return null;
	}

	private static int FindEndTag(string input, int from)
	{
		if (from >= input.Length)
		{
			return -1;
		}
		bool flag = input[from] == '=';
		for (int i = from; i < input.Length; i++)
		{
			if (input[i] == '>')
			{
				return i;
			}
			if (!flag)
			{
				return -1;
			}
		}
		return -1;
	}

	public static string StripRichTags(this string input)
	{
		_sb.Clear();
		for (int i = 0; i < input.Length; i++)
		{
			char c = input[i];
			if (c == '<' && i + 1 < input.Length)
			{
				bool flag = false;
				if (input[i + 1] == '/' && i + 2 < input.Length)
				{
					string text = MatchTag(input, i + 2);
					if (text != null)
					{
						int num = FindEndTag(input, i + 2 + text.Length);
						if (num != -1)
						{
							i = num;
							flag = true;
						}
					}
				}
				else
				{
					string text2 = MatchTag(input, i + 1);
					if (text2 != null)
					{
						int num2 = FindEndTag(input, i + 1 + text2.Length);
						if (num2 != -1)
						{
							i = num2;
							flag = true;
						}
					}
				}
				if (!flag)
				{
					_sb.Append(c);
				}
			}
			else
			{
				_sb.Append(c);
			}
		}
		return _sb.ToString();
	}
}
