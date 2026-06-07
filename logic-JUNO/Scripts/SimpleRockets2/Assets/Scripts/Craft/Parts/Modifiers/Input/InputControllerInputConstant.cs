using ModApi.Craft.Parts.Input;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class InputControllerInputConstant : IInputControllerInput
	{
		private float _value;

		public bool Enabled => true;

		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public InputControllerInputConstant(float value)
		{
			_value = value;
		}
	}
}
