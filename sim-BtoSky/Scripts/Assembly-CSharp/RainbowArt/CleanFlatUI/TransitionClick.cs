using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator animator;

		public void OnPointerClick(PointerEventData eventData)
		{
			animator.Play("Transition", 0, 0f);
		}
	}
}
