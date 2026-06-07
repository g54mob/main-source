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
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].Play("Transition", 0, 0f);
			}
		}
	}
}
