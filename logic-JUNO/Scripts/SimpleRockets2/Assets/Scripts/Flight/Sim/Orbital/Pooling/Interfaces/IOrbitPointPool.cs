using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces
{
	public interface IOrbitPointPool
	{
		IOrbitPoint Get();

		void ReturnAll();
	}
}
