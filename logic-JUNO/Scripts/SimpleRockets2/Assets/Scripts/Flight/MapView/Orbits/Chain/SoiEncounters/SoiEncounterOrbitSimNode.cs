using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters
{
	public class SoiEncounterOrbitSimNode : OrbitNode
	{
		public SoiEncounterOrbitSimNode(IOrbit orbit, IPlanetNode parent)
		{
			base.Parent = parent;
			base.Orbit = orbit;
		}

		public SoiEncounterOrbitSimNode(double time, double e, double a, double w, double nu, double inclination, double ra, bool prograde, PlanetNode parent)
		{
			base.Parent = parent;
			base.Orbit = new Orbit(time, e, a, w, nu, inclination, ra, parent.PlanetData.Mass, prograde: true);
		}
	}
}
