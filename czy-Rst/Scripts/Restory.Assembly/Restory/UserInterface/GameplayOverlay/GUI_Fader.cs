using DG.Tweening;
using UnityEngine;

namespace Restory.UserInterface.GameplayOverlay
{
	public class GUI_Fader : MonoBehaviour
	{
		[SerializeField]
		private float fadeDuration = 0.5f;

		[SerializeField]
		private CanvasGroup canvasGroup;

		private Tween tween;

		private void OnDestroy()
		{
			tween?.Kill();
		}

		public void DoFade(float endValue)
		{
			bool flag = endValue > 0f;
			tween = canvasGroup.DOFade(endValue, fadeDuration).SetUpdate(isIndependentUpdate: true);
			canvasGroup.interactable = flag;
			canvasGroup.blocksRaycasts = flag;
		}
	}
}
