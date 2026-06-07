namespace CLanguage.Parser.yyParser
{
	internal class yyUnexpectedEof : yyException
	{
		public yyUnexpectedEof(string message)
			: base(null)
		{
		}

		public yyUnexpectedEof()
			: base(null)
		{
		}
	}
}
