using TMPEffects.Databases;
using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal abstract class TMPEffectCategory<TEffect> : TMPEffectCategory, ITMPEffectDatabase<TEffect>, ITMPEffectDatabase
	{
		public TMPEffectCategory(char prefix)
			: base('\0')
		{
		}

		public abstract bool ContainsEffect(string name);

		public abstract TEffect GetEffect(string name);
	}
	internal abstract class TMPEffectCategory : ITMPTagValidator, ITMPPrefixSupplier
	{
		protected readonly char prefix;

		public char Prefix => '\0';

		public TMPEffectCategory(char prefix)
		{
		}

		public abstract bool ValidateOpenTag(ParsingUtility.TagInfo tagInfo, out TMPEffectTag data, out int endIndex);

		public abstract bool ValidateTag(TMPEffectTag tag);

		public abstract bool ValidateTag(ParsingUtility.TagInfo tagInfo);
	}
}
