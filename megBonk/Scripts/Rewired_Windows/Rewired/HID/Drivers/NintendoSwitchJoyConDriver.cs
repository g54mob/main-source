using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private const int RBePpdABnOsrIeDfVBNhBxcQLZsK = 11;

		private const int PrbEqXqcsAxtfYwXhkwzSiFZVFsc = 2;

		private const int aiiEeXHFDgIVrKsSoJrmRcQjDmiV = 1;

		private const int TeeHuehAzIRDZEWHSVFMHEobqkDDb = 1;

		private const int PRRzFDddtLuhJwAiHQpdkEWvYJud = 3;

		private readonly NativeBuffer GVMzoKfoKBJGuadaEBknrBPgvkDRA;

		private readonly NintendoSwitchJoyConType zUIKGqDNMwxJlqvzzbLlnfmdcvMj;

		private NintendoSwitchJoyConGripStyle yHLqWVDvMhRwChzcmqOwQwjcNHhw;

		private readonly byte[] AizjWksJsdrpHRVodRdEgGFTauBk;

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

		protected NintendoSwitchJoyConDriver(InitArgs P_0, TcyrPLPfzGgITAruLwqcettRbltv P_1)
			: base(null, default(TcyrPLPfzGgITAruLwqcettRbltv), 0, 0, 0)
		{
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		protected override void UpdateElements(GLNYbQuaOXeaSToXMWjUhtXAplaf[] elements, NativeBuffer inputReport, double timestamp)
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
