using UnityEngine;
using UnityEngine.InputSystem;

namespace InputControl
{
	public static class InputActionExtension
	{
		public static bool HoldAndKeep(this InputAction inputAction)
		{
			return false;
		}

		public static (bool, Vector2Int) GetStickStepOrKeep(this InputAction inputAction)
		{
			return default((bool, Vector2Int));
		}
	}
}
