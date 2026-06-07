using System;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class CustomControllerDemo : MonoBehaviour
	{
		public int playerId;

		public string controllerTag;

		public bool useUpdateCallbacks;

		private int buttonCount;

		private int axisCount;

		private float[] axisValues;

		private bool[] buttonValues;

		private TouchJoystickExample[] joysticks;

		private TouchButtonExample[] buttons;

		private CustomController controller;

		[NonSerialized]
		private bool initialized;

		private void Awake()
		{
		}

		private void Initialize()
		{
		}

		private void Update()
		{
		}

		private void OnInputSourceUpdate()
		{
		}

		private void GetSourceAxisValues()
		{
		}

		private void GetSourceButtonValues()
		{
		}

		private void SetControllerAxisValues()
		{
		}

		private void SetControllerButtonValues()
		{
		}

		private float GetAxisValueCallback(int index)
		{
			return 0f;
		}

		private bool GetButtonValueCallback(int index)
		{
			return false;
		}
	}
}
