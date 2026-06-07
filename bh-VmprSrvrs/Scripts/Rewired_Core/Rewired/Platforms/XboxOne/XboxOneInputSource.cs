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

		private struct fvNgGHpyiDhAbEpRkgyfgLMlGzEmA
		{
			public uint JYjDiIDPSAriyOWmnhbXMWmhkYpeA;

			public uint JRVmtEitkwWefUzvwJMMdcAkLNGA;

			public fvNgGHpyiDhAbEpRkgyfgLMlGzEmA(uint P_0, uint P_1)
			{
				JYjDiIDPSAriyOWmnhbXMWmhkYpeA = 0u;
				JRVmtEitkwWefUzvwJMMdcAkLNGA = 0u;
			}
		}

		private class RTYGUvRxWQBWoyhrIdPtNPSoAJGL : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int oSxxZBIpeJanFbTJyKCCxlrtqLoN = 6;

			private const int uXAENyipSuHCSEEwYyzGStlfpqZFb = 14;

			private const string MXvkFOYfsAyzHNZhcMsyWjLsXRWr = "Xbox One Controller";

			private const string joQBsDAfcgZmCbryOWrhzzyjGWih = "Controller";

			private const int kAEIRpTnTfjwRUYDcmGHMFfaSVph = 0;

			private const int VqUfHbqxMYeyDxtGuImwhNRtJZfc = 1;

			private const int sttnxWqTeHGqOJvPWAlFYZHVNXFT = 2;

			private const int cnUQnQXJrOIlQLTaOlMHzsRFJZsB = 3;

			private const int wjPvXBOBldcArODEnCPGRYarCGlF = 4;

			private const int wSFhyrzDQmbruOESEdRfdSAmDdWfb = 5;

			private const int lfygzQBQvLmdFrGISoUGWTELMoRY = 6;

			private const int xQuRLcTOcIHROfpwUTEenKWZwPEjA = 7;

			private const int phEkhQFwYFBuFefvGjfflrewJSGv = 8;

			private const int VUuEiYmWmHayZxcxQZWJwYlYuSaF = 9;

			private const int UKpfFFxfKRMterSXcLdvZoYdGFxO = 12;

			private const int hVwssEipSwOyfuXcEDAtzQLAFnlw = 13;

			private const int SgdaSfYGkQBTrgAFasjzWooNYQNlA = 14;

			private const int ZaYfAJcvYgfciYNfDRpSaBradYxuA = 15;

			private const int VBjiXOKmMaLAuwjfPNlAQKPcLrMd = 0;

			private const int UeEsKfXscdgOkzLaNRoTANpyCyUX = 1;

			private const int YiAEMWwAejakEvQJzBeHcBOVTJvKA = 3;

			private const int wyCGrZxgFqajeTeoONPHADmdxJey = 4;

			private const int kfrVQlBmCLSqyhqVFdWbiEzCorHO = 8;

			private const int kxNyhzDizVcSVfmdmOQIarbpMfbT = 9;

			private readonly IXboxOneInputSource KLILGdWQFEHLVzoaxOZVzSASqegG;

			private int llvbCtVAHweEGZpegkiOUzMIiwzC;

			private ulong IPcZrbJUeMkbzJxihjLGRgFrtuhv;

			private string[] rOsPIvQehzPbJMioWtpJKYwmvUI;

			private HardwareJoystickMap_InputManager sylJzNUECOMXspbkNnlyOIYLyvsM;

			private readonly LocalizedString XKIqeoPKkOtGCwASYxOEAEOHqIWm;

			public ulong GREAaVsRmByCzmZSUHcQnWjtmMSQ => 0uL;

			public RTYGUvRxWQBWoyhrIdPtNPSoAJGL(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(null, 0L, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void qHDjRmwzwqBSMQZJQnjoeSYscyKi(ulong P_0)
			{
			}

			private void xwiDhykZpLHoTrAGnsuxPQoVkbNo()
			{
			}

			private bool gyhcTQKWCveGjavFQMMwDgihrzNbB(int P_0)
			{
				return false;
			}

			private void vlYvCEVmHRxSPdigZjEOsFIjFNPcA()
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

		private const int irJhsXAuvmHxgApBPbJTAMkjQMof = 8;

		private readonly bool HJcrFSbSlEPYcYIPVWSRriegDTEt;

		private bool mmSIfVwxMJJknjmHmAuiWptbAoiQ;

		private Queue<fvNgGHpyiDhAbEpRkgyfgLMlGzEmA> hJvYhiNlJwfNkbnjdhrAomSvbltJA;

		private bool zaAjMajXQMRDkhWUQJiyEvChmWwHA;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void beaafnJumldklCCMUwOVWDyywyGnA(uint P_0, bool P_1)
		{
		}

		private void rxAVRNRoVsKfsmEIfSTgRrZNcMId(uint P_0, bool P_1)
		{
		}

		private void wLoWxZjXdCGaQgrsbqtvDHEvQfTT()
		{
		}

		private bool xLUdsMyJYkPCDyFblrxyVnvZerFH(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void OgDnKxyXZeMojmnMeKBpDQpbQPPU()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, vRiOjWoGMaJiCNohERMEeCehFWPV vibration)
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
