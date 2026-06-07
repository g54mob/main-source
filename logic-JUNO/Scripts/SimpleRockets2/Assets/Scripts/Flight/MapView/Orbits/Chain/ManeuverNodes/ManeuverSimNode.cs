using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class ManeuverSimNode : OrbitNode
	{
		public ManeuverSimNode(IOrbit orbit, IPlanetNode parent)
		{
			base.Orbit = orbit;
			base.Parent = parent;
		}
	}
}
