using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	public abstract class InputHandler : MonoBehaviour
	{
		public static InputHandler CreateInputHandler(GameObject gameObject, HumanInputType inputType)
		{
			InputHandler result = null;
			switch (inputType)
			{
			case HumanInputType.InputManager:
				result = gameObject.AddComponent<UnityInputHandler>();
				break;
			case HumanInputType.UIMobile:
				result = gameObject.AddComponent<UIInputHandler>();
				break;
			}
			return result;
		}

		public abstract bool GetBool(string actionName);

		public abstract float GetFloat(string actionName);

		public abstract Vector2 GetVector2(string actionName);
	}
}
