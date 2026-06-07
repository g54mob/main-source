using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class BoatSpawningProcess : IProcess, IReusable
	{
		private const int BoatsPerLine = 1;

		[Dependency]
		private SimulationConstantsData _constants;

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<BoatPathModel> enumerator = simulation.GetModels<BoatPathModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				BoatPathModel current = enumerator.Current;
				List<BoatPathTileModel> boatSpawnTiles = current.BoatSpawnTiles;
				while (current.BoatCount < boatSpawnTiles.Count && current.BoatCount < 1)
				{
					BoatModel boatModel = simulation.Scope.Get<BoatModel>();
					boatModel.state = BoatModel.BehaviorState.Sailing;
					boatModel.CurrentFrame.speed = Fix64.Zero;
					boatModel.NextFrame.speed = Fix64.Zero;
					boatModel.CurrentFrame.tile = boatSpawnTiles[current.BoatCount];
					boatModel.CurrentFrame.DistanceAlongPathSegment = Fix64.Zero;
					boatModel.NextFrame.tile = boatSpawnTiles[current.BoatCount];
					boatModel.NextFrame.DistanceAlongPathSegment = boatModel.CurrentFrame.DistanceAlongPathSegment;
					current.AddBoat(boatModel);
					simulation.AddModel(boatModel);
				}
			}
		}

		public void Reset()
		{
		}
	}
}
