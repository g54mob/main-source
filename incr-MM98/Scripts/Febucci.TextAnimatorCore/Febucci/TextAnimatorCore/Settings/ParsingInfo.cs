using System;

namespace Febucci.TextAnimatorCore.Settings
{
	[Serializable]
	public struct ParsingInfo
	{
		public char openingBracket;

		public char closingBracket;

		public char middleSymbol;

		public ParsingInfo(char openingBracket, char closingBracket, char middleSymbol)
		{
			this.openingBracket = openingBracket;
			this.closingBracket = closingBracket;
			this.middleSymbol = middleSymbol;
		}

		public ParsingInfo(char openingBracket, char closingBracket)
		{
			this.openingBracket = openingBracket;
			this.closingBracket = closingBracket;
			middleSymbol = '\0';
		}
	}
}
