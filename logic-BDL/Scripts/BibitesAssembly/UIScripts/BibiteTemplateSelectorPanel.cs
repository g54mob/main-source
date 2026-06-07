using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SteamIntegrations;
using TMPro;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class BibiteTemplateSelectorPanel : UIPanel
	{
		public static BibiteTemplateSelectorPanel instance;

		[SerializeField]
		private GameObject panelToHide;

		[SerializeField]
		private BibiteEditorPanel bibiteEditorPanel;

		[SerializeField]
		private GameObject bibiteEditorButton;

		[SerializeField]
		private GameObject bibiteItemPrefab;

		[SerializeField]
		private Transform templatesHolder;

		[SerializeField]
		private Transform savedHolder;

		[SerializeField]
		private Button deleteTemplateButton;

		[SerializeField]
		private BibiteTemplateGenePreviewer previewer;

		[SerializeField]
		private GameObject toSubscribedWorkshopItemButton;

		[SerializeField]
		private GameObject toSharedWorkshopItemButton;

		[SerializeField]
		private GameObject shareOnWorkshopButton;

		[SerializeField]
		private List<GameObject> tabs;

		[SerializeField]
		private GameObject submitButton;

		[SerializeField]
		private TextMeshProUGUI submitButtonText;

		private string templateFolder;

		private string savedFolder;

		private BibiteItem selectedItem;

		private BibiteTemplate selectedBibite;

		public UnityEvent<BibiteTemplate> selectedBibiteChange = new UnityEvent<BibiteTemplate>();

		public UnityEvent<BibiteTemplate> onSubmitSelectedBibite = new UnityEvent<BibiteTemplate>();

		public UnityEvent onCancelSelection = new UnityEvent();

		public UnityAction<BibiteTemplate> onSubmitAction;

		public UnityAction onCancelAction;

		public ItemDictPool<string, BibiteItem> bibiteTemplates;

		public ItemDictPool<string, BibiteItem> bibiteSaves;

		private bool closePanelOnSubmit = true;

		private bool steamEnabled;

		protected override bool canBeEscapedFlag => !bibiteEditorPanel.gameObject.activeSelf;

		public override void InitPanel()
		{
			instance = this;
			bibiteTemplates = new ItemDictPool<string, BibiteItem>(bibiteItemPrefab, templatesHolder);
			bibiteSaves = new ItemDictPool<string, BibiteItem>(bibiteItemPrefab, savedHolder);
			templateFolder = SaveSystem.bibiteTemplatePath;
			savedFolder = SaveSystem.savedBibitePath;
			previewer.InitializePreview();
			using FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(savedFolder);
			fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
			fileSystemWatcher.Changed += OnFileChangedOrAdded;
			fileSystemWatcher.Created += OnFileChangedOrAdded;
			fileSystemWatcher.IncludeSubdirectories = true;
			fileSystemWatcher.EnableRaisingEvents = true;
			steamEnabled = SteamManager.Initialized;
			if (!steamEnabled)
			{
				toSharedWorkshopItemButton.SetActive(value: false);
				toSubscribedWorkshopItemButton.SetActive(value: false);
				shareOnWorkshopButton.SetActive(value: false);
			}
			if (bibiteEditorButton != null)
			{
				bibiteEditorButton.SetActive(bibiteEditorPanel != null);
			}
		}

		public override void OpenPanel()
		{
			if (panelToHide != null)
			{
				panelToHide.SetActive(value: false);
			}
			UserControl.SetKeyboardBlockFromSource("BibiteLibrary", block: true);
			if (TimeController.Instance != null)
			{
				TimeController.Instance.TogglePauseGame("BibiteLibrary");
			}
			base.OpenPanel();
			FillLists();
		}

		public void OpenWithCallBacks(UnityAction<BibiteTemplate> onSubmit, UnityAction onCancel = null, bool closeOnSubmit = true, string submitText = "Select Bibite")
		{
			onSubmitAction = onSubmit;
			onCancelAction = onCancel;
			closePanelOnSubmit = closeOnSubmit;
			submitButtonText.text = submitText;
			OpenPanel();
		}

		public void OpenWithoutGoals()
		{
			selectedBibite = null;
			OpenWithCallBacks(delegate
			{
				EditSelectedBibite();
			}, null, closeOnSubmit: false, "Edit Bibite");
		}

		public void OpenForBibiteEditor()
		{
			OpenWithCallBacks(delegate
			{
				EditSelectedBibite();
			}, null, closeOnSubmit: false, "Edit Bibite");
			selectedBibite = null;
			EditSelectedBibite();
		}

		public void OpenForBibiteEditor(BibiteTemplate bibiteToEdit)
		{
			OpenWithCallBacks(delegate
			{
				EditSelectedBibite();
			}, null, closeOnSubmit: false, "Edit Bibite");
			selectedBibite = bibiteToEdit;
			EditSelectedBibite();
		}

		public void OpenEditorForNewBibite()
		{
			bibiteEditorPanel.onClose.AddListener(AfterEditorClose);
			bibiteEditorPanel.EditTemplate(null);
		}

		public void EditSelectedBibite()
		{
			bibiteEditorPanel.EditTemplate(selectedBibite, AfterEditorSubmit);
			bibiteEditorPanel.onClose.AddListener(AfterEditorClose);
		}

		public void AfterEditorClose()
		{
			bibiteEditorPanel.onClose.RemoveListener(AfterEditorClose);
			BibiteItem item = selectedItem;
			FillLists();
			ItemClicked(item);
		}

		public void AfterEditorSubmit(BibiteTemplate template)
		{
			bibiteEditorPanel.onClose.RemoveListener(AfterEditorClose);
			FillLists();
			ItemClicked(bibiteTemplates.activeItems.FirstOrDefault((KeyValuePair<string, BibiteItem> t) => t.Value.template.name == template.name).Value);
		}

		public void CancelSelection()
		{
			onCancelAction?.Invoke();
			onCancelSelection.Invoke();
			ClosePanel();
		}

		public override void Escape()
		{
			CancelSelection();
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			UserControl.SetKeyboardBlockFromSource("BibiteLibrary", block: false);
			if (TimeController.Instance != null)
			{
				TimeController.Instance.TogglePauseGame("BibiteLibrary", isUnpause: true);
			}
			if (panelToHide != null)
			{
				panelToHide.SetActive(value: true);
			}
		}

		public void OpenTab(int i)
		{
			tabs.ForEach(delegate(GameObject g)
			{
				g.SetActive(value: false);
			});
			tabs[i].SetActive(value: true);
		}

		public void ItemClicked(BibiteItem item)
		{
			selectedItem = item;
			submitButton.SetActive(onSubmitAction != null);
			if (item == null)
			{
				selectedBibite = null;
				selectedBibiteChange.Invoke(selectedBibite);
				deleteTemplateButton.interactable = false;
				return;
			}
			selectedBibite = item.template;
			selectedBibiteChange.Invoke(selectedBibite);
			if (steamEnabled)
			{
				toSharedWorkshopItemButton.SetActive(item.isShared);
				toSubscribedWorkshopItemButton.SetActive(item.isExternal);
				shareOnWorkshopButton.SetActive(!item.isShared && !item.isExternal && !item.isOfficial);
			}
			deleteTemplateButton.interactable = !selectedBibite.isOfficial && !selectedBibite.isExternal;
		}

		public void GoToWorkshopPageOfSelectedItem()
		{
			if (!(selectedItem == null) && selectedItem.workshopItem != null && steamEnabled)
			{
				WorkshopItemsPanel.instance.OpenPanelWithItemSelected(selectedItem.workshopItem);
			}
		}

		public void ShareSelectedItemToWorkshop()
		{
			if (!(selectedItem == null) && steamEnabled)
			{
				SpriteGenerator.instance.SaveSpriteOfPreview(previewer, SteamWorkshopManager.tempImgPath, UserSettings.BackgroundColor.val, 1f, 10, 2);
				WorkshopItemsPanel.instance.ShareNewItemFromPath(selectedItem.template.fullPath);
			}
		}

		public void DeleteSelectedAction()
		{
			PopupManager.DisplayActionWarning(ActionWarnings.deleteBibiteFileActionWarning, DeleteSelected);
		}

		private void DeleteSelected()
		{
			if (selectedBibite.isOfficial)
			{
				return;
			}
			try
			{
				File.Delete(selectedBibite.fullPath);
				(selectedBibite.isTemplate ? bibiteTemplates : bibiteSaves).RetireItemWithKey(selectedBibite.filePath);
				ItemClicked((selectedBibite.isTemplate ? bibiteTemplates : bibiteSaves).activeItemsList.FirstOrDefault());
			}
			catch (Exception ex)
			{
				PopupManager.DisplayError("Error", "Couldn't delete template\n" + ex.Message);
			}
		}

		public void SubmitTemplate()
		{
			onSubmitSelectedBibite.Invoke(selectedBibite);
			onSubmitAction(selectedBibite);
			if (closePanelOnSubmit)
			{
				ClosePanel();
			}
		}

		public void OpenSaveFolder()
		{
			string text = savedFolder;
			Process.Start("explorer.exe", "/root," + text.Replace("/", "\\"));
		}

		public void FillLists(int panelFromSelectFirst = 0)
		{
			bibiteTemplates.RetireAll();
			string[] files = Directory.GetFiles(templateFolder, "*.bb8template");
			string[] files2 = Directory.GetFiles(savedFolder, "*.bb8");
			IEnumerable<string> enumerable = files.Concat(files2);
			bool flag = false;
			foreach (string item in enumerable)
			{
				BibiteItem bibiteItem = UpdateOrCreateItemForTemplate(item);
				if (!(bibiteItem == null))
				{
					bibiteItem.transform.SetAsLastSibling();
					if (!flag && panelFromSelectFirst == 0)
					{
						flag = true;
						ItemClicked(bibiteItem);
					}
				}
			}
			if (!SteamManager.Initialized || SteamWorkshopManager.instance.bibiteItems == null)
			{
				return;
			}
			foreach (WorkshopItem bibiteItem2 in SteamWorkshopManager.instance.bibiteItems)
			{
				UpdateOrCreateItemForTemplate(bibiteItem2.itemPath, bibiteItem2);
			}
		}

		public BibiteItem UpdateOrCreateItemForTemplate(string path, WorkshopItem external = null)
		{
			bool flag = Path.GetExtension(path) == ".bb8template";
			bool flag2 = external != null;
			string text = (flag2 ? path : path.Replace(flag ? templateFolder : savedFolder, ""));
			BibiteTemplate bibiteTemplate;
			try
			{
				bibiteTemplate = new BibiteTemplate(text, flag2);
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogException(ex);
				PopupManager.DisplayError("Bibite Parser: " + text, ex.Message);
				(flag ? bibiteTemplates : bibiteSaves).RetireItemWithKey(text);
				return null;
			}
			if (!bibiteTemplate.IsValid)
			{
				PopupManager.DisplayError("Bibite Parser: " + text, "This Bibite is from an unknown version and can't be loaded.");
				(flag ? bibiteTemplates : bibiteSaves).RetireItemWithKey(text);
				return null;
			}
			BibiteItem itemWithKey = (flag ? bibiteTemplates : bibiteSaves).GetItemWithKey(text);
			itemWithKey.InitializeItem(bibiteTemplate, ItemClicked, external);
			return itemWithKey;
		}

		private void OnFileChangedOrAdded(object sender, FileSystemEventArgs e)
		{
			BibiteItem bibiteItem = UpdateOrCreateItemForTemplate(e.FullPath);
			if (bibiteItem != null && bibiteItem == selectedItem)
			{
				ItemClicked(bibiteItem);
			}
		}
	}
}
