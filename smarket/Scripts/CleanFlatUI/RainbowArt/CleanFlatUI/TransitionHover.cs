using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator animator;

		public void OnPointerEnter(PointerEventData eventData)
		{
		}
	}
}
