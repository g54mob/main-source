using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public struct ClosestEncounterSearchOptions
	{
		public double BinarySearchTargetDistance { get; set; }

		public string DebugDescription { get; set; }

		public double EndNu { get; set; }

		public double LocalMinimaModifier { get; set; }

		public IMapOptions MapOptions { get; }

		public IOrbitNode NodeA { get; }

		public IOrbitNode NodeB { get; }

		public ClosestEncounterSearchSpace SearchSpace { get; set; }

		public double StartNu { get; set; }

		public double TimeToStartSearch { get; set; }

		public ClosestEncounterSearchOptions(IIocContainer ioc, IOrbitNode nodeA, IOrbitNode nodeB)
		{
			MapOptions = ioc.Resolve<IMapOptions>();
			NodeA = nodeA;
			NodeB = nodeB;
			StartNu = nodeA.Orbit.TrueAnomaly;
			EndNu = ((nodeA.Orbit.Eccentricity > 1.0) ? nodeA.Orbit.TrueAnomalyAtApoapsis : nodeA.Orbit.TrueAnomaly);
			TimeToStartSearch = nodeA.Orbit.Time;
			SearchSpace = ((!MapOptions.Targeting.SearchWholeOrbit) ? ClosestEncounterSearchSpace.PossibleCaptureRanges : ClosestEncounterSearchSpace.WholeOrbit);
			LocalMinimaModifier = MapOptions.Targeting.SoiEntryLocalMinimaModifier;
			BinarySearchTargetDistance = Mathd.Max(nodeB.SphereOfInfluence / 10.0, 1.0);
			DebugDescription = null;
		}
	}
}
