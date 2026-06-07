using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public class InputHandlerSettings
	{
		[Tooltip("Input manager: Unity's old input manager\n\nUI Mobile : It uses specific UI elements in the scene (InputButton and InputAxes component) as inputs. Make sure these elements \"action names\" match with the character actions you want to trigger.\n\nCustom: A custom implementation.")]
		[SerializeField]
		private HumanInputType humanInputType;

		[SerializeField]
		[Condition("humanInputType", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 2f)]
		private InputHandler inputHandler;

		public InputHandler InputHandler
		{
			get
			{
				return inputHandler;
			}
			set
			{
				inputHandler = value;
			}
		}

		public void Initialize(GameObject gameObject)
		{
			if (inputHandler == null)
			{
				inputHandler = InputHandler.CreateInputHandler(gameObject, humanInputType);
			}
		}
	}
}
