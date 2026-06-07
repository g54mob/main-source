using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using UIScripts.SettingHandles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class DefaultBibitesPanel : MonoBehaviour
	{
		public static DefaultBibitesPanel instance;

		[SerializeField]
		private BibiteTemplateSelectorPanel bibiteTemplateSelectorPanel;

		[SerializeField]
		private GameObject bibiteItemPrefab;

		[SerializeField]
		private Transform bibiteItemsHolder;

		[SerializeField]
		private Button deleteAllButton;

		[NonSerialized]
		public List<BibiteSettingsHandle> bibiteItems = new List<BibiteSettingsHandle>();

		private BibiteTemplate selectedBibite;

		public UnityEvent<BibiteTemplate> selectedBibiteChange = new UnityEvent<BibiteTemplate>();

		private bool deleting;

		public List<BibiteTemplate> allTemplates => bibiteItems.Select((BibiteSettingsHandle i) => i.template).ToList();

		public void Awake()
		{
			instance = this;
			bibiteTemplateSelectorPanel.gameObject.SetActive(value: false);
			ScenarioSettings.onBibiteRemoved.AddListener(SettingsRemoved);
		}

		public void RefillPanel()
		{
			bibiteItems.ForEach(delegate(BibiteSettingsHandle p)
			{
				UnityEngine.Object.Destroy(p.gameObject);
			});
			bibiteItems.Clear();
			List<BibiteSettings> erroneousBibites = new List<BibiteSettings>();
			ScenarioSettings.Instance.bibites.ForEach(delegate(BibiteSettings z)
			{
				if (!BibiteTemplate.Exists(z.filePath, z.isExternal))
				{
					erroneousBibites.Add(z);
					PopupManager.DisplayError("Bibite Template", "Could not find " + z.filePath);
				}
				else
				{
					BibiteSettingsHandle component = UnityEngine.Object.Instantiate(bibiteItemPrefab, bibiteItemsHolder).GetComponent<BibiteSettingsHandle>();
					component.InitializeItem(z);
					component.onItemClicked.AddListener(ItemClicked);
					component.onItemDelete.AddListener(BibiteDeleted);
					bibiteItems.Add(component);
				}
			});
			erroneousBibites.ForEach(delegate(BibiteSettings b)
			{
				ScenarioSettings.Instance.bibites.Remove(b);
			});
			if (ScenarioSettings.Instance.bibites.Count > 0)
			{
				ItemClicked(bibiteItems[0]);
			}
			deleteAllButton.interactable = ScenarioSettings.Instance.bibites.Count > 0;
		}

		public void AddBibite(BibiteTemplate bibiteTemplate)
		{
			BibiteSettings bibiteSettings = new BibiteSettings
			{
				filePath = bibiteTemplate.filePath,
				isExternal = bibiteTemplate.isExternal
			};
			ScenarioSettings.Instance.AddNewBibite(bibiteSettings);
			BibiteSettingsHandle component = UnityEngine.Object.Instantiate(bibiteItemPrefab, bibiteItemsHolder).GetComponent<BibiteSettingsHandle>();
			component.InitializeItem(bibiteSettings, bibiteTemplate);
			component.onItemClicked.AddListener(ItemClicked);
			component.onItemDelete.AddListener(BibiteDeleted);
			bibiteItems.Add(component);
			ItemClicked(component);
			deleteAllButton.interactable = ScenarioSettings.Instance.bibites.Count > 0;
		}

		private void SettingsRemoved(BibiteSettings removed)
		{
			if (deleting)
			{
				return;
			}
			if (removed == null)
			{
				RefillPanel();
				return;
			}
			BibiteSettingsHandle bibiteSettingsHandle = bibiteItems.FirstOrDefault((BibiteSettingsHandle i) => i.settings == removed);
			if (bibiteSettingsHandle != null)
			{
				bibiteItems.Remove(bibiteSettingsHandle);
				UnityEngine.Object.Destroy(bibiteSettingsHandle.gameObject);
			}
		}

		public void AddBibiteButtonPressed()
		{
			bibiteTemplateSelectorPanel.OpenWithCallBacks(AddBibite);
		}

		public void DeleteAllBibites()
		{
			PopupManager.DisplayChoiceDialog("Delete All Default Bibites", "Are you sure you want to delete all default bibites? You will lose all data.", "Cancel", "YES", null, ActuallyDeleteAllBibites);
		}

		public void ActuallyDeleteAllBibites()
		{
			deleting = true;
			bibiteItems.ForEach(delegate(BibiteSettingsHandle i)
			{
				UnityEngine.Object.Destroy(i.gameObject);
			});
			bibiteItems.Clear();
			ScenarioSettings.Instance.RemoveAllBibites();
			RefillPanel();
			deleting = false;
		}

		private void ItemClicked(BibiteSettingsHandle settingsHandle)
		{
			bibiteItems.ForEach(delegate(BibiteSettingsHandle i)
			{
				i.CloseEditSection();
			});
			settingsHandle.SelectItem();
			selectedBibite = settingsHandle.template;
			selectedBibiteChange.Invoke(selectedBibite);
		}

		private void BibiteDeleted(BibiteSettingsHandle settingsHandle)
		{
			deleting = true;
			ScenarioSettings.Instance.RemoveBibite(settingsHandle.settings);
			bibiteItems.Remove(settingsHandle);
			deleting = false;
		}

		private void OnDestroy()
		{
			ScenarioSettings.onBibiteRemoved.RemoveListener(SettingsRemoved);
		}
	}
}
