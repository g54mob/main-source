using Assets.Scripts.Flight.MapView.Orbits;

namespace Assets.Scripts.Flight.MapView.Items
{
	public interface ITargetableItem
	{
		string ClosestEncounterIcon { get; }

		string Name { get; }

		MapOrbitInfo OrbitInfo { get; }

		double GetSphereOfInfluence(MapOrbitInfo other);
	}
}
