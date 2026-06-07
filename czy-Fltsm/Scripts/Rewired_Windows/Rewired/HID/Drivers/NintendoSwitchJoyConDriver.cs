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
		private const int ROShwPYjZJPqfdFnfMcGCaBZdtUT = 11;

		private const int ZRDcPbgFGRQKOXCuVjKSTnFOtCfJ = 2;

		private const int cIOujtLpvdaBIFzYWCYXWqpqEACL = 1;

		private const int ZTCBAYHYDRgggdNLAsQxjLFxwYhyb = 1;

		private const int FjGRfRvLEDRmOnUbVPAClhyUoSbA = 3;

		private readonly NativeBuffer WUiSWafIcKVjTwHccejIaQutHGtpA;

		private readonly NintendoSwitchJoyConType jVqasAJWspMqUjJvNmCEggToESyX;

		private NintendoSwitchJoyConGripStyle sivpcdDGqaCBlCayKYRHmNSzKtXAb;

		private readonly byte[] KIBXcGsaKmDKcWJcTBCfvQaQdCnU = new byte[3];

		protected byte[] buttonAxisReadBuffer => KIBXcGsaKmDKcWJcTBCfvQaQdCnU;

		protected abstract int byteIndexStartSticks { get; }

		NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => jVqasAJWspMqUjJvNmCEggToESyX;

		NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
		{
			get
			{
				return sivpcdDGqaCBlCayKYRHmNSzKtXAb;
			}
			set
			{
				sivpcdDGqaCBlCayKYRHmNSzKtXAb = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (sivpcdDGqaCBlCayKYRHmNSzKtXAb == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, NMOoxbNrRRsluLpmhhjPhxWOwZVpA P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != NMOoxbNrRRsluLpmhhjPhxWOwZVpA.JoyConLeft && P_1 != NMOoxbNrRRsluLpmhhjPhxWOwZVpA.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			jVqasAJWspMqUjJvNmCEggToESyX = ((P_1 != NMOoxbNrRRsluLpmhhjPhxWOwZVpA.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			sivpcdDGqaCBlCayKYRHmNSzKtXAb = NintendoSwitchJoyConGripStyle.Horizontal;
			WUiSWafIcKVjTwHccejIaQutHGtpA = new NativeBuffer(5);
			axes = new bpjwwWbNobTCGrXbZKxCDfQGumWO[2]
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
				}, false, 32767)
			};
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(OYzieseEeYXDrIqXsZAdwVmBBsCg[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] kIBXcGsaKmDKcWJcTBCfvQaQdCnU = KIBXcGsaKmDKcWJcTBCfvQaQdCnU;
			inputReport.Read(kIBXcGsaKmDKcWJcTBCfvQaQdCnU, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(kIBXcGsaKmDKcWJcTBCfvQaQdCnU[0] | ((kIBXcGsaKmDKcWJcTBCfvQaQdCnU[1] & 0xF) << 8));
			ushort valueY = (ushort)((kIBXcGsaKmDKcWJcTBCfvQaQdCnU[1] >> 4) | (kIBXcGsaKmDKcWJcTBCfvQaQdCnU[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			WUiSWafIcKVjTwHccejIaQutHGtpA.Write((byte)48, 0);
			WUiSWafIcKVjTwHccejIaQutHGtpA.Write(calibratedX, 1);
			WUiSWafIcKVjTwHccejIaQutHGtpA.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].bNihcfetwkjYPbAQTEqgnRQFuUSJ(WUiSWafIcKVjTwHccejIaQutHGtpA, timestamp);
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
				if (disposing && WUiSWafIcKVjTwHccejIaQutHGtpA != null)
				{
					WUiSWafIcKVjTwHccejIaQutHGtpA.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
