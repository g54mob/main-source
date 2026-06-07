using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class EeBjZomyKmhEjuvTDjsOpCttDOOo : IControllerExtensionSource
		{
			public const int srpKZbYsaMFiNrvNwdcVdSUysCCP = 4;

			public poqVdBSaRLeupdLkAXXVBdSVpptwA YkjSmunnuLFsEAShJXTRRjtmGbyIA;

			public readonly IXboxOneInputSource eDThpVCwUyxEzqcaXECHyUtjQQQk;

			public readonly bool dlIPCSMLwehPSpoyegaHRPfolceV;

			public EeBjZomyKmhEjuvTDjsOpCttDOOo(bool P_0, IXboxOneInputSource P_1, poqVdBSaRLeupdLkAXXVBdSVpptwA P_2)
			{
			}
		}

		private EeBjZomyKmhEjuvTDjsOpCttDOOo pCOzBpBBWWmVDIAMioRntaAhWrvU;

		private TimerAbs[] IjxrnbyVleHaHrBGBakXDyHMZGDvA;

		private Joystick joystick => null;

		public int xboxOneUserId => 0;

		public ulong xboxOneJoystickId => 0uL;

		public int vibrationMotorCount => 0;

		internal XboxOneGamepadExtension(bool P_0, IXboxOneInputSource P_1)
			: base((IControllerExtensionSource)null)
		{
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
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

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private void LCgMYtVgBCOLGVdnRDEtMYnbIZxq()
		{
		}

		private void qzEwUchLlqhkZdbmSlISIBrbOzGU(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
		}

		private void RELAbjdAGHpeucybhevvWwHIMvDPA()
		{
		}
	}
}
