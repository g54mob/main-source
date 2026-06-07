namespace Febucci.UI.Core.Parsing
{
	public class TMPTagParser : TagParserBase
	{
		private readonly bool richTagsEnabled;

		private static readonly string[] lookup;

		public override bool shouldPasteTag => false;

		public TMPTagParser(bool richTagsEnabled, char openingBracket, char closingBracket, char closingTagSymbol)
		{
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, int realTextIndex, int internalOrder)
		{
			return false;
		}
	}
}
