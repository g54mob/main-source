using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchJoyConLeftDriver : NintendoSwitchJoyConDriver
	{
		private const int gcDiwCUJbMsObzDDRFSlJDRqgWmm = 4;

		private const int mxjVpatklIPiOOtRxvMXwFujPvtq = 6;

		protected override int byteIndexStartSticks => 0;

		public NintendoSwitchJoyConLeftDriver(InitArgs P_0)
			: base(null, default(QwAxKCqcQdVZqAtdHqKPatvkXEam))
		{
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
		}

		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
		}

		~NintendoSwitchJoyConLeftDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}
	}
}
