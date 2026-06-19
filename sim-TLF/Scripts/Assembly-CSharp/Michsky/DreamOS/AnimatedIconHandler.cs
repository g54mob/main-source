using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	public class AnimatedIconHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		public enum PlayType
		{
			Click = 0,
			Hover = 1,
			Button = 2,
			Other = 3
		}

		[Header("Resources")]
		[SerializeField]
		private Animator iconAnimator;

		[SerializeField]
		private ButtonManager targetButton;

		[Header("Settings")]
		[SerializeField]
		private PlayType playType;

		[SerializeField]
		private string defaultState = "HamburgerMenu_In";

		[SerializeField]
		[Range(0f, 1f)]
		private float crossFade;

		private bool isIn;

		private float disableAfter = 1f;

		private void Awake()
		{
			if (iconAnimator == null)
			{
				iconAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (playType == PlayType.Button && targetButton != null)
			{
				targetButton.onClick.AddListener(Animate);
			}
			disableAfter = DreamOSInternalTools.GetAnimatorClipLength(iconAnimator, defaultState) + 0.1f;
		}

		private void OnEnable()
		{
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void PlayStart()
		{
			isIn = false;
			iconAnimator.enabled = true;
			iconAnimator.CrossFade("Start", crossFade);
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void PlayIn()
		{
			isIn = true;
			if (base.gameObject.activeInHierarchy)
			{
				iconAnimator.enabled = true;
				iconAnimator.CrossFade("In", crossFade);
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
		}

		public void PlayOut()
		{
			isIn = false;
			if (base.gameObject.activeInHierarchy)
			{
				iconAnimator.enabled = true;
				iconAnimator.CrossFade("Out", crossFade);
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
		}

		public void Animate()
		{
			if (isIn)
			{
				PlayOut();
			}
			else
			{
				PlayIn();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (playType == PlayType.Click)
			{
				Animate();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (playType == PlayType.Hover)
			{
				PlayIn();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (playType == PlayType.Hover)
			{
				PlayOut();
			}
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(disableAfter);
			iconAnimator.enabled = false;
		}
	}
}
