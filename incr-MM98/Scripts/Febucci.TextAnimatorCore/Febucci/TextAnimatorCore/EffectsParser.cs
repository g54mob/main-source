using System.Collections.Generic;
using Febucci.Parsing.Regions;

namespace Febucci.TextAnimatorCore
{
	internal abstract class EffectsParser<TPlayerType> : RegionParser<IEffect, TPlayerType> where TPlayerType : IEffectPlayer
	{
		public EffectsParser(char openingBracket, char closingBracket, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, endSymbol, tagsLookup, isCaseSensitive)
		{
		}

		public EffectsParser(char openingBracket, char closingBracket, char middleSymbol, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, middleSymbol, endSymbol, tagsLookup, isCaseSensitive)
		{
		}
	}
}
