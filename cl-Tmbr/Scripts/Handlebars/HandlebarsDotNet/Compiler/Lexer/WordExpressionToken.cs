namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class WordExpressionToken : ExpressionToken
	{
		public override TokenType Type => TokenType.Word;

		public override string Value { get; }

		public IReaderContext Context { get; }

		public WordExpressionToken(string word, IReaderContext context = null)
		{
			Value = word;
			Context = context;
		}
	}
}
