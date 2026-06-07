using System.Collections.Generic;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms.Custom;

namespace Rewired.Platforms.XboxOne
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		[CustomObfuscation(rename = false)]
		private enum BadConnectionReason
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			GamepadNotActive = 1,
			[CustomObfuscation(rename = false)]
			InvalidName = 2
		}

		private struct zNbNXdYxFmTXfxQQcFyCqZIoWzMO
		{
			public uint BlFwdumMbvjlqnennBbwfUkuFCxHA;

			public uint DOdvtPRJAVVeyxTehJrzKaqZXKPL;

			public zNbNXdYxFmTXfxQQcFyCqZIoWzMO(uint P_0, uint P_1)
			{
				BlFwdumMbvjlqnennBbwfUkuFCxHA = 0u;
				DOdvtPRJAVVeyxTehJrzKaqZXKPL = 0u;
			}
		}

		private class JmyDIDspvhOEiLUyAvBAwHGfAIUM : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int stLZOlttFoLuHKdAyoEnWRdkrHeM = 6;

			private const int ylwWGWQMvHkTCxTbQWfnAMvqzsPT = 14;

			private const string KKDnOshaTdMyFcuekduPfgPbhLWEA = "Xbox One Controller";

			private const string hsgdznvEHRzjUAhxMEzUKemgWNwi = "Controller";

			private const int aCuVNRmCDGsyNzJyouustxivMcbg = 0;

			private const int TkykZrBMHpnVsUwzkQSDKNwcJbVE = 1;

			private const int gMLKmkZlZwDnIhcQAKdqErFfQHJoB = 2;

			private const int cPeXCXgeKxHFrmEKYlGhOZcMFFHj = 3;

			private const int kQbmvenowQffhdIGtQAtsEIcUfbE = 4;

			private const int cntopXKQnHPgmpMPKgRErzKpcnKV = 5;

			private const int tDQWigzhCcdwXFlFAoUhjmCSRqRmA = 6;

			private const int zPUfUCeEDjWEKIRdEpGPjoCUiVCy = 7;

			private const int zbkpwseWvspnHFroSNdUMlcxESAk = 8;

			private const int BmQrrkXVNuLjJSpsOZTqTnnHVsyv = 9;

			private const int KVVrUdIclqXeeENSuNfGklYsNwpl = 12;

			private const int bQSEjwANnTMpveLfCVUMjELDyfbwA = 13;

			private const int YxZLLJvpThOwplbEqjzQDNyOCgZI = 14;

			private const int LjaVLrCSnFMpwspcFHnfaUfzaWtGA = 15;

			private const int XXZvspvNePMahFeDRXblpILlVFYG = 0;

			private const int UBwiTHuqDMUBaWkpHMqixGbxecEz = 1;

			private const int UWiXbyXvJIhmKMECpepiuJMATNbl = 3;

			private const int sHyJDvQdgRmUmqExCBkavbiwTveK = 4;

			private const int qgPFZVgfziepciWMDwQSNBpLdrDmA = 8;

			private const int wOvAuFEaKayBTPSukGIvCXpAgxhLB = 9;

			private readonly IXboxOneInputSource KrwKRFrbrlGkJOtBvUUkYAUPsAyC;

			private int xOVoXaoztVllUioQoyuftjrNcCje;

			private ulong IwUBeZheZtDanvkvjmDpAkTjycbcc;

			private string[] zyidSqEkDQekbuRjwAmAmeChcGGH;

			private HardwareJoystickMap_InputManager ekTmgtlMdpXKsSqfHrnJtpAMGpwaA;

			private readonly LocalizedString DvcevQsgHhgHWdRLYXIxNtACqKWZ;

			public ulong QUwXljPlRcMDlJGPSDyxfEfggMOoA => 0uL;

			public JmyDIDspvhOEiLUyAvBAwHGfAIUM(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(null, 0L, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void iyrlYWLTTLnOIfKMQluZXYChweUj(ulong P_0)
			{
			}

			private void rmEqwKRSOatjRQCZzFqCyTeQyfDn()
			{
			}

			private bool kNZzCkrTdAqPnIPOGESHeNmgQlNHA(int P_0)
			{
				return false;
			}

			private void zXcdJyDmqeGcBYAfLrApJFEcoRZdA()
			{
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				value = null;
				return false;
			}
		}

		private const int qOtAmtloSNTOilIQZXpyjnmwWSqq = 8;

		private readonly bool PxCEOsQoKtbHehlYZrUeUOsnfXUR;

		private bool aWaLupVvncwvvUfCqbqLdSlqFqkBA;

		private Queue<zNbNXdYxFmTXfxQQcFyCqZIoWzMO> daXDuUeeaJNOgvCchTndITAinfzUA;

		private bool zLwuHUaKxzTKqjuTEcmVWGWeRCuW;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void zFKauHekHQAfhGrZGOGifweWzoOWb(uint P_0, bool P_1)
		{
		}

		private void hdsYBviTtZPBkZTHnKgRizsSkDUG(uint P_0, bool P_1)
		{
		}

		private void eZCekzIGUxOlUrTfrCpEDyYcalHnc()
		{
		}

		private bool zkfqgwRrBUAHgZipsrPngtKXaLTA(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void EdtMDLRhwNLtbHWDwTZCkafosLDw()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, vkILuKPvdHIKCqiXEDJbDuPsYCTd vibration)
		{
			return false;
		}

		public override void Dispose()
		{
		}

		~XboxOneInputSource()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
