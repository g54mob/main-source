using UnityEngine;
using UnityEngine.InputSystem;

namespace AllIn1SpriteShader
{
	public static class AllIn1InputSystem
	{
		public static bool GetKeyDown(KeyCode keyCode)
		{
			Key keyFromKeycode = InputKeyConverter.GetKeyFromKeycode(keyCode);
			return Keyboard.current[keyFromKeycode].wasPressedThisFrame;
		}

		public static bool GetKey(KeyCode keyCode)
		{
			Key keyFromKeycode = InputKeyConverter.GetKeyFromKeycode(keyCode);
			return Keyboard.current[keyFromKeycode].isPressed;
		}

		public static float GetMouseXAxis()
		{
			return Mouse.current.delta.ReadValue().x * 0.1f;
		}

		public static float GetMouseYAxis()
		{
			return Mouse.current.delta.ReadValue().y * 0.1f;
		}

		public static float GetMouseScroll()
		{
			return Mouse.current.scroll.ReadValue().y * 0.1f;
		}
	}
}
