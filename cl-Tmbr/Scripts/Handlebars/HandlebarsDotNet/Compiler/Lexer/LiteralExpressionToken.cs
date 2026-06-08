namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class LiteralExpressionToken : ExpressionToken
	{
		public IReaderContext Context { get; }

		public bool IsDelimitedLiteral => Delimiter != null;

		public string Delimiter { get; }

		public override TokenType Type => TokenType.Literal;

		public override string Value { get; }

		public LiteralExpressionToken(string value, string delimiter = null, IReaderContext context = null)
		{
			Context = context;
			Value = value;
			Delimiter = delimiter;
		}
	}
}
