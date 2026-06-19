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
		}

		public CachedCommand CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return null;
		}
	}
}
