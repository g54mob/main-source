using TMPEffects.Databases;
using TMPEffects.TMPAnimations;
using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal class TMPAnimationCategory : TMPEffectCategory<ITMPAnimation>
	{
		private ITMPEffectDatabase<ITMPAnimation> database;

		private ITMPKeywordDatabase keywordDatabase;

		public TMPAnimationCategory(char prefix, ITMPEffectDatabase<ITMPAnimation> database, ITMPKeywordDatabase keywordDatabase)
			: base('\0')
		{
		}

		public override bool ContainsEffect(string name)
		{
			return false;
		}

		public override ITMPAnimation GetEffect(string name)
		{
			return null;
		}

		public override bool ValidateOpenTag(ParsingUtility.TagInfo tagInfo, out TMPEffectTag data, out int endIndex)
		{
			data = null;
			endIndex = default(int);
			return false;
		}

		public override bool ValidateTag(TMPEffectTag tag)
		{
			return false;
		}

		public override bool ValidateTag(ParsingUtility.TagInfo tagInfo)
		{
			return false;
		}
	}
}
