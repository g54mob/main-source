using System;
using UnityEngine;

namespace JUTPS.JUInputSystem
{
	[Serializable]
	public class CustomInputButton
	{
		public string Name;

		[SerializeField]
		private KeyCode Input = KeyCode.P;

		public bool Pressed()
		{
			return UnityEngine.Input.GetKey(Input);
		}

		public bool PressedDown()
		{
			return UnityEngine.Input.GetKeyDown(Input);
		}

		public bool PressedUp()
		{
			return UnityEngine.Input.GetKeyUp(Input);
		}
	}
}
