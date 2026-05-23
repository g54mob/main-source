using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private const int HHXMZHlzIUlaTzLaeMxMqrNhhwts = 11;

		private const int BoOyOvNCVCYpeRZnOUQYzePigmAS = 2;

		private const int obXpKfmgcmvFmDlVRdjNwUzOlPro = 1;

		private const int ZPmyQfWaWLoYZSzrrInnZuIJIQD = 1;

		private const int FKabpvbIQHPcSFdVakqEUFbmStpib = 3;

		private readonly NativeBuffer WgrgtoSbpBOvhgpXfAgAaicXDNGe;

		private readonly NintendoSwitchJoyConType xObsWUevjqtxsbgeIRHKMxHMLsZL;

		private NintendoSwitchJoyConGripStyle cWsSWtgcjjiBXeEvHAyBdVSBjyyo;

		private readonly byte[] YWGQpCBqBngtKgEfCSdllPyiMNKhb = new byte[3];

		protected byte[] buttonAxisReadBuffer => YWGQpCBqBngtKgEfCSdllPyiMNKhb;

		protected abstract int byteIndexStartSticks { get; }

		NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => xObsWUevjqtxsbgeIRHKMxHMLsZL;

		NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
		{
			get
			{
				return cWsSWtgcjjiBXeEvHAyBdVSBjyyo;
			}
			set
			{
				cWsSWtgcjjiBXeEvHAyBdVSBjyyo = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (cWsSWtgcjjiBXeEvHAyBdVSBjyyo == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, BcXVNrwlGYMmCDHjgcGZTTSoSUao P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != BcXVNrwlGYMmCDHjgcGZTTSoSUao.JoyConLeft && P_1 != BcXVNrwlGYMmCDHjgcGZTTSoSUao.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			xObsWUevjqtxsbgeIRHKMxHMLsZL = ((P_1 != BcXVNrwlGYMmCDHjgcGZTTSoSUao.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			cWsSWtgcjjiBXeEvHAyBdVSBjyyo = NintendoSwitchJoyConGripStyle.Horizontal;
			WgrgtoSbpBOvhgpXfAgAaicXDNGe = new NativeBuffer(5);
			axes = new nZeIQQWnQohhanyhWEOObGRunlRc[2]
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
				}, false, 32767)
			};
			Initialize();
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(QTwvMqRjxXBwLOoUpuezGnwheUbM[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] yWGQpCBqBngtKgEfCSdllPyiMNKhb = YWGQpCBqBngtKgEfCSdllPyiMNKhb;
			inputReport.Read(yWGQpCBqBngtKgEfCSdllPyiMNKhb, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(yWGQpCBqBngtKgEfCSdllPyiMNKhb[0] | ((yWGQpCBqBngtKgEfCSdllPyiMNKhb[1] & 0xF) << 8));
			ushort valueY = (ushort)((yWGQpCBqBngtKgEfCSdllPyiMNKhb[1] >> 4) | (yWGQpCBqBngtKgEfCSdllPyiMNKhb[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			WgrgtoSbpBOvhgpXfAgAaicXDNGe.Write((byte)33, 0);
			WgrgtoSbpBOvhgpXfAgAaicXDNGe.Write(calibratedX, 1);
			WgrgtoSbpBOvhgpXfAgAaicXDNGe.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].nbdaOhPzrnnznbxNEnDgLWCrHhfx(WgrgtoSbpBOvhgpXfAgAaicXDNGe, timestamp);
			}
		}

		protected abstract void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY);

		~NintendoSwitchJoyConDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!base.disposed)
			{
				if (disposing && WgrgtoSbpBOvhgpXfAgAaicXDNGe != null)
				{
					WgrgtoSbpBOvhgpXfAgAaicXDNGe.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
