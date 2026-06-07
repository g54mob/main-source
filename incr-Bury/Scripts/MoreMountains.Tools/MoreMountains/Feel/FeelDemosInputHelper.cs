using UnityEngine;

namespace MoreMountains.Feel
{
	public static class FeelDemosInputHelper
	{
		public static bool ScriptInput;

		public static bool ScriptInputThisFrame;

		private const string _horizontalAxis = "Horizontal";

		private const string _verticalAxis = "Vertical";

		public static bool CheckMainActionInputPressedThisFrame()
		{
			bool result = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetMouseButtonDown(0) || ScriptInputThisFrame;
			ScriptInputThisFrame = false;
			return result;
		}

		public static bool CheckMainActionInputPressed()
		{
			if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Joystick1Button0) && !Input.GetMouseButton(0))
			{
				return ScriptInput;
			}
			return true;
		}

		public static bool CheckMainActionInputUpThisFrame()
		{
			if (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Joystick1Button0))
			{
				return Input.GetMouseButtonUp(0);
			}
			return true;
		}

		public static bool CheckEnterPressedThisFrame()
		{
			return Input.GetKeyDown(KeyCode.Return);
		}

		public static bool CheckMouseDown()
		{
			return Input.GetMouseButtonUp(0);
		}

		public static Vector2 MousePosition()
		{
			return Input.mousePosition;
		}

		public static Vector2 GetDirectionAxis(ref Vector2 direction)
		{
			direction.x = 0f;
			direction.y = 0f;
			direction.x = Input.GetAxis("Horizontal");
			direction.y = Input.GetAxis("Vertical");
			return direction;
		}

		public static bool CheckAlphaInputPressedThisFrame(int alpha)
		{
			bool result = false;
			switch (alpha)
			{
			case 1:
				result = Input.GetKeyDown(KeyCode.Alpha1);
				break;
			case 2:
				result = Input.GetKeyDown(KeyCode.Alpha2);
				break;
			case 3:
				result = Input.GetKeyDown(KeyCode.Alpha3);
				break;
			case 4:
				result = Input.GetKeyDown(KeyCode.Alpha4);
				break;
			}
			return result;
		}
	}
}
