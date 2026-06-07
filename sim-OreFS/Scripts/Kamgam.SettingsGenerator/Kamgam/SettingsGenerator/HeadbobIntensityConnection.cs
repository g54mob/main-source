namespace Kamgam.SettingsGenerator
{
	public class HeadbobIntensityConnection : Connection<float>
	{
		public float headbobIntensity;

		private float value;

		private static float currentValue;

		public static float CurrentValue => currentValue;

		public HeadbobIntensityConnection(float currentHeadbobIntensity)
		{
			headbobIntensity = currentHeadbobIntensity;
		}

		public override float Get()
		{
			return value;
		}

		public override float GetDefault()
		{
			return 0.08f;
		}

		public override void Set(float volume)
		{
			value = volume;
			currentValue = volume;
		}
	}
}
