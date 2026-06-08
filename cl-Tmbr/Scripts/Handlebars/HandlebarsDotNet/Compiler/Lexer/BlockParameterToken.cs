namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class BlockParameterToken : Token
	{
		public override TokenType Type => TokenType.BlockParams;

		public override string Value { get; }

		public IReaderContext Context { get; }

		public BlockParameterToken(string value, IReaderContext context = null)
		{
			Value = value;
			Context = context;
		}
	}
}
