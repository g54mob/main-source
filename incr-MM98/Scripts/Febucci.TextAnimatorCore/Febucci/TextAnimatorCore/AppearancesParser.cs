using System.Collections.Generic;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore
{
	internal class AppearancesParser : EffectsParser<IEffectPlayer>
	{
		private bool isBackwards;

		public AppearancesParser(bool isBackwards, char openingBracket, char closingBracket, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, endSymbol, tagsLookup, isCaseSensitive)
		{
			this.isBackwards = isBackwards;
		}

		public AppearancesParser(bool isBackwards, char openingBracket, char closingBracket, char middleSymbol, char endSymbol, Dictionary<string, IEffect> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, middleSymbol, endSymbol, tagsLookup, isCaseSensitive)
		{
			this.isBackwards = isBackwards;
		}

		protected override IEffectPlayer CreatePlayer(string tagId, IEffect preset, RegionParameters parameters)
		{
			if (isBackwards)
			{
				return TextAnimator.DisappearancePlayerFactory(tagId, preset, parameters);
			}
			return TextAnimator.AppearancePlayerFactory(tagId, preset, parameters);
		}
	}
}
