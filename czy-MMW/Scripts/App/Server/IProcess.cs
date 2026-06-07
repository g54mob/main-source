using Factory;
using Factory.Pools;
using FixMath;

namespace Server
{
	[Serializable(1)]
	public interface IProcess : IReusable
	{
		void Step(ISimulation simulation, Fix64 timestep);
	}
}
