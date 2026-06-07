using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ManagementScripts;
using OneUseScripts;
using SettingScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class SaveGamePanel : UIPanel, IUsingSaveItem
	{
		[NonSerialized]
		public static SaveGamePanel Instance;

		[SerializeField]
		private GameObject saveItemPrefab;

		[SerializeField]
		private Transform savesHolder;

		[SerializeField]
		private RawImage preview;

		[SerializeField]
		private TMP_InputField saveName;

		[SerializeField]
		private TextMeshProUGUI simTime;

		[SerializeField]
		private FloatValueTextHandle simSize;

		[SerializeField]
		private TextMeshProUGUI nBibites;

		[SerializeField]
		private TextMeshProUGUI nPellets;

		[SerializeField]
		private GameObject existIndicator;

		[SerializeField]
		private Button saveButton;

		[SerializeField]
		private Toggle includeTemplatesToggle;

		private ItemPool<SaveItemReference> saveItems;

		private readonly Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");

		private FileInfo selectedSaveInfo;

		private SaveItemReference selectedSaveItem;

		private Texture2D tex;

		public override void InitPanel()
		{
			Instance = this;
			tex = new Texture2D(400, 400, TextureFormat.RGB24, mipChain: false);
			preview.texture = tex;
			saveItems = new ItemPool<SaveItemReference>(saveItemPrefab, savesHolder);
			saveName.onValueChanged.AddListener(delegate
			{
				OnSaveNameChanged();
			});
		}

		public override void OpenPanel()
		{
			if (!base.isActiveAndEnabled)
			{
				base.OpenPanel();
				TimeController.Instance?.TogglePauseGame("SavePanel");
				UserControl.AllowControl = false;
				FillList();
				int[] array = TimeKeeper.ParseTime(TimeKeeper.simulatedTime);
				simTime.text = $"{array[0]:00}:{array[1]:00}:{array[2]:00}";
				simSize.UpdateValue(ScenarioIndependentSettings.Instance.SimulationSize.val);
				nBibites.text = InformationPanel.Instance.bibiteNumber.ToString();
				nPellets.text = InformationPanel.Instance.pelletNumber.ToString();
				SceneScreenShotHandler.instance.SaveScreenshotToImage(tex);
				saveName.text = "";
				saveButton.interactable = false;
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			ReleaseRestrictions();
		}

		private void ReleaseRestrictions()
		{
			TimeController.Instance?.TogglePauseGame("SavePanel", isUnpause: true);
			UserControl.AllowControl = true;
		}

		public void FillList()
		{
			saveItems.RetireAll();
			string[] saves = SaveController.GetSaves();
			foreach (string fileName in saves)
			{
				SaveItemReference itemFromPool = saveItems.GetItemFromPool();
				FileInfo fileInfo = new FileInfo(fileName);
				try
				{
					itemFromPool.InitSaveItem(fileInfo, this);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					PopupManager.DisplayError("Corrupted Save", "A corrupted save was found and couldn't ne displayed:\n" + fileInfo.FullName + "\nDelete the file to stop this problem, or even better: Share it with the dev team\n\n" + string.Join("\n", ex.ToString().Split("\n").Take(1)));
					itemFromPool.ReturnToPool();
				}
			}
			OnSaveNameChanged();
		}

		public void SelectSaveItem(SaveItemReference item)
		{
			selectedSaveItem = item;
			if (!(selectedSaveItem == null))
			{
				selectedSaveInfo = item.info;
				saveName.text = Path.GetFileNameWithoutExtension(selectedSaveInfo.Name);
				OnSaveNameChanged();
			}
		}

		public void OnSaveNameChanged()
		{
			string text = saveName.text;
			saveButton.interactable = !containsABadCharacter.IsMatch(text) && !string.IsNullOrEmpty(text);
			string path = SaveController.SavePath + text + ".zip";
			existIndicator.SetActive(File.Exists(path));
		}

		public void Save()
		{
			SaveSystem.includeTemplates = true;
			SaveController.Instance.SaveWorld(Path.Combine(SaveController.SavePath, saveName.text + ".zip"));
			ClosePanel();
		}

		public void AskOverwritePreviousSave()
		{
			if (File.Exists(Path.Combine(SaveController.SavePath, saveName.text + ".zip")))
			{
				PopupManager.DisplayChoiceDialog("Are you SURE???", "You are about to delete a previous save file, are you sure you want to do this?", "Cancel", "OK", null, Save);
			}
			else
			{
				Save();
			}
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
	}
}
