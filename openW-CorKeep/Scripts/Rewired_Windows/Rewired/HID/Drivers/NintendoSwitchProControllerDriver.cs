using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int BBszhDLFLNUtdgkzUGLUcnrqRCvfA = 18;

		private const int IPPZlfMyegGDsiCNVbtCYSUkqTmE = 4;

		private const int UxcbuhFJXieSucLHbTETlVUPITIHb = 2;

		private const int tnmSwazvlJSgiFYFIrxvtcQxehEn = 3;

		private const int DPLrfdVyGkTQUTNnlIhWGZeQHaIDA = 6;

		private const int BUNehBFDrDmAQzKIZOPwngVYBGHhb = 1;

		private const int QoFbPQdRnKPhQWvoPEXNHCFlyhoQA = 3;

		private const int ycdVuryDZjOoUZwzuOAINHbSrAhc = 5;

		private const int KhtNqpUIMYwRUuyLjQJwaJnbPzwq = 7;

		private readonly byte[] fmEOFmiRxwoblhygKxrlQDoMOklL = new byte[6];

		private readonly NativeBuffer lVVuovaMCTXmHVPuDboAKNObmlsEb;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, yLpbwZJUFNkRouxglOYNdRyBNHOG.ProController, 18, 4, 2)
		{
			lVVuovaMCTXmHVPuDboAKNObmlsEb = new NativeBuffer(9);
			axes = new OLAxjmdqJbHeCArvVCNIDgdBciXE[4]
			{
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(33, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(33, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(33, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(33, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
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
			Initialize();
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
			inputReport.Read(fmEOFmiRxwoblhygKxrlQDoMOklL, 3, 3);
			buttons[0].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 4) != 0, timestamp);
			buttons[1].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 8) != 0, timestamp);
			buttons[2].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 1) != 0, timestamp);
			buttons[3].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 2) != 0, timestamp);
			buttons[4].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 0x40) != 0, timestamp);
			buttons[5].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 0x40) != 0, timestamp);
			buttons[6].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 0x80) != 0, timestamp);
			buttons[7].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[0] & 0x80) != 0, timestamp);
			buttons[8].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 1) != 0, timestamp);
			buttons[9].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 2) != 0, timestamp);
			buttons[10].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 0x20) != 0, timestamp);
			buttons[11].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 0x10) != 0, timestamp);
			buttons[12].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 8) != 0, timestamp);
			buttons[13].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[1] & 4) != 0, timestamp);
			buttons[14].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 2) != 0, timestamp);
			buttons[15].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 4) != 0, timestamp);
			buttons[16].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 1) != 0, timestamp);
			buttons[17].fihwdEXCUmtjghmZzTkajeNnBqkZ((fmEOFmiRxwoblhygKxrlQDoMOklL[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(fmEOFmiRxwoblhygKxrlQDoMOklL, 6, 6);
			byte[] array = fmEOFmiRxwoblhygKxrlQDoMOklL;
			int num = 0;
			ushort valueX = (ushort)(array[num] | ((array[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((array[1 + num] >> 4) | (array[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(array[num] | ((array[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((array[1 + num] >> 4) | (array[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			lVVuovaMCTXmHVPuDboAKNObmlsEb.Write((byte)33, 0);
			lVVuovaMCTXmHVPuDboAKNObmlsEb.Write(calibratedX, 1);
			lVVuovaMCTXmHVPuDboAKNObmlsEb.Write(calibratedY, 3);
			lVVuovaMCTXmHVPuDboAKNObmlsEb.Write(calibratedX2, 5);
			lVVuovaMCTXmHVPuDboAKNObmlsEb.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].SnJrVNcoeoNiXCCQLiNahDsWooVr(lVVuovaMCTXmHVPuDboAKNObmlsEb, timestamp);
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
				if (disposing && lVVuovaMCTXmHVPuDboAKNObmlsEb != null)
				{
					lVVuovaMCTXmHVPuDboAKNObmlsEb.Dispose();
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
