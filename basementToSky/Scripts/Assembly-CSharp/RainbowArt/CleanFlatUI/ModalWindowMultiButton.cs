using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowMultiButton : MonoBehaviour
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
		private TextMeshProUGUI description;

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
			HideModalWindow();
			onCancel.Invoke();
		}

		private void OnFirstClick()
		{
			HideModalWindow();
			onFirst.Invoke();
		}

		private void OnSecondClick()
		{
			HideModalWindow();
			onSecond.Invoke();
		}

		private void OnThirdClick()
		{
			HideModalWindow();
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
	}
}
