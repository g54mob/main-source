using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class ModalWindowManager : MonoBehaviour
	{
		public enum StartBehaviour
		{
			Enable = 0,
			Disable = 1
		}

		public enum CloseBehaviour
		{
			Disable = 0,
			Destroy = 1
		}

		public enum InputType
		{
			Focused = 0,
			Free = 1
		}

		public Image windowIcon;

		public TextMeshProUGUI windowTitle;

		public TextMeshProUGUI windowDescription;

		public ButtonManager confirmButton;

		public ButtonManager cancelButton;

		[SerializeField]
		private Animator mwAnimator;

		[SerializeField]
		private UIBlur backgroundBlur;

		public Sprite icon;

		public string titleText = "Title";

		[TextArea]
		public string descriptionText = "Description here";

		public string titleKey;

		public string descriptionKey;

		public bool useCustomContent;

		public bool isOn;

		public bool closeOnCancel = true;

		public bool closeOnConfirm = true;

		public bool showCancelButton = true;

		public bool showConfirmButton = true;

		public bool useLocalization = true;

		[Range(0.5f, 2f)]
		public float animationSpeed = 1f;

		public StartBehaviour startBehaviour = StartBehaviour.Disable;

		public CloseBehaviour closeBehaviour;

		public InputType inputType;

		public UnityEvent onConfirm;

		public UnityEvent onCancel;

		public UnityEvent onOpen;

		public UnityEvent onClose;

		private string animIn = "In";

		private string animOut = "Out";

		private string animSpeedKey = "AnimSpeed";

		private float openStateLength;

		private float closeStateLength;

		private void Awake()
		{
			InitModalWindow();
			UpdateUI();
		}

		private void InitModalWindow()
		{
			if (mwAnimator == null)
			{
				mwAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (closeOnCancel)
			{
				onCancel.AddListener(CloseWindow);
			}
			if (closeOnConfirm)
			{
				onConfirm.AddListener(CloseWindow);
			}
			if (confirmButton != null)
			{
				confirmButton.onClick.AddListener(onConfirm.Invoke);
			}
			if (cancelButton != null)
			{
				cancelButton.onClick.AddListener(onCancel.Invoke);
			}
			if (useLocalization)
			{
				LocalizedObject component = GetComponent<LocalizedObject>();
				if (component == null || !component.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else
				{
					if (windowTitle != null && !string.IsNullOrEmpty(titleKey))
					{
						LocalizedObject component2 = windowTitle.gameObject.GetComponent<LocalizedObject>();
						if (component2 != null)
						{
							component2.tableIndex = component.tableIndex;
							component2.localizationKey = titleKey;
							component2.UpdateItem();
						}
					}
					if (windowDescription != null && !string.IsNullOrEmpty(descriptionKey))
					{
						LocalizedObject component3 = windowDescription.gameObject.GetComponent<LocalizedObject>();
						if (component3 != null)
						{
							component3.tableIndex = component.tableIndex;
							component3.localizationKey = descriptionKey;
							component3.UpdateItem();
						}
					}
				}
			}
			if (startBehaviour == StartBehaviour.Disable)
			{
				isOn = false;
				base.gameObject.SetActive(value: false);
			}
			else if (startBehaviour == StartBehaviour.Enable)
			{
				isOn = false;
				OpenWindow();
			}
			openStateLength = DreamOSInternalTools.GetAnimatorClipLength(mwAnimator, "ModalWindow_In");
			closeStateLength = DreamOSInternalTools.GetAnimatorClipLength(mwAnimator, "ModalWindow_Out");
		}

		public void UpdateUI()
		{
			if (!useCustomContent)
			{
				if (windowIcon != null)
				{
					windowIcon.sprite = icon;
				}
				if (windowTitle != null && !useLocalization)
				{
					windowTitle.text = titleText;
				}
				if (windowDescription != null && !useLocalization)
				{
					windowDescription.text = descriptionText;
				}
			}
			if (showCancelButton && cancelButton != null)
			{
				cancelButton.gameObject.SetActive(value: true);
			}
			else if (cancelButton != null)
			{
				cancelButton.gameObject.SetActive(value: false);
			}
			if (showConfirmButton && confirmButton != null)
			{
				confirmButton.gameObject.SetActive(value: true);
			}
			else if (confirmButton != null)
			{
				confirmButton.gameObject.SetActive(value: false);
			}
		}

		public void OpenWindow()
		{
			if (!isOn)
			{
				base.gameObject.SetActive(value: true);
				isOn = true;
				StopCoroutine("DisableObject");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				if (backgroundBlur != null)
				{
					backgroundBlur.BlurInAnim();
				}
				mwAnimator.enabled = true;
				mwAnimator.SetFloat(animSpeedKey, animationSpeed);
				mwAnimator.Play(animIn);
				onOpen.Invoke();
			}
		}

		public void CloseWindow()
		{
			if (isOn)
			{
				isOn = false;
				StopCoroutine("DisableObject");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableObject");
				if (backgroundBlur != null)
				{
					backgroundBlur.BlurOutAnim();
				}
				mwAnimator.enabled = true;
				mwAnimator.SetFloat(animSpeedKey, animationSpeed);
				mwAnimator.Play(animOut);
				onClose.Invoke();
			}
		}

		public void AnimateWindow()
		{
			if (!isOn)
			{
				OpenWindow();
			}
			else
			{
				CloseWindow();
			}
		}

		private IEnumerator DisableObject()
		{
			yield return new WaitForSecondsRealtime(closeStateLength);
			if (closeBehaviour == CloseBehaviour.Disable)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (closeBehaviour == CloseBehaviour.Destroy)
			{
				Object.Destroy(base.gameObject);
			}
			mwAnimator.enabled = false;
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSecondsRealtime(openStateLength + 0.1f);
			mwAnimator.enabled = false;
		}
	}
}
