using System.Collections.Generic;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore
{
	internal class BehaviorsParser : EffectsParser<IEffectPlayer>
	{
		public BehaviorsParser(char openingBracket, char closingBracket, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, endSymbol, tagsLookup, isCaseSensitive)
		{
		}

		public BehaviorsParser(char openingBracket, char closingBracket, char middleSymbol, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, middleSymbol, endSymbol, tagsLookup, isCaseSensitive)
		{
		}

		protected override IEffectPlayer CreatePlayer(string tagId, IEffect preset, RegionParameters parameters)
		{
			return TextAnimator.BehaviorPlayerFactory(tagId, preset, parameters);
		}
	}
}
