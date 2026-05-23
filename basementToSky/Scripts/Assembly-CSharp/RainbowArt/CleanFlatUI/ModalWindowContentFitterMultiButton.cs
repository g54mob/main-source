using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ModalWindowContentFitterMultiButton : MonoBehaviour
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
		private Button buttonFirst;

		[SerializeField]
		private Button buttonSecond;

		[SerializeField]
		private Button buttonThird;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform view;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private RectTransform buttonBar;

		[SerializeField]
		private ModalWindowEvent onFirst = new ModalWindowEvent();

		[SerializeField]
		private ModalWindowEvent onSecond = new ModalWindowEvent();

		[SerializeField]
		private ModalWindowEvent onThird = new ModalWindowEvent();

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

		public ModalWindowEvent OnFirst
		{
			get
			{
				return onFirst;
			}
			set
			{
				onFirst = value;
			}
		}

		public ModalWindowEvent OnSecond
		{
			get
			{
				return onSecond;
			}
			set
			{
				onSecond = value;
			}
		}

		public ModalWindowEvent OnThird
		{
			get
			{
				return onThird;
			}
			set
			{
				onThird = value;
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
			if (buttonFirst != null)
			{
				buttonFirst.onClick.RemoveAllListeners();
				buttonFirst.onClick.AddListener(OnFirstClick);
			}
			if (buttonSecond != null)
			{
				buttonSecond.onClick.RemoveAllListeners();
				buttonSecond.onClick.AddListener(OnSecondClick);
			}
			if (buttonThird != null)
			{
				buttonThird.onClick.RemoveAllListeners();
				buttonThird.onClick.AddListener(OnThirdClick);
			}
		}

		private void OnCloseClick()
		{
			OnCancelClick();
		}

		private void OnCancelClick()
		{
			onCancel.Invoke();
		}

		private void OnFirstClick()
		{
			onFirst.Invoke();
		}

		private void OnSecondClick()
		{
			onSecond.Invoke();
		}

		private void OnThirdClick()
		{
			onThird.Invoke();
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
