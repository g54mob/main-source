namespace Restory.Audio
{
	public interface IOverlayingAudioEffectsService
	{
		void TurnOnEffect(OverlayingAudioEffectsType effect);

		void TurnOffEffect(OverlayingAudioEffectsType effect);

		void TurnOnEffectAnimated(OverlayingAudioEffectsType effect, float duration);

		void TurnOffEffectAnimated(OverlayingAudioEffectsType effect, float duration);
	}
}
