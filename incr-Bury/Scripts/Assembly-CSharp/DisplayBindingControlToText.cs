using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayBindingControlToText : MonoBehaviour
{
	[SerializeField]
	private TMP_Text displayText;

	[SerializeField]
	private string actionName;

	private void Awake()
	{
		DisplayBindingDisplayText();
	}

	private void Start()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Combine(singleton.ControllerTypeChanged, new Action(OnControllerChanged));
	}

	private void OnDestroy()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Remove(singleton.ControllerTypeChanged, new Action(OnControllerChanged));
	}

	private void OnControllerChanged()
	{
		DisplayBindingDisplayText();
	}

	private void DisplayBindingDisplayText()
	{
		InputAction inputAction = null;
		InputActionMap inputActionMap = InputManager.Singleton.inputActions.PlayerActionMap;
		inputAction = inputActionMap.FindAction(actionName);
		if (inputActionMap == null || inputAction == null)
		{
			Debug.Log("Couldn't find this action binding to display");
		}
		else if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			displayText.text = inputAction.GetBindingDisplayString(1);
		}
		else if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.keyboard)
		{
			displayText.text = inputAction.GetBindingDisplayString(0);
		}
	}
}
