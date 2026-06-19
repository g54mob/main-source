using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	public class ButtonManager : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		public enum RippleUpdateMode
		{
			Normal = 0,
			UnscaledTime = 1
		}

		[Serializable]
		public class Padding
		{
			public int left = 18;

			public int right = 18;

			public int top = 15;

			public int bottom = 15;
		}

		public Sprite buttonIcon;

		public string buttonText = "Button";

		[Range(0.1f, 10f)]
		public float iconScale = 1f;

		[Range(1f, 200f)]
		public float textSize = 24f;

		public AudioClip hoverSound;

		public AudioClip clickSound;

		[SerializeField]
		private Canvas targetCanvas;

		[SerializeField]
		private CanvasGroup normalCG;

		[SerializeField]
		private CanvasGroup highlightCG;

		[SerializeField]
		private CanvasGroup pressedCG;

		[SerializeField]
		private CanvasGroup disabledCG;

		public TextMeshProUGUI normalTextObj;

		public TextMeshProUGUI highlightTextObj;

		public TextMeshProUGUI pressedTextObj;

		public TextMeshProUGUI disabledTextObj;

		public Image normalImageObj;

		public Image highlightImageObj;

		public Image pressedImageObj;

		public Image disabledImageObj;

		public GameObject rippleParent;

		public HoverEffect hoverEffect;

		public bool autoFitContent = true;

		public Padding padding;

		[Range(0f, 100f)]
		public int spacing = 12;

		[SerializeField]
		private HorizontalLayoutGroup disabledLayout;

		[SerializeField]
		private HorizontalLayoutGroup normalLayout;

		[SerializeField]
		private HorizontalLayoutGroup highlightedLayout;

		[SerializeField]
		private HorizontalLayoutGroup pressedLayout;

		public HorizontalLayoutGroup mainLayout;

		[SerializeField]
		private ContentSizeFitter mainFitter;

		[SerializeField]
		private ContentSizeFitter targetFitter;

		[SerializeField]
		private RectTransform targetRect;

		public bool isInteractable = true;

		public bool enableIcon;

		public bool enableText = true;

		public bool useCustomContent;

		[SerializeField]
		private bool useCustomTextSize;

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

		public bool useSounds;

		public bool useRipple = true;

		public bool useHoverEffect;

		[Range(0.1f, 1f)]
		public float doubleClickPeriod = 0.25f;

		[Range(0f, 15f)]
		public float fadingMultiplier = 8f;

		public RippleUpdateMode rippleUpdateMode = RippleUpdateMode.UnscaledTime;

		public Sprite rippleShape;

		[Range(0.1f, 8f)]
		public float speed = 1f;

		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		public Color startColor = new Color(1f, 1f, 1f, 1f);

		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		public bool renderOnTop;

		public bool centered;

		[Range(1f, 25f)]
		public float heSpeed = 10f;

		[Range(0.1f, 25f)]
		public float heSize = 2f;

		public Sprite heShape;

		[Range(0f, 1f)]
		public float heTransitionAlpha = 0.1f;

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onDoubleClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		public UnityEvent onLeave = new UnityEvent();

		public UnityEvent onSelect = new UnityEvent();

		public UnityEvent onDeselect = new UnityEvent();

		private bool isInitialized;

		private bool isPointerOn;

		private bool isPressedCGEmpty;

		private Button targetButton;

		private LocalizedObject localizedObject;

		private bool waitingForDoubleClickInput;

		private void Start()
		{
			if (targetCanvas == null)
			{
				targetCanvas = GetComponentInParent<Canvas>();
			}
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
		}

		private void OnDisable()
		{
			if (isInteractable)
			{
				if (disabledCG != null)
				{
					disabledCG.alpha = 0f;
				}
				if (normalCG != null)
				{
					normalCG.alpha = 1f;
				}
				if (highlightCG != null)
				{
					highlightCG.alpha = 0f;
				}
				if (pressedCG != null)
				{
					pressedCG.alpha = 0f;
				}
			}
		}

		private void Initialize()
		{
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (useUINavigation)
			{
				AddUINavigation();
			}
			if (normalCG == null)
			{
				normalCG = new GameObject().AddComponent<CanvasGroup>();
				normalCG.gameObject.AddComponent<RectTransform>();
				normalCG.transform.SetParent(base.transform);
				normalCG.gameObject.name = "Normal";
			}
			if (highlightCG == null)
			{
				highlightCG = new GameObject().AddComponent<CanvasGroup>();
				highlightCG.gameObject.AddComponent<RectTransform>();
				highlightCG.transform.SetParent(base.transform);
				highlightCG.gameObject.name = "Highlight";
			}
			if (pressedCG == null)
			{
				pressedCG = new GameObject().AddComponent<CanvasGroup>();
				pressedCG.gameObject.AddComponent<RectTransform>();
				pressedCG.transform.SetParent(base.transform);
				pressedCG.gameObject.name = "Pressed";
				isPressedCGEmpty = true;
			}
			if (disabledCG == null)
			{
				disabledCG = new GameObject().AddComponent<CanvasGroup>();
				disabledCG.gameObject.AddComponent<RectTransform>();
				disabledCG.transform.SetParent(base.transform);
				disabledCG.gameObject.name = "Disabled";
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			pressedCG.alpha = 0f;
			disabledCG.alpha = 0f;
			if (useLocalization && !useCustomContent)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (localizedObject != null && !string.IsNullOrEmpty(localizedObject.localizationKey))
				{
					buttonText = localizedObject.GetKeyOutput(localizedObject.localizationKey);
					localizedObject.onLanguageChanged.AddListener(delegate
					{
						buttonText = localizedObject.GetKeyOutput(localizedObject.localizationKey);
						UpdateUI();
					});
				}
			}
			maxSize = Mathf.Clamp(maxSize, 0.5f, 1000f);
			if (useRipple && rippleParent != null)
			{
				rippleParent.SetActive(value: false);
			}
			else if (!useRipple && rippleParent != null)
			{
				UnityEngine.Object.Destroy(rippleParent);
			}
			if (useHoverEffect && hoverEffect != null)
			{
				hoverEffect.gameObject.SetActive(value: false);
			}
			isInitialized = true;
		}

		public void UpdateUI()
		{
			if (!autoFitContent)
			{
				if (mainFitter != null)
				{
					mainFitter.enabled = false;
				}
				if (mainLayout != null)
				{
					mainLayout.enabled = false;
				}
				if (disabledLayout != null)
				{
					disabledLayout.childForceExpandWidth = false;
				}
				if (normalLayout != null)
				{
					normalLayout.childForceExpandWidth = false;
				}
				if (highlightedLayout != null)
				{
					highlightedLayout.childForceExpandWidth = false;
				}
				if (pressedLayout != null)
				{
					pressedLayout.childForceExpandWidth = false;
				}
				if (targetFitter != null)
				{
					targetFitter.enabled = false;
					if (targetRect != null)
					{
						targetRect.anchorMin = new Vector2(0f, 0f);
						targetRect.anchorMax = new Vector2(1f, 1f);
						targetRect.offsetMin = new Vector2(0f, 0f);
						targetRect.offsetMax = new Vector2(0f, 0f);
					}
				}
			}
			else
			{
				if (disabledLayout != null)
				{
					disabledLayout.childForceExpandWidth = true;
				}
				if (normalLayout != null)
				{
					normalLayout.childForceExpandWidth = true;
				}
				if (highlightedLayout != null)
				{
					highlightedLayout.childForceExpandWidth = true;
				}
				if (pressedLayout != null)
				{
					pressedLayout.childForceExpandWidth = true;
				}
				if (mainFitter != null)
				{
					mainFitter.enabled = true;
				}
				if (mainLayout != null)
				{
					mainLayout.enabled = true;
				}
				if (targetFitter != null)
				{
					targetFitter.enabled = true;
				}
			}
			if (disabledLayout != null && autoFitContent)
			{
				disabledLayout.padding = new RectOffset(padding.left, padding.right, padding.top, padding.bottom);
				disabledLayout.spacing = spacing;
			}
			if (normalLayout != null && autoFitContent)
			{
				normalLayout.padding = new RectOffset(padding.left, padding.right, padding.top, padding.bottom);
				normalLayout.spacing = spacing;
			}
			if (highlightedLayout != null && autoFitContent)
			{
				highlightedLayout.padding = new RectOffset(padding.left, padding.right, padding.top, padding.bottom);
				highlightedLayout.spacing = spacing;
			}
			if (pressedLayout != null && autoFitContent)
			{
				pressedLayout.padding = new RectOffset(padding.left, padding.right, padding.top, padding.bottom);
				pressedLayout.spacing = spacing;
			}
			if (enableText && !useCustomContent)
			{
				if (normalTextObj != null)
				{
					normalTextObj.gameObject.SetActive(value: true);
					normalTextObj.text = buttonText;
					if (!useCustomTextSize)
					{
						normalTextObj.fontSize = textSize;
					}
				}
				if (highlightTextObj != null)
				{
					highlightTextObj.gameObject.SetActive(value: true);
					highlightTextObj.text = buttonText;
					if (!useCustomTextSize)
					{
						highlightTextObj.fontSize = textSize;
					}
				}
				if (pressedTextObj != null)
				{
					pressedTextObj.gameObject.SetActive(value: true);
					pressedTextObj.text = buttonText;
					if (!useCustomTextSize)
					{
						pressedTextObj.fontSize = textSize;
					}
				}
				if (disabledTextObj != null)
				{
					disabledTextObj.gameObject.SetActive(value: true);
					disabledTextObj.text = buttonText;
					if (!useCustomTextSize)
					{
						disabledTextObj.fontSize = textSize;
					}
				}
			}
			else if (!enableText)
			{
				if (normalTextObj != null)
				{
					normalTextObj.gameObject.SetActive(value: false);
				}
				if (highlightTextObj != null)
				{
					highlightTextObj.gameObject.SetActive(value: false);
				}
				if (pressedTextObj != null)
				{
					pressedTextObj.gameObject.SetActive(value: false);
				}
				if (disabledTextObj != null)
				{
					disabledTextObj.gameObject.SetActive(value: false);
				}
			}
			if (enableIcon && buttonIcon != null && !useCustomContent)
			{
				Vector3 localScale = new Vector3(iconScale, iconScale, iconScale);
				if (normalImageObj != null)
				{
					normalImageObj.transform.parent.gameObject.SetActive(value: true);
					normalImageObj.sprite = buttonIcon;
					normalImageObj.transform.localScale = localScale;
				}
				if (highlightImageObj != null)
				{
					highlightImageObj.transform.parent.gameObject.SetActive(value: true);
					highlightImageObj.sprite = buttonIcon;
					highlightImageObj.transform.localScale = localScale;
				}
				if (pressedImageObj != null)
				{
					pressedImageObj.transform.parent.gameObject.SetActive(value: true);
					pressedImageObj.sprite = buttonIcon;
					pressedImageObj.transform.localScale = localScale;
				}
				if (disabledImageObj != null)
				{
					disabledImageObj.transform.parent.gameObject.SetActive(value: true);
					disabledImageObj.sprite = buttonIcon;
					disabledImageObj.transform.localScale = localScale;
				}
			}
			else if (!enableIcon || buttonIcon == null)
			{
				if (normalImageObj != null)
				{
					normalImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (highlightImageObj != null)
				{
					highlightImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (pressedImageObj != null)
				{
					pressedImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (disabledImageObj != null)
				{
					disabledImageObj.transform.parent.gameObject.SetActive(value: false);
				}
			}
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				if (!isInteractable)
				{
					StartCoroutine("SetDisabled");
				}
				else if (isInteractable && disabledCG.alpha == 1f)
				{
					StartCoroutine("SetNormal");
				}
				StartCoroutine("LayoutFix");
			}
		}

		public void UpdateState()
		{
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				if (!isInteractable)
				{
					StartCoroutine("SetDisabled");
				}
				else if (isInteractable)
				{
					StartCoroutine("SetNormal");
				}
			}
		}

		public void SetText(string text)
		{
			buttonText = text;
			UpdateUI();
		}

		public void SetIcon(Sprite icon)
		{
			if (icon != null)
			{
				buttonIcon = icon;
			}
			else
			{
				enableIcon = false;
			}
			UpdateUI();
		}

		public void Interactable(bool value)
		{
			isInteractable = value;
			if (base.gameObject.activeInHierarchy)
			{
				if (!isInteractable)
				{
					StartCoroutine("SetDisabled");
				}
				else if (isInteractable && disabledCG.alpha == 1f)
				{
					StartCoroutine("SetNormal");
				}
			}
		}

		public void AddUINavigation()
		{
			if (targetButton == null)
			{
				targetButton = base.gameObject.AddComponent<Button>();
				targetButton.transition = Selectable.Transition.None;
			}
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

		public void CreateRipple(Vector2 pos)
		{
			if (rippleParent != null)
			{
				GameObject gameObject = new GameObject();
				Image image = gameObject.AddComponent<Image>();
				image.raycastTarget = false;
				image.sprite = rippleShape;
				gameObject.name = "Ripple";
				rippleParent.SetActive(value: true);
				gameObject.transform.SetParent(rippleParent.transform);
				if (renderOnTop)
				{
					rippleParent.transform.SetAsLastSibling();
				}
				if (centered)
				{
					gameObject.transform.localPosition = new Vector2(0f, 0f);
				}
				else
				{
					gameObject.transform.position = pos;
				}
				gameObject.AddComponent<Ripple>();
				Ripple component = gameObject.GetComponent<Ripple>();
				component.speed = speed;
				component.maxSize = maxSize;
				component.startColor = startColor;
				component.transitionColor = transitionColor;
				if (rippleUpdateMode == RippleUpdateMode.Normal)
				{
					component.unscaledTime = false;
				}
				else
				{
					component.unscaledTime = true;
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!isInteractable || eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (AudioManager.instance != null && useSounds)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.clickSound);
			}
			if (base.gameObject.activeInHierarchy)
			{
				if (!isPointerOn)
				{
					StartCoroutine("SetNormal");
				}
				else
				{
					StartCoroutine("SetHighlight");
				}
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

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!isInteractable || eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (!isPressedCGEmpty)
			{
				StartCoroutine("SetPressed");
			}
			if (useRipple && isPointerOn)
			{
				if (targetCanvas != null && (targetCanvas.renderMode == RenderMode.ScreenSpaceCamera || targetCanvas.renderMode == RenderMode.WorldSpace))
				{
					CreateRipple(targetCanvas.worldCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
				}
				else
				{
					CreateRipple(Mouse.current.position.ReadValue());
				}
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (!isPressedCGEmpty && !isPointerOn)
				{
					StartCoroutine("SetNormal");
				}
				else if (isPointerOn)
				{
					StartCoroutine("SetHighlight");
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (AudioManager.instance != null && useSounds)
				{
					AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.hoverSound);
				}
				isPointerOn = true;
				StartCoroutine("SetHighlight");
				onHover.Invoke();
				if (useHoverEffect && hoverEffect != null)
				{
					hoverEffect.speed = heSpeed;
					hoverEffect.targetImage.sprite = heShape;
					hoverEffect.targetImage.transform.localScale = new Vector3(heSize, heSize, heSize);
					hoverEffect.transitionAlpha = heTransitionAlpha;
					hoverEffect.StartFadeIn();
				}
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (useHoverEffect && hoverEffect != null)
				{
					hoverEffect.StartFadeOut();
				}
				isPointerOn = false;
				StartCoroutine("SetNormal");
				onLeave.Invoke();
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (AudioManager.instance != null && useSounds)
				{
					AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.hoverSound);
				}
				StartCoroutine("SetHighlight");
				onSelect.Invoke();
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetNormal");
				onDeselect.Invoke();
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (isInteractable)
			{
				if (AudioManager.instance != null && useSounds)
				{
					AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.clickSound);
				}
				if (EventSystem.current.currentSelectedGameObject != base.gameObject)
				{
					StartCoroutine("SetNormal");
				}
				onClick.Invoke();
			}
		}

		private IEnumerator LayoutFix()
		{
			yield return new WaitForSecondsRealtime(0.025f);
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			if (base.transform.parent != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform.parent.GetComponent<RectTransform>());
			}
			if (disabledCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(disabledCG.GetComponent<RectTransform>());
			}
			if (normalCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(normalCG.GetComponent<RectTransform>());
			}
			if (highlightCG != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(highlightCG.GetComponent<RectTransform>());
			}
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			StopCoroutine("SetPressed");
			StopCoroutine("SetDisabled");
			if (fadingMultiplier == 0f)
			{
				normalCG.alpha = 1f;
			}
			else
			{
				while (normalCG.alpha < 0.99f)
				{
					normalCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					if (pressedCG != null)
					{
						pressedCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					}
					yield return null;
				}
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 0f;
			if (pressedCG != null)
			{
				pressedCG.alpha = 0f;
			}
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetPressed");
			StopCoroutine("SetDisabled");
			if (fadingMultiplier == 0f)
			{
				highlightCG.alpha = 1f;
			}
			else
			{
				while (highlightCG.alpha < 0.99f)
				{
					normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					if (pressedCG != null)
					{
						pressedCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					}
					yield return null;
				}
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 1f;
			disabledCG.alpha = 0f;
			if (pressedCG != null)
			{
				pressedCG.alpha = 0f;
			}
		}

		private IEnumerator SetPressed()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			StopCoroutine("SetDisabled");
			if (fadingMultiplier == 0f)
			{
				pressedCG.alpha = 1f;
			}
			else
			{
				while (pressedCG.alpha < 0.99f)
				{
					normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					if (pressedCG != null)
					{
						pressedCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					}
					yield return null;
				}
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 0f;
			if (pressedCG != null)
			{
				pressedCG.alpha = 1f;
			}
		}

		private IEnumerator SetDisabled()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			if (fadingMultiplier == 0f)
			{
				disabledCG.alpha = 1f;
			}
			else
			{
				while (disabledCG.alpha < 0.99f)
				{
					normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					disabledCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					if (pressedCG != null)
					{
						pressedCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					}
					yield return null;
				}
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 1f;
			if (pressedCG != null)
			{
				pressedCG.alpha = 0f;
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
	}
}
