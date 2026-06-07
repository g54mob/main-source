#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Presentation.UI.Toolbar;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

[CreateAssetMenu(fileName = "ToolBarButtonGroups", menuName = "UI/Toolbar/ToolBarButtonGroups")]
public class ToolBarButtonGroupsSO : ScriptableObject
{
	private readonly Dictionary<InputAction, ToolBarButtonGroup> _buttonsByInput = new Dictionary<InputAction, ToolBarButtonGroup>();

	public int AddButton(InputAction inputAction, ToolBarButtonShortcut button)
	{
		if (!_buttonsByInput.TryGetValue(inputAction, out var value))
		{
			value = new ToolBarButtonGroup(inputAction);
			_buttonsByInput.Add(inputAction, value);
		}
		return value.AddButton(button);
	}

	public void RemoveButton(InputAction inputAction, int buttonIndex)
	{
		if (!_buttonsByInput.TryGetValue(inputAction, out var value))
		{
			this.LogWarning($"Failed to find group for input: \"{inputAction}\"", "RemoveButton", 27);
		}
		else
		{
			value.RemoveButton(buttonIndex);
		}
	}

	public void SetLastPressedButton(InputAction inputAction, int buttonIndex)
	{
		if (!_buttonsByInput.TryGetValue(inputAction, out var value))
		{
			this.DevException($"Failed to find group for input: \"{inputAction}\"", "SetLastPressedButton", 37);
		}
		else
		{
			value.SetLastPressedButton(buttonIndex);
		}
	}
}
