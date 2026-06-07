using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Cysharp.Threading.Tasks;
using DV.Common;
using DV.Scenarios.Common;
using DV.UIFramework;
using DV.Util;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public abstract class PresetSelectorLogic<T> : ASelectorLogic, IUIMenuSwitchPreventer where T : class, IThing
	{
		[Header("References")]
		public Popup popupPrefab;

		public bool needsPopup = true;

		public ButtonDV saveButton;

		public ButtonDV deleteButton;

		public ButtonDV renameButton;

		public bool hasSaveButton = true;

		public bool hasDeleteAndRenameButtons = true;

		private Func<T> GetCurrent;

		private Func<ObservableCollectionExt<T>> GetAll;

		private Func<IScenarioCRUD> CRUD;

		private TMProAddMark labelMark;

		private UniTaskCompletionSource menuSwitchRequest;

		private PopupManager _popupManager;

		protected abstract string LOC_NO_ELEMENTS { get; }

		protected abstract string LOC_SAVE_OR_REVERT_PROMPT { get; }

		protected string LOC_GENERIC_SAVE => "save";

		protected string LOC_GENERIC_DISCARD => "discard";

		protected string LOC_GENERIC_CANCEL => "cancel";

		private bool HasCurrent
		{
			get
			{
				if (GetCurrent != null)
				{
					return GetCurrent() != null;
				}
				return false;
			}
		}

		private bool HasElements
		{
			get
			{
				if (GetAll != null && GetAll() != null)
				{
					return GetAll().Count > 0;
				}
				return false;
			}
		}

		private IThing CurrentThing => HasCurrent ? GetCurrent() : null;

		private bool IsReadOnly
		{
			get
			{
				if (CurrentThing is IScenariosThing scenariosThing)
				{
					return scenariosThing.IsReadOnly;
				}
				return false;
			}
		}

		private bool ShouldShowPopup
		{
			get
			{
				if (needsPopup && CurrentThing is IScenariosThing scenariosThing)
				{
					return scenariosThing.SyncState != SyncState.Synced;
				}
				return false;
			}
		}

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		protected override void Awake()
		{
			base.Awake();
			if (needsPopup)
			{
				NullChecking.NullCheck(popupPrefab, "popupPrefab", this, "Awake");
			}
			if (hasSaveButton)
			{
				NullChecking.NullCheck(saveButton, "saveButton", this, "Awake");
			}
			if (hasDeleteAndRenameButtons)
			{
				NullChecking.NullCheck(deleteButton, "deleteButton", this, "Awake");
				NullChecking.NullCheck(renameButton, "renameButton", this, "Awake");
			}
			labelMark = selector.GetLabelTMPro().gameObject.AddComponent<TMProAddMark>();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			selector.AboutToChangeSelection += OnAboutToChangeSelection;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			selector.AboutToChangeSelection -= OnAboutToChangeSelection;
		}

		public void SetCallbacks(Func<T> GetCurrent, Func<ObservableCollectionExt<T>> GetAll, Func<IScenarioCRUD> CRUD)
		{
			this.GetCurrent = GetCurrent;
			this.GetAll = GetAll;
			this.CRUD = CRUD;
		}

		public void RefreshInterface()
		{
			if (!HasCurrent || !HasElements)
			{
				selector.LocalizedValues = true;
				selector.SetValues(new List<string> { LOC_NO_ELEMENTS });
				selector.SetSelectedIndex(0, fireEvent: false);
				selector.ToggleInteractable(newInteractable: false);
				labelMark.ClearMark();
				if ((bool)saveButton)
				{
					saveButton.ToggleInteractable(newInteractable: false);
				}
				if ((bool)deleteButton)
				{
					deleteButton.ToggleInteractable(newInteractable: false);
				}
				if ((bool)renameButton)
				{
					renameButton.ToggleInteractable(newInteractable: false);
				}
				return;
			}
			T val = GetCurrent();
			ObservableCollectionExt<T> observableCollectionExt = GetAll();
			selector.LocalizedValues = false;
			selector.SetValues(Enumerable.Select(observableCollectionExt, ProcessName).ToList());
			int index = ((val != null) ? observableCollectionExt.IndexOf(val) : 0);
			selector.SetSelectedIndex(index, fireEvent: false);
			selector.ToggleInteractable(observableCollectionExt.Count > 1);
			labelMark.SetMark(GetMark(val));
			if ((bool)saveButton)
			{
				saveButton.ToggleInteractable(!IsReadOnly);
			}
			if ((bool)deleteButton)
			{
				deleteButton.ToggleInteractable(!IsReadOnly);
			}
			if ((bool)renameButton)
			{
				renameButton.ToggleInteractable(!IsReadOnly);
			}
		}

		protected abstract string ProcessName(T thing);

		private static string GetMark(T thing)
		{
			if (thing is IScenariosThing scenariosThing)
			{
				switch (scenariosThing.SyncState)
				{
				case SyncState.Fresh:
					return "+";
				case SyncState.Modified:
					return "*";
				case SyncState.Synced:
					return "";
				case SyncState.Deleted:
					return "?";
				default:
					UnityEngine.Debug.LogWarning($"Unexpected value {scenariosThing.SyncState}");
					return "";
				}
			}
			return "";
		}

		protected override void OnSelectionChanged(IClickable clickable, int selectedIndex)
		{
		}

		private void OnAboutToChangeSelection(IClickable clickable, int selectedIndex, CancelEventArgs cancelEventArgs)
		{
			if (ShouldShowPopup)
			{
				cancelEventArgs.Cancel = true;
				try
				{
					OpenPopup(CurrentThing as IScenariosThing, selectedIndex);
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
				}
			}
		}

		public UniTask RequestSwitch()
		{
			menuSwitchRequest = null;
			if (ShouldShowPopup)
			{
				menuSwitchRequest = new UniTaskCompletionSource();
				try
				{
					OpenPopup(CurrentThing as IScenariosThing, -1);
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
				}
				return menuSwitchRequest.Task;
			}
			return UniTask.FromResult(value: true);
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		private void OpenPopup(IScenariosThing thing, int requestedIndex)
		{
			if (!PopupManager.CanShowPopup())
			{
				UnityEngine.Debug.LogWarning("PopupManager can't show popups at this moment", this);
				return;
			}
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				labelKey = LOC_SAVE_OR_REVERT_PROMPT,
				positiveKey = LOC_GENERIC_SAVE,
				negativeKey = LOC_GENERIC_DISCARD,
				abortionKey = LOC_GENERIC_CANCEL
			};
			Dictionary<string, string> locParams = new Dictionary<string, string> { { "NAME", CurrentThing.Name } };
			PopupManager.ShowPopup(popupPrefab, locKeys, locParams).Closed += delegate(PopupResult result)
			{
				switch (result.closedBy)
				{
				case PopupClosedByAction.Abortion:
					if (menuSwitchRequest != null)
					{
						menuSwitchRequest.TrySetCanceled();
					}
					break;
				case PopupClosedByAction.Positive:
					CRUD().Flush();
					if (requestedIndex >= 0)
					{
						selector.SetSelectedIndex(requestedIndex);
					}
					if (menuSwitchRequest != null)
					{
						menuSwitchRequest.TrySetResult();
					}
					break;
				case PopupClosedByAction.Negative:
					thing.RevertChanges();
					if (requestedIndex >= 0)
					{
						selector.SetSelectedIndex(requestedIndex);
					}
					if (menuSwitchRequest != null)
					{
						menuSwitchRequest.TrySetResult();
					}
					break;
				}
				menuSwitchRequest = null;
			};
		}

		[Conditional("UNITY_EDITOR")]
		private void EditorLog(string message, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.Log(message, context);
		}

		[Conditional("UNITY_EDITOR")]
		private void EditorLogError(string message, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogError(message, context);
		}
	}
}
