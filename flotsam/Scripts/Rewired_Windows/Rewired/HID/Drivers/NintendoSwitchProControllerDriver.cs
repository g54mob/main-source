using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int oBIkhGZPRosdCPhKPoSzwTjcCedA = 18;

		private const int rXeuEZMPmqyTcTMSLpCWKbsdPehw = 4;

		private const int npNfFDREXmXtcuINLhgDDPiZRwTf = 2;

		private const int UYXnKxrdcTxussNBYQngxkdylTXA = 3;

		private const int gMaAoHThWuOBQgmdluSKHyYBqgDp = 6;

		private const int wtoervDrGPNmMnMvDugeqdSLIdIC = 1;

		private const int nzwKgeNblGgcMjryXkmLUuhujSbg = 3;

		private const int FhYSGEmRNvXXcoluvKpMZnfZOdRr = 5;

		private const int lvMcdJMoQMMQCXfBrvcwsLHsxwjL = 7;

		private readonly byte[] SYpHRYgFdaztxCDcApEhKBKNSQoQ = new byte[6];

		private readonly NativeBuffer SRstXFqSpLvVyscGHVSlNsegvFdC;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, NMOoxbNrRRsluLpmhhjPhxWOwZVpA.ProController, 18, 4, 2)
		{
			SRstXFqSpLvVyscGHVSlNsegvFdC = new NativeBuffer(9);
			axes = new bpjwwWbNobTCGrXbZKxCDfQGumWO[4]
			{
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(48, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(48, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(48, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 5,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(48, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 7,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767)
			};
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			base.Update(updateLoop);
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchProControllerExtension(this);
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(SYpHRYgFdaztxCDcApEhKBKNSQoQ, 3, 3);
			buttons[0].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 4) != 0, timestamp);
			buttons[1].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 8) != 0, timestamp);
			buttons[2].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 1) != 0, timestamp);
			buttons[3].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 2) != 0, timestamp);
			buttons[4].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 0x40) != 0, timestamp);
			buttons[5].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 0x40) != 0, timestamp);
			buttons[6].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 0x80) != 0, timestamp);
			buttons[7].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[0] & 0x80) != 0, timestamp);
			buttons[8].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 1) != 0, timestamp);
			buttons[9].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 2) != 0, timestamp);
			buttons[10].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 0x20) != 0, timestamp);
			buttons[11].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 0x10) != 0, timestamp);
			buttons[12].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 8) != 0, timestamp);
			buttons[13].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[1] & 4) != 0, timestamp);
			buttons[14].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 2) != 0, timestamp);
			buttons[15].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 4) != 0, timestamp);
			buttons[16].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 1) != 0, timestamp);
			buttons[17].AtQsHqTAryodwUVQnJukddZkgqvd((SYpHRYgFdaztxCDcApEhKBKNSQoQ[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(OYzieseEeYXDrIqXsZAdwVmBBsCg[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(SYpHRYgFdaztxCDcApEhKBKNSQoQ, 6, 6);
			byte[] sYpHRYgFdaztxCDcApEhKBKNSQoQ = SYpHRYgFdaztxCDcApEhKBKNSQoQ;
			int num = 0;
			ushort valueX = (ushort)(sYpHRYgFdaztxCDcApEhKBKNSQoQ[num] | ((sYpHRYgFdaztxCDcApEhKBKNSQoQ[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((sYpHRYgFdaztxCDcApEhKBKNSQoQ[1 + num] >> 4) | (sYpHRYgFdaztxCDcApEhKBKNSQoQ[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(sYpHRYgFdaztxCDcApEhKBKNSQoQ[num] | ((sYpHRYgFdaztxCDcApEhKBKNSQoQ[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((sYpHRYgFdaztxCDcApEhKBKNSQoQ[1 + num] >> 4) | (sYpHRYgFdaztxCDcApEhKBKNSQoQ[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			SRstXFqSpLvVyscGHVSlNsegvFdC.Write((byte)48, 0);
			SRstXFqSpLvVyscGHVSlNsegvFdC.Write(calibratedX, 1);
			SRstXFqSpLvVyscGHVSlNsegvFdC.Write(calibratedY, 3);
			SRstXFqSpLvVyscGHVSlNsegvFdC.Write(calibratedX2, 5);
			SRstXFqSpLvVyscGHVSlNsegvFdC.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].bNihcfetwkjYPbAQTEqgnRQFuUSJ(SRstXFqSpLvVyscGHVSlNsegvFdC, timestamp);
			}
		}

		~NintendoSwitchProControllerDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!base.disposed)
			{
				if (disposing && SRstXFqSpLvVyscGHVSlNsegvFdC != null)
				{
					SRstXFqSpLvVyscGHVSlNsegvFdC.Dispose();
				}
				base.Dispose(disposing);
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (vid == 1406)
			{
				return pid == 8201;
			}
			return false;
		}
	}
}
