using System;
using System.Text;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class CommentParser : Parser
	{
		public override Token Parse(ExtendedStringReader reader)
		{
			if (!IsComment(reader))
			{
				return null;
			}
			Token token = null;
			bool isEscaped;
			string text = AccumulateComment(reader, out isEscaped).Trim();
			if (text.StartsWith("<") && !isEscaped)
			{
				token = Token.Layout(text.Substring(1).Trim());
			}
			return token ?? Token.Comment(text);
		}

		private static bool IsComment(ExtendedStringReader reader)
		{
			return (ushort)reader.Peek() == 33;
		}

		private static string AccumulateComment(ExtendedStringReader reader, out bool isEscaped)
		{
			reader.Read();
			bool? flag = null;
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				while (true)
				{
					if (!flag.HasValue)
					{
						flag = CheckIfEscaped(reader, value);
					}
					if (IsClosed(reader, value, flag.Value))
					{
						break;
					}
					int num = reader.Read();
					if (num == -1)
					{
						throw new HandlebarsParserException("Reached end of template in the middle of a comment", reader.GetContext());
					}
					value.Append((char)num);
				}
				isEscaped = flag.Value;
				return value.ToString();
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private static bool IsClosed(ExtendedStringReader reader, StringBuilder buffer, bool isEscaped)
		{
			if (!isEscaped || !CheckIfEscaped(reader, buffer) || !CheckIfStatementClosed(reader))
			{
				if (!isEscaped)
				{
					return CheckIfStatementClosed(reader);
				}
				return false;
			}
			return true;
		}

		private static bool CheckIfStatementClosed(ExtendedStringReader reader)
		{
			return (ushort)reader.Peek() == 125;
		}

		private static bool CheckIfEscaped(ExtendedStringReader reader, StringBuilder buffer)
		{
			if ((ushort)reader.Peek() != 45)
			{
				return false;
			}
			bool result = false;
			int value = reader.Read();
			if ((ushort)reader.Peek() == 45)
			{
				reader.Read();
				result = true;
			}
			else
			{
				buffer.Append(value);
			}
			return result;
		}
	}
}
