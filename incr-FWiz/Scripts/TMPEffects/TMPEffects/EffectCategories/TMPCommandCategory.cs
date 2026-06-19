using TMPEffects.Databases;
using TMPEffects.TMPCommands;
using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal class TMPCommandCategory : TMPEffectCategory<ITMPCommand>
	{
		private ITMPEffectDatabase<ITMPCommand> database;

		private ITMPKeywordDatabase keywordDatabase;

		public TMPCommandCategory(char prefix, ITMPEffectDatabase<ITMPCommand> database, ITMPKeywordDatabase keywordDatabase)
			: base('\0')
		{
		}

		public override bool ContainsEffect(string name)
		{
			return false;
		}

		public override ITMPCommand GetEffect(string name)
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
