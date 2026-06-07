namespace Febucci.TextAnimatorCore
{
	public interface IEffectContent
	{
		IEffectPlayback Playback { get; }

		IEffectCurve StateCurve { get; }

		IEffectPhase CreatePhase();

		IEffectState CreateState();
	}
}
