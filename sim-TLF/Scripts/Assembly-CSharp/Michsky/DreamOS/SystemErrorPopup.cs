using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class SystemErrorPopup : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private Animator animator;

		[Header("Settings")]
		[SerializeField]
		private bool showOnAwake;

		[SerializeField]
		[Range(0f, 15f)]
		private float autoHideIn;

		private float cachedStateLength = 0.5f;

		private bool isOn;

		private bool isLeftover;

		private void Awake()
		{
			cachedStateLength = DreamOSInternalTools.GetAnimatorClipLength(animator, "SystemErrorPopup_Show") + 0.1f;
			if (showOnAwake)
			{
				Show();
			}
			else if (!isOn)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			if (isLeftover)
			{
				isOn = false;
				isLeftover = false;
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			if (isOn)
			{
				isLeftover = true;
			}
		}

		public void Show()
		{
			if (!isOn)
			{
				isOn = true;
				base.gameObject.SetActive(value: true);
				animator.enabled = true;
				animator.Play("Show");
				StopCoroutine("DisableObject");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				if (autoHideIn > 0f)
				{
					StopCoroutine("AutoHideTimer");
					StartCoroutine("AutoHideTimer", autoHideIn);
				}
			}
		}

		public void Hide()
		{
			if (isOn && base.gameObject.activeInHierarchy)
			{
				isOn = false;
				animator.enabled = true;
				animator.Play("Hide");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				StopCoroutine("DisableObject");
				StartCoroutine("DisableObject");
			}
		}

		private IEnumerator AutoHideTimer()
		{
			yield return new WaitForSeconds(autoHideIn);
			Hide();
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedStateLength);
			animator.enabled = false;
		}

		private IEnumerator DisableObject()
		{
			yield return new WaitForSeconds(cachedStateLength);
			base.gameObject.SetActive(value: false);
		}
	}
}
