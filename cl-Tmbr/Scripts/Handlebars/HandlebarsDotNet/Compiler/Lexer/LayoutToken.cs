namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class LayoutToken : Token
	{
		private readonly string _layout;

		public override TokenType Type => TokenType.Layout;

		public override string Value => _layout;

		public LayoutToken(string layout)
		{
			_layout = layout.Trim('-', ' ');
		}
	}
}
