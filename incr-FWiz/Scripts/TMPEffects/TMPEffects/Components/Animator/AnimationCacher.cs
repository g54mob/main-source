using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Modifiers;
using TMPEffects.TMPAnimations;
using TMPEffects.Tags;

namespace TMPEffects.Components.Animator
{
	internal class AnimationCacher : ITagCacher<CachedAnimation>
	{
		private readonly ITMPEffectDatabase<ITMPAnimation> database;

		private readonly IList<CharData> charData;

		private readonly IAnimatorContext context;

		private readonly Predicate<char> animates;

		private readonly CharDataModifiers modifiers;

		private readonly ReadOnlyAnimatorContext roContext;

		private readonly ITMPKeywordDatabase keywordDatabase;

		public AnimationCacher(ITMPEffectDatabase<ITMPAnimation> database, CharDataModifiers modifiers, ReadOnlyAnimatorContext context, IList<CharData> charData, Predicate<char> animates, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public CachedAnimation CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return null;
		}
	}
}
