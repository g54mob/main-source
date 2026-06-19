using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Rewired;
using UnityEngine;

public class ControlMapping_ActionMapping : MonoBehaviour
{
	[SerializeField]
	private List<ControlMapping_SingleActionMapping> _keyboardActionMappings = new List<ControlMapping_SingleActionMapping>();

	[SerializeField]
	private List<ControlMapping_SingleActionMapping> _mouseActionMappings = new List<ControlMapping_SingleActionMapping>();

	[SerializeField]
	private List<ControlMapping_SingleActionMapping> _joystickActionMappings = new List<ControlMapping_SingleActionMapping>();

	[SerializeField]
	private PugText _actionNameText;

	public InputAction InputAction { get; private set; }

	public ActionMappingType ActionMappingType { get; private set; }

	public int MapCategoryId { get; private set; }

	public event Action<ControlMapping_ActionMapping, ControlMapping_SingleActionMapping> ActionMappingActivated;

	public event Action<ControlMapping_ActionMapping, ControlMapping_SingleActionMapping> ActionMappingSelected;

	private List<ControlMapping_SingleActionMapping> GetSingleActionMappings(ControllerType controllerType)
	{
		return controllerType switch
		{
			ControllerType.Keyboard => _keyboardActionMappings, 
			ControllerType.Mouse => _mouseActionMappings, 
			ControllerType.Joystick => _joystickActionMappings, 
			_ => new List<ControlMapping_SingleActionMapping>(), 
		};
	}

