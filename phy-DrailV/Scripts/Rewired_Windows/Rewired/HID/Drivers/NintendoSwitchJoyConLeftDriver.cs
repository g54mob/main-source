using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchJoyConLeftDriver : NintendoSwitchJoyConDriver
	{
		private const int GiXHgIkgyGoBLtggvaYLqIpcRSmg = 4;

		private const int xshlOwJHnEjifqihmyZTQPeyTvdu = 6;

		protected override int byteIndexStartSticks => 6;

		public NintendoSwitchJoyConLeftDriver(InitArgs P_0)
			: base(P_0, RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConLeft)
		{
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			byte[] array = base.buttonAxisReadBuffer;
			inputReport.Read(array, 2, 4);
			byte b = array[1];
			if (base.joyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				buttons[0].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 8) != 0, timestamp);
				buttons[1].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, timestamp);
				buttons[2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, timestamp);
				buttons[3].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 4) != 0, timestamp);
			}
			else
			{
				buttons[0].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, timestamp);
				buttons[1].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 4) != 0, timestamp);
				buttons[2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 8) != 0, timestamp);
				buttons[3].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, timestamp);
			}
			buttons[4].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, timestamp);
			buttons[5].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x10) != 0, timestamp);
			buttons[6].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x40) != 0, timestamp);
			buttons[7].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x80) != 0, timestamp);
			b = array[0];
			buttons[8].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, timestamp);
			buttons[9].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, timestamp);
			buttons[10].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 8) != 0, timestamp);
		}

		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
			if (base.joyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				ushort num = stickY;
				stickY = stickX;
				stickX = (ushort)(65535 - num);
			}
		}

		~NintendoSwitchJoyConLeftDriver()
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
				return pid == 8198;
			}
			return false;
		}
	}
}
