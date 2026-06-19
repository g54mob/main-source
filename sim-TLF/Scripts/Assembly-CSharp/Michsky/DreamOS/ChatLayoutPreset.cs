using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class ChatLayoutPreset : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		public Transform messageParent;

		public Image individualImage;

		public TextMeshProUGUI nameText;

		[HideInInspector]
		public MessagingManager manager;

		[HideInInspector]
		public string personName;

		[HideInInspector]
		public Sprite personPicture;

		private float cachedAnimatorLength = 1f;

		private void Awake()
		{
			cachedAnimatorLength = DreamOSInternalTools.GetAnimatorClipLength(animator, "ChatLayout_In") + 0.1f;
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			individualImage.sprite = personPicture;
			nameText.text = personName;
			animator.enabled = true;
			animator.Play("In");
			StopCoroutine("DisableAnimator");
			StopCoroutine("DisableObject");
			StartCoroutine("DisableAnimator");
		}

		public void Hide()
		{
			animator.enabled = true;
			animator.Play("Out");
			StopCoroutine("DisableAnimator");
			StopCoroutine("DisableObject");
			StartCoroutine("DisableObject");
		}

		private IEnumerator DisableObject()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			animator.enabled = false;
		}
	}
}
