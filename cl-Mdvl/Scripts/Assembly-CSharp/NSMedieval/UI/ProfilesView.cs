using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace NSMedieval.UI
{
	public class ProfilesView : ClosableUIView
	{
		[SerializeField]
		private GameObject saveProfilePrefab;

		[SerializeField]
		private GameObject profilesListGameObject;

		[SerializeField]
		private SoundButton nextButton;

		[SerializeField]
		private SoundButton deleteButton;

		[SerializeField]
		private SoundButton deleteAllButton;

		[SerializeField]
		private GameObject footer;

		[SerializeField]
		private SoundButton backButton;

		[SerializeField]
		private SoundButton loadDevMapSize;

		[SerializeField]
		private SafeTMP_InputField searchInputField;

		[SerializeField]
		private SoundButton searchButton;

		private List<VillageSaveInfo> profiles;

		private readonly List<string> folders = new List<string>();

		private readonly Dictionary<string, List<VillageSaveInfo>> savesByFolder = new Dictionary<string, List<VillageSaveInfo>>();

		private readonly List<SettlementView> settlementViews = new List<SettlementView>();

		private VillageSaveInfo selectedSaveInfo;

		public virtual List<VillageSaveInfo> GetProfiles()
		{
			return MonoSingleton<GlobalSaveController>.Instance.SavesList.OrderByDescending((VillageSaveInfo profile) => profile.LastPlayed).ToList();
		}

		protected virtual List<VillageSaveInfo> GetProfilesForFoldersList()
		{
			return MonoSingleton<GlobalSaveController>.Instance.SavesList.OrderByDescending((VillageSaveInfo profile) => profile.LastPlayed).ToList();
		}

		private void Awake()
		{
			if (deleteAllButton != null)
			{
				_ = footer.GetComponent<HorizontalLayoutGroup>() != null;
			}
		}

		public override void Show()
		{
			profiles = GetProfiles();
			List<VillageSaveInfo> profilesForFoldersList = GetProfilesForFoldersList();
			savesByFolder.Clear();
			folders.Clear();
			foreach (VillageSaveInfo item in profilesForFoldersList)
			{
				if (!folders.Contains(item.FolderName))
				{
					folders.Add(item.FolderName);
				}
				if (!savesByFolder.ContainsKey(item.FolderName))
				{
					savesByFolder.Add(item.FolderName, new List<VillageSaveInfo>());
				}
				savesByFolder[item.FolderName].Add(item);
			}
			CreateVillageGroups();
			if (profiles.Count > 0)
			{
				if (nextButton != null)
				{
					nextButton.interactable = true;
				}
				if (deleteButton != null)
				{
					deleteButton.interactable = true;
				}
			}
			if (deleteAllButton != null)
			{
				deleteAllButton.gameObject.SetActive(value: false);
			}
			if (loadDevMapSize != null)
			{
				loadDevMapSize.gameObject.SetActive(value: false);
			}
			SetSelectedProfile((profiles.Count > 0) ? profiles[0] : null);
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			base.Show();
			StartCoroutine(ResetScrollViewDelay());
		}

		public void SetSelectedProfile(VillageSaveInfo profile)
		{
			Log.Info((profile == null) ? "Setting selected profile to: null" : ("Setting selected profile to: " + profile.FolderName + "/" + profile.FileName), "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
			selectedSaveInfo = profile;
			foreach (SettlementView settlementView in settlementViews)
			{
				if (settlementView.gameObject.activeSelf)
				{
					settlementView.SetSelectedProfile(profile);
				}
			}
			bool interactable = selectedSaveInfo != null;
			if (deleteButton != null)
			{
				deleteButton.interactable = interactable;
			}
			if (nextButton != null)
			{
				nextButton.interactable = interactable;
			}
		}

		protected void Start()
		{
			if (nextButton != null)
			{
				nextButton.onClick.RemoveAllListeners();
				nextButton.onClick.AddListener(OnLoadClick);
			}
			if (deleteButton != null)
			{
				deleteButton.onClick.RemoveAllListeners();
				deleteButton.onClick.AddListener(OnDeleteClick);
			}
			if (backButton != null)
			{
				backButton.onClick.RemoveAllListeners();
				backButton.onClick.AddListener(CloseSelf);
			}
			if (deleteAllButton != null)
			{
				deleteAllButton.onClick.RemoveAllListeners();
				deleteAllButton.onClick.AddListener(OnDeleteAllClick);
			}
			if (loadDevMapSize != null)
			{
				loadDevMapSize.onClick.RemoveAllListeners();
				loadDevMapSize.onClick.AddListener(LoadDevMapSizeSave);
			}
			if (searchButton != null)
			{
				searchButton.onClick.RemoveAllListeners();
				searchButton.onClick.AddListener(OnSearchClick);
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
		}

		private void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("ProfilesView.Tick"))
			{
				if (base.gameObject.activeInHierarchy && searchInputField != null)
				{
					if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && searchInputField.text != string.Empty)
					{
						OnSearchClick();
					}
					if (Input.GetKeyDown(KeyCode.Escape) && searchInputField.text != string.Empty)
					{
						CancelSearch();
					}
				}
			}
		}

		private void OnSearchClick()
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (searchInputField.text != string.Empty)
				{
					SearchVillageGroups(searchInputField.text.ToLower());
					searchInputField.Select();
					searchInputField.ActivateInputField();
				}
				else if (searchInputField.text == string.Empty)
				{
					CancelSearch();
				}
			}
		}

		private void CancelSearch()
		{
			ClearSearchInputField();
			CreateVillageGroups();
			if (savesByFolder.Count > 0)
			{
				SetSelectedProfile(savesByFolder.Values.First().FirstOrDefault());
			}
		}

		private void ClearSearchInputField()
		{
			searchInputField.Select();
			searchInputField.ActivateInputField();
			searchInputField.text = string.Empty;
		}

		private void SearchVillageGroups(string keyword)
		{
			Dictionary<string, List<VillageSaveInfo>> dictionary = new Dictionary<string, List<VillageSaveInfo>>();
			foreach (KeyValuePair<string, List<VillageSaveInfo>> item in savesByFolder)
			{
				List<VillageSaveInfo> list = new List<VillageSaveInfo>();
				foreach (VillageSaveInfo item2 in item.Value)
				{
					if (item2.FileName.ToLower().IndexOf(keyword) != -1)
					{
						list.Add(item2);
					}
				}
				if (list.Count > 0)
				{
					dictionary.Add(item.Key, list);
				}
			}
			CreateVillageGroups(dictionary);
			if (dictionary.Count > 0)
			{
				SetSelectedProfile(dictionary.Values.First().First());
			}
		}

		private void CreateVillageGroups(Dictionary<string, List<VillageSaveInfo>> savesByFolder)
		{
			foreach (SettlementView settlementView in settlementViews)
			{
				settlementView.Hide();
				settlementView.gameObject.SetActive(value: false);
			}
			StartCoroutine(CreateVillageGroupsDelay(savesByFolder));
		}

		private IEnumerator CreateVillageGroupsDelay(Dictionary<string, List<VillageSaveInfo>> savesByFolder)
		{
			yield return new WaitForEndOfFrame();
			Action<VillageSaveInfo> loadProfileAction = ((this is SaveView) ? null : new Action<VillageSaveInfo>(LoadProfile));
			int num = 0;
			foreach (string folder in folders)
			{
				if (savesByFolder.ContainsKey(folder) && savesByFolder[folder].Count != 0)
				{
					SettlementView firstFreeSettlementView = GetFirstFreeSettlementView(folder);
					firstFreeSettlementView.gameObject.SetActive(value: true);
					Action<VillageSaveInfo> overwriteProfileAction = null;
					if (OverrideButtonEnabled() && GlobalSaveController.CurrentVillageData.FolderName.Equals(folder))
					{
						overwriteProfileAction = OverwriteProfile;
					}
					firstFreeSettlementView.Setup(folder, savesByFolder[folder], overwriteProfileAction, DeleteProfile, SelectProfile, DeleteFolder, loadProfileAction, isExpanded: true);
					firstFreeSettlementView.transform.SetSiblingIndex(num++);
				}
			}
		}

		private void LoadDevMapSizeSave()
		{
			SetSelectedProfile(profiles.Where((VillageSaveInfo profile) => profile.FolderName == "Dev Map Size" && profile.FileName == "Start.sav").First());
			TryLoading();
		}

		private void OnDeleteAllClick()
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", OnDeleteAllConfirmed),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("Delete all saves?", buttonActions), handleInput: false);
		}

		private void OnDeleteAllConfirmed()
		{
			foreach (VillageSaveInfo item in MonoSingleton<GlobalSaveController>.Instance.SavesList.ToList())
			{
				if (MonoSingleton<GlobalSaveController>.Instance.DeleteSave(item))
				{
					profiles.Remove(item);
				}
			}
			savesByFolder.Clear();
			folders.Clear();
			foreach (SettlementView settlementView in settlementViews)
			{
				settlementView.gameObject.SetActive(value: false);
			}
			if (profiles.Count <= 0)
			{
				if (deleteButton != null)
				{
					deleteButton.interactable = false;
				}
				if (deleteAllButton != null && deleteAllButton.gameObject.activeSelf)
				{
					deleteAllButton.interactable = false;
				}
				if (nextButton != null)
				{
					nextButton.interactable = false;
				}
			}
			SetSelectedProfile(null);
		}

		private void OnLoadClick()
		{
			TryLoading();
		}

		public bool TryLoading()
		{
			if (selectedSaveInfo == null)
			{
				Log.Info("Cannot load selected profile, it is null!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
				return false;
			}
			if (selectedSaveInfo.IsObsolete)
			{
				MainMenuView.ShowObsoleteSaveMessage(selectedSaveInfo.ModifiedVersion, "0.17.0");
				return false;
			}
			if (SceneManager.GetActiveScene().name.Equals("HomeScene"))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trying to load save ");
					messageBuilder.AppendFormatted(selectedSaveInfo.FileName);
					messageBuilder.AppendLiteral(" from HomeScene");
				}
				Log.Info(messageBuilder);
				MonoSingleton<LoadingController>.Instance.DebugMeasureLoadingTime("Loaded save from main menu.");
				if (nextButton != null)
				{
					nextButton.interactable = false;
				}
				MonoSingleton<SecureSaveLoadingManager>.Instance.LoadVillageSaveData(selectedSaveInfo);
				return true;
			}
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(LoadDelayed);
			return true;
		}

		private void LoadDelayed()
		{
			MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Trying to load save ");
				messageBuilder.AppendFormatted(selectedSaveInfo.FileName);
				messageBuilder.AppendLiteral(" from MainScene");
			}
			Log.Info(messageBuilder);
			MonoSingleton<LoadingController>.Instance.DebugMeasureLoadingTime("Loaded save from in-game menu.");
			MonoSingleton<GlobalSaveController>.Instance.SetSaveInfoToLoad(selectedSaveInfo);
			MonoSingleton<AddressableSceneLoadingManager>.Instance.ReloadMainScene();
		}

		protected virtual void OnBackClick()
		{
			base.SceneUIManager.ShowPreviousView();
		}

		private void OnDeleteClick()
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					OnDeleteConfirmed(selectedSaveInfo);
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("delete_save_prompt", buttonActions), handleInput: false);
		}

		private void OnDeleteConfirmed(VillageSaveInfo profile)
		{
			VillageSaveInfo selectedProfileOnDelete = GetSelectedProfileOnDelete(selectedSaveInfo);
			bool flag = MonoSingleton<GlobalSaveController>.Instance.DeleteSave(profile);
			if (flag)
			{
				profiles.Remove(profile);
				foreach (string key in savesByFolder.Keys)
				{
					if (savesByFolder[key].Contains(profile))
					{
						savesByFolder[key].Remove(profile);
						if (savesByFolder[key].Count == 0)
						{
							OnRemoveFolder(key);
						}
					}
				}
			}
			if (profiles.Count <= 0)
			{
				if (deleteButton != null)
				{
					deleteButton.interactable = false;
				}
				if (nextButton != null)
				{
					nextButton.interactable = false;
				}
			}
			if (!flag)
			{
				return;
			}
			foreach (SettlementView settlementView in settlementViews)
			{
				if (settlementView.gameObject.activeSelf)
				{
					settlementView.OnProfileDeleted(profile);
				}
			}
			SetSelectedProfile(selectedProfileOnDelete);
		}

		private void OnRemoveFolder(string folder)
		{
			folders.Remove(folder);
			foreach (SettlementView settlementView in settlementViews)
			{
				if (settlementView.gameObject.activeSelf && settlementView.FolderName.Equals(folder))
				{
					settlementView.Hide();
					settlementView.gameObject.SetActive(value: false);
				}
			}
		}

		private VillageSaveInfo GetSelectedProfileOnDelete(VillageSaveInfo profileDeleting)
		{
			bool flag = false;
			VillageSaveInfo result = null;
			foreach (SettlementView settlementView in settlementViews)
			{
				if (!settlementView.gameObject.activeSelf)
				{
					continue;
				}
				VillageSaveInfo result2 = null;
				foreach (SaveFileView saveView in settlementView.SaveViews)
				{
					if (saveView.Profile != null)
					{
						if (flag)
						{
							return saveView.Profile;
						}
						if (saveView.Profile.Equals(profileDeleting))
						{
							flag = true;
						}
						else
						{
							result2 = saveView.Profile;
						}
						result = saveView.Profile;
					}
				}
				if (flag)
				{
					return result2;
				}
			}
			return result;
		}

		protected virtual void SelectProfile(VillageSaveInfo profileSelected)
		{
			SetSelectedProfile(profileSelected);
		}

		protected virtual void OverwriteProfile(VillageSaveInfo profile)
		{
		}

		protected virtual void DeleteProfile(VillageSaveInfo profile)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deleting profile ");
				messageBuilder.AppendFormatted(profile.FolderName);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(profile.FileName);
			}
			Log.Info(messageBuilder);
			SetSelectedProfile(profile);
			OnDeleteClick();
		}

		protected virtual void LoadProfile(VillageSaveInfo profile)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Loading profile ");
				messageBuilder.AppendFormatted(profile.FolderName);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(profile.FileName);
			}
			Log.Info(messageBuilder);
			SetSelectedProfile(profile);
			TryLoading();
		}

		private void DeleteFolder(string folder)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					OnFolderDeleteConfirmed(folder);
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("delete_folder_prompt", buttonActions), handleInput: false);
		}

		private void OnFolderDeleteConfirmed(string folder)
		{
			List<VillageSaveInfo> list = MonoSingleton<GlobalSaveController>.Instance.SavesList.FindAll((VillageSaveInfo save) => string.Compare(save.FolderName, folder, ignoreCase: true, CultureInfo.CurrentCulture) == 0);
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deleting all ");
				messageBuilder.AppendFormatted(list.Count);
				messageBuilder.AppendLiteral(" saves from ");
				messageBuilder.AppendFormatted(folder);
			}
			Log.Info(messageBuilder);
			bool flag = true;
			List<VillageSaveInfo> list2 = new List<VillageSaveInfo>();
			foreach (VillageSaveInfo item in list)
			{
				if (MonoSingleton<GlobalSaveController>.Instance.DeleteSave(item, serialize: false))
				{
					profiles.Remove(item);
					if (savesByFolder.ContainsKey(folder) && savesByFolder[folder].Contains(item))
					{
						messageBuilder = new FVLogInfoInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Del folder ");
							messageBuilder.AppendFormatted(folder);
							messageBuilder.AppendLiteral(": removing ");
							messageBuilder.AppendFormatted(item.FileName);
						}
						Log.Info(messageBuilder);
						savesByFolder[folder].Remove(item);
						list2.Add(item);
					}
				}
				else
				{
					flag = false;
				}
			}
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			if (savesByFolder.ContainsKey(folder) && savesByFolder[folder].Count == 0)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ProfilesView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(folder);
					messageBuilder.AppendLiteral(" from savesByFolder");
				}
				Log.Info(messageBuilder);
				savesByFolder.Remove(folder);
				OnRemoveFolder(folder);
			}
			if (profiles.Count <= 0)
			{
				if (deleteButton != null)
				{
					deleteButton.interactable = false;
				}
				if (nextButton != null)
				{
					nextButton.interactable = false;
				}
			}
			if (flag)
			{
				SetSelectedProfile(MonoSingleton<GlobalSaveController>.Instance.GetLastPlayedProfile());
				return;
			}
			foreach (VillageSaveInfo item2 in list2)
			{
				foreach (SettlementView settlementView in settlementViews)
				{
					if (settlementView.gameObject.activeSelf)
					{
						settlementView.OnProfileDeleted(item2);
					}
				}
				SetSelectedProfile(MonoSingleton<GlobalSaveController>.Instance.GetLastPlayedProfile());
			}
		}

		protected void RefreshSettlementsLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(profilesListGameObject.transform.parent.GetComponent<RectTransform>());
		}

		protected virtual bool OverrideButtonEnabled()
		{
			return false;
		}

		protected virtual void CreateVillageGroups()
		{
			foreach (SettlementView settlementView in settlementViews)
			{
				settlementView.Hide();
				settlementView.gameObject.SetActive(value: false);
			}
			Action<VillageSaveInfo> loadProfileAction = ((this is SaveView) ? null : new Action<VillageSaveInfo>(LoadProfile));
			int num = 0;
			foreach (string folder in folders)
			{
				if (savesByFolder.ContainsKey(folder) && savesByFolder[folder].Count != 0)
				{
					SettlementView firstFreeSettlementView = GetFirstFreeSettlementView(folder);
					firstFreeSettlementView.gameObject.SetActive(value: true);
					Action<VillageSaveInfo> overwriteProfileAction = null;
					if (OverrideButtonEnabled() && GlobalSaveController.CurrentVillageData.FolderName.Equals(folder))
					{
						overwriteProfileAction = OverwriteProfile;
					}
					firstFreeSettlementView.Setup(folder, savesByFolder[folder], overwriteProfileAction, DeleteProfile, SelectProfile, DeleteFolder, loadProfileAction, num == 0);
					firstFreeSettlementView.transform.SetSiblingIndex(num++);
				}
			}
		}

		private SettlementView GetFirstFreeSettlementView(string folderName)
		{
			SettlementView settlementView = settlementViews.FirstOrDefault((SettlementView entry) => !entry.gameObject.activeSelf);
			if (settlementView != null)
			{
				return settlementView;
			}
			settlementView = UnityEngine.Object.Instantiate(saveProfilePrefab, Vector3.zero, Quaternion.identity, profilesListGameObject.transform).GetComponent<SettlementView>();
			settlementViews.Add(settlementView);
			return settlementView;
		}

		protected void OnSaveReplaced(VillageSaveInfo newSave, VillageSaveInfo oldSave)
		{
			int index = profiles.IndexOf(oldSave);
			profiles[index] = newSave;
			foreach (string key in savesByFolder.Keys)
			{
				if (savesByFolder[key].Contains(oldSave))
				{
					index = savesByFolder[key].IndexOf(oldSave);
					savesByFolder[key][index] = newSave;
				}
			}
			foreach (SettlementView settlementView in settlementViews)
			{
				settlementView.OnSaveReplaced(newSave, oldSave);
			}
			if (selectedSaveInfo == null || selectedSaveInfo.Equals(newSave))
			{
				selectedSaveInfo = oldSave;
			}
			Show();
		}

		private IEnumerator ResetScrollViewDelay()
		{
			yield return new WaitForEndOfFrame();
			if (base.gameObject.activeInHierarchy)
			{
				profilesListGameObject.transform.parent.parent.GetComponent<ScrollRect>().ScrollToTop();
			}
		}
	}
}
