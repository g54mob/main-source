using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SwitchJoyConRightDriver : NintendoSwitchJoyConDriver
	{
		private const int RwQjnKHOvspcVcNMWUjtxpqUVXuU = 3;

		private const int THnbRGTNNkcKbwPRUUoITABiQePJ = 9;

		int NintendoSwitchJoyConDriver.byteIndexStartSticks => 9;

		public SwitchJoyConRightDriver(InitArgs P_0)
			: base(P_0, HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConRight)
		{
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			byte[] array = base.buttonAxisReadBuffer;
			inputReport.Read(array, 2, 3);
			byte b = array[0];
			buttons[0].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 8) != 0, timestamp);
			buttons[1].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, timestamp);
			buttons[2].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 4) != 0, timestamp);
			buttons[3].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 1) != 0, timestamp);
			buttons[4].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x20) != 0, timestamp);
			buttons[5].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, timestamp);
			buttons[6].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x40) != 0, timestamp);
			buttons[7].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x80) != 0, timestamp);
			b = array[1];
			buttons[8].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, timestamp);
			buttons[9].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, timestamp);
			buttons[10].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 4) != 0, timestamp);
		}

		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
			if (base.Rewired_002EHID_002EDrivers_002EIDriver_NintendoSwitchJoyCon_002EjoyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				ushort num = stickY;
				stickY = (ushort)(65535 - stickX);
				stickX = num;
			}
		}

		~SwitchJoyConRightDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!base.disposed)
			{
				base.Dispose(disposing);
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (vid == 1406)
			{
				return pid == 8199;
			}
			return false;
		}
	}
}
