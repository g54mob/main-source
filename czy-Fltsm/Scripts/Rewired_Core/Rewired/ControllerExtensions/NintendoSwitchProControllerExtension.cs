using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchProControllerExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension
	{
		private class QECeqwQNElOEqkunZifgNbyxNBup : ExtSource_Base
		{
			public IDriver_NintendoSwitchProController VjmoPOOCdrPTDPZXesMIbHEOzXyt => base.driver as IDriver_NintendoSwitchProController;

			public QECeqwQNElOEqkunZifgNbyxNBup(IDriver_NintendoSwitchProController P_0)
				: base(P_0)
			{
			}
		}

		public int motorIndexLeft;

		public int motorIndexRight = 1;

		private new QECeqwQNElOEqkunZifgNbyxNBup source => base.source as QECeqwQNElOEqkunZifgNbyxNBup;

		internal NintendoSwitchProControllerExtension(IDriver_NintendoSwitchProController P_0)
			: base(new QECeqwQNElOEqkunZifgNbyxNBup(P_0))
		{
		}

		private NintendoSwitchProControllerExtension(NintendoSwitchProControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchProControllerExtension(this);
		}
	}
}
