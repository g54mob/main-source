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

		public readonly int firstAffectingAnimationIndex = -1;

		public TMPEffectTag Tag => tag;

		public TMPEffectTagIndices Indices => indices;

		public bool? overrides => TagData.overrides;

		public bool late => TagData.late;

		public bool Finished(int index)
		{
			return context.Finished(index);
		}

		public CachedAnimation(TMPEffectTag tag, TMPEffectTagIndices indices, ITMPAnimation animation, AnimationContext context, ExtendedAnimationTagData tagData)
		{
			this.tag = tag;
			this.indices = indices;
			this.animation = animation;
			this.context = context;
			roContext = new ReadOnlyAnimationContext(context);
			TagData = tagData;
		}
	}
}
