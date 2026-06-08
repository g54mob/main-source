using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class ModalWindowManager : MonoBehaviour
	{
		public Image windowIcon;

		public TextMeshProUGUI windowTitle;

		public TextMeshProUGUI windowDescription;

		public Button confirmButton;

		public Button cancelButton;

		public Animator mwAnimator;

		public Sprite icon;

		public string titleText = "Title";

		public string descriptionText = "Description here";

		public UnityEvent onConfirm;

		public UnityEvent onCancel;

		public bool sharpAnimations;

		public bool useCustomValues;

		public bool isOn;

		private void Start()
		{
			if (mwAnimator == null)
			{
				mwAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (confirmButton != null)
			{
				confirmButton.onClick.AddListener(onConfirm.Invoke);
			}
			if (cancelButton != null)
			{
				cancelButton.onClick.AddListener(onCancel.Invoke);
			}
			if (!useCustomValues)
			{
				UpdateUI();
			}
		}

		public void UpdateUI()
		{
			try
			{
				windowIcon.sprite = icon;
				windowTitle.text = titleText;
				windowDescription.text = descriptionText;
			}
			catch
			{
				Debug.LogWarning("Modal Window - Cannot update the content due to missing variables.", this);
			}
		}

		public void OpenWindow()
		{
			if (!isOn)
			{
				if (!sharpAnimations)
				{
					mwAnimator.CrossFade("Fade-in", 0.1f);
				}
				else
				{
					mwAnimator.Play("Fade-in");
				}
				isOn = true;
			}
		}

		public void CloseWindow()
		{
			if (isOn)
			{
				if (!sharpAnimations)
				{
					mwAnimator.CrossFade("Fade-out", 0.1f);
				}
				else
				{
					mwAnimator.Play("Fade-out");
				}
				isOn = false;
			}
		}

		public void AnimateWindow()
		{
			if (!isOn)
			{
				if (!sharpAnimations)
				{
					mwAnimator.CrossFade("Fade-in", 0.1f);
				}
				else
				{
					mwAnimator.Play("Fade-in");
				}
				isOn = true;
			}
			else
			{
				if (!sharpAnimations)
				{
					mwAnimator.CrossFade("Fade-out", 0.1f);
				}
				else
				{
					mwAnimator.Play("Fade-out");
				}
				isOn = false;
			}
		}
	}
}
