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
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].Play("Transition", 0, 0f);
			}
		}
	}
}
