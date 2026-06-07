namespace Kamgam.SettingsGenerator
{
	public class ControllerVibrationIntensityConnection : Connection<float>
	{
		public float controllerVibrationIntensity;

		private float value;

		private static float currentValue;

		public static float CurrentValue => currentValue;

		public ControllerVibrationIntensityConnection(float currentControllerVibrationIntensity)
		{
			controllerVibrationIntensity = currentControllerVibrationIntensity;
		}

		public override float Get()
		{
			return value;
		}

		public override float GetDefault()
		{
			return 1f;
		}

		public override void Set(float volume)
		{
			value = volume;
			currentValue = volume;
		}
	}
}
