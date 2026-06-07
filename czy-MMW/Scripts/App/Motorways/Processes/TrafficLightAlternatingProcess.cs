using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class TrafficLightAlternatingProcess : IProcess, IReusable
	{
		[Dependency]
		private SimulationConstantsData _constants;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<TrafficLightModel> enumerator = simulation.GetModels<TrafficLightModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TrafficLightModel current = enumerator.Current;
				current.durationOnCurrentPair += timestep;
				if (current.requiresPairCalculation)
				{
					TileDirectionBitfield activePair = current.ActivePair;
					current.CalculatePairs();
					if (!current.SetActivePair(activePair))
					{
						current.RotateLights();
						current.durationOnCurrentPair = Fix64.Zero;
					}
				}
				if (current.amberLightsOn && current.durationOnCurrentPair > _constants.amberDelay)
				{
					current.RotateLights();
					current.durationOnCurrentPair = Fix64.Zero;
				}
				else if (!current.amberLightsOn && (current.durationOnCurrentPair > _constants.changeDelay || (current.isInOvertime && current.durationOnCurrentPair > _constants.overtimeChangeDelay)))
				{
					if (current.RequiresRotation())
					{
						current.isInOvertime = false;
						current.ChangeGreenToAmber();
					}
					else
					{
						current.isInOvertime = true;
					}
					current.durationOnCurrentPair = Fix64.Zero;
				}
			}
		}
	}
}
