using TMPEffects.Components.Animator;

namespace TMPEffects.TMPAnimations
{
	public interface IAnimationData : IAnimationFinished
	{
		IAnimatorContext AnimatorContext { get; }

		SegmentData SegmentData { get; }

		object CustomData { get; }
	}
}
