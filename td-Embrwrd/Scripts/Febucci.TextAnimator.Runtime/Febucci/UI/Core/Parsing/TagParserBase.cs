namespace Febucci.UI.Core.Parsing
{
	public abstract class TagParserBase
	{
		public char startSymbol;

		public char endSymbol;

		public char closingSymbol;

		public virtual bool shouldPasteTag => false;

		public TagParserBase()
		{
		}

		public TagParserBase(char startSymbol, char closingSymbol, char endSymbol)
		{
		}

		public abstract bool TryProcessingTag(string textInsideBrackets, int tagLength, int realTextIndex, int internalOrder);

		public void Initialize()
		{
		}

		protected virtual void OnInitialize()
		{
		}
	}
}
