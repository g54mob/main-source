using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces
{
	public interface ISoiEnterInfoPool
	{
		OrbitAnalyser.SoiEnterInfo Get(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint pointA, IOrbitPoint pointB);

		void ReturnAll();
	}
}
