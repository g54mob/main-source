using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchProControllerExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension
	{
		private class QbWDetUdcAfrlRSSGoKUXCawvCIb : ExtSource_Base
		{
			public IDriver_NintendoSwitchProController LtowoWEQfEszQwuabPguraVZngUf => null;

			public QbWDetUdcAfrlRSSGoKUXCawvCIb(IDriver_NintendoSwitchProController P_0)
				: base(null)
			{
			}
		}

		public int motorIndexLeft;

		public int motorIndexRight;

		private new QbWDetUdcAfrlRSSGoKUXCawvCIb source => null;

		internal NintendoSwitchProControllerExtension(IDriver_NintendoSwitchProController P_0)
			: base((ExtSource_Base)null)
		{
		}

		private NintendoSwitchProControllerExtension(NintendoSwitchProControllerExtension P_0)
			: base((ExtSource_Base)null)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}
