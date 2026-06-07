using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Demos.CustomPlatform
{
	public sealed class MyPlatformControllerExtension : CustomControllerExtension, IControllerVibrator
	{
		private class Source : IControllerExtensionSource
		{
			public readonly MyPlatformInputSource.Joystick sourceJoystick;

			public Source(MyPlatformInputSource.Joystick sourceJoystick)
			{
			}
		}

		public int vibrationMotorCount => 0;

		public MyPlatformControllerExtension(MyPlatformInputSource.Joystick sourceJoystick)
			: base((IControllerExtensionSource)null)
		{
		}

		private MyPlatformControllerExtension(MyPlatformControllerExtension other)
			: base((IControllerExtensionSource)null)
		{
		}

		public override Controller.Extension ShallowCopy()
		{
			return null;
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public float GetVibration(int motorIndex)
		{
			return 0f;
		}

		public void StopVibration()
		{
		}
	}
}
