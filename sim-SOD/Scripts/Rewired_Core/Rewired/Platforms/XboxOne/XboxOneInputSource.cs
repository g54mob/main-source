using System.Collections.Generic;
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

		private struct BsbiicwFwgrdUPXbfpHxDEiOZty
		{
			public uint SAeNXohWJSkcvgYinFVOXEpLZAE;

			public uint dETeyFzvFPXvDvQhxAwXVoRreFI;

			public BsbiicwFwgrdUPXbfpHxDEiOZty(uint unityJoystickId, uint connectedFrame)
			{
				SAeNXohWJSkcvgYinFVOXEpLZAE = 0u;
				dETeyFzvFPXvDvQhxAwXVoRreFI = 0u;
			}
		}

		private class zRaagAEGWlBwRfxTVWYvDneLgIo : Joystick
		{
			private const int nghLKlaBbOhGsidmJgHBsFfgVzeE = 6;

			private const int RrYxBmqUSBCLFEwCTngUveIoIMP = 14;

			private const string YITroaYDJnYYxirKXlqQAFnfwtN = "Xbox One Controller";

			private const int hINxEGpUzRJGLselzdNsaamXNTe = 0;

			private const int IAycRyAIXlrtLtXpXmZLjQsKqCTt = 1;

			private const int nJyoitcGQorMtZtNXhZvasVwnhQ = 2;

			private const int QASKRASaYhBVhOfpMIASjZJsIhC = 3;

			private const int FYMYOCFWtqFMshlRUBTpKYAoSHi = 4;

			private const int qFiesxfTSxlLXQbjmFeWRIxZwHl = 5;

			private const int QALUzJrUcStVWCFdNHtIAFSJembf = 6;

			private const int rqUqIBLaAgigTmjFzbOsGMqfbyqj = 7;

			private const int LHokMdOtVspDRcZnrsnrIbnfELiE = 8;

			private const int ngBZekptlxLnHlbVPWCthDDBvGW = 9;

			private const int YrczEIoNhkEkCSQKFMQUOXPRnBS = 12;

			private const int FueqkdMWFCeLPIEudfPlxrCZQxb = 13;

			private const int xlrEvPErFdjAhMvZzeMuIYcgepvv = 14;

			private const int nFExhbnbuuDkJzQRmTlrrHhrXYm = 15;

			private const int hDmDmxDyJvGjXSOvAfPVRmWfrMM = 0;

			private const int CNTkLNlclTatHcRcKHcxQietIoK = 1;

			private const int XKeaSEanHLkAXkBcpUHusFjlMhNR = 3;

			private const int EuxfvuTHvAdzxboegnXeBROChdFv = 4;

			private const int pYZHhryztflzPOONJwResaBuhTCa = 8;

			private const int OpULteqtqWkxdTfiVGpHKVnfEbYh = 9;

			private readonly IXboxOneInputSource yoSyHRopdxoJZbHbOQnQvYEjUel;

			private int pxjqhAdOObmAtnSrVunaLPNYGGfG;

			private ulong msZBiqhoxaNeXHXGEDkLEEmVWZTf;

			private string[] VAVFMVfyQepHVDGkwoIPbbxShrFA;

			public ulong xboxControllerId => 0uL;

			public zRaagAEGWlBwRfxTVWYvDneLgIo(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(null, null, 0, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void yevEaEOpxaTseresMwWwEaZGFmnj(ulong P_0)
			{
			}

			private void VWwdawJBkHFaUGHVdfxDyXcdWtIh()
			{
			}

			private bool VxdmOUEPTHrbDmDfsUPqNkyKovq(int P_0)
			{
				return false;
			}

			private void gBWVctAReXBKmxHqQZHHdsRKRAt()
			{
			}
		}

		private const int olfPWFrNsUuaHTCjtHxKeZqrxlaN = 8;

		private readonly bool yguPpeqEjThrBNXEFhOahcAYtXtO;

		private bool ZWSfPoTVHFkTLPoVExJMZxMGDWx;

		private Queue<BsbiicwFwgrdUPXbfpHxDEiOZty> kMMTTMbFFZtvhkbODzdzQzYcKMH;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void cPfLyDjruufnwKsiCbOnJmBoSCf(uint P_0, bool P_1)
		{
		}

		private void WkjVREQKzNFHOLOfMjOSMVxcxPK(uint P_0, bool P_1)
		{
		}

		private void pICbcHESqrjqWIwakOEQHRzjXvd()
		{
		}

		private bool UVkwrRoGUZgshptsHGhzbkaMjUcE(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void YabxIgfqBhfopBTAgclceZHExOTK()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, DqUyzldQsPcJtEPkFoCSofUEWrn vibration)
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
