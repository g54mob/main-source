using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class BuildMotorwaysProcess : IProcess, IReusable
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("BuildMotorwaysProcess");

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabase;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<MotorwayModel> enumerator = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current = enumerator.Current;
				if (current.isHighBuildPriority && Diagnostics.Verify(TryBuildMotorway(current), "Unable to build high-priority motorway! Things are going to get ugly."))
				{
					current.isHighBuildPriority = false;
				}
			}
			enumerator = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current2 = enumerator.Current;
				if (!current2.isHighBuildPriority)
				{
					TryBuildMotorway(current2);
				}
			}
		}

		private bool TryBuildMotorway(MotorwayModel motorway)
		{
			if (motorway.State != RoadState.Planned)
			{
				return false;
			}
			if (motorway.CanBeReplacedByActivatingMothballedMotorway(out var mothballedReplacement))
			{
				Log.Info("Replacing planned motorway {0} by re-activating mothballed motorway {1}", motorway.Id, mothballedReplacement.Id);
				motorway.SetState(RoadState.None);
				motorway.ConcreteGivenToReplacement = motorway.ConcreteCost;
				mothballedReplacement.SetState(RoadState.Active);
				return Diagnostics.Verify(motorway.StartTile.Tile.SetNodeState(new RoadTileNode(motorway.StartDirection, RoadType.Motorway, motorway.Id), RoadState.None) & motorway.EndTile.Tile.SetNodeState(new RoadTileNode(motorway.EndDirection, RoadType.Motorway, motorway.Id), RoadState.None) & mothballedReplacement.StartTile.Tile.SetNodeState(new RoadTileNode(mothballedReplacement.StartDirection, RoadType.Motorway, mothballedReplacement.Id), RoadState.Active) & mothballedReplacement.EndTile.Tile.SetNodeState(new RoadTileNode(mothballedReplacement.EndDirection, RoadType.Motorway, mothballedReplacement.Id), RoadState.Active), "Failed to reactivate mothballed motorway and dispose of planned one!");
			}
			if (!motorway.CanSetMotorwayAndNodeState(RoadState.Active))
			{
				return false;
			}
			if (!motorway.hasConsumedUpgrade)
			{
				if (!_upgradeDatabase.ConsumeUpgrade(UpgradeType.Motorway))
				{
					Log.Info("Unable to activate motorway {0}, no motorway asset is available.", motorway.Id);
					return true;
				}
				Log.Info("Consumed upgrade to activate motorway {0}.", motorway.Id);
				motorway.hasConsumedUpgrade = true;
			}
			else
			{
				Log.Info("Activating pre-paid motorway {0}.", motorway.Id);
			}
			motorway.SetMotorwayAndNodeState(RoadState.Active);
			return true;
		}
	}
}
