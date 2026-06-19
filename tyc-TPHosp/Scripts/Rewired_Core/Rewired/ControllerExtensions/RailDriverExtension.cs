using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class GfALStiCOqmmwKmoImcdgcJCeCT : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver dyKYGRpafBLeBoCSSijQzhOhFYt;

			public GfALStiCOqmmwKmoImcdgcJCeCT(IDriver_RailDriver driver)
			{
				dyKYGRpafBLeBoCSSijQzhOhFYt = driver;
			}
		}

		private GfALStiCOqmmwKmoImcdgcJCeCT UdjCSEOPIRsTIjnUgCiPBbbzKWS;

		private Joystick joystick => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt == null)
				{
					return false;
				}
				return UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt != null)
				{
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt.SpeakerEnabled = value;
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base(new GfALStiCOqmmwKmoImcdgcJCeCT(driver))
		{
		}

		private RailDriverExtension(RailDriverExtension source)
			: base(source)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt != null && base.enabled)
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt != null && base.enabled)
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.dyKYGRpafBLeBoCSSijQzhOhFYt.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
		}

		internal void tmEnLTdHsRVxaDmExqmMETendBa(IControllerExtensionSource P_0)
		{
			UdjCSEOPIRsTIjnUgCiPBbbzKWS = P_0 as GfALStiCOqmmwKmoImcdgcJCeCT;
		}

		internal Controller.Extension AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return new RailDriverExtension(this);
		}
	}
}
