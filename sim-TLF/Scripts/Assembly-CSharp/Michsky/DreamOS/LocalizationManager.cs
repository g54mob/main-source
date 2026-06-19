using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class LocalizationManager : MonoBehaviour
	{
		public static LocalizationManager instance;

		public UIManager UIManagerAsset;

		public List<HorizontalSelector> languageSelectors = new List<HorizontalSelector>();

		public bool setLanguageOnAwake = true;

		public bool updateItemsOnSet = true;

		public bool saveLanguageChanges = true;

		public static bool enableLogs = true;

		public string currentLanguage;

		public LocalizationLanguage currentLanguageAsset;

		public List<LocalizedObject> localizedItems = new List<LocalizedObject>();

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.System;

		private void Awake()
		{
			instance = this;
			if (UIManagerAsset == null)
			{
				UIManagerAsset = (UIManager)Resources.FindObjectsOfTypeAll(typeof(UIManager))[0];
			}
			if (UIManagerAsset == null || !UIManagerAsset.enableLocalization)
			{
				return;
			}
			if (setLanguageOnAwake)
			{
				InitializeLanguage();
			}
			foreach (HorizontalSelector languageSelector in languageSelectors)
			{
				if (languageSelector == null)
				{
					continue;
				}
				languageSelector.items.Clear();
				for (int i = 0; i < UIManagerAsset.localizationSettings.languages.Count; i++)
				{
					languageSelector.CreateNewItem(UIManagerAsset.localizationSettings.languages[i].localizedName);
					string tempID = UIManagerAsset.localizationSettings.languages[i].languageID;
					languageSelector.items[i].onItemSelect.AddListener(delegate
					{
						SetLanguage(tempID);
					});
					if (UIManagerAsset.localizationSettings.languages[i].localizationLanguage == currentLanguageAsset)
					{
						languageSelector.index = i;
						languageSelector.defaultIndex = i;
					}
				}
				languageSelector.UpdateUI();
			}
		}

		public void InitializeLanguage()
		{
			if (DreamOSDataManager.ContainsJsonKey(dataCat, "Language"))
			{
				currentLanguage = DreamOSDataManager.ReadStringData(dataCat, "Language");
			}
			else
			{
				currentLanguage = UIManagerAsset.localizationSettings.defaultLanguageID;
			}
			SetLanguage(currentLanguage);
		}

		public void SetLanguageByIndex(int index)
		{
			SetLanguage(UIManagerAsset.localizationSettings.languages[index].languageID);
		}

		public void SetLanguage(string langID)
		{
			if (UIManagerAsset == null || !UIManagerAsset.enableLocalization)
			{
				UIManager.isLocalizationEnabled = false;
				return;
			}
			currentLanguageAsset = null;
			for (int i = 0; i < UIManagerAsset.localizationSettings.languages.Count; i++)
			{
				if (UIManagerAsset.localizationSettings.languages[i].languageID == langID)
				{
					currentLanguageAsset = UIManagerAsset.localizationSettings.languages[i].localizationLanguage;
					break;
				}
				if (UIManagerAsset.localizationSettings.languages[i].languageName + " (" + UIManagerAsset.localizationSettings.languages[i].languageID + ")" == langID)
				{
					currentLanguageAsset = UIManagerAsset.localizationSettings.languages[i].localizationLanguage;
					break;
				}
				if (UIManagerAsset.localizationSettings.languages[i].languageName == langID + ")")
				{
					currentLanguageAsset = UIManagerAsset.localizationSettings.languages[i].localizationLanguage;
					break;
				}
			}
			if (currentLanguageAsset == null)
			{
				Debug.Log("<b>[Localization Manager]</b> No language named <b>" + langID + "</b> found.", this);
				return;
			}
			currentLanguage = currentLanguageAsset.languageName + " (" + currentLanguageAsset.languageID + ")";
			if (updateItemsOnSet)
			{
				for (int j = 0; j < localizedItems.Count; j++)
				{
					if (localizedItems[j] == null)
					{
						localizedItems.RemoveAt(j);
					}
					else if (localizedItems[j].gameObject.activeInHierarchy && localizedItems[j].updateMode != LocalizedObject.UpdateMode.OnDemand)
					{
						localizedItems[j].UpdateItem();
					}
				}
			}
			if (saveLanguageChanges)
			{
				DreamOSDataManager.WriteStringData(dataCat, "Language", currentLanguageAsset.languageID);
			}
			UIManagerAsset.currentLanguage = currentLanguageAsset;
			UIManager.isLocalizationEnabled = true;
		}

		public static void SetLanguageWithoutNotify(string langID)
		{
			DreamOSDataManager.WriteStringData(DreamOSDataManager.DataCategory.System, "Language", langID);
		}
	}
}
