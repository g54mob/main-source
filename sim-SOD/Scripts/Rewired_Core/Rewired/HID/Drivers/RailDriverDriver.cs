using System;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_RailDriver
	{
		private enum qQxDpzKcVLgEqewkSfGVeJEODYAs
		{
			tKSbCfaytEABXgbhgdKfvYimKjV = 0,
			jvkYgsMmrPvvZgyFoerCLpLyDeOi = 1
		}

		private const int axWwffAaHiXyyGsVoFtmRYdXoOO = 1523;

		private const int kgXJmBkdHUmnrsXDvqQYENnMpeU = 210;

		private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 50;

		private const int IRLadBWqVVcgGeZZvoVbTSpIYxsf = 44;

		private const int SGtCVGkeveAotDjODFOZjppiKzLc = 6;

		private const int gIEVStAwiFmsJXSLFTrPSgFcYVs = 44;

		private const int pizIMatvNkGNlNJsTLmzLGLpZLB = 45;

		private const int cxBeJlcDPsezWaqWobVClqHVHZCF = 46;

		private const int vtpcQTfHfSRhIvrZvSuibCFEPAlc = 47;

		private const int GSslsZJJospQcdsUWASBDiErpAi = 48;

		private const int vUkWgNpPYNDrAhXcXsXTijjafNP = 49;

		private const int erfwFBADmWApOIMVqDFsvvJGtPTD = 0;

		private const int fGqJJtwFhIgykeEZqWqYnupWkLa = 15;

		private const int qQZQuTlOoPzlobrIONTKuxbEemf = 9;

		private const int lsVKkWqubOtTYmhNuiNzQemLaTd = 1;

		private const int uaCYoPJQcEwimEZnmaRQOlvsFYF = 2;

		private const int KiaPCbGfFBBoSJZlcQvoLdOZezI = 3;

		private const int xQQCVVgLVRDHbFeOcclgAnrihOF = 4;

		private const int MWBIYqAnXcmcHgILERZdkOtYLAV = 5;

		private const int eksVWSBChCcrjFTvSAhVeSkEwsV = 6;

		private const int FEaWLLeSmYmGiwfMOABPjyWndTsg = 7;

		private const int lFdfMwiclnQvwENBGxMXnTbcyKkE = 8;

		private const int rgxsXmhWeYnYHQEgcLgugnukZiP = 14;

		private const int xbWnOkuLhcvKcrtOSCWJVYwwEjr = 3;

		private const int kmoXyDZobWjlqtCGsgysdGOBGPJ = 7;

		private readonly NativeBuffer WeTLTQgjeKEBrrORCNRYigMNAHP;

		private readonly NativeBuffer JTaZSyknCdqJDInuGhEEgXuUHFU;

		private bool xZfgZZaKLLHGOHfBMKCSYuDvtWh;

		private byte[] MqidpjAYqkbhqzgLQiLqiMmjieG;

		private readonly OutputReport KgtLjbxBQdTwAJUGebKaTegqdzu;

		private readonly Func<OutputReport, bool> sIYQGHZuBRrgcHkqHWAFymHybWP;

		private readonly Action<OutputReport> LfWnxXsegPrAMJywATffGawQTrN;

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

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
		}

		public RailDriverDriver(InitArgs initArgs)
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

		private bool qdtLBJUBzwUcZtTJTEqDyLvpCUsD(qQxDpzKcVLgEqewkSfGVeJEODYAs P_0, qtYOVDQyuJWkDWXBHmYRaOJGJPk P_1)
		{
			return false;
		}

		private void NJbewBpvbuVRvjcOpTlUdUpPpOq(qQxDpzKcVLgEqewkSfGVeJEODYAs P_0)
		{
		}

		private bool elREEMihZvtWhUjKwNOejGLbJimb(qtYOVDQyuJWkDWXBHmYRaOJGJPk P_0)
		{
			return false;
		}

		private void JzhqFYipGthZqgIzHnMCRHSPSms(NativeBuffer P_0, double P_1)
		{
		}

		private void tPnynrrElxAzqRtVYgUBAHXStQHi(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
