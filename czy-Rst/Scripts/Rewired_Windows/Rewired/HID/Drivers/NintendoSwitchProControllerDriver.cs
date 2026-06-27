using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int qngNHpJZAPKCXnosuzKOsHbcdYYaA = 18;

		private const int jjHvtXUEtgEtGvlBfKoKRJEyDwPiA = 4;

		private const int prijWHLlMospQWzIpwHXCLAQEHjBA = 2;

		private const int MacUWOfBwBfVSdIIgGuzjgOdjpjoA = 3;

		private const int opBtFRDcTggzcgKsFTyEkAsUIydlA = 6;

		private const int ejPgJxZIqLSxqDoHzfIgbqFQZAmT = 1;

		private const int hzPjrqXZmQJYkXUnvGRDFePnJxHU = 3;

		private const int REdAnSuSSlepGEKnBHHISYFUiddM = 5;

		private const int hHfZQDUrPIRgghqODAQmhhzpqlVYA = 7;

		private readonly byte[] MMQgJAekUgRGTgDteaPfPAoIcOIo = new byte[6];

		private readonly NativeBuffer YSHqOHsIXXaVlhGxzkfYZKMbgnFqA;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, HhGUzcDWBmLEChxRWFLeeoTNXhWA.ProController, 18, 4, 2)
		{
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA = new NativeBuffer(9);
			axes = new dnWPfQfDfnEmaJKgzGFSEYqFnsqm[4]
			{
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(33, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(33, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(33, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(33, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
			inputReport.Read(MMQgJAekUgRGTgDteaPfPAoIcOIo, 3, 3);
			buttons[0].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 4) != 0, timestamp);
			buttons[1].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 8) != 0, timestamp);
			buttons[2].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 1) != 0, timestamp);
			buttons[3].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 2) != 0, timestamp);
			buttons[4].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 0x40) != 0, timestamp);
			buttons[5].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 0x40) != 0, timestamp);
			buttons[6].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 0x80) != 0, timestamp);
			buttons[7].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[0] & 0x80) != 0, timestamp);
			buttons[8].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 1) != 0, timestamp);
			buttons[9].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 2) != 0, timestamp);
			buttons[10].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 0x20) != 0, timestamp);
			buttons[11].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 0x10) != 0, timestamp);
			buttons[12].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 8) != 0, timestamp);
			buttons[13].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[1] & 4) != 0, timestamp);
			buttons[14].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 2) != 0, timestamp);
			buttons[15].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 4) != 0, timestamp);
			buttons[16].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 1) != 0, timestamp);
			buttons[17].MGdQDuXuJchSCgHSZmfwaNPbKwTP((MMQgJAekUgRGTgDteaPfPAoIcOIo[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(MMQgJAekUgRGTgDteaPfPAoIcOIo, 6, 6);
			byte[] mMQgJAekUgRGTgDteaPfPAoIcOIo = MMQgJAekUgRGTgDteaPfPAoIcOIo;
			int num = 0;
			ushort valueX = (ushort)(mMQgJAekUgRGTgDteaPfPAoIcOIo[num] | ((mMQgJAekUgRGTgDteaPfPAoIcOIo[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((mMQgJAekUgRGTgDteaPfPAoIcOIo[1 + num] >> 4) | (mMQgJAekUgRGTgDteaPfPAoIcOIo[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(mMQgJAekUgRGTgDteaPfPAoIcOIo[num] | ((mMQgJAekUgRGTgDteaPfPAoIcOIo[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((mMQgJAekUgRGTgDteaPfPAoIcOIo[1 + num] >> 4) | (mMQgJAekUgRGTgDteaPfPAoIcOIo[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Write((byte)33, 0);
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Write(calibratedX, 1);
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Write(calibratedY, 3);
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Write(calibratedX2, 5);
			YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].zlNHwfexPeybhRZVfQjgkewMqYcH(YSHqOHsIXXaVlhGxzkfYZKMbgnFqA, timestamp);
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
				if (disposing && YSHqOHsIXXaVlhGxzkfYZKMbgnFqA != null)
				{
					YSHqOHsIXXaVlhGxzkfYZKMbgnFqA.Dispose();
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
