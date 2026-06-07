namespace Kamgam.SettingsGenerator
{
	public class ControllerVibrationConnection : Connection<bool>
	{
		private bool value;

		private static bool controllerVibrationValue;

		private static bool currentValue;

		public static bool CurrentValue
		{
			get
			{
				return currentValue;
			}
			set
			{
				currentValue = value;
				controllerVibrationValue = value;
			}
		}

		public override bool Get()
		{
			value = controllerVibrationValue;
			return value;
		}

		public override void Set(bool controllerVibration)
		{
			controllerVibrationValue = controllerVibration;
			currentValue = controllerVibrationValue;
			NotifyListenersIfChanged(controllerVibration);
		}
	}
}
