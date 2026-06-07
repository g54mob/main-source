using System;
using System.Collections.Generic;
using System.IO;
using DV.Common;
using DV.Localization;
using DV.UIFramework;
using DV.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class SaveLoadController : AUIController
	{
		private const string LOC_KEY_BUTTON_SAVE = "save";

		private const string LOC_KEY_BUTTON_LOAD = "load";

		private const string LOC_KEY_BUTTON_OVERWRITE = "overwrite";

		private const string LOC_KEY_OK = "ok";

		private const string LOC_KEY_TITLE_SAVE = "mm/load_title";

		private const string LOC_KEY_TITLE_SAVE_LOAD = "mm/load_save_title";

		private const string LOC_KEY_SIDEPANEL_MAKE_NEW_SAVE = "mm/make_new_save";

		private const string LOC_KEY_SIDEPANEL_SAVE_INFO_FORMAT = "mm/save_description";

		private const string LOC_KEY_SAVETYPE_AUTO = "save_type_auto_save";

		private const string LOC_KEY_SAVETYPE_MANUAL = "save_type_manual_save";

		private const string LOC_KEY_SAVETYPE_QUICK = "save_type_quick_save";

		private const string LOC_GENERIC_CANCEL = "cancel";

		private const string LOC_RENAME_PROMPT = "mm/savegame_rename_prompt";

		private const string LOC_RENAME_CONFIRM = "mm/savegame_rename_confirm";

		private const string LOC_DELETE_PROMPT = "mm/savegame_delete_prompt";

		private const string LOC_DELETE_CONFIRM = "mm/savegame_delete_confirm";

		private const string LOC_BRANCH_OUT_PROMPT = "mm/savegame_branch_out_prompt";

		private const string LOC_BRANCH_OUT_CONFIRM = "mm/savegame_branch_out_confirm";

		private const string LOC_BRANCH_OUT_ERROR = "mm/savegame_branch_out_error";

		private const string LOC_BRANCH_OUT_SUFFIX = "mm/savegame_branch_out_suffix";

		private const string LOC_OVERWRITE_PROMPT = "mm/savegame_overwrite_prompt";

		private const string LOC_LOAD_PROMPT = "mm/savegame_load_prompt";

		public PopupManager popupManager;

		private ObservableCollectionExt<ISaveGame> gridViewModel = new ObservableCollectionExt<ISaveGame>();

		private AUserProfileProvider provider;

		private APauseMenuProvider pauseMenuProvider;

		private ScrollRect parentScroller;

		private IGameSession session;

		private bool inMainMenu;

		private int indexToSelectOnRefresh;

		private int indexAwaitingConfirmation = -1;

		private ISaveGame saveAwaitingConfirmation;

		private bool manualSavingAllowed;

		private bool isInSingleSaveMode;

		[Header("GUI Element References")]
		[NullCheck]
		public SaveLoadGridView gridView;

		[NullCheck]
		public TextMeshProUGUI titleBar;

		[NullCheck]
		public TextMeshProUGUI subtitle;

		[NullCheck]
		public TextMeshProUGUI saveInfoTMPro;

		[NullCheck]
		public SaveThumbnailViewer thumbnail;

		[NullCheck]
		public GameObject hardcoreNote;

		[NullCheck]
		public GameObject tutorialNote;

		[NullCheck]
		public GameObject photoModeNote;

		[NullCheck]
		public Button deleteButton;

		[NullCheck]
		public Button renameButton;

		[NullCheck]
		public Button openFolderButton;

		[NullCheck]
		public Button branchOutButton;

		[NullCheck]
		public Button loadButton;

		[NullCheck]
		public Button saveButton;

		[NullCheck]
		public Button overwriteButton;

		[NullCheck]
		public Button backButton;

		[NullCheck]
		public Popup infoPopupPrefab;

		[NullCheck]
		public Popup yesNoPopupPrefab;

		[NullCheck]
		public Popup textInputPopupPrefab;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		private ISaveGame SelectedSave
		{
			get
			{
				if (!IsSelectedIndexValid)
				{
					return null;
				}
				return gridViewModel[gridView.SelectedModelIndex];
			}
		}

		private bool IsSelectedIndexValid => IsIndexValid(gridView.SelectedModelIndex);

		private bool IsHoveredIndexValid => IsIndexValid(gridView.HoveredModelIndex);

		private bool SaveButtonDoesOverwrite => IsSelectedIndexValid;

		public AUserProfileProvider Provider => provider;

		public event Action<ISaveGame> LoadRequested;

		public event Action BackRequested;

		public void SetData(bool inMainMenu, APauseMenuProvider pauseMenuProvider, IGameSession session)
		{
			this.pauseMenuProvider = pauseMenuProvider;
			this.inMainMenu = inMainMenu;
			this.session = session;
			indexToSelectOnRefresh = 0;
			RefreshData();
		}

		public void SetProvider(AUserProfileProvider provider)
		{
			this.provider = provider;
			RefreshData();
		}

		private void OnEnable()
		{
			if (!parentScroller)
			{
				parentScroller = gridView.GetComponentInParent<ScrollRect>();
			}
			SetupListeners(on: true);
			indexToSelectOnRefresh = 0;
			RefreshData();
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				gridView.SelectedIndexChanged += RefreshInterface;
				gridView.HoveredIndexChanged += RefreshInterface;
				deleteButton.onClick.AddListener(OnDeleteClicked);
				renameButton.onClick.AddListener(OnRenameClicked);
				openFolderButton.onClick.AddListener(OnOpenFolderClicked);
				branchOutButton.onClick.AddListener(OnBranchOutClicked);
				loadButton.onClick.AddListener(OnLoadClicked);
				saveButton.onClick.AddListener(OnSaveClicked);
				overwriteButton.onClick.AddListener(OnOverwriteClicked);
				backButton.onClick.AddListener(OnBackButtonClicked);
			}
			else
			{
				gridView.SelectedIndexChanged -= RefreshInterface;
				gridView.HoveredIndexChanged -= RefreshInterface;
				deleteButton.onClick.RemoveListener(OnDeleteClicked);
				renameButton.onClick.RemoveListener(OnRenameClicked);
				openFolderButton.onClick.RemoveListener(OnOpenFolderClicked);
				branchOutButton.onClick.RemoveListener(OnBranchOutClicked);
				loadButton.onClick.RemoveListener(OnLoadClicked);
				saveButton.onClick.RemoveListener(OnSaveClicked);
				overwriteButton.onClick.RemoveListener(OnOverwriteClicked);
				backButton.onClick.RemoveListener(OnBackButtonClicked);
			}
		}

		private void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError(GetType().Name + " RefreshData reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshData = true;
			gridView.showDummyElement = false;
			gridViewModel.Clear();
			gridView.SetModel(gridViewModel);
			if (session != null)
			{
				manualSavingAllowed = provider?.IsManualSavingAllowed() ?? false;
				isInSingleSaveMode = provider?.IsInSingleSaveMode(session) ?? false;
				if (isInSingleSaveMode)
				{
					if (session.LatestSave != null)
					{
						gridViewModel.Add(session.LatestSave);
					}
				}
				else
				{
					gridViewModel.AddRange(session.Saves);
				}
			}
			else
			{
				Debug.LogWarning("SaveLoadController session is null", this);
			}
			RefreshInterface();
			if (indexToSelectOnRefresh >= 0 && gridView != null && gridView.Model.Count > indexToSelectOnRefresh)
			{
				gridView.SetSelected(indexToSelectOnRefresh);
				if ((bool)parentScroller)
				{
					parentScroller.verticalNormalizedPosition = 1f - (float)indexToSelectOnRefresh / (float)gridView.Model.Count;
				}
				indexToSelectOnRefresh = -1;
			}
			reentrancyCheck_RefreshData = false;
		}

		private void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError(GetType().Name + " RefreshInterface reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			string firstParamValue = ((session == null || string.IsNullOrWhiteSpace(session.Name)) ? LocalizationAPI.L("scenario/session_selector") : session.Name);
			subtitle.text = LocalizationAPI.L("mm/manage_your_progress", firstParamValue);
			bool flag = provider != null;
			bool flag2 = !inMainMenu && (!flag || manualSavingAllowed);
			bool flag3 = flag && isInSingleSaveMode;
			bool flag4 = flag && provider.IsSavingRestrictedByTutorial();
			bool active = flag && provider.IsSavingRestrictedByPhotoMode();
			bool active2 = flag2 && (!flag3 || gridViewModel.Count == 0);
			hardcoreNote.SetActive(flag3 && (inMainMenu || flag2));
			tutorialNote.SetActive(flag4);
			photoModeNote.SetActive(active);
			saveButton.gameObject.SetActive(active2);
			overwriteButton.gameObject.SetActive(flag2 && (!flag3 || gridViewModel.Count > 0));
			branchOutButton.gameObject.SetActive(inMainMenu);
			backButton.gameObject.SetActive(inMainMenu);
			loadButton.gameObject.SetActive(inMainMenu || flag4 || !flag3);
			deleteButton.gameObject.SetActive(inMainMenu || !flag3);
			Localize componentInChildren = titleBar.GetComponentInChildren<Localize>();
			componentInChildren.key = (flag2 ? "mm/load_save_title" : "mm/load_title");
			componentInChildren.UpdateLocalization();
			if (IsSelectedIndexValid)
			{
				deleteButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
				loadButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
				saveButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
				overwriteButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
				branchOutButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
			}
			else
			{
				deleteButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: false);
				loadButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: false);
				saveButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: true);
				overwriteButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: false);
				branchOutButton.GetComponent<ButtonDV>().ToggleInteractable(newInteractable: false);
			}
			if (IsHoveredIndexValid)
			{
				UpdateInfoTextAndThumb(gridViewModel[gridView.HoveredModelIndex]);
			}
			else if (IsSelectedIndexValid)
			{
				UpdateInfoTextAndThumb(gridViewModel[gridView.SelectedModelIndex]);
			}
			else
			{
				UpdateInfoTextAndThumb(null);
			}
			reentrancyCheck_RefreshInterface = false;
		}

		private void RefreshInterface(AGridView<ISaveGame> _)
		{
			RefreshInterface();
		}

		private void UpdateInfoTextAndThumb(ISaveGame data)
		{
			if (data != null)
			{
				saveInfoTMPro.text = FormatLocalizedSaveInfo(data);
				thumbnail.Show(data);
			}
			else if (inMainMenu)
			{
				saveInfoTMPro.text = "";
				thumbnail.Hide();
			}
			else if (!inMainMenu)
			{
				saveInfoTMPro.text = LocalizationAPI.L("mm/make_new_save");
				thumbnail.Hide();
			}
		}

		private string FormatLocalizedSaveInfo(ISaveGame data)
		{
			string arg = "";
			switch (data.Type)
			{
			case SaveType.Manual:
				arg = LocalizationAPI.L("save_type_manual_save");
				break;
			case SaveType.Quick:
				arg = LocalizationAPI.L("save_type_quick_save");
				break;
			case SaveType.Auto:
				arg = LocalizationAPI.L("save_type_auto_save");
				break;
			}
			return string.Format(LocalizationAPI.L("mm/save_description"), data.Timestamp.ToString("yyyy\\/MM\\/dd HH\\:mm\\:ss"), arg);
		}

		private void OnDeleteClicked()
		{
			if (IsSelectedIndexValid)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("popupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "mm/savegame_delete_confirm",
					negativeKey = "cancel",
					labelKey = "mm/savegame_delete_prompt"
				};
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				saveAwaitingConfirmation = SelectedSave;
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", saveAwaitingConfirmation.Name } };
				popupManager.ShowPopup(yesNoPopupPrefab, locKeys, locParams).Closed += OnDeletePopupClosed;
			}
		}

		private void OnDeletePopupClosed(PopupResult result)
		{
			Debug.Log($"Delete save popup closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				indexToSelectOnRefresh = ((gridViewModel.Count > 1) ? Mathf.Min(indexAwaitingConfirmation, gridViewModel.Count - 2) : (-1));
				session.DeleteSaveGame(saveAwaitingConfirmation);
				RefreshData();
			}
		}

		private void OnRenameClicked()
		{
			if (IsSelectedIndexValid)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("popupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "mm/savegame_rename_confirm",
					negativeKey = "cancel",
					labelKey = "mm/savegame_rename_prompt"
				};
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				saveAwaitingConfirmation = SelectedSave;
				Popup popup = popupManager.ShowPopup(textInputPopupPrefab, locKeys);
				popup.Closed += OnRenamePopupClosed;
				popup.GetComponentInChildren<TMP_InputField>().text = saveAwaitingConfirmation.Name;
			}
		}

		private void OnRenamePopupClosed(PopupResult result)
		{
			Debug.Log($"Rename save popup closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				saveAwaitingConfirmation.Name = result.data.Trim();
				saveAwaitingConfirmation.FlushToDisk();
				RefreshData();
			}
		}

		private void OnOpenFolderClicked()
		{
			if (SelectedSave == null)
			{
				Util.OpenFolder(Path.Combine(Provider.GetFilesystemPath(session.BasePath), "Saves"));
			}
			else
			{
				Util.OpenFile(Provider.GetFilesystemPath(SelectedSave.GetFiles(null)[0]));
			}
		}

		private void OnBranchOutClicked()
		{
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				positiveKey = "mm/savegame_branch_out_confirm",
				negativeKey = "cancel",
				labelKey = "mm/savegame_branch_out_prompt"
			};
			indexAwaitingConfirmation = gridView.SelectedModelIndex;
			saveAwaitingConfirmation = SelectedSave;
			Popup popup = popupManager.ShowPopup(textInputPopupPrefab, locKeys);
			popup.Closed += OnBranchOutPopupClosed;
			popup.GetComponentInChildren<TMP_InputField>().text = saveAwaitingConfirmation.ParentSession.Name + LocalizationAPI.L("mm/savegame_branch_out_suffix");
		}

		private void OnBranchOutPopupClosed(PopupResult result)
		{
			Debug.Log($"Branch out popup closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				ISaveGame saveGame = saveAwaitingConfirmation;
				IGameSession parentSession = saveGame.ParentSession;
				string text = result.data.Trim();
				if (string.IsNullOrEmpty(text))
				{
					text = parentSession.Name + LocalizationAPI.L("mm/branch_out_suffix");
				}
				if (provider.BranchOutSession(saveGame, text) != null)
				{
					this.BackRequested?.Invoke();
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "ok",
					labelKey = "mm/savegame_branch_out_error"
				};
				popupManager.ShowPopup(infoPopupPrefab, locKeys);
			}
		}

		private void OnLoadClicked()
		{
			if (!IsSelectedIndexValid)
			{
				return;
			}
			if ((bool)pauseMenuProvider && pauseMenuProvider.HasUnsavedProgress)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("popupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "load",
					negativeKey = "cancel",
					labelKey = "mm/savegame_load_prompt"
				};
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				saveAwaitingConfirmation = SelectedSave;
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", saveAwaitingConfirmation.Name } };
				popupManager.ShowPopup(yesNoPopupPrefab, locKeys, locParams).Closed += OnLoadPopupClosed;
			}
			else
			{
				this.LoadRequested?.Invoke(SelectedSave);
			}
		}

		private void OnLoadPopupClosed(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				this.LoadRequested?.Invoke(saveAwaitingConfirmation);
			}
		}

		private void OnSaveClicked()
		{
			ISaveGame saveGame = provider.SaveGame(SaveType.Manual);
			if (saveGame != null)
			{
				RefreshData();
				int num = gridViewModel.IndexOf(saveGame);
				if (num >= 0)
				{
					gridView.SetSelected(num + (gridView.showDummyElement ? 1 : 0));
				}
			}
		}

		private void OnOverwriteClicked()
		{
			if (IsSelectedIndexValid)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("popupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "overwrite",
					negativeKey = "cancel",
					labelKey = "mm/savegame_overwrite_prompt"
				};
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				saveAwaitingConfirmation = SelectedSave;
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", saveAwaitingConfirmation.Name } };
				popupManager.ShowPopup(yesNoPopupPrefab, locKeys, locParams).Closed += OnOverwritePopupClosed;
			}
		}

		private void OnOverwritePopupClosed(PopupResult result)
		{
			if (result.closedBy != PopupClosedByAction.Positive)
			{
				return;
			}
			ISaveGame saveGame = provider.OverwriteSave(saveAwaitingConfirmation, SaveType.Manual);
			if (saveGame != null)
			{
				RefreshData();
				int num = gridViewModel.IndexOf(saveGame);
				if (num >= 0)
				{
					gridView.SetSelected(num + (gridView.showDummyElement ? 1 : 0));
				}
			}
		}

		private void OnBackButtonClicked()
		{
			this.BackRequested?.Invoke();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				OnDeleteClicked();
			}
		}

		private bool IsIndexValid(int i)
		{
			if (gridViewModel.Count > 0 && i >= 0)
			{
				return i < gridViewModel.Count;
			}
			return false;
		}
	}
}
