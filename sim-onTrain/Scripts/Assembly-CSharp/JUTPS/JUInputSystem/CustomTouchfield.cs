using System;
using JUTPS.CrossPlataform;
using UnityEngine;

namespace JUTPS.JUInputSystem
{
	[Serializable]
	public class CustomTouchfield
	{
		public string Name;

		[SerializeField]
		private Touchfield TouchfieldInput;

		public Vector2 TouchDistance()
		{
			return TouchfieldInput.TouchDistance;
		}
	}
}
