using System;
using CTS;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RebindAction : MonoBehaviour
{
	[Serializable]
	public class UpdateBindingUIEvent : UnityEvent<RebindAction, string, string, string>
	{
	}

	[Serializable]
	public class InteractiveRebindEvent : UnityEvent<RebindAction, InputActionRebindingExtensions.RebindingOperation>
	{
	}

	[SerializeField]
	private InputActionReference _action;

	[SerializeField]
	private string _bindingId;

	[SerializeField]
	private InputBinding.DisplayStringOptions _displayStringOptions;

	[SerializeField]
	[Tooltip("Indique si cette touche est une option secondaire vide.")]
	private bool _isTheEmptyPlaceholder;

	[SerializeField]
	private TMP_Text _bindingText;

	[SerializeField]
	private GameObject _rebindOverlay;

	[SerializeField]
	private GameObject _errorOverlay;

	[SerializeField]
	private UpdateBindingUIEvent _updateBindingUIEvent;

	[SerializeField]
	private InteractiveRebindEvent _rebindStartEvent;

	[SerializeField]
	private InteractiveRebindEvent _rebindStopEvent;

	private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

	private InputBinding _lastBindingIndex;

	private string _bindingIndex;

	public void StartInteractiveRebind()
	{
		if (ResolveActionAndBinding(out var action, out var bindingIndex))
		{
			_bindingIndex = action.bindings[bindingIndex].effectivePath;
			PerformInteractiveRebind(action, bindingIndex);
		}
	}

	public void ResetToDefault(bool needTheLast)
	{
		if (ResolveActionAndBinding(out var action, out var bindingIndex))
		{
			action.RemoveBindingOverride(bindingIndex);
			if (needTheLast && !string.IsNullOrEmpty(_bindingIndex))
			{
				action.ApplyBindingOverride(bindingIndex, _bindingIndex);
				Debug.Log("Dernier binding restauré : " + _bindingIndex);
			}
			else
			{
				action.RemoveBindingOverride(bindingIndex);
				Debug.Log("Binding réinitialisé à la valeur par défaut.");
			}
			UpdateBindingDisplay();
		}
	}

	public void UpdateBindingDisplay()
	{
		InputAction inputAction = _action?.action;
		if (inputAction == null || string.IsNullOrEmpty(_bindingId))
		{
			if (_bindingText != null)
			{
				_bindingText.text = "N/A";
			}
			return;
		}
		int bindingIndex = GetBindingIndex(inputAction, _bindingId);
		if (bindingIndex == -1)
		{
			if (_bindingText != null)
			{
				_bindingText.text = "N/A";
			}
			return;
		}
		string bindingDisplayString = inputAction.GetBindingDisplayString(bindingIndex, _displayStringOptions);
		if (_bindingText != null)
		{
			_bindingText.text = bindingDisplayString;
		}
		_updateBindingUIEvent?.Invoke(this, bindingDisplayString, null, null);
	}

	private bool ResolveActionAndBinding(out InputAction action, out int bindingIndex)
	{
		action = _action?.action;
		bindingIndex = -1;
		if (action == null || string.IsNullOrEmpty(_bindingId))
		{
			return false;
		}
		bindingIndex = GetBindingIndex(action, _bindingId);
		return bindingIndex != -1;
	}

	private int GetBindingIndex(InputAction action, string bindingId)
	{
		Guid guid = new Guid(bindingId);
		for (int i = 0; i < action.bindings.Count; i++)
		{
			if (action.bindings[i].id == guid)
			{
				return i;
			}
		}
		return -1;
	}

	private void PerformInteractiveRebind(InputAction action, int bindingIndex)
	{
		_rebindOperation?.Cancel();
		action.Disable();
		_rebindOperation = action.PerformInteractiveRebinding(bindingIndex).WithTargetBinding(bindingIndex).WithCancelingThrough("<Keyboard>/escape")
			.OnPotentialMatch(delegate(InputActionRebindingExtensions.RebindingOperation operation)
			{
				string path = operation.selectedControl.path;
				if (path == "/Mouse/press" || path == "/Mouse/leftButton")
				{
					operation.Cancel();
				}
			})
			.OnCancel(delegate
			{
				EventSystem.current.SetSelectedGameObject(null);
				HandleRebindCancel(action);
			})
			.OnComplete(delegate
			{
				EventSystem.current.SetSelectedGameObject(null);
				HandleRebindComplete(action, bindingIndex);
			});
		ShowRebindOverlay(show: true);
		_rebindOperation.Start();
	}

	private void HandleRebindCancel(InputAction action)
	{
		action.Enable();
		ShowRebindOverlay(show: false);
		_rebindOperation?.Dispose();
		_rebindOperation = null;
	}

	private void HandleRebindComplete(InputAction action, int bindingIndex)
	{
		action.Enable();
		ShowRebindOverlay(show: false);
		if (IsBindingDuplicate(action, bindingIndex))
		{
			ResetToDefault(needTheLast: true);
		}
		else
		{
			UpdateBindingDisplay();
		}
		_rebindOperation?.Dispose();
		_rebindOperation = null;
	}

	private bool IsBindingDuplicate(InputAction action, int bindingIndex)
	{
		string effectivePath = action.bindings[bindingIndex].effectivePath;
		foreach (InputBinding binding in action.actionMap.bindings)
		{
			if (binding.id == action.bindings[bindingIndex].id || !(binding.effectivePath == effectivePath))
			{
				continue;
			}
			_ = binding.action;
			if (_errorOverlay != null)
			{
				UI_RebindError component = _errorOverlay.GetComponent<UI_RebindError>();
				if (component != null)
				{
					component.StartShowText(Color.red);
				}
			}
			_rebindOperation.Cancel();
			ResetToDefault(needTheLast: true);
			return true;
		}
		return false;
	}

	private void ShowRebindOverlay(bool show)
	{
		if (_rebindOverlay != null)
		{
			_rebindOverlay.SetActive(show);
		}
	}

	private void ShowError(string message)
	{
	}

	private void Awake()
	{
		UISettingControl.Reset += ResetTheTouch;
	}

	private void ResetTheTouch()
	{
		ResetToDefault(needTheLast: false);
	}

	private void OnDestroy()
	{
		UISettingControl.Reset -= ResetTheTouch;
	}

	private void OnEnable()
	{
		UpdateBindingDisplay();
	}

	private void OnDisable()
	{
		_rebindOperation?.Dispose();
		_rebindOperation = null;
	}
}
