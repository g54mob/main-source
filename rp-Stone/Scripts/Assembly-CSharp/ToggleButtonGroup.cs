using System;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButtonGroup : MonoBehaviour
{
	public List<ToggleButton> buttons;

	private int _selectedIndex;

	public int selectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			_selectedIndex = value;
			UpdateButtonStates();
			if (this.OnIndexChanged != null)
			{
				this.OnIndexChanged(_selectedIndex);
			}
		}
	}

	public ToggleButton selectedButton
	{
		get
		{
			if (_selectedIndex < 0 || _selectedIndex >= buttons.Count)
			{
				return null;
			}
			return buttons[_selectedIndex];
		}
	}

	public event Action<int> OnIndexChanged;

	public void UpdateTic()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ToggleButton toggleButton = buttons[i];
			if (toggleButton != null && toggleButton.enabled)
			{
				toggleButton.UpdateTic();
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ToggleButton toggleButton = buttons[i];
			if (toggleButton != null && toggleButton.enabled)
			{
				toggleButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void Start()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ToggleButton toggleButton = buttons[i];
			if (toggleButton != null)
			{
				toggleButton.OnPressed += HandleButtonPressed;
			}
		}
		UpdateButtonStates();
	}

	private void OnDestroy()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ToggleButton toggleButton = buttons[i];
			if (toggleButton != null)
			{
				toggleButton.OnPressed -= HandleButtonPressed;
			}
		}
	}

	private void HandleButtonPressed(DialogButton button)
	{
		int num = -1;
		for (int i = 0; i < buttons.Count; i++)
		{
			if (buttons[i] == button)
			{
				num = i;
				break;
			}
		}
		if (num >= 0 && num < buttons.Count)
		{
			selectedIndex = num;
		}
	}

	private void UpdateButtonStates()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ToggleButton toggleButton = buttons[i];
			if (toggleButton != null)
			{
				toggleButton.isOn = i == selectedIndex;
				toggleButton.HasFocus = i != selectedIndex;
			}
		}
	}
}
