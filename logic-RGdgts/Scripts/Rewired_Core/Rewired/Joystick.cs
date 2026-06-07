using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int TFUNNCCCyzBDrrswlncQsEnSWCUL = 0;

		private const int iCtLorZPIuLejEOFCYfTkebcDBJy = 1;

		private IInputManagerJoystickPublic NGGCdldmafityAXNOqnLyBtdiZjMA;

		private readonly JoystickType[] GtuZnRzQDnsBOtlkoBXzhuSGsEkI;

		private readonly ReadOnlyCollection<JoystickType> lRfYWZQUDjSxqUJUThllESUuCGfe;

		private readonly bool NlEsLwrKCjqFrmBfZfjrECLGFIHGb;

		private readonly bool xqNirlJBkMOaswGvDBOGRgkMgEUD;

		private readonly bool cixQEmCLnZZSfYFIBpbjKDCkSZqF;

		private readonly int AsTPrhBOwVirWSiSaPkYiBYwYVtV;

		private readonly float[] dilbvUiHtYfgLWwVSNTAVBZchSxc;

		private readonly TimerAbs[] hesHthBSpPCxecJCoIHxlTtAsZpM;

		private readonly int afMIxBrXmXrqVGpSHUPmcKwoLJjm;

		private readonly Hat[] osjcmqtxfDATJKIlJrinuyrAIscRA;

		private readonly ReadOnlyCollection<Hat> OfarxzVBZhlkkqfWJTviiLzKGtyg;

		internal IList<JoystickType> gblvScfyvozvFqGbesEpZxqIczti => null;

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

		internal int qaWdomDkXYbyYcgkBEEJSjidPqMv => 0;

		internal HardwareControllerMapIdentifier QffiBMTMryEswOxOSXKFrNXqjHhj => default(HardwareControllerMapIdentifier);

		internal Joystick(BridgedController P_0)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal bool uvcoqQqmrleBNYXAMWMhdWdTvgQg(JoystickType P_0)
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

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
		}

		internal void VbVBYliTbuvVNPetPsBZqFKmHxco(UpdateControllerInfoEventArgs P_0)
		{
		}

		internal void VbVBYliTbuvVNPetPsBZqFKmHxco(BridgedController P_0)
		{
		}

		private void VbVBYliTbuvVNPetPsBZqFKmHxco(IInputManagerJoystickPublic P_0)
		{
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
		}

		internal override void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
		{
		}

		protected override void Disconnected()
		{
		}

		private void AMMeAhkLwOBFGwkLSkKJbpphoqDmc()
		{
		}

		private void eckYuhrQGmhxKCkKPQpDiTCNKwwK(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
		}

		private void MZSgYGhYocewiTaTylarBTZjLmac()
		{
		}

		private void cWtBAxEKfCaXWlJKNdpiEdvygRFd()
		{
		}

		internal static int IlwjNInzmxvVcBXkwDzCSGORdgzi(Joystick P_0, Joystick P_1)
		{
			return 0;
		}
	}
}
