using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionDown : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator animator;

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
