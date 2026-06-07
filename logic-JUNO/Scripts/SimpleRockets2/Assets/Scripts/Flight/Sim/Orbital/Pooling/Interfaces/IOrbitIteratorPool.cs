using Assets.Scripts.Flight.Sim.Orbital.Interfaces;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces
{
	public interface IOrbitIteratorPool
	{
		IOrbitIterator GetIterator(IOrbit orbit, double startEa, double endEa, double eaStep);

		IOrbitIterator GetIterator(IOrbit orbit);

		IOrbitIterator GetIteratorFromNu(IOrbit orbit, double startNu, double endNu, double eaStep);

		void ReturnAll();
	}
}
