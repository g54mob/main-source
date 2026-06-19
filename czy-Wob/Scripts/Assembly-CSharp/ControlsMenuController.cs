using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using InControl;
using TMPro;
using UnityEngine;

public class ControlsMenuController : MonoBehaviour
{
	public delegate void SaveFinishedCallback();

	public GameObject mouseKeyboardHeader;

	public GameObject gamepadHeader;

	public GameObject savingPopup;

	public GameObject remappingPopup;

	public TextMeshProUGUI popupHeaderText;

	public TextMeshProUGUI popupCommandNameText;

	public TextMeshProUGUI popupCommandMappingText;

	public CoreButtonUnityGUI clearMappingButton;

	public CoreButtonUnityGUI exitMappingButton;

	public CoreButtonUnityGUI resetMappingButton;

	public CoreButtonUnityGUI newMappingButton;

	public CursorUpdateArea cursorUpdateAreaRef;

	public GameObject interactRemappingPopup;

	private float activeTabXPos = -485f;

	private float inactiveTabXPos = -450f;

	public GameObject commandMappingOptionPrefab;

	public Transform commandMappingOptionHolderTransform;

	public GameObject mouseKeyboardTab;

	public GameObject gamepadTab;

	public CoreButtonUnityGUI mouseKeyboardTabButton;

	public CoreButtonUnityGUI gamepadTabButton;

	private bool isInMouseKeyboardMode = true;

	private ControlCommand currentCommandBeingMapped;

	private ControlType currentControlTypeBeingMapped;

	private List<CommandMappingOption> commandMappingOptions = new List<CommandMappingOption>();

	private CursorController cursorRef;

