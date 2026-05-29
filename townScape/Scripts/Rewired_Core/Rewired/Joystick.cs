using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int LEFT_MOTOR_INDEX = 0;

		private const int RIGHT_MOTOR_INDEX = 1;

		private IInputManagerJoystickPublic _sourceJoystick;

		private readonly JoystickType[] _joystickTypes;

		private readonly ReadOnlyCollection<JoystickType> _joystickTypes_readOnly;

		private readonly bool _supportsVibration;

		private readonly bool _supportsLocalVibration;

		private readonly bool _supportsVoice;

		private readonly int _localVibrationMotorCount;

		private readonly float[] _localVibrationMotorValues;

		private readonly TimerAbs[] _localVibrationStopTimers;

		private readonly int _hatCount;

		private readonly Hat[] _hats;

		private readonly ReadOnlyCollection<Hat> hats_readOnly;

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

		internal bool IsType(JoystickType joystickType)
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

		internal override void NFSHGTXxwNpYHMyToumsXPPmaYz(UpdateLoopType updateLoop)
		{
		}

		internal void UpdateControllerInfo(UpdateControllerInfoEventArgs args)
		{
		}

		internal void UpdateControllerInfo(BridgedController controller)
		{
		}

		private void UpdateControllerInfo(IInputManagerJoystickPublic joystick)
		{
		}

		internal override void CKSoitBPjLqWpFGpwBNgDbvTrVm()
		{
		}

		protected override void Disconnected()
		{
		}

		private void CheckVibrationTimeout()
		{
		}

		private void SetLocalVibration(int motorIndex, float motorLevel, float motorDuration, bool stopOtherMotors, bool updateNow)
		{
		}

		private void UpdateLocalControllerVibration()
		{
		}

		private void StopAllVibration()
		{
		}

		internal static int CompareById_Ascending(Joystick a, Joystick b)
		{
			return 0;
		}
	}
}
