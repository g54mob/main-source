using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class DateAndTimeTaskbar : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Animator animator;

		private float cachedStateLength = 0.5f;

		private void Awake()
		{
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			cachedStateLength = DreamOSInternalTools.GetAnimatorClipLength(animator, "DateAndTimeTaskbar_In") + 0.1f;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			animator.enabled = true;
			animator.Play("In");
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			animator.enabled = true;
			animator.Play("Out");
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedStateLength + 0.1f);
			animator.enabled = false;
		}
	}
}
