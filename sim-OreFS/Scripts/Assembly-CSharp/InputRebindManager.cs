using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kamgam.SettingsGenerator;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputRebindManager : MonoBehaviour
{
	[Header("References")]
	[Tooltip("The TabManagerUGUI component on the settings panel.")]
	public TabManagerUGUI tabManager;

	[Tooltip("The InputActionAsset to disable during rebinding.")]
	public InputActionAsset inputActionAsset;

	[Header("Duplicate Key Prevention")]
	[Tooltip("The SettingsProvider to read all input binding settings from.")]
	public SettingsProvider settingsProvider;

	[Tooltip("If true, prevents assigning the same key to multiple actions by swapping.")]
	public bool preventDuplicateBindings = true;

	[Header("Auto-Detect")]
	[Tooltip("If true, automatically finds all InputBindingUGUI components in children.")]
	public bool autoDetectBindings = true;

	private List<InputBindingUGUI> allBindings = new List<InputBindingUGUI>();

	private InputBindingUGUI activeBinding;

	private string previousPath;

	private bool isBlocked;

	private void OnEnable()
	{
		if (autoDetectBindings)
		{
			allBindings = GetComponentsInChildren<InputBindingUGUI>(includeInactive: true).ToList();
		}
		foreach (InputBindingUGUI allBinding in allBindings)
		{
			InputBindingUGUI captured = allBinding;
			if (captured.Button != null)
			{
				for (int i = 0; i < captured.Button.onClick.GetPersistentEventCount(); i++)
				{
					captured.Button.onClick.SetPersistentListenerState(i, UnityEventCallState.Off);
				}
				captured.Button.onClick.AddListener(delegate
				{
					if (inputActionAsset != null)
					{
						inputActionAsset.Disable();
					}
					OnRebindStarted(captured);
					captured.SetActive(active: true);
				});
			}
			InputBindingUGUI inputBindingUGUI = captured;
			inputBindingUGUI.OnChanged = (InputBindingUGUI.OnChangedDelegate)Delegate.Combine(inputBindingUGUI.OnChanged, new InputBindingUGUI.OnChangedDelegate(OnBindingChanged));
		}
	}

	private void OnDisable()
	{
		if (isBlocked)
		{
			BlockUIInteractions(block: false);
			EnableInputActions();
		}
		activeBinding = null;
		foreach (InputBindingUGUI allBinding in allBindings)
		{
			if (!(allBinding == null))
			{
				if (allBinding.Button != null)
				{
					allBinding.Button.onClick.RemoveAllListeners();
				}
				allBinding.OnChanged = (InputBindingUGUI.OnChangedDelegate)Delegate.Remove(allBinding.OnChanged, new InputBindingUGUI.OnChangedDelegate(OnBindingChanged));
			}
		}
	}

	private void OnRebindStarted(InputBindingUGUI binding)
	{
		activeBinding = binding;
		previousPath = binding.InputBinding.GetBindingPath();
		BlockUIInteractions(block: true);
	}

	private void OnBindingChanged(string newPath)
	{
		if (activeBinding != null && preventDuplicateBindings && !string.IsNullOrEmpty(newPath))
		{
			CheckAndSwapDuplicate(activeBinding, newPath);
		}
		activeBinding = null;
		previousPath = null;
		BlockUIInteractions(block: false);
		StartCoroutine(EnableInputActionsDelayed());
	}

	private void Update()
	{
		if (activeBinding != null && !activeBinding.IsActive)
		{
			activeBinding = null;
			previousPath = null;
			BlockUIInteractions(block: false);
			StartCoroutine(EnableInputActionsDelayed());
		}
	}

	private void EnableInputActions()
	{
		if (inputActionAsset != null)
		{
			inputActionAsset.Enable();
		}
	}

	private IEnumerator EnableInputActionsDelayed()
	{
		yield return null;
		EnableInputActions();
	}

	private void BlockUIInteractions(bool block)
	{
		if (isBlocked == block)
		{
			return;
		}
		isBlocked = block;
		if (tabManager != null)
		{
			tabManager.enabled = !block;
		}
		foreach (InputBindingUGUI allBinding in allBindings)
		{
			if (!(allBinding == activeBinding) && allBinding.Button != null)
			{
				allBinding.Button.interactable = !block;
			}
		}
	}

	private void CheckAndSwapDuplicate(InputBindingUGUI changedBinding, string newPath)
	{
		if (settingsProvider == null || settingsProvider.Settings == null || changedBinding.GetComponent<InputBindingUGUIResolver>() == null)
		{
			return;
		}
		foreach (InputBindingUGUI allBinding in allBindings)
		{
			if (allBinding == changedBinding)
			{
				continue;
			}
			InputBindingUGUIResolver component = allBinding.GetComponent<InputBindingUGUIResolver>();
			if (component == null)
			{
				continue;
			}
			string iD = component.ID;
			SettingString settingString = settingsProvider.Settings.GetString(iD);
			if (settingString != null && string.Equals(settingString.GetValue(), newPath, StringComparison.OrdinalIgnoreCase))
			{
				if (!string.IsNullOrEmpty(previousPath))
				{
					Debug.Log("[InputRebindManager] Duplicate detected! Swapping: '" + iD + "' gets '" + previousPath + "' (was '" + newPath + "')");
					settingString.SetValue(previousPath);
					allBinding.InputBinding.SetBindingPath(previousPath);
					allBinding.Refresh();
				}
				else
				{
					Debug.Log("[InputRebindManager] Duplicate detected! Resetting '" + iD + "' (was '" + newPath + "')");
					settingString.ResetToDefault();
					allBinding.Refresh();
				}
				break;
			}
		}
	}
}
