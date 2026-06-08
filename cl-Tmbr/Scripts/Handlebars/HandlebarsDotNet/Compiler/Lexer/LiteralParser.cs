using System;
using System.Linq;
using System.Text;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class LiteralParser : Parser
	{
		public override Token Parse(ExtendedStringReader reader)
		{
			IReaderContext context = reader.GetContext();
			if (IsDelimitedLiteral(reader))
			{
				char c = (char)reader.Read();
				return Token.Literal(AccumulateLiteral(reader, true, c), c.ToString(), context);
			}
			if (IsNonDelimitedLiteral(reader))
			{
				return Token.Literal(AccumulateLiteral(reader, false, ' ', ')'), null, context);
			}
			return null;
		}

		private static bool IsDelimitedLiteral(ExtendedStringReader reader)
		{
			char c = (char)reader.Peek();
			if (c != '\'')
			{
				return c == '"';
			}
			return true;
		}

		private static bool IsNonDelimitedLiteral(ExtendedStringReader reader)
		{
			char c = (char)reader.Peek();
			if (!char.IsDigit(c))
			{
				return c == '-';
			}
			return true;
		}

		private static string AccumulateLiteral(ExtendedStringReader reader, bool captureDelimiter, params char[] delimiters)
		{
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				while (true)
				{
					int num = reader.Peek();
					if (num == -1)
					{
						throw new HandlebarsParserException("Reached end of template before the expression was closed.", reader.GetContext());
					}
					if (delimiters.Contains((char)num))
					{
						if (captureDelimiter)
						{
							reader.Read();
						}
						break;
					}
					if (!captureDelimiter && (ushort)num == 125)
					{
						break;
					}
					value.Append((char)reader.Read());
				}
				return value.ToString();
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
