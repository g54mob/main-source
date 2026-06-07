namespace Febucci.TextAnimatorCore
{
	public interface IEffectPlayback : IParameterUpdater
	{
		void Initialize();

		float GetTotalDuration();

		void CalculateIntensity01(float time, out float intensity01, out bool hasFinishedEffect);
	}
}
