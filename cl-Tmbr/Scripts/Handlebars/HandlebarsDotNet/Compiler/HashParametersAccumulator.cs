using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class HashParametersAccumulator : TokenConverter
	{
		private static readonly HashParametersAccumulator Accumulator = new HashParametersAccumulator();

		public static IEnumerable<object> Accumulate(IEnumerable<object> sequence)
		{
			return Accumulator.ConvertTokens(sequence).ToList();
		}

		private HashParametersAccumulator()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is HashParameterAssignmentExpression)
				{
					bool moveNext;
					Dictionary<string, Expression> dictionary = AccumulateParameters(enumerator, out moveNext);
					if (dictionary.Any())
					{
						yield return HandlebarsExpression.HashParametersExpression(dictionary);
					}
					if (!moveNext)
					{
						break;
					}
					current = enumerator.Current;
				}
				yield return (current is Expression expression) ? Visit(expression) : current;
			}
		}

		private Dictionary<string, Expression> AccumulateParameters(IEnumerator<object> enumerator, out bool moveNext)
		{
			moveNext = true;
			Dictionary<string, Expression> dictionary = new Dictionary<string, Expression>();
			object current = enumerator.Current;
			while (current is HashParameterAssignmentExpression hashParameterAssignmentExpression)
			{
				current = GetNext(enumerator);
				if (current is Expression expression)
				{
					dictionary.Add(hashParameterAssignmentExpression.Name, Visit(expression));
					moveNext = enumerator.MoveNext();
					if (!moveNext)
					{
						break;
					}
					current = enumerator.Current;
					continue;
				}
				throw new HandlebarsCompilerException($"Unexpected token '{current}', expected an expression");
			}
			return dictionary;
		}

		private Expression Visit(Expression expression)
		{
			if (expression is HelperExpression helperExpression)
			{
				Expression[] array = helperExpression.Arguments.ToArray();
				Expression[] array2 = ConvertTokens(array).Cast<Expression>().ToArray();
				if (!array2.SequenceEqual(array))
				{
					return HandlebarsExpression.Helper(helperExpression.HelperName, helperExpression.IsBlock, array2, helperExpression.IsRaw);
				}
			}
			if (expression is SubExpressionExpression subExpressionExpression)
			{
				Expression expression2 = Visit(subExpressionExpression.Expression);
				if (expression2 != subExpressionExpression.Expression)
				{
					return HandlebarsExpression.SubExpression(expression2);
				}
			}
			return expression;
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}
