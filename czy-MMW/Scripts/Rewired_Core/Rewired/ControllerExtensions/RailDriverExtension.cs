using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class EjteLtFOkmUymUkyOMEvFpRJHrQNB : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver xBFzISdUzGpcWsiFcfWMYwyLtqeH;

			public EjteLtFOkmUymUkyOMEvFpRJHrQNB(IDriver_RailDriver P_0)
			{
				xBFzISdUzGpcWsiFcfWMYwyLtqeH = P_0;
			}
		}

		private EjteLtFOkmUymUkyOMEvFpRJHrQNB iDMfzOJovLoGaGZuEStevPyuiUmB;

		private Joystick JqrCpPFHCOWPtsJgGEAdFZTaRlVZB => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH == null)
				{
					return false;
				}
				return iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH != null)
				{
					iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH.SpeakerEnabled = value;
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new EjteLtFOkmUymUkyOMEvFpRJHrQNB(P_0))
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
			else if (iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH != null && base.enabled)
			{
				iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH != null && base.enabled)
			{
				iDMfzOJovLoGaGZuEStevPyuiUmB.xBFzISdUzGpcWsiFcfWMYwyLtqeH.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal void hscwUqPwztmxqBmByUnUTgaubfrDA(UpdateLoopType P_0)
		{
		}

		internal void PJIyflxTKKFvifwDMufCmlCMchvE(IControllerExtensionSource P_0)
		{
			iDMfzOJovLoGaGZuEStevPyuiUmB = P_0 as EjteLtFOkmUymUkyOMEvFpRJHrQNB;
		}

		internal Controller.Extension bceaxQgsFvitULtsohuwvODKzuuNA()
		{
			return new RailDriverExtension(this);
		}
	}
}
