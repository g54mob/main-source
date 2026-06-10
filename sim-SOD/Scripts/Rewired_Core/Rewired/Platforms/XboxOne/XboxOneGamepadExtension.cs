using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class sDjOwIVgFsdnddtiSuODuLdwLnK : IControllerExtensionSource
		{
			public const int ZHjjBLxDSwIULZUgnbCMHwanPkf = 4;

			public DqUyzldQsPcJtEPkFoCSofUEWrn lzQfwbSYSXsuWuEKliVrxIVKzMt;

			public readonly IXboxOneInputSource RpPDZyXLsMZzPPUkrTBkOcGHweP;

			public readonly bool KTfrJbQBKhaUMbjHRbtMzWYUXDE;

			public sDjOwIVgFsdnddtiSuODuLdwLnK(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, DqUyzldQsPcJtEPkFoCSofUEWrn vibrationData)
			{
			}
		}

		private sDjOwIVgFsdnddtiSuODuLdwLnK ottLIBaLKUdMBBqnPedZdrrIelx;

		private TimerAbs[] PycTVpjFjwfCGsowmeMWFpbIOXU;

		private Joystick joystick => null;

		public int xboxOneUserId => 0;

		public ulong xboxOneJoystickId => 0uL;

		public int vibrationMotorCount => 0;

		internal XboxOneGamepadExtension(bool supportsVibration, IXboxOneInputSource xboxOneInputSource)
			: base((IControllerExtensionSource)null)
		{
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base((IControllerExtensionSource)null)
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

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			return 0f;
		}

		public void StopVibration()
		{
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
		{
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
		{
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private void QWIjVqDTqkbRucBdBwaMftUrGTU()
		{
		}

		private void byElLAxPlbLAnuFUvRVYXfGZFF(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
		}

		private void pSTDHpgvgZcefgDpqiiVHGiGTWIj()
		{
		}
	}
}
