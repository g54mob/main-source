using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum fqXXcTpEjUFfZcfGyChWhuqyXfsEA
		{
			Speaker = 0,
			LED = 1
		}

		private const int KRIBeCDozyDIcPMTgCZONbwAWQYr = 1523;

		private const int odAHATpQZsPILdwKLAdYQDHPdFoc = 210;

		private const int eAlhCMmMRrmhDcBdLFzpFvUBeyZkA = 50;

		private const int KWbUSnHCmAIFdUetgvgearETNIRd = 44;

		private const int RvGwMvmwOIOjeoShSptJAEXMlCQM = 6;

		private const int ucBABNVCSAHCQxeABDCbqfdMSibf = 44;

		private const int WGkRgQKKQMrvzTOvQXBNVRkxdHoF = 45;

		private const int zJjZMekltKVerVOVosWOnLmyUmXn = 46;

		private const int zgjwlbHxytnlAqPItDZSXqDhRMQR = 47;

		private const int fRtVCJhQNnaTaujMmavsqxdcOfaN = 48;

		private const int nASrRJTNwKoAaXzTfbaaSbsrqmwG = 49;

		private const int aUGiXkjTHILXnzphMbrxoLgzeuJw = 0;

		private const int lFgKQAoaxbfbnwDCFMikwtkbASWy = 15;

		private const int WllyfuZPcQZnegIzakNKHeDQREhU = 9;

		private const int mdwBMtkZdUQZsgKnNMsSmbxRpdRR = 1;

		private const int MVlhidGMpXsryqXQwhrdRgJDeHgb = 2;

		private const int euCDTBAtHXXjGSkbahzZdaHKHLpZ = 3;

		private const int SCHIVCJfxgCqIDEAoCTXApFkbHvt = 4;

		private const int yOMcDffAkPXyGMmmoAuXTcJKvYUb = 5;

		private const int TBlrBJyEWBlTCxgfgtfXSjVTxBOq = 6;

		private const int YskOKYwxKvptlahDjiWIhsPHbdaAA = 7;

		private const int GqMSbDqKQhqcyfaAWhMkIlGhiEQBA = 8;

		private const int SxMrRkmwtLbWvBfSHSydmOzjSoIU = 14;

		private const int YzVnXxvLOTedwfkxKlaRAASCuaqV = 3;

		private const int WxgjVHgHMupwtsAsbFWICMkCxrHU = 7;

		private readonly NativeBuffer uxihDiDLEqSfXuVChIHWyodltYNT;

		private readonly NativeBuffer EXxspFpQzMBvXdctXcNwkgQFjTGyA;

		private bool kdLzrnNaNUzCFRDsqCZZnocqFElgA;

		private byte[] uZXBydKNWfxmjQhKxvrjRHvkEqgGA;

		private readonly IHIDDevice jpIURSdIDVghlZsUYhWcnxWxGblT;

		private readonly HIDProperties BYKbAWDAWCqhbksYPKUNHzcufTzz;

		private readonly kotbTAfQioNEwLHSkuVgCDNCKFGrA MsTaaTZfpbpJKxYZUGtdTOQFBPCI;

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

		private bool sOLrmQpgvDaIMaWnCuonIkADHcfp(fqXXcTpEjUFfZcfGyChWhuqyXfsEA P_0, XhYmzuUQGnhOTiFQlJuRwfesjZJm P_1)
		{
			return false;
		}

		private void ObUtcnBKWDpZjRAOPvsSeJeEMKbJ(fqXXcTpEjUFfZcfGyChWhuqyXfsEA P_0)
		{
		}

		private bool VyWmzGQIvXDUzzcJzDKnvmxFamMiA(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
			return false;
		}

		private void rjtBWWeHZDySsShpPAdSQFErfvmOA(NativeBuffer P_0, double P_1)
		{
		}

		private void eHpGFUtvvnjeBOMFNHdOKJrNGHVI(FWfncLHkdkAtpfBEQVIdHvRpLZvXA[] P_0, NativeBuffer P_1, double P_2)
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
