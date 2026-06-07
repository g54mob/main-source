using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class OpenTrainCrossingsProcess : IProcess, IReusable
	{
		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<TrainCrossingModel> enumerator = simulation.GetModels<TrainCrossingModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TrainCrossingModel current = enumerator.Current;
				if (current.HasPendingSignalOpenRequestTimeElapsed())
				{
					current.CommitPendingSignalOpenRequest();
				}
			}
		}

		public void Reset()
		{
		}
	}
}
