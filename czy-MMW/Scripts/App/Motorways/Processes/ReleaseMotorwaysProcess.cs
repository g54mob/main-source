using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Processes
{
	public class ReleaseMotorwaysProcess : IProcess, IReusable
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ReleaseMotorwaysProcess");

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabase;

		[Dependency]
		private TilemapModel _tilemapModel;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<MotorwayModel> enumerator = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current = enumerator.Current;
				if (current.State != RoadState.None)
				{
					continue;
				}
				int num = current.ConcreteCost - current.ConcreteGivenToReplacement;
				if (num > 0)
				{
					_upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Concrete, num);
				}
				if (current.hasConsumedUpgrade)
				{
					Log.Info("Closing motorway {0}, releasing {1} concrete and one upgrade.", current.Id, num);
					current.hasConsumedUpgrade = false;
					MotorwayModel motorwayModel = FindReplacementMotorway(simulation, current);
					if (motorwayModel != null)
					{
						Log.Info("Gifting upgrade to motorway {0} instead of releasing it.", motorwayModel.Id);
						motorwayModel.hasConsumedUpgrade = true;
					}
					else
					{
						_upgradeDatabase.MothballUpgrade(UpgradeType.Motorway);
						_upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Motorway);
					}
				}
				else
				{
					Log.Info("Closing motorway {0}, releasing {1} concrete and no upgrade.", current.Id, num);
				}
				Diagnostics.Verify(_tilemapModel.RemoveMotorwayModel(current), "Failed to remove motorway {0} from the simulation's tilemap.", current);
				simulation.RemoveModel(current);
			}
		}

		private MotorwayModel FindReplacementMotorway(ISimulation simulation, MotorwayModel oldMotorway)
		{
			int num = -1;
			MotorwayModel motorwayModel = null;
			ModelListEnumerator<MotorwayModel> enumerator = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current = enumerator.Current;
				if (current.State == RoadState.Planned && !current.hasConsumedUpgrade && current.CanSetMotorwayAndNodeState(RoadState.Active))
				{
					int sqrMagnitude = (current.StartCoordinates - oldMotorway.StartCoordinates).sqrMagnitude;
					sqrMagnitude = Mathf.Min(sqrMagnitude, (current.StartCoordinates - oldMotorway.EndCoordinates).sqrMagnitude);
					sqrMagnitude = Mathf.Min(sqrMagnitude, (current.EndCoordinates - oldMotorway.StartCoordinates).sqrMagnitude);
					sqrMagnitude = Mathf.Min(sqrMagnitude, (current.EndCoordinates - oldMotorway.EndCoordinates).sqrMagnitude);
					if (motorwayModel == null || (current.isHighBuildPriority && !motorwayModel.isHighBuildPriority) || sqrMagnitude < num)
					{
						motorwayModel = current;
						num = sqrMagnitude;
					}
				}
			}
			return motorwayModel;
		}
	}
}
