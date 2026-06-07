using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionMultiHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator[] animators;

		public void OnPointerEnter(PointerEventData eventData)
		{
		}
	}
}
