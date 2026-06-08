using System;
using System.Collections.Generic;
using System.Text;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class BlockWordParser : Parser
	{
		private static readonly HashSet<char> ValidBlockWordStartCharacters = new HashSet<char> { '#', '^', '/' };

		public override Token Parse(ExtendedStringReader reader)
		{
			if (!IsBlockWord(reader))
			{
				return null;
			}
			IReaderContext context = reader.GetContext();
			return Token.Word(AccumulateBlockWord(reader), context);
		}

		private static bool IsBlockWord(ExtendedStringReader reader)
		{
			char item = (char)reader.Peek();
			return ValidBlockWordStartCharacters.Contains(item);
		}

		private static string AccumulateBlockWord(ExtendedStringReader reader)
		{
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				value.Append((char)reader.Read());
				while (char.IsWhiteSpace((char)reader.Peek()))
				{
					reader.Read();
				}
				while (true)
				{
					char c = (char)reader.Peek();
					if (c == '}' || c == '~' || char.IsWhiteSpace(c))
					{
						break;
					}
					int num = reader.Read();
					if (num == -1)
					{
						throw new HandlebarsParserException("Reached end of template before the expression was closed.", reader.GetContext());
					}
					value.Append((char)num);
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
