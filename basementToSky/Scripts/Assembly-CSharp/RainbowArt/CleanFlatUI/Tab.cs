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
			isPointerEntered = false;
			UpdateStatusContent();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isPointerEntered = true;
			UpdateStatusContent();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerEntered = false;
			UpdateStatusContent();
		}

		public void UpdateStatusContent()
		{
			if (!toggle.isOn)
			{
				if (isPointerEntered)
				{
					PlayAnimation(animator, "Hover");
				}
				else
				{
					PlayAnimation(animator, "Off Init");
				}
			}
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				animator.Play(animStr, 0, 0f);
			}
		}

		private void ResetAnimation(Animator animator)
		{
			if (animator != null)
			{
				animator.enabled = false;
			}
		}
	}
}
