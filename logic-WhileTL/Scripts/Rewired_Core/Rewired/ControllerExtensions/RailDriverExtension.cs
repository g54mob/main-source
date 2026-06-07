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
				HASpVVHfbqNxqOWsgCqNVQzLcYFw = P_0;
			}
		}

		private awWrOjSzYLpKVknCqbjoGdDqwamX yGdZHAmdUeDYveLTSINOCvUHtMoHA;

		private Joystick ncRBPRILXKISRDXTTSTeRKtkNzpTA => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw == null)
				{
					return false;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw != null)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw.SpeakerEnabled = value;
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new awWrOjSzYLpKVknCqbjoGdDqwamX(P_0))
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
			: base(P_0)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw != null && base.enabled)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw != null && base.enabled)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.HASpVVHfbqNxqOWsgCqNVQzLcYFw.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
		}

		internal void LPEqqRVtBurlVfmUZLbHuUeFxrWN(IControllerExtensionSource P_0)
		{
			yGdZHAmdUeDYveLTSINOCvUHtMoHA = P_0 as awWrOjSzYLpKVknCqbjoGdDqwamX;
		}

		internal Controller.Extension whghpXSUuKbFknTBkNmxaxTkkihX()
		{
			return new RailDriverExtension(this);
		}
	}
}
