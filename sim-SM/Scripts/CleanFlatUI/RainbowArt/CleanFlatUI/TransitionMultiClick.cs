using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TransitionMultiClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator[] animators;

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
