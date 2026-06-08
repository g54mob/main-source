namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class PartialToken : Token
	{
		public IReaderContext Context { get; }

		public override TokenType Type => TokenType.Partial;

		public override string Value => ">";

		public PartialToken(IReaderContext context = null)
		{
			Context = context;
		}
	}
}
