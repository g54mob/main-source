namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class EndExpressionToken : ExpressionScopeToken
	{
		public bool IsEscaped { get; }

		public bool TrimTrailingWhitespace { get; }

		public bool IsRaw { get; }

		public IReaderContext Context { get; }

		public override string Value
		{
			get
			{
				if (!IsRaw)
				{
					if (!IsEscaped)
					{
						return "}}}";
					}
					return "}}";
				}
				return "}}}}";
			}
		}

		public override TokenType Type => TokenType.EndExpression;

		public EndExpressionToken(bool isEscaped, bool trimWhitespace, bool isRaw, IReaderContext context)
		{
			IsEscaped = isEscaped;
			TrimTrailingWhitespace = trimWhitespace;
			IsRaw = isRaw;
			Context = context;
		}
	}
}
