using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class ikOvBoYsIhFCbqYsfUJpYScdgLf : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver RoGyCOLKdQfbMICWzOACeDQIYzWc;

			public ikOvBoYsIhFCbqYsfUJpYScdgLf(IDriver_RailDriver driver)
			{
			}
		}

		private ikOvBoYsIhFCbqYsfUJpYScdgLf ottLIBaLKUdMBBqnPedZdrrIelx;

		private Joystick joystick => null;

		public bool speakerEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base((IControllerExtensionSource)null)
		{
		}

		private RailDriverExtension(RailDriverExtension source)
			: base((IControllerExtensionSource)null)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}
