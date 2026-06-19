using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal class TMPEventCategory : TMPEffectCategory
	{
		public TMPEventCategory(char prefix)
			: base('\0')
		{
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
