using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class SubExpressionConverter : TokenConverter
	{
		private static readonly SubExpressionConverter Converter = new SubExpressionConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private SubExpressionConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is StartSubExpressionToken)
				{
					yield return BuildSubExpression(enumerator);
				}
				else
				{
					yield return current;
				}
			}
		}

		private static SubExpressionExpression BuildSubExpression(IEnumerator<object> enumerator)
		{
			PathExpression obj = (GetNext(enumerator) as PathExpression) ?? throw new HandlebarsCompilerException("Found a sub-expression that does not contain a path expression");
			return HandlebarsExpression.SubExpression(HandlebarsExpression.Helper(arguments: AccumulateSubExpression(enumerator), helperName: obj.Path, isBlock: false));
		}

		private static IEnumerable<Expression> AccumulateSubExpression(IEnumerator<object> enumerator)
		{
			object obj = GetNext(enumerator);
			List<Expression> list = new List<Expression>();
			while (!(obj is EndSubExpressionToken))
			{
				if (obj is StartSubExpressionToken)
				{
					obj = BuildSubExpression(enumerator);
				}
				else if (!(obj is Expression))
				{
					throw new HandlebarsCompilerException($"Token '{obj}' could not be converted to an expression");
				}
				list.Add((Expression)obj);
				obj = GetNext(enumerator);
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
