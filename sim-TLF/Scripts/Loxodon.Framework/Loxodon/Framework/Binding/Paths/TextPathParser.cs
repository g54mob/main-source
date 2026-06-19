using System;
using System.Linq;

namespace Loxodon.Framework.Binding.Paths
{
	public struct TextPathParser
	{
		private string text;

		private int total;

		private int pos;

		public char Current => text[pos];

		public static Path Parse(string text)
		{
			return new TextPathParser(text).Parse();
		}

		public TextPathParser(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Invalid argument", "text");
			}
			this.text = ((text.IndexOf(' ') == -1) ? text : text.Replace(" ", ""));
			if (string.IsNullOrEmpty(this.text) || this.text[0] == '.')
			{
				throw new ArgumentException("Invalid argument", "text");
			}
			total = this.text.Length;
			pos = -1;
		}

		public bool MoveNext()
		{
			if (pos++ < total - 1)
			{
				return true;
			}
			return false;
		}

		private bool IsEOF()
		{
			return pos >= total;
		}

		public Path Parse()
		{
			Path path = new Path();
			MoveNext();
			do
			{
				SkipWhiteSpaceAndCharacters('.');
				if (IsEOF())
				{
					break;
				}
				if (Current.Equals('['))
				{
					ParseIndex(path);
					SkipWhiteSpace();
					if (!Current.Equals(']'))
					{
						throw new BindingException("Error parsing indexer , unterminated in text {0}", text);
					}
					if (MoveNext() && !Current.Equals('.'))
					{
						throw new BindingException("Error parsing path , unterminated in text {0}", text);
					}
				}
				else
				{
					if (!char.IsLetter(Current) && Current != '_')
					{
						throw new BindingException("Error parsing path , unterminated in text {0}", text);
					}
					string name = ReadMemberName();
					path.Append(new MemberNode(name));
					if (!IsEOF() && !Current.Equals('.') && !Current.Equals('[') && !char.IsWhiteSpace(Current))
					{
						throw new BindingException("Error parsing path , unterminated in text {0}", text);
					}
				}
			}
			while (!IsEOF());
			return path;
		}

		private void ParseIndex(Path path)
		{
			if (!MoveNext())
			{
				throw new BindingException("Error parsing string indexer , unterminated in text {0}", text);
			}
			char current = Current;
			if (current == '\'' || current == '"')
			{
				string indexValue = ReadQuotedString();
				path.AppendIndexed(indexValue);
				MoveNext();
				return;
			}
			if (char.IsDigit(current))
			{
				uint indexValue2 = ReadUnsignedInteger();
				path.AppendIndexed((int)indexValue2);
				return;
			}
			throw new BindingException("Error parsing indexer , unterminated in text {0}", text);
		}

		private unsafe string ReadMemberName()
		{
			char* ptr = stackalloc char[128];
			int num = 0;
			do
			{
				char current = Current;
				if (!char.IsLetterOrDigit(current) && current != '_')
				{
					break;
				}
				ptr[num++] = current;
			}
			while (MoveNext());
			if (num <= 0)
			{
				throw new BindingException("Error parsing member name , unterminated in text {0}", text);
			}
			return new string(ptr, 0, num);
		}

		private unsafe uint ReadUnsignedInteger()
		{
			char* ptr = stackalloc char[128];
			int length = 0;
			do
			{
				char current = Current;
				if (!char.IsDigit(current))
				{
					break;
				}
				ptr[length++] = current;
			}
			while (MoveNext());
			string text = new string(ptr, 0, length);
			if (!uint.TryParse(text, out var result))
			{
				throw new BindingException("Unable to parse integer text from {0} in {1}", text, this.text);
			}
			return result;
		}

		private unsafe string ReadQuotedString()
		{
			char current = Current;
			if (current != '\'' && current != '"')
			{
				throw new BindingException("Error parsing string indexer , unexpected quote character {0} in text {1}", current, text);
			}
			if (!MoveNext())
			{
				throw new BindingException("Error parsing string indexer , unterminated in text {0}", text);
			}
			char* ptr = stackalloc char[128];
			int num = 0;
			do
			{
				current = Current;
				if (!char.IsLetterOrDigit(current) && current != '_' && current != '-')
				{
					break;
				}
				ptr[num++] = current;
			}
			while (MoveNext());
			if (num <= 0 || (current != '\'' && current != '"'))
			{
				throw new BindingException("Error parsing string indexer , unexpected quote character {0} in text {1}", current, text);
			}
			return new string(ptr, 0, num);
		}

		private void SkipWhiteSpace()
		{
			while (char.IsWhiteSpace(Current) && MoveNext())
			{
			}
		}

		private bool IsWhiteSpaceOrCharacter(char ch, params char[] characters)
		{
			if (!char.IsWhiteSpace(ch))
			{
				return characters.Contains(ch);
			}
			return true;
		}

		private void SkipWhiteSpaceAndCharacters(params char[] characters)
		{
			while (IsWhiteSpaceOrCharacter(Current, characters) && MoveNext())
			{
			}
		}
	}
}
