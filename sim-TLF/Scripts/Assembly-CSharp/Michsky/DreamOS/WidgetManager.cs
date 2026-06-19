using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class WidgetManager : MonoBehaviour
	{
		public enum DefaultWidgetState
		{
			Enabled = 0,
			Disabled = 1
		}

		[Serializable]
		public class WidgetItem
		{
			public string ID = "ID";

			public string title = "Title";

			[TextArea(2, 4)]
			public string description = "Description";

			public Sprite icon;

			public GameObject widgetPrefab;

			public DefaultWidgetState defaultState = DefaultWidgetState.Disabled;

			[HideInInspector]
			public WidgetPreset preset;

			[HideInInspector]
			public WidgetLibraryItem libraryItem;

			[Header("Localization")]
			public string titleKey;

			public string descriptionKey;
		}

		public List<WidgetItem> widgetItems = new List<WidgetItem>();

		[SerializeField]
		private GameObject libraryItem;

		[SerializeField]
		private Transform libraryParent;

		[SerializeField]
		private Transform widgetParent;

		[SerializeField]
		private bool useLocalization = true;

		private void Awake()
		{
			ListWidgets();
		}

		public void ListWidgets()
		{
			if (widgetItems.Count == 0 || widgetParent == null)
			{
				return;
			}
			foreach (Transform item in widgetParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in libraryParent)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			for (int i = 0; i < widgetItems.Count; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(widgetItems[i].widgetPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(widgetParent, worldPositionStays: false);
				obj.gameObject.name = widgetItems[i].title;
				WidgetPreset component = obj.GetComponent<WidgetPreset>();
				component.manager = this;
				component.index = i;
				component.ID = widgetItems[i].ID;
				component.defaultState = widgetItems[i].defaultState;
				widgetItems[i].preset = component;
				if (component.GetComponent<WindowDragger>() != null)
				{
					component.GetComponent<WindowDragger>().dragArea = widgetParent.GetComponent<RectTransform>();
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(libraryItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(libraryParent, worldPositionStays: false);
				gameObject.gameObject.name = widgetItems[i].title;
				WidgetLibraryItem tempLibPreset = gameObject.GetComponent<WidgetLibraryItem>();
				tempLibPreset.manager = this;
				tempLibPreset.widgetIndex = i;
				tempLibPreset.iconImage.sprite = widgetItems[i].icon;
				widgetItems[i].libraryItem = tempLibPreset;
				tempLibPreset.itemSwitch.onEvents.AddListener(delegate
				{
					EnableWidget(tempLibPreset.widgetIndex);
				});
				tempLibPreset.itemSwitch.offEvents.AddListener(delegate
				{
					DisableWidget(tempLibPreset.widgetIndex);
				});
				LocalizedObject tempTitleLoc = tempLibPreset.titleText.gameObject.GetComponent<LocalizedObject>();
				LocalizedObject tempDescLoc = tempLibPreset.descriptionText.gameObject.GetComponent<LocalizedObject>();
				if (!useLocalization || string.IsNullOrEmpty(widgetItems[i].titleKey) || tempTitleLoc == null || !tempTitleLoc.CheckLocalizationStatus())
				{
					tempLibPreset.titleText.text = widgetItems[i].title;
					tempLibPreset.descriptionText.text = widgetItems[i].description;
				}
				else if (tempTitleLoc != null)
				{
					tempTitleLoc.localizationKey = widgetItems[i].titleKey;
					tempTitleLoc.onLanguageChanged.AddListener(delegate
					{
						tempLibPreset.titleText.text = tempTitleLoc.GetKeyOutput(tempTitleLoc.localizationKey);
					});
					tempTitleLoc.InitializeItem();
					tempTitleLoc.UpdateItem();
					tempDescLoc.localizationKey = widgetItems[i].descriptionKey;
					tempDescLoc.onLanguageChanged.AddListener(delegate
					{
						tempLibPreset.descriptionText.text = tempDescLoc.GetKeyOutput(tempDescLoc.localizationKey);
					});
					tempDescLoc.InitializeItem();
					tempDescLoc.UpdateItem();
				}
				component.enabled = true;
			}
		}

		public void EnableWidget(int widgetIndex)
		{
			widgetItems[widgetIndex].preset.SetEnabled();
		}

		public void EnableWidget(string widgetID)
		{
			for (int i = 0; i < widgetItems.Count; i++)
			{
				if (widgetItems[i].ID == widgetID)
				{
					EnableWidget(widgetItems[i].preset.index);
					break;
				}
			}
		}

		public void DisableWidget(int widgetIndex)
		{
			widgetItems[widgetIndex].preset.SetDisabled();
		}

		public void DisableWidget(string widgetID)
		{
			for (int i = 0; i < widgetItems.Count; i++)
			{
				if (widgetItems[i].ID == widgetID)
				{
					DisableWidget(widgetItems[i].preset.index);
					break;
				}
			}
		}
	}
}
