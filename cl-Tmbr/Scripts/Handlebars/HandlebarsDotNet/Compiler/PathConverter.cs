using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
	internal class PathConverter : TokenConverter
	{
		private static readonly PathConverter Converter = new PathConverter();

		public static IEnumerable<object> Convert(IEnumerable<object> sequence)
		{
			return Converter.ConvertTokens(sequence).ToList();
		}

		private PathConverter()
		{
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			foreach (object item in sequence)
			{
				if (item is WordExpressionToken wordExpressionToken)
				{
					yield return HandlebarsExpression.Path(wordExpressionToken.Value);
				}
				else
				{
					yield return item;
				}
			}
		}
	}
}
