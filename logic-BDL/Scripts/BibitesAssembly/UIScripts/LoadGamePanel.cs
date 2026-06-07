using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SteamIntegrations;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class LoadGamePanel : UIPanel, IUsingSaveItem
	{
		[NonSerialized]
		public static LoadGamePanel Instance;

		[SerializeField]
		private Toggle includeAutoSaves;

		[SerializeField]
		private GameObject saveItemPrefab;

		[SerializeField]
		private Transform savesHolder;

		[SerializeField]
		private RawImage preview;

		[SerializeField]
		private Texture defaultPreview;

		[SerializeField]
		private GameObject noPreviewDisclaimer;

		[SerializeField]
		private GameObject saveInfoContainer;

		[SerializeField]
		private TextMeshProUGUI saveName;

		[SerializeField]
		private TextMeshProUGUI saveDate;

		[SerializeField]
		private TextMeshProUGUI saveVersion;

		[SerializeField]
		private GameObject incompatibleVersionIndicator;

		[SerializeField]
		private GameObject unknownVersionIndicator;

		[SerializeField]
		private GameObject compatibleVersionIndicator;

		[SerializeField]
		private TextMeshProUGUI simTime;

		[SerializeField]
		private FloatValueTextHandle simSize;

		[SerializeField]
		private TextMeshProUGUI nBibites;

		[SerializeField]
		private TextMeshProUGUI nPellets;

		[SerializeField]
		private Button loadButton;

		private ItemPool<SaveItemReference> saveItems;

		private FileInfo selectedSaveInfo;

		private SaveItemReference selectedSaveItem;

		private Texture2D tex;

		public override void InitPanel()
		{
			Instance = this;
			tex = new Texture2D(400, 400);
			includeAutoSaves.isOn = UserSettings.IncludeAutoSavesInLoadPanel.val;
			includeAutoSaves.onValueChanged.AddListener(UserSettings.IncludeAutoSavesInLoadPanel.SetValue);
			includeAutoSaves.onValueChanged.AddListener(FillList);
			saveItems = new ItemPool<SaveItemReference>(saveItemPrefab, savesHolder);
			preview.texture = tex;
			noPreviewDisclaimer.SetActive(value: false);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			TimeController.Instance?.TogglePauseGame("LoadPanel");
			UserControl.AllowControl = false;
			if (tex != null)
			{
				FillList(UserSettings.IncludeAutoSavesInLoadPanel.val);
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			ReleaseRestrictions();
		}

		private void ReleaseRestrictions()
		{
			TimeController.Instance?.TogglePauseGame("LoadPanel", isUnpause: true);
			UserControl.AllowControl = true;
		}

		public void FillList(bool includeAutoSave)
		{
			saveItems.RetireAll();
			string[] saves = SaveController.GetSaves(includeAutoSave);
			foreach (string path in saves)
			{
				CreateItemForPath(path);
			}
			SaveItemReference saveItemReference = saveItems[0];
			if (SteamManager.Initialized && SteamWorkshopManager.instance.saveItems != null)
			{
				foreach (WorkshopItem saveItem in SteamWorkshopManager.instance.saveItems)
				{
					SaveItemReference saveItemReference2 = CreateItemForPath(saveItem.itemPath, saveItem);
					if (saveItemReference2 != null)
					{
						saveItemReference2.transform.SetAsFirstSibling();
					}
				}
				if (saveItemReference != null)
				{
					saveItemReference.transform.SetAsFirstSibling();
				}
			}
			SelectSaveItem((saveItems.activeCount < 1) ? null : saveItems[0]);
		}

		public SaveItemReference CreateItemForPath(string path, WorkshopItem item = null)
		{
			SaveItemReference itemFromPool = saveItems.GetItemFromPool();
			FileInfo file = new FileInfo(path);
			if ((item == null) ? itemFromPool.InitSaveItem(file, this) : itemFromPool.InitSaveItemAsExternal(file, this, item))
			{
				return itemFromPool;
			}
			itemFromPool.ReturnToPool();
			return null;
		}

		public void SelectSaveItem(SaveItemReference item)
		{
			selectedSaveItem = item;
			saveInfoContainer.SetActive(selectedSaveItem != null);
			if (selectedSaveItem == null)
			{
				return;
			}
			selectedSaveInfo = item.info;
			saveName.text = Path.GetFileNameWithoutExtension(selectedSaveInfo.Name);
			saveDate.text = selectedSaveInfo.LastWriteTime.ToString("dd/MM/yyyy HH:mm");
			using ZipArchive zipArchive = ZipFile.Open(selectedSaveInfo.FullName, ZipArchiveMode.Read);
			ZipArchiveEntry entry = zipArchive.GetEntry("img.png");
			if (entry != null)
			{
				byte[] data = SaveSystem.ReadFileFromArchive(entry);
				preview.texture = tex;
				tex.LoadImage(data);
				noPreviewDisclaimer.SetActive(value: false);
			}
			else
			{
				preview.texture = defaultPreview;
				noPreviewDisclaimer.SetActive(value: true);
			}
			JObject sceneOfSave = SaveSystem.GetSceneOfSave(zipArchive);
			JObject settingsOfSave = SaveSystem.GetSettingsOfSave(zipArchive);
			Utility.Version versionOfFile = SaveSystem.GetVersionOfFile(sceneOfSave);
			saveVersion.text = versionOfFile.ToString();
			saveVersion.gameObject.SetActive(value: true);
			if (versionOfFile == Utility.Version.Null)
			{
				loadButton.interactable = false;
				saveVersion.gameObject.SetActive(value: false);
				incompatibleVersionIndicator.SetActive(value: false);
				compatibleVersionIndicator.SetActive(value: false);
				unknownVersionIndicator.SetActive(value: true);
			}
			else if (!VersionTracker.CanUpdateFromVersion(versionOfFile))
			{
				loadButton.interactable = false;
				compatibleVersionIndicator.SetActive(value: false);
				unknownVersionIndicator.SetActive(value: false);
				incompatibleVersionIndicator.SetActive(value: true);
			}
			else
			{
				loadButton.interactable = true;
				unknownVersionIndicator.SetActive(value: false);
				incompatibleVersionIndicator.SetActive(value: false);
				compatibleVersionIndicator.SetActive(VersionTracker.ChangesSinceVersion(versionOfFile));
			}
			int[] array = TimeKeeper.ParseTime(SaveSystem.GetTimeOfScene(sceneOfSave));
			simTime.text = $"{array[0]:00}:{array[1]:00}:{array[2]:00}";
			JToken jToken = settingsOfSave["SimulationSize"] ?? settingsOfSave["independents"]["SimulationSize"];
			simSize.UpdateValue((jToken == null) ? 0f : ((float)jToken["Value"]));
			nBibites.text = (sceneOfSave["nBibites"] ?? ((JToken)"?")).ToString();
			nPellets.text = (sceneOfSave["nPellets"] ?? ((JToken)(sceneOfSave["pellets"]?.Count() ?? 0))).ToString();
		}

		public void LoadSelectedSave()
		{
			ReleaseRestrictions();
			GameManager.StartGame(selectedSaveInfo.FullName);
		}

		public void AskDeleteSelectedSave()
		{
			PopupManager.DisplayActionWarning(ActionWarnings.deleteSaveFileActionWarning, DeleteSelectedSave);
		}

		private void DeleteSelectedSave()
		{
			int a = saveItems.activeItems.IndexOf(selectedSaveItem);
			saveItems.ReturnItem(selectedSaveItem);
			File.Delete(selectedSaveInfo.FullName);
			a = Mathf.Min(a, saveItems.activeCount - 1);
			SelectSaveItem((a >= 0) ? saveItems.activeItems[a] : null);
		}

		public void OpenSaveFolder()
		{
			string savePath = SaveController.SavePath;
			Process.Start("explorer.exe", "/root," + savePath.Replace("/", "\\"));
		}
	}
}
