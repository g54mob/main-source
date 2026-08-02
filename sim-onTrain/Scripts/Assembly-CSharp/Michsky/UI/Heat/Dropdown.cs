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
	public class Dropdown : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		[Serializable]
		public class DropdownEvent : UnityEvent<int>
		{
		}

		public enum PanelDirection
		{
			Bottom = 0,
			Top = 1
		}

		[Serializable]
		public class Item
		{
			public string itemName = "Dropdown Item";

			public string localizationKey;

			public Sprite itemIcon;

			[HideInInspector]
			public int itemIndex;

			[HideInInspector]
			public bool isInvisible;

			[HideInInspector]
			public ButtonManager itemButton;

			public UnityEvent onItemSelection = new UnityEvent();
		}

		public GameObject triggerObject;

		public TextMeshProUGUI headerText;

		public Image headerImage;

		public Transform itemParent;

		[SerializeField]
		private GameObject itemPreset;

		public Scrollbar scrollbar;

		public VerticalLayoutGroup itemList;

		[SerializeField]
		private CanvasGroup highlightCG;

		public CanvasGroup contentCG;

		[SerializeField]
		private CanvasGroup listCG;

		[SerializeField]
		private RectTransform listRect;

		public bool isInteractable = true;

		public bool enableIcon = true;

		public bool enableTrigger = true;

		public bool enableScrollbar = true;

		[SerializeField]
		private bool startAtBottom;

		[SerializeField]
		private bool useGamepadInput;

		public bool setHighPriority = true;

		public bool updateOnEnable = true;

		public bool outOnPointerExit;

		public bool invokeOnEnable;

		public bool initOnEnable = true;

		public bool useSounds = true;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		[Range(1f, 50f)]
		public int itemPaddingTop = 8;

		[Range(1f, 50f)]
		public int itemPaddingBottom = 8;

		[Range(1f, 50f)]
		public int itemPaddingLeft = 8;

		[Range(1f, 50f)]
		public int itemPaddingRight = 25;

		[Range(1f, 50f)]
		public int itemSpacing = 8;

		public int selectedItemIndex;

		public bool useUINavigation;

		public Navigation.Mode navigationMode = Navigation.Mode.Automatic;

		public GameObject selectOnUp;

		public GameObject selectOnDown;

		public GameObject selectOnLeft;

		public GameObject selectOnRight;

		public bool wrapAround;

		public PanelDirection panelDirection;

		[Range(25f, 1000f)]
		public float panelSize = 200f;

		[Range(0.5f, 10f)]
		public float curveSpeed = 2f;

		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public bool saveSelected;

		public string saveKey = "My Dropdown";

		[SerializeField]
		public List<Item> items = new List<Item>();

		public DropdownEvent onValueChanged;

		[HideInInspector]
		public bool isOn;

		[HideInInspector]
		public int index;

		[HideInInspector]
		public int siblingIndex;

		private EventTrigger triggerEvent;

		private Button targetButton;

		private void Awake()
		{
			if (initOnEnable)
			{
				Initialize();
			}
			if (useUINavigation)
			{
				AddUINavigation();
			}
			if (enableTrigger && triggerObject != null)
			{
				triggerEvent = triggerObject.AddComponent<EventTrigger>();
				EventTrigger.Entry entry = new EventTrigger.Entry();
				entry.eventID = EventTriggerType.PointerClick;
				entry.callback.AddListener(delegate
				{
					Animate();
				});
				triggerEvent.GetComponent<EventTrigger>().triggers.Add(entry);
			}
			if (highlightCG == null)
			{
				highlightCG = new GameObject().AddComponent<CanvasGroup>();
				highlightCG.gameObject.AddComponent<RectTransform>();
				highlightCG.transform.SetParent(base.transform);
				highlightCG.gameObject.name = "Highlight";
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (setHighPriority)
			{
				if (contentCG == null)
				{
					contentCG = base.transform.Find("Content/Item List").GetComponent<CanvasGroup>();
				}
				contentCG.alpha = 1f;
				Canvas canvas = contentCG.gameObject.AddComponent<Canvas>();
				canvas.overrideSorting = true;
				canvas.sortingOrder = 30000;
				contentCG.gameObject.AddComponent<GraphicRaycaster>();
			}
		}

		private void OnEnable()
		{
			if (listCG == null)
			{
				listCG = base.gameObject.GetComponentInChildren<CanvasGroup>();
			}
			if (listRect == null)
			{
				listRect = listCG.GetComponent<RectTransform>();
			}
			if (updateOnEnable && index < items.Count)
			{
				SetDropdownIndex(selectedItemIndex);
			}
			if (contentCG != null)
			{
				contentCG.alpha = 1f;
			}
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			listCG.alpha = 0f;
			listCG.interactable = false;
			listCG.blocksRaycasts = false;
			listRect.sizeDelta = new Vector2(listRect.sizeDelta.x, 0f);
			isOn = false;
		}

		private void Update()
		{
			if (useGamepadInput && isOn && items.Count > 0 && ControllerManager.instance != null && EventSystem.current.currentSelectedGameObject.transform.parent != itemParent)
			{
				if (!startAtBottom)
				{
					ControllerManager.instance.SelectUIObject(itemParent.GetChild(0).gameObject);
				}
				else
				{
					ControllerManager.instance.SelectUIObject(itemParent.GetChild(items.Count - 1).gameObject);
				}
			}
		}

		public void Initialize()
		{
			if (items.Count == 0)
			{
				return;
			}
			if (!enableScrollbar && scrollbar != null)
			{
				UnityEngine.Object.Destroy(scrollbar);
			}
			if (itemList == null)
			{
				itemList = itemParent.GetComponent<VerticalLayoutGroup>();
			}
			UpdateItemLayout();
			index = 0;
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < items.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(itemPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(itemParent, worldPositionStays: false);
				gameObject.name = items[i].itemName;
				ButtonManager goBtn = gameObject.GetComponent<ButtonManager>();
				goBtn.buttonText = items[i].itemName;
				goBtn.bypassUpdateOnEnable = true;
				items[i].itemButton = goBtn;
				if (items[i].isInvisible)
				{
					gameObject.SetActive(value: false);
					continue;
				}
				LocalizedObject loc = goBtn.GetComponent<LocalizedObject>();
				if (string.IsNullOrEmpty(items[i].localizationKey) && loc != null)
				{
					UnityEngine.Object.Destroy(loc);
				}
				else if (!string.IsNullOrEmpty(items[i].localizationKey) && loc != null)
				{
					loc.localizationKey = items[i].localizationKey;
					loc.onLanguageChanged.AddListener(delegate
					{
						goBtn.buttonText = loc.GetKeyOutput(loc.localizationKey);
						goBtn.UpdateUI();
					});
					loc.InitializeItem();
					loc.UpdateItem();
				}
				if (items[i].itemIcon == null)
				{
					goBtn.enableIcon = false;
				}
				else
				{
					goBtn.enableIcon = true;
					goBtn.buttonIcon = items[i].itemIcon;
				}
				goBtn.UpdateUI();
				items[i].itemIndex = i;
				Item mainItem = items[i];
				goBtn.onClick.AddListener(Animate);
				goBtn.onClick.AddListener(items[index = mainItem.itemIndex].onItemSelection.Invoke);
				goBtn.onClick.AddListener(delegate
				{
					SetDropdownIndex(index = mainItem.itemIndex);
					onValueChanged.Invoke(index = mainItem.itemIndex);
					if (saveSelected)
					{
						PlayerPrefs.SetInt("Dropdown_" + saveKey, mainItem.itemIndex);
					}
				});
			}
			if (headerImage != null && !enableIcon)
			{
				headerImage.gameObject.SetActive(value: false);
			}
			else if (headerImage != null)
			{
				headerImage.sprite = items[selectedItemIndex].itemIcon;
			}
			if (headerText != null)
			{
				headerText.text = items[selectedItemIndex].itemName;
			}
			if (saveSelected)
			{
				if (invokeOnEnable)
				{
					items[PlayerPrefs.GetInt("Dropdown_" + saveKey)].onItemSelection.Invoke();
				}
				else
				{
					SetDropdownIndex(PlayerPrefs.GetInt("Dropdown_" + saveKey));
				}
			}
			else if (invokeOnEnable)
			{
				items[selectedItemIndex].onItemSelection.Invoke();
			}
		}

		public void SetDropdownIndex(int itemIndex)
		{
			selectedItemIndex = itemIndex;
			if (headerText != null)
			{
				headerText.text = items[itemIndex].itemButton.buttonText;
			}
			if (!items[itemIndex].isInvisible)
			{
				if (headerImage != null && enableIcon && items[itemIndex].itemButton.enableIcon)
				{
					headerImage.gameObject.SetActive(value: true);
					headerImage.sprite = items[itemIndex].itemButton.buttonIcon;
				}
				else if (headerImage != null && enableIcon && !items[itemIndex].itemButton.enableIcon)
				{
					headerImage.gameObject.SetActive(value: false);
				}
			}
		}

		public void Animate()
		{
			if (!isOn)
			{
				if (enableScrollbar && scrollbar != null && startAtBottom)
				{
					scrollbar.value = 0f;
				}
				isOn = true;
				listCG.blocksRaycasts = true;
				listCG.interactable = true;
				listCG.gameObject.SetActive(value: true);
				StopCoroutine("StartMinimize");
				StopCoroutine("StartExpand");
				StartCoroutine("StartExpand");
			}
			else if (isOn)
			{
				isOn = false;
				listCG.blocksRaycasts = false;
				listCG.interactable = false;
				StopCoroutine("StartMinimize");
				StopCoroutine("StartExpand");
				StartCoroutine("StartMinimize");
			}
			if (enableTrigger && triggerObject != null && !isOn)
			{
				triggerObject.SetActive(value: false);
			}
			else if (enableTrigger && triggerObject != null && isOn)
			{
				triggerObject.SetActive(value: true);
			}
			if (enableTrigger && outOnPointerExit && triggerObject != null)
			{
				triggerObject.SetActive(value: false);
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

		public void Interactable(bool value)
		{
			isInteractable = value;
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("SetNormal");
			}
		}

		public void CreateNewItem(string title, Sprite icon, bool notify)
		{
			Item item = new Item();
			item.itemName = title;
			item.itemIcon = icon;
			items.Add(item);
			if (notify)
			{
				Initialize();
			}
		}

		public void CreateNewItem(string title, bool notify)
		{
			Item item = new Item();
			item.itemName = title;
			items.Add(item);
			if (notify)
			{
				Initialize();
			}
		}

		public void CreateNewItem(string title)
		{
			Item item = new Item();
			item.itemName = title;
			items.Add(item);
			Initialize();
		}

		public void RemoveItem(string itemTitle, bool notify)
		{
			Item item = items.Find((Item x) => x.itemName == itemTitle);
			items.Remove(item);
			if (notify)
			{
				Initialize();
			}
		}

		public void RemoveItem(string itemTitle)
		{
			Item item = items.Find((Item x) => x.itemName == itemTitle);
			items.Remove(item);
			Initialize();
		}

		public void UpdateItemLayout()
		{
			if (!(itemList == null))
			{
				itemList.spacing = itemSpacing;
				itemList.padding.top = itemPaddingTop;
				itemList.padding.bottom = itemPaddingBottom;
				itemList.padding.left = itemPaddingLeft;
				itemList.padding.right = itemPaddingRight;
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
				Animate();
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
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (outOnPointerExit && isOn)
				{
					Animate();
				}
				StartCoroutine("SetNormal");
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
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetNormal");
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
			}
		}

		private IEnumerator StartExpand()
		{
			float elapsedTime = 0f;
			Vector2 startPos = listRect.sizeDelta;
			Vector2 endPos = new Vector2(listRect.sizeDelta.x, panelSize);
			while (listRect.sizeDelta.y <= panelSize - 0.1f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				listCG.alpha += Time.unscaledDeltaTime * (curveSpeed * 2f);
				listRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			listCG.alpha = 1f;
			listRect.sizeDelta = endPos;
		}

		private IEnumerator StartMinimize()
		{
			float elapsedTime = 0f;
			Vector2 startPos = listRect.sizeDelta;
			Vector2 endPos = new Vector2(listRect.sizeDelta.x, 0f);
			while (listRect.sizeDelta.y >= 0.1f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				listCG.alpha -= Time.unscaledDeltaTime * (curveSpeed * 2f);
				listRect.sizeDelta = Vector2.Lerp(startPos, endPos, animationCurve.Evaluate(elapsedTime * curveSpeed));
				yield return null;
			}
			listCG.alpha = 0f;
			listRect.sizeDelta = endPos;
			listCG.gameObject.SetActive(value: false);
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			while (highlightCG.alpha > 0.01f)
			{
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			while (highlightCG.alpha < 0.99f)
			{
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 1f;
		}
	}
}
