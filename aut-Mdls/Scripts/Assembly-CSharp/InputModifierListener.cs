#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.UI.Controls;
using UnityEngine.InputSystem;
using Utils;

public class InputModifierListener
{
	private readonly InputAction[] _modifierActions;

	private readonly List<SettingsRebindAction>[] _actionsWithModifier;

	private readonly List<SettingsRebindAction> _matchingActions = new List<SettingsRebindAction>();

	private bool _modifierIsPressed;

	public InputModifierListener(InputAction[] modifierActions)
	{
		_modifierActions = modifierActions;
		_actionsWithModifier = new List<SettingsRebindAction>[modifierActions.Length];
		for (int i = 0; i < modifierActions.Length; i++)
		{
			_actionsWithModifier[i] = new List<SettingsRebindAction>();
		}
	}

	public void CleanUp()
	{
		if (_modifierIsPressed)
		{
			foreach (SettingsRebindAction matchingAction in _matchingActions)
			{
				matchingAction.RemoveDisable(this);
			}
		}
		_matchingActions.Clear();
		for (int i = 0; i < _modifierActions.Length; i++)
		{
			if (_actionsWithModifier[i].Count != 0)
			{
				_actionsWithModifier[i].Clear();
				_modifierActions[i].performed -= OnModifierPerformed;
				_modifierActions[i].canceled -= OnModifierCanceled;
			}
		}
	}

	private void OnModifierPerformed(InputAction.CallbackContext context)
	{
		_modifierIsPressed = true;
		foreach (SettingsRebindAction matchingAction in _matchingActions)
		{
			matchingAction.Disable(this);
		}
	}

	private void OnModifierCanceled(InputAction.CallbackContext context)
	{
		for (int i = 0; i < _modifierActions.Length; i++)
		{
			if (_actionsWithModifier[i].Count > 0 && _modifierActions[i].IsPressed())
			{
				_modifierIsPressed = true;
				return;
			}
		}
		_modifierIsPressed = false;
		foreach (SettingsRebindAction matchingAction in _matchingActions)
		{
			matchingAction.RemoveDisable(this);
		}
	}

	public void Add(SettingsRebindAction action)
	{
		action.OnChanged = (Action<SettingsRebindAction>)Delegate.Combine(action.OnChanged, new Action<SettingsRebindAction>(OnActionChanged));
		if (action.IsModifierUnbound())
		{
			_matchingActions.Add(action);
			return;
		}
		for (int i = 0; i < _modifierActions.Length; i++)
		{
			if (!(_modifierActions[i].bindings[0].effectivePath != action.ModifierBinding.effectivePath))
			{
				if (_actionsWithModifier[i].Count == 0)
				{
					_modifierActions[i].performed += OnModifierPerformed;
					_modifierActions[i].canceled += OnModifierCanceled;
				}
				_actionsWithModifier[i].Add(action);
				return;
			}
		}
		this.LogError("Failed to handle modifier binding \"" + action.ModifierBinding.effectivePath + "\" for the action \"" + action.Action.name + "\"", "Add", 95);
	}

	public void Remove(SettingsRebindAction action)
	{
		if (_matchingActions.Contains(action))
		{
			action.RemoveDisable(this);
			_matchingActions.Remove(action);
			return;
		}
		for (int i = 0; i < _modifierActions.Length; i++)
		{
			if (_actionsWithModifier[i].Contains(action))
			{
				_actionsWithModifier[i].Remove(action);
				if (_actionsWithModifier[i].Count == 0)
				{
					_modifierActions[i].performed -= OnModifierPerformed;
					_modifierActions[i].canceled -= OnModifierCanceled;
				}
				return;
			}
		}
		this.LogError($"Failed to handle action id \"{action.Action.id}\" for the action \"{action.Action.name}\"", "Remove", 122);
	}

	private void OnActionChanged(SettingsRebindAction action)
	{
		action.OnChanged = (Action<SettingsRebindAction>)Delegate.Remove(action.OnChanged, new Action<SettingsRebindAction>(OnActionChanged));
		Remove(action);
	}

	public void OnApplicationFocus(bool hasFocus)
	{
		if (!hasFocus && _modifierIsPressed)
		{
			OnModifierCanceled(default(InputAction.CallbackContext));
		}
	}
}
