using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum yXfVtKGdUdsoyeOJeIjnFuoNbLdeb
		{
			Speaker = 0,
			LED = 1
		}

		private const int NXudYJbwGBRZHaXAcKFbKZkvccJQA = 1523;

		private const int dBiMpPEZfTIwjlFdREIMILZknXAQ = 210;

		private const int nLoETJcTEudqqcsZpAQfeCqBUIX = 50;

		private const int NQZkwDszvpNPaIwnuLbJmLjqejIIA = 44;

		private const int KjicWaRLflcBNulaQxuiWgDpuWDI = 6;

		private const int pkdFiImJvjWGdxGnFZFKyChxzcuR = 44;

		private const int ROGmzBzBzbfcEfTsQfDgcHqEGLhrb = 45;

		private const int oXRqVnRlMvtMCJFKiUihtzyTGVYf = 46;

		private const int yGLVXewAPEuTfoiRvRPbZGHCkcRs = 47;

		private const int asNmeQSscCryVaaPklAZkJdHHLrk = 48;

		private const int wVsQDIozmpBtTNDolmhDMNiGhAjX = 49;

		private const int xIsnChYuVrSbGtyTAjIWwkLGGDKd = 0;

		private const int mLABwFbDUCKcAXsPZMoXkxeMecJaA = 15;

		private const int HYPJDbyfNtbeDefcidTtCRTjqmgab = 9;

		private const int bYQGakKTIhyEVTucXzyhdwdcuJWQA = 1;

		private const int PdxeJffjtEcjIaaMMyfAfZesZCEdA = 2;

		private const int pmojEbhmxqqjyWgAatoDhJirrdyC = 3;

		private const int XonByXdeWXgFxHVNegZoHOXRHjgqb = 4;

		private const int jfaFYKYWloTAFYYtyJSVPpknjTVy = 5;

		private const int IUPvkIRercGKbbBskjBkIIBigxLV = 6;

		private const int BMQeLPBijGofGwVSbEPbtqVyHLjl = 7;

		private const int BpaswIDZbSWnVjpXUGEXMfWOAgBgA = 8;

		private const int BzopXzNWeiHLEVLSJgkSkzEUWXTC = 14;

		private const int TnhlRyQlFaeAVjfkQqdiILMvEBpI = 3;

		private const int BsIGZKCFnLioYbipAbWhOSgcpJKhc = 7;

		private readonly NativeBuffer lqQjgrehqPiyWqRbbJjrmxUAmNId;

		private readonly NativeBuffer BmXLNMASCdqMwdmkLBqJqfAmKrTT;

		private bool jxpZyeeWyhLUgPalaLmelDsDuwkK;

		private byte[] nfzMHuhfhOAjGEkJlrtSTwfFNWxm;

		private readonly IHIDDevice yHwrIBEOkmcvEPMNYOvXxNKYHziF;

		private readonly HIDProperties QmwoQVtBjnHuOgXTHLUcpPoZXdsw;

		private readonly ndPzSZhFNVeBDFDFsrPPRfBbUpJt VMvREOiDIYvijvvAGiGORwEaadRM;

		public bool SpeakerEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
		}

		public RailDriverDriver(InitArgs P_0)
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		private bool hkxcNXMwOaYZzorgATgKMoYwaUmU(yXfVtKGdUdsoyeOJeIjnFuoNbLdeb P_0, GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_1)
		{
			return false;
		}

		private void PMklFycNdyqkGHdJNZfdaBenHqsJA(yXfVtKGdUdsoyeOJeIjnFuoNbLdeb P_0)
		{
		}

		private bool QDkTLFzUUcGpGtAKfSWArxqsWXDe(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private void wyDiLFwXwkPMHhvkFtOfZzOKXspG(NativeBuffer P_0, double P_1)
		{
		}

		private void lTZgmDMWSOTaoMGDHVPdIbdklcOQ(GLNYbQuaOXeaSToXMWjUhtXAplaf[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		~RailDriverDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}
	}
}
