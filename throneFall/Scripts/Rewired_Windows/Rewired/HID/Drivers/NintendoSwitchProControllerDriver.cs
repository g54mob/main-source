using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int cFSACfFiWKvFNTJqVkZIlBBBJJHMA = 18;

		private const int zilcNXftVvgGQBNfWjSYgmLZxdYD = 4;

		private const int tdGXFTsBEtXaImpCAIWNAnedqUwab = 2;

		private const int UtYdTKICuKiYKwcELGxpSXiIZesDA = 3;

		private const int gcvgWJalDlNouoYgeMfYnpKnYlaN = 6;

		private const int inbTKhkGoQOqwxUDUfXmEQrnANts = 1;

		private const int dtpvyoiEsTNTarCpGlPDaWpIQkQw = 3;

		private const int TpBmSYFKFoyvQafXsWEAjzlrceuc = 5;

		private const int zkVJPLxuXZipyTOUioHuStTIDyYL = 7;

		private readonly byte[] KiuBbATdyzKQBKtlHWrzwuAhCBBo = new byte[6];

		private readonly NativeBuffer IFrFPThJTYqWlcsvEOkMNvqQOoKMc;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, BcXVNrwlGYMmCDHjgcGZTTSoSUao.ProController, 18, 4, 2)
		{
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc = new NativeBuffer(9);
			axes = new nZeIQQWnQohhanyhWEOObGRunlRc[4]
			{
				new nZeIQQWnQohhanyhWEOObGRunlRc(33, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(33, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(33, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(33, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
			inputReport.Read(KiuBbATdyzKQBKtlHWrzwuAhCBBo, 3, 3);
			buttons[0].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 4) != 0, timestamp);
			buttons[1].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 8) != 0, timestamp);
			buttons[2].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 1) != 0, timestamp);
			buttons[3].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 2) != 0, timestamp);
			buttons[4].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 0x40) != 0, timestamp);
			buttons[5].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 0x40) != 0, timestamp);
			buttons[6].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 0x80) != 0, timestamp);
			buttons[7].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[0] & 0x80) != 0, timestamp);
			buttons[8].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 1) != 0, timestamp);
			buttons[9].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 2) != 0, timestamp);
			buttons[10].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 0x20) != 0, timestamp);
			buttons[11].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 0x10) != 0, timestamp);
			buttons[12].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 8) != 0, timestamp);
			buttons[13].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[1] & 4) != 0, timestamp);
			buttons[14].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 2) != 0, timestamp);
			buttons[15].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 4) != 0, timestamp);
			buttons[16].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 1) != 0, timestamp);
			buttons[17].YMBfCqamFtXXCaOMewymSLhGnbUnA((KiuBbATdyzKQBKtlHWrzwuAhCBBo[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(QTwvMqRjxXBwLOoUpuezGnwheUbM[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(KiuBbATdyzKQBKtlHWrzwuAhCBBo, 6, 6);
			byte[] kiuBbATdyzKQBKtlHWrzwuAhCBBo = KiuBbATdyzKQBKtlHWrzwuAhCBBo;
			int num = 0;
			ushort valueX = (ushort)(kiuBbATdyzKQBKtlHWrzwuAhCBBo[num] | ((kiuBbATdyzKQBKtlHWrzwuAhCBBo[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((kiuBbATdyzKQBKtlHWrzwuAhCBBo[1 + num] >> 4) | (kiuBbATdyzKQBKtlHWrzwuAhCBBo[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(kiuBbATdyzKQBKtlHWrzwuAhCBBo[num] | ((kiuBbATdyzKQBKtlHWrzwuAhCBBo[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((kiuBbATdyzKQBKtlHWrzwuAhCBBo[1 + num] >> 4) | (kiuBbATdyzKQBKtlHWrzwuAhCBBo[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Write((byte)33, 0);
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Write(calibratedX, 1);
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Write(calibratedY, 3);
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Write(calibratedX2, 5);
			IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].nbdaOhPzrnnznbxNEnDgLWCrHhfx(IFrFPThJTYqWlcsvEOkMNvqQOoKMc, timestamp);
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
				if (disposing && IFrFPThJTYqWlcsvEOkMNvqQOoKMc != null)
				{
					IFrFPThJTYqWlcsvEOkMNvqQOoKMc.Dispose();
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
