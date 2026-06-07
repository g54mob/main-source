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

		private readonly NativeBuffer ShVyMngjRGpATSpXBxiMfikSCAbW;

		private readonly NativeBuffer qlIDaIAQiaGOJDLunwpupVHqEVqZ;

		private bool UryHyiouQujhZnFzQyzZkBfJbCBGA;

		private byte[] IjgPpclqXLFHvwSPRyPbUPqVAqGU;

		private readonly IHIDDevice JEvFYZYVCzrOfnyFoaiawXRKmdBu;

		private readonly HIDProperties hLxmNXhKDkqAtCVTfRkNoVjRCTZn;

		private readonly MwEMUNdEdQpngdbXMtjwIdOvEFgfA iCecbAgqiRzIEPRAmlarWSZuoTax;

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

		private bool EFweRXSmpfpnEAyLeAEvTCRwuwXE(BAgKWMWygaQrTUTSQToEhfNVxyEe P_0, pVnphHvTNRURYWZADvNPfpgNNbuB P_1)
		{
			return false;
		}

		private void iljagmkNFhGCvKpHlGFWbptEpOXuB(BAgKWMWygaQrTUTSQToEhfNVxyEe P_0)
		{
		}

		private bool jKjDoNkjsvDytfFWeLurLgshwyqbc(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private void PrEnZTavMxdpsRPavNHAMwBYNbUS(NativeBuffer P_0, double P_1)
		{
		}

		private void CUCRZVClyXQUXgLMblHOTayeMWpe(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
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
