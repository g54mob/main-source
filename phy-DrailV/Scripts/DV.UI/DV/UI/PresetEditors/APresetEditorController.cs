using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using DV.Common;
using DV.Scenarios.Common;
using DV.UIFramework;
using DV.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.PresetEditors
{
	public abstract class APresetEditorController<T> : AUIController where T : class, IThing
	{
		[Header("GUI Element References - Base class common")]
		[NullCheck]
		public ButtonDV deletePresetButton;

		[NullCheck]
		public ButtonDV renamePresetButton;

		[NullCheck]
		public ButtonDV newPresetButton;

		public Button savePresetButton;

		public Button openFolderButton;

		public Button doneButton;

		[Header("GUI Element References - Popups")]
		[NullCheck]
		public Popup renamePopupPrefab;

		[NullCheck]
		public Popup deletePopupPrefab;

		public Popup twoButtonPopupPrefab;

		protected PresetSelectorLogic<T> presetSelectorLogic;

		protected bool isVR;

		private PopupManager _popupManager;

		protected abstract string LOC_RENAME_PROMPT { get; }

		protected abstract string LOC_DELETE_PROMPT { get; }

		protected virtual string LOC_DELETE_CONFIRM => "scenario/delete_confirm_button";

		protected virtual string LOC_RENAME_CONFIRM => "scenario/rename_confirm_button";

		protected virtual string LOC_CREATE_CONFIRM => "mm/create";

		protected virtual string LOC_GENERIC_CANCEL => "cancel";

		protected virtual string LOC_GENERIC_CONFIRM => "confirm";

		protected abstract string LOC_SAVE_OR_REVERT_PROMPT { get; }

		protected abstract bool HasSaveButton { get; }

		protected abstract bool HasOpenFolderButton { get; }

		protected abstract bool HasDoneButton { get; }

		protected bool IsInitialized { get; set; }

		public abstract T CurrentThing { get; protected set; }

		public abstract IScenarioCRUD CRUD { get; }

		public abstract ObservableCollectionExt<T> Things { get; }

		protected PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		public event Action<T> BackRequested;

		protected abstract void OnPresetSelected(IClickable _, int selectedIndex);

		protected abstract void OnSavePresetClicked();

		protected abstract string GetSuggestedNameForNew();

		protected abstract void CreateNewImpl(string nameToUse);

		protected abstract void DeleteImpl();

		protected abstract void FlushChanges();

		protected abstract string GetTargetFilePath();

		protected abstract bool IsDefaultPresetName(string name);

		protected override void Awake()
		{
			base.Awake();
			if (HasSaveButton)
			{
				NullChecking.NullCheck(savePresetButton, "savePresetButton", this, "Awake");
			}
			if (HasSaveButton)
			{
				NullChecking.NullCheck(twoButtonPopupPrefab, "twoButtonPopupPrefab", this, "Awake");
			}
			if (HasOpenFolderButton)
			{
				NullChecking.NullCheck(openFolderButton, "openFolderButton", this, "Awake");
			}
			if (HasDoneButton)
			{
				NullChecking.NullCheck(doneButton, "doneButton", this, "Awake");
			}
			presetSelectorLogic = GetComponent<PresetSelectorLogic<T>>();
			NullChecking.NullCheck(presetSelectorLogic, "presetSelectorLogic", this, "Awake");
			presetSelectorLogic.SetCallbacks(() => CurrentThing, () => Things, () => CRUD);
		}

		protected virtual void OnEnable()
		{
			RefreshData();
			SetupListeners(on: true);
		}

		protected virtual void OnDisable()
		{
			SetupListeners(on: false);
		}

		public virtual void RefreshData()
		{
			if (!IsInitialized)
			{
				CurrentThing = null;
			}
			else if (Things.Count == 0)
			{
				CurrentThing = null;
			}
			else if (CurrentThing == null || !Things.Contains(CurrentThing))
			{
				int index = Mathf.Clamp(presetSelectorLogic.selector.SelectedIndex, 0, Things.Count - 1);
				CurrentThing = Things[index];
			}
		}

		public virtual void RefreshInterface()
		{
			presetSelectorLogic.RefreshInterface();
		}

		protected virtual void SetupListeners(bool on)
		{
			if (on)
			{
				deletePresetButton.Clicked += OnDeletePresetClicked;
				renamePresetButton.Clicked += OnRenamePresetClicked;
				newPresetButton.Clicked += OnNewPresetClicked;
				presetSelectorLogic.selector.SelectionChanged += OnPresetSelected;
				if (HasSaveButton)
				{
					savePresetButton.onClick.AddListener(OnSavePresetClicked);
				}
				if (HasOpenFolderButton)
				{
					openFolderButton.onClick.AddListener(OnOpenFolderClicked);
				}
				if (HasDoneButton)
				{
					doneButton.onClick.AddListener(OnDoneClicked);
				}
			}
			else
			{
				deletePresetButton.Clicked -= OnDeletePresetClicked;
				renamePresetButton.Clicked -= OnRenamePresetClicked;
				newPresetButton.Clicked -= OnNewPresetClicked;
				presetSelectorLogic.selector.SelectionChanged -= OnPresetSelected;
				if (HasSaveButton)
				{
					savePresetButton.onClick.RemoveListener(OnSavePresetClicked);
				}
				if (HasOpenFolderButton)
				{
					openFolderButton.onClick.RemoveListener(OnOpenFolderClicked);
				}
				if (HasDoneButton)
				{
					doneButton.onClick.RemoveListener(OnDoneClicked);
				}
			}
		}

		private void OnRenamePresetClicked(IClickable _)
		{
			if (CurrentThing != null)
			{
				if (!PopupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = LOC_RENAME_CONFIRM,
					negativeKey = LOC_GENERIC_CANCEL,
					labelKey = LOC_RENAME_PROMPT
				};
				Popup popup = PopupManager.ShowPopup(renamePopupPrefab, locKeys);
				popup.Closed += OnRenamePopupClosed;
				popup.GetComponentInChildren<TMP_InputField>().text = CurrentThing.Name;
			}
		}

		private void OnOpenFolderClicked()
		{
			string targetFilePath = GetTargetFilePath();
			if (!string.IsNullOrEmpty(targetFilePath))
			{
				if (File.Exists(targetFilePath))
				{
					Util.OpenFile(targetFilePath);
				}
				else if (Directory.Exists(targetFilePath))
				{
					Util.OpenFolder(targetFilePath);
				}
				else
				{
					Debug.LogError("Invalid path requested for opening in system file explorer: " + targetFilePath);
				}
			}
		}

		private void OnDeletePresetClicked(IClickable _)
		{
			if (CurrentThing != null)
			{
				if (!PopupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				(PopupLocalizationKeys, Dictionary<string, string>) deletePopupArgs = GetDeletePopupArgs();
				PopupManager.ShowPopup(deletePopupPrefab, deletePopupArgs.Item1, deletePopupArgs.Item2).Closed += OnDeletePopupClosed;
			}
		}

		private void OnRenamePopupClosed(PopupResult result)
		{
			Debug.Log($"\"Rename {typeof(T).Name}\" popup '{result.popup.name}' closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive && !IsDefaultPresetName(result.data))
			{
				CurrentThing.Name = result.data;
				FlushChanges();
				RefreshInterface();
			}
		}

		private void OnDeletePopupClosed(PopupResult result)
		{
			Debug.Log($"\"Delete {typeof(T).Name}\" popup '{result.popup.name}' closed by {result.closedBy}, data: {result.data}");
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				DeleteImpl();
				RefreshData();
			}
		}

		protected virtual (PopupLocalizationKeys keys, Dictionary<string, string> locParams) GetDeletePopupArgs()
		{
			PopupLocalizationKeys item = new PopupLocalizationKeys
			{
				positiveKey = LOC_DELETE_CONFIRM,
				negativeKey = LOC_GENERIC_CANCEL,
				labelKey = LOC_DELETE_PROMPT
			};
			Dictionary<string, string> item2 = new Dictionary<string, string> { { "NAME", CurrentThing.Name } };
			return (keys: item, locParams: item2);
		}

		protected void OnNewPresetClicked(IClickable clickable)
		{
			if (isVR || CurrentThing == null)
			{
				AskToKeepOrRevertIfNeeded().ContinueWith(delegate
				{
					CreateNewImpl(GetSuggestedNameForNew());
					RefreshData();
				}).Forget();
				return;
			}
			AskToKeepOrRevertIfNeeded().ContinueWith(() => UniTask.Delay(50)).ContinueWith((Func<UniTask<string>>)AskToChangeName).ContinueWith(delegate(string nameToUse)
			{
				CreateNewImpl(nameToUse);
				RefreshData();
			})
				.Forget();
		}

		private void OnDoneClicked()
		{
			if (CurrentThing != null)
			{
				this.BackRequested?.Invoke(CurrentThing);
			}
		}

		private UniTask AskToKeepOrRevertIfNeeded()
		{
			IScenariosThing scenariosThing;
			if ((scenariosThing = CurrentThing as IScenariosThing) != null && scenariosThing.SyncState == SyncState.Modified)
			{
				if (!PopupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
					uniTaskCompletionSource.TrySetCanceled();
					return uniTaskCompletionSource.Task;
				}
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = LOC_GENERIC_CONFIRM,
					negativeKey = LOC_GENERIC_CANCEL,
					labelKey = LOC_SAVE_OR_REVERT_PROMPT
				};
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", CurrentThing.Name } };
				Popup createdPopupInstance;
				return PopupManager.ShowPopupAsync(twoButtonPopupPrefab, out createdPopupInstance, locKeys, locParams).ContinueWith(delegate(PopupResult result)
				{
					if (result.closedBy == PopupClosedByAction.Negative)
					{
						scenariosThing.RevertChanges();
					}
					RefreshData();
				});
			}
			return UniTask.CompletedTask;
		}

		private UniTask<string> AskToChangeName()
		{
			if (!PopupManager.CanShowPopup())
			{
				Debug.LogWarning("PopupManager can't show popups at this moment", this);
				UniTaskCompletionSource<string> uniTaskCompletionSource = new UniTaskCompletionSource<string>();
				uniTaskCompletionSource.TrySetCanceled();
				return uniTaskCompletionSource.Task;
			}
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				positiveKey = LOC_CREATE_CONFIRM,
				negativeKey = LOC_GENERIC_CANCEL,
				labelKey = LOC_RENAME_PROMPT
			};
			Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", CurrentThing.Name } };
			Popup createdPopupInstance;
			UniTask<PopupResult> task = PopupManager.ShowPopupAsync(renamePopupPrefab, out createdPopupInstance, locKeys, locParams);
			string suggestedName = GetSuggestedNameForNew();
			createdPopupInstance.GetComponentInChildren<TMP_InputField>().text = suggestedName;
			return task.ContinueWith((PopupResult popupResult) => (popupResult.closedBy == PopupClosedByAction.Positive) ? popupResult.data.Trim() : suggestedName);
		}
	}
}
