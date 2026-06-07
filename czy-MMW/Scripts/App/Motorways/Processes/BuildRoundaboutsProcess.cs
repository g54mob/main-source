using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class BuildRoundaboutsProcess : IProcess, IReusable
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("BuildRoundaboutsProcess");

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<RoundaboutModel> enumerator = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				RoundaboutModel current = enumerator.Current;
				if (current.State == RoadState.Planned && current.Activate())
				{
					Log.Info("Activated roundabout.");
				}
			}
		}
	}
}
