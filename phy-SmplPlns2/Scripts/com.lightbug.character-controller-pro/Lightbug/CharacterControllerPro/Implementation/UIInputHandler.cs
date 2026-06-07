using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	public class UIInputHandler : InputHandler
	{
		private Dictionary<string, InputButton> inputButtons = new Dictionary<string, InputButton>();

		private Dictionary<string, InputAxes> inputAxes = new Dictionary<string, InputAxes>();

		private void Awake()
		{
			InputButton[] array = Object.FindObjectsByType<InputButton>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				inputButtons.Add(array[i].ActionName, array[i]);
			}
			InputAxes[] array2 = Object.FindObjectsByType<InputAxes>(FindObjectsSortMode.None);
			for (int j = 0; j < array2.Length; j++)
			{
				inputAxes.Add(array2[j].ActionName, array2[j]);
			}
		}

		public override bool GetBool(string actionName)
		{
			if (!inputButtons.TryGetValue(actionName, out var value))
			{
				return false;
			}
			return value.BoolValue;
		}

		public override float GetFloat(string actionName)
		{
			return 0f;
		}

		public override Vector2 GetVector2(string actionName)
		{
			if (!inputAxes.TryGetValue(actionName, out var value))
			{
				return Vector2.zero;
			}
			return value.Vector2Value;
		}
	}
}
