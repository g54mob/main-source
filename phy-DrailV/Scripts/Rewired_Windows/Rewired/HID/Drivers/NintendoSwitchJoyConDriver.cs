using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IHIDControllerExtension, IControllerDriver, IDriver_NintendoSwitchController, IDriver_NintendoSwitchJoyCon, IAxisCalibrationIndexMap
	{
		private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 11;

		private const int AwUBlBIarYlMFWZXoHYmfVypiArhb = 2;

		private const int YXyQZPluEhsvCTBttWxtVKCEjmXy = 1;

		private const int STfLCsbOBbuLjQlXbmODVSWdiKvw = 1;

		private const int xxqhUVuEgPdsGeflNSdYBFBjghWqA = 3;

		private readonly NativeBuffer SutKjrSnBbjEjHsWUzAzKovaoPxTA;

		private readonly NintendoSwitchJoyConType OzsNPmuRvZhbCAnBtMBNtwzTfuse;

		private NintendoSwitchJoyConGripStyle eqsFdrmyBPnzSYjGXCErapgLXpjT;

		private readonly byte[] bIjJoRDNTjTepuOZHNyqmByIaNBW = new byte[3];

		protected byte[] buttonAxisReadBuffer => bIjJoRDNTjTepuOZHNyqmByIaNBW;

		protected abstract int byteIndexStartSticks { get; }

		public NintendoSwitchJoyConType joyConType => OzsNPmuRvZhbCAnBtMBNtwzTfuse;

		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				return eqsFdrmyBPnzSYjGXCErapgLXpjT;
			}
			set
			{
				eqsFdrmyBPnzSYjGXCErapgLXpjT = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (eqsFdrmyBPnzSYjGXCErapgLXpjT == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, RBOSFYcFMxSplZbDyfFnHXSWynIJ P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConLeft && P_1 != RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			OzsNPmuRvZhbCAnBtMBNtwzTfuse = ((P_1 != RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			eqsFdrmyBPnzSYjGXCErapgLXpjT = NintendoSwitchJoyConGripStyle.Horizontal;
			SutKjrSnBbjEjHsWUzAzKovaoPxTA = new NativeBuffer(5);
			axes = new vapXGbCthTfrBlIUGtkgzOtCLETf[2]
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
				}, false, 32767)
			};
			Initialize();
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(YszNVDBZreQueMHaxAPTEUkXgqRz[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] array = bIjJoRDNTjTepuOZHNyqmByIaNBW;
			inputReport.Read(array, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(array[0] | ((array[1] & 0xF) << 8));
			ushort valueY = (ushort)((array[1] >> 4) | (array[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write((byte)33, 0);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedX, 1);
			SutKjrSnBbjEjHsWUzAzKovaoPxTA.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].trsfRiBFSIjLrLMemKcGjgULCoSi(SutKjrSnBbjEjHsWUzAzKovaoPxTA, timestamp);
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
				if (disposing && SutKjrSnBbjEjHsWUzAzKovaoPxTA != null)
				{
					SutKjrSnBbjEjHsWUzAzKovaoPxTA.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
