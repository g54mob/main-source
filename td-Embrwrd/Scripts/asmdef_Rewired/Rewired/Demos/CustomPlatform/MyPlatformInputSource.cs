using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	public sealed class MyPlatformInputSource : CustomPlatformInputSource
	{
		public new sealed class Joystick : CustomPlatformInputSource.Joystick, IControllerVibrator
		{
			private UnityInputJoystickSource.Joystick _sourceJoystick;

			public UnityInputJoystickSource.Joystick sourceJoystick => null;

			public int vibrationMotorCount => 0;

			public Joystick(UnityInputJoystickSource.Joystick sourceJoystick)
				: base(null, 0L, 0, 0)
			{
			}

			public override void Update()
			{
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

		private UnityInputJoystickSource _joystickInputSource;

		private bool _initialized;

		private bool _disposed;

		public override bool isReady => false;

		public MyPlatformInputSource(CustomPlatformConfigVars configVars)
			: base(null, null)
		{
		}

		protected override void OnInitialize()
		{
		}

		public override void Update()
		{
		}

		private void MonitorDeviceChanges()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private static bool ContainsJoystickBySystemId(IList<CustomInputSource.Joystick> joysticks, long systemId)
		{
			return false;
		}

		private static bool ContainsSystemJoystickBySystemId(IList<UnityInputJoystickSource.Joystick> systemJoysticks, long systemId)
		{
			return false;
		}
	}
}
