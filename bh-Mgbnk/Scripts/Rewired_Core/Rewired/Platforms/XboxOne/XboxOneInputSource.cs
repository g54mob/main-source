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

		private struct miyZWpTlfrgbhFZVVSteyfKElQFk
		{
			public uint UYShWylDBqCBgTsHAHvAtqYAMTuC;

			public uint YNmtvZUykEnusHkdSgxFAEephNOqA;

			public miyZWpTlfrgbhFZVVSteyfKElQFk(uint P_0, uint P_1)
			{
				UYShWylDBqCBgTsHAHvAtqYAMTuC = 0u;
				YNmtvZUykEnusHkdSgxFAEephNOqA = 0u;
			}
		}

		private class UJnRHJtIBeEpunQvxbRqwsAVzSVo : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int btMIEdklntFPTuBJFueREnKYZDtE = 6;

			private const int xytUbCXALKiOMJBuvDFJEpdGeiIJ = 14;

			private const string RRAWyuektmJqHOCtLIqnzHVDiNRU = "Xbox One Controller";

			private const string eerunhytzCjIMgmyttioImgIRWfq = "Controller";

			private const int bqvzVTdNyZcNNIDQHkMUUhrNASiYA = 0;

			private const int MjjZufUWskuGeuJhTgidAUHAVVIlA = 1;

			private const int xdEeJgIZjzYxAKvTdVAAliBcHHGv = 2;

			private const int zCtUXRlLQcsmjEiJfaZFHMkwIPUfb = 3;

			private const int bZubynygGFeCphHPIYsHigGCMOcHb = 4;

			private const int lGyzcPLdDGdVgHrEhqfoxoKJonNR = 5;

			private const int cwNgacyBwlDYRLcWrwmHwGMqacYK = 6;

			private const int wTPBEGrdnyjnYjskjvazcbYaQPRgA = 7;

			private const int krnkiutMDdAsRlohlHhoWfaNWSLm = 8;

			private const int CeXzteWcdhMzDsEbjhgGFcnfJsdx = 9;

			private const int DoISVhBGDpLVqyaDNFhuqfAMCFqs = 12;

			private const int aNjeiGDHKKKrvvuvclyEQBflMsi = 13;

			private const int FCYnNBswdgNfhLGDXyTgNBqcCIMz = 14;

			private const int KAlHshZDDIUBeKOrsZVRehjZEAkj = 15;

			private const int YLYDzaBqbEMjgufhyIzNItGPuJPSA = 0;

			private const int BynVwFtfjTHkwwLowDAQkrtFlqPzA = 1;

			private const int ZpflNaMpdFSWIcYLEWaGqyKkRNsl = 3;

			private const int lotoFnFQACmTmIomrGjWvNiEmZrv = 4;

			private const int vFOHJpzXYnQsHuBYgwswBnwztUtB = 8;

			private const int xnomjNdasjudDqfTLswNLdeIraog = 9;

			private readonly IXboxOneInputSource BffaARwxBmztByJmGgoEMtAhDajy;

			private int gbYwoixoFMcUAeCtRXUVixflKaqGA;

			private ulong VZZccLzljcBdtQDcSbKLgDRKgimJ;

			private string[] eXbtveFCvVnLpCDaBTuegqYLAwLr;

			private HardwareJoystickMap_InputManager xsYusnaTFshheefqcNbllYEadElK;

			private readonly LocalizedString KYvCzMtNzefwYzUWptiLbRCirOTn;

			public ulong DHnbthEbMtweblUsjITXUrQWGBlc => 0uL;

			public UJnRHJtIBeEpunQvxbRqwsAVzSVo(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(null, 0L, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void vRoQnUYOtQbSIBfZtBjhHtADqgVH(ulong P_0)
			{
			}

			private void kgJqAYAoepMJBcDSScAukSkabwYl()
			{
			}

			private bool rEQWocsBoRcmjmNLzmkvFkFQvFKF(int P_0)
			{
				return false;
			}

			private void ecbTiHnIhxVhPgwtgyAJZSqOLVMC()
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

		private const int nhujktiewWTfgJNNaQDQnWkMWUxp = 8;

		private readonly bool OSPAKwBGcaasuKRXcTuCJUeVAXLDb;

		private bool dZxuzhAONxSMjuFPBkAnrTrOGutq;

		private Queue<miyZWpTlfrgbhFZVVSteyfKElQFk> aqWeUmtECYdudspjGXTtDOEQvmtb;

		private bool cQhLNWpAXerbuNDCvjEvQCWGDGfkA;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void mkNoGLrhcBOSfLMkhquGygDBoZND(uint P_0, bool P_1)
		{
		}

		private void yqveSxebtWOqsfzAFWabBazIgaHTC(uint P_0, bool P_1)
		{
		}

		private void pCLgbWZqCuOSeruyAByqkOrSjOMc()
		{
		}

		private bool efnHwcbKDCWnNazvCwXjafdsdsIEA(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void ZSoHjLYDMGIwhtcEJahsebdSRPUr()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, qLJFBgiKLIprSOWlnupLPXiABOCWA vibration)
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
