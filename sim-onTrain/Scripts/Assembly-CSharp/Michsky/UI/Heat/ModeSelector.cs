using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	public class ModeSelector : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		[Serializable]
		public class Item
		{
			public string title = "Mode Title";

			public string titleKey = "";

			public Sprite icon;

			public Sprite background;

			public UnityEvent onModeSelection = new UnityEvent();
		}

		public int currentModeIndex;

		public List<Item> items = new List<Item>();

		public string headerTitle = "Selected Mode";

		public string headerTitleKey = "";

		[SerializeField]
		private UIPopup modeSelectPopup;

		[SerializeField]
		private ImageFading transitionPanel;

		[SerializeField]
		private Transform itemParent;

		[SerializeField]
		private ButtonManager itemPreset;

		[SerializeField]
		private CanvasGroup normalCG;

		[SerializeField]
		private CanvasGroup highlightCG;

		[SerializeField]
		private CanvasGroup disabledCG;

		[SerializeField]
		private TextMeshProUGUI disabledHeaderObj;

		[SerializeField]
		private TextMeshProUGUI normalHeaderObj;

		[SerializeField]
		private TextMeshProUGUI highlightHeaderObj;

		[SerializeField]
		private TextMeshProUGUI disabledTextObj;

		[SerializeField]
		private TextMeshProUGUI normalTextObj;

		[SerializeField]
		private TextMeshProUGUI highlightTextObj;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Image disabledIconObj;

		[SerializeField]
		private Image normalIconObj;

		[SerializeField]
		private Image highlightIconObj;

		public bool isInteractable = true;

		public bool useLocalization = true;

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

		public UnityEvent onDeselect = new UnityEvent();

		private bool isInitialized;

		private Button targetButton;

		private LocalizedObject localizedObject;

		private string tempTitleOutput;

		private void OnEnable()
		{
			if (!isInitialized)
			{
				Initialize();
			}
			if (useLocalization && !string.IsNullOrEmpty(headerTitleKey))
			{
				LocalizedObject component = disabledHeaderObj.GetComponent<LocalizedObject>();
				if (component != null)
				{
					component.localizationKey = headerTitleKey;
					component.UpdateItem();
				}
				component = normalHeaderObj.GetComponent<LocalizedObject>();
				if (component != null)
				{
					component.localizationKey = headerTitleKey;
					component.UpdateItem();
				}
				component = highlightHeaderObj.GetComponent<LocalizedObject>();
				if (component != null)
				{
					component.localizationKey = headerTitleKey;
					component.UpdateItem();
				}
			}
			else
			{
				disabledHeaderObj.text = headerTitle;
				normalHeaderObj.text = headerTitle;
				highlightHeaderObj.text = headerTitle;
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 0f;
			if (useLocalization && !string.IsNullOrEmpty(items[currentModeIndex].titleKey))
			{
				tempTitleOutput = localizedObject.GetKeyOutput(items[currentModeIndex].titleKey);
				SelectMode(currentModeIndex, applyData: false);
			}
		}

		public void Initialize()
		{
			if (items.Count == 0)
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
			if (disabledCG == null)
			{
				disabledCG = new GameObject().AddComponent<CanvasGroup>();
				disabledCG.gameObject.AddComponent<RectTransform>();
				disabledCG.transform.SetParent(base.transform);
				disabledCG.gameObject.name = "Disabled";
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (useLocalization)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
			}
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < items.Count; i++)
			{
				int tempIndex = i;
				GameObject gameObject = UnityEngine.Object.Instantiate(itemPreset.gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(itemParent, worldPositionStays: false);
				gameObject.gameObject.name = items[i].title;
				ButtonManager itemButton = gameObject.GetComponent<ButtonManager>();
				itemButton.buttonIcon = items[i].icon;
				if (!useLocalization || string.IsNullOrEmpty(items[tempIndex].titleKey))
				{
					itemButton.buttonText = items[i].title;
				}
				else
				{
					LocalizedObject tempLoc = itemButton.GetComponent<LocalizedObject>();
					if (tempLoc != null)
					{
						tempLoc.tableIndex = localizedObject.tableIndex;
						tempLoc.localizationKey = items[i].titleKey;
						tempLoc.onLanguageChanged.AddListener(delegate
						{
							itemButton.buttonText = tempLoc.GetKeyOutput(tempLoc.localizationKey);
							itemButton.UpdateUI();
						});
						tempLoc.InitializeItem();
						tempLoc.UpdateItem();
					}
				}
				itemButton.onClick.AddListener(delegate
				{
					if (!string.IsNullOrEmpty(items[tempIndex].titleKey) && useLocalization)
					{
						tempTitleOutput = localizedObject.GetKeyOutput(items[tempIndex].titleKey);
					}
					SelectMode(tempIndex, applyData: false);
				});
				itemButton.UpdateUI();
				if (tempIndex == currentModeIndex && !string.IsNullOrEmpty(items[tempIndex].titleKey) && useLocalization)
				{
					tempTitleOutput = localizedObject.GetKeyOutput(items[tempIndex].titleKey);
				}
			}
			onClick.AddListener(delegate
			{
				modeSelectPopup.Animate();
			});
			items[currentModeIndex].onModeSelection.Invoke();
			modeSelectPopup.gameObject.SetActive(value: false);
			ApplyModeData(currentModeIndex);
			isInitialized = true;
		}

		public void SelectMode(int index)
		{
			if (currentModeIndex != index)
			{
				if (useLocalization && !string.IsNullOrEmpty(items[index].titleKey))
				{
					tempTitleOutput = localizedObject.GetKeyOutput(items[index].titleKey);
				}
				SelectMode(index, applyData: false);
			}
		}

		public void SelectMode(int index, bool applyData)
		{
			if (transitionPanel == null)
			{
				ApplyModeData(index);
			}
			else
			{
				transitionPanel.onFadeInEnd.RemoveAllListeners();
				transitionPanel.onFadeInEnd.AddListener(delegate
				{
					ApplyModeData(index);
				});
				transitionPanel.FadeIn();
			}
			currentModeIndex = index;
			items[index].onModeSelection.Invoke();
			modeSelectPopup.PlayOut();
			if (applyData)
			{
				ApplyModeData(index);
			}
		}

		private void ApplyModeData(int index)
		{
			backgroundImage.sprite = items[index].background;
			disabledIconObj.sprite = items[index].icon;
			normalIconObj.sprite = items[index].icon;
			highlightIconObj.sprite = items[index].icon;
			if (string.IsNullOrEmpty(tempTitleOutput))
			{
				disabledTextObj.text = items[index].title;
				normalTextObj.text = items[index].title;
				highlightTextObj.text = items[index].title;
			}
			else
			{
				disabledTextObj.text = tempTitleOutput;
				normalTextObj.text = tempTitleOutput;
				highlightTextObj.text = tempTitleOutput;
			}
		}

		public void UpdateState()
		{
			if (Application.isPlaying && base.gameObject.activeInHierarchy)
			{
				if (!modeSelectPopup.isOn)
				{
					modeSelectPopup.PlayOut();
				}
				else
				{
					modeSelectPopup.PlayIn();
				}
				if (!isInteractable)
				{
					StartCoroutine("SetDisabled");
				}
				else
				{
					StartCoroutine("SetNormal");
				}
			}
		}

		public void Interactable(bool value)
		{
			isInteractable = value;
			if (!value)
			{
				modeSelectPopup.PlayOut();
			}
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
				StartCoroutine("SetHighlight");
				onHover.Invoke();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetNormal");
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
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				if (EventSystem.current.currentSelectedGameObject != base.gameObject)
				{
					StartCoroutine("SetNormal");
				}
				onClick.Invoke();
			}
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			StopCoroutine("SetDisabled");
			while (normalCG.alpha < 0.99f)
			{
				normalCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			normalCG.alpha = 1f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetDisabled");
			while (highlightCG.alpha < 0.99f)
			{
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				disabledCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 1f;
			disabledCG.alpha = 0f;
		}

		private IEnumerator SetDisabled()
		{
			StopCoroutine("SetNormal");
			StopCoroutine("SetHighlight");
			while (disabledCG.alpha < 0.99f)
			{
				normalCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				disabledCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			normalCG.alpha = 0f;
			highlightCG.alpha = 0f;
			disabledCG.alpha = 1f;
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
