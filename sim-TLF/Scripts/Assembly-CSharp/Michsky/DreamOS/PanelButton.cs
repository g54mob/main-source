using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class PanelButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		public Sprite buttonIcon;

		public string buttonText = "Button";

		[SerializeField]
		private CanvasGroup normalCG;

		[SerializeField]
		private CanvasGroup highlightCG;

		[SerializeField]
		private CanvasGroup pressCG;

		[SerializeField]
		private CanvasGroup selectCG;

		[SerializeField]
		private TextMeshProUGUI normalTextObj;

		[SerializeField]
		private TextMeshProUGUI highlightTextObj;

		[SerializeField]
		private TextMeshProUGUI pressedTextObj;

		[SerializeField]
		private TextMeshProUGUI selectedTextObj;

		[SerializeField]
		private Image normalImageObj;

		[SerializeField]
		private Image highlightImageObj;

		[SerializeField]
		private Image pressedImageObj;

		[SerializeField]
		private Image selectedImageObj;

		public bool isInteractable = true;

		public bool isSelected;

		public bool useLocalization = true;

		public bool useCustomText;

		public bool useUINavigation;

		public Navigation.Mode navigationMode = Navigation.Mode.Automatic;

		public GameObject selectOnUp;

		public GameObject selectOnDown;

		public GameObject selectOnLeft;

		public GameObject selectOnRight;

		public bool wrapAround;

		public bool useSounds;

		[Range(0f, 15f)]
		public float fadingMultiplier = 8f;

		public UnityEvent onClick = new UnityEvent();

		public UnityEvent onHover = new UnityEvent();

		private bool isInitialized;

		private bool isPressedCGEmpty;

		private Button targetButton;

		private LocalizedObject localizedObject;

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
			if (pressCG == null)
			{
				pressCG = new GameObject().AddComponent<CanvasGroup>();
				pressCG.gameObject.AddComponent<RectTransform>();
				pressCG.transform.SetParent(base.transform);
				pressCG.gameObject.name = "Pressed";
				isPressedCGEmpty = true;
			}
			if (selectCG == null)
			{
				selectCG = new GameObject().AddComponent<CanvasGroup>();
				selectCG.gameObject.AddComponent<RectTransform>();
				selectCG.transform.SetParent(base.transform);
				selectCG.gameObject.name = "Selected";
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			pressCG.alpha = 0f;
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

		public void UpdateUI()
		{
			if (useCustomText)
			{
				return;
			}
			if (normalTextObj != null)
			{
				normalTextObj.text = buttonText;
			}
			if (highlightTextObj != null)
			{
				highlightTextObj.text = buttonText;
			}
			if (pressedTextObj != null)
			{
				pressedTextObj.text = buttonText;
			}
			if (selectedTextObj != null)
			{
				selectedTextObj.text = buttonText;
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
			if (pressedImageObj != null && buttonIcon != null)
			{
				pressedImageObj.transform.parent.gameObject.SetActive(value: true);
				pressedImageObj.sprite = buttonIcon;
			}
			else if (pressedImageObj != null && buttonIcon == null)
			{
				pressedImageObj.transform.parent.gameObject.SetActive(value: false);
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
				normalCG.alpha = 0f;
				highlightCG.alpha = 0f;
				if (pressCG != null)
				{
					pressCG.alpha = 0f;
				}
				selectCG.alpha = 1f;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}

		public void SetSelected(bool value)
		{
			isSelected = value;
			if (isSelected)
			{
				StartCoroutine("SetSelect");
			}
			else
			{
				StartCoroutine("SetNormal");
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (isInteractable && !isSelected && !isPressedCGEmpty && !(pressCG == null) && eventData.button == PointerEventData.InputButton.Left)
			{
				StartCoroutine("SetPressed");
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (isInteractable && !isPressedCGEmpty && !isSelected)
			{
				StartCoroutine("SetNormal");
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isInteractable && eventData.button == PointerEventData.InputButton.Left)
			{
				if (AudioManager.instance != null && useSounds)
				{
					AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.clickSound);
				}
				onClick.Invoke();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (AudioManager.instance != null && useSounds)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.hoverSound);
			}
			if (isInteractable && !isSelected)
			{
				onHover.Invoke();
				StartCoroutine("SetHighlight");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable && !isSelected)
			{
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

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			StopCoroutine("SetPressed");
			StopCoroutine("SetSelect");
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
					if (pressCG != null)
					{
						pressCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					}
					selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					yield return null;
				}
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			if (pressCG != null)
			{
				pressCG.alpha = 0f;
			}
			selectCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetPressed");
			StopCoroutine("SetSelect");
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
					if (pressCG != null)
					{
						pressCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					}
					selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					yield return null;
				}
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 1f;
			if (pressCG != null)
			{
				pressCG.alpha = 0f;
			}
			selectCG.alpha = 0f;
		}

		private IEnumerator SetPressed()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			StopCoroutine("SetSelect");
			if (fadingMultiplier == 0f)
			{
				pressCG.alpha = 1f;
			}
			else
			{
				while (pressCG.alpha < 0.99f)
				{
					normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					pressCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					selectCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					yield return null;
				}
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			pressCG.alpha = 1f;
			selectCG.alpha = 0f;
		}

		private IEnumerator SetSelect()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			StopCoroutine("SetPressed");
			if (fadingMultiplier == 0f)
			{
				selectCG.alpha = 1f;
			}
			while (selectCG.alpha < 0.99f)
			{
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				if (pressCG != null)
				{
					pressCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				}
				selectCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			if (pressCG != null)
			{
				pressCG.alpha = 0f;
			}
			selectCG.alpha = 1f;
		}
	}
}
