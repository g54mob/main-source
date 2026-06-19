using TMPEffects.Modifiers;

namespace TMPEffects.Components.Animator
{
	public interface IAnimatorDataProvider
	{
		TMPAnimator Animator { get; }

		CharDataModifiers Modifiers { get; }

		bool ScaleAnimations { get; }

		bool ScaleUniformly { get; }

		bool UseScaledTime { get; }
	}
}
