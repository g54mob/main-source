using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegScript : PartModifierScript<LandingLegData>, IDesignerUpdate, IGameLoopItem, IFlightStart, IFlightUpdate
	{
		private ILandingLeg _landingLeg;

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			if (this != null)
			{
				_landingLeg.DesignerUpdate(in frame);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_landingLeg.FlightStart(in frame);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_landingLeg.FlightUpdate(in frame);
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			if (base.Data.LandingLegType == 0)
			{
				_landingLeg = new LandingLegOriginal(this);
			}
			else if (base.Data.LandingLegType == 1)
			{
				_landingLeg = new LandingLegNew(this);
			}
			else if (base.Data.LandingLegType == 2)
			{
				_landingLeg = new LandingLegCowl(this);
			}
			else if (base.Data.LandingLegType == 3)
			{
				_landingLeg = new LandingLegBasic(this);
			}
		}

		public override void PrepareForPartIcon()
		{
			base.PrepareForPartIcon();
			_landingLeg.PrepareForPartIcon();
		}

		public void SetStartDeployed(bool startDeployed)
		{
			_landingLeg.SetStartDeployed(startDeployed);
		}

		public void UpdateScale()
		{
			_landingLeg.UpdateScale();
		}
	}
}
