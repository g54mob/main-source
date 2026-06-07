using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RtlHelper
{
	private enum Dir
	{
		None = 0,
		LTR = 1,
		RTL = 2,
		InheritPrev = 3,
		InheritNext = 4,
		Solo = 5,
		Merge = 6
	}

	private class Segment
	{
		public string text = string.Empty;

		public Dir dir;

		public string reversedText
		{
			get
			{
				string text = string.Empty;
				for (int i = 0; i < this.text.Length; i++)
				{
					char c = this.text[this.text.Length - 1 - i];
					switch (c)
					{
					case '(':
						c = ')';
						break;
					case ')':
						c = '(';
						break;
					case '[':
						c = ']';
						break;
					case ']':
						c = '[';
						break;
					case '<':
						c = '>';
						break;
					case '{':
						c = '}';
						break;
					case '}':
						c = '{';
						break;
					default:
						if (c == '<')
						{
							c = '>';
						}
						else if (c == '>')
						{
							c = '<';
						}
						else if (c == '「')
						{
							c = '」';
						}
						else if (c == '」')
						{
							c = '「';
						}
						else if (c == '←')
						{
							continue;
						}
						break;
					}
					text += c;
				}
				return text;
			}
		}

		public string reversedOrder
		{
			get
			{
				string text = string.Empty;
				int num = 0;
				for (int i = 0; i < this.text.Length; i++)
				{
					char c = this.text[this.text.Length - 1 - i];
					if (c != '←')
					{
						text += 9 - num;
						num = (num + 1) % 10;
					}
				}
				return text;
			}
		}

		public string order
		{
			get
			{
				string text = string.Empty;
				int num = 0;
				for (int i = 0; i < this.text.Length; i++)
				{
					char c = this.text[this.text.Length - 1 - i];
					if (c != '←')
					{
						text += num;
						num = (num + 1) % 10;
					}
				}
				return text;
			}
		}

		public bool Append(char c, Dir cDir)
		{
			if (dir == Dir.None || dir == Dir.InheritNext)
			{
				text += c;
				dir = cDir;
				return true;
			}
			if (dir == Dir.Solo)
			{
				return false;
			}
			if (cDir == dir || cDir == Dir.InheritPrev)
			{
				text += c;
				return true;
			}
			return false;
		}
	}

	public const char kRtlMarkerChar = '←';

	public const string kRtlMarkerString = "←";

	private static Regex rtlRegex = new Regex("[\\u0600-\\u06FF\\u0750-\\u077F\\u0870-\\u089F\\u08A0-\\u08FF\\uFB50-\\uFDFF\\uFE70-\\uFEFF]+");

	public static bool HasRtl(string text)
	{
		return rtlRegex.IsMatch(text);
	}

	public static string FlipTags(string text)
	{
		if (text.Contains("</size>"))
		{
			MatchCollection matchCollection = Regex.Matches(text, "(<[/]?size[^>]*>)", RegexOptions.Multiline);
			string text2 = string.Empty;
			int num = 0;
			for (int i = 0; i < matchCollection.Count - 1; i += 2)
			{
				Group obj = matchCollection[i].Groups[1];
				Group obj2 = matchCollection[i + 1].Groups[1];
				text2 += text.Substring(num, obj.Index - num);
				text2 += obj2.ToString();
				text2 += text.Substring(obj.Index + obj.Length, obj2.Index - (obj.Index + obj.Length));
				text2 += obj.ToString();
				num = obj2.Index + obj2.Length;
			}
			return text2 + text.Substring(num, text.Length - num);
		}
		return text;
	}

	public static string Reverse(string text)
	{
		if (text.Contains("\n"))
		{
			string[] array = text.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ReverseParagraph(array[i]);
			}
			return string.Join("\n", array);
		}
		return ReverseParagraph(text);
	}

	private static string ReverseParagraph(string text)
	{
		if (!HasRtl(text))
		{
			return text;
		}
		text = FlipTags(text);
		List<Segment> list = new List<Segment>();
		Segment segment = new Segment();
		list.Add(segment);
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			Dir dir = GetDir(c, i == text.Length - 1);
			if (!segment.Append(c, dir))
			{
				segment = new Segment();
				list.Add(segment);
				segment.Append(c, dir);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			Segment segment2 = list[j];
			if (segment2.dir == Dir.InheritNext)
			{
				for (int k = j + 1; k < list.Count; k++)
				{
					Segment segment3 = list[k];
					if (segment3.dir != Dir.InheritPrev && segment3.dir != Dir.InheritNext)
					{
						segment2.dir = segment3.dir;
						break;
					}
				}
			}
			else
			{
				if (segment2.dir != Dir.InheritPrev)
				{
					continue;
				}
				for (int num = j - 1; num >= 0; num--)
				{
					Segment segment4 = list[num];
					if (segment4.dir != Dir.InheritPrev && segment4.dir != Dir.InheritNext)
					{
						segment2.dir = segment4.dir;
						break;
					}
				}
			}
		}
		for (int l = 1; l < list.Count - 1; l++)
		{
			Segment segment5 = list[l - 1];
			Segment segment6 = list[l];
			Segment segment7 = list[l + 1];
			if (segment6.dir == Dir.Merge && segment5.dir == segment7.dir)
			{
				segment7.text = segment5.text + segment6.text + segment7.text;
				segment5.text = string.Empty;
				segment6.text = string.Empty;
			}
		}
		string text2 = string.Empty;
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			text2 = ((list[num2].dir != Dir.RTL) ? (text2 + list[num2].text) : (text2 + list[num2].reversedText));
		}
		return text2;
	}

	private static void LogRaw(string s)
	{
		List<string> list = new List<string>();
		char[] array = s.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			list.Add(c.ToString());
		}
		Debug.Log(string.Join("/", list.ToArray()));
	}

	private static Dir GetDir(char c, bool isLast)
	{
		if ((c >= '\u0600' && c <= 'ۿ') || (c >= 'ݐ' && c <= 'ݿ') || (c >= 'ࡰ' && c <= '\u089f') || (c >= 'ࢠ' && c <= '\u08ff') || (c >= 'ﭐ' && c <= '﷿') || (c >= 'ﹰ' && c <= '\ufeff') || c == '←')
		{
			return Dir.RTL;
		}
		if (isLast && (false || c == '!' || c == '?' || c == '.'))
		{
			return Dir.Solo;
		}
		if (false || c == '”' || c == '"' || c == '\'' || c == ')' || c == '}' || c == '>' || c == '」' || c == ',' || c == '•' || c == '!' || c == '?' || c == '.')
		{
			return Dir.InheritPrev;
		}
		if (false || c == '(' || c == '{' || c == '<' || c == '「' || c == '“')
		{
			return Dir.InheritNext;
		}
		if (false || c == '|' || c == ':')
		{
			return Dir.Solo;
		}
		if (false || c == ' ' || c == '\n')
		{
			return Dir.Merge;
		}
		return Dir.LTR;
	}
}
