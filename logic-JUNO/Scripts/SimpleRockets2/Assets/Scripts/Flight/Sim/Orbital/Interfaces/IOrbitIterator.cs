using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Interfaces
{
	public interface IOrbitIterator
	{
		bool EnforceConsistentStepBase { get; set; }

		double NextEaStep { get; set; }

		IOrbitPoint GetAt(double eccentricAnomaly);

		void Prepare(IOrbit orbit, double startEa, double endEa, double eaStep);

		bool TryGetNext(out IOrbitPoint point);
	}
}
