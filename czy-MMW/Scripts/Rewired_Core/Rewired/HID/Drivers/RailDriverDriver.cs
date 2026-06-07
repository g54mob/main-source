using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver
	{
		private enum YQQndoODrQoapmPeruFRqfrqCixkA
		{
			Speaker = 0,
			LED = 1
		}

		private const int zPZDEdwodsCDYZzlnNpBVwbMSNLn = 1523;

		private const int ZzXZznMkKaIEgvmSIzoqWqWJmjIL = 210;

		private const int XIgccnZMTtsmzoNLUFXmxXFPRxIS = 50;

		private const int rMsdepgwMGqNjWRQfaNdEcwTaKWcb = 44;

		private const int mLTwDGZcOSyTUcIHXHIAMOWABrZi = 6;

		private const int HhQFkyDsCMrCocrGQxlwhyqgUZgub = 44;

		private const int hanzjfjgIUYkXFlJDahKNShdgyrDA = 45;

		private const int ExicxVZvfMjWNZtEdksLtdkkbDUf = 46;

		private const int EAcLqMiBejsKikeieHpBDkWxEHPZ = 47;

		private const int WRooZqIVrxrTIwiOtLavyaGaeIzf = 48;

		private const int QgJWTayxDYHrGXeTgBJtCIhpQhxhA = 49;

		private const int HPFAxLOtPSWKJflFPrJiufbjxbUR = 0;

		private const int WehIczNJhjDoPqimQlGxmKlltZVq = 15;

		private const int lYaZRLeqnQiCWahDhxwJVBCYRhkk = 9;

		private const int PglGmSZztMsUCqpFICTJoXwZgWCI = 1;

		private const int xkWGLDEdKzBjHryxXbPiZxtDapKAA = 2;

		private const int HlNbtahSPLjaciELnQNEGlAUaMwqA = 3;

		private const int nBGJeberfqjFwJmyzIhKQwGuJKmX = 4;

		private const int JmDFGwgUQNUYWQICdRahQRjKqsReb = 5;

		private const int oamhNoRTCJYNexxNnNrUAIWJKOZj = 6;

		private const int hmlqOjHqKtivTwSzcifFfDOHgyzs = 7;

		private const int zoBVgqZDIhylYlLoBqkzUrHnPBNw = 8;

		private const int lJBhBRXKlLHpPFnsMAoyswgdzPLH = 14;

		private const int fHUjgAAPAFurKlTFPOpIMKBIhItI = 3;

		private const int nkjhFeDTOiguJamUsCoJKQzEViMNA = 7;

		private readonly NativeBuffer LhhhWPuaKgCoteMeaIhHcUyjWFUp;

		private readonly NativeBuffer dMeTJkGFrMkQjjLFIvAdwBHZjCXT;

		private bool VbYZgYgEVQHxtTmEdtCYlZhaZTkF;

		private byte[] NcQAIShMutdPFGovoZhiJcyojQbC = new byte[3];

		private readonly OutputReport vRWVOmgQffAompRfJwkiRsTRIRXk;

		private readonly Func<OutputReport, bool> lpjdyofMrttNBLRrVTeUirZgbKWi;

		private readonly Action<OutputReport> MCKazvxgndEVvnZkptenpGNKOhfP;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return VbYZgYgEVQHxtTmEdtCYlZhaZTkF;
			}
			set
			{
				VbYZgYgEVQHxtTmEdtCYlZhaZTkF = value;
				TyFauOxYnaJeNFhehjcxIBECHGgCb(YQQndoODrQoapmPeruFRqfrqCixkA.Speaker, IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				NcQAIShMutdPFGovoZhiJcyojQbC[digitIndex] = digitBitValues;
				TyFauOxYnaJeNFhehjcxIBECHGgCb(YQQndoODrQoapmPeruFRqfrqCixkA.LED, IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			NcQAIShMutdPFGovoZhiJcyojQbC[0] = digit1BitValues;
			NcQAIShMutdPFGovoZhiJcyojQbC[1] = digit2BitValues;
			NcQAIShMutdPFGovoZhiJcyojQbC[2] = digit3BitValues;
			TyFauOxYnaJeNFhehjcxIBECHGgCb(YQQndoODrQoapmPeruFRqfrqCixkA.LED, IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous);
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
			LhhhWPuaKgCoteMeaIhHcUyjWFUp = new NativeBuffer(15);
			dMeTJkGFrMkQjjLFIvAdwBHZjCXT = new NativeBuffer(9);
			vRWVOmgQffAompRfJwkiRsTRIRXk = new OutputReport(dMeTJkGFrMkQjjLFIvAdwBHZjCXT.Pointer, dMeTJkGFrMkQjjLFIvAdwBHZjCXT.Length, 9);
			lpjdyofMrttNBLRrVTeUirZgbKWi = P_0.synchronousWriteOutputReportDelegate;
			MCKazvxgndEVvnZkptenpGNKOhfP = P_0.asynchronousWriteOutputReportDelegate;
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
			if (inputReportLength < LhhhWPuaKgCoteMeaIhHcUyjWFUp.Length)
			{
				return false;
			}
			LhhhWPuaKgCoteMeaIhHcUyjWFUp.Write(inputReportPtr, inputReportLength, LhhhWPuaKgCoteMeaIhHcUyjWFUp.Length);
			KakowtcNBDZVWzHTIDqNTDhzgZve(LhhhWPuaKgCoteMeaIhHcUyjWFUp, timestamp);
			HIDControllerElement[] array = axes;
			JvkbavjOprJmpIOqYAzDJOiHJNYpA(array, LhhhWPuaKgCoteMeaIhHcUyjWFUp, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool TyFauOxYnaJeNFhehjcxIBECHGgCb(YQQndoODrQoapmPeruFRqfrqCixkA P_0, IthEmOYLIWoAKOtZgfENDyquvbZK P_1)
		{
			rdXYJGqVKXfsFLvgQXvBsdzSHZkS(P_0);
			return vXkGbynZCvNwOMXMZkpJmqVGTLlm(P_1);
		}

		private void rdXYJGqVKXfsFLvgQXvBsdzSHZkS(YQQndoODrQoapmPeruFRqfrqCixkA P_0)
		{
			switch (P_0)
			{
			case YQQndoODrQoapmPeruFRqfrqCixkA.Speaker:
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT.Clear();
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[1] = 133;
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[7] = (byte)(VbYZgYgEVQHxtTmEdtCYlZhaZTkF ? 1 : 0);
				break;
			case YQQndoODrQoapmPeruFRqfrqCixkA.LED:
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT.Clear();
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[1] = 134;
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[2] = NcQAIShMutdPFGovoZhiJcyojQbC[0];
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[3] = NcQAIShMutdPFGovoZhiJcyojQbC[1];
				dMeTJkGFrMkQjjLFIvAdwBHZjCXT[4] = NcQAIShMutdPFGovoZhiJcyojQbC[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool vXkGbynZCvNwOMXMZkpJmqVGTLlm(IthEmOYLIWoAKOtZgfENDyquvbZK P_0)
		{
			switch (P_0)
			{
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Synchronous:
				if (lpjdyofMrttNBLRrVTeUirZgbKWi == null)
				{
					return false;
				}
				return lpjdyofMrttNBLRrVTeUirZgbKWi(vRWVOmgQffAompRfJwkiRsTRIRXk);
			case IthEmOYLIWoAKOtZgfENDyquvbZK.Asynchronous:
				if (MCKazvxgndEVvnZkptenpGNKOhfP == null)
				{
					return false;
				}
				MCKazvxgndEVvnZkptenpGNKOhfP(vRWVOmgQffAompRfJwkiRsTRIRXk);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void KakowtcNBDZVWzHTIDqNTDhzgZve(NativeBuffer P_0, double P_1)
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

		private void JvkbavjOprJmpIOqYAzDJOiHJNYpA(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
				if (LhhhWPuaKgCoteMeaIhHcUyjWFUp != null)
				{
					LhhhWPuaKgCoteMeaIhHcUyjWFUp.Dispose();
				}
				if (dMeTJkGFrMkQjjLFIvAdwBHZjCXT != null)
				{
					dMeTJkGFrMkQjjLFIvAdwBHZjCXT.Dispose();
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
