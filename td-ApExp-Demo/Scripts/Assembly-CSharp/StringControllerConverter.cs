public static class StringControllerConverter
{
	public static ControllerType GetController(string name)
	{
		if (name.Contains("Keyboard") || name.Contains("Mouse"))
		{
			return ControllerType.KeyboardMouse;
		}
		if (name.Contains("XInput"))
		{
			return ControllerType.GamepadXBox;
		}
		if (name.Contains("DualShock"))
		{
			return ControllerType.GamepadPS4;
		}
		if (name.Contains("DualSense"))
		{
			return ControllerType.GamepadPS5;
		}
		if (name.Contains("Keyboard") && !name.Contains("Mouse"))
		{
			return ControllerType.Keyboard;
		}
		return ControllerType.None;
	}

	public static string GetName(ControllerType type)
	{
		return type switch
		{
			ControllerType.KeyboardMouse => "Keyboard", 
			ControllerType.GamepadXBox => "GamepadXBox", 
			ControllerType.GamepadPS4 => "DualShock", 
			ControllerType.GamepadPS5 => "DualSense", 
			ControllerType.Keyboard => "Keyboard", 
			_ => "None", 
		};
	}
}
