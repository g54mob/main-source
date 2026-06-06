using System;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MalbersAnimations.InputSystem
{
	[Serializable]
	public struct FastInput
	{
		public string name;

		public bool debug;

		public InputAction input;

		[Space]
		public BoolEvent OnInputPressed;

		public UnityEvent OnInputDown;

		public UnityEvent OnInputUp;

		public readonly void InputAction(InputAction.CallbackContext context)
		{
			if (context.started || context.performed)
			{
				OnInputDown.Invoke();
				OnInputPressed.Invoke(arg0: true);
				if (debug)
				{
					Debug.Log("Input:" + name + " Pressed");
				}
			}
			else if (context.canceled)
			{
				OnInputUp.Invoke();
				OnInputPressed.Invoke(arg0: false);
				if (debug)
				{
					Debug.Log("Input:" + name + " Released");
				}
			}
		}
	}
}
