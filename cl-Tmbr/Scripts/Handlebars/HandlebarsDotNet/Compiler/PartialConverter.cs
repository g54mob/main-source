using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class PartialConverter : TokenConverter
	{
		private static readonly PartialConverter Converter = new PartialConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private PartialConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (!(current is PartialToken))
				{
					yield return current;
					continue;
				}
				List<Expression> list = AccumulateArguments(enumerator);
				if (list.Count == 0)
				{
					throw new HandlebarsCompilerException("A partial must have a name");
				}
				Expression expression = list[0];
				if (expression is PathExpression pathExpression)
				{
					expression = Expression.Constant(pathExpression.Path);
				}
				switch (list.Count)
				{
				case 1:
					yield return HandlebarsExpression.Partial(expression);
					break;
				case 2:
					yield return HandlebarsExpression.Partial(expression, list[1]);
					break;
				default:
					throw new HandlebarsCompilerException("A partial can only accept 0 or 1 arguments");
				}
				yield return enumerator.Current;
			}
		}

		private static List<Expression> AccumulateArguments(IEnumerator<object> enumerator)
		{
			object next = GetNext(enumerator);
			List<Expression> list = new List<Expression>();
			while (!(next is EndExpressionToken))
			{
				if (!(next is Expression))
				{
					throw new HandlebarsCompilerException($"Token '{next}' could not be converted to an expression");
				}
				list.Add((Expression)next);
				next = GetNext(enumerator);
			}
			return list;
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}
