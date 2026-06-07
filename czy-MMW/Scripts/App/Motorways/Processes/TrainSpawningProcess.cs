using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class TrainSpawningProcess : IProcess, IReusable
	{
		private const int TrainsPerLine = 1;

		[Dependency]
		private SimulationConstantsData _constants;

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<TrainLineModel> enumerator = simulation.GetModels<TrainLineModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TrainLineModel current = enumerator.Current;
				List<RailTileModel> trainSpawnTiles = current.TrainSpawnTiles;
				if (current.TrainCount >= trainSpawnTiles.Count || current.TrainCount >= 1)
				{
					continue;
				}
				foreach (RailTileModel item in trainSpawnTiles)
				{
					TrainModel trainModel = simulation.Scope.Get<TrainModel>();
					trainModel.state = TrainModel.BehaviorState.Stopped;
					trainModel.CurrentFrame.speed = Fix64.Zero;
					trainModel.NextFrame.speed = Fix64.Zero;
					trainModel.CurrentFrame.tile = item;
					trainModel.CurrentFrame.distanceAlongTrack = Fix64.Zero;
					trainModel.NextFrame.tile = item;
					trainModel.NextFrame.distanceAlongTrack = trainModel.CurrentFrame.distanceAlongTrack;
					current.AddTrain(trainModel);
					simulation.AddModel(trainModel);
				}
			}
		}

		public void Reset()
		{
		}
	}
}
