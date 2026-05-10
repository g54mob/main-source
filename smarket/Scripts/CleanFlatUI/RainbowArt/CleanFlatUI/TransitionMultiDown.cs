using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionMultiDown : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator[] animators;

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
