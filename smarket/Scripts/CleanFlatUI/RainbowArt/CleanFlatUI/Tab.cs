using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class Tab : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Animator animator;

		private bool isPointerEntered;

		private void OnEnable()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void UpdateStatusContent()
		{
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
		}

		private void ResetAnimation(Animator animator)
		{
		}
	}
}
