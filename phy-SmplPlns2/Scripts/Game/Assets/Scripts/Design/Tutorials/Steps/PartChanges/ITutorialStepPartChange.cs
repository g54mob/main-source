using Assets.Scripts.Craft;

namespace Assets.Scripts.Design.Tutorials.Steps.PartChanges
{
	public interface ITutorialStepPartChange
	{
		void Apply(AircraftData craft);

		void Revert(AircraftData craft);
	}
}
