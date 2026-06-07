namespace Assets.Scripts.Craft.Parts.Modifiers.Animations
{
	public interface IPartModifierAnimationScript
	{
		float AnimationSpeed { get; set; }

		float AnimationState { get; set; }

		float AnimationStateTarget { get; set; }

		bool IsActive { get; set; }

		float TotalTime { get; }

		void Animate(float targetState, float animationSpeed = 1f);

		void Initialize();

		void Stop();
	}
}
