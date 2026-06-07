#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Data.UI.Controls;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils;
using Utils.Enums;

namespace Presentation.UI.Controls
{
	public class SettingsRebindActionUI : MonoBehaviour
	{
		private const string OverlayText_LocKey = "RebindSettings.RebindOverlay";

		[Header("UI")]
		[SerializeField]
		private GameObject _rebindOverlay;

		[SerializeField]
		private TMP_Text _rebindText;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private SettingsRebindDatabase _database;

		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[Space]
		[SerializeField]
		private TMP_Text _rebindActionLabel;

		[SerializeField]
		private TMP_Text _bindingText;

		[SerializeField]
		private Button _rebindButton;

		[Space]
		[SerializeField]
		[LocaKey]
		private string _hasDuplicateTitleLocKey;

		[SerializeField]
		[LocaKey]
		private string _hasDuplicateBodyLocKey;

		[SerializeField]
		[LocaKey]
		private string _acceptDuplicateLocKey;

		[SerializeField]
		[LocaKey]
		private string _declineDuplicateLocKey;

		[Header("Alternative Rebind")]
		[SerializeField]
		private GameObject _altRebindContainer;

		[SerializeField]
		private TMP_Text _altBindingText;

		[SerializeField]
		private Button _altRebindButton;

		[Header("Events")]
		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private SettingsRebindEvent _settingRebindStartEvent;

		[SerializeField]
		private SettingsRebindEvent _settingRebindEndEvent;

		private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

		private SettingsRebindAction _rebindAction;

		private SettingsRebindAction _altRebindAction;

		public InputAction Action => _rebindAction.Action;

		private void Start()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_rebindButton.onClick.AddListener(StartInteractiveRebind);
			_altRebindButton.onClick.AddListener(StartInteractiveRebindAlt);
			_resetButton.onClick.AddListener(ResetToDefault);
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
			_rebindButton.onClick.RemoveListener(StartInteractiveRebind);
			_altRebindButton.onClick.RemoveListener(StartInteractiveRebindAlt);
			_resetButton.onClick.RemoveListener(ResetToDefault);
		}

		protected void OnDisable()
		{
			_rebindOperation?.Dispose();
			_rebindOperation = null;
		}

		public void Initialize(SettingsRebindAction rebindAction, SettingsRebindAction altRebindAction = null)
		{
			_rebindAction = rebindAction;
			_altRebindAction = altRebindAction;
			_rebindActionLabel.SetText(rebindAction.Data.GetLocalizedName());
			UpdateBindingDisplay();
		}

		private void OnLanguageUpdate()
		{
			if (_rebindAction != null)
			{
				_rebindActionLabel.SetText(_rebindAction.Data.GetLocalizedName());
			}
		}

		public void UpdateBindingDisplay()
		{
			_bindingText.SetText(_rebindAction.GetBindingString());
			bool flag = _altRebindAction != null;
			_altBindingText.SetText(flag ? _altRebindAction.GetBindingString() : string.Empty);
			_altRebindContainer.SetActive(flag);
			bool flag2 = _rebindAction.HasOverrides();
			bool flag3 = flag && _altRebindAction.HasOverrides();
			_resetButton.gameObject.SetActive(flag2 || flag3);
		}

		public void ResetToDefault()
		{
			_rebindAction.ClearOverrides(out var previousBindingPath, out var previousModifierBindingPath);
			ResolveDuplicates(_rebindAction, previousBindingPath, previousModifierBindingPath);
			if (_altRebindAction != null)
			{
				_altRebindAction.ClearOverrides(out previousBindingPath, out previousModifierBindingPath);
				ResolveDuplicates(_rebindAction, previousBindingPath, previousModifierBindingPath);
			}
			UpdateBindingDisplay();
			_rebindAction.OnChanged(_rebindAction);
			_rebindAction.Data.OnChanged();
			_settingRebindEndEvent.Fire(_rebindAction);
		}

		public void StartInteractiveRebind(SettingsRebindAction rebindAction)
		{
			PerformInteractiveRebind(rebindAction);
		}

		public void StartInteractiveRebind()
		{
			StartInteractiveRebind(_rebindAction);
		}

		public void StartInteractiveRebindAlt()
		{
			StartInteractiveRebind(_altRebindAction);
		}

