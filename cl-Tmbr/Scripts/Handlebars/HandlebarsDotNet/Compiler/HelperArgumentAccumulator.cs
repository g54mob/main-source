using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class HelperArgumentAccumulator : TokenConverter
	{
		private static readonly HelperArgumentAccumulator Accumulator = new HelperArgumentAccumulator();

		public static IEnumerable<object> Accumulate(IEnumerable<object> sequence)
		{
			return Accumulator.ConvertTokens(sequence).ToList();
		}

		private HelperArgumentAccumulator()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (!(current is HelperExpression helperExpression))
				{
					if (current is PathExpression pathExpression)
					{
						List<Expression> list = AccumulateArguments(enumerator);
						if (list.Count > 0)
						{
							yield return HandlebarsExpression.Helper(pathExpression.Path, isBlock: false, list, ((EndExpressionToken)enumerator.Current)?.IsRaw ?? false);
							yield return enumerator.Current;
						}
						else
						{
							yield return pathExpression;
							yield return enumerator.Current;
						}
					}
					else
					{
						yield return current;
					}
				}
				else
				{
					List<Expression> arguments = AccumulateArguments(enumerator);
					yield return HandlebarsExpression.Helper(helperExpression.HelperName, helperExpression.IsBlock, arguments, helperExpression.IsRaw);
					yield return enumerator.Current;
				}
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
