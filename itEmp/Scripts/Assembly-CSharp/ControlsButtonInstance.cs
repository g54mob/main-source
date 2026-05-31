using System.Collections.Generic;
using UnityEngine;

public class ControlsButtonInstance : MonoBehaviour
{
	public static ControlsButtonInstance instance;

	public SettingsBaseButtonsControl[] buttonsBase;

	public Dictionary<string, KeyCode> buttons;

	public SettingsButtonsControlSet[] ListButtons;

	public static void InitInstance(SettingsBaseButtonsControl[] keyBase, SettingsButtonsControlSet[] _buttons)
	{
	}

	private void Awake()
	{
	}

	public void Initialize(SettingsBaseButtonsControl[] keyBase)
	{
	}

	public void SetButtons(SettingsButtonsControlSet[] _buttons)
	{
	}

	public KeyCode GetButton(string name)
	{
		return default(KeyCode);
	}

	public Sprite GetImageButton(KeyCode key)
	{
		return null;
	}
}
