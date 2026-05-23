using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Utils;

namespace Data.UI.Controls
{
	public class SettingsRebindAction
	{
		private readonly SettingsRebindActionData _data;

		private readonly SettingsRebindGroup _group;

		private readonly SettingsRebindDatabase _database;

		private readonly bool _isAlt;

		private SettingsRebindAction _siblingRebindAction;

		private Guid _bindingId;

		private int _bindingIndex;

		private Guid _modiferBindingId;

		private int _modiferBindingIndex;

		private readonly List<object> _disableCount = new List<object>();

		public Action<SettingsRebindAction> OnChanged = delegate
		{
		};

		public InputAction Action => _data.Action.action;

		public InputActionReference ActionReference => _data.Action;

		public SettingsRebindActionData Data => _data;

		public SettingsRebindGroup Group => _group;

		public SettingsRebindAction SiblingRebindAction => _siblingRebindAction;

		public bool HasModifier => _modiferBindingIndex != -1;

		public bool IsAlt => _isAlt;

		public int BindingIndex => _bindingIndex;

		public InputBinding Binding => Action.bindings[_bindingIndex];

		public InputBinding ModifierBinding => Action.bindings[_modiferBindingIndex];

		public bool IsUnbound()
		{
			return string.IsNullOrEmpty(Binding.effectivePath);
		}

		public bool IsModifierUnbound()
		{
			if (HasModifier && !string.IsNullOrEmpty(ModifierBinding.effectivePath))
			{
				return ModifierBinding.effectivePath == Binding.effectivePath;
			}
			return true;
		}

		public SettingsRebindAction(SettingsRebindActionData data, SettingsRebindGroup group, SettingsRebindDatabase database, bool isAlt)
		{
			_data = data;
			_group = group;
			_database = database;
			_isAlt = isAlt;
			if (isAlt)
			{
				InitalizeBindings(data.AltBindingId, data.AltModifierBindingId);
			}
			else
			{
				InitalizeBindings(data.BindingId, data.ModifierBindingId);
			}
		}

		public IEnumerable<InputAction> GetDuplicateActions()
		{
			foreach (InputActionReference hiddenDuplicateAction in _data.HiddenDuplicateActions)
			{
				yield return hiddenDuplicateAction.action;
			}
		}

		public void SetSiblingRebind(SettingsRebindAction siblingRebindAction)
		{
			_siblingRebindAction = siblingRebindAction;
		}

		public InputActionRebindingExtensions.RebindingOperation PerformInteractiveRebinding()
		{
			return Action.PerformInteractiveRebinding(_bindingIndex);
		}

		public string GetBindingString(bool omitModifier = false)
		{
			return GetBindingStringColouredInternal(_database.DisplayStringOptions, omitModifier);
		}

		public string GetBindingLongString()
		{
			return GetBindingStringColouredInternal(_database.DisplayFullStringOptions);
		}

		public bool HasOverrides()
		{
			if (!BindingHasOverrides(Action.bindings[_bindingIndex]))
			{
				if (HasModifier)
				{
					return BindingHasOverrides(Action.bindings[_modiferBindingIndex]);
				}
				return false;
			}
			return true;
		}

		public void ClearOverrides(out string previousBindingPath, out string previousModifierBindingPath)
		{
			previousBindingPath = Action.bindings[_bindingIndex].effectivePath;
			Action.RemoveBindingOverride(_bindingIndex);
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.RemoveBindingOverride(_bindingIndex);
			}
			if (!HasModifier)
			{
				previousModifierBindingPath = string.Empty;
				return;
			}
			previousModifierBindingPath = Action.bindings[_modiferBindingIndex].effectivePath;
			Action.RemoveBindingOverride(_modiferBindingIndex);
			foreach (InputAction duplicateAction2 in GetDuplicateActions())
			{
				duplicateAction2.RemoveBindingOverride(_modiferBindingIndex);
			}
		}

		public void ApplyOverrideUnbound()
		{
			ApplyOverride(string.Empty);
			if (HasModifier)
			{
				ApplyModifierOverride(string.Empty);
			}
		}

		public void ApplyOverride(string bindingPath)
		{
			Action.ApplyBindingOverride(_bindingIndex, bindingPath);
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.ApplyBindingOverride(_bindingIndex, bindingPath);
			}
		}

		public void ApplyOverride(InputBinding binding)
		{
			Action.ApplyBindingOverride(_bindingIndex, binding);
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.ApplyBindingOverride(_bindingIndex, binding);
			}
		}

		public void ApplyOverrideToDuplicateAction()
		{
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.ApplyBindingOverride(_bindingIndex, Binding);
			}
		}

		public void ApplyModifierOverride(string bindingPath)
		{
			Action.ApplyBindingOverride(_modiferBindingIndex, bindingPath);
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.ApplyBindingOverride(_modiferBindingIndex, bindingPath);
			}
		}

		public void ApplyModifierOverride(InputBinding binding)
		{
			Action.ApplyBindingOverride(_modiferBindingIndex, binding);
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.ApplyBindingOverride(_modiferBindingIndex, binding);
			}
		}

		private string GetBindingStringInternal(InputBinding.DisplayStringOptions options, bool omitModifier = false)
		{
			string deviceLayoutName;
			string controlPath;
			string bindingDisplayString = Action.GetBindingDisplayString(_bindingIndex, out deviceLayoutName, out controlPath, options);
			if (omitModifier || IsModifierUnbound())
			{
				return bindingDisplayString;
			}
			return Action.GetBindingDisplayString(_modiferBindingIndex, out controlPath, out deviceLayoutName, options) + "+" + bindingDisplayString;
		}

		private string GetBindingStringColouredInternal(InputBinding.DisplayStringOptions options, bool omitModifier = false)
		{
			string text = GetBindingStringInternal(options, omitModifier);
			if (!IsModifierUnbound() && _database.TryGetModifierColour(ModifierBinding.effectivePath, out var colour))
			{
				text = DebugUtils.ColourString(text, colour);
			}
			return text;
		}

		private static bool BindingHasOverrides(InputBinding binding)
		{
			if (binding.hasOverrides)
			{
				return binding.overridePath != binding.path;
			}
			return false;
		}

		private void InitalizeBindings(string bindingId, string modifierBindingId)
		{
			_bindingId = new Guid(bindingId);
			_bindingIndex = Action.bindings.IndexOf((InputBinding x) => x.id == _bindingId);
			if (string.IsNullOrEmpty(modifierBindingId))
			{
				_modiferBindingId = default(Guid);
				_modiferBindingIndex = -1;
				return;
			}
			_modiferBindingId = new Guid(modifierBindingId);
			_modiferBindingIndex = Action.bindings.IndexOf((InputBinding x) => x.id == _modiferBindingId);
		}

		public void Disable(object handle)
		{
			if (_disableCount.Contains(handle))
			{
				return;
			}
			_disableCount.Add(handle);
			Action.Disable();
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.Disable();
			}
		}

		public void RemoveDisable(object handle)
		{
			if (!_disableCount.Contains(handle))
			{
				return;
			}
			_disableCount.Remove(handle);
			if (_disableCount.Count > 0 || !Action.actionMap.enabled)
			{
				return;
			}
			Action.Enable();
			foreach (InputAction duplicateAction in GetDuplicateActions())
			{
				duplicateAction.Enable();
			}
		}
	}
}
