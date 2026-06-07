using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int iRBLPXmtTqsNYVCufyJRaRbxpicM = 18;

		private const int nSqvgzrciPEiFXxZyGxHXGIrSUjW = 4;

		private const int ftDhUlqwVJDePgMAwhCQDKKPctFPA = 2;

		private const int AFRRYsItveiAFqTOdKvcuTUaKDDS = 3;

		private const int erqVNxabOTtknauiKlzLIkcNRGTo = 6;

		private const int kueeNPajbsWmpbaZyoDdrLBHrqSt = 1;

		private const int xEcJbYeTfzVPjfHraMVSPpRmEFnkA = 3;

		private const int NdWtqwBeJOfeFwVhSgYFGdPNdPZaA = 5;

		private const int jZMzElbRIfQllJrWCPNbnWtqGDxn = 7;

		private readonly byte[] ItbcZgRzJFIOUOzMzhNaHepNkhif;

		private readonly NativeBuffer WSwNCxFLUuCGukyluqcXQJUsYBdV;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(default(InitArgs), default(JLQITNuLVoGPiJxXEWOqoebWxbLC), 0, 0, 0)
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

		protected override void UpdateElements(MdziBGNqephqKFAONQgipbAHplCzA[] elements, NativeBuffer inputReport, double timestamp)
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
