using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum caLerWhbmXgXydaMdiJHyblEpNVn
		{
			Speaker = 0,
			LED = 1
		}

		private const int JZUNdJDVyhTZLSVknbVUFdiakKhE = 1523;

		private const int lMGqvRxLrjOVbwsYUmHyGCjxVFyc = 210;

		private const int hStrjJuqMgseojdjYePudjZtbWoNA = 50;

		private const int LenvrPLXbBHbaPHylHwpmJghnowI = 44;

		private const int GpMAjmicLFicVrbvDzBGiGAiXwtpA = 6;

		private const int jKJpPOTeNRQbbsEuUCvceFikwgYy = 44;

		private const int HakmMRQNzFyBQGnuNtYWPliTVBBe = 45;

		private const int sTzZhbsOuXcbSFANvMoRArdCGUyLB = 46;

		private const int srlFKsiTnqoirljWmnrFBDMDBqdqc = 47;

		private const int wZbgzEnHEmCrTaxYfgTtLymWxZDq = 48;

		private const int wENIIpBCNTdXeCnoaZjSYzFJEZbA = 49;

		private const int rlALqnpZIPSYIwQbXEFaelbTxWgT = 0;

		private const int yLsvBDsIaodcMfbOSlMreOxRbwnDA = 15;

		private const int VszAWlGBbPGgXQrnjwdBiFWmhsOTA = 9;

		private const int ltczEaaMcROFJnynUGlNmgyxTcqG = 1;

		private const int TrRUitUhBejmKlXJXPOkBxdlSDqK = 2;

		private const int nBAsqYYHIGfenHwtveRIabYcldErA = 3;

		private const int FJBvzDNMavNbzAgYhpICOEQCrVEk = 4;

		private const int vpKPqObEZKMhXNGinaerJGlwHRnK = 5;

		private const int OufEyOymVIEQdeDlvRRQQOMbctnP = 6;

		private const int XicEnDiwNwwuKrkZwGuPglQvuVZNA = 7;

		private const int TUCbUayRgpzHikWNDixIoJDDodo = 8;

		private const int DPEhohwcmUtVEOCMQwWiccgBtCjX = 14;

		private const int VHLFcwreRQleBkJvZJQQUYXwRSDu = 3;

		private const int RfeOAGkpLhkSYflgwuvDAszyLmsI = 7;

		private readonly NativeBuffer dfumifNRDhLgwxuGsJlTsOmPSkgw;

		private readonly NativeBuffer RfvGSYnRqJfuqHirEOzbKuFzVjzOA;

		private bool zuHaUagFYNKVcDAeHthCGjtzGmKtb;

		private byte[] btRxDoSkDshpWHCQkuFmLkkYGAZv;

		private readonly IHIDDevice mJQEqLanUUHgAaUCDEslclRHFLQtb;

		private readonly HIDProperties QfWyjDQoZDKgAnrCIcwOatxARhGCA;

		private readonly bvbVwPMivxlHVYJUjAzbVqMqOlbN XPJVQPkkwbctuaHLwqgRmDxWxzs;

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
			: base(default(InitArgs))
		{
		}

		protected override void OnInitialize()
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

		private bool vHRKvXpNsYPrxlptJSIsMyVjKCWL(caLerWhbmXgXydaMdiJHyblEpNVn P_0, ApGJLxYzFsobivPGgnsYkhrKhjyh P_1)
		{
			return false;
		}

		private void FiCQbmDLaQwmKGAbGRoJczjsmyQC(caLerWhbmXgXydaMdiJHyblEpNVn P_0)
		{
		}

		private bool WrIJEDYmqWDYIkSJyTggtRkpIvbk(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private void uZpUtJVsMAlVNsxzErLRHLVDuFXn(NativeBuffer P_0, double P_1)
		{
		}

		private void tAvnBPthceiSgRQGSbTJUwgluKqK(MdziBGNqephqKFAONQgipbAHplCzA[] P_0, NativeBuffer P_1, double P_2)
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
