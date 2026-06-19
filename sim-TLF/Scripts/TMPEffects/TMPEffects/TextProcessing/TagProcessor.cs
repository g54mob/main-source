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
			processedTags = new List<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>();
			ProcessedTags = new ReadOnlyCollection<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>(processedTags);
			this.validator = validator;
		}

		public bool Process(ParsingUtility.TagInfo tagInfo, int textIndex, int orderAtIndex)
		{
			if (tagInfo.type == ParsingUtility.TagType.Open)
			{
				return Process_Open(tagInfo, textIndex, orderAtIndex);
			}
			return Process_Close(tagInfo, textIndex);
		}

		public void Reset()
		{
			processedTags.Clear();
		}

		internal void AdjustIndices(KeyValuePair<TMPEffectTagIndices, TMPEffectTag> oldPair, KeyValuePair<TMPEffectTagIndices, TMPEffectTag> newPair)
		{
			int num = ProcessedTags.IndexOf(oldPair);
			if (num >= 0)
			{
				processedTags[num] = newPair;
			}
		}

		private bool Process_Open(ParsingUtility.TagInfo tagInfo, int textIndex, int orderAtIndex)
		{
			if (!validator.ValidateOpenTag(tagInfo, out var data, out var endIndex))
			{
				return false;
			}
			endIndex = ((endIndex == -1) ? (-1) : (endIndex - tagInfo.startIndex + textIndex));
			TMPEffectTagIndices key = new TMPEffectTagIndices(textIndex, endIndex, orderAtIndex);
			KeyValuePair<TMPEffectTagIndices, TMPEffectTag> item = new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(key, data);
			processedTags.Add(item);
			return true;
		}

		private bool Process_Close(ParsingUtility.TagInfo tagInfo, int textIndex)
		{
			if (tagInfo.name == "")
			{
				return CloseMostRecent(textIndex);
			}
			if (tagInfo.name == "all")
			{
				CloseAll(textIndex);
				return true;
			}
			if (!validator.ValidateTag(tagInfo))
			{
				return false;
			}
			for (int num = ProcessedTags.Count - 1; num >= 0; num--)
			{
				KeyValuePair<TMPEffectTagIndices, TMPEffectTag> keyValuePair = ProcessedTags[num];
				if (keyValuePair.Key.IsOpen && keyValuePair.Value.Name == tagInfo.name)
				{
					TMPEffectTagIndices key = new TMPEffectTagIndices(keyValuePair.Key.StartIndex, textIndex, keyValuePair.Key.OrderAtIndex);
					processedTags[num] = new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(key, keyValuePair.Value);
					return true;
				}
			}
			return false;
		}

		private bool CloseMostRecent(int textIndex)
		{
			for (int num = ProcessedTags.Count - 1; num >= 0; num--)
			{
				KeyValuePair<TMPEffectTagIndices, TMPEffectTag> keyValuePair = ProcessedTags[num];
				if (keyValuePair.Key.IsOpen)
				{
					TMPEffectTagIndices key = new TMPEffectTagIndices(keyValuePair.Key.StartIndex, textIndex, keyValuePair.Key.OrderAtIndex);
					processedTags[num] = new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(key, keyValuePair.Value);
					return true;
				}
			}
			return false;
		}

		private void CloseAll(int textIndex)
		{
			for (int num = ProcessedTags.Count - 1; num >= 0; num--)
			{
				KeyValuePair<TMPEffectTagIndices, TMPEffectTag> keyValuePair = ProcessedTags[num];
				if (keyValuePair.Key.IsOpen)
				{
					TMPEffectTagIndices key = new TMPEffectTagIndices(keyValuePair.Key.StartIndex, textIndex, keyValuePair.Key.OrderAtIndex);
					processedTags[num] = new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(key, keyValuePair.Value);
				}
			}
		}
	}
}
