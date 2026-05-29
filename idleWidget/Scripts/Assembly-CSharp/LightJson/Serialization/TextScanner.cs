using System.IO;

namespace LightJson.Serialization
{
	public sealed class TextScanner
	{
		private TextReader reader;

		private TextPosition position;

		public TextPosition Position => position;

		public bool CanRead => reader.Peek() != -1;

		public TextScanner(TextReader reader)
		{
			this.reader = reader;
		}

		public char Peek()
		{
			int num = reader.Peek();
			if (num == -1)
			{
				throw new JsonParseException(JsonParseException.ErrorType.IncompleteMessage, position);
			}
			return (char)num;
		}

		public char Read()
		{
			int num = reader.Read();
			if (num == -1)
			{
				throw new JsonParseException(JsonParseException.ErrorType.IncompleteMessage, position);
			}
			if (num != 10)
			{
				if (num != 13)
				{
					position.column++;
					return (char)num;
				}
				if (reader.Peek() == 10)
				{
					reader.Read();
				}
			}
			position.line++;
			position.column = 0L;
			return '\n';
		}

		public void SkipWhitespace()
		{
			while (char.IsWhiteSpace(Peek()))
			{
				Read();
			}
		}

		public void Assert(char next)
		{
			if (Peek() == next)
			{
				Read();
				return;
			}
			throw new JsonParseException($"Parser expected '{next}'", JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
		}

		public void Assert(string next)
		{
			for (int i = 0; i < next.Length; i++)
			{
				Assert(next[i]);
			}
		}
	}
}
