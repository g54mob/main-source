using System.Text;

namespace Febucci.Parsing.Core
{
	public abstract class TagParserBase
	{
		public char OpeningBracket;

		public char EndSymbol;

		public char ClosingBracket;

		public TagParserBase()
		{
		}

		public TagParserBase(char openingBracket, char endSymbol, char closingBracket)
		{
			OpeningBracket = openingBracket;
			ClosingBracket = closingBracket;
			EndSymbol = endSymbol;
		}

		public abstract bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder);

		public void Initialize()
		{
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		public void FinishParsing()
		{
			OnFinishParsing();
		}

		protected virtual void OnFinishParsing()
		{
		}
	}
}