		private void PerformInteractiveRebind(SettingsRebindAction rebindAction, bool didAssignModifer = false)
		{
			_settingRebindStartEvent.Fire(rebindAction);
			bool wasEnabled = rebindAction.Action.enabled;
			rebindAction.Action.Disable();
			foreach (InputAction duplicateAction in rebindAction.GetDuplicateActions())
			{
				duplicateAction.Disable();
			}
			string effectivePath = rebindAction.Binding.effectivePath;
			string previousModifierBinding = (rebindAction.HasModifier ? rebindAction.ModifierBinding.effectivePath : string.Empty);
			OnInteractiveRebindStart();
			PreformInteractiveRebindInternal(rebindAction, wasEnabled, effectivePath, previousModifierBinding, didAssignModifer);
		}

		private void PreformInteractiveRebindInternal(SettingsRebindAction rebindAction, bool wasEnabled, string previousBinding, string previousModifierBinding, bool didAssignModifer = false)
		{
			if (_rebindOperation != null && !_rebindOperation.completed)
			{
				_rebindOperation.Cancel();
			}
			_rebindOperation?.Dispose();
			_rebindOperation = rebindAction.PerformInteractiveRebinding().WithCancelingThrough(_database.CancelBindingPaths[0]).OnCancel(delegate
			{
				OnInteractiveRebindCancel(rebindAction, wasEnabled, previousModifierBinding);
			})
				.OnComplete(delegate
				{
					OnInteractiveRebindComplete(rebindAction, wasEnabled, didAssignModifer, previousBinding, previousModifierBinding);
				});
			_rebindOperation.Start();
		}

		private void OnInteractiveRebindStart()
		{
			if (_rebindOverlay != null)
			{
				_rebindOverlay.SetActive(value: true);
			}
			if (_rebindText != null)
			{
				_rebindText.SetText(LocalizationUtility.GetLocalizedText("RebindSettings.RebindOverlay"));
			}
		}

		private void OnInteractiveRebindCancel(SettingsRebindAction rebindAction, bool wasEnabled, string previousModifierBinding)
		{
			if (rebindAction.HasModifier)
			{
				rebindAction.ApplyModifierOverride(previousModifierBinding);
			}
			_rebindOverlay.SetActive(value: false);
			UpdateBindingDisplay();
			OnInteractiveRebindFinished(rebindAction, wasEnabled);
		}

		private void OnInteractiveRebindComplete(SettingsRebindAction rebindAction, bool doEnable, bool didAssignModifer, string previousBinding, string previousModifierBinding)
		{
			for (int i = 1; i < _database.CancelBindingPaths.Length; i++)
			{
				if (!(_database.CancelBindingPaths[i] != rebindAction.Binding.effectivePath))
				{
					rebindAction.ApplyOverride(previousBinding);
					OnInteractiveRebindCancel(rebindAction, doEnable, previousModifierBinding);
					return;
				}
			}
			string value;
			if (ShouldClearNewBinding(rebindAction.Binding))
			{
				this.Log("Clear New Input Binding", "OnInteractiveRebindComplete", 200);
				rebindAction.ApplyOverrideUnbound();
			}
			else if (_database.BindingPathReplacers.TryGetValue(rebindAction.Binding.effectivePath, out value))
			{
				rebindAction.ApplyOverride(value);
			}
			if (IsNewBindingAModifier(rebindAction.Binding))
			{
				if (!rebindAction.HasModifier)
				{
					rebindAction.ApplyOverride(previousBinding);
					PreformInteractiveRebindInternal(rebindAction, doEnable, previousBinding, previousModifierBinding);
				}
				else
				{
					rebindAction.ApplyModifierOverride(rebindAction.Binding);
					rebindAction.ApplyOverride(string.Empty);
					PreformInteractiveRebindInternal(rebindAction, doEnable, previousBinding, previousModifierBinding, didAssignModifer: true);
				}
				return;
			}
			if (!didAssignModifer && rebindAction.HasModifier)
			{
				rebindAction.ApplyModifierOverride(rebindAction.Binding);
			}
			_rebindOverlay.SetActive(value: false);
			UpdateBindingDisplay();
			OnInteractiveRebindFinished(rebindAction, doEnable);
			ResolveDuplicates(rebindAction, previousBinding, previousModifierBinding);
		}

