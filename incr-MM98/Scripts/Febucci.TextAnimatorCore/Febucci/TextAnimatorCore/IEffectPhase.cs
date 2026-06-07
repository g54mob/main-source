namespace Febucci.TextAnimatorCore
{
	public interface IEffectPhase : IParameterUpdater
	{
		float MaxSpeed { get; }

		float GetSpeedFor(int charIndex, int wordIndex);

		float GetOffsetFor(int charIndex, int wordIndex);
	}
}
