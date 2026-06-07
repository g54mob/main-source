using UnityEngine;

namespace MalbersAnimations
{
	public class DefaultInput : IInputSystem
	{
		public float GetAxis(string Axis)
		{
			return Input.GetAxis(Axis);
		}

		public float GetAxisRaw(string Axis)
		{
			return Input.GetAxisRaw(Axis);
		}

		public bool GetButton(string button)
		{
			return Input.GetButton(button);
		}

		public bool GetButtonDown(string button)
		{
			return Input.GetButtonDown(button);
		}

		public bool GetButtonUp(string button)
		{
			return Input.GetButtonUp(button);
		}

		public static IInputSystem GetInputSystem(string PlayerID = "")
		{
			return new DefaultInput();
		}
	}
}
