using TMPEffects.TextProcessing;

namespace TMPEffects.Tags
{
	public interface ITMPTagValidator
	{
		bool ValidateOpenTag(ParsingUtility.TagInfo tagInfo, out TMPEffectTag data, out int endIndex);

		bool ValidateTag(ParsingUtility.TagInfo tagInfo);

		bool ValidateTag(TMPEffectTag tag);
	}
}
