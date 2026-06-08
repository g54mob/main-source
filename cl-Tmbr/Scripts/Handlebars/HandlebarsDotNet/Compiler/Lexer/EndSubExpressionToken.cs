namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class EndSubExpressionToken : ExpressionScopeToken
	{
		public IReaderContext Context { get; }

		public override string Value { get; } = ")";

		public override TokenType Type => TokenType.EndSubExpression;

		public EndSubExpressionToken(IReaderContext context)
		{
			Context = context;
		}
	}
}
