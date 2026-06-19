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
			this.context = context;
			this.database = database;
			this.charData = charData;
			this.animates = animates;
			this.modifiers = modifiers;
			roContext = new ReadOnlyAnimatorContext(context);
			this.keywordDatabase = keywordDatabase;
		}

		public CachedAnimation CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			ITMPAnimation effect = database.GetEffect(tag.Name);
			TMPEffectTagIndices indices2 = new TMPEffectTagIndices(indices.StartIndex, indices.IsOpen ? charData.Count : indices.EndIndex, indices.OrderAtIndex);
			AnimationContext animationContext = new AnimationContext(segmentData: new SegmentData(indices2, charData, animates), animatorContext: roContext, modifiers: modifiers, customData: null);
			object customData = (animationContext.CustomData = effect.GetNewCustomData());
			effect.SetParameters(customData, tag.Parameters, keywordDatabase);
			return new CachedAnimation(tag, indices2, effect, animationContext, new ExtendedAnimationTagData(tag, keywordDatabase));
		}
	}
}
