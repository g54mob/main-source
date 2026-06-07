using ModApi.GameLoop;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public interface ILandingLeg
	{
		void DesignerUpdate(in DesignerFrameData frame);

		void FlightStart(in FlightFrameData frame);

		void FlightUpdate(in FlightFrameData frame);

		void PrepareForPartIcon();

		void SetStartDeployed(bool startDeployed);

		void UpdateScale();
	}
}