	private ControlManager controlManagerRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		controlManagerRef = registrationScript.GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		controlManagerRef.AssignGUIRef(this);
		savingPopup.SetActive(value: false);
		remappingPopup.SetActive(value: false);
		interactRemappingPopup.SetActive(value: false);
		SwitchToMouseKeyboardMode();
	}

	public IEnumerator SaveOnClose(SaveFinishedCallback callback)
	{
		yield return new WaitForEndOfFrame();
		savingPopup.SetActive(value: true);
		yield return StartCoroutine(controlManagerRef.SaveControlMapping());
		savingPopup.SetActive(value: false);
		callback?.Invoke();
	}

	public bool StealCloseInputIfNeeded()
	{
		if (remappingPopup.activeSelf)
		{
			if (exitMappingButton.interactable)
			{
				CloseRemappingPopup();
			}
			else if (!isInMouseKeyboardMode && cursorRef.IsSystemMouseActive())
			{
				CloseRemappingPopup();
			}
			return true;
		}
		return false;
	}

	public void OnMouseKeyboardTabClicked()
	{
		SwitchToMouseKeyboardMode();
	}

	public void OnGamepadTabClicked()
	{
		SwitchToGamepadMode();
	}

	private void SwitchToMouseKeyboardMode()
	{
		isInMouseKeyboardMode = true;
		gamepadTabButton.interactable = true;
		mouseKeyboardTabButton.interactable = false;
		gamepadTabButton.OnPointerExit(null);
		gamepadTab.transform.localPosition = new Vector3(inactiveTabXPos, gamepadTab.transform.localPosition.y, gamepadTab.transform.localPosition.z);
		mouseKeyboardTab.transform.localPosition = new Vector3(activeTabXPos, mouseKeyboardTab.transform.localPosition.y, mouseKeyboardTab.transform.localPosition.z);
		gamepadHeader.SetActive(value: false);
		mouseKeyboardHeader.SetActive(value: true);
		CreateOptions();
	}

	private void SwitchToGamepadMode()
	{
		isInMouseKeyboardMode = false;
		gamepadTabButton.interactable = false;
		mouseKeyboardTabButton.interactable = true;
		mouseKeyboardTabButton.OnPointerExit(null);
		gamepadTab.transform.localPosition = new Vector3(activeTabXPos, gamepadTab.transform.localPosition.y, gamepadTab.transform.localPosition.z);
		mouseKeyboardTab.transform.localPosition = new Vector3(inactiveTabXPos, mouseKeyboardTab.transform.localPosition.y, mouseKeyboardTab.transform.localPosition.z);
		gamepadHeader.SetActive(value: true);
		mouseKeyboardHeader.SetActive(value: false);
		CreateOptions();
	}

	public void ResetAllCommands()
	{
		for (int i = 0; i < commandMappingOptions.Count; i++)
		{
			commandMappingOptions[i].ResetToDefault();
		}
	}

	public void ShowInteractRemappingPopup()
	{
		interactRemappingPopup.SetActive(value: true);
	}

	public void CloseInteractRemappingPopup()
	{
		interactRemappingPopup.SetActive(value: false);
	}

	public void AcceptInteractRemapping()
	{
		interactRemappingPopup.SetActive(value: false);
		OpenRemappingPopup(ControlCommand.INTERACT, ControlType.MOUSE);
	}

	public void OpenRemappingPopup(ControlCommand command, ControlType controlType)
	{
		currentCommandBeingMapped = command;
		currentControlTypeBeingMapped = controlType;
		remappingPopup.SetActive(value: true);
		string text = "";
		switch (controlType)
		{
		case ControlType.MOUSE:
			text = ScriptLocalization.GUI.GUI_CONTROLS_MOUSEMAP;
			break;
		case ControlType.KEYBOARD:
			text = ScriptLocalization.GUI.GUI_CONTROLS_KEYBIND;
			break;
		case ControlType.GAMEPAD:
			text = ScriptLocalization.GUI.GUI_CONTROLS_GAMEPADBIND;
			break;
		}
		popupHeaderText.text = text;
		popupCommandNameText.text = ControlManager.ControlCommandToLocalizedString(command);
		RefreshPopupCommandMappingText();
		RefreshClearBindingButton();
	}

	private void RefreshClearBindingButton()
	{
		if (controlManagerRef.GetNumberOfActiveMouseKeyboardBindingsForCommand(currentCommandBeingMapped) <= 1 && controlManagerRef.DoesCommandHaveAnyDefaultBindings(currentCommandBeingMapped))
		{
			clearMappingButton.interactable = false;
		}
		else if (popupCommandMappingText.text.Length == 0)
		{
			clearMappingButton.interactable = false;
		}
		else
		{
			clearMappingButton.interactable = true;
		}
	}

	private void RefreshPopupCommandMappingText()
	{
		if (currentControlTypeBeingMapped == ControlType.MOUSE)
		{
			popupCommandMappingText.text = controlManagerRef.GetCurrentMouseBindingForCommand(currentCommandBeingMapped);
		}
		else if (currentControlTypeBeingMapped == ControlType.KEYBOARD)
		{
			popupCommandMappingText.text = controlManagerRef.GetCurrentKeyboardBindingForCommand(currentCommandBeingMapped);
		}
		else if (currentControlTypeBeingMapped == ControlType.GAMEPAD)
		{
			popupCommandMappingText.text = controlManagerRef.GetCurrentGamepadBindingForCommand(currentCommandBeingMapped);
		}
		CommandMappingOption commandMappingOption = null;
		for (int i = 0; i < commandMappingOptions.Count; i++)
		{
			if (commandMappingOptions[i].command == currentCommandBeingMapped)
			{
				commandMappingOption = commandMappingOptions[i];
				break;
			}
		}
		if (commandMappingOption == null)
		{
			Debug.LogError("No command option found for command: " + currentCommandBeingMapped);
		}
		else
		{
			commandMappingOption.Refresh();
		}
	}

	public void CloseRemappingPopup()
	{
		controlManagerRef.StopCurrentBinding();
		remappingPopup.SetActive(value: false);
	}

	public void ResetSelectedOption()
	{
		BindingSourceType sourceType = BindingSourceType.None;
		if (currentControlTypeBeingMapped == ControlType.MOUSE)
		{
			sourceType = BindingSourceType.MouseBindingSource;
		}
		else if (currentControlTypeBeingMapped == ControlType.KEYBOARD)
		{
			sourceType = BindingSourceType.KeyBindingSource;
		}
		else if (currentControlTypeBeingMapped == ControlType.GAMEPAD)
		{
			sourceType = BindingSourceType.DeviceBindingSource;
		}
		controlManagerRef.ResetBinding(currentCommandBeingMapped, sourceType);
		RefreshPopupCommandMappingText();
		RefreshClearBindingButton();
	}

	public void EnterCommandBindingMode()
	{
		CommandMappingOption commandMappingOption = null;
		for (int i = 0; i < commandMappingOptions.Count; i++)
		{
			if (commandMappingOptions[i].command == currentCommandBeingMapped)
			{
				commandMappingOption = commandMappingOptions[i];
				break;
			}
		}
		if (commandMappingOption == null)
		{
			Debug.LogError("No command option found for command: " + currentCommandBeingMapped);
			return;
		}
		ClearSelectedBinding();
		controlManagerRef.EnterBindMode(currentCommandBeingMapped, commandMappingOption, currentControlTypeBeingMapped);
		popupCommandMappingText.text = ScriptLocalization.GUI.GUI_CONTROLS_NEWMAP;
		LockButtons();
	}

	public void ClearSelectedBinding()
	{
		BindingSourceType sourceType = BindingSourceType.MouseBindingSource;
		if (currentControlTypeBeingMapped == ControlType.KEYBOARD)
		{
			sourceType = BindingSourceType.KeyBindingSource;
		}
		else if (currentControlTypeBeingMapped == ControlType.GAMEPAD)
		{
			sourceType = BindingSourceType.DeviceBindingSource;
		}
		controlManagerRef.ClearBinding(currentCommandBeingMapped, sourceType);
		popupCommandMappingText.text = "";
		RefreshClearBindingButton();
		CommandMappingOption commandMappingOption = null;
		for (int i = 0; i < commandMappingOptions.Count; i++)
		{
			if (commandMappingOptions[i].command == currentCommandBeingMapped)
			{
				commandMappingOption = commandMappingOptions[i];
				break;
			}
		}
		if (commandMappingOption == null)
		{
			Debug.LogError("No command option found for command: " + currentCommandBeingMapped);
		}
		else
		{
			commandMappingOption.ReportBindingCleared(currentControlTypeBeingMapped);
		}
	}

	private void ClearOptions()
	{
		for (int i = 0; i < commandMappingOptions.Count; i++)
		{
			Object.Destroy(commandMappingOptions[i].gameObject);
		}
		commandMappingOptions.Clear();
	}

	private void CreateOptions()
	{
		ClearOptions();
		if (!isInMouseKeyboardMode)
		{
			GameObject obj = Object.Instantiate(commandMappingOptionPrefab);
			obj.transform.SetParent(commandMappingOptionHolderTransform);
			obj.transform.localScale = Vector3.one;
			CommandMappingOption component = obj.GetComponent<CommandMappingOption>();
			component.SetToggleCommandType();
			component.SetGUIRef(this, cursorUpdateAreaRef);
			commandMappingOptions.Add(component);
			GameObject obj2 = Object.Instantiate(commandMappingOptionPrefab);
			obj2.transform.SetParent(commandMappingOptionHolderTransform);
			obj2.transform.localScale = Vector3.one;
			CommandMappingOption component2 = obj2.GetComponent<CommandMappingOption>();
			component2.SetEmpty();
			component2.SetGUIRef(this, cursorUpdateAreaRef);
			commandMappingOptions.Add(component2);
		}
		foreach (ControlCommand value in EnumUtils.GetValues<ControlCommand>())
		{
			if ((!isInMouseKeyboardMode || !controlManagerRef.IsCommandGamepadOnly(value)) && (isInMouseKeyboardMode || !controlManagerRef.IsCommandMouseKeyboardOnly(value)) && !controlManagerRef.IsCommandToggle(value))
			{
				GameObject obj3 = Object.Instantiate(commandMappingOptionPrefab);
				obj3.transform.SetParent(commandMappingOptionHolderTransform);
				obj3.transform.localScale = Vector3.one;
				CommandMappingOption component3 = obj3.GetComponent<CommandMappingOption>();
				component3.SetCommandType(value, isInMouseKeyboardMode);
				component3.SetGUIRef(this, cursorUpdateAreaRef);
				commandMappingOptions.Add(component3);
			}
		}
	}

	public void OnBindingEnded()
	{
		RefreshPopupCommandMappingText();
		RefreshClearBindingButton();
		UnlockButtons();
	}

	private void LockButtons()
	{
		newMappingButton.interactable = false;
		exitMappingButton.interactable = false;
		resetMappingButton.interactable = false;
	}

	private void UnlockButtons()
	{
		newMappingButton.interactable = true;
		exitMappingButton.interactable = true;
		resetMappingButton.interactable = true;
		newMappingButton.OnPointerExit(null);
		exitMappingButton.OnPointerExit(null);
		resetMappingButton.OnPointerExit(null);
	}
}
