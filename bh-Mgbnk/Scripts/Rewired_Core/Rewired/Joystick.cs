using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int wMOHxtXJjPsFraGiTITbqRvDiRTN = 0;

		private const int LudXNlMIqtfBbCpfpbMmefqosbuJA = 1;

		private IInputManagerJoystickPublic DeWFseQblgGCkfjXAiQINbZBpksgA;

		private readonly JoystickType[] TRIJRNofnOvnYTYpsnVhAToTNDvI;

		private readonly ReadOnlyCollection<JoystickType> zZeMzvnsksFpqxALlxBzNASChiXK;

		private readonly bool OHiSYRPgKXDKQstZLbfFAoSwuuXs;

		private readonly bool FhVTYKNbzaYOZzFLbePxawlUmjTv;

		private readonly bool gxlFxcRbeJTKMGwWgEAjcxiITtTU;

		private readonly int BQrqNTzusmnngpPZiBncKmRusdRwA;

		private readonly float[] ozqEWpdVxPWtiDtTIkmmGystSpMEb;

		private readonly TimerAbs[] LybXtDUWRVDTykDnipNkCngtYksn;

		private readonly int HAYEsgJzBrjnRewobgvUlUjoagXGb;

		private readonly Hat[] LoRODOATTXgyQcwioZVAeCKenLFA;

		private readonly ReadOnlyCollection<Hat> GNVDwEgGGmYQNrFFCYdxQGbhaiTy;

		private readonly int VkefnUJPZWahJSUQVypocQhxPOivA;

		private readonly DirectionalPad[] fAlbPEAWEYhdDViywmYMHiStBcNpA;

		private readonly ReadOnlyCollection<DirectionalPad> sZbbXBaJUIVqvnAiLbqHExoFGgZUb;

		internal IList<JoystickType> GcdNOMcKonnJGQYjPAQMCdGUIgDx => null;

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

		internal int LUdhTWFTWdKKsZQqDLwilQYeKhndA => 0;

		internal HardwareControllerMapIdentifier VQwWOHkkzHSYKvnOxlHTqDGpWAth => default(HardwareControllerMapIdentifier);

		internal Joystick(BridgedController P_0)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal bool ZhlnjWLhRzSILcUjWcafYlalBBAM(JoystickType P_0)
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

		internal override void JXxDIRZpnsgiGXNGCAUihWVkSdwx(UpdateLoopType P_0)
		{
		}

		internal void QZgWghrJEuQMOBEtZAJiGrNGidTw(UpdateControllerInfoEventArgs P_0)
		{
		}

		internal void XIJRrxRHogPdxwFYzFWbRvNRzNbj(BridgedController P_0)
		{
		}

		private void gXQySzeEYLpWudVwIDPXuaoICWHaA(IInputManagerJoystickPublic P_0)
		{
		}

		internal override void fDlKuMABpdnNzezjAcKGsqfGpGcE()
		{
		}

		internal override void pmKeldfEgYcUHdSZgCOYBoCGnvRfc(bool P_0)
		{
		}

		protected override void Disconnected()
		{
		}

		private void tkWmMofhebhKoAvvJOfVEpdUjGpnA()
		{
		}

		private void YpinGhHrBEBzjPjDnwFWGmFQwqVj(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
		}

		private void mGBAlZvSEtPDMpbdVAQspfFeANKk()
		{
		}

		private void KrzJnmGxBktLeGvMgpKQYguMhSfc()
		{
		}

		internal static int kUrqalpiNSvssqfhkZEVnlvAfbubA(Joystick P_0, Joystick P_1)
		{
			return 0;
		}
	}
}
