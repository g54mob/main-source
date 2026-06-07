using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver
	{
		private enum MxRZomVcuyNPgkHzPxoUGqVhbIHq
		{
			Speaker = 0,
			LED = 1
		}

		private const int nwUuXrxugOdaJBZaRiEKvALXopzT = 1523;

		private const int DdIPsnVaFGVfzvYRogFdsGoYhYyFA = 210;

		private const int TcplOnEWxLXAwaFEcgIzZTlCHNwj = 50;

		private const int bqlOtbzyVisosOePFEciFUYKwsaZ = 44;

		private const int yiGdXSOULwNvFyVOncpNyvwJngtH = 6;

		private const int RkJrngnkJshflKtNqBYtJGWNrjGgA = 44;

		private const int pTsgctymNcZFITmYjsKZxLBmBWDx = 45;

		private const int WdtvRNSykoCMEBgoNCDKPNDzHVun = 46;

		private const int IhlcEWzFvHfXjexbOACUAteejhtSA = 47;

		private const int EYdaviFeQHTYJkjhTKqyCyIjaCXP = 48;

		private const int CaYgYedMYwESBBxUQDiqauBcRHTo = 49;

		private const int DjUqYJZKVkrDMvAJbgpdEZiiPuaC = 0;

		private const int AlwzvvIUcReJWuRzwiniYrBiNvxV = 15;

		private const int dftOxVlczwfFLmUSHUQElFkXxxKs = 9;

		private const int LCeWzUQdmmDhZGuYktvWhUGWGYoXA = 1;

		private const int feVPMZyFTZcICiWefdadKfNWpLafA = 2;

		private const int RoAoUmgGQvPJrUyURywNTEiJqZEI = 3;

		private const int biFYxjxGgQUkhNNnNjKZhqutgcUBb = 4;

		private const int VFOrDgFkDrazDaCDDmNmFxNZKAhCA = 5;

		private const int wbtimOERpSbzFvUTyiRCqiYYyxJA = 6;

		private const int zfatbRMJRLTQrwwWQXICLiBKSLXb = 7;

		private const int vHOHtgGaNNxMPdmtzCJgiKfcufxR = 8;

		private const int hUoYVYcohmqSNTduhmlWGMiTtri = 14;

		private const int flJaQjFJAxXeRzIFhbpTinxZZcDE = 3;

		private const int fQgwWsAcRCtVWgzLECDEcmFBGOgx = 7;

		private readonly NativeBuffer LKsucRlARKNGkoNlWOLIWeOwvlsJ;

		private readonly NativeBuffer ltrdImXDikrJcjrKwaSaDUdWJybx;

		private bool VXDUiEnjOugooLRNFNUFXrJtwzUr;

		private byte[] DzTNGYqtHLYHESixQeRvrwOnVRDi = new byte[3];

		private readonly OutputReport nlThJuregRmJrdlgpPvzbAxQGwvU;

		private readonly Func<OutputReport, bool> tIqqDusgxPWkSZkOzoJTCxMxVBuC;

		private readonly Action<OutputReport> EwJuoziujVmLoddzHRhkXzAPRGHf;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return VXDUiEnjOugooLRNFNUFXrJtwzUr;
			}
			set
			{
				VXDUiEnjOugooLRNFNUFXrJtwzUr = value;
				BsUpZOqqtUNIvJxZZJaYhqFroKZ(MxRZomVcuyNPgkHzPxoUGqVhbIHq.Speaker, WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				DzTNGYqtHLYHESixQeRvrwOnVRDi[digitIndex] = digitBitValues;
				BsUpZOqqtUNIvJxZZJaYhqFroKZ(MxRZomVcuyNPgkHzPxoUGqVhbIHq.LED, WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			DzTNGYqtHLYHESixQeRvrwOnVRDi[0] = digit1BitValues;
			DzTNGYqtHLYHESixQeRvrwOnVRDi[1] = digit2BitValues;
			DzTNGYqtHLYHESixQeRvrwOnVRDi[2] = digit3BitValues;
			BsUpZOqqtUNIvJxZZJaYhqFroKZ(MxRZomVcuyNPgkHzPxoUGqVhbIHq.LED, WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous);
		}

		void IDriver_RailDriver.SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}

		public RailDriverDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			LKsucRlARKNGkoNlWOLIWeOwvlsJ = new NativeBuffer(15);
			ltrdImXDikrJcjrKwaSaDUdWJybx = new NativeBuffer(9);
			nlThJuregRmJrdlgpPvzbAxQGwvU = new OutputReport(ltrdImXDikrJcjrKwaSaDUdWJybx.Pointer, ltrdImXDikrJcjrKwaSaDUdWJybx.Length, 9);
			tIqqDusgxPWkSZkOzoJTCxMxVBuC = P_0.synchronousWriteOutputReportDelegate;
			EwJuoziujVmLoddzHRhkXzAPRGHf = P_0.asynchronousWriteOutputReportDelegate;
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
			if (inputReportLength < LKsucRlARKNGkoNlWOLIWeOwvlsJ.Length)
			{
				return false;
			}
			LKsucRlARKNGkoNlWOLIWeOwvlsJ.Write(inputReportPtr, inputReportLength, LKsucRlARKNGkoNlWOLIWeOwvlsJ.Length);
			WWntufhlAdkRPxLQccAMnOhiIfJl(LKsucRlARKNGkoNlWOLIWeOwvlsJ, timestamp);
			HIDControllerElement[] array = axes;
			VOxLjfJwwDLBgSPjmpQCuOSKGrwJA(array, LKsucRlARKNGkoNlWOLIWeOwvlsJ, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool BsUpZOqqtUNIvJxZZJaYhqFroKZ(MxRZomVcuyNPgkHzPxoUGqVhbIHq P_0, WweBMfPLHmZJRWKTQOAYhINlTVzC P_1)
		{
			fGGjIAfQNrrLOXTfowcOKSRThwWL(P_0);
			return hUfWmouVZNkqPMfDzePOQLxNtPFL(P_1);
		}

		private void fGGjIAfQNrrLOXTfowcOKSRThwWL(MxRZomVcuyNPgkHzPxoUGqVhbIHq P_0)
		{
			switch (P_0)
			{
			case MxRZomVcuyNPgkHzPxoUGqVhbIHq.Speaker:
				ltrdImXDikrJcjrKwaSaDUdWJybx.Clear();
				ltrdImXDikrJcjrKwaSaDUdWJybx[1] = 133;
				ltrdImXDikrJcjrKwaSaDUdWJybx[7] = (byte)(VXDUiEnjOugooLRNFNUFXrJtwzUr ? 1 : 0);
				break;
			case MxRZomVcuyNPgkHzPxoUGqVhbIHq.LED:
				ltrdImXDikrJcjrKwaSaDUdWJybx.Clear();
				ltrdImXDikrJcjrKwaSaDUdWJybx[1] = 134;
				ltrdImXDikrJcjrKwaSaDUdWJybx[2] = DzTNGYqtHLYHESixQeRvrwOnVRDi[0];
				ltrdImXDikrJcjrKwaSaDUdWJybx[3] = DzTNGYqtHLYHESixQeRvrwOnVRDi[1];
				ltrdImXDikrJcjrKwaSaDUdWJybx[4] = DzTNGYqtHLYHESixQeRvrwOnVRDi[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool hUfWmouVZNkqPMfDzePOQLxNtPFL(WweBMfPLHmZJRWKTQOAYhINlTVzC P_0)
		{
			switch (P_0)
			{
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Synchronous:
				if (tIqqDusgxPWkSZkOzoJTCxMxVBuC == null)
				{
					return false;
				}
				return tIqqDusgxPWkSZkOzoJTCxMxVBuC(nlThJuregRmJrdlgpPvzbAxQGwvU);
			case WweBMfPLHmZJRWKTQOAYhINlTVzC.Asynchronous:
				if (EwJuoziujVmLoddzHRhkXzAPRGHf == null)
				{
					return false;
				}
				EwJuoziujVmLoddzHRhkXzAPRGHf(nlThJuregRmJrdlgpPvzbAxQGwvU);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void WWntufhlAdkRPxLQccAMnOhiIfJl(NativeBuffer P_0, double P_1)
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

		private void VOxLjfJwwDLBgSPjmpQCuOSKGrwJA(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
				if (LKsucRlARKNGkoNlWOLIWeOwvlsJ != null)
				{
					LKsucRlARKNGkoNlWOLIWeOwvlsJ.Dispose();
				}
				if (ltrdImXDikrJcjrKwaSaDUdWJybx != null)
				{
					ltrdImXDikrJcjrKwaSaDUdWJybx.Dispose();
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
