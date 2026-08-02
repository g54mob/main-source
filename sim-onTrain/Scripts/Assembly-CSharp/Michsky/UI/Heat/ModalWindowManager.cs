using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
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

		public Sprite icon;

		public string titleText = "Title";

		[TextArea(0, 4)]
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

		public UnityEvent onConfirm = new UnityEvent();

		public UnityEvent onCancel = new UnityEvent();

		public UnityEvent onOpen = new UnityEvent();

		public UnityEvent onClose = new UnityEvent();

		private string animIn = "In";

		private string animOut = "Out";

		private string animSpeedKey = "AnimSpeed";

		private bool canProcessEventSystem;

		private float openStateLength;

		private float closeStateLength;

		private GameObject latestEventSystemObject;

		private void Awake()
		{
			InitModalWindow();
			InitEventSystem();
			UpdateUI();
		}

		private void Start()
		{
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
		}

		private void Update()
		{
			if (inputType != InputType.Free && isOn && canProcessEventSystem && ControllerManager.instance.gamepadEnabled)
			{
				CheckForEventButtons();
			}
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
			if (useLocalization && !useCustomContent)
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
			openStateLength = HeatUIInternalTools.GetAnimatorClipLength(mwAnimator, "ModalWindow_In");
			closeStateLength = HeatUIInternalTools.GetAnimatorClipLength(mwAnimator, "ModalWindow_Out");
		}

		private void InitEventSystem()
		{
			if (ControllerManager.instance == null)
			{
				canProcessEventSystem = false;
			}
			else if (cancelButton == null && confirmButton == null)
			{
				canProcessEventSystem = false;
			}
			else
			{
				canProcessEventSystem = true;
			}
		}

		private void CheckForEventButtons()
		{
			if (cancelButton != null && EventSystem.current.currentSelectedGameObject != cancelButton.gameObject && EventSystem.current.currentSelectedGameObject != confirmButton.gameObject)
			{
				ControllerManager.instance.SelectUIObject(cancelButton.gameObject);
			}
			else if (confirmButton != null && EventSystem.current.currentSelectedGameObject != cancelButton.gameObject && EventSystem.current.currentSelectedGameObject != confirmButton.gameObject)
			{
				ControllerManager.instance.SelectUIObject(confirmButton.gameObject);
			}
		}

		public void UpdateUI()
		{
			if (!useCustomContent)
			{
				if (windowIcon != null)
				{
					windowIcon.sprite = icon;
				}
				if (windowTitle != null && (!useLocalization || string.IsNullOrEmpty(titleKey)))
				{
					windowTitle.text = titleText;
				}
				if (windowDescription != null && (!useLocalization || string.IsNullOrEmpty(titleKey)))
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
				if (EventSystem.current.currentSelectedGameObject != null)
				{
					latestEventSystemObject = EventSystem.current.currentSelectedGameObject;
				}
				base.gameObject.SetActive(value: true);
				isOn = true;
				StopCoroutine("DisableObject");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
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
				if (base.gameObject.activeSelf)
				{
					StopCoroutine("DisableObject");
					StopCoroutine("DisableAnimator");
					StartCoroutine("DisableObject");
				}
				isOn = false;
				mwAnimator.enabled = true;
				mwAnimator.SetFloat(animSpeedKey, animationSpeed);
				mwAnimator.Play(animOut);
				onClose.Invoke();
				if (ControllerManager.instance != null && latestEventSystemObject != null && latestEventSystemObject.activeInHierarchy)
				{
					ControllerManager.instance.SelectUIObject(latestEventSystemObject);
				}
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
