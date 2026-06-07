using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ModalWindowContentFitter : MonoBehaviour
	{
		[Serializable]
		public class ModalWindowEvent : UnityEvent
		{
		}

		[SerializeField]
		private Image iconTitle;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private Button buttonConfirm;

		[SerializeField]
		private Button buttonCancel;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform view;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private RectTransform buttonBar;

		[SerializeField]
		private ModalWindowEvent onConfirm = new ModalWindowEvent();

		[SerializeField]
		private ModalWindowEvent onCancel = new ModalWindowEvent();

		private IEnumerator diableCoroutine;

		private float disableTime = 0.5f;

		private float spacing = 20f;

		private float elapsedTime;

		private bool bDelayedUpdate;

		public string DescriptionValue
		{
			get
			{
				if (description != null)
				{
					return description.text;
				}
				return "";
			}
			set
			{
				if (description != null)
				{
					description.text = value;
				}
			}
		}

		public string TitleValue
		{
			get
			{
				if (title != null)
				{
					return title.text;
				}
				return "";
			}
			set
			{
				if (title != null)
				{
					title.text = value;
				}
			}
		}

		public Sprite IconValue
		{
			get
			{
				if (iconTitle != null)
				{
					return iconTitle.sprite;
				}
				return null;
			}
			set
			{
				if (iconTitle != null)
				{
					if (value != null)
					{
						iconTitle.gameObject.SetActive(value: true);
						iconTitle.sprite = value;
					}
					else
					{
						iconTitle.gameObject.SetActive(value: false);
						iconTitle.sprite = null;
					}
				}
			}
		}

		public ModalWindowEvent OnConfirm
		{
			get
			{
				return onConfirm;
			}
			set
			{
				onConfirm = value;
			}
		}

		public ModalWindowEvent OnCancel
		{
			get
			{
				return onCancel;
			}
			set
			{
				onCancel = value;
			}
		}

		public void ShowModalWindow()
		{
			base.gameObject.SetActive(value: true);
			InitButtons();
			InitAnimation();
			UpdateHeight();
			PlayAnimation(bShow: true);
		}

		public void HideModalWindow()
		{
			PlayAnimation(bShow: false);
			if (animator != null)
			{
				if (diableCoroutine != null)
				{
					StopCoroutine(diableCoroutine);
					diableCoroutine = null;
				}
				diableCoroutine = DisableTransition();
				StartCoroutine(diableCoroutine);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private IEnumerator DisableTransition()
		{
			yield return new WaitForSeconds(disableTime);
			base.gameObject.SetActive(value: false);
		}

		private void InitButtons()
		{
			if (buttonClose != null)
			{
				buttonClose.onClick.RemoveAllListeners();
				buttonClose.onClick.AddListener(OnCloseClick);
			}
			if (buttonConfirm != null)
			{
				buttonConfirm.onClick.RemoveAllListeners();
				buttonConfirm.onClick.AddListener(OnConfirmClick);
			}
			if (buttonCancel != null)
			{
				buttonCancel.onClick.RemoveAllListeners();
				buttonCancel.onClick.AddListener(OnCancelClick);
			}
		}

		private void OnCloseClick()
		{
			OnCancelClick();
		}

		private void OnCancelClick()
		{
			HideModalWindow();
			onCancel.Invoke();
		}

		private void OnConfirmClick()
		{
			HideModalWindow();
			onConfirm.Invoke();
		}

		private void InitAnimation()
		{
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
		}

		private void PlayAnimation(bool bShow)
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				if (bShow)
				{
					animator.Play("In", 0, 0f);
				}
				else
				{
					animator.Play("Out", 0, 0f);
				}
			}
		}

		private void Update()
		{
			if (bDelayedUpdate)
			{
				elapsedTime += Time.deltaTime;
				if ((double)elapsedTime >= 0.1)
				{
					bDelayedUpdate = false;
					UpdateHeight();
				}
			}
		}

		private void UpdateHeight()
		{
			if (description != null)
			{
				float num = 0f - description.GetComponent<RectTransform>().anchoredPosition3D.y + description.preferredHeight + spacing;
				if (buttonBar != null)
				{
					float height = buttonBar.rect.height;
					Vector3 anchoredPosition3D = buttonBar.anchoredPosition3D;
					anchoredPosition3D.y = 0f - num;
					buttonBar.anchoredPosition3D = anchoredPosition3D;
					num += height;
				}
				view.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
				float y = view.pivot.y;
				if (y != 0.5f)
				{
					float height2 = view.rect.height;
					Vector3 anchoredPosition3D2 = view.anchoredPosition3D;
					anchoredPosition3D2.y = height2 * (y - 0.5f);
					view.anchoredPosition3D = anchoredPosition3D2;
				}
			}
		}
	}
}
