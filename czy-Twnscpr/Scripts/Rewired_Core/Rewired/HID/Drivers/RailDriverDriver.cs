using System;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_RailDriver
	{
		private enum bxUCBMexplNNemxmCCnxtUtzIGE
		{
			kgdmRMMBHeNZJmIboUvDHyDJifR = 0,
			ckBULRiRMdwEHoTvqMeotfwVgBQ = 1
		}

		private const int fZxJMGwxnChhoMZBwYzQbEJsMbE = 1523;

		private const int nqwWfgItxcBhlylDfHDcGsEvghSf = 210;

		private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 50;

		private const int PYaeTqcWpxmdKRYNbyXTeYSlhLs = 44;

		private const int XbIImtMjLKGjvJSOHpdzHESLYnN = 6;

		private const int xylkGQwhUjbuXPRTFEofgbqDPBw = 44;

		private const int cNIayRFcxEASnDxyFRRLrxgYKTJ = 45;

		private const int lPkahYMVjSLgUsRWenkyUJakEXW = 46;

		private const int eUymwqlZyWcGhrTtKFAoccrpAjc = 47;

		private const int RNLmDgjpWAelkzXMOrtjrUzApfu = 48;

		private const int uxPANiHgSnEEKbucPPslIKaBtBL = 49;

		private const int lhEplacCAkcgCCEHqduQTzgfsVB = 0;

		private const int imTbtOIDVyprkwbVcDFgXLGjuPe = 15;

		private const int hHwUfsBNCzqvovrQGeowMpGjczb = 9;

		private const int kAupubGzFeTcCynDoQHRgOPqbZxH = 1;

		private const int zChIYovSWclirOzYiqaqwUJRSRk = 2;

		private const int LQPNjIiitxTjMVJnwFtQjDriFtA = 3;

		private const int qBlAimCStdXCnvRuyINEeuIZHrHH = 4;

		private const int HGcwoRyPHOpbFkfUSOoXMJjbGZV = 5;

		private const int ptZrdvfrLqvftFOtSWdjSbLbhwLB = 6;

		private const int YuJtYkQShmZmsuIfYksnQlIWZEq = 7;

		private const int uGMmFAWZxZskfDPMQrjXnKQLAoo = 8;

		private const int yREDEyHJiiyeIqWUeUyESVEVzHF = 14;

		private const int cMhZTLINjKQoyhXbQWvhztpXPAl = 3;

		private const int dUFGxDGrUZmmtjoEWTJGfKxxvYZF = 7;

		private readonly NativeBuffer TNsrdxUzSigJvhkTABqkSBrupPX;

		private readonly NativeBuffer YiDkrZSsLRSeHQoRYfEyOJZtZhA;

		private bool wlMCMsfAsnEQCtHlGNfmjaBEWxAk;

		private byte[] PbFBHWhigUYqgAtmOVTUCKxEZsWE;

		private readonly OutputReport NqIwrAVCcNbKUFTUcaAOSzVPjfgd;

		private readonly Func<OutputReport, bool> zGragaBdAvmiqiZgBpxhyCoTgvTK;

		private readonly Action<OutputReport> QwhNoqAoCzNjUBkTYKdLiZWnfeJ;

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

		private bool fVAxseiaLYEjXhJFRLDnGqAQHCoj(bxUCBMexplNNemxmCCnxtUtzIGE P_0, langamgpCrFDZAyXTaThMJylRDe P_1)
		{
			return false;
		}

		private void SUWXUaJrRCSUjhqatnyyZfhoGbu(bxUCBMexplNNemxmCCnxtUtzIGE P_0)
		{
		}

		private bool jRmbybWcjNPDpGJKuGrMfRcMtae(langamgpCrFDZAyXTaThMJylRDe P_0)
		{
			return false;
		}

		private void YUQoGhMUuTiuoibvVdSmdbngLQcP(NativeBuffer P_0, double P_1)
		{
		}

		private void uEQFxSNLHXgJiBDRGvzRlggnKJF(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
