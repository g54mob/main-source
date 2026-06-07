using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.InputSystem
{
	[AddComponentMenu("Malbers/Input/Fast Input")]
	public class MFastInput : MonoBehaviour
	{
		[NonReorderable]
		public FastInput[] inputs;

		private void OnEnable()
		{
			if (inputs == null && inputs.Length == 0)
			{
				return;
			}
			for (int i = 0; i < inputs.Length; i++)
			{
				inputs[i].input.Enable();
				inputs[i].input.started += inputs[i].InputAction;
				inputs[i].input.canceled += inputs[i].InputAction;
				if (inputs[i].OnInputPressed == null)
				{
					inputs[i].OnInputPressed = new BoolEvent();
				}
				if (inputs[i].OnInputDown == null)
				{
					inputs[i].OnInputDown = new UnityEvent();
				}
				if (inputs[i].OnInputUp == null)
				{
					inputs[i].OnInputUp = new UnityEvent();
				}
			}
		}

		private void OnDisable()
		{
			if (inputs != null || inputs.Length != 0)
			{
				for (int i = 0; i < inputs.Length; i++)
				{
					inputs[i].input.started -= inputs[i].InputAction;
					inputs[i].input.canceled -= inputs[i].InputAction;
					inputs[i].input.Disable();
				}
			}
		}
	}
}
