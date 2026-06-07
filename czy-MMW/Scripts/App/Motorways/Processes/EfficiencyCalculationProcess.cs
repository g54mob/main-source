using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using Unity.Profiling;

namespace Motorways.Processes
{
	public class EfficiencyCalculationProcess : IProcess, IReusable
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("EfficiencyCalculationProcess");

		private static readonly ProfilerMarker Profiler_Step = new ProfilerMarker(ProfilerUtility.CategoryProcess, "EfficiencyCalculationProcess.Step");

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			ModelListEnumerator<ScoreModel> enumerator = simulation.GetModels<ScoreModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ScoreModel current = enumerator.Current;
				if (current.HasAchievedCurrentMilestone())
				{
					current.ProgressToNextMilestone();
				}
				current.DeductEfficiencyScore(deltaTime);
			}
		}
	}
}
