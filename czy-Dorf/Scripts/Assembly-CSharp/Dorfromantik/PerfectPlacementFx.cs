using DG.Tweening;
using UnityEngine;

namespace Dorfromantik
{
	public class PerfectPlacementFx : MonoBehaviour
	{
		[SerializeField]
		private float destroyTime = 2f;

		[SerializeField]
		private Transform hexagonHighlight;

		[SerializeField]
		private float hexagonHighlightScaleUpDuration = 0.5f;

		[SerializeField]
		private AnimationCurve hexagonHighlightScaleUpCurve;

		[SerializeField]
		private float hexagonHighlightYScale = 0.5f;

		[SerializeField]
		private float hexagonHighlightScaleDownDuration = 0.5f;

		[SerializeField]
		private AnimationCurve hexagonHighlightScaleDownCurve;

		[SerializeField]
		private ParticleSystem particleEffect;

		[SerializeField]
		private AudioClipOptions perfectPlacementSfx;

		private Sequence effectSequence;

		public void Play(float delay, bool playSound)
		{
			Object.Destroy(base.gameObject, destroyTime + delay);
			effectSequence = DOTween.Sequence();
			TweenSettingsExtensions.AppendInterval(effectSequence, delay);
			TweenSettingsExtensions.Append(effectSequence, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScaleY(hexagonHighlight, hexagonHighlightYScale, hexagonHighlightScaleUpDuration), hexagonHighlightScaleUpCurve));
			TweenSettingsExtensions.Append(effectSequence, TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScaleY(hexagonHighlight, 0f, hexagonHighlightScaleDownDuration), hexagonHighlightScaleDownCurve));
			TweenSettingsExtensions.InsertCallback(effectSequence, delay, particleEffect.Play);
			if (playSound)
			{
				TweenSettingsExtensions.InsertCallback(effectSequence, delay, delegate
				{
					AudioManager.Instance.PlaySoundAtPosition(perfectPlacementSfx, base.transform.position);
				});
			}
			TweenExtensions.Play(effectSequence);
		}

		private void _003CPlay_003Eb__10_0()
		{
			AudioManager.Instance.PlaySoundAtPosition(perfectPlacementSfx, base.transform.position);
		}
	}
}
