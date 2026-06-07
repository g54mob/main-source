using System;
using System.Collections.Generic;
using Presentation.UI.Toolbar;
using UnityEngine.InputSystem;

public class ToolBarButtonGroup : IDisposable
{
	private InputAction _inputAction;

	private int _currentIndex;

	private readonly List<ToolBarButtonShortcut> _buttons = new List<ToolBarButtonShortcut>();

	private readonly List<bool> _hasButtons = new List<bool>();

	public ToolBarButtonGroup(InputAction inputAction)
	{
		_inputAction = inputAction;
		_inputAction.performed += ActionPerformed;
	}

	public void Dispose()
	{
		if (_inputAction != null)
		{
			_inputAction.performed -= ActionPerformed;
			_inputAction = null;
		}
	}

	public int AddButton(ToolBarButtonShortcut button)
	{
		for (int i = 0; i < _buttons.Count; i++)
		{
			if (!_hasButtons[i])
			{
				_buttons[i] = button;
				_hasButtons[i] = true;
				button.SetButtonActiveInGroup(i == 0);
				return i;
			}
		}
		_buttons.Add(button);
		_hasButtons.Add(item: true);
		button.SetButtonActiveInGroup(_buttons.Count == 1);
		return _buttons.Count - 1;
	}

	public void RemoveButton(int index)
	{
		_buttons[index] = null;
		_hasButtons[index] = false;
		if (_currentIndex == index)
		{
			SelectNextValidButton();
		}
	}

	private void SelectNextValidButton()
	{
		int num = _currentIndex;
		do
		{
			num++;
			if (num >= _buttons.Count)
			{
				num = 0;
			}
			if (_hasButtons[num])
			{
				SetLastPressedButton(num);
				break;
			}
		}
		while (num != _currentIndex);
	}

	private void ActionPerformed(InputAction.CallbackContext context)
	{
		if (_buttons.Count > 1)
		{
			for (int i = _currentIndex; i < _buttons.Count; i++)
			{
				if (_hasButtons[i] && !_buttons[i].IsSelected && _buttons[i].TryPressButtonShortcut())
				{
					_currentIndex = i;
					return;
				}
			}
			for (int j = 0; j < _currentIndex; j++)
			{
				if (_hasButtons[j] && !_buttons[j].IsSelected && _buttons[j].TryPressButtonShortcut())
				{
					_currentIndex = j;
					return;
				}
			}
		}
		if (_hasButtons[_currentIndex])
		{
			_buttons[_currentIndex].TryPressButtonShortcut();
		}
	}

	internal void SetLastPressedButton(int buttonIndex)
	{
		_currentIndex = buttonIndex;
		for (int i = 0; i < _buttons.Count; i++)
		{
			if (_hasButtons[i])
			{
				_buttons[i].SetButtonActiveInGroup(i == _currentIndex);
			}
		}
	}
}
