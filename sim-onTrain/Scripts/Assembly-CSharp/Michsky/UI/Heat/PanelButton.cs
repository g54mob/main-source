using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class PanelButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		public Sprite buttonIcon;

		public string buttonText = "Button";

		[SerializeField]
		private CanvasGroup disabledCG;

		[SerializeField]
		private CanvasGroup normalCG;

		[SerializeField]
		private CanvasGroup highlightCG;

		[SerializeField]
		private CanvasGroup selectCG;

		[SerializeField]
		private TextMeshProUGUI disabledTextObj;

		[SerializeField]
		private TextMeshProUGUI normalTextObj;

		[SerializeField]
		private TextMeshProUGUI highlightTextObj;

		[SerializeField]
		private TextMeshProUGUI selectTextObj;

		[SerializeField]
		private Image disabledImageObj;

		[SerializeField]
		private Image normalImageObj;

		[SerializeField]
		private Image highlightImageObj;

		[SerializeField]
		private Image selectedImageObj;

		[SerializeField]
		private GameObject seperator;

		public bool isInteractable = true;

		public bool isSelected;

		public bool useLocalization = true;

		public bool useCustomText;

		public bool useSeperator = true;

		public bool useUINavigation;

		public Navigation.Mode navigationMode = Navigation.Mode.Automatic;

		public GameObject selectOnUp;

		public GameObject selectOnDown;

		public GameObject selectOnLeft;

		public GameObject selectOnRight;

		public bool wrapAround;

		public bool useSounds = true;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		public UnityEvent onLeave = new UnityEvent();

		public UnityEvent onSelect = new UnityEvent();

		private bool isInitialized;

		private Button targetButton;

		private LocalizedObject localizedObject;

		[HideInInspector]
		public NavigationBar navbar;

		private void OnEnable()
		{
			if (!isInitialized)
			{
				Initialize();
			}
			UpdateUI();
		}

		private void Initialize()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			if (useUINavigation)
			{
				AddUINavigation();
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			disabledCG.alpha = 0f;
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			selectCG.alpha = 0f;
			if (useLocalization)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (useLocalization && !string.IsNullOrEmpty(localizedObject.localizationKey))
				{
					buttonText = localizedObject.GetKeyOutput(localizedObject.localizationKey);
					localizedObject.onLanguageChanged.AddListener(delegate
					{
						buttonText = localizedObject.GetKeyOutput(localizedObject.localizationKey);
						UpdateUI();
					});
				}
			}
			isInitialized = true;
		}

		public void IsInteractable(bool value)
		{
			isInteractable = value;
			if (!isInteractable)
			{
				StartCoroutine("SetDisabled");
			}
			else if (isInteractable && !isSelected)
			{
				StartCoroutine("SetNormal");
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

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isInteractable)
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
			if (navbar != null)
			{
				navbar.DimButtons(this);
			}
			if (useSounds)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
			}
			if (isInteractable && !isSelected)
			{
				onHover.Invoke();
				StartCoroutine("SetHighlight");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (navbar != null)
			{
				navbar.LitButtons();
			}
			if (isInteractable && !isSelected)
			{
				onLeave.Invoke();
				StartCoroutine("SetNormal");
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (isInteractable && !isSelected)
			{
				StartCoroutine("SetHighlight");
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable && !isSelected)
			{
				StartCoroutine("SetNormal");
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (isInteractable && !isSelected)
			{
				onClick.Invoke();
			}
		}

		public void UpdateUI()
		{
			if (useSeperator && base.transform.parent != null && base.transform.GetSiblingIndex() != base.transform.parent.childCount - 1 && seperator != null)
			{
				seperator.SetActive(value: true);
			}
			else if (seperator != null)
			{
				seperator.SetActive(value: false);
			}
			if (!useCustomText)
			{
				if (disabledTextObj != null)
				{
					disabledTextObj.text = buttonText;
				}
				if (normalTextObj != null)
				{
					normalTextObj.text = buttonText;
				}
				if (highlightTextObj != null)
				{
					highlightTextObj.text = buttonText;
				}
				if (selectTextObj != null)
				{
					selectTextObj.text = buttonText;
				}
				if (disabledImageObj != null && buttonIcon != null)
				{
					disabledImageObj.transform.parent.gameObject.SetActive(value: true);
					disabledImageObj.sprite = buttonIcon;
				}
				else if (disabledImageObj != null && buttonIcon == null)
				{
					disabledImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (normalImageObj != null && buttonIcon != null)
				{
					normalImageObj.transform.parent.gameObject.SetActive(value: true);
					normalImageObj.sprite = buttonIcon;
				}
				else if (normalImageObj != null && buttonIcon == null)
				{
					normalImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (highlightImageObj != null && buttonIcon != null)
				{
					highlightImageObj.transform.parent.gameObject.SetActive(value: true);
					highlightImageObj.sprite = buttonIcon;
				}
				else if (highlightImageObj != null && buttonIcon == null)
				{
					highlightImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (selectedImageObj != null && buttonIcon != null)
				{
					selectedImageObj.transform.parent.gameObject.SetActive(value: true);
					selectedImageObj.sprite = buttonIcon;
				}
				else if (selectedImageObj != null && buttonIcon == null)
				{
					selectedImageObj.transform.parent.gameObject.SetActive(value: false);
				}
				if (isSelected)
				{
					disabledCG.alpha = 0f;
					normalCG.alpha = 0f;
					highlightCG.alpha = 0f;
					selectCG.alpha = 1f;
				}
				else if (!isInteractable)
				{
					disabledCG.alpha = 1f;
					normalCG.alpha = 0f;
					highlightCG.alpha = 0f;
					selectCG.alpha = 0f;
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			}
		}

		public void SetSelected(bool value)
		{
			isSelected = value;
			if (navbar != null)
			{
				navbar.LitButtons(this);
			}
			if (isSelected)
			{
				StartCoroutine("SetSelect");
				onSelect.Invoke();
			}
			else
			{
				StartCoroutine("SetNormal");
			}
		}

		private IEnumerator SetDisabled()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			StopCoroutine("SetSelect");
			while (disabledCG.alpha < 0.99f)
			{
				disabledCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			disabledCG.alpha = 1f;
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			selectCG.alpha = 0f;
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetDisabled");
			StopCoroutine("SetHighlight");
			StopCoroutine("SetSelect");
			while (normalCG.alpha < 0.99f)
			{
				disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				normalCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			disabledCG.alpha = 0f;
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			selectCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetDisabled");
			StopCoroutine("SetNormal");
			StopCoroutine("SetSelect");
			while (highlightCG.alpha < 0.99f)
			{
				disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			disabledCG.alpha = 0f;
			normalCG.alpha = 0f;
			highlightCG.alpha = 1f;
			selectCG.alpha = 0f;
		}

		private IEnumerator SetSelect()
		{
			StopCoroutine("SetDisabled");
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			while (selectCG.alpha < 0.99f)
			{
				disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				selectCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			disabledCG.alpha = 0f;
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			selectCG.alpha = 1f;
		}
	}
}
