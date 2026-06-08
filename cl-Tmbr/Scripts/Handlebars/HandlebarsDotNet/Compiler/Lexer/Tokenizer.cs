using System;
using System.Collections.Generic;
using System.Text;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Lexer
{
	internal static class Tokenizer
	{
		private static readonly Parser WordParser = new WordParser();

		private static readonly Parser LiteralParser = new LiteralParser();

		private static readonly Parser CommentParser = new CommentParser();

		private static readonly Parser PartialParser = new PartialParser();

		private static readonly Parser BlockWordParser = new BlockWordParser();

		private static readonly Parser BlockParamsParser = new BlockParamsParser();

		public static IEnumerable<Token> Tokenize(ExtendedStringReader source)
		{
			try
			{
				return Parse(source);
			}
			catch (Exception innerException)
			{
				throw new HandlebarsParserException("An unhandled exception occurred while trying to compile the template", innerException);
			}
		}

		private static IEnumerable<Token> Parse(ExtendedStringReader source)
		{
			bool inExpression = false;
			bool trimWhitespace = false;
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> container = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder buffer = container.Value;
				int node = source.Read();
				while (true)
				{
					if (node == -1)
					{
						if (buffer.Length > 0)
						{
							if (inExpression)
							{
								throw new InvalidOperationException("Reached end of template before expression was closed");
							}
							yield return Token.Static(buffer.ToString(), source.GetContext());
							break;
						}
						break;
					}
					if (inExpression)
					{
						if ((ushort)node == 40)
						{
							yield return Token.StartSubExpression();
						}
						Token token = WordParser.Parse(source);
						if (token == null)
						{
							token = LiteralParser.Parse(source);
						}
						if (token == null)
						{
							token = CommentParser.Parse(source);
						}
						if (token == null)
						{
							token = PartialParser.Parse(source);
						}
						if (token == null)
						{
							token = BlockWordParser.Parse(source);
						}
						if (token == null)
						{
							token = BlockParamsParser.Parse(source);
						}
						if (token != null)
						{
							yield return token;
							if ((ushort)source.Peek() == 61)
							{
								source.Read();
								yield return Token.Assignment(source.GetContext());
								continue;
							}
						}
						if ((ushort)node == 125 && (ushort)source.Read() == 125)
						{
							bool isEscaped = true;
							bool isRaw = false;
							if ((ushort)source.Peek() == 125)
							{
								source.Read();
								isEscaped = false;
							}
							if ((ushort)source.Peek() == 125)
							{
								source.Read();
								isRaw = true;
							}
							node = source.Read();
							yield return Token.EndExpression(isEscaped, trimWhitespace, isRaw, source.GetContext());
							inExpression = false;
						}
						else if ((ushort)node == 41)
						{
							node = source.Read();
							yield return Token.EndSubExpression(source.GetContext());
						}
						else if (char.IsWhiteSpace((char)node) || char.IsWhiteSpace((char)source.Peek()))
						{
							node = source.Read();
						}
						else if ((ushort)node == 126)
						{
							node = source.Read();
							trimWhitespace = true;
						}
						else
						{
							if (token == null)
							{
								throw new HandlebarsParserException("Reached unparseable token in expression: " + source.ReadLine(), source.GetContext());
							}
							node = source.Read();
						}
					}
					else if ((ushort)node == 92 && (ushort)source.Peek() == 92)
					{
						source.Read();
						buffer.Append('\\');
						node = source.Read();
					}
					else if ((ushort)node == 92 && (ushort)source.Peek() == 123)
					{
						source.Read();
						if ((ushort)source.Peek() == 123)
						{
							source.Read();
							buffer.Append('{', 2);
						}
						else
						{
							buffer.Append("\\{");
						}
						node = source.Read();
					}
					else if ((ushort)node == 123 && (ushort)source.Peek() == 123)
					{
						bool escaped = true;
						bool raw = false;
						trimWhitespace = false;
						node = source.Read();
						if ((ushort)source.Peek() == 123)
						{
							node = source.Read();
							escaped = false;
						}
						if ((ushort)source.Peek() == 123)
						{
							node = source.Read();
							raw = true;
						}
						if ((ushort)source.Peek() == 126)
						{
							source.Read();
							node = source.Peek();
							trimWhitespace = true;
						}
						yield return Token.Static(buffer.ToString(), source.GetContext());
						yield return Token.StartExpression(escaped, trimWhitespace, raw, source.GetContext());
						trimWhitespace = false;
						buffer.Clear();
						inExpression = true;
					}
					else
					{
						buffer.Append((char)node);
						node = source.Read();
					}
				}
			}
			finally
			{
				((IDisposable)container/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
