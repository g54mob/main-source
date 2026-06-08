namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class AssignmentToken : Token
	{
		public IReaderContext Context { get; }

		public override TokenType Type => TokenType.Assignment;

		public override string Value => "=";

		public AssignmentToken(IReaderContext context)
		{
			Context = context;
		}
	}
}
