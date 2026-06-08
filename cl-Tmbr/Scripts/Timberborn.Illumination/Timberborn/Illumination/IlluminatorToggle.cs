namespace Timberborn.Illumination
{
	public class IlluminatorToggle
	{
		private readonly Illuminator _illuminator;

		private bool _isOn;

		internal IlluminatorToggle(Illuminator illuminator)
		{
			_illuminator = illuminator;
		}

		public void TurnOn()
		{
			if (!_isOn)
			{
				_illuminator.IncrementTurnedOnToggles();
				_isOn = true;
			}
		}

		public void TurnOff()
		{
			if (_isOn)
			{
				_illuminator.DecrementTurnedOnToggles();
				_isOn = false;
			}
		}

		public void Toggle(bool value)
		{
			if (value)
			{
				TurnOn();
			}
			else
			{
				TurnOff();
			}
		}
	}
}
