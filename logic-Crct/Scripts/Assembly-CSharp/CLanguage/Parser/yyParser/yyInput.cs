namespace CLanguage.Parser.yyParser
{
	internal interface yyInput
	{
		bool advance();

		int token();

		object value();
	}
}
