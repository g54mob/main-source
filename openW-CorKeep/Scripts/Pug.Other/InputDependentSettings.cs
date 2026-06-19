using System;

[Serializable]
public class InputDependentSettings<T>
{
	public bool useSystemInput;

	public T keyboard;

	public T xbox;

	public T nx;

	public T playstation;

	public T playstationJapan;

	public T playstation5;

	private T currentSettings;

	public T GetBestSettings()
	{
		currentSettings = keyboard;
		switch (Manager.input.GetActiveControllerPlatformType(useSystemInput))
		{
		case InputManager.ControllerPlatformType.Keyboard:
		case InputManager.ControllerPlatformType.Mouse:
			currentSettings = keyboard;
			break;
		case InputManager.ControllerPlatformType.XboxController:
			currentSettings = xbox;
			break;
		case InputManager.ControllerPlatformType.Playstation4Controller:
			currentSettings = playstation;
			break;
		case InputManager.ControllerPlatformType.Playstation5Controller:
			currentSettings = playstation5;
			break;
		case InputManager.ControllerPlatformType.NintendoSwitchController:
			currentSettings = nx;
			break;
		}
		return currentSettings;
	}
}
