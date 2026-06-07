using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class IntersectionEvaluatingProcess : IProcess, IReusable
	{
		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<RoadChunkModel> enumerator = simulation.GetModels<RoadChunkModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.SortInboundVehicles();
			}
		}
	}
}
