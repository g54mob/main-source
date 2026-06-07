using System;
using System.IO;
using System.IO.Compression;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using StandaloneFileBrowser;
using Steamworks;
using TMPro;
using UIScripts;
using UIScripts.InfoHandles;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace SteamIntegrations
{
	public class EditSharedItemPanel : UIPanel
	{
		[SerializeField]
		private TMP_InputField titleField;

		[SerializeField]
		private TMP_InputField descField;

		[SerializeField]
		private TMP_InputField changelogField;

		[SerializeField]
		private TextMeshProUGUI pathText;

		[SerializeField]
		private TextMeshProUGUI typeText;

		[SerializeField]
		private Image typeIcon;

		[SerializeField]
		private TextMeshProUGUI versionText;

		[SerializeField]
		private TextMeshProUGUI lastFilePull;

		[SerializeField]
		private GameObject updateFileCheckmark;

		[SerializeField]
		private GameObject lastUpdateSection;

		[SerializeField]
		private TextMeshProUGUI lastUpdated;

		[SerializeField]
		private TooltipTrigger lastChangelogTooltip;

		[SerializeField]
		private Button submitButton1;

		[SerializeField]
		private GameObject deleteItemButton;

		[SerializeField]
		private GameObject submitPopup;

		[SerializeField]
		private GameObject closeSubmitPanelButton;

		[SerializeField]
		private Button submitButton2;

		[SerializeField]
		private ValueSliderHandle submitBar;

		[SerializeField]
		private GameObject publishSuccessPopup;

		[SerializeField]
		private RawImage preview;

		[SerializeField]
		private Texture defaultPreview;

		[SerializeField]
		private GameObject noPreviewDisclaimer;

		[SerializeField]
		private GameObject titleErrorDisclaimer;

		[SerializeField]
		private GameObject descErrorDisclaimer;

		[SerializeField]
		private GameObject changelogErrorDisclaimer;

		[SerializeField]
		private SettingDropdownReference visibilityDropdownRef;

		private ChoiceSettingDropdown<ChoiceSetting<ERemoteStoragePublishedFileVisibility>, ERemoteStoragePublishedFileVisibility> visibilityDropdown;

		private ChoiceSetting<ERemoteStoragePublishedFileVisibility> visibility = new ChoiceSetting<ERemoteStoragePublishedFileVisibility>(WorkshopItem.visibilityChoices)
		{
			Name = "Visibility"
		};

		private bool otherPanelOpen;

		private WorkshopItem item;

		private string sourcePath;

		private bool updateFile;

		private bool updatePreview;

		private SteamWorkshopManager manager;

		private string tempFilePath;

		private DateTime tempPullTime;

		private Texture2D tex;

		private float progress;

		private bool submitting;

		private bool submittedSuccess;

		private bool isNew;

		protected override bool canBeEscapedFlag => !otherPanelOpen;

		private string tempPreviewPath => Path.Combine(SteamWorkshopManager.workshopSharingPath, "preview.png");

		public override void InitPanel()
		{
			visibilityDropdown = new ChoiceSettingDropdown<ChoiceSetting<ERemoteStoragePublishedFileVisibility>, ERemoteStoragePublishedFileVisibility>(visibility, visibilityDropdownRef);
			manager = SteamWorkshopManager.instance;
			tex = new Texture2D(400, 400);
			titleField.onValueChanged.AddListener(delegate
			{
				CheckCanBeSubmitted();
			});
			descField.onValueChanged.AddListener(delegate
			{
				CheckCanBeSubmitted();
			});
			changelogField.onValueChanged.AddListener(OnChangeLogUpdate);
			manager.onWorkshopItemSubmitResult.AddListener(OnItemSubmitResult);
			manager.onWorkshopItemDestroyed.AddListener(OnItemDeleted);
		}

		public void OpenForItem(WorkshopItem itemRef, bool isNewItem)
		{
			OpenPanel();
			item = itemRef;
			isNew = isNewItem;
			updateFile = false;
			updatePreview = false;
			titleField.text = item.title;
			descField.text = item.desc;
			sourcePath = manager.SourceFileOfItem(item.id);
			pathText.text = sourcePath.Replace(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), "~");
			typeText.text = item.type.ToString();
			typeIcon.sprite = manager.GetSpriteOfType(item.type);
			versionText.text = item.version;
			lastFilePull.text = item.lastFilePull.ToString("yyyy-MM dd HH:mm:ss");
			lastUpdated.text = item.lastUpdated.ToString("yyyy-MM dd HH:mm:ss");
			lastChangelogTooltip.UpdateText("Last Changelog:", item.lastChangelog ?? "no notes left :(");
			visibility.SetValue(item.visibility.val);
			bool flag = item.LoadPreviewToTex(tex);
			if (flag)
			{
				preview.FitTexture(tex, FitType.Fill);
			}
			else
			{
				preview.texture = defaultPreview;
			}
			noPreviewDisclaimer.SetActive(!flag);
			changelogField.text = (isNew ? "Initial Publish" : "");
			deleteItemButton.SetActive(!isNew);
			updateFileCheckmark.SetActive(value: false);
			publishSuccessPopup.SetActive(value: false);
			CloseSubmitPanel();
			lastUpdateSection.SetActive(!isNew);
			CheckCanBeSubmitted();
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			if (isNew)
			{
				manager.RequestDeleteItem(item);
			}
			if (File.Exists(tempFilePath))
			{
				File.Delete(tempFilePath);
			}
			if (File.Exists(tempPreviewPath))
			{
				File.Delete(tempPreviewPath);
			}
		}

		protected override void UpdatePanel()
		{
			if (submitting)
			{
				float updateProgress = item.GetUpdateProgress();
				if (float.IsNaN(updateProgress))
				{
					PopupManager.DisplayError("Publishing error", "Try again later");
					submitting = false;
					CloseSubmitPanel();
				}
				else
				{
					submitBar.UpdateValue(updateProgress);
				}
				progress += Time.deltaTime;
				if (progress > 10f)
				{
					OnItemSubmitResult(EResult.k_EResultExpired, item);
				}
			}
			else if (submittedSuccess)
			{
				progress += Time.deltaTime;
				if (!(progress < 2f))
				{
					submittedSuccess = false;
					ClosePanel();
				}
			}
		}

		private void OnItemSubmitResult(EResult res, WorkshopItem submitted)
		{
			if (item == submitted)
			{
				if (res != EResult.k_EResultOK)
				{
					PopupManager.DisplayError("Publishing Error", "There was an error with the steam submit process:\n" + res.ToString() + res.GetDetails());
					submittedSuccess = false;
					CloseSubmitPanel();
				}
				else
				{
					manager.RequestItemDetails(item.id);
					submittedSuccess = true;
					isNew = false;
				}
				progress = 0f;
				submitting = false;
				submitBar.gameObject.SetActive(value: false);
				if (submittedSuccess)
				{
					publishSuccessPopup.SetActive(value: true);
				}
			}
		}

		public void DeleteItemPressed()
		{
			PopupManager.DisplayActionWarning(ActionWarnings.deleteWorkshopItem, ActuallyDeleteItem);
		}

		private void ActuallyDeleteItem()
		{
			manager.RequestDeleteItem(item);
		}

		private void OnItemDeleted(PublishedFileId_t removed)
		{
			if (item == null || !(item.id != removed))
			{
				item?.Delete();
				isNew = false;
				ClosePanel();
			}
		}

		public void UpdateFile()
		{
			if (!File.Exists(sourcePath))
			{
				PopupManager.DisplayError("File Update Failed", sourcePath + " is nowhere to be found");
				updateFileCheckmark.SetActive(value: false);
				return;
			}
			FileInfo fileInfo = new FileInfo(sourcePath);
			string text;
			try
			{
				if (item.type == WorkshopItemType.Bibite)
				{
					BibiteTemplate bibiteTemplate = new BibiteTemplate(sourcePath);
					if (!bibiteTemplate.IsValid)
					{
						PopupManager.DisplayError("File Update Failed", "The bibite file was in an incorrect format and couldn't be read.");
						updateFileCheckmark.SetActive(value: false);
						return;
					}
					text = bibiteTemplate.version;
				}
				else if (item.type == WorkshopItemType.Save)
				{
					using ZipArchive zip = ZipFile.Open(sourcePath, ZipArchiveMode.Read);
					JObject sceneOfSave = SaveSystem.GetSceneOfSave(zip);
					if (sceneOfSave?["simulatedTime"] == null || sceneOfSave["nBibites"] == null || sceneOfSave["version"] == null)
					{
						PopupManager.DisplayError("File Update Failed", "The save file was in an incorrect format and couldn't be read.");
						updateFileCheckmark.SetActive(value: false);
						return;
					}
					text = sceneOfSave["version"].ToString();
				}
				else
				{
					using ZipArchive zip2 = ZipFile.Open(sourcePath, ZipArchiveMode.Read);
					JObject infoOfScenario = SaveSystem.GetInfoOfScenario(zip2);
					if (infoOfScenario?["name"] == null || infoOfScenario["desc"] == null || infoOfScenario["version"] == null)
					{
						PopupManager.DisplayError("File Update Failed", "The save file was in an incorrect format and couldn't be read.");
						updateFileCheckmark.SetActive(value: false);
						return;
					}
					text = infoOfScenario["version"].ToString();
				}
			}
			catch (Exception ex)
			{
				PopupManager.DisplayError("File Update Failed", sourcePath + " caused an unexpected error\n\n" + ex.Message);
				updateFileCheckmark.SetActive(value: false);
				return;
			}
			try
			{
				tempFilePath = Path.Combine(SteamWorkshopManager.workshopSharingPath, fileInfo.Name);
				if (File.Exists(tempFilePath))
				{
					File.Delete(tempFilePath);
				}
				File.Copy(sourcePath, tempFilePath);
				tempPullTime = DateTime.Now;
			}
			catch (Exception ex2)
			{
				PopupManager.DisplayError("File Copy Failed", sourcePath + " caused an unexpected error and couldn't be copied:\n\n" + ex2.Message);
				updateFileCheckmark.SetActive(value: false);
				return;
			}
			versionText.text = text;
			lastFilePull.text = item.lastFilePull.ToString("yyyy-MM dd HH:mm:ss");
			updateFile = true;
			updateFileCheckmark.SetActive(value: true);
		}

		public void SelectNewPreview()
		{
			global::StandaloneFileBrowser.StandaloneFileBrowser.OpenFilePanelAsync("Select new preview Image (1MB max)", Application.persistentDataPath, "png", multiselect: false, UpdatePreview);
		}

		public void UpdatePreview(string[] path)
		{
			if (path == null || path.Length < 1)
			{
				return;
			}
			string text = path[0];
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			FileInfo fileInfo = new FileInfo(text);
			if (fileInfo.Extension != ".png")
			{
				PopupManager.DisplayError("Image Upload", "Only .png files are supported.");
				return;
			}
			if ((double)fileInfo.Length > 1000000.0)
			{
				PopupManager.DisplayError("Image Upload", "The maximum preview image size is 1MB.");
				return;
			}
			if (File.Exists(tempPreviewPath))
			{
				File.Delete(tempPreviewPath);
			}
			File.Copy(text, tempPreviewPath);
			bool flag = tex.LoadImageIntoTexture(tempPreviewPath);
			if (flag)
			{
				preview.FitTexture(tex, FitType.Fill);
			}
			else
			{
				preview.texture = defaultPreview;
			}
			noPreviewDisclaimer.SetActive(!flag);
			updatePreview = true;
		}

		private void CheckCanBeSubmitted()
		{
			bool interactable = true;
			if (titleField.text.Length < 10)
			{
				titleErrorDisclaimer.SetActive(value: true);
				interactable = false;
			}
			else
			{
				titleErrorDisclaimer.SetActive(value: false);
			}
			if (descField.text.Length < 30)
			{
				descErrorDisclaimer.SetActive(value: true);
				interactable = false;
			}
			else
			{
				descErrorDisclaimer.SetActive(value: false);
			}
			submitButton1.interactable = interactable;
		}

		private void OnChangeLogUpdate(string val)
		{
			bool flag = changelogField.text.Length > 5;
			submitButton2.interactable = flag;
			changelogErrorDisclaimer.SetActive(!flag);
		}

		public void SubmitPressed()
		{
			submitPopup.SetActive(value: true);
			otherPanelOpen = true;
			submitBar.gameObject.SetActive(value: false);
			submitButton2.gameObject.SetActive(value: true);
			publishSuccessPopup.SetActive(value: false);
			closeSubmitPanelButton.SetActive(value: true);
		}

		public void ActuallySubmit()
		{
			if (!isNew)
			{
				item.StartItemUpdate();
			}
			closeSubmitPanelButton.SetActive(value: false);
			if (isNew || item.title != titleField.text)
			{
				item.SetTitle(titleField.text);
			}
			if (isNew || item.desc != descField.text)
			{
				item.SetDescription(descField.text);
			}
			if (isNew || item.visibility.val != visibility.val)
			{
				item.SetVisibility(visibility.val);
			}
			if (updateFile)
			{
				item.UpdateSharedFile(tempFilePath, tempPullTime, versionText.text);
				File.Delete(tempFilePath);
				updateFile = false;
			}
			if (updatePreview)
			{
				item.SetPreview(tempPreviewPath);
				File.Delete(tempPreviewPath);
				updatePreview = false;
			}
			if (item.SubmitItemUpdate(changelogField.text))
			{
				submitting = true;
				submitButton2.gameObject.SetActive(value: false);
				submitBar.gameObject.SetActive(value: true);
				progress = 0f;
			}
		}

		public void CloseSubmitPanel()
		{
			submitPopup.SetActive(value: false);
			otherPanelOpen = false;
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(tex);
			manager.onWorkshopItemSubmitResult.RemoveListener(OnItemSubmitResult);
			manager.onWorkshopItemDestroyed.RemoveListener(OnItemDeleted);
		}
	}
}
