using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int LTWSdHIWoHHOZjWCqDkLmgMHjlX = 0;

		private const int cqtALaTBMYZbZEBpHyQQyGYlakS = 1;

		private IInputManagerJoystickPublic PsAksowKuVGzCHNbRxBSqLWgWwm;

		private readonly JoystickType[] WfyQmCjRXTwkenAplzeonpnTROl;

		private readonly ReadOnlyCollection<JoystickType> vfrRXCErQZMlGOKxGNqeSpzlzWw;

		private readonly bool VzYtArxDKBQJJkpZOaFkCQeHajMD;

		private readonly bool rDZzseZtRsGUCgxuUpZBFNFJVIJ;

		private readonly bool aWpVEpOzVzFoNSjvQaTiGOzfBxbf;

		private readonly int WEJwycBjkxmxsINitIKVgqxzUqa;

		private readonly float[] xvjimJsrJajSrUFITzlXVByxOpF;

		private readonly TimerAbs[] dtufqmDTpnNlKCkoGbzsOnIeFibq;

		private readonly int ytCbcYFzcbeuxEWyOxjxqlFvpeq;

		private readonly Hat[] uCrmxplRlvSFhGfBOoIgaNYXABhh;

		private readonly ReadOnlyCollection<Hat> ISiycqFgTTtWWsPeIndhwoIJlMt;

		internal IList<JoystickType> joystickTypes => null;

		public long? systemId => null;

		public int unityId => 0;

		public override Guid deviceInstanceGuid => default(Guid);

		public bool supportsVibration => false;

		public float vibrationLeftMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int vibrationMotorCount => 0;

		public int hatCount => 0;

		public IList<Hat> Hats => null;

		internal int inputManagerId => 0;

		internal HardwareControllerMapIdentifier hardwareJoystickMapIdentifier => default(HardwareControllerMapIdentifier);

		internal Joystick(BridgedController controller)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal bool ejwpdLaDwBGotKKvTRqijujUVMD(JoystickType P_0)
		{
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			return null;
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
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

		internal override void IdvXxslbVpgePKGcszHAudaDgmvT(UpdateLoopType P_0)
		{
		}

		internal void LNJCviqtSOvahDBfOGyQgxMdCld(UpdateControllerInfoEventArgs P_0)
		{
		}

		internal void LNJCviqtSOvahDBfOGyQgxMdCld(BridgedController P_0)
		{
		}

		private void LNJCviqtSOvahDBfOGyQgxMdCld(IInputManagerJoystickPublic P_0)
		{
		}

		internal override void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		internal override void aYscBdBbWIIgUMQjVZygRDyLkhan(bool P_0)
		{
		}

		protected override void Disconnected()
		{
		}

		private void QWIjVqDTqkbRucBdBwaMftUrGTU()
		{
		}

		private void uoalvcpJAEPraMKyEVMGkffEdhz(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
		}

		private void ENSjbVpuUCobWFpKlTqdRQqywUx()
		{
		}

		private void alxaIkKmCutaazDjQDNhKCWbmLQE()
		{
		}

		internal static int GZccIRKdoBFtQqDCldbHZGfKrGiM(Joystick P_0, Joystick P_1)
		{
			return 0;
		}
	}
}