	public void Setup(ActionMappingDisplayConfig displayConfig, ActionMappingType actionMappingType, int mapCategoryId, InputAction action, List<ActionElementMap> actionMappings, List<KeyValuePair_String> keyboardLocalizationWhitelist)
	{
		MapCategoryId = mapCategoryId;
		InputAction = action;
		ActionMappingType = actionMappingType;
		string actionNameIdentifier = GetActionNameIdentifier(action, actionMappingType);
		string text = "ControlMapper/" + actionNameIdentifier;
		if (string.IsNullOrEmpty(LocalizationManager.GetTranslation(text)))
		{
			text += "PC";
			if (string.IsNullOrEmpty(LocalizationManager.GetTranslation(text)))
			{
				text = actionNameIdentifier + "PC";
			}
		}
		_actionNameText.Render(text, rewindEffectAnims: false, force: true);
		int[] array = new int[3];
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				ControllerType controllerType = (ControllerType)i;
				List<ControlMapping_SingleActionMapping> singleActionMappings = GetSingleActionMappings(controllerType);
				if (j < singleActionMappings.Count && ShouldShowMapping(displayConfig, controllerType, j))
				{
					singleActionMappings[j].gameObject.SetActive(value: true);
					singleActionMappings[j].ActionMappingActivated += SingleActionMappingActivated;
					singleActionMappings[j].ActionMappingSelected += SingleActionMappingSelected;
				}
				else
				{
					singleActionMappings[j].gameObject.SetActive(value: false);
				}
			}
		}
		if (actionMappings == null)
		{
			return;
		}
		foreach (ActionElementMap actionElementMap in actionMappings)
		{
			ControllerType controllerType2 = actionElementMap.controllerMap.controllerType;
			List<ControlMapping_SingleActionMapping> singleActionMappings2 = GetSingleActionMappings(controllerType2);
			int num = array[(int)controllerType2];
			if (num >= singleActionMappings2.Count)
			{
				Debug.LogWarning(string.Format("{0}.{1}: element for {2} (mapping id {3}) {4} mapping for action {5} is not available. Skipping.", "ControlMapping_ActionMapping", "Setup", (num == 0) ? "primary" : "secondary", actionElementMap.id, controllerType2, _actionNameText.GetText()));
				continue;
			}
			string localizationOverride = null;
			if (controllerType2 == ControllerType.Keyboard)
			{
				localizationOverride = keyboardLocalizationWhitelist.FirstOrDefault((KeyValuePair_String x) => x.Key.Equals(actionElementMap.elementIdentifierName))?.Value;
			}
			singleActionMappings2[num].Setup(actionElementMap, localizationOverride);
			array[(int)controllerType2]++;
		}
		bool ShouldShowMapping(ActionMappingDisplayConfig config, ControllerType controllerType3, int mappingIndex)
		{
			switch (controllerType3)
			{
			case ControllerType.Keyboard:
				if (config.ShowKeyboard)
				{
					if (mappingIndex != 0)
					{
						return displayConfig.ShowKeyboardSecondaryMapping;
					}
					return true;
				}
				return false;
			case ControllerType.Mouse:
				if (config.ShowMouse)
				{
					if (mappingIndex != 0)
					{
						return displayConfig.ShowMouseSecondaryMapping;
					}
					return true;
				}
				return false;
			case ControllerType.Joystick:
				if (config.ShowJoystick)
				{
					if (mappingIndex != 0)
					{
						return displayConfig.ShowJoystickSecondaryMapping;
					}
					return true;
				}
				return false;
			default:
				return false;
			}
		}
	}

	private string GetActionNameIdentifier(InputAction action, ActionMappingType actionMappingType)
	{
		return actionMappingType switch
		{
			ActionMappingType.Default => action.name, 
			ActionMappingType.PositiveAxis => action.positiveDescriptiveName, 
			ActionMappingType.NegativeAxis => action.negativeDescriptiveName, 
			_ => throw new ArgumentOutOfRangeException("actionMappingType", actionMappingType, null), 
		};
	}

	public IEnumerable<RadicalMenuOption> GetActiveSingleActionMappingElements()
	{
		List<ControlMapping_SingleActionMapping> list = new List<ControlMapping_SingleActionMapping>();
		list.AddRange(GetSingleActionMappings(ControllerType.Keyboard));
		list.AddRange(GetSingleActionMappings(ControllerType.Mouse));
		list.AddRange(GetSingleActionMappings(ControllerType.Joystick));
		return list.Where((ControlMapping_SingleActionMapping mapping) => mapping.gameObject.activeSelf);
	}

	public ControlMapping_SingleActionMapping GetSingleActionMapping(ControllerType controllerType, bool primary)
	{
		return controllerType switch
		{
			ControllerType.Keyboard => _keyboardActionMappings[(!primary) ? 1 : 0], 
			ControllerType.Mouse => _mouseActionMappings[(!primary) ? 1 : 0], 
			ControllerType.Joystick => _joystickActionMappings[(!primary) ? 1 : 0], 
			ControllerType.Custom => throw new NotImplementedException(), 
			_ => throw new ArgumentOutOfRangeException("controllerType", controllerType, null), 
		};
	}

	private void SingleActionMappingActivated(ControlMapping_SingleActionMapping mapping)
	{
		this.ActionMappingActivated?.Invoke(this, mapping);
	}

	private void SingleActionMappingSelected(ControlMapping_SingleActionMapping mapping)
	{
		this.ActionMappingSelected?.Invoke(this, mapping);
	}

	private void OnDisable()
	{
		foreach (ControlMapping_SingleActionMapping keyboardActionMapping in _keyboardActionMappings)
		{
			keyboardActionMapping.gameObject.SetActive(value: false);
		}
		foreach (ControlMapping_SingleActionMapping mouseActionMapping in _mouseActionMappings)
		{
			mouseActionMapping.gameObject.SetActive(value: false);
		}
		foreach (ControlMapping_SingleActionMapping joystickActionMapping in _joystickActionMappings)
		{
			joystickActionMapping.gameObject.SetActive(value: false);
		}
		this.ActionMappingActivated = null;
		this.ActionMappingSelected = null;
	}

	public void Cleanup()
	{
		foreach (ControlMapping_SingleActionMapping joystickActionMapping in _joystickActionMappings)
		{
			joystickActionMapping.Cleanup();
		}
		foreach (ControlMapping_SingleActionMapping keyboardActionMapping in _keyboardActionMappings)
		{
			keyboardActionMapping.Cleanup();
		}
		foreach (ControlMapping_SingleActionMapping mouseActionMapping in _mouseActionMappings)
		{
			mouseActionMapping.Cleanup();
		}
	}
}
