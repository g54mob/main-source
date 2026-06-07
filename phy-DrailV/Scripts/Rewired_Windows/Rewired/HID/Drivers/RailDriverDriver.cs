using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IHIDControllerExtension, IControllerDriver, IDriver_RailDriver
	{
		private enum ofNeITdLtOyEInSuLsJeDDPOYyKg
		{
			Speaker = 0,
			LED = 1
		}

		private const int oPgcGLhpxpYcQRHnpBfLHwcZEnMd = 1523;

		private const int odfiIlFNlPYWRKpPccYftScEZhYBA = 210;

		private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 50;

		private const int GohRidjxrIGXmUiPsdrGQKgYQtuo = 44;

		private const int UsXmTeRmJfuOHIdMYKeunwumRnNn = 6;

		private const int agRNDCtGAZUzlEBOMBmSYCeuTmRA = 44;

		private const int lzFRVWCMzvtJPIkeKAgSZwIdFYXj = 45;

		private const int aFlIwDJAnlZPepeEdrztwaCBPHUJ = 46;

		private const int jmZFhtsbJDBBimvFwApRMGuKCYhC = 47;

		private const int IeEImpoPUfkRGmtOPHswNKZzejqhA = 48;

		private const int nIYnhjCuhCjramoIIEYeimGevxFd = 49;

		private const int ePxYdzxUZGLodHNlWlPgxIEXZPz = 0;

		private const int zZEAAPFGVJAACxBBpIYjxGgMYZgm = 15;

		private const int ozhfWvGyCMLbWcvQZdEvgVmIggpL = 9;

		private const int lmrjHsHvHHhVuhhVzkSCKOrJURvo = 1;

		private const int mospDdyEiTMKAFtbrngpECcoWELJ = 2;

		private const int MZAkONbkrYfMkkWdlSgDuRPZmdKjA = 3;

		private const int zqqePriVvQmxFkWqnLINoOamjtBzA = 4;

		private const int QTnEZWxkFlaCrIdUFgjONqBIjXLPA = 5;

		private const int eeQgUyaoJBjYRWWbJdyqiopUZuReA = 6;

		private const int BCMQxPREDigIjeEBSnsemVrkXoQ = 7;

		private const int dTPZJMJPVqNCMMCNPyWmHlouImgk = 8;

		private const int xAZZplGQuJcXaHRArRjVivgqHLJu = 14;

		private const int xdmdkAABblONINqnJMcyiXLeHKrjb = 3;

		private const int ofWvSMwzAufJLxsSTEOHkqHWFKTdA = 7;

		private readonly NativeBuffer WynDIcPUQZuoNwMFNYtngVTThDLT;

		private readonly NativeBuffer HuOJQfTacspCpPwKDklzixhSDESC;

		private bool bxZYbzXRaAJvsQRbHJwdQptlunKV;

		private byte[] MsUCaBdlizNVKGuaPNCZMaJnqqWAb = new byte[3];

		private readonly IHIDDevice ZdGAobiSJtgKVSSufZEKkbWOqrot;

		private readonly HIDProperties wZOmWuPOIaODgUnRVvZwyhfFATbk;

		private readonly xDlFkKEEsqHDzeOiaTIGueyqTccYA OdRhINdCygWtgcGOteXZfFdHmxobc;

		public bool SpeakerEnabled
		{
			get
			{
				return bxZYbzXRaAJvsQRbHJwdQptlunKV;
			}
			set
			{
				bxZYbzXRaAJvsQRbHJwdQptlunKV = value;
				ueVUxdtLNlEmviSBAGTegtixQTeF(ofNeITdLtOyEInSuLsJeDDPOYyKg.Speaker, AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => wZOmWuPOIaODgUnRVvZwyhfFATbk.vendorId;

		ushort IHIDControllerExtension.productId => wZOmWuPOIaODgUnRVvZwyhfFATbk.productId;

		string IHIDControllerExtension.productName => wZOmWuPOIaODgUnRVvZwyhfFATbk.productName;

		string IHIDControllerExtension.manufacturer => wZOmWuPOIaODgUnRVvZwyhfFATbk.manufacturer;

		ushort IHIDControllerExtension.usagePage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usagePage;

		ushort IHIDControllerExtension.usage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				MsUCaBdlizNVKGuaPNCZMaJnqqWAb[digitIndex] = digitBitValues;
				ueVUxdtLNlEmviSBAGTegtixQTeF(ofNeITdLtOyEInSuLsJeDDPOYyKg.LED, AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			MsUCaBdlizNVKGuaPNCZMaJnqqWAb[0] = digit1BitValues;
			MsUCaBdlizNVKGuaPNCZMaJnqqWAb[1] = digit2BitValues;
			MsUCaBdlizNVKGuaPNCZMaJnqqWAb[2] = digit3BitValues;
			ueVUxdtLNlEmviSBAGTegtixQTeF(ofNeITdLtOyEInSuLsJeDDPOYyKg.LED, AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
		}

		public RailDriverDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			ZdGAobiSJtgKVSSufZEKkbWOqrot = P_0.hidDevice;
			wZOmWuPOIaODgUnRVvZwyhfFATbk = ZdGAobiSJtgKVSSufZEKkbWOqrot.properties;
			WynDIcPUQZuoNwMFNYtngVTThDLT = new NativeBuffer(15);
			HuOJQfTacspCpPwKDklzixhSDESC = new NativeBuffer(9);
			OdRhINdCygWtgcGOteXZfFdHmxobc = new xDlFkKEEsqHDzeOiaTIGueyqTccYA(HuOJQfTacspCpPwKDklzixhSDESC.Pointer, HuOJQfTacspCpPwKDklzixhSDESC.Length, 9);
			buttons = new UGvkBdUzfogfxagdjdQqdinGSMwv[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new UGvkBdUzfogfxagdjdQqdinGSMwv(0, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new vapXGbCthTfrBlIUGtkgzOtCLETf[4]
			{
				new vapXGbCthTfrBlIUGtkgzOtCLETf(0, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(0, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(0, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(0, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
			if (inputReportLength < WynDIcPUQZuoNwMFNYtngVTThDLT.Length)
			{
				return false;
			}
			WynDIcPUQZuoNwMFNYtngVTThDLT.Write(inputReportPtr, inputReportLength, WynDIcPUQZuoNwMFNYtngVTThDLT.Length);
			RdPFzuLpsssVUfJbWIHhRQPBGScT(WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			YszNVDBZreQueMHaxAPTEUkXgqRz[] array = axes;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool ueVUxdtLNlEmviSBAGTegtixQTeF(ofNeITdLtOyEInSuLsJeDDPOYyKg P_0, AdGZaeWqClcGEbNkSQklXlRYcQrJ P_1)
		{
			TeBejrASFvqxZaiiEktdanDSFjglb(P_0);
			return aclPpaLxnqyTLVJMfezZhuMzsQcg(P_1);
		}

		private void TeBejrASFvqxZaiiEktdanDSFjglb(ofNeITdLtOyEInSuLsJeDDPOYyKg P_0)
		{
			switch (P_0)
			{
			case ofNeITdLtOyEInSuLsJeDDPOYyKg.Speaker:
				HuOJQfTacspCpPwKDklzixhSDESC.Clear();
				HuOJQfTacspCpPwKDklzixhSDESC[1] = 133;
				HuOJQfTacspCpPwKDklzixhSDESC[7] = (byte)(bxZYbzXRaAJvsQRbHJwdQptlunKV ? 1 : 0);
				break;
			case ofNeITdLtOyEInSuLsJeDDPOYyKg.LED:
				HuOJQfTacspCpPwKDklzixhSDESC.Clear();
				HuOJQfTacspCpPwKDklzixhSDESC[1] = 134;
				HuOJQfTacspCpPwKDklzixhSDESC[2] = MsUCaBdlizNVKGuaPNCZMaJnqqWAb[0];
				HuOJQfTacspCpPwKDklzixhSDESC[3] = MsUCaBdlizNVKGuaPNCZMaJnqqWAb[1];
				HuOJQfTacspCpPwKDklzixhSDESC[4] = MsUCaBdlizNVKGuaPNCZMaJnqqWAb[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			switch (P_0)
			{
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous:
				return ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous:
				ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteAsync(OdRhINdCygWtgcGOteXZfFdHmxobc, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT(NativeBuffer P_0, double P_1)
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
					buttons[num2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 < 95, P_1);
			buttons[45].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 >= 95 && b2 < 161, P_1);
			buttons[46].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 < 95, P_1);
			buttons[48].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 >= 95 && b2 < 161, P_1);
			buttons[49].uqcjdwWGLmpPBtHzkpeQnIbXtmIb(b2 >= 161, P_1);
		}

		private void tNFwFMIVpqJCnYRvDmgzNUNGOLYB(YszNVDBZreQueMHaxAPTEUkXgqRz[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].trsfRiBFSIjLrLMemKcGjgULCoSi(P_1, P_2);
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
				if (WynDIcPUQZuoNwMFNYtngVTThDLT != null)
				{
					WynDIcPUQZuoNwMFNYtngVTThDLT.Dispose();
				}
				if (HuOJQfTacspCpPwKDklzixhSDESC != null)
				{
					HuOJQfTacspCpPwKDklzixhSDESC.Dispose();
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
