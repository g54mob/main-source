using System;
using JUTPS.CrossPlataform;
using UnityEngine;

namespace JUTPS.JUInputSystem
{
	[Serializable]
	public class CustomJoystickVirtual
	{
		public string Name;

		[SerializeField]
		private JoystickVirtual Joystick;

		public Vector2 JoystickInput()
		{
			return Joystick.InputVector;
		}
	}
}
