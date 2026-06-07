using CLanguage.Syntax;

namespace CLanguage.Parser
{
	public class LexedDocument
	{
		public readonly Document Document;

		public readonly Token[] Tokens;

		public LexedDocument(Document document, Report report, bool comments = false)
		{
		}
	}
}
