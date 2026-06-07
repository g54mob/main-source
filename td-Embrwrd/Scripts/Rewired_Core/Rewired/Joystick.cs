using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int pzJRLhGcRMvRrYmnubbZqltviLYM = 0;

		private const int UzkIPfNqMoEmnwZmGkcAfeuIghdJA = 1;

		private IInputManagerJoystickPublic AmJceyDtBnKpmHFYdEiqdhPvLgbeb;

		private readonly JoystickType[] URBtNHdTNLwYApuwVViZKYmhPFcI;

		private readonly ReadOnlyCollection<JoystickType> umjwKbkTSrjyeFnLSBTJVcOghhWhA;

		private readonly bool XizUqNOHyWlhAWPYmTSdGrUAwFQl;

		private readonly bool YIMYlQSaNnvvFLEAQnxLiGrcpsGF;

		private readonly bool xSglxkAHCKHvGgBJVyqHqpksTtIX;

		private readonly int UjcReVglSpWRwZBUFZDOgyDSljEF;

		private readonly float[] znYAhAANEAEmaFIxRISIewLglRjb;

		private readonly TimerAbs[] CLqprBVxLGaneIwfFjuOOcYLuDpD;

		private readonly int ONUsqxilwvCZAAbWPHqMUrCPkMDA;

		private readonly Hat[] QTnfCZFNjSjNaSopFerxUAYuojCgA;

		private readonly ReadOnlyCollection<Hat> NYORFOzOwhxlJViEtMmJIibHMcIw;

		private readonly int SjnnIWAtoHGBioJewPCKSdBZChqc;

		private readonly DirectionalPad[] iteLnOPizJQQRQdqLgZewQcPcOQC;

		private readonly ReadOnlyCollection<DirectionalPad> lqyPNjAoGFZrEknNkSlebweacdEd;

		internal IList<JoystickType> NksUBUllEqHGOHmgsayotMSsByUgb => null;

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

		internal int SmXwIWewoffusMrgFGUAQQEvbuPA => 0;

		internal HardwareControllerMapIdentifier GLhSSFnnFCXvGLRyGFZtciJBVOwT => default(HardwareControllerMapIdentifier);

		internal Joystick(BridgedController P_0)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal bool MIijYSKOzsryPMOoxGJFAHyJFwJm(JoystickType P_0)
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

		internal override void CSiaEXSpXvcRSFdVhCeIWbTYQhvjA(UpdateLoopType P_0)
		{
		}

		internal void DMnvEjcOohTpGpGmeEzGUvHwGhOKA(UpdateControllerInfoEventArgs P_0)
		{
		}

		internal void GhAtHnAldtImbjETSMnTIFVdKpwab(BridgedController P_0)
		{
		}

		private void nOPKwvleoGbseVrsxtJfgicgAlGD(IInputManagerJoystickPublic P_0)
		{
		}

		internal override void igkEEaHPzoACJWIsdSAeIycaNzjBA()
		{
		}

		internal override void mqDdjbinUHqhNkJGDAiqbqUVlpYZ(bool P_0)
		{
		}

		protected override void Disconnected()
		{
		}

		private void asVSsswlGerdaPBiuXrbldpoaQym()
		{
		}

		private void VWxQdbKFjNywxbwSUsYoUsBuFuOp(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
		}

		private void zpOwMVwymiauGDViiHsEbkXUgIVfA()
		{
		}

		private void ZbyDRdETVxWQXCmmRkNwiAsCufTQB()
		{
		}

		internal static int rHcqEbgNnJBFcGgkDIopnJtiExdy(Joystick P_0, Joystick P_1)
		{
			return 0;
		}
	}
}
