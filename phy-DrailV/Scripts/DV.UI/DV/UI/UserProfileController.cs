using System;
using System.Collections.Generic;
using DV.Common;
using DV.UIFramework;
using DV.Util;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class UserProfileController : AUIController
	{
		[Flags]
		private enum CopyAction
		{
			None = 0,
			Settings = 1,
			CareerSaves = 2,
			FreeRoamSaves = 4
		}

		private const string LOC_KEY_DELETE_LABEL = "mm/delete_user_label";

		private const string LOC_KEY_DELETE_CONFIRM = "mm/delete_user_confirm";

		private const string LOC_KEY_RENAME_LABEL = "mm/rename_user_label";

		private const string LOC_KEY_RENAME_CONFIRM = "mm/rename_user_confirm";

		private const string LOC_KEY_GENERIC_CANCEL = "cancel";

		private const string LOC_KEY_ADD_USER = "mm/create_user_button";

		private const string SELECTED_IMAGE = "[selected]";

		private ObservableCollectionExt<IUserProfile> gridViewModel = new ObservableCollectionExt<IUserProfile>();

		private AUserProfileProvider provider;

		private (IUserProfile profile, CopyAction action)? selectedForCopying;

		private Popup popupInstance;

		[Header("GUI Element References")]
		[NullCheck]
		public UserProfileGridView gridView;

		[NullCheck]
		public Popup deletePopupPrefab;

		[NullCheck]
		public Popup renamePopupPrefab;

		[NullCheck]
		public ButtonDV deleteButton;

		[NullCheck]
		public ButtonDV editButton;

		[NullCheck]
		public ButtonDV importButton;

		[NullCheck]
		public ButtonDV copySettingsButton;

		[NullCheck]
		public ButtonDV copyCareerButton;

		[NullCheck]
		public ButtonDV copyFreeRoamButton;

		[NullCheck]
		public ButtonDV pasteButton;

		[NullCheck]
		public ButtonDV createNewUserButton;

		[NullCheck]
		public ButtonDV selectProfileButton;

		private IUserProfile profileAwaitingConfirmation;

		private int indexAwaitingConfirmation = -1;

		private PopupManager _popupManager;

		private bool IsSelectedIndexValid => IsIndexValid(gridView.SelectedModelIndex);

		private IUserProfile SelectedProfile
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

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		public void SetProvider(AUserProfileProvider provider)
		{
			this.provider = provider;
			RefreshInterface(reloadModel: true);
		}

		private void RequestLoadProfile(IUserProfile profile)
		{
			provider.LoadProfile(profile);
		}

		protected override void Awake()
		{
			base.Awake();
			gridView.SetModel(gridViewModel);
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
			RefreshInterface(reloadModel: true);
		}

		private void OnDisable()
		{
			selectedForCopying = null;
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				gridView.SelectedIndexChanged += OnSelectedIndexChanged;
				deleteButton.Clicked += OnDeleteClicked;
				editButton.Clicked += OnEditClicked;
				importButton.Clicked += OnImportClicked;
				copySettingsButton.Clicked += OnCopySettingsClicked;
				copyCareerButton.Clicked += OnCopyCareerClicked;
				copyFreeRoamButton.Clicked += OnCopyFreeRoamClicked;
				pasteButton.Clicked += OnPasteClicked;
				createNewUserButton.Clicked += OnCreateNewUserClicked;
				selectProfileButton.Clicked += OnSelectProfileClicked;
			}
			else
			{
				gridView.SelectedIndexChanged -= OnSelectedIndexChanged;
				deleteButton.Clicked -= OnDeleteClicked;
				editButton.Clicked -= OnEditClicked;
				importButton.Clicked -= OnImportClicked;
				copySettingsButton.Clicked -= OnCopySettingsClicked;
				copyCareerButton.Clicked -= OnCopyCareerClicked;
				copyFreeRoamButton.Clicked -= OnCopyFreeRoamClicked;
				pasteButton.Clicked -= OnPasteClicked;
				createNewUserButton.Clicked -= OnCreateNewUserClicked;
				selectProfileButton.Clicked -= OnSelectProfileClicked;
			}
		}

		private void OnSelectedIndexChanged(AGridView<IUserProfile> _)
		{
			RefreshInterface();
		}

		private void RefreshInterface(bool reloadModel = false)
		{
			if (reloadModel && (bool)provider)
			{
				int num = gridView.SelectedModelIndex;
				gridViewModel.Clear();
				gridViewModel.AddRange(provider.GetProfiles());
				if (num == -1 && provider.GetCurrentProfile() != null)
				{
					num = gridViewModel.IndexOf(provider.GetCurrentProfile());
				}
				num = (IsIndexValid(num) ? num : 0);
				gridView.SetSelected(num);
			}
			bool newInteractable = IsSelectedIndexValid && selectedForCopying.HasValue && selectedForCopying.Value.profile != SelectedProfile;
			bool newInteractable2 = provider != null && provider.GetProfiles().Count > 1;
			if (IsSelectedIndexValid)
			{
				deleteButton.ToggleInteractable(newInteractable: true);
				editButton.ToggleInteractable(newInteractable: true);
				importButton.ToggleInteractable(newInteractable: true);
				copySettingsButton.ToggleInteractable(newInteractable2);
				copyCareerButton.ToggleInteractable(newInteractable2);
				copyFreeRoamButton.ToggleInteractable(newInteractable2);
				pasteButton.ToggleInteractable(newInteractable);
				selectProfileButton.ToggleInteractable(newInteractable: true);
			}
			else
			{
				deleteButton.ToggleInteractable(newInteractable: false);
				editButton.ToggleInteractable(newInteractable: false);
				importButton.ToggleInteractable(newInteractable: false);
				copySettingsButton.ToggleInteractable(newInteractable: false);
				copyCareerButton.ToggleInteractable(newInteractable: false);
				copyFreeRoamButton.ToggleInteractable(newInteractable: false);
				pasteButton.ToggleInteractable(newInteractable: false);
				selectProfileButton.ToggleInteractable(newInteractable: false);
			}
			if ((bool)provider)
			{
				createNewUserButton.ToggleInteractable(provider.CanCreateNewProfile);
			}
			ToggleCopyButton(copySettingsButton, CopyAction.Settings);
			ToggleCopyButton(copyCareerButton, CopyAction.CareerSaves);
			ToggleCopyButton(copyFreeRoamButton, CopyAction.FreeRoamSaves);
		}

		private void ToggleCopyButton(ButtonDV button, CopyAction matchAction)
		{
			bool active = selectedForCopying.HasValue && selectedForCopying.Value.action.HasIntFlag(matchAction);
			button.transform.Find("[selected]").gameObject.SetActive(active);
		}

		private void OnCreateNewUserClicked(IClickable _)
		{
			string newUserNameSuggestion = provider.GetNewUserNameSuggestion();
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				positiveKey = "mm/create_user_button",
				negativeKey = "cancel",
				labelKey = "mm/rename_user_label"
			};
			popupInstance = PopupManager.ShowPopup(renamePopupPrefab, locKeys);
			popupInstance.GetComponentInChildren<TMP_InputField>().text = newUserNameSuggestion;
			popupInstance.Closed += OnUserNameInput;
		}

		private void OnUserNameInput(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Positive && !string.IsNullOrEmpty(result.data))
			{
				IUserProfile item = provider.CreateNewUserProfile(result.data);
				RefreshInterface(reloadModel: true);
				gridView.SetSelected(gridViewModel.IndexOf(item));
			}
		}

		private void OnDeleteClicked(IClickable _)
		{
			if (IsSelectedIndexValid)
			{
				if (!PopupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "mm/delete_user_confirm",
					negativeKey = "cancel",
					labelKey = "mm/delete_user_label"
				};
				profileAwaitingConfirmation = SelectedProfile;
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", profileAwaitingConfirmation.Name } };
				popupInstance = PopupManager.ShowPopup(deletePopupPrefab, locKeys, locParams);
				popupInstance.Closed += OnDeletePopupClosed;
			}
		}

		private void OnDeletePopupClosed(PopupResult result)
		{
			Debug.Log($"\"Delete user\" popup '{result.popup.name}' closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				provider.DeleteProfile(profileAwaitingConfirmation);
				RefreshInterface(reloadModel: true);
			}
		}

		private void OnEditClicked(IClickable _)
		{
			if (IsSelectedIndexValid)
			{
				if (!PopupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "mm/rename_user_confirm",
					negativeKey = "cancel",
					labelKey = "mm/rename_user_label"
				};
				profileAwaitingConfirmation = SelectedProfile;
				indexAwaitingConfirmation = gridView.SelectedModelIndex;
				popupInstance = PopupManager.ShowPopup(renamePopupPrefab, locKeys);
				popupInstance.Closed += OnRenamePopupClosed;
				popupInstance.GetComponentInChildren<TMP_InputField>().text = profileAwaitingConfirmation.Name;
			}
		}

		private void OnImportClicked(IClickable _)
		{
			if (IsSelectedIndexValid)
			{
				provider.OpenImportFolderFor(SelectedProfile);
			}
		}

		private void OnRenamePopupClosed(PopupResult result)
		{
			Debug.Log($"\"Rename user\" popup '{result.popup.name}' closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				provider.RenameProfile(profileAwaitingConfirmation, result.data);
				RefreshInterface(reloadModel: true);
			}
		}

		private void Copy(CopyAction action)
		{
			if (!IsSelectedIndexValid)
			{
				selectedForCopying = null;
				return;
			}
			if (!selectedForCopying.HasValue || selectedForCopying.Value.profile != SelectedProfile)
			{
				selectedForCopying = (SelectedProfile, CopyAction.None);
			}
			selectedForCopying = (SelectedProfile, selectedForCopying.Value.action ^ action);
			RefreshInterface();
		}

		private void OnCopySettingsClicked(IClickable _)
		{
			Copy(CopyAction.Settings);
		}

		private void OnCopyCareerClicked(IClickable _)
		{
			Copy(CopyAction.CareerSaves);
		}

		private void OnCopyFreeRoamClicked(IClickable _)
		{
			Copy(CopyAction.FreeRoamSaves);
		}

		private void OnPasteClicked(IClickable _)
		{
			if (IsSelectedIndexValid && selectedForCopying.HasValue)
			{
				if (selectedForCopying.Value.action.HasIntFlag(CopyAction.Settings))
				{
					provider.CopySettings(selectedForCopying.Value.profile, SelectedProfile);
				}
				if (selectedForCopying.Value.action.HasIntFlag(CopyAction.CareerSaves))
				{
					provider.CopyCareerSaves(selectedForCopying.Value.profile, SelectedProfile);
				}
				if (selectedForCopying.Value.action.HasIntFlag(CopyAction.FreeRoamSaves))
				{
					provider.CopyFreeRoamSaves(selectedForCopying.Value.profile, SelectedProfile);
				}
				selectedForCopying = null;
				RefreshInterface();
			}
		}

		private void OnSelectProfileClicked(IClickable _)
		{
			if (IsSelectedIndexValid)
			{
				RequestLoadProfile(SelectedProfile);
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
