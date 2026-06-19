using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.TMPCommands;
using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal class CommandCacher : ITagCacher<CachedCommand>
	{
		private ITMPEffectDatabase<ITMPCommand> database;

		private TMPWriter writer;

		private IList<CharData> charData;

		private ITMPKeywordDatabase keywordDatabase;

		public CommandCacher(IList<CharData> charData, TMPWriter writer, ITMPEffectDatabase<ITMPCommand> database, ITMPKeywordDatabase keywordDatabase)
		{
			this.charData = charData;
			this.writer = writer;
			this.database = database;
			this.keywordDatabase = keywordDatabase;
		}

		public CachedCommand CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			ITMPCommand effect = database.GetEffect(tag.Name);
			int endIndex = indices.EndIndex;
			switch (effect.TagType)
			{
			case TagType.Index:
				endIndex = indices.StartIndex + 1;
				break;
			case TagType.Block:
			case TagType.Either:
				if (indices.IsOpen)
				{
					endIndex = charData.Count;
				}
				break;
			default:
				throw new ArgumentException("TagType");
			}
			TMPEffectTagIndices indices2 = new TMPEffectTagIndices(indices.StartIndex, endIndex, indices.OrderAtIndex);
			CommandContext commandContext = new CommandContext(writer, indices2);
			object customData = (commandContext.CustomData = effect.GetNewCustomData());
			effect.SetParameters(customData, tag.Parameters, keywordDatabase);
			return new CachedCommand(tag, indices2, commandContext, effect);
		}
	}
}
