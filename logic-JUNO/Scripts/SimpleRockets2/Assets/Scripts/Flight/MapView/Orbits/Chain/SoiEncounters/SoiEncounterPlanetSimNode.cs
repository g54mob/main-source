using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters
{
	public class SoiEncounterPlanetSimNode : PlanetNode
	{
		public IPlanetNode ReferencePlanet { get; private set; }

		public SoiEncounterPlanetSimNode(IPlanetData planetData, IOrbit orbit, IPlanetNode parent, IPlanetNode referencePlanet)
			: base(null, planetData, orbit)
		{
			base.Parent = parent;
			ReferencePlanet = referencePlanet;
			if (Debug.isDebugBuild)
			{
				_ = base.Orbit;
				_ = referencePlanet.Orbit;
			}
		}
	}
}
