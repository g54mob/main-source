using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IHIDControllerExtension, IControllerDriver, IDriver_NintendoSwitchController, IDriver_NintendoSwitchProController
	{
		private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 18;

		private const int AwUBlBIarYlMFWZXoHYmfVypiArhb = 4;

		private const int YXyQZPluEhsvCTBttWxtVKCEjmXy = 2;

		private const int GiXHgIkgyGoBLtggvaYLqIpcRSmg = 3;

		private const int xshlOwJHnEjifqihmyZTQPeyTvdu = 6;

		private const int sGgRtOFgjOLVHbLJKdvDHFgnFzNBb = 1;

		private const int isGnbFgtKhsRFxdNdBPxAsUjsqHMA = 3;

		private const int yhSyPViGjzluAicdsiayQHoAanXS = 5;

		private const int ZnNvgbonbKQrHskaGHOXkBUBWAfl = 7;

		private readonly byte[] bIjJoRDNTjTepuOZHNyqmByIaNBW = new byte[6];

		private readonly NativeBuffer SutKjrSnBbjEjHsWUzAzKovaoPxTA;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, RBOSFYcFMxSplZbDyfFnHXSWynIJ.ProController, 18, 4, 2)
		{
			SutKjrSnBbjEjHsWUzAzKovaoPxTA = new NativeBuffer(9);
			axes = new vapXGbCthTfrBlIUGtkgzOtCLETf[4]
			{
				new vapXGbCthTfrBlIUGtkgzOtCLETf(33, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(33, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(33, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
				new vapXGbCthTfrBlIUGtkgzOtCLETf(33, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
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
			inputReport.Read(bIjJoRDNTjTepuOZHNyqmByIaNBW, 3, 3);
			buttons[0].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 4) != 0, timestamp);
			buttons[1].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 8) != 0, timestamp);
			buttons[2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 1) != 0, timestamp);
			buttons[3].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 2) != 0, timestamp);
			buttons[4].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 0x40) != 0, timestamp);
			buttons[5].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 0x40) != 0, timestamp);
			buttons[6].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 0x80) != 0, timestamp);
			buttons[7].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[0] & 0x80) != 0, timestamp);
			buttons[8].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 1) != 0, timestamp);
			buttons[9].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 2) != 0, timestamp);
			buttons[10].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 0x20) != 0, timestamp);
			buttons[11].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 0x10) != 0, timestamp);
			buttons[12].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 8) != 0, timestamp);
			buttons[13].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[1] & 4) != 0, timestamp);
			buttons[14].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 2) != 0, timestamp);
			buttons[15].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 4) != 0, timestamp);
			buttons[16].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 1) != 0, timestamp);
			buttons[17].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((bIjJoRDNTjTepuOZHNyqmByIaNBW[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(YszNVDBZreQueMHaxAPTEUkXgqRz[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(bIjJoRDNTjTepuOZHNyqmByIaNBW, 6, 6);
			byte[] array = bIjJoRDNTjTepuOZHNyqmByIaNBW;
			int num = 0;
			ushort valueX = (ushort)(array[num] | ((array[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((array[1 + num] >> 4) | (array[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(array[num] | ((array[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((array[1 + num] >> 4) | (array[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write((byte)33, 0);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedX, 1);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedY, 3);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedX2, 5);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].trsfRiBFSIjLrLMemKcGjgULCoSi(SutKjrSnBbjEjHsWUzAzKovaoPxTA, timestamp);
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
				if (disposing && SutKjrSnBbjEjHsWUzAzKovaoPxTA != null)
				{
					SutKjrSnBbjEjHsWUzAzKovaoPxTA.Dispose();
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
