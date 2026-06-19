using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal class TMPEventCategory : TMPEffectCategory
	{
		public TMPEventCategory(char prefix)
			: base(prefix)
		{
		}

		public override bool ValidateOpenTag(ParsingUtility.TagInfo tagInfo, out TMPEffectTag data, out int endIndex)
		{
			data = null;
			endIndex = tagInfo.startIndex;
			if (tagInfo.type != ParsingUtility.TagType.Open)
			{
				return false;
			}
			if (tagInfo.prefix != base.Prefix)
			{
				return false;
			}
			TMPEffectTag tMPEffectTag = new TMPEffectTag(tagInfo.name, tagInfo.prefix, ParsingUtility.GetTagParametersDict(tagInfo.parameterString));
			data = tMPEffectTag;
			return true;
		}

		public override bool ValidateTag(TMPEffectTag tag)
		{
			if (tag.Prefix != base.Prefix)
			{
				return false;
			}
			return true;
		}

		public override bool ValidateTag(ParsingUtility.TagInfo tagInfo)
		{
			if (tagInfo.type != ParsingUtility.TagType.Open)
			{
				return false;
			}
			if (tagInfo.prefix != base.Prefix)
			{
				return false;
			}
			return true;
		}
	}
}
