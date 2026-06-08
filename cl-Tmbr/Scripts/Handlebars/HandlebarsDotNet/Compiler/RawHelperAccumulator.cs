using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HandlebarsDotNet.Compiler.Lexer;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	internal class RawHelperAccumulator : TokenConverter
	{
		private static readonly RawHelperAccumulator Accumulator = new RawHelperAccumulator();

		public static IEnumerable<object> Accumulate(IEnumerable<object> sequence)
		{
			return Accumulator.ConvertTokens(sequence).ToList();
		}

		private RawHelperAccumulator()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is StartExpressionToken startExpressionTokenItem)
				{
					yield return current;
					if (!startExpressionTokenItem.IsRaw)
					{
						continue;
					}
					current = GetNext(enumerator);
					if (!(current is HelperExpression helperExpression))
					{
						throw new HandlebarsCompilerException("Expected HelperExpression, got " + current);
					}
					yield return current;
					foreach (object item in CollectParameters(enumerator, helperExpression.HelperName))
					{
						yield return item;
					}
					foreach (object item2 in CollectBody(enumerator, helperExpression.HelperName))
					{
						yield return item2;
					}
				}
				else
				{
					yield return current;
				}
			}
		}

		private IEnumerable<object> CollectParameters(IEnumerator<object> enumerator, string rawHelperName)
		{
			int unclosedExpressions = 1;
			while (enumerator.MoveNext())
			{
				object item = enumerator.Current;
				if (item is EndExpressionToken)
				{
					unclosedExpressions--;
					yield return item;
					if (unclosedExpressions == 0)
					{
						yield break;
					}
				}
				if (item is StartExpressionToken)
				{
					unclosedExpressions++;
					yield return item;
				}
				else
				{
					yield return item;
				}
			}
			throw new HandlebarsCompilerException("Reached end of template before raw block helper expression '" + rawHelperName + "' tag was closed");
		}

		private IEnumerable<object> CollectBody(IEnumerator<object> enumerator, string rawHelperName)
		{
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> container = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = container.Value;
				object precedingItem = null;
				while (enumerator.MoveNext())
				{
					object item = enumerator.Current;
					if (item is StartExpressionToken startExpressionToken)
					{
						item = GetNext(enumerator);
						if (IsClosingTag(startExpressionToken, item, rawHelperName))
						{
							yield return Token.Static(value.ToString());
							yield return startExpressionToken;
							yield return item;
							yield break;
						}
						value.Append(Stringify(startExpressionToken, precedingItem));
						value.Append(Stringify(item, startExpressionToken));
					}
					else
					{
						value.Append(Stringify(item, precedingItem));
					}
					precedingItem = item;
				}
				throw new HandlebarsCompilerException("Reached end of template before raw block helper expression '" + rawHelperName + "' was closed");
			}
			finally
			{
				((IDisposable)container/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private bool IsClosingTag(StartExpressionToken startExpressionToken, object item, string helperName)
		{
			if (startExpressionToken.IsRaw && item is WordExpressionToken wordExpressionToken)
			{
				return wordExpressionToken.Value == "/" + helperName;
			}
			return false;
		}

		private static string Stringify(object item, object precedingItem)
		{
			if (item is Token token)
			{
				return PrependWhitespaceWhereNeeded(StringifyToken(token), token, precedingItem);
			}
			if (item is HelperExpression helperExpression)
			{
				return helperExpression.HelperName;
			}
			return item.ToString();
		}

		private static string PrependWhitespaceWhereNeeded(string value, Token currToken, object precedingItem)
		{
			if (precedingItem == null)
			{
				return value;
			}
			if (currToken.Type != TokenType.Word && currToken.Type != TokenType.Literal)
			{
				return value;
			}
			if (precedingItem is HelperExpression)
			{
				return " " + value;
			}
			if (precedingItem is Token token && (token.Type == TokenType.Word || token.Type == TokenType.Literal))
			{
				return " " + value;
			}
			return value;
		}

		private static string StringifyToken(Token token)
		{
			if (!(token is LiteralExpressionToken { IsDelimitedLiteral: not false } literalExpressionToken))
			{
				return token.Value;
			}
			return literalExpressionToken.Delimiter + literalExpressionToken.Value + literalExpressionToken.Delimiter;
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}
