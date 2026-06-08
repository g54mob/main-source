using DG.Tweening;
using UnityEngine;

namespace Dorfromantik
{
	public class SelectionToolPreview : MonoBehaviour
	{
		[SerializeField]
		private Transform selectionOutline;

		[SerializeField]
		private Transform iconBubble;

		[SerializeField]
		private VfxManager vfxManager;

		[SerializeField]
		private VfxConfiguration targetVfx;

		[SerializeField]
		private AudioClipOptions pressedSfx;

		[SerializeField]
		private float showAnimationDuration = 0.15f;

		[SerializeField]
		private float hideAnimationDuration = 0.15f;

		[SerializeField]
		private float pressWobbleScaleMultiplier = -0.15f;

		[SerializeField]
		private float pressWobbleDuration = 0.3f;

		[SerializeField]
		private int pressWobbleVibrato = 10;

		[SerializeField]
		private float pressWobbleElasticity = 0.8f;

		private Sequence pressedTween;

		public void Show(bool show, bool animate = true)
		{
			ShortcutExtensions.DOScale(base.transform, show ? 1 : 0, (!animate) ? 0f : (show ? showAnimationDuration : hideAnimationDuration));
		}

		public void ShowPressedFeedback()
		{
			Sequence sequence = pressedTween;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			pressedTween = DOTween.Sequence();
			TweenSettingsExtensions.Insert(pressedTween, 0f, ShortcutExtensions.DOPunchScale(selectionOutline, Vector3.one * pressWobbleScaleMultiplier, pressWobbleDuration, pressWobbleVibrato, pressWobbleElasticity));
			TweenSettingsExtensions.Insert(pressedTween, 0f, ShortcutExtensions.DOPunchScale(iconBubble, Vector3.one * pressWobbleScaleMultiplier, pressWobbleDuration, pressWobbleVibrato, pressWobbleElasticity));
			vfxManager.SpawnEffectAtPosition(targetVfx, base.transform.position);
			AudioManager.Instance.PlaySoundAtPosition(pressedSfx, base.transform.position);
		}
	}
}
