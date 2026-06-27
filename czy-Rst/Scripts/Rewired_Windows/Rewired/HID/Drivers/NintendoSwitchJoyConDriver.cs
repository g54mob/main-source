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
		private const int HStDEFKYANAvVUTkVFcYiXlACbuBc = 11;

		private const int DGeIRfcLDRSckfyrtDSISjbTHbDw = 2;

		private const int czxbHpeBwtnUuBlLulqHATZxvUqwA = 1;

		private const int HNzbjEOVIPQDCblWEaidCPjtAkTh = 1;

		private const int TiGPyptCAKqdCPRDXgtSecBxLmmY = 3;

		private readonly NativeBuffer SgNaxopxrAcTtGWpEHBENKKuIWNAA;

		private readonly NintendoSwitchJoyConType fmTFTQKJjlkkuVPudaOYQrrnMGARA;

		private NintendoSwitchJoyConGripStyle eEGNbPNhkwlJFOpmkdFWUgwNbhYA;

		private readonly byte[] KzgCoIhuLyGuKdwffrmpfkCKLQDdc = new byte[3];

		protected byte[] buttonAxisReadBuffer => KzgCoIhuLyGuKdwffrmpfkCKLQDdc;

		protected abstract int byteIndexStartSticks { get; }

		NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => fmTFTQKJjlkkuVPudaOYQrrnMGARA;

		NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
		{
			get
			{
				return eEGNbPNhkwlJFOpmkdFWUgwNbhYA;
			}
			set
			{
				eEGNbPNhkwlJFOpmkdFWUgwNbhYA = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (eEGNbPNhkwlJFOpmkdFWUgwNbhYA == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, HhGUzcDWBmLEChxRWFLeeoTNXhWA P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConLeft && P_1 != HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			fmTFTQKJjlkkuVPudaOYQrrnMGARA = ((P_1 != HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			eEGNbPNhkwlJFOpmkdFWUgwNbhYA = NintendoSwitchJoyConGripStyle.Horizontal;
			SgNaxopxrAcTtGWpEHBENKKuIWNAA = new NativeBuffer(5);
			axes = new dnWPfQfDfnEmaJKgzGFSEYqFnsqm[2]
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
				}, false, 32767)
			};
			Initialize();
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] kzgCoIhuLyGuKdwffrmpfkCKLQDdc = KzgCoIhuLyGuKdwffrmpfkCKLQDdc;
			inputReport.Read(kzgCoIhuLyGuKdwffrmpfkCKLQDdc, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(kzgCoIhuLyGuKdwffrmpfkCKLQDdc[0] | ((kzgCoIhuLyGuKdwffrmpfkCKLQDdc[1] & 0xF) << 8));
			ushort valueY = (ushort)((kzgCoIhuLyGuKdwffrmpfkCKLQDdc[1] >> 4) | (kzgCoIhuLyGuKdwffrmpfkCKLQDdc[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			SgNaxopxrAcTtGWpEHBENKKuIWNAA.Write((byte)33, 0);
			SgNaxopxrAcTtGWpEHBENKKuIWNAA.Write(calibratedX, 1);
			SgNaxopxrAcTtGWpEHBENKKuIWNAA.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].zlNHwfexPeybhRZVfQjgkewMqYcH(SgNaxopxrAcTtGWpEHBENKKuIWNAA, timestamp);
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
				if (disposing && SgNaxopxrAcTtGWpEHBENKKuIWNAA != null)
				{
					SgNaxopxrAcTtGWpEHBENKKuIWNAA.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
