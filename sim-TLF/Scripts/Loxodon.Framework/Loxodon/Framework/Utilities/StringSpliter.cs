using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loxodon.Framework.Utilities
{
	public class StringSpliter : IEnumerator<char>, IEnumerator, IDisposable
	{
		private static readonly char[] SEPARATOR = new char[1] { ',' };

		[ThreadStatic]
		private static StringSpliter spliter;

		private string text;

		private char[] separators;

		private int total;

		private int pos = -1;

		private readonly List<string> items = new List<string>();

		private static StringSpliter Spliter
		{
			get
			{
				if (spliter == null)
				{
					spliter = new StringSpliter();
				}
				return spliter;
			}
		}

		public char Current => text[pos];

		object IEnumerator.Current => text[pos];

		public static string[] Split(string input, params char[] characters)
		{
			return Split(input, characters, StringSplitOptions.None);
		}

		public static string[] Split(string input, char[] characters, StringSplitOptions options)
		{
			if (string.IsNullOrEmpty(input))
			{
				return new string[0];
			}
			StringSpliter stringSpliter = Spliter;
			try
			{
				stringSpliter.Reset(input, characters);
				return stringSpliter.Split(options);
			}
			finally
			{
				stringSpliter.Clear();
			}
		}

		private StringSpliter()
		{
		}

		public void Reset(string text, char[] separators)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Invalid argument", "text");
			}
			if (separators == null || separators.Length == 0)
			{
				this.separators = SEPARATOR;
			}
			else
			{
				this.separators = separators;
			}
			this.text = text;
			total = this.text.Length;
			pos = -1;
			items.Clear();
		}

		public void Dispose()
		{
			text = null;
			pos = -1;
		}

		public bool MoveNext()
		{
			if (pos < total - 1)
			{
				pos++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			pos = -1;
			items.Clear();
		}

		public void Clear()
		{
			text = null;
			separators = null;
			pos = -1;
			total = 0;
			items.Clear();
		}

		public string[] Split(StringSplitOptions options)
		{
			while (MoveNext())
			{
				char current = Current;
				if (separators.Contains(current))
				{
					if (options == StringSplitOptions.None)
					{
						items.Add("");
					}
				}
				else
				{
					string item = ReadString(separators);
					items.Add(item);
				}
			}
			if (separators.Contains(Current) && options == StringSplitOptions.None)
			{
				items.Add("");
			}
			return items.ToArray();
		}

		private bool IsEOF()
		{
			return pos >= total;
		}

		private void ReadStructString(StringBuilder buf, char start, char end)
		{
			char current = Current;
			if (current != start)
			{
				throw new Exception($"Error parsing string , unexpected quote character {current} in text {text}");
			}
			buf.Append(current);
			while (MoveNext())
			{
				current = Current;
				switch (current)
				{
				case '(':
					ReadStructString(buf, '(', ')');
					continue;
				case '[':
					ReadStructString(buf, '[', ']');
					continue;
				case '{':
					ReadStructString(buf, '{', '}');
					continue;
				case '<':
					ReadStructString(buf, '<', '>');
					continue;
				}
				buf.Append(current);
				if (current == end)
				{
					return;
				}
			}
			throw new Exception($"Not found the end character '{end}' in the text {text}.");
		}

		private void ReadQuotedString(StringBuilder buf, char start, char end)
		{
			char current = Current;
			if (current != start)
			{
				throw new Exception($"Error parsing string , unexpected quote character {current} in text {text}");
			}
			while (MoveNext())
			{
				char num = current;
				current = Current;
				if (num != '\\' && current == end)
				{
					return;
				}
				buf.Append(current);
			}
			throw new Exception($"Not found the end character '{end}' in the text {text}.");
		}

		private string ReadString(char[] separators)
		{
			StringBuilder stringBuilder = new StringBuilder();
			char current = Current;
			do
			{
				current = Current;
				switch (current)
				{
				case '(':
					ReadStructString(stringBuilder, '(', ')');
					continue;
				case '[':
					ReadStructString(stringBuilder, '[', ']');
					continue;
				case '{':
					ReadStructString(stringBuilder, '{', '}');
					continue;
				case '<':
					ReadStructString(stringBuilder, '<', '>');
					continue;
				case '\'':
					ReadQuotedString(stringBuilder, '\'', '\'');
					continue;
				case '"':
					ReadQuotedString(stringBuilder, '"', '"');
					continue;
				default:
					if (separators.Contains(current))
					{
						break;
					}
					stringBuilder.Append(current);
					continue;
				}
				break;
			}
			while (MoveNext());
			stringBuilder.Replace("&quot;", "\"");
			stringBuilder.Replace("\\\"", "\"");
			return stringBuilder.ToString();
		}
	}
}
