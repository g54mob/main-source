using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class BoxButtonManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		public enum BackgroundFilter
		{
			Aqua = 0,
			Dawn = 1,
			Dusk = 2,
			Emerald = 3,
			Kylo = 4,
			Memory = 5,
			Mice = 6,
			Pinky = 7,
			Retro = 8,
			Rock = 9,
			Sunset = 10,
			Violet = 11,
			Warm = 12,
			Random = 13
		}

		public Sprite buttonBackground;

		public Sprite buttonIcon;

		public string buttonTitle = "Button";

		public string titleLocalizationKey;

		public string buttonDescription = "Description";

		public string descriptionLocalizationKey;

		public BackgroundFilter backgroundFilter;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private CanvasGroup buttonCG;

		public Image backgroundObj;

		public Image iconObj;

		public TextMeshProUGUI titleObj;

		public TextMeshProUGUI descriptionObj;

		public Image filterObj;

		public List<Sprite> filters = new List<Sprite>();

		public bool isInteractable = true;

		public bool enableBackground = true;

		public bool enableIcon;

		public bool enableTitle = true;

		public bool enableDescription = true;

		public bool enableFilter = true;

		public bool useCustomContent;

		public bool checkForDoubleClick = true;

		public bool useLocalization = true;

		public bool bypassUpdateOnEnable;

		public bool useUINavigation;

		public Navigation.Mode navigationMode = Navigation.Mode.Automatic;

		public GameObject selectOnUp;

		public GameObject selectOnDown;

		public GameObject selectOnLeft;

		public GameObject selectOnRight;

		public bool wrapAround;

		public bool useSounds = true;

		[Range(0.1f, 1f)]
		public float doubleClickPeriod = 0.25f;

		[Range(0.1f, 1f)]
		public float disabledOpacity = 0.5f;

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onDoubleClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		public UnityEvent onLeave = new UnityEvent();

		public UnityEvent onSelect = new UnityEvent();

		public UnityEvent onDeselect = new UnityEvent();

		private bool isInitialized;

		private float cachedStateLength = 0.5f;

		private bool waitingForDoubleClickInput;

		private Button targetButton;

		private void Awake()
		{
			cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(animator, "BoxButton_Highlighted") + 0.1f;
		}

		private void OnEnable()
		{
			if (!isInitialized)
			{
				Initialize();
			}
			if (!bypassUpdateOnEnable)
			{
				UpdateUI();
			}
			if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				TriggerAnimation("Highlighted");
			}
			if (Application.isPlaying && useUINavigation)
			{
				AddUINavigation();
			}
			else if (Application.isPlaying && !useUINavigation && targetButton == null)
			{
				if (base.gameObject.GetComponent<Button>() == null)
				{
					targetButton = base.gameObject.AddComponent<Button>();
				}
				else
				{
					targetButton = GetComponent<Button>();
				}
				targetButton.transition = Selectable.Transition.None;
			}
		}

		private void Initialize()
		{
			if (ControllerManager.instance != null)
			{
				ControllerManager.instance.boxButtons.Add(this);
			}
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}
			if (buttonCG == null)
			{
				buttonCG = base.gameObject.AddComponent<CanvasGroup>();
			}
			if (GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			TriggerAnimation("Start");
			if (useLocalization && !useCustomContent)
			{
				LocalizedObject mainLoc = GetComponent<LocalizedObject>();
				if (mainLoc == null || !mainLoc.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (mainLoc != null && !string.IsNullOrEmpty(titleLocalizationKey))
				{
					buttonTitle = mainLoc.GetKeyOutput(titleLocalizationKey);
					buttonDescription = mainLoc.GetKeyOutput(descriptionLocalizationKey);
					mainLoc.localizationKey = titleLocalizationKey;
					mainLoc.onLanguageChanged.AddListener(delegate
					{
						buttonTitle = mainLoc.GetKeyOutput(titleLocalizationKey);
						buttonDescription = mainLoc.GetKeyOutput(descriptionLocalizationKey);
						UpdateUI();
					});
				}
			}
			isInitialized = true;
		}

		public void UpdateUI()
		{
			if (enableIcon && iconObj != null)
			{
				iconObj.gameObject.SetActive(value: true);
				iconObj.sprite = buttonIcon;
			}
			else if (iconObj != null)
			{
				iconObj.gameObject.SetActive(value: false);
			}
			if (enableTitle && titleObj != null)
			{
				titleObj.gameObject.SetActive(value: true);
				titleObj.text = buttonTitle;
			}
			else if (titleObj != null)
			{
				titleObj.gameObject.SetActive(value: false);
			}
			if (enableDescription && descriptionObj != null)
			{
				descriptionObj.gameObject.SetActive(value: true);
				descriptionObj.text = buttonDescription;
			}
			else if (descriptionObj != null)
			{
				descriptionObj.gameObject.SetActive(value: false);
				if (Application.isPlaying && enableTitle && titleObj != null)
				{
					titleObj.transform.parent.gameObject.name = titleObj.gameObject.name + "_D";
				}
			}
			if (!enableFilter && filterObj != null)
			{
				filterObj.gameObject.SetActive(value: false);
			}
			else if (enableFilter && filterObj != null && filters.Count >= (int)(backgroundFilter + 1))
			{
				filterObj.gameObject.SetActive(value: true);
				if (backgroundFilter == BackgroundFilter.Random)
				{
					filterObj.sprite = filters[Random.Range(0, filters.Count - 2)];
				}
				else
				{
					filterObj.sprite = filters[(int)backgroundFilter];
				}
			}
			if (enableBackground && backgroundObj != null)
			{
				backgroundObj.sprite = buttonBackground;
			}
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				TriggerAnimation("Start");
			}
		}

		public void SetText(string text)
		{
			buttonTitle = text;
			UpdateUI();
		}

		public void SetDescription(string text)
		{
			buttonDescription = text;
			UpdateUI();
		}

		public void SetIcon(Sprite icon)
		{
			buttonIcon = icon;
			UpdateUI();
		}

		public void SetBackground(Sprite bg)
		{
			buttonBackground = bg;
			UpdateUI();
		}

		public void SetInteractable(bool value)
		{
			isInteractable = value;
		}

		public void Interactable(bool value)
		{
			isInteractable = value;
			if (!isInteractable)
			{
				buttonCG.alpha = disabledOpacity;
			}
			else if (isInteractable)
			{
				buttonCG.alpha = 1f;
			}
			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Normal"))
			{
				TriggerAnimation("Normal");
			}
		}

		public void AddUINavigation()
		{
			if (targetButton == null)
			{
				if (base.gameObject.GetComponent<Button>() == null)
				{
					targetButton = base.gameObject.AddComponent<Button>();
				}
				else
				{
					targetButton = GetComponent<Button>();
				}
				targetButton.transition = Selectable.Transition.None;
			}
			if (targetButton.navigation.mode != navigationMode)
			{
				Navigation navigation = new Navigation
				{
					mode = navigationMode
				};
				if (navigationMode == Navigation.Mode.Vertical || navigationMode == Navigation.Mode.Horizontal)
				{
					navigation.wrapAround = wrapAround;
				}
				else if (navigationMode == Navigation.Mode.Explicit)
				{
					StartCoroutine("InitUINavigation", navigation);
					return;
				}
				targetButton.navigation = navigation;
			}
		}

		public void DisableUINavigation()
		{
			if (targetButton != null)
			{
				Navigation navigation = default(Navigation);
				Navigation.Mode mode = Navigation.Mode.None;
				navigation.mode = mode;
				targetButton.navigation = navigation;
			}
		}

		public void InvokeOnClick()
		{
			onClick.Invoke();
		}

		private void TriggerAnimation(string triggername)
		{
			animator.enabled = true;
			animator.ResetTrigger("Start");
			animator.ResetTrigger("Normal");
			animator.ResetTrigger("Highlighted");
			animator.SetTrigger(triggername);
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!isInteractable || eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (useSounds)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
			}
			onClick.Invoke();
			if (!checkForDoubleClick)
			{
				return;
			}
			if (waitingForDoubleClickInput)
			{
				onDoubleClick.Invoke();
				waitingForDoubleClickInput = false;
				return;
			}
			waitingForDoubleClickInput = true;
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("CheckForDoubleClick");
				StartCoroutine("CheckForDoubleClick");
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
				}
				TriggerAnimation("Highlighted");
				onHover.Invoke();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				TriggerAnimation("Normal");
				onLeave.Invoke();
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
				}
				TriggerAnimation("Highlighted");
				onSelect.Invoke();
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				TriggerAnimation("Normal");
				onDeselect.Invoke();
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				if (EventSystem.current.currentSelectedGameObject != base.gameObject)
				{
					TriggerAnimation("Normal");
				}
				onClick.Invoke();
			}
		}

		private IEnumerator CheckForDoubleClick()
		{
			yield return new WaitForSecondsRealtime(doubleClickPeriod);
			waitingForDoubleClickInput = false;
		}

		private IEnumerator InitUINavigation(Navigation nav)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			if (selectOnUp != null)
			{
				nav.selectOnUp = selectOnUp.GetComponent<Selectable>();
			}
			if (selectOnDown != null)
			{
				nav.selectOnDown = selectOnDown.GetComponent<Selectable>();
			}
			if (selectOnLeft != null)
			{
				nav.selectOnLeft = selectOnLeft.GetComponent<Selectable>();
			}
			if (selectOnRight != null)
			{
				nav.selectOnRight = selectOnRight.GetComponent<Selectable>();
			}
			targetButton.navigation = nav;
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSecondsRealtime(cachedStateLength);
			animator.enabled = false;
		}
	}
}
