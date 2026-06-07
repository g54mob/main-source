namespace Kamgam.SettingsGenerator
{
	public class CameraSmoothingConnection : Connection<float>
	{
		public float smoothing;

		private float value;

		private static float currentValue;

		public static float CurrentValue => currentValue;

		public CameraSmoothingConnection(float currSmoothing)
		{
			smoothing = currSmoothing;
		}

		public override float Get()
		{
			return value;
		}

		public override float GetDefault()
		{
			return 0f;
		}

		public override void Set(float volume)
		{
			value = volume;
			currentValue = volume;
		}
	}
}
