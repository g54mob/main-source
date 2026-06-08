using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class ExpressionScopeConverter : TokenConverter
	{
		private static readonly ExpressionScopeConverter Converter = new ExpressionScopeConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private ExpressionScopeConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (!(current is StartExpressionToken startExpressionToken))
				{
					yield return current;
					continue;
				}
				object next = GetNext(enumerator);
				if (!(next is Expression))
				{
					throw new HandlebarsCompilerException($"Token '{next}' could not be converted to an expression");
				}
				if (!(GetNext(enumerator) is EndExpressionToken endExpressionToken))
				{
					throw new HandlebarsCompilerException("Handlebars statement was not reduced to a single expression");
				}
				if (endExpressionToken.IsEscaped != startExpressionToken.IsEscaped)
				{
					throw new HandlebarsCompilerException("Starting and ending handlebars do not match", endExpressionToken.Context);
				}
				yield return HandlebarsExpression.Statement((Expression)next, startExpressionToken.IsEscaped, startExpressionToken.TrimPreceedingWhitespace, endExpressionToken.TrimTrailingWhitespace);
			}
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}
