using DG.Tweening;
using UnityEngine;

namespace UI
{
	public class TrashCanUI : MonoBehaviour
	{
		[SerializeField]
		private Transform arrow;

		private float yPosition;

		private Animator animator;

		private void Start()
		{
			yPosition = arrow.position.y;
			animator = GetComponent<Animator>();
			Hide();
		}

		private void LoopAnimation()
		{
			arrow.DOMoveY(yPosition + 0.5f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}

		public void Show()
		{
			arrow.gameObject.SetActive(value: true);
			LoopAnimation();
		}

		public void Hide()
		{
			arrow.DORewind();
			arrow.gameObject.SetActive(value: false);
		}

		public void AnimateTrashCan()
		{
			animator.SetTrigger("Triggered");
		}

		public void ResetTrigger()
		{
			animator.ResetTrigger("Triggered");
		}
	}
}
