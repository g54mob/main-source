using System;
using System.Collections.Generic;
using System.Text;
using HandlebarsDotNet.Extensions;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class WordParser : Parser
	{
		private const string ValidWordStartCharactersString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_$.@[]*";

		private static readonly HashSet<char> ValidWordStartCharacters;

		static WordParser()
		{
			ValidWordStartCharacters = new HashSet<char>();
			for (int i = 0; i < "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_$.@[]*".Length; i++)
			{
				ValidWordStartCharacters.Add("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_$.@[]*"[i]);
			}
		}

		public override Token Parse(ExtendedStringReader reader)
		{
			IReaderContext context = reader.GetContext();
			if (!IsWord(reader))
			{
				return null;
			}
			return Token.Word(AccumulateWord(reader), context);
		}

		private static bool IsWord(ExtendedStringReader reader)
		{
			int num = reader.Peek();
			return ValidWordStartCharacters.Contains((char)num);
		}

		private static string AccumulateWord(ExtendedStringReader reader)
		{
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				bool flag = false;
				bool flag2 = false;
				while (true)
				{
					if (!flag && !flag2)
					{
						char c = (char)reader.Peek();
						if (c == '}' || c == '~' || c == ')' || c == '=' || char.IsWhiteSpace(c))
						{
							break;
						}
					}
					int num = reader.Read();
					if (num == -1)
					{
						throw new HandlebarsParserException("Reached end of template before the expression was closed.", reader.GetContext());
					}
					if (flag2)
					{
						char c2 = (char)num;
						if (c2 == ']')
						{
							flag2 = false;
						}
						value.Append(c2);
					}
					else if (num == 91 && !flag)
					{
						flag2 = true;
						value.Append((char)num);
					}
					else
					{
						if (num == 39 || num == 34)
						{
							flag = !flag;
						}
						value.Append((char)num);
					}
				}
				return value.Trim().ToString();
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
