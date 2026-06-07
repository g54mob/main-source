using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private readonly byte[] fmEOFmiRxwoblhygKxrlQDoMOklL;

		private readonly NativeBuffer lVVuovaMCTXmHVPuDboAKNObmlsEb;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(null, default(yLpbwZJUFNkRouxglOYNdRyBNHOG), 0, 0, 0)
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
		}

		protected override void UpdateElements(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements, NativeBuffer inputReport, double timestamp)
		{
		}

		~NintendoSwitchProControllerDriver()
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
