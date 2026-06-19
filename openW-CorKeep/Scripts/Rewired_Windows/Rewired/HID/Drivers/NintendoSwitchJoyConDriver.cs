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
		private const int cwhhgbGkHRiOxaGzzdnCAOjcCbTec = 11;

		private const int cheepJFmELOHMYocDcWMaJjDRzkec = 2;

		private const int PPdJjJTQdjmhYcfIGsfPQmJxjGHCA = 1;

		private const int cvjBdsOdVXlryweRilSnLrpnIVqJ = 1;

		private const int ywKvYBjWFAYvcGaOpCuQxpNviaTr = 3;

		private readonly NativeBuffer frBLQmhylAwZLXsIeMCYKIVoSczB;

		private readonly NintendoSwitchJoyConType MCJGvmDLcpBXUHYtXDRWagnpqQpgb;

		private NintendoSwitchJoyConGripStyle XrCCrHXaaoNCnDzuSuqVLZusAtIq;

		private readonly byte[] vosiQgufMwZLstqeBLjfroYHpSws = new byte[3];

		protected byte[] buttonAxisReadBuffer => vosiQgufMwZLstqeBLjfroYHpSws;

		protected abstract int byteIndexStartSticks { get; }

		NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => MCJGvmDLcpBXUHYtXDRWagnpqQpgb;

		NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
		{
			get
			{
				return XrCCrHXaaoNCnDzuSuqVLZusAtIq;
			}
			set
			{
				XrCCrHXaaoNCnDzuSuqVLZusAtIq = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (XrCCrHXaaoNCnDzuSuqVLZusAtIq == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, yLpbwZJUFNkRouxglOYNdRyBNHOG P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != yLpbwZJUFNkRouxglOYNdRyBNHOG.JoyConLeft && P_1 != yLpbwZJUFNkRouxglOYNdRyBNHOG.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			MCJGvmDLcpBXUHYtXDRWagnpqQpgb = ((P_1 != yLpbwZJUFNkRouxglOYNdRyBNHOG.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			XrCCrHXaaoNCnDzuSuqVLZusAtIq = NintendoSwitchJoyConGripStyle.Horizontal;
			frBLQmhylAwZLXsIeMCYKIVoSczB = new NativeBuffer(5);
			axes = new OLAxjmdqJbHeCArvVCNIDgdBciXE[2]
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
				}, false, 32767)
			};
			Initialize();
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] array = vosiQgufMwZLstqeBLjfroYHpSws;
			inputReport.Read(array, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(array[0] | ((array[1] & 0xF) << 8));
			ushort valueY = (ushort)((array[1] >> 4) | (array[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			frBLQmhylAwZLXsIeMCYKIVoSczB.Write((byte)33, 0);
			frBLQmhylAwZLXsIeMCYKIVoSczB.Write(calibratedX, 1);
			frBLQmhylAwZLXsIeMCYKIVoSczB.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].SnJrVNcoeoNiXCCQLiNahDsWooVr(frBLQmhylAwZLXsIeMCYKIVoSczB, timestamp);
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
				if (disposing && frBLQmhylAwZLXsIeMCYKIVoSczB != null)
				{
					frBLQmhylAwZLXsIeMCYKIVoSczB.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
