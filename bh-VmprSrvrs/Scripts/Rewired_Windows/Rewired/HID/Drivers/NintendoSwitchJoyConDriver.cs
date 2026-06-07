using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private const int UiSyjwxHAfbvhiAsXmPUNhmzqrbW = 11;

		private const int OQRpgCRpHlMqWAAjnlcOEykgvlKy = 2;

		private const int dcOAmCfqeDPUYiIBqlXXWNQIsGhOA = 1;

		private const int OEUcGlhWQjVQwUVKAdZhIQaAPGSt = 1;

		private const int SdvIZYWIMwTpsaAHXdQAKySWiurNA = 3;

		private readonly NativeBuffer PcmQyFCvlwLOTfApYJmSXBVBdGYFA;

		private readonly NintendoSwitchJoyConType qowvcjuLvVeuCajanOvAtQkOXUDv;

		private NintendoSwitchJoyConGripStyle lAnwcAantSnplhrfyOsBEcxRtSej;

		private readonly byte[] FHHxZxFPPAfsmFUrvsFfadLwCSWeA;

		protected byte[] buttonAxisReadBuffer => null;

		protected abstract int byteIndexStartSticks { get; }

		public NintendoSwitchJoyConType joyConType => default(NintendoSwitchJoyConType);

		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				return default(NintendoSwitchJoyConGripStyle);
			}
			set
			{
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			return 0;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, QwAxKCqcQdVZqAtdHqKPatvkXEam P_1)
			: base(null, default(QwAxKCqcQdVZqAtdHqKPatvkXEam), 0, 0, 0)
		{
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		protected override void UpdateElements(FWfncLHkdkAtpfBEQVIdHvRpLZvXA[] elements, NativeBuffer inputReport, double timestamp)
		{
		}

		protected abstract void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY);

		~NintendoSwitchJoyConDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
