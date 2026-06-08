using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class HashParameterConverter : TokenConverter
	{
		private static readonly HashParameterConverter Converter = new HashParameterConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private HashParameterConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object item = enumerator.Current;
				while (item is WordExpressionToken wordExpressionToken)
				{
					item = GetNext(enumerator);
					if (item is AssignmentToken)
					{
						yield return HandlebarsExpression.HashParameterAssignmentExpression(wordExpressionToken.Value);
						item = GetNext(enumerator);
					}
					else
					{
						yield return wordExpressionToken;
					}
				}
				yield return item;
			}
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}
