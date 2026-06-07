using System.Text;

namespace Febucci.UI.Core.Parsing
{
	public abstract class TagParserBase
	{
		public char startSymbol;

		public char endSymbol;

		public char closingSymbol;

		public TagParserBase()
		{
		}

		public TagParserBase(char startSymbol, char closingSymbol, char endSymbol)
		{
			this.startSymbol = startSymbol;
			this.closingSymbol = closingSymbol;
			this.endSymbol = endSymbol;
		}

		public abstract bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder);

		public void Initialize()
		{
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}
	}
}
