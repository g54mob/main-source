namespace Kamgam.SettingsGenerator
{
	public class CameraShakeConnection : Connection<bool>
	{
		private bool value = true;

		private static bool currentValue;

		public static bool CurrentValue => currentValue;

		public override bool Get()
		{
			return value;
		}

		public override void Set(bool cameraShake)
		{
			value = cameraShake;
			currentValue = value;
			NotifyListenersIfChanged(cameraShake);
		}
	}
}
