using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class LiteralConverter : TokenConverter
	{
		private static readonly LiteralConverter Converter = new LiteralConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private LiteralConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			foreach (object item in sequence)
			{
				object obj2;
				object obj = (obj2 = item);
				if (!(obj is LiteralExpressionToken literalExpressionToken))
				{
					if (obj is WordExpressionToken wordExpressionToken && bool.TryParse(wordExpressionToken.Value, out var result))
					{
						obj2 = Expression.Convert(Expression.Constant(result), typeof(object));
					}
				}
				else
				{
					LiteralExpressionToken literalExpressionToken2 = literalExpressionToken;
					obj2 = Expression.Convert(Expression.Constant(literalExpressionToken2.Value), typeof(object));
					if (!literalExpressionToken2.IsDelimitedLiteral)
					{
						long result3;
						if (int.TryParse(literalExpressionToken2.Value, out var result2))
						{
							obj2 = Expression.Convert(Expression.Constant(result2), typeof(object));
						}
						else if (long.TryParse(literalExpressionToken2.Value, out result3))
						{
							obj2 = Expression.Convert(Expression.Constant(result3), typeof(object));
						}
					}
				}
				yield return obj2;
			}
		}
	}
}
