using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	public class UnityInputHandler : InputHandler
	{
		private struct Vector2Action
		{
			public string x;

			public string y;

			public Vector2Action(string x, string y)
			{
				this.x = x;
				this.y = y;
			}
		}

		private Dictionary<string, Vector2Action> vector2Actions = new Dictionary<string, Vector2Action>();

		public override bool GetBool(string actionName)
		{
			bool result = false;
			try
			{
				result = Input.GetButton(actionName);
			}
			catch (Exception)
			{
				PrintInputWarning(actionName);
			}
			return result;
		}

		public override float GetFloat(string actionName)
		{
			float result = 0f;
			try
			{
				result = Input.GetAxis(actionName);
			}
			catch (Exception)
			{
				PrintInputWarning(actionName);
			}
			return result;
		}

		public override Vector2 GetVector2(string actionName)
		{
			if (!vector2Actions.TryGetValue(actionName, out var value))
			{
				value = new Vector2Action(actionName + " X", actionName + " Y");
				vector2Actions.Add(actionName, value);
			}
			Vector2 result = default(Vector2);
			try
			{
				result = new Vector2(Input.GetAxis(value.x), Input.GetAxis(value.y));
				return result;
			}
			catch (Exception)
			{
				PrintInputWarning(value.x, value.y);
			}
			return result;
		}

		private void PrintInputWarning(string actionName)
		{
			Debug.LogWarning(actionName + " action not found! Please make sure this action is included in your input settings (axis). If you're only testing the demo scenes from Character Controller Pro please load the input preset included at \"Character Controller Pro/OPEN ME/Presets/.");
		}

		private void PrintInputWarning(string actionXName, string actionYName)
		{
			Debug.LogWarning(actionXName + " and/or " + actionYName + " actions not found! Please make sure both of these actions are included in your input settings (axis). If you're only testing the demo scenes from Character Controller Pro please load the input preset included at \"Character Controller Pro/OPEN ME/Presets/.");
		}
	}
}
