using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;

namespace TMPEffects.TMPAnimations
{
	public class ReadOnlyAnimationContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
	{
		private IAnimationContext context;

		public IAnimatorContext AnimatorContext => null;

		public SegmentData SegmentData => default(SegmentData);

		public object CustomData => null;

		public bool Finished(int index)
		{
			return false;
		}

		public bool Finished(CharData cData)
		{
			return false;
		}

		public ReadOnlyAnimationContext(IAnimationContext context)
		{
		}

		public ReadOnlyAnimationContext(IAnimatorContext animatorContext, CharDataModifiers state, SegmentData segmentData, object customData)
		{
		}

		public void FinishAnimation(CharData cData)
		{
		}
	}
}
