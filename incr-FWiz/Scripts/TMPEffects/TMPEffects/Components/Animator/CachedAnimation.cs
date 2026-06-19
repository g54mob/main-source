using TMPEffects.TMPAnimations;
using TMPEffects.Tags;

namespace TMPEffects.Components.Animator
{
	internal class CachedAnimation : ITagWrapper
	{
		public readonly ExtendedAnimationTagData TagData;

		private TMPEffectTag tag;

		private TMPEffectTagIndices indices;

		public readonly ITMPAnimation animation;

		public readonly AnimationContext context;

		public readonly ReadOnlyAnimationContext roContext;

		public readonly int firstAffectingAnimationIndex;

		public TMPEffectTag Tag => null;

		public TMPEffectTagIndices Indices => default(TMPEffectTagIndices);

		public bool? overrides => null;

		public bool late => false;

		public bool Finished(int index)
		{
			return false;
		}

		public CachedAnimation(TMPEffectTag tag, TMPEffectTagIndices indices, ITMPAnimation animation, AnimationContext context, ExtendedAnimationTagData tagData)
		{
		}
	}
}
