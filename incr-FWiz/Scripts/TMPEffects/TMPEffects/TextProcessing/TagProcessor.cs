using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPEffects.Tags;

namespace TMPEffects.TextProcessing
{
	public sealed class TagProcessor
	{
		public readonly ReadOnlyCollection<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>> ProcessedTags;

		public const string ALL_KEYWORD = "all";

		public const string MOST_RECENT_KEYWORD = "";

		private ITMPTagValidator validator;

		private List<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>> processedTags;

		public TagProcessor(ITMPTagValidator validator)
		{
		}

		public bool Process(ParsingUtility.TagInfo tagInfo, int textIndex, int orderAtIndex)
		{
			return false;
		}

		public void Reset()
		{
		}

		internal void AdjustIndices(KeyValuePair<TMPEffectTagIndices, TMPEffectTag> oldPair, KeyValuePair<TMPEffectTagIndices, TMPEffectTag> newPair)
		{
		}

		private bool Process_Open(ParsingUtility.TagInfo tagInfo, int textIndex, int orderAtIndex)
		{
			return false;
		}

		private bool Process_Close(ParsingUtility.TagInfo tagInfo, int textIndex)
		{
			return false;
		}

		private bool CloseMostRecent(int textIndex)
		{
			return false;
		}

		private void CloseAll(int textIndex)
		{
		}
	}
}
