using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private const int PpGbIpafJuMqQZzqYFzZnPvZPPYRA = 11;

		private const int JXTIFHLjIkutlLxpiaSPEzxMeRjR = 2;

		private const int ajCDLHecnKnZzHiPdAnSKTJqLoEmA = 1;

		private const int NMOtZsbETeNWFJCWDjAcSjvakrpf = 1;

		private const int ZwvMsBCuRxpmFfEJIEwHuPPqyESo = 3;

		private readonly NativeBuffer UvalnAIbgzcCsswvPgEJBgSrSktm;

		private readonly NintendoSwitchJoyConType nWkgZwqkuEXttflcyPBFtThuBgqU;

		private NintendoSwitchJoyConGripStyle cghPNOosNBsOqgfHtkcQWeltJBJd;

		private readonly byte[] WPREykXSOXzrNUXlewnuaeCSvonX;

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

		protected NintendoSwitchJoyConDriver(InitArgs P_0, JLQITNuLVoGPiJxXEWOqoebWxbLC P_1)
			: base(default(InitArgs), default(JLQITNuLVoGPiJxXEWOqoebWxbLC), 0, 0, 0)
		{
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		protected override void UpdateElements(MdziBGNqephqKFAONQgipbAHplCzA[] elements, NativeBuffer inputReport, double timestamp)
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
