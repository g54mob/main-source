using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

		private byte[] WDccciWEMMAbOnmCJjElaopsxJFvA = new byte[3];

		private readonly OutputReport QSlMBqvPWXLKoPeajJppRMZfOavF;

		private readonly Func<OutputReport, bool> myQDjUZwqprLMPhYIhkWexcvAGWR;

		private readonly Action<OutputReport> RTIYeSihwbcKqHTKBbLiGsTLCGSGA;

		public bool SpeakerEnabled
		{
			get
			{
				return rpllhOwCYnEZqTLLNiwHMtXsNWVn;
			}
			set
			{
				rpllhOwCYnEZqTLLNiwHMtXsNWVn = value;
				oRzeIEUwpKiibeptUGAIucAuHzdsA(yGvgyqWHLfzGCiyGJpoUFipZJxFR.Speaker, sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				WDccciWEMMAbOnmCJjElaopsxJFvA[digitIndex] = digitBitValues;
				oRzeIEUwpKiibeptUGAIucAuHzdsA(yGvgyqWHLfzGCiyGJpoUFipZJxFR.LED, sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			WDccciWEMMAbOnmCJjElaopsxJFvA[0] = digit1BitValues;
			WDccciWEMMAbOnmCJjElaopsxJFvA[1] = digit2BitValues;
			WDccciWEMMAbOnmCJjElaopsxJFvA[2] = digit3BitValues;
			oRzeIEUwpKiibeptUGAIucAuHzdsA(yGvgyqWHLfzGCiyGJpoUFipZJxFR.LED, sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous);
		}

		public RailDriverDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			QRRGDLqbiaCGBhafJDtJkPxMcuSN = new NativeBuffer(15);
			ZFeOTfqkMHEFlOYAHOmVynLZegZx = new NativeBuffer(9);
			QSlMBqvPWXLKoPeajJppRMZfOavF = new OutputReport(ZFeOTfqkMHEFlOYAHOmVynLZegZx.Pointer, ZFeOTfqkMHEFlOYAHOmVynLZegZx.Length, 9);
			myQDjUZwqprLMPhYIhkWexcvAGWR = P_0.synchronousWriteOutputReportDelegate;
			RTIYeSihwbcKqHTKBbLiGsTLCGSGA = P_0.asynchronousWriteOutputReportDelegate;
			buttons = new HIDButton[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new HIDButton(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[4]
			{
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 4,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127)
			};
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < QRRGDLqbiaCGBhafJDtJkPxMcuSN.Length)
			{
				return false;
			}
			QRRGDLqbiaCGBhafJDtJkPxMcuSN.Write(inputReportPtr, inputReportLength, QRRGDLqbiaCGBhafJDtJkPxMcuSN.Length);
			NmpnNBiKKVbSAuwNMDZPPwvGzdji(QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			HIDControllerElement[] array = axes;
			jcpPocnebBUnOJmnVNaIDNqLQtUw(array, QRRGDLqbiaCGBhafJDtJkPxMcuSN, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool oRzeIEUwpKiibeptUGAIucAuHzdsA(yGvgyqWHLfzGCiyGJpoUFipZJxFR P_0, sEFlMWgexWIvWAvMGQUwmUTmbxg P_1)
		{
			JYzhIOlRjERfDdfGmAdHjrjKUGnT(P_0);
			return qaREVHHsFJUMDlAslfcvwbycMXnBb(P_1);
		}

		private void JYzhIOlRjERfDdfGmAdHjrjKUGnT(yGvgyqWHLfzGCiyGJpoUFipZJxFR P_0)
		{
			switch (P_0)
			{
			case yGvgyqWHLfzGCiyGJpoUFipZJxFR.Speaker:
				ZFeOTfqkMHEFlOYAHOmVynLZegZx.Clear();
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[1] = 133;
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[7] = (byte)(rpllhOwCYnEZqTLLNiwHMtXsNWVn ? 1 : 0);
				break;
			case yGvgyqWHLfzGCiyGJpoUFipZJxFR.LED:
				ZFeOTfqkMHEFlOYAHOmVynLZegZx.Clear();
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[1] = 134;
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[2] = WDccciWEMMAbOnmCJjElaopsxJFvA[0];
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[3] = WDccciWEMMAbOnmCJjElaopsxJFvA[1];
				ZFeOTfqkMHEFlOYAHOmVynLZegZx[4] = WDccciWEMMAbOnmCJjElaopsxJFvA[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool qaREVHHsFJUMDlAslfcvwbycMXnBb(sEFlMWgexWIvWAvMGQUwmUTmbxg P_0)
		{
			switch (P_0)
			{
			case sEFlMWgexWIvWAvMGQUwmUTmbxg.Synchronous:
				if (myQDjUZwqprLMPhYIhkWexcvAGWR == null)
				{
					return false;
				}
				return myQDjUZwqprLMPhYIhkWexcvAGWR(QSlMBqvPWXLKoPeajJppRMZfOavF);
			case sEFlMWgexWIvWAvMGQUwmUTmbxg.Asynchronous:
				if (RTIYeSihwbcKqHTKBbLiGsTLCGSGA == null)
				{
					return false;
				}
				RTIYeSihwbcKqHTKBbLiGsTLCGSGA(QSlMBqvPWXLKoPeajJppRMZfOavF);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji(NativeBuffer P_0, double P_1)
		{
			for (int i = 0; i < 6; i++)
			{
				byte b = P_0[8 + i];
				int num = i * 8;
				for (int j = 0; j < 8; j++)
				{
					int num2 = num + j;
					if (num2 >= 44)
					{
						break;
					}
					buttons[num2].SetValue((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].SetValue(b2 < 95, P_1);
			buttons[45].SetValue(b2 >= 95 && b2 < 161, P_1);
			buttons[46].SetValue(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].SetValue(b2 < 95, P_1);
			buttons[48].SetValue(b2 >= 95 && b2 < 161, P_1);
			buttons[49].SetValue(b2 >= 161, P_1);
		}

		private void jcpPocnebBUnOJmnVNaIDNqLQtUw(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].UpdateValue(P_1, P_2);
			}
		}

		~RailDriverDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				if (QRRGDLqbiaCGBhafJDtJkPxMcuSN != null)
				{
					QRRGDLqbiaCGBhafJDtJkPxMcuSN.Dispose();
				}
				if (ZFeOTfqkMHEFlOYAHOmVynLZegZx != null)
				{
					ZFeOTfqkMHEFlOYAHOmVynLZegZx.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (1523 == vid)
			{
				return 210 == pid;
			}
			return false;
		}
	}
}
