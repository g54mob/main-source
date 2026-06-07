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

		private struct blVfVCFedeHjGCyUyJuqYDsNfAiY
		{
			public uint BHzLXfnTHnPVVObFxvMFXQPJnXOb;

			public uint BRDFTaiIcXkpPUEiboTPVoKydmrqA;

			public blVfVCFedeHjGCyUyJuqYDsNfAiY(uint P_0, uint P_1)
			{
				BHzLXfnTHnPVVObFxvMFXQPJnXOb = 0u;
				BRDFTaiIcXkpPUEiboTPVoKydmrqA = 0u;
			}
		}

		private class TmUHherJBzemDuWyCZnaCSqAxVmL : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int qnlyQQafOwMdofOCyYLLqTgJslIE = 6;

			private const int oiYyhBFJlZvfgKdtWhVRyVPJJbiB = 14;

			private const string WizoiJwarfaKkXUwkTidXJlEikahA = "Xbox One Controller";

			private const string xRCFNUoozXIHxzFnIvIkyEIRsxKq = "Controller";

			private const int ufSBtiKrwUOOujORgFkMgLVhWrTKb = 0;

			private const int LPEESKhKotSHNItgkBOpyetRgspxA = 1;

			private const int qMhOxFGNjaZZxBRKEpPAHAxrDgbv = 2;

			private const int gtMcvuDvIrphYvDYCnfZisIlfotfb = 3;

			private const int mWZwAKcmKWfHEKgAhASHJQkVNpBHb = 4;

			private const int inVAFgDEBZpSBUPJMoFqTUySdMgR = 5;

			private const int zAsKDwkyGaAyiMDvUCNJCoEvXvub = 6;

			private const int jpyyxxnEtbySdtYbEKQtVxunymyH = 7;

			private const int vYIQGPhaByFBeeLuKhhsgMUQapuy = 8;

			private const int PlmbDZEibuBXsztqGjPEpuRmuTOW = 9;

			private const int OvzbyCFjBkbQZvhKmihkWwuXUePs = 12;

			private const int zkkZqZOiHNNKGkRnOKUuqjpyQfDI = 13;

			private const int QZfgnqmxdfNgWEyWylpgxIUfDjbZ = 14;

			private const int HFSvQxRVSZRHlZeJHpFjSZoQzVdc = 15;

			private const int PedzBVgLjNpoDkeuXUDDBEmEtmgu = 0;

			private const int KBSzlcvwlIheNfglXimGVlBUAVcAA = 1;

			private const int GXGInLOldGVWnpZWpuqIOtyzguHI = 3;

			private const int mHWjfAVoAFmUFZkrKDJYBuOBAyWv = 4;

			private const int yAhtvajCJsZcZdWEXAdohBZeEGjN = 8;

			private const int yINCViduzcxdcbaneAgLbAFVOONl = 9;

			private readonly IXboxOneInputSource UuEaaautBtzuqjNrneIEmLgqCBGy;

			private int zUtDMNJtVPjTvCNigogVSNPlsPFac;

			private ulong AQwSoovrBxEAIZJrbNpNUdRZJZLE;

			private string[] tcOHTLdRpWyGMCBzyxGmlMkYSTcPA;

			private HardwareJoystickMap_InputManager qHxKEOgDDlgQVfvnFbQfBDqpeKYM;

			private readonly LocalizedString JvENDvplbtrbpyYTYAfTPBcfBpun;

			public ulong YoOLGGAnDslQEuPjOsITmfXBrCwl => 0uL;

			public TmUHherJBzemDuWyCZnaCSqAxVmL(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(null, 0L, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void syLwLxSXtXystKIIMdtddLyGRaqf(ulong P_0)
			{
			}

			private void nJycAjGlcgJXsnhJxCwaGqOpAWdo()
			{
			}

			private bool citgcRcXMMlCVfWHIWcbbGTZIOld(int P_0)
			{
				return false;
			}

			private void lUUrfBvKQyCgqjctFSNBvKaVejvh()
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

		private const int wORoKGccwVTcBQTWTPtWXRQVtvGP = 8;

		private readonly bool ZwwyfFVnilnyJIeYBUTYgiEAcwkj;

		private bool sTUKLEGYNuVMKjEAiKwjDMTNKVCQ;

		private Queue<blVfVCFedeHjGCyUyJuqYDsNfAiY> zwtKLjbEOBemVtukjxBPbcmJYbHm;

		private bool hUBjhzWTrTwRKcJWhwjecmXnfAWA;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void fckEtkzvKABGCAPtMIKCKGUQDIwD(uint P_0, bool P_1)
		{
		}

		private void pIYzuQjgfJVvJoUDfwOtOzRvUZmR(uint P_0, bool P_1)
		{
		}

		private void iueCaEXoxjJhfmfpjlxqAHgTYVxi()
		{
		}

		private bool juYSYXEqLPwtusGytBzvSpFxCVns(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void UZRrWyItOPJMQuJDyReuYIFRgZdf()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, poqVdBSaRLeupdLkAXXVBdSVpptwA vibration)
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
