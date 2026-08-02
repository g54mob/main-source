using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class LocalizationManager : MonoBehaviour
	{
		public static LocalizationManager instance;

		public UIManager UIManagerAsset;

		public HorizontalSelector languageSelector;

		public bool setLanguageOnAwake = true;

		public bool updateItemsOnSet = true;

		public bool saveLanguageChanges = true;

		public static bool enableLogs = true;

		public string currentLanguage;

		public LocalizationLanguage currentLanguageAsset;

		public List<LocalizedObject> localizedItems = new List<LocalizedObject>();

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
			if (!(languageSelector != null))
			{
				return;
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

		public void InitializeLanguage()
		{
			if (PlayerPrefs.HasKey(UIManager.localizationSaveKey))
			{
				currentLanguage = PlayerPrefs.GetString(UIManager.localizationSaveKey);
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
				PlayerPrefs.SetString(UIManager.localizationSaveKey, currentLanguageAsset.languageID);
			}
			UIManagerAsset.currentLanguage = currentLanguageAsset;
			UIManager.isLocalizationEnabled = true;
		}

		public static void SetLanguageWithoutNotify(string langID)
		{
			PlayerPrefs.SetString(UIManager.localizationSaveKey, langID);
		}
	}
}
