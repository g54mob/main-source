using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class awWrOjSzYLpKVknCqbjoGdDqwamX : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver HASpVVHfbqNxqOWsgCqNVQzLcYFw;

			public awWrOjSzYLpKVknCqbjoGdDqwamX(IDriver_RailDriver P_0)
			{
			}
		}

		private awWrOjSzYLpKVknCqbjoGdDqwamX yGdZHAmdUeDYveLTSINOCvUHtMoHA;

		private Joystick ncRBPRILXKISRDXTTSTeRKtkNzpTA => null;

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

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
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
