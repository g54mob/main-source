using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using JSAM;
using UnityEngine;
using UnityEngine.Rendering;

namespace MainMenu
{
	public class MenuAnimator : MonoBehaviour
	{
		[SerializeField]
		private Volume volume;

		[SerializeField]
		private float _glitchForwardDuration = 0.3f;

		[SerializeField]
		private Ease _glitchEase;

		public async void GlitchTransition()
		{
			TweenerCore<float, float, FloatOptions> t = DOTween.To(() => volume.weight, delegate(float x)
			{
				volume.weight = x;
			}, 1f, _glitchForwardDuration).SetEase(_glitchEase).Pause();
			TweenerCore<float, float, FloatOptions> backwardTween = DOTween.To(() => volume.weight, delegate(float x)
			{
				volume.weight = x;
			}, 0f, _glitchForwardDuration).SetEase(_glitchEase).Pause();
			AudioManager.PlaySound(MainMenuLibrarySounds.Glitch);
			AudioManager.StopSoundIfPlaying(MainMenuLibrarySounds.Electromagnetic_Neon_Light_Loop_Mono_Elektrousi_03, base.transform);
			await t.Play().AsyncWaitForCompletion();
			await backwardTween.Play().AsyncWaitForCompletion();
		}
	}
}
