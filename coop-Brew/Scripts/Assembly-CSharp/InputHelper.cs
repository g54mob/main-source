using UnityEngine;
using UnityEngine.InputSystem;

public static class InputHelper
{
	private static bool IsKeySupported(KeyCode key)
	{
		return false;
	}

	public static bool GetKey(KeyCode key)
	{
		return false;
	}

	public static bool GetKeyDown(KeyCode key)
	{
		return false;
	}

	public static bool GetKeyUp(KeyCode key)
	{
		return false;
	}

	private static Key ToKey(this KeyCode key)
	{
		return default(Key);
	}
}
