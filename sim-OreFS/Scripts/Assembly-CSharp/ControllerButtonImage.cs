using System.Collections;
using Kamgam.SettingsGenerator;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerButtonImage : MonoBehaviour
{
	public ControllerData controllerData;

	public string buttonName;

	private Image image;

	public bool isInputChangable;

	public InputBindingConnectionSO keyboardInputBindingConnection;

	public InputBindingConnectionSO gamepadInputBindingConnection;

	public InputKeyBindingImageDatas keyBindingImageDatas;

	public bool inputBindingFound;

	private InputBinding binding;

	private void OnEnable()
	{
		CheckInputBindingConnection();
	}

	public void CheckInputBindingConnection()
	{
		if (isInputChangable && keyboardInputBindingConnection != null && gamepadInputBindingConnection != null)
		{
			switch (InputDetection.Instance.activeInputDevice)
			{
			case CurrentInputDevice.XboxGamepad:
			case CurrentInputDevice.PlaystationGamepad:
			case CurrentInputDevice.SwitchGamepad:
				inputBindingFound = gamepadInputBindingConnection.InputActionAsset.FindBinding(gamepadInputBindingConnection.BindingId, out binding);
				break;
			case CurrentInputDevice.Keyboard:
				inputBindingFound = keyboardInputBindingConnection.InputActionAsset.FindBinding(keyboardInputBindingConnection.BindingId, out binding);
				break;
			case CurrentInputDevice.SteamDeck:
				inputBindingFound = gamepadInputBindingConnection.InputActionAsset.FindBinding(gamepadInputBindingConnection.BindingId, out binding);
				break;
			}
		}
		image = GetComponent<Image>();
		StartCoroutine(SetUpdateImageData());
	}

	private IEnumerator SetUpdateImageData()
	{
		yield return new WaitForEndOfFrame();
		UpdateButtonImage();
	}

	public void UpdateButtonImage()
	{
		if (!base.enabled)
		{
			return;
		}
		if (isInputChangable && keyboardInputBindingConnection != null && gamepadInputBindingConnection != null)
		{
			switch (InputDetection.Instance.activeInputDevice)
			{
			case CurrentInputDevice.XboxGamepad:
			case CurrentInputDevice.PlaystationGamepad:
			case CurrentInputDevice.SwitchGamepad:
			case CurrentInputDevice.SteamDeck:
				inputBindingFound = gamepadInputBindingConnection.InputActionAsset.FindBinding(gamepadInputBindingConnection.BindingId, out binding);
				break;
			case CurrentInputDevice.Keyboard:
				inputBindingFound = keyboardInputBindingConnection.InputActionAsset.FindBinding(keyboardInputBindingConnection.BindingId, out binding);
				break;
			}
			if (inputBindingFound)
			{
				image.sprite = GetInputBindingImage(binding.effectivePath);
			}
		}
		else
		{
			Sprite buttonImage = controllerData.GetButtonImage(buttonName);
			if (buttonImage != null && image != null)
			{
				image.sprite = buttonImage;
			}
			else
			{
				Debug.Log("No valid button image found for button: " + buttonName);
			}
		}
	}

	public Sprite GetInputBindingImage(string bindingPath)
	{
		if (bindingPath.Contains("Gamepad"))
		{
			switch (InputDetection.Instance.activeInputDevice)
			{
			case CurrentInputDevice.XboxGamepad:
				if (PlayerPrefs.GetInt("ControllerOverlay") != 0 && GamepadSelector.Instance.activeGamepadImageType == GamepadImageType.Playstation)
				{
					foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad in keyBindingImageDatas.gamepadList)
					{
						if (gamepad.gamepadString == bindingPath && gamepad.playStationSprite != null)
						{
							return gamepad.playStationSprite;
						}
					}
				}
				foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad2 in keyBindingImageDatas.gamepadList)
				{
					if (gamepad2.gamepadString == bindingPath && gamepad2.xboxSprite != null)
					{
						return gamepad2.xboxSprite;
					}
				}
				return keyBindingImageDatas.unknownSprite;
			case CurrentInputDevice.PlaystationGamepad:
				if (PlayerPrefs.GetInt("ControllerOverlay") != 0 && GamepadSelector.Instance.activeGamepadImageType == GamepadImageType.XInput)
				{
					foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad3 in keyBindingImageDatas.gamepadList)
					{
						if (gamepad3.gamepadString == bindingPath && gamepad3.xboxSprite != null)
						{
							return gamepad3.xboxSprite;
						}
					}
				}
				foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad4 in keyBindingImageDatas.gamepadList)
				{
					if (gamepad4.gamepadString == bindingPath && gamepad4.playStationSprite != null)
					{
						return gamepad4.playStationSprite;
					}
				}
				return keyBindingImageDatas.unknownSprite;
			case CurrentInputDevice.SteamDeck:
				foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad5 in keyBindingImageDatas.gamepadList)
				{
					if (gamepad5.gamepadString == bindingPath && gamepad5.steamDeckSprite != null)
					{
						return gamepad5.steamDeckSprite;
					}
				}
				return keyBindingImageDatas.unknownSprite;
			}
		}
		else
		{
			switch (InputDetection.Instance.activeInputDevice)
			{
			case CurrentInputDevice.Keyboard:
				foreach (InputKeyBindingImageDatas.KeyboardBindingData keyboard in keyBindingImageDatas.keyboardList)
				{
					if (keyboard.keyboardString == bindingPath && keyboard.keyboardSprite != null)
					{
						return keyboard.keyboardSprite;
					}
				}
				foreach (InputKeyBindingImageDatas.MouseBindingData mouse in keyBindingImageDatas.mouseList)
				{
					if (mouse.mouseString == bindingPath && mouse.mouseSprite != null)
					{
						return mouse.mouseSprite;
					}
				}
				return keyBindingImageDatas.unknownSprite;
			case CurrentInputDevice.SteamDeck:
				foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad6 in keyBindingImageDatas.gamepadList)
				{
					if (gamepad6.gamepadString == bindingPath && gamepad6.steamDeckSprite != null)
					{
						return gamepad6.steamDeckSprite;
					}
				}
				return keyBindingImageDatas.unknownSprite;
			}
		}
		return keyBindingImageDatas.unknownSprite;
	}
}
