namespace Rewired.Platforms.PS4
{
	public sealed class PS4AimExtension : PS4ControllerExtension
	{
		private IPS4AimExtensionSource Source => null;

		internal PS4AimExtension(IPS4AimExtensionSource source)
			: base((IPS4ControllerExtensionSource)null)
		{
		}

		private PS4AimExtension(PS4AimExtension source)
			: base((IPS4ControllerExtensionSource)null)
		{
		}

		public float GetVibration(PS4AimMotorType motor)
		{
			return 0f;
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel)
		{
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(float strongMotorLevel, float weakMotorLevel)
		{
		}

		public void SetVibration(float strongMotorLevel, float weakMotorLevel, float strongMotorDuration, float weakMotorDuration)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private static int lvwSqIQtOiBwiJqdlVeItTjNGlO(PS4AimMotorType P_0)
		{
			return 0;
		}
	}
}
