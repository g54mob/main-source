using System;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_RailDriver
	{
		private enum yGvgyqWHLfzGCiyGJpoUFipZJxFR
		{
			Speaker = 0,
			LED = 1
		}

		private const int gJALgsQJLIjoGWrfllXrTkASMzFr = 1523;

		private const int qSZSEQerHqkrHabvsUgJMXONElPm = 210;

		private const int CslwhBCeGKNctEjyAWkxAmQhbouC = 50;

		private const int AVsLYYDBfkRkJfkgvEuAOOJEfhD = 44;

		private const int YrfVaVgrqCmGBDolQyrApQDtSmQe = 6;

		private const int kVMRJaWuidvuvBtvKJxMCckbBgpn = 44;

		private const int jXpbBnGtZEIXHlNGSsGehDqyFkSyA = 45;

		private const int knJgAoqXRWAlafgyjgtFAyihYsXdc = 46;

		private const int nddfTAVJvcapuvUzgBAhKYuBizcL = 47;

		private const int WEeqDYTDgAhqOpoaFsWMHxdsIHrf = 48;

		private const int bHoLfObWQrtTmdJEAuQUeoOjPWUt = 49;

		private const int yedSGASLekijqGVlbdnndxkZqiUV = 0;

		private const int pwyZSeeFfopmAcwhjqAZlKMBhozR = 15;

		private const int mDZWhApzcjkdWdDoTDjNawEDcXgZ = 9;

		private const int pdXTtJebpsnOoklHzGYsAJpSwwgD = 1;

		private const int oLIlxATOeuAqOShBbFdVgQIdmvAyA = 2;

		private const int OtqAnaQNNhqdoPNxbkktXtwOGtNE = 3;

		private const int dFMJzIaRZvXcHFBGbIurEaSbWsEk = 4;

		private const int SjBLblWvzIwlrgicBrqmePpLeBGK = 5;

		private const int wVaIGTXHpqsPVXqLLwvIgeVZHUKJ = 6;

		private const int ZRkqEWupyuHSGqXwPhnOaixsqmnx = 7;

		private const int dPtfBhqMtVcrCXQbHKaGLnKlBnbV = 8;

		private const int lVdpLCjjKcpWkQAgbnwdieEriTMl = 14;

		private const int hpIaSfgtVWrmOxHRTiiQJprlDhmeA = 3;

		private const int gxcAEvXgyZkfJakoLIOzaNfXydUW = 7;

		private readonly NativeBuffer QRRGDLqbiaCGBhafJDtJkPxMcuSN;

		private readonly NativeBuffer ZFeOTfqkMHEFlOYAHOmVynLZegZx;

		private bool rpllhOwCYnEZqTLLNiwHMtXsNWVn;

		private byte[] WDccciWEMMAbOnmCJjElaopsxJFvA;

		private readonly OutputReport QSlMBqvPWXLKoPeajJppRMZfOavF;

		private readonly Func<OutputReport, bool> myQDjUZwqprLMPhYIhkWexcvAGWR;

		private readonly Action<OutputReport> RTIYeSihwbcKqHTKBbLiGsTLCGSGA;

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

		private bool oRzeIEUwpKiibeptUGAIucAuHzdsA(yGvgyqWHLfzGCiyGJpoUFipZJxFR P_0, sEFlMWgexWIvWAvMGQUwmUTmbxg P_1)
		{
			return false;
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT(yGvgyqWHLfzGCiyGJpoUFipZJxFR P_0)
		{
		}

		private bool qaREVHHsFJUMDlAslfcvwbycMXnBb(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			return false;
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji(NativeBuffer P_0, double P_1)
		{
		}

		private void jcpPocnebBUnOJmnVNaIDNqLQtUw(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
