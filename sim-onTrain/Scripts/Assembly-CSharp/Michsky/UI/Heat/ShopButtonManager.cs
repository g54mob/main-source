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
	public class ShopButtonManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		public enum State
		{
			Default = 0,
			Purchased = 1
		}

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

		public State state;

		public Sprite buttonIcon;

		public string buttonTitle = "Button";

		public string titleLocalizationKey;

		public string buttonDescription = "Description";

		public string descriptionLocalizationKey;

		public Sprite priceIcon;

		public string priceText = "123";

		public BackgroundFilter backgroundFilter;

		[SerializeField]
		private Animator animator;

		public ButtonManager purchaseButton;

		public ButtonManager purchasedButton;

		public GameObject purchasedIndicator;

		public ModalWindowManager purchaseModal;

		public Image iconObj;

		public Image priceIconObj;

		public TextMeshProUGUI titleObj;

		public TextMeshProUGUI descriptionObj;

		public TextMeshProUGUI priceObj;

		public Image filterObj;

		public List<Sprite> filters = new List<Sprite>();

		public bool isInteractable = true;

		public bool enableIcon;

		public bool enableTitle = true;

		public bool enableDescription = true;

		public bool enablePrice = true;

		public bool enableFilter = true;

		public bool useModalWindow = true;

		public bool useCustomContent;

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

		public UnityEvent onPurchaseClick = new UnityEvent();

		public UnityEvent onPurchase = new UnityEvent();

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		public UnityEvent onLeave = new UnityEvent();

		public UnityEvent onSelect = new UnityEvent();

		public UnityEvent onDeselect = new UnityEvent();

		private bool isInitialized;

		private float cachedStateLength = 0.5f;

		private Button targetButton;

		private void Awake()
		{
			cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(animator, "ShopButton_Highlighted") + 0.1f;
			InitializePurchaseEvents();
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
				ControllerManager.instance.shopButtons.Add(this);
			}
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			if (animator == null)
			{
				animator = GetComponent<Animator>();
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
				else
				{
					if (titleObj != null && !string.IsNullOrEmpty(titleLocalizationKey))
					{
						LocalizedObject component = titleObj.gameObject.GetComponent<LocalizedObject>();
						if (component != null)
						{
							component.tableIndex = mainLoc.tableIndex;
							component.localizationKey = titleLocalizationKey;
							component.UpdateItem();
						}
					}
					if (descriptionObj != null && !string.IsNullOrEmpty(descriptionLocalizationKey))
					{
						LocalizedObject component2 = descriptionObj.gameObject.GetComponent<LocalizedObject>();
						if (component2 != null)
						{
							component2.tableIndex = mainLoc.tableIndex;
							component2.localizationKey = descriptionLocalizationKey;
							component2.UpdateItem();
						}
					}
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
			if (!enablePrice && priceObj != null)
			{
				priceObj.transform.parent.gameObject.SetActive(value: false);
			}
			else if (enablePrice && priceIconObj != null)
			{
				if (priceObj != null)
				{
					priceObj.transform.parent.gameObject.SetActive(value: true);
					priceObj.text = priceText;
				}
				if (priceIconObj != null)
				{
					priceIconObj.sprite = priceIcon;
				}
			}
			if (!enableFilter && filterObj != null)
			{
				filterObj.gameObject.SetActive(value: false);
			}
			else if (enableFilter && filterObj != null && filters.Count > 1)
			{
				filterObj.gameObject.SetActive(value: true);
				if (Application.isPlaying && backgroundFilter == BackgroundFilter.Random)
				{
					filterObj.sprite = filters[Random.Range(0, filters.Count - 1)];
				}
				else if (filters.Count >= (int)(backgroundFilter + 1))
				{
					filterObj.sprite = filters[(int)backgroundFilter];
				}
			}
			UpdateState();
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				animator.enabled = true;
				animator.SetTrigger("Start");
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
		}

		public void UpdateState()
		{
			if (!(purchaseButton == null) && !(purchasedButton == null) && !(purchasedIndicator == null))
			{
				if (state == State.Default)
				{
					purchaseButton.gameObject.SetActive(value: true);
					purchasedButton.gameObject.SetActive(value: false);
					purchasedIndicator.gameObject.SetActive(value: false);
				}
				else if (state == State.Purchased)
				{
					purchaseButton.gameObject.SetActive(value: false);
					purchasedButton.gameObject.SetActive(value: true);
					purchasedIndicator.gameObject.SetActive(value: true);
				}
			}
		}

		public void SetState(State tempState)
		{
			state = tempState;
			UpdateState();
		}

		public void Purchase()
		{
			if (state != State.Purchased)
			{
				SetState(State.Purchased);
				onPurchase.Invoke();
			}
		}

		public void InitializePurchaseEvents()
		{
			if (purchaseButton == null)
			{
				Debug.LogError("<b>[Shop Button]</b> 'Purchase Button' is missing.", this);
				return;
			}
			purchaseButton.onClick.RemoveAllListeners();
			if (useModalWindow && purchaseModal != null)
			{
				onPurchaseClick.AddListener(delegate
				{
					purchaseModal.onConfirm.RemoveAllListeners();
					purchaseModal.onConfirm.AddListener(Purchase);
					purchaseModal.onConfirm.AddListener(purchaseModal.CloseWindow);
					purchaseModal.OpenWindow();
				});
			}
			purchaseButton.onClick.AddListener(onPurchaseClick.Invoke);
		}

		public void SetText(string text)
		{
			buttonTitle = text;
			UpdateUI();
		}

		public void SetIcon(Sprite icon)
		{
			buttonIcon = icon;
			UpdateUI();
		}

		public void SetPrice(string text)
		{
			priceText = text;
			UpdateUI();
		}

		public void SetInteractable(bool value)
		{
			isInteractable = value;
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
			if (isInteractable && eventData.button == PointerEventData.InputButton.Left)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				onClick.Invoke();
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
