using System;
using JUTPS.CrossPlataform;
using UnityEngine;

namespace JUTPS.JUInputSystem
{
	[Serializable]
	public class CustomTouchButton
	{
		public string Name;

		[SerializeField]
		private ButtonVirtual ButtonInput;

		public bool Pressed()
		{
			return ButtonInput.IsPressed;
		}

		public bool PressedDown()
		{
			return ButtonInput.IsPressedDown;
		}

		public bool PressedUp()
		{
			return ButtonInput.IsPressedUp;
		}
	}
}
