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
		private enum alZEGWZaoJBHnRJSsrJCrOhNfiZ
		{
			dcqEWYAvSMDBAJNTKStsCFVIbSOE = 0,
			dsIHVRHCAVjsIFepCLQVhSgtcPP = 1
		}

		private const int kmwBCSRluuydtxNtKiIvnmISedV = 1523;

		private const int ivlJuovDoYuzcVRlLnPRmaEHsAV = 210;

		private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 50;

		private const int MvbyEgFViFQfZibfDwyowAEPgQf = 44;

		private const int AWXtdntlEumxekCqldpMZVCpgOEj = 6;

		private const int qTkxnYLCZDnUWmBlpJQYihcjkcx = 44;

		private const int tRJzRBwcUgAzosWSxZNchsxuoWv = 45;

		private const int gIpiuCjcXgcgXFqVYqAHKuLIqcR = 46;

		private const int drFzggSBGCkaNEndZgJlgaoBHpia = 47;

		private const int EKQGUodIRanizGKocyrKYznJwGnm = 48;

		private const int roIBVwyylZMtTIDYpBZAAIWfhSE = 49;

		private const int aNTqlgLaFEFuTfBlGCwxXSuVWyI = 0;

		private const int lVYwnQxIYEdSlZrtSDEZNJWJgVv = 15;

		private const int cQlFinwXPLepIKatikRbSIuZFcA = 9;

		private const int dSrgbdGjCIWcZFTjUgLsacZMEskU = 1;

		private const int ckocTkCjNMGdpFxVENoFgVAbzrO = 2;

		private const int KYQfeMNUoTAxBDaBGYzxnxdCAWJ = 3;

		private const int vKegpixRyVhYueqSESFhkkYlACWJ = 4;

		private const int WKjKjVXMAohfGcZsaayqEIfFtgIe = 5;

		private const int uZGBkzIVMWBzcewLwQpCdQTXwZYo = 6;

		private const int RgOiIgjIXANSlBecqgVCQZvwqPn = 7;

		private const int xyPrDBhYKzyAhsxbctKItIXzlGb = 8;

		private const int pwLsRmiZrEtyJnisEHsjUUUvRsW = 14;

		private const int jfyhUBbsmcYqbMXHclzWlcfbLnm = 3;

		private const int kYEMoBMyBxWqeJNoenJdGSrBsnI = 7;

		private readonly NativeBuffer AefEkpbfHElTyBMlaqmDNCteGkjO;

		private readonly NativeBuffer TPSpSLhbrlBSIvSWkEtRGjZVKkR;

		private bool laLtJifPzXaIBHuHujdZYiVkrILP;

		private byte[] CkEHECRSlsjmfbYSsJXpFEluhNVr = new byte[3];

		private readonly OutputReport IvPKgKkDdjiQRIeyQBKtobHpCOfP;

		private readonly Func<OutputReport, bool> caiqrwIKNFaqbsKYlJrOKtgxQKM;

		private readonly Action<OutputReport> sXCsxnNDNTRewUgWMsCsNbDKWD;

		public bool SpeakerEnabled
		{
			get
			{
				return laLtJifPzXaIBHuHujdZYiVkrILP;
			}
			set
			{
				laLtJifPzXaIBHuHujdZYiVkrILP = value;
				kaNyqmHaSydJUQEzzPxMKRWwlat(alZEGWZaoJBHnRJSsrJCrOhNfiZ.dcqEWYAvSMDBAJNTKStsCFVIbSOE, wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				CkEHECRSlsjmfbYSsJXpFEluhNVr[digitIndex] = digitBitValues;
				kaNyqmHaSydJUQEzzPxMKRWwlat(alZEGWZaoJBHnRJSsrJCrOhNfiZ.dsIHVRHCAVjsIFepCLQVhSgtcPP, wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			CkEHECRSlsjmfbYSsJXpFEluhNVr[0] = digit1BitValues;
			CkEHECRSlsjmfbYSsJXpFEluhNVr[1] = digit2BitValues;
			CkEHECRSlsjmfbYSsJXpFEluhNVr[2] = digit3BitValues;
			kaNyqmHaSydJUQEzzPxMKRWwlat(alZEGWZaoJBHnRJSsrJCrOhNfiZ.dsIHVRHCAVjsIFepCLQVhSgtcPP, wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv);
		}

		public RailDriverDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			AefEkpbfHElTyBMlaqmDNCteGkjO = new NativeBuffer(15);
			TPSpSLhbrlBSIvSWkEtRGjZVKkR = new NativeBuffer(9);
			IvPKgKkDdjiQRIeyQBKtobHpCOfP = new OutputReport(TPSpSLhbrlBSIvSWkEtRGjZVKkR.Pointer, TPSpSLhbrlBSIvSWkEtRGjZVKkR.Length, 9);
			caiqrwIKNFaqbsKYlJrOKtgxQKM = initArgs.synchronousWriteOutputReportDelegate;
			sXCsxnNDNTRewUgWMsCsNbDKWD = initArgs.asynchronousWriteOutputReportDelegate;
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127)
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
			if (inputReportLength < AefEkpbfHElTyBMlaqmDNCteGkjO.Length)
			{
				return false;
			}
			AefEkpbfHElTyBMlaqmDNCteGkjO.Write(inputReportPtr, inputReportLength, AefEkpbfHElTyBMlaqmDNCteGkjO.Length);
			DmLZJnvnrnNkrBYTnoYZbojIVhn(AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			hwHaYIiTEvRaleSlaFhMhqeHzxK(axes, AefEkpbfHElTyBMlaqmDNCteGkjO, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool kaNyqmHaSydJUQEzzPxMKRWwlat(alZEGWZaoJBHnRJSsrJCrOhNfiZ P_0, wruyziXHZVSFMldlrVBWMmkPnqz P_1)
		{
			FyXDTkkoQgBIkIOMPrsPJPpQWUph(P_0);
			return aVzxnnjmGlRYclaUUzLjDmhmPEn(P_1);
		}

		private void FyXDTkkoQgBIkIOMPrsPJPpQWUph(alZEGWZaoJBHnRJSsrJCrOhNfiZ P_0)
		{
			switch (P_0)
			{
			case alZEGWZaoJBHnRJSsrJCrOhNfiZ.dcqEWYAvSMDBAJNTKStsCFVIbSOE:
				TPSpSLhbrlBSIvSWkEtRGjZVKkR.Clear();
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[1] = 133;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[7] = (byte)(laLtJifPzXaIBHuHujdZYiVkrILP ? 1 : 0);
				break;
			case alZEGWZaoJBHnRJSsrJCrOhNfiZ.dsIHVRHCAVjsIFepCLQVhSgtcPP:
				TPSpSLhbrlBSIvSWkEtRGjZVKkR.Clear();
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[1] = 134;
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[2] = CkEHECRSlsjmfbYSsJXpFEluhNVr[0];
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[3] = CkEHECRSlsjmfbYSsJXpFEluhNVr[1];
				TPSpSLhbrlBSIvSWkEtRGjZVKkR[4] = CkEHECRSlsjmfbYSsJXpFEluhNVr[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool aVzxnnjmGlRYclaUUzLjDmhmPEn(wruyziXHZVSFMldlrVBWMmkPnqz P_0)
		{
			switch (P_0)
			{
			case wruyziXHZVSFMldlrVBWMmkPnqz.PMWgOuJtLQMJprSBqurejINtaRpv:
				if (caiqrwIKNFaqbsKYlJrOKtgxQKM == null)
				{
					return false;
				}
				return caiqrwIKNFaqbsKYlJrOKtgxQKM(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
			case wruyziXHZVSFMldlrVBWMmkPnqz.hXynUPOhxYJwCUolLiXrgDrOcWu:
				if (sXCsxnNDNTRewUgWMsCsNbDKWD == null)
				{
					return false;
				}
				sXCsxnNDNTRewUgWMsCsNbDKWD(IvPKgKkDdjiQRIeyQBKtobHpCOfP);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void DmLZJnvnrnNkrBYTnoYZbojIVhn(NativeBuffer P_0, double P_1)
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

		private void hwHaYIiTEvRaleSlaFhMhqeHzxK(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
				if (AefEkpbfHElTyBMlaqmDNCteGkjO != null)
				{
					AefEkpbfHElTyBMlaqmDNCteGkjO.Dispose();
				}
				if (TPSpSLhbrlBSIvSWkEtRGjZVKkR != null)
				{
					TPSpSLhbrlBSIvSWkEtRGjZVKkR.Dispose();
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
