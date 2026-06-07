using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SwitchJoyConRightDriver : NintendoSwitchJoyConDriver
	{
		protected override int byteIndexStartSticks => 0;

		public SwitchJoyConRightDriver(InitArgs P_0)
			: base(null, default(yLpbwZJUFNkRouxglOYNdRyBNHOG))
		{
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
		}

		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
		}

		~SwitchJoyConRightDriver()
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
