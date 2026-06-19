using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum BAgKWMWygaQrTUTSQToEhfNVxyEe
		{
			Speaker = 0,
			LED = 1
		}

		private const int watnyJgAcUtNavsOGxzIQvrxEiuk = 1523;

		private const int QvrCHDQQFQkEITCdhJwbLlOeNvrt = 210;

		private const int CLYVNRNkQXUKJAlutaDffwDuJannA = 50;

		private const int aGMPXFiNDyxbDcYrKDNyjQkuDEbl = 44;

		private const int bErJLcJXPeDAwYtqwFPFPoOluEaM = 6;

		private const int WnoLLCuRVamyIRllrxghhvibUjPH = 44;

		private const int uAZaGXddDkMMnrqmwhhFOcdQjxOZ = 45;

		private const int VzWiLrZlwiiXxnLCAdkGkxbXAkhn = 46;

		private const int RPUheocTlJJSMQCPFNjKScIMQKaR = 47;

		private const int LEEhVMSqIXIXgbEHQFHkXzyVAxIVA = 48;

		private const int ZujAeWmVSwRZebTiLERoXlvYFoWAA = 49;

		private const int AftzAfWZSyHerFlqkqPnzefWdqpIA = 0;

		private const int ZLTLxHTokJQxVALzxEmrrxWOMsvb = 15;

		private const int wXYGshkSvuEQcSCuCglOECYrxCXSA = 9;

		private const int IRLXaqRIeywDmAdqpJOAxTooqfbR = 1;

		private const int cjugQzflDLByrSPWoLhxUqzikNnG = 2;

		private const int EJrsESvQUxHMIsdcMQBHkvElaLJn = 3;

		private const int eJsFcHcjyWlVWxOHWjLBXIKNiJFt = 4;

		private const int QirplCCsDrygqeOpKoauUPrtjniI = 5;

		private const int fUADUUhJXjdeQxJsWMBFARCuqXczA = 6;

		private const int iDXFDFdXFNpMhiEQBWeKjwOsBzIKA = 7;

		private const int sZbVwIZeFRLumNdFefagRwFWIwuK = 8;

		private const int erbgEjhVapsnjnvBxxIhdemOMmsu = 14;

		private const int mLgEQkgODplSuYTwwPIHvNPrkaWiA = 3;

		private const int qhRuoKFGPKUelYchZdkIRwdlbSzk = 7;

		private readonly NativeBuffer ShVyMngjRGpATSpXBxiMfikSCAbW;

		private readonly NativeBuffer qlIDaIAQiaGOJDLunwpupVHqEVqZ;

		private bool UryHyiouQujhZnFzQyzZkBfJbCBGA;

		private byte[] IjgPpclqXLFHvwSPRyPbUPqVAqGU = new byte[3];

		private readonly IHIDDevice JEvFYZYVCzrOfnyFoaiawXRKmdBu;

		private readonly HIDProperties hLxmNXhKDkqAtCVTfRkNoVjRCTZn;

		private readonly MwEMUNdEdQpngdbXMtjwIdOvEFgfA iCecbAgqiRzIEPRAmlarWSZuoTax;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return UryHyiouQujhZnFzQyzZkBfJbCBGA;
			}
			set
			{
				UryHyiouQujhZnFzQyzZkBfJbCBGA = value;
				EFweRXSmpfpnEAyLeAEvTCRwuwXE(BAgKWMWygaQrTUTSQToEhfNVxyEe.Speaker, pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.vendorId;

		ushort IHIDControllerExtension.productId => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.productId;

		string IHIDControllerExtension.productName => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.productName;

		string IHIDControllerExtension.manufacturer => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.manufacturer;

		ushort IHIDControllerExtension.usagePage => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.usagePage;

		ushort IHIDControllerExtension.usage => hLxmNXhKDkqAtCVTfRkNoVjRCTZn.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				IjgPpclqXLFHvwSPRyPbUPqVAqGU[digitIndex] = digitBitValues;
				EFweRXSmpfpnEAyLeAEvTCRwuwXE(BAgKWMWygaQrTUTSQToEhfNVxyEe.LED, pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			IjgPpclqXLFHvwSPRyPbUPqVAqGU[0] = digit1BitValues;
			IjgPpclqXLFHvwSPRyPbUPqVAqGU[1] = digit2BitValues;
			IjgPpclqXLFHvwSPRyPbUPqVAqGU[2] = digit3BitValues;
			EFweRXSmpfpnEAyLeAEvTCRwuwXE(BAgKWMWygaQrTUTSQToEhfNVxyEe.LED, pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
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
			JEvFYZYVCzrOfnyFoaiawXRKmdBu = P_0.hidDevice;
			hLxmNXhKDkqAtCVTfRkNoVjRCTZn = JEvFYZYVCzrOfnyFoaiawXRKmdBu.properties;
			ShVyMngjRGpATSpXBxiMfikSCAbW = new NativeBuffer(15);
			qlIDaIAQiaGOJDLunwpupVHqEVqZ = new NativeBuffer(9);
			iCecbAgqiRzIEPRAmlarWSZuoTax = new MwEMUNdEdQpngdbXMtjwIdOvEFgfA(qlIDaIAQiaGOJDLunwpupVHqEVqZ.Pointer, qlIDaIAQiaGOJDLunwpupVHqEVqZ.Length, 9);
			buttons = new jIFGialkYdAmDDAGsjKrXJoDparB[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new jIFGialkYdAmDDAGsjKrXJoDparB(0, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new OLAxjmdqJbHeCArvVCNIDgdBciXE[4]
			{
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(0, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(0, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(0, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(0, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
			if (inputReportLength < ShVyMngjRGpATSpXBxiMfikSCAbW.Length)
			{
				return false;
			}
			ShVyMngjRGpATSpXBxiMfikSCAbW.Write(inputReportPtr, inputReportLength, ShVyMngjRGpATSpXBxiMfikSCAbW.Length);
			PrEnZTavMxdpsRPavNHAMwBYNbUS(ShVyMngjRGpATSpXBxiMfikSCAbW, timestamp);
			tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] array = axes;
			CUCRZVClyXQUXgLMblHOTayeMWpe(array, ShVyMngjRGpATSpXBxiMfikSCAbW, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool EFweRXSmpfpnEAyLeAEvTCRwuwXE(BAgKWMWygaQrTUTSQToEhfNVxyEe P_0, pVnphHvTNRURYWZADvNPfpgNNbuB P_1)
		{
			iljagmkNFhGCvKpHlGFWbptEpOXuB(P_0);
			return jKjDoNkjsvDytfFWeLurLgshwyqbc(P_1);
		}

		private void iljagmkNFhGCvKpHlGFWbptEpOXuB(BAgKWMWygaQrTUTSQToEhfNVxyEe P_0)
		{
			switch (P_0)
			{
			case BAgKWMWygaQrTUTSQToEhfNVxyEe.Speaker:
				qlIDaIAQiaGOJDLunwpupVHqEVqZ.Clear();
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[1] = 133;
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[7] = (UryHyiouQujhZnFzQyzZkBfJbCBGA ? ((byte)1) : ((byte)0));
				break;
			case BAgKWMWygaQrTUTSQToEhfNVxyEe.LED:
				qlIDaIAQiaGOJDLunwpupVHqEVqZ.Clear();
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[1] = 134;
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[2] = IjgPpclqXLFHvwSPRyPbUPqVAqGU[0];
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[3] = IjgPpclqXLFHvwSPRyPbUPqVAqGU[1];
				qlIDaIAQiaGOJDLunwpupVHqEVqZ[4] = IjgPpclqXLFHvwSPRyPbUPqVAqGU[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool jKjDoNkjsvDytfFWeLurLgshwyqbc(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			switch (P_0)
			{
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous:
				return JEvFYZYVCzrOfnyFoaiawXRKmdBu.WriteSync(iCecbAgqiRzIEPRAmlarWSZuoTax, 0);
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous:
				JEvFYZYVCzrOfnyFoaiawXRKmdBu.WriteAsync(iCecbAgqiRzIEPRAmlarWSZuoTax, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void PrEnZTavMxdpsRPavNHAMwBYNbUS(NativeBuffer P_0, double P_1)
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
					buttons[num2].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 < 95, P_1);
			buttons[45].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 >= 95 && b2 < 161, P_1);
			buttons[46].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 < 95, P_1);
			buttons[48].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 >= 95 && b2 < 161, P_1);
			buttons[49].fihwdEXCUmtjghmZzTkajeNnBqkZ(b2 >= 161, P_1);
		}

		private void CUCRZVClyXQUXgLMblHOTayeMWpe(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].SnJrVNcoeoNiXCCQLiNahDsWooVr(P_1, P_2);
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
				if (ShVyMngjRGpATSpXBxiMfikSCAbW != null)
				{
					ShVyMngjRGpATSpXBxiMfikSCAbW.Dispose();
				}
				if (qlIDaIAQiaGOJDLunwpupVHqEVqZ != null)
				{
					qlIDaIAQiaGOJDLunwpupVHqEVqZ.Dispose();
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
