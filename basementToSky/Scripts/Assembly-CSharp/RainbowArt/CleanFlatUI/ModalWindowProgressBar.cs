using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowProgressBar : MonoBehaviour
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
		private TextMeshProUGUI description;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ProgressBar progressBar;

		[SerializeField]
		private ModalWindowEvent onCancel = new ModalWindowEvent();

		[SerializeField]
		private ModalWindowEvent onFinish = new ModalWindowEvent();

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

		public ModalWindowEvent OnFinish
		{
			get
			{
				return onFinish;
			}
			set
			{
				onFinish = value;
			}
		}

		public void ShowModalWindow()
		{
			base.gameObject.SetActive(value: true);
			InitButtons();
			InitAnimation();
			PlayAnimation(bShow: true);
		}

		public void SetProgress(float progress)
		{
			progressBar.CurrentValue = progress;
		}

		public void FinishProgress()
		{
			HideModalWindow();
			onFinish.Invoke();
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
		}

		private void OnCloseClick()
		{
			onCancel.Invoke();
			HideModalWindow();
		}

		private void OnProgressFinish()
		{
			HideModalWindow();
			onFinish.Invoke();
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
