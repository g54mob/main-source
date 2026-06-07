using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionTwo : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Animator animator;

		public void OnPointerEnter(PointerEventData eventData)
		{
			animator.Play("Transition", 0, 0f);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			animator.Play("Idle", 0, 0f);
		}
	}
}
