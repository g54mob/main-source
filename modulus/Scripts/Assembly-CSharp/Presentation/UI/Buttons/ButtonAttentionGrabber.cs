using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Buttons
{
	public class ButtonAttentionGrabber : MonoBehaviour
	{
		[SerializeField]
		private Image border1;

		[SerializeField]
		private Image border2;

		private void Awake()
		{
			border1.gameObject.SetActive(value: false);
			border2.gameObject.SetActive(value: false);
		}

		public void GrabAttention()
		{
			border1.DOFade(0f, 0.5f).SetLoops(2, LoopType.Restart);
			border1.transform.DOScale(1.3f, 0.5f).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Restart);
			border2.DOFade(0f, 0.5f).SetLoops(2, LoopType.Restart);
			border2.transform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Restart)
				.OnComplete(EndGrabAttention);
			border1.gameObject.SetActive(value: true);
			border2.gameObject.SetActive(value: true);
		}

		private void EndGrabAttention()
		{
			border1.gameObject.SetActive(value: false);
			border2.gameObject.SetActive(value: false);
			border1.transform.localScale = Vector3.one;
			border2.transform.localScale = Vector3.one;
			border1.color = Color.white;
			border2.color = Color.white;
		}
	}
}
