using System;
using MalbersAnimations.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class InputAxis
	{
		public bool active = true;

		public string name = "NewAxis";

		public bool raw = true;

		public string input = "Value";

		private IInputSystem inputSystem = new DefaultInput();

		public FloatEvent OnAxisValueChanged = new FloatEvent();

		private float currentAxisValue;

		public float GetAxis
		{
			get
			{
				if (inputSystem == null || !active)
				{
					return 0f;
				}
				currentAxisValue = (raw ? inputSystem.GetAxisRaw(input) : inputSystem.GetAxis(input));
				return currentAxisValue;
			}
		}

		public IInputSystem InputSystem
		{
			get
			{
				return inputSystem;
			}
			set
			{
				inputSystem = value;
			}
		}

		public InputAxis()
		{
			active = true;
			raw = true;
			input = "Value";
			name = "NewAxis";
			inputSystem = new DefaultInput();
		}

		public InputAxis(string value)
		{
			active = true;
			raw = false;
			input = value;
			name = "NewAxis";
			inputSystem = new DefaultInput();
		}

		public InputAxis(string InputValue, bool active, bool isRaw)
		{
			this.active = active;
			raw = isRaw;
			input = InputValue;
			name = "NewAxis";
			inputSystem = new DefaultInput();
		}

		public InputAxis(string name, string InputValue, bool active, bool raw)
		{
			this.active = active;
			this.raw = raw;
			input = InputValue;
			this.name = name;
			inputSystem = new DefaultInput();
		}
	}
}
