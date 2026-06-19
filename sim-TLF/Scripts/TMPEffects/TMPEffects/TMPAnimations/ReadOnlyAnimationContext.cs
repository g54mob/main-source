using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;

namespace TMPEffects.TMPAnimations
{
	public class ReadOnlyAnimationContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
	{
		private IAnimationContext context;

		public IAnimatorContext AnimatorContext => context.AnimatorContext;

		public SegmentData SegmentData => context.SegmentData;

		public object CustomData => context.CustomData;

		public bool Finished(int index)
		{
			return context.Finished(index);
		}

		public bool Finished(CharData cData)
		{
			return context.Finished(cData);
		}

		public ReadOnlyAnimationContext(IAnimationContext context)
		{
			this.context = context;
		}

		public ReadOnlyAnimationContext(IAnimatorContext animatorContext, CharDataModifiers state, SegmentData segmentData, object customData)
			: this(new AnimationContext(animatorContext, state, segmentData, customData))
		{
		}

		public void FinishAnimation(CharData cData)
		{
			context.FinishAnimation(cData);
		}
	}
}
