using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int hWfBnSPofOUdUdaniFlrQrLEiowaA = 0;

		private const int IYEhBUSCqmfYAZDoSBmoiLCtTAPJA = 1;

		private IInputManagerJoystickPublic YOnsSFOclnGBDFuKbIiYbFdaMBFqB;

		private readonly JoystickType[] QpSjkdmdPhgvSSkZoHjgyQOzwSZ;

		private readonly ReadOnlyCollection<JoystickType> ggLqOSxkizADEwRkMXxstsHVEgoB;

		private readonly bool PNZEwgVmGACLpajSsIBPNeexSRoQA;

		private readonly bool QokgwpZEvnWNquAAWtpzOrHPlIuv;

		private readonly bool vVCPXPTfeCTJbRZHBGufOPGRqSiU;

		private readonly int MLAenslustnkTemKBbRkhGlvVCeWA;

		private readonly float[] rQBSyYDcdWosRoLInNOqIJIcyUtT;

		private readonly TimerAbs[] OrYZTyIxRWDQNzcaPsdkoFKwxLVn;

		private readonly int CFhvUFzIBojoyDllAKXEqNVreLoiA;

		private readonly Hat[] YnNmSaEJZChMVRgfZfVDwdgPGZsh;

		private readonly ReadOnlyCollection<Hat> FwkBjlyUEbAZkgiKrEyxwMTmlJcY;

		private readonly int QpNvPbTPDJegsGHPaHVoBuZFuhBSB;

		private readonly DirectionalPad[] eYKbpfaKCNTekvvdHLcWUSomCDaPA;

		private readonly ReadOnlyCollection<DirectionalPad> tVEwzkNRGJcxYHYjuiSNBnSPgNmkA;

		internal IList<JoystickType> FEKbnJymnikfjNsMweCqeaPTViqB => null;

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

		public int directionalPadCount => 0;

		public IList<DirectionalPad> DirectionalPads => null;

		internal int AlMUvvTnIgrTRXyrwbEgurgdFIKr => 0;

		internal HardwareControllerMapIdentifier YLCwakRxQZFrcauCaNHIKvwulUt => default(HardwareControllerMapIdentifier);

		internal Joystick(BridgedController P_0)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal bool WLMKJtRjRatHetQsbdWfctYeiQxJ(JoystickType P_0)
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

		internal override void KvONimPsnvghlMkZzyXoBEjvJCHX(UpdateLoopType P_0)
		{
		}

		internal void LhNaCDtQBlFhlOmjcxEuebnJKMyh(UpdateControllerInfoEventArgs P_0)
		{
		}

		internal void IcncIVaTpJCUlQRYUlrjJjSEQQCA(BridgedController P_0)
		{
		}

		private void xRpAqOCySAaRZouzzblBqIUVovimA(IInputManagerJoystickPublic P_0)
		{
		}

		internal override void scCwpLEHFiuvitLgzEfOOpCTYgPj()
		{
		}

		internal override void crbQLMpBgFCTkCHGXdkEoAiefEsyA(bool P_0)
		{
		}

		protected override void Disconnected()
		{
		}

		private void aSzJmTlgeyGJHagaiaFFaXPDDbEyb()
		{
		}

		private void NuZdBOZqXPLKKQCOCoUQypjDcTmQ(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
		}

		private void ljiomptAjsUznqkqgqgOVterxabd()
		{
		}

		private void LvUpLKWhBbaPkPgQBNdEgWpVKxdD()
		{
		}

		internal static int dIAeAKtMNNvvJzlcRCiRITZPdWRXA(Joystick P_0, Joystick P_1)
		{
			return 0;
		}
	}
}
