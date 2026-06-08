namespace HandlebarsDotNet.Compiler.Lexer
{
	internal class CommentToken : Token
	{
		private readonly string _comment;

		public override TokenType Type => TokenType.Comment;

		public override string Value => _comment;

		public CommentToken(string comment)
		{
			_comment = comment.Trim('-', ' ');
		}
	}
}
