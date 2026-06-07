using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int jiFKiYwzWfOOzWzucKnEmRqLMCVt = 18;

		private const int oYcCuyvJpMhucAFNtJPGLIZTGwKt = 4;

		private const int cnPmbeqOWAmdelQWlgoFDWJbiVmIA = 2;

		private const int NvZDbvSzyjCZgpfUsGBzqRXIpjun = 3;

		private const int vYyFqkbyLOKfEtncZVTONStxFygab = 6;

		private const int xBwRoKkpexrpSwXHvdpyzIGjnKbW = 1;

		private const int qVqmGBicakZMWwcfplbNPuYYenSR = 3;

		private const int QVSWHxHjONfRczepRynAWwSxxEuk = 5;

		private const int qqGCfeEjHqwkAfQATXbqsfqGNxMOA = 7;

		private readonly byte[] FlLxdXyLSZyrNzTkXWxVzBpIdFh;

		private readonly NativeBuffer PigFbyLRRtHFFnWffuOQIONYCtMu;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(null, default(QwAxKCqcQdVZqAtdHqKPatvkXEam), 0, 0, 0)
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

		protected override void UpdateElements(FWfncLHkdkAtpfBEQVIdHvRpLZvXA[] elements, NativeBuffer inputReport, double timestamp)
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
