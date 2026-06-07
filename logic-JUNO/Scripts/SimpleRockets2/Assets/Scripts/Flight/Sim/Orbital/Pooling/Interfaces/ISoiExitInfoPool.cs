using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces
{
	public interface ISoiExitInfoPool
	{
		OrbitAnalyser.SoiExitInfo Get(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint escapePointA, IOrbitPoint escapePointB);

		void ReturnAll();
	}
}
