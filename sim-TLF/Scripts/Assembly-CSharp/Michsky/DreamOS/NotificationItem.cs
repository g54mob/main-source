using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class NotificationItem : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private Animator animator;

		public Transform buttonParent;

		public Image iconObject;

		public TextMeshProUGUI titleObject;

		public TextMeshProUGUI descriptionObject;

		[Header("Settings")]
		[SerializeField]
		private string stateID = "StandardNotification_In";

		private NotificationItemParent nip;

		private float cachedAnimatorLength = 0.5f;

		private bool closeInProgress;

		private bool waitingToBeEnabled;

		private void Awake()
		{
			if (animator != null)
			{
				cachedAnimatorLength = DreamOSInternalTools.GetAnimatorClipLength(animator, stateID) + 0.01f;
			}
		}

		private void OnEnable()
		{
			if (waitingToBeEnabled)
			{
				waitingToBeEnabled = false;
				Open();
			}
		}

		private void OnDisable()
		{
			if (closeInProgress)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void Open()
		{
			if (nip == null)
			{
				nip = base.gameObject.GetComponentInParent<NotificationItemParent>();
			}
			if (!base.gameObject.activeInHierarchy)
			{
				waitingToBeEnabled = true;
				return;
			}
			StopCoroutine("DisableAnimator");
			StopCoroutine("DestroyObject");
			StartCoroutine("DisableAnimator");
			closeInProgress = false;
			animator.enabled = true;
			animator.Play("In");
			nip.UpdateState();
		}

		public void OpenPopup(float duration)
		{
			StopCoroutine("DisableAnimator");
			StopCoroutine("WaitForPopupDuration");
			StartCoroutine("DisableAnimator");
			StartCoroutine("WaitForPopupDuration", duration);
			animator.enabled = true;
			animator.Play("In");
		}

		public void Close()
		{
			StopCoroutine("DisableAnimator");
			StopCoroutine("DestroyObject");
			StartCoroutine("DestroyObject");
			closeInProgress = true;
			animator.enabled = true;
			animator.Play("Out");
		}

		private IEnumerator WaitForPopupDuration(float time)
		{
			yield return new WaitForSeconds(time);
			Close();
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			animator.enabled = false;
		}

		private IEnumerator DestroyObject()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			base.transform.SetParent(null);
			if (nip != null)
			{
				nip.UpdateState();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
