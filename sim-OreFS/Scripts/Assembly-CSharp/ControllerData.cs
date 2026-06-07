using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerData", menuName = "ZGS/UI/ControllerData", order = 1)]
public class ControllerData : ScriptableObject
{
	[Serializable]
	public class ButtonInfo
	{
		public string buttonName;

		public Sprite xboxImage;

		public Sprite playstationImage;

		public Sprite switchImage;

		public Sprite keyboardImage;

		public Sprite steamDeckImage;
	}

	public ButtonInfo[] buttons;

	public Sprite GetButtonImage(string buttonName)
	{
		ButtonInfo buttonInfo = FindButton(buttonName);
		if (buttonInfo == null)
		{
			Debug.Log("Button not found: " + buttonName);
			return null;
		}
		switch (InputDetection.Instance.activeInputDevice)
		{
		case CurrentInputDevice.XboxGamepad:
			if (PlayerPrefs.GetInt("ControllerOverlay") != 0 && GamepadSelector.Instance.activeGamepadImageType == GamepadImageType.Playstation)
			{
				return buttonInfo.playstationImage;
			}
			return buttonInfo.xboxImage;
		case CurrentInputDevice.PlaystationGamepad:
			if (PlayerPrefs.GetInt("ControllerOverlay") != 0 && GamepadSelector.Instance.activeGamepadImageType == GamepadImageType.XInput)
			{
				return buttonInfo.xboxImage;
			}
			return buttonInfo.playstationImage;
		case CurrentInputDevice.SwitchGamepad:
			return buttonInfo.switchImage;
		case CurrentInputDevice.Keyboard:
			return buttonInfo.keyboardImage;
		case CurrentInputDevice.SteamDeck:
			return buttonInfo.steamDeckImage;
		default:
			Debug.Log("Invalid gamepad name: " + CurrentInputDevice.Undefined);
			return null;
		}
	}

	private ButtonInfo FindButton(string buttonName)
	{
		ButtonInfo[] array = buttons;
		foreach (ButtonInfo buttonInfo in array)
		{
			if (buttonInfo.buttonName == buttonName)
			{
				return buttonInfo;
			}
		}
		return null;
	}
}
