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
		private enum MxvfncoEVOGcbUxgnKhRpqGfpud
		{
			ZFCrzwQWdXjoSWevRAnbaVqJWOkq = 0,
			VEsuHrgajAVOOSyTDIhUxJRDDsn = 1
		}

		private const int SzOrKughBvIrlmFPVEwapSngfKr = 1523;

		private const int MrZzDKCAPVvQcKMLAoLUsNbtzQr = 210;

		private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 50;

		private const int cYBjrIoNHUGKXBbLSOmpHedpcAZB = 44;

		private const int mGrDUVEtrjKvotyMahPBJEdZJCc = 6;

		private const int EDQCUkmaOOSfWhZtmUmVaJwHksP = 44;

		private const int LOlCWfRtBrHfabXeoMLxjPLOUqs = 45;

		private const int KORLnkWdPlDJVOSMZEqKMdTcrap = 46;

		private const int LurSfGvtIVJWLFHfWZnwgNEdteO = 47;

		private const int mTmObEbzqxDHzLtYjJvHnxGUwCZ = 48;

		private const int NsgeMSRHOKvtDNfkaLvZWapRIVa = 49;

		private const int WhfLmGgsmZPBFadTJanmJjXtdos = 0;

		private const int NsmbVuYVxJQSnOnRNDwSPgrzCaR = 15;

		private const int MhXsDGNEwWHrzDDApdsYGtftGZG = 9;

		private const int VvXRSZWljFZNBIrTLgBngxkaRiC = 1;

		private const int QXAglMjesTKktcvbVcIMqgjDlpo = 2;

		private const int kRiqLekFPYpGXvFxPmnafmMwLIt = 3;

		private const int ZGKVIQAMHMvrqvFiBuVeyDhPLQg = 4;

		private const int ybDbKdguxjSMScUMxqojBUAbwsiW = 5;

		private const int SnwOFTvxtPBIqhcdpghJIKcljLci = 6;

		private const int ztoVmSSyTNcdxCSGvcuTEOISwPJ = 7;

		private const int VHhUhbOpVgJMrzVffhfPhHjZnCN = 8;

		private const int ZShgwKDJCHGBZxoERdcesAhFVaaI = 14;

		private const int VlExbtCvFrlZbBdvnbzHhpSDxtYR = 3;

		private const int YoceFjKrycRXaEGKnMPugYIlHzan = 7;

		private readonly NativeBuffer wHROFVCPoBcgoRFVjtkCSkMeFuk;

		private readonly NativeBuffer rduQNjAjUwpDOenklfOCQHuddaf;

		private bool FMhfkWGAYGybHhztrTbStogOcWbU;

		private byte[] eGmWlwsIQdtHbXFgnOPoCKQOEDd = new byte[3];

		private readonly OutputReport mrlYPePkWgGjXkbGVrGeWhyFtAPK;

		private readonly Func<OutputReport, bool> MGQfESFdwSETxDxqyVdJeMTdFOuC;

		private readonly Action<OutputReport> vqMzbKWSwIyLZlIopEOnsCgzEOm;

		public bool SpeakerEnabled
		{
			get
			{
				return FMhfkWGAYGybHhztrTbStogOcWbU;
			}
			set
			{
				FMhfkWGAYGybHhztrTbStogOcWbU = value;
				MWdbRGcNfhnGUHNBugXDSMzIjfT(MxvfncoEVOGcbUxgnKhRpqGfpud.ZFCrzwQWdXjoSWevRAnbaVqJWOkq, CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				eGmWlwsIQdtHbXFgnOPoCKQOEDd[digitIndex] = digitBitValues;
				MWdbRGcNfhnGUHNBugXDSMzIjfT(MxvfncoEVOGcbUxgnKhRpqGfpud.VEsuHrgajAVOOSyTDIhUxJRDDsn, CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			eGmWlwsIQdtHbXFgnOPoCKQOEDd[0] = digit1BitValues;
			eGmWlwsIQdtHbXFgnOPoCKQOEDd[1] = digit2BitValues;
			eGmWlwsIQdtHbXFgnOPoCKQOEDd[2] = digit3BitValues;
			MWdbRGcNfhnGUHNBugXDSMzIjfT(MxvfncoEVOGcbUxgnKhRpqGfpud.VEsuHrgajAVOOSyTDIhUxJRDDsn, CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD);
		}

		public RailDriverDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			wHROFVCPoBcgoRFVjtkCSkMeFuk = new NativeBuffer(15);
			rduQNjAjUwpDOenklfOCQHuddaf = new NativeBuffer(9);
			mrlYPePkWgGjXkbGVrGeWhyFtAPK = new OutputReport(rduQNjAjUwpDOenklfOCQHuddaf.Pointer, rduQNjAjUwpDOenklfOCQHuddaf.Length, 9);
			MGQfESFdwSETxDxqyVdJeMTdFOuC = initArgs.synchronousWriteOutputReportDelegate;
			vqMzbKWSwIyLZlIopEOnsCgzEOm = initArgs.asynchronousWriteOutputReportDelegate;
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
			if (inputReportLength < wHROFVCPoBcgoRFVjtkCSkMeFuk.Length)
			{
				return false;
			}
			wHROFVCPoBcgoRFVjtkCSkMeFuk.Write(inputReportPtr, inputReportLength, wHROFVCPoBcgoRFVjtkCSkMeFuk.Length);
			dpxLoNUKQscDlKAbeZOSlMIeEvD(wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			FZlxIiFbfuBYttTXpfAXtPpltho(axes, wHROFVCPoBcgoRFVjtkCSkMeFuk, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool MWdbRGcNfhnGUHNBugXDSMzIjfT(MxvfncoEVOGcbUxgnKhRpqGfpud P_0, CvGIYAiMgYJmSqaJkRZPGAFfBeJb P_1)
		{
			pOvvcIDYnvotyPoiWFcSBJEwlEPO(P_0);
			return ELTYrNSbPohkwkUYTOzoZuPMPVT(P_1);
		}

		private void pOvvcIDYnvotyPoiWFcSBJEwlEPO(MxvfncoEVOGcbUxgnKhRpqGfpud P_0)
		{
			switch (P_0)
			{
			case MxvfncoEVOGcbUxgnKhRpqGfpud.ZFCrzwQWdXjoSWevRAnbaVqJWOkq:
				rduQNjAjUwpDOenklfOCQHuddaf.Clear();
				rduQNjAjUwpDOenklfOCQHuddaf[1] = 133;
				rduQNjAjUwpDOenklfOCQHuddaf[7] = (byte)(FMhfkWGAYGybHhztrTbStogOcWbU ? 1 : 0);
				break;
			case MxvfncoEVOGcbUxgnKhRpqGfpud.VEsuHrgajAVOOSyTDIhUxJRDDsn:
				rduQNjAjUwpDOenklfOCQHuddaf.Clear();
				rduQNjAjUwpDOenklfOCQHuddaf[1] = 134;
				rduQNjAjUwpDOenklfOCQHuddaf[2] = eGmWlwsIQdtHbXFgnOPoCKQOEDd[0];
				rduQNjAjUwpDOenklfOCQHuddaf[3] = eGmWlwsIQdtHbXFgnOPoCKQOEDd[1];
				rduQNjAjUwpDOenklfOCQHuddaf[4] = eGmWlwsIQdtHbXFgnOPoCKQOEDd[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool ELTYrNSbPohkwkUYTOzoZuPMPVT(CvGIYAiMgYJmSqaJkRZPGAFfBeJb P_0)
		{
			switch (P_0)
			{
			case CvGIYAiMgYJmSqaJkRZPGAFfBeJb.xZuRfCCvmDouxJKprRhnKByJKHD:
				if (MGQfESFdwSETxDxqyVdJeMTdFOuC == null)
				{
					return false;
				}
				return MGQfESFdwSETxDxqyVdJeMTdFOuC(mrlYPePkWgGjXkbGVrGeWhyFtAPK);
			case CvGIYAiMgYJmSqaJkRZPGAFfBeJb.JeCFtnHdSHkNKaBJSloqagIGicGg:
				if (vqMzbKWSwIyLZlIopEOnsCgzEOm == null)
				{
					return false;
				}
				vqMzbKWSwIyLZlIopEOnsCgzEOm(mrlYPePkWgGjXkbGVrGeWhyFtAPK);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void dpxLoNUKQscDlKAbeZOSlMIeEvD(NativeBuffer P_0, double P_1)
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

		private void FZlxIiFbfuBYttTXpfAXtPpltho(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
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
				if (wHROFVCPoBcgoRFVjtkCSkMeFuk != null)
				{
					wHROFVCPoBcgoRFVjtkCSkMeFuk.Dispose();
				}
				if (rduQNjAjUwpDOenklfOCQHuddaf != null)
				{
					rduQNjAjUwpDOenklfOCQHuddaf.Dispose();
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
