using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	public class HorizontalSelector : MonoBehaviour
	{
		[Serializable]
		public class Item
		{
			public string itemTitle = "Item Title";

			public string localizationKey;

			public Sprite itemIcon;

			public UnityEvent onItemSelect = new UnityEvent();
		}

		[Serializable]
		public class HorizontalSelectorEvent : UnityEvent<int>
		{
		}

		public TextMeshProUGUI label;

		[SerializeField]
		private TextMeshProUGUI labelHelper;

		public Image labelIcon;

		[SerializeField]
		private Image labelIconHelper;

		public Transform indicatorParent;

		public GameObject indicatorObject;

		[SerializeField]
		private Animator selectorAnimator;

		[SerializeField]
		private HorizontalLayoutGroup contentLayout;

		[SerializeField]
		private HorizontalLayoutGroup contentLayoutHelper;

		private string newItemTitle;

		public bool saveSelected;

		public string saveKey = "Horizontal Selector";

		public bool enableIndicator = true;

		public bool enableIcon;

		public bool invokeOnAwake = true;

		public bool invertAnimation;

		public bool loopSelection;

		public bool useLocalization = true;

		[Range(0.25f, 2.5f)]
		public float iconScale = 1f;

		[Range(1f, 50f)]
		public int contentSpacing = 15;

		public int defaultIndex;

		[HideInInspector]
		public int index;

		public List<Item> items = new List<Item>();

		public HorizontalSelectorEvent onValueChanged = new HorizontalSelectorEvent();

		private LocalizedObject localizedObject;

		private float cachedStateLength;

		private void Awake()
		{
			if (selectorAnimator == null)
			{
				selectorAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (label == null || labelHelper == null)
			{
				Debug.LogError("<b>[Horizontal Selector]</b> Cannot initalize the object due to missing resources.", this);
				return;
			}
			InitializeSelector();
			UpdateContentLayout();
			if (invokeOnAwake)
			{
				items[index].onItemSelect.Invoke();
				onValueChanged.Invoke(index);
			}
			cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(selectorAnimator, "HorizontalSelector_Next");
		}

		private void OnEnable()
		{
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("DisableAnimator");
			}
			if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey) && localizedObject.CheckLocalizationStatus())
			{
				label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
			}
		}

		public void InitializeSelector()
		{
			if (items.Count == 0)
			{
				return;
			}
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				string key = "HorizontalSelector_" + saveKey;
				if (Singleton<SettingsSaveManager>.Instance.HasSetting(key))
				{
					defaultIndex = Singleton<SettingsSaveManager>.Instance.LoadSetting(key, defaultIndex);
				}
			}
			index = defaultIndex;
			label.text = items[index].itemTitle;
			labelHelper.text = label.text;
			if (labelIcon != null && enableIcon)
			{
				labelIcon.sprite = items[index].itemIcon;
				labelIconHelper.sprite = labelIcon.sprite;
			}
			else if (!enableIcon)
			{
				if (labelIcon != null)
				{
					labelIcon.gameObject.SetActive(value: false);
				}
				if (labelIconHelper != null)
				{
					labelIconHelper.gameObject.SetActive(value: false);
				}
			}
			if (enableIndicator)
			{
				UpdateIndicators();
			}
			else
			{
				UnityEngine.Object.Destroy(indicatorParent.gameObject);
			}
			if (!useLocalization)
			{
				return;
			}
			localizedObject = base.gameObject.GetComponent<LocalizedObject>();
			if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
			{
				useLocalization = false;
			}
			else if (useLocalization)
			{
				localizedObject.onLanguageChanged.AddListener(delegate
				{
					UpdateUI();
				});
			}
		}

		public void PreviousItem()
		{
			if (items.Count == 0)
			{
				return;
			}
			StopCoroutine("DisableAnimator");
			selectorAnimator.enabled = true;
			if (!loopSelection)
			{
				if (index != 0)
				{
					labelHelper.text = label.text;
					if (labelIcon != null && enableIcon)
					{
						labelIconHelper.sprite = labelIcon.sprite;
					}
					if (index == 0)
					{
						index = items.Count - 1;
					}
					else
					{
						index--;
					}
					if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey))
					{
						label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
					}
					else
					{
						label.text = items[index].itemTitle;
					}
					if (labelIcon != null && enableIcon)
					{
						labelIcon.sprite = items[index].itemIcon;
					}
					items[index].onItemSelect.Invoke();
					onValueChanged.Invoke(index);
					selectorAnimator.Play(null);
					selectorAnimator.StopPlayback();
					if (invertAnimation)
					{
						selectorAnimator.Play("Next");
					}
					else
					{
						selectorAnimator.Play("Prev");
					}
				}
			}
			else
			{
				labelHelper.text = label.text;
				if (labelIcon != null && enableIcon)
				{
					labelIconHelper.sprite = labelIcon.sprite;
				}
				if (index == 0)
				{
					index = items.Count - 1;
				}
				else
				{
					index--;
				}
				if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey))
				{
					label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
				}
				else
				{
					label.text = items[index].itemTitle;
				}
				if (labelIcon != null && enableIcon)
				{
					labelIcon.sprite = items[index].itemIcon;
				}
				items[index].onItemSelect.Invoke();
				onValueChanged.Invoke(index);
				selectorAnimator.Play(null);
				selectorAnimator.StopPlayback();
				if (invertAnimation)
				{
					selectorAnimator.Play("Next");
				}
				else
				{
					selectorAnimator.Play("Prev");
				}
			}
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("HorizontalSelector_" + saveKey, index);
			}
			if (enableIndicator)
			{
				for (int i = 0; i < items.Count; i++)
				{
					GameObject obj = indicatorParent.GetChild(i).gameObject;
					Transform transform = obj.transform.Find("On");
					Transform transform2 = obj.transform.Find("Off");
					if (i == index)
					{
						transform.gameObject.SetActive(value: true);
						transform2.gameObject.SetActive(value: false);
					}
					else
					{
						transform.gameObject.SetActive(value: false);
						transform2.gameObject.SetActive(value: true);
					}
				}
			}
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("DisableAnimator");
			}
		}

		public void NextItem()
		{
			if (items.Count == 0)
			{
				return;
			}
			StopCoroutine("DisableAnimator");
			selectorAnimator.enabled = true;
			if (!loopSelection)
			{
				if (index != items.Count - 1)
				{
					labelHelper.text = label.text;
					if (labelIcon != null && enableIcon)
					{
						labelIconHelper.sprite = labelIcon.sprite;
					}
					if (index + 1 >= items.Count)
					{
						index = 0;
					}
					else
					{
						index++;
					}
					if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey))
					{
						label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
					}
					else
					{
						label.text = items[index].itemTitle;
					}
					if (labelIcon != null && enableIcon)
					{
						labelIcon.sprite = items[index].itemIcon;
					}
					items[index].onItemSelect.Invoke();
					onValueChanged.Invoke(index);
					selectorAnimator.Play(null);
					selectorAnimator.StopPlayback();
					if (invertAnimation)
					{
						selectorAnimator.Play("Prev");
					}
					else
					{
						selectorAnimator.Play("Next");
					}
				}
			}
			else
			{
				labelHelper.text = label.text;
				if (labelIcon != null && enableIcon)
				{
					labelIconHelper.sprite = labelIcon.sprite;
				}
				if (index + 1 >= items.Count)
				{
					index = 0;
				}
				else
				{
					index++;
				}
				if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey))
				{
					label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
				}
				else
				{
					label.text = items[index].itemTitle;
				}
				if (labelIcon != null && enableIcon)
				{
					labelIcon.sprite = items[index].itemIcon;
				}
				items[index].onItemSelect.Invoke();
				onValueChanged.Invoke(index);
				selectorAnimator.Play(null);
				selectorAnimator.StopPlayback();
				if (invertAnimation)
				{
					selectorAnimator.Play("Prev");
				}
				else
				{
					selectorAnimator.Play("Next");
				}
			}
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("HorizontalSelector_" + saveKey, index);
			}
			if (enableIndicator)
			{
				for (int i = 0; i < items.Count; i++)
				{
					GameObject obj = indicatorParent.GetChild(i).gameObject;
					Transform transform = obj.transform.Find("On");
					Transform transform2 = obj.transform.Find("Off");
					if (i == index)
					{
						transform.gameObject.SetActive(value: true);
						transform2.gameObject.SetActive(value: false);
					}
					else
					{
						transform.gameObject.SetActive(value: false);
						transform2.gameObject.SetActive(value: true);
					}
				}
			}
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("DisableAnimator");
			}
		}

		public void UpdateUI()
		{
			selectorAnimator.enabled = true;
			if (useLocalization && !string.IsNullOrEmpty(items[index].localizationKey))
			{
				label.text = localizedObject.GetKeyOutput(items[index].localizationKey);
			}
			else
			{
				label.text = items[index].itemTitle;
			}
			if (labelIcon != null && enableIcon)
			{
				labelIcon.sprite = items[index].itemIcon;
			}
			UpdateContentLayout();
			UpdateIndicators();
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine("DisableAnimator");
			}
		}

		public void UpdateIndicators()
		{
			if (!enableIndicator)
			{
				return;
			}
			foreach (Transform item in indicatorParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < items.Count; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(indicatorObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(indicatorParent, worldPositionStays: false);
				obj.name = items[i].itemTitle;
				Transform transform = obj.transform.Find("On");
				Transform transform2 = obj.transform.Find("Off");
				if (i == index)
				{
					transform.gameObject.SetActive(value: true);
					transform2.gameObject.SetActive(value: false);
				}
				else
				{
					transform.gameObject.SetActive(value: false);
					transform2.gameObject.SetActive(value: true);
				}
			}
		}

		public void UpdateContentLayout()
		{
			if (contentLayout != null)
			{
				contentLayout.spacing = contentSpacing;
			}
			if (contentLayoutHelper != null)
			{
				contentLayoutHelper.spacing = contentSpacing;
			}
			if (labelIcon != null)
			{
				labelIcon.transform.localScale = new Vector3(iconScale, iconScale, iconScale);
				labelIconHelper.transform.localScale = new Vector3(iconScale, iconScale, iconScale);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(label.transform.parent.GetComponent<RectTransform>());
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedStateLength + 0.1f);
			selectorAnimator.enabled = false;
		}

		public void CreateNewItem(string title)
		{
			Item item = new Item();
			newItemTitle = title;
			item.itemTitle = newItemTitle;
			items.Add(item);
		}

		public void RemoveItem(string itemTitle)
		{
			Item item = items.Find((Item x) => x.itemTitle == itemTitle);
			items.Remove(item);
			InitializeSelector();
		}

		public void AddNewItem()
		{
			Item item = new Item();
			items.Add(item);
		}
	}
}