		private bool ResolveDuplicates(SettingsRebindAction rebindAction, string previousBinding, string previousModifierBinding)
		{
			if (!HasDuplicateBindings(rebindAction, out var overlappingBindings))
			{
				return false;
			}
			MenuModalDialogDto menuModalDialogDto = new MenuModalDialogDto(_hasDuplicateTitleLocKey, _hasDuplicateBodyLocKey, Sizes.M, delegate
			{
				OnAcceptDuplicate(overlappingBindings);
			}, showCancelButton: true, delegate
			{
				OnDeclineDuplicate(rebindAction, previousBinding, previousModifierBinding);
			})
			{
				OverrideSuccessButtonTextKey = _acceptDuplicateLocKey,
				OverrideCancelButtonTextKey = _declineDuplicateLocKey
			};
			menuModalDialogDto.Text = string.Format(menuModalDialogDto.Text, rebindAction.Data.GetLocalizedName(), overlappingBindings[0].Data.GetLocalizedName());
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(menuModalDialogDto));
			return true;
		}

		private void OnAcceptDuplicate(List<SettingsRebindAction> overlappingRebinds)
		{
			foreach (SettingsRebindAction overlappingRebind in overlappingRebinds)
			{
				overlappingRebind.ApplyOverrideUnbound();
				overlappingRebind.OnChanged(overlappingRebind);
				overlappingRebind.Data.OnChanged();
				_settingRebindEndEvent.Fire(overlappingRebind);
			}
		}

		private void OnDeclineDuplicate(SettingsRebindAction rebindAction, string previousBinding, string modifierPreviousBinding)
		{
			rebindAction.ApplyOverride(previousBinding);
			if (rebindAction.HasModifier)
			{
				rebindAction.ApplyModifierOverride(modifierPreviousBinding);
				rebindAction.OnChanged(rebindAction);
				rebindAction.Data.OnChanged();
				_settingRebindEndEvent.Fire(rebindAction);
			}
		}

		private void OnInteractiveRebindFinished(SettingsRebindAction rebindAction, bool wasEnabled)
		{
			_rebindOperation?.Dispose();
			_rebindOperation = null;
			if (wasEnabled)
			{
				rebindAction.Action.Enable();
				foreach (InputAction duplicateAction in rebindAction.GetDuplicateActions())
				{
					duplicateAction.Enable();
				}
			}
			rebindAction.ApplyOverrideToDuplicateAction();
			rebindAction.OnChanged(rebindAction);
			rebindAction.Data.OnChanged();
			_settingRebindEndEvent.Fire(rebindAction);
		}

		private bool HasDuplicateBindings(SettingsRebindAction rebindAction, out List<SettingsRebindAction> overlappingRebinds)
		{
			overlappingRebinds = new List<SettingsRebindAction>();
			InputBinding binding = rebindAction.Binding;
			if (string.IsNullOrEmpty(binding.effectivePath))
			{
				return false;
			}
			string text = (rebindAction.IsModifierUnbound() ? string.Empty : rebindAction.ModifierBinding.effectivePath);
			if (!_rebindInfo.TryGetConflictGroups(rebindAction.Group, out var conflictGroups))
			{
				return false;
			}
			foreach (SettingsRebindGroup item in conflictGroups)
			{
				if (!_rebindInfo.TryGetRebindActions(item, out var rebindActions))
				{
					continue;
				}
				foreach (SettingsRebindAction item2 in rebindActions)
				{
					if ((!(rebindAction.Action.id == item2.Action.id) || rebindAction.BindingIndex != item2.BindingIndex) && rebindAction.Data.IsHoldAction == item2.Data.IsHoldAction && !(item2.Binding.effectivePath != binding.effectivePath) && !((item2.IsModifierUnbound() ? string.Empty : item2.ModifierBinding.effectivePath) != text))
					{
						this.Log("Duplicate binding found: " + binding.effectivePath, "HasDuplicateBindings", 352);
						overlappingRebinds.Add(item2);
					}
				}
			}
			return overlappingRebinds.Count > 0;
		}

		private bool ShouldClearNewBinding(InputBinding binding)
		{
			string[] clearBindingPaths = _database.ClearBindingPaths;
			foreach (string text in clearBindingPaths)
			{
				if (binding.effectivePath == text)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsNewBindingAModifier(InputBinding binding)
		{
			foreach (string allModifierBindingPath in _database.GetAllModifierBindingPaths())
			{
				if (binding.effectivePath == allModifierBindingPath)
				{
					return true;
				}
			}
			return false;
		}
	}
}
