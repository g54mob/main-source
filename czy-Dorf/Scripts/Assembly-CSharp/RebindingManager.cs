using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class RebindingManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public RebindingManager _003C_003E4__this;

		public InputAction action;

		public int currentBindingIndex;

		public bool allCompositeParts;

		public string controlScheme;

		internal void _003CPerformInteractiveRebind_003Eb__1(InputActionRebindingExtensions.RebindingOperation operation)
		{
			_003C_003E4__this.ResetBindingsToBuffered(action, _003C_003E4__this.currentBindings);
			_003C_003E4__this.RebindStopped();
		}

		internal void _003CPerformInteractiveRebind_003Eb__2(InputActionRebindingExtensions.RebindingOperation operation)
		{
			_003C_003E4__this.RebindStopped();
			List<string> list = _003C_003E4__this.FindDuplicateBindings(action, currentBindingIndex, allCompositeParts);
			if (list.Count > 0)
			{
				if (list.Contains(action.name))
				{
					Debug.Log($"same action already contains binding {action.bindings[currentBindingIndex]}");
					InputActionRebindingExtensions.RemoveBindingOverride(action, currentBindingIndex);
					_003C_003E4__this.PerformInteractiveRebind(action, currentBindingIndex, controlScheme, allCompositeParts: true);
					return;
				}
				switch (_003C_003E4__this.duplicateBindingBehaviour)
				{
				case DuplicateBindingBehaviour.ClearDuplicate:
					Debug.Log($"duplicate binding - set {action} binding {currentBindingIndex} to none");
					_003C_003E4__this.SetDuplicateBindingsToNone(action, currentBindingIndex, allCompositeParts);
					break;
				case DuplicateBindingBehaviour.Retry:
					Debug.Log("duplicate binding - retry");
					InputActionRebindingExtensions.RemoveBindingOverride(action, currentBindingIndex);
					_003C_003E4__this.PerformInteractiveRebind(action, currentBindingIndex, controlScheme, allCompositeParts: true);
					return;
				}
			}
			_003C_003E4__this.UpdateBindingData(action, currentBindingIndex);
			_003C_003E4__this.RemoveUnassignedInputAction(action);
			if (allCompositeParts)
			{
				int num = currentBindingIndex + 1;
				if (num < action.bindings.Count && action.bindings[num].isPartOfComposite)
				{
					_003C_003E4__this.PerformInteractiveRebind(action, num, controlScheme, allCompositeParts: true);
				}
			}
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<InputActionRebindingExtensions.RebindingOperation> _003C_003E9__22_0;

		internal void _003CPerformInteractiveRebind_003Eb__22_0(InputActionRebindingExtensions.RebindingOperation operation)
		{
			Debug.Log($"Pressed {operation.selectedControl} - {operation.selectedControl.path}");
			string path = operation.selectedControl.path;
			if (path == "/Keyboard/escape" || path == "<Gamepad>/start")
			{
				Debug.Log("Cancel Operation - " + operation.selectedControl.path + " pressed");
				operation.Cancel();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public string actionName;

		public int bindingIndex;

		internal bool _003CUpdateBindingData_003Eb__0(BindingOverrideData x)
		{
			if (x.actionName == actionName)
			{
				return x.bindingIndex == bindingIndex;
			}
			return false;
		}

		internal bool _003CUpdateBindingData_003Eb__1(BindingOverrideData x)
		{
			if (x.actionName == actionName)
			{
				return x.bindingIndex == bindingIndex;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public string actionName;

		public int bindingIndex;

		internal bool _003CRemoveBindingData_003Eb__0(BindingOverrideData x)
		{
			if (x.actionName == actionName)
			{
				return x.bindingIndex == bindingIndex;
			}
			return false;
		}

		internal bool _003CRemoveBindingData_003Eb__1(BindingOverrideData x)
		{
			if (x.actionName == actionName)
			{
				return x.bindingIndex == bindingIndex;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public InputAction action;

		internal bool _003CRemoveUnassignedInputAction_003Eb__0(InputAction x)
		{
			return x == action;
		}
	}

	[SerializeField]
	private RebindingUi_WaitingForInput waitingForInputScreen;

	[SerializeField]
	private InputActionAsset actionAsset;

	[SerializeField]
	private InputActionReference toggleMenuAction;

	[SerializeField]
	private InputManager inputManager;

	[SerializeField]
	private string controlScheme;

	[SerializeField]
	private DuplicateBindingBehaviour duplicateBindingBehaviour = DuplicateBindingBehaviour.Retry;

	[SerializeField]
	[FormerlySerializedAs("unassignedInputActionWarningSymbols")]
	private List<GameObject> unassignedInputActionWarnings;

	private InputRebinding_WarningBox warningBox;

	private RebindingButton currentRebindButton;

	private InputActionRebindingExtensions.RebindingOperation currentRebindOperation;

	private int firstBindingIndex = -1;

	private Dictionary<int, string> currentBindings;

	private Dictionary<InputAction, RebindingButton> rebindingButtonByInputAction;

	private Dictionary<InputAction, GameModeId> gameModeByInputAction = new Dictionary<InputAction, GameModeId>();

	private List<InputAction> unassignedInputActions = new List<InputAction>();

	private BindingsOverrideData bindingsOverrideData;

	private List<string> buttonsToExclude = new List<string> { "<Mouse>/leftButton", "<Mouse>/rightButton", "<Pointer>/Press", "<Gamepad>/select", "<Gamepad>/start", "<DualShock4GamepadHID>/systemButton", "<DualSenseGamepadHID>/systemButton" };

	private void Awake()
	{
		warningBox = GetComponentInChildren<InputRebinding_WarningBox>(includeInactive: true);
		rebindingButtonByInputAction = new Dictionary<InputAction, RebindingButton>();
		RebindingButton[] componentsInChildren = GetComponentsInChildren<RebindingButton>(includeInactive: true);
		foreach (RebindingButton rebindingButton in componentsInChildren)
		{
			if (rebindingButtonByInputAction.ContainsKey(rebindingButton.InputAction))
			{
				Debug.LogError($"two rebindingButtons found for {rebindingButton.InputAction}: {rebindingButtonByInputAction[rebindingButton.InputAction]} & {rebindingButton}", rebindingButton);
				continue;
			}
			rebindingButtonByInputAction.Add(rebindingButton.InputAction, rebindingButton);
			gameModeByInputAction.Add(rebindingButton.InputAction, rebindingButton.RelatedGameMode);
		}
		LoadControlOverrides();
		UpdateUnassignedActionsWarning();
		inputManager.OnInputDeviceChanged += CancelRebindingDependingOnInputDevice;
	}

	private void Start()
	{
		if ((bool)warningBox)
		{
			LocalizationManager.Instance.OnLanguageChanged += UpdateUnassignedActionsWarning;
		}
	}

	private void UpdateUnassignedActionsWarning()
	{
		foreach (GameObject unassignedInputActionWarning in unassignedInputActionWarnings)
		{
			unassignedInputActionWarning.SetActive(unassignedInputActions.Count > 0);
		}
		if (!warningBox)
		{
			return;
		}
		warningBox.ResetEntries();
		foreach (InputAction item in Enumerable.Distinct(unassignedInputActions))
		{
			warningBox.AddEntry(rebindingButtonByInputAction[item].ActionLocalizationKey);
		}
	}

	private void CancelRebindingDependingOnInputDevice(Dorfromantik.InputDevice inputDevice)
	{
	}

	public void StartRebind(RebindingButton callingRebindButton, InputAction action, int bindingIndex, string controlScheme, bool allCompositeParts = false)
	{
		if ((bool)currentRebindButton)
		{
			currentRebindButton.RebindCompleted();
		}
		if (currentRebindOperation != null)
		{
			Debug.Log("Cancel operation because new rebind started");
		}
		currentRebindOperation?.Cancel();
		if (controlScheme != inputManager.CurrentControlScheme)
		{
			Debug.Log("not rebinding - current control scheme is " + inputManager.CurrentControlScheme + ", target control scheme is " + controlScheme);
			return;
		}
		currentRebindButton = callingRebindButton;
		firstBindingIndex = bindingIndex;
		if (allCompositeParts)
		{
			currentBindings = new Dictionary<int, string>();
			for (int i = bindingIndex; i < action.bindings.Count; i++)
			{
				if (action.bindings[i].isPartOfComposite)
				{
					currentBindings.Add(i, action.bindings[i].effectivePath);
				}
			}
		}
		else
		{
			currentBindings = new Dictionary<int, string> { 
			{
				bindingIndex,
				action.bindings[bindingIndex].effectivePath
			} };
		}
		PerformInteractiveRebind(action, bindingIndex, controlScheme, allCompositeParts);
	}

	private void PerformInteractiveRebind(InputAction action, int currentBindingIndex, string controlScheme, bool allCompositeParts = false)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals53 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals53._003C_003E4__this = this;
		CS_0024_003C_003E8__locals53.action = action;
		CS_0024_003C_003E8__locals53.currentBindingIndex = currentBindingIndex;
		CS_0024_003C_003E8__locals53.allCompositeParts = allCompositeParts;
		CS_0024_003C_003E8__locals53.controlScheme = controlScheme;
		RebindStarted(CS_0024_003C_003E8__locals53.currentBindingIndex);
		Debug.Log($"Rebind for {CS_0024_003C_003E8__locals53.action}, bindingIndex {CS_0024_003C_003E8__locals53.currentBindingIndex} started");
		currentRebindOperation = InputActionRebindingExtensions.PerformInteractiveRebinding(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex).OnPotentialMatch(delegate(InputActionRebindingExtensions.RebindingOperation operation)
		{
			Debug.Log($"Pressed {operation.selectedControl} - {operation.selectedControl.path}");
			string path = operation.selectedControl.path;
			if (path == "/Keyboard/escape" || path == "<Gamepad>/start")
			{
				Debug.Log("Cancel Operation - " + operation.selectedControl.path + " pressed");
				operation.Cancel();
			}
		}).WithCancelingThrough("an enormous string of absolute gibberish which overrides the default which is escape and causes the above bug")
			.OnCancel(delegate
			{
				CS_0024_003C_003E8__locals53._003C_003E4__this.ResetBindingsToBuffered(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53._003C_003E4__this.currentBindings);
				CS_0024_003C_003E8__locals53._003C_003E4__this.RebindStopped();
			})
			.OnComplete(delegate
			{
				CS_0024_003C_003E8__locals53._003C_003E4__this.RebindStopped();
				List<string> list = CS_0024_003C_003E8__locals53._003C_003E4__this.FindDuplicateBindings(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex, CS_0024_003C_003E8__locals53.allCompositeParts);
				if (list.Count > 0)
				{
					if (list.Contains(CS_0024_003C_003E8__locals53.action.name))
					{
						Debug.Log($"same action already contains binding {CS_0024_003C_003E8__locals53.action.bindings[CS_0024_003C_003E8__locals53.currentBindingIndex]}");
						InputActionRebindingExtensions.RemoveBindingOverride(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex);
						CS_0024_003C_003E8__locals53._003C_003E4__this.PerformInteractiveRebind(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex, CS_0024_003C_003E8__locals53.controlScheme, allCompositeParts: true);
						return;
					}
					switch (CS_0024_003C_003E8__locals53._003C_003E4__this.duplicateBindingBehaviour)
					{
					case DuplicateBindingBehaviour.ClearDuplicate:
						Debug.Log($"duplicate binding - set {CS_0024_003C_003E8__locals53.action} binding {CS_0024_003C_003E8__locals53.currentBindingIndex} to none");
						CS_0024_003C_003E8__locals53._003C_003E4__this.SetDuplicateBindingsToNone(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex, CS_0024_003C_003E8__locals53.allCompositeParts);
						break;
					case DuplicateBindingBehaviour.Retry:
						Debug.Log("duplicate binding - retry");
						InputActionRebindingExtensions.RemoveBindingOverride(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex);
						CS_0024_003C_003E8__locals53._003C_003E4__this.PerformInteractiveRebind(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex, CS_0024_003C_003E8__locals53.controlScheme, allCompositeParts: true);
						return;
					}
				}
				CS_0024_003C_003E8__locals53._003C_003E4__this.UpdateBindingData(CS_0024_003C_003E8__locals53.action, CS_0024_003C_003E8__locals53.currentBindingIndex);
				CS_0024_003C_003E8__locals53._003C_003E4__this.RemoveUnassignedInputAction(CS_0024_003C_003E8__locals53.action);
				if (CS_0024_003C_003E8__locals53.allCompositeParts)
				{
					int num = CS_0024_003C_003E8__locals53.currentBindingIndex + 1;
					if (num < CS_0024_003C_003E8__locals53.action.bindings.Count && CS_0024_003C_003E8__locals53.action.bindings[num].isPartOfComposite)
					{
						CS_0024_003C_003E8__locals53._003C_003E4__this.PerformInteractiveRebind(CS_0024_003C_003E8__locals53.action, num, CS_0024_003C_003E8__locals53.controlScheme, allCompositeParts: true);
					}
				}
			});
		foreach (string item in buttonsToExclude)
		{
			currentRebindOperation = currentRebindOperation.WithControlsExcluding(item);
		}
		currentRebindOperation.Start();
	}

	private void ResetBindingsToBuffered(InputAction action, Dictionary<int, string> inputBindings)
	{
		Debug.Log($"Reset {inputBindings.Count} Bindings");
		foreach (KeyValuePair<int, string> inputBinding in inputBindings)
		{
			if (action.bindings[inputBinding.Key].path == inputBinding.Value)
			{
				InputActionRebindingExtensions.RemoveBindingOverride(action, inputBinding.Key);
				RemoveBindingData(action, inputBinding.Key);
			}
			else
			{
				InputActionRebindingExtensions.ApplyBindingOverride(action, inputBinding.Key, inputBinding.Value);
				UpdateBindingData(action, inputBinding.Key);
			}
			Debug.Log($"apply binding override {inputBinding.Key} -> {inputBinding.Value}");
		}
		currentBindings.Clear();
	}

	private List<string> FindDuplicateBindings(InputAction action, int bindingIndex, bool allCompositeParts = false)
	{
		List<string> list = new List<string>();
		InputBinding inputBinding = action.bindings[bindingIndex];
		foreach (InputBinding binding in action.actionMap.bindings)
		{
			if (!(binding.action == inputBinding.action) && binding.effectivePath == inputBinding.effectivePath && !(binding.effectivePath == "Empty") && !string.IsNullOrWhiteSpace(binding.effectivePath))
			{
				InputAction inputAction = action.actionMap.FindAction(binding.action);
				if (!gameModeByInputAction.ContainsKey(inputAction))
				{
					Debug.LogError($"no game mode defined for input action {inputAction}");
				}
				else if (!gameModeByInputAction.ContainsKey(action))
				{
					Debug.LogError($"no game mode defined for input action {action}");
				}
				else if (gameModeByInputAction[inputAction] == gameModeByInputAction[action] || gameModeByInputAction[inputAction] == GameModeId.Undefined || gameModeByInputAction[action] == GameModeId.Undefined)
				{
					Debug.LogError($"Duplicate action found:\n{action} {gameModeByInputAction[action]}\n{inputAction} {gameModeByInputAction[inputAction]}");
					list.Add(binding.action);
				}
			}
		}
		if (allCompositeParts)
		{
			for (int i = firstBindingIndex; i < bindingIndex; i++)
			{
				if (action.bindings[i].effectivePath == inputBinding.effectivePath)
				{
					Debug.Log("duplicate binding found " + action.bindings[i].effectivePath + " in action " + action.bindings[i].action);
					list.Add(action.bindings[i].action);
				}
			}
		}
		return list;
	}

	private void SetDuplicateBindingsToNone(InputAction action, int bindingIndex, bool allCompositeParts = false)
	{
		InputBinding inputBinding = action.bindings[bindingIndex];
		foreach (InputBinding binding in action.actionMap.bindings)
		{
			if (binding.action == inputBinding.action || !(binding.effectivePath == inputBinding.effectivePath) || binding.effectivePath == "Empty" || string.IsNullOrWhiteSpace(binding.effectivePath))
			{
				continue;
			}
			Debug.Log(StringUtility.Colored("duplicate binding found " + binding.effectivePath + " in action " + binding.action, Color.yellow));
			InputAction inputAction = action.actionMap.FindAction(binding.action);
			if (!rebindingButtonByInputAction.ContainsKey(inputAction))
			{
				Debug.Log($"{inputAction} can't be set to none - skip");
			}
			else if (gameModeByInputAction[inputAction] == gameModeByInputAction[action] || gameModeByInputAction[inputAction] == GameModeId.Undefined || gameModeByInputAction[action] == GameModeId.Undefined)
			{
				for (int i = 0; i < inputAction.bindings.Count; i++)
				{
					Debug.Log(StringUtility.Colored($"{inputAction.name} binding {i}: {inputAction.bindings[i].effectivePath}, {inputAction.bindings[i].groups}", Color.yellow));
				}
				Debug.Log(StringUtility.Colored("search for binding in " + inputAction.name + " with group: " + binding.groups + ", path: " + binding.effectivePath, Color.yellow));
				int bindingIndex2 = InputActionRebindingExtensions.GetBindingIndex(inputAction, binding);
				if (bindingIndex2 == -1)
				{
					Debug.Log(StringUtility.Colored("first version search: not successful, trying to search by groups", Color.yellow));
					bindingIndex2 = InputActionRebindingExtensions.GetBindingIndex(inputAction, binding.groups);
				}
				Debug.Log(StringUtility.Colored($"affected bindingIndex {bindingIndex2}", Color.yellow));
				InputActionRebindingExtensions.ApplyBindingOverride(inputAction, bindingIndex2, "Empty");
				UpdateBindingData(inputAction, bindingIndex2);
				rebindingButtonByInputAction[inputAction].DisplayBindingsOnButton();
				Debug.Log(StringUtility.Colored("new path: " + inputAction.bindings[bindingIndex2].effectivePath, Color.yellow));
				AddUnassignedInputAction(inputAction);
			}
		}
	}

	private void RebindStarted(int bindingIndex)
	{
		toggleMenuAction.action.Disable();
		currentRebindButton.RebindStarted(bindingIndex - firstBindingIndex);
	}

	private void RebindStopped()
	{
		toggleMenuAction.action.Enable();
		currentRebindOperation?.Dispose();
		currentRebindOperation = null;
		currentRebindButton.RebindCompleted();
	}

	public void CancelRebindingOfAction(InputAction targetAction)
	{
		if (currentRebindOperation?.action == targetAction)
		{
			currentRebindOperation?.Cancel();
		}
	}

	public void RemoveBindings(InputAction targetAction, string controlScheme)
	{
		for (int i = 0; i < targetAction.bindings.Count; i++)
		{
			InputBinding inputBinding = targetAction.bindings[i];
			Debug.Log($"Remove binding - check {inputBinding}. Correct controlScheme {controlScheme}? {inputBinding.groups.Contains(controlScheme)}");
			if (!inputBinding.groups.Contains(controlScheme))
			{
				continue;
			}
			Debug.Log("correct control scheme! effective path " + inputBinding.effectivePath + ", binding path " + inputBinding.path);
			if (!(inputBinding.path == inputBinding.effectivePath) && BindingPathTaken(targetAction, inputBinding.path, out var duplicateBindingActionName))
			{
				switch (duplicateBindingBehaviour)
				{
				case DuplicateBindingBehaviour.Retry:
					Debug.Log("can't reset, " + duplicateBindingActionName + " uses binding " + inputBinding.path);
					return;
				case DuplicateBindingBehaviour.ClearDuplicate:
					InputActionRebindingExtensions.RemoveBindingOverride(targetAction, i);
					RemoveBindingData(targetAction, i);
					Debug.Log($"Remove bindings of {targetAction}, duplicate found: {duplicateBindingActionName}");
					SetDuplicateBindingsToNone(targetAction, i);
					break;
				}
			}
		}
		for (int j = 0; j < targetAction.bindings.Count; j++)
		{
			if (targetAction.bindings[j].groups.Contains(controlScheme))
			{
				InputActionRebindingExtensions.RemoveBindingOverride(targetAction, j);
				RemoveBindingData(targetAction, j);
			}
		}
		RemoveUnassignedInputAction(targetAction, removeAllEntries: true);
	}

	private bool BindingPathTaken(InputAction callingAction, string bindingPath, out string duplicateBindingActionName)
	{
		foreach (InputBinding binding in callingAction.actionMap.bindings)
		{
			if (!(binding.action == callingAction.name) && binding.effectivePath == bindingPath)
			{
				duplicateBindingActionName = binding.action;
				Debug.Log("duplicate binding found " + binding.effectivePath + " in action " + binding.action);
				return true;
			}
		}
		duplicateBindingActionName = null;
		return false;
	}

	private void UpdateBindingData(InputAction action, int bindingIndex)
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals10.bindingIndex = bindingIndex;
		CS_0024_003C_003E8__locals10.actionName = action.name;
		string effectivePath = action.bindings[CS_0024_003C_003E8__locals10.bindingIndex].effectivePath;
		if (Enumerable.Count(bindingsOverrideData.bindingOverrides, (BindingOverrideData x) => x.actionName == CS_0024_003C_003E8__locals10.actionName && x.bindingIndex == CS_0024_003C_003E8__locals10.bindingIndex) == 0)
		{
			bindingsOverrideData.bindingOverrides.Add(new BindingOverrideData
			{
				actionName = CS_0024_003C_003E8__locals10.actionName,
				bindingIndex = CS_0024_003C_003E8__locals10.bindingIndex,
				overridePath = effectivePath
			});
		}
		else
		{
			Enumerable.First(bindingsOverrideData.bindingOverrides, (BindingOverrideData x) => x.actionName == CS_0024_003C_003E8__locals10.actionName && x.bindingIndex == CS_0024_003C_003E8__locals10.bindingIndex).overridePath = effectivePath;
		}
		Debug.Log($"Updated binding of {action} from {action.bindings[CS_0024_003C_003E8__locals10.bindingIndex].path} to {effectivePath}");
		JsonSaver.SaveAsJson(bindingsOverrideData, "Controls.json");
	}

	private void RemoveBindingData(InputAction action, int bindingIndex)
	{
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass32_0();
		CS_0024_003C_003E8__locals7.bindingIndex = bindingIndex;
		CS_0024_003C_003E8__locals7.actionName = action.name;
		if (Enumerable.Count(bindingsOverrideData.bindingOverrides, (BindingOverrideData x) => x.actionName == CS_0024_003C_003E8__locals7.actionName && x.bindingIndex == CS_0024_003C_003E8__locals7.bindingIndex) != 0)
		{
			BindingOverrideData item = Enumerable.First(bindingsOverrideData.bindingOverrides, (BindingOverrideData x) => x.actionName == CS_0024_003C_003E8__locals7.actionName && x.bindingIndex == CS_0024_003C_003E8__locals7.bindingIndex);
			bindingsOverrideData.bindingOverrides.Remove(item);
			Debug.Log($"Removed binding override of {action} - new path: {action.bindings[CS_0024_003C_003E8__locals7.bindingIndex].effectivePath}");
			JsonSaver.SaveAsJson(bindingsOverrideData, "Controls.json");
		}
	}

	private void LoadControlOverrides()
	{
		Debug.Log("Load and apply control overrides");
		bindingsOverrideData = JsonLoader.LoadJsonFromDataLocation<BindingsOverrideData>("Controls.json") ?? new BindingsOverrideData();
		foreach (BindingOverrideData bindingOverride in bindingsOverrideData.bindingOverrides)
		{
			InputAction inputAction = actionAsset.FindAction(bindingOverride.actionName);
			InputActionRebindingExtensions.ApplyBindingOverride(inputAction, bindingOverride.bindingIndex, bindingOverride.overridePath);
			if (bindingOverride.overridePath == "Empty" && inputAction.bindings[bindingOverride.bindingIndex].groups.Contains(controlScheme))
			{
				AddUnassignedInputAction(inputAction);
			}
		}
	}

	private void AddUnassignedInputAction(InputAction action)
	{
		if (duplicateBindingBehaviour == DuplicateBindingBehaviour.ClearDuplicate)
		{
			if (!unassignedInputActions.Contains(action))
			{
				unassignedInputActions.Add(action);
			}
			rebindingButtonByInputAction[action].ShowUnassignedWarning(show: true);
			UpdateUnassignedActionsWarning();
		}
	}

	private void RemoveUnassignedInputAction(InputAction action, bool removeAllEntries = false)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals5.action = action;
		if (removeAllEntries)
		{
			unassignedInputActions.RemoveAll((InputAction x) => x == CS_0024_003C_003E8__locals5.action);
		}
		else
		{
			unassignedInputActions.Remove(CS_0024_003C_003E8__locals5.action);
		}
		if (!unassignedInputActions.Contains(CS_0024_003C_003E8__locals5.action))
		{
			rebindingButtonByInputAction[CS_0024_003C_003E8__locals5.action].ShowUnassignedWarning(show: false);
		}
		UpdateUnassignedActionsWarning();
	}

	private void LogUnassignedInputActions()
	{
		Debug.Log("Unassigned Input Actions:");
		foreach (InputAction unassignedInputAction in unassignedInputActions)
		{
			Debug.Log(unassignedInputAction.name ?? "");
		}
	}
}
