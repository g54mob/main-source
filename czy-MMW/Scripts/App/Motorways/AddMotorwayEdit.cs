using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways
{
	public class AddMotorwayEdit : TileEdit
	{
		private int newMotorwayId;

		private int replacedMotorwayId;

		private int motorwayNumber;

		private Vector2Int startCoordinates;

		private TileDirection startDirection;

		private Vector2Int endCoordinates;

		private TileDirection endDirection;

		public int ConcreteCostForNewMotorway => _behaviour.GetConcreteCostForMotorway(startCoordinates, endCoordinates);

		public override bool ApplyToAffectedTile(Tile tile)
		{
			bool flag = false;
			bool flag2 = true;
			Fix64 permanence = Fix64.Zero;
			if (replacedMotorwayId != -1)
			{
				Motorway motorway = tile.Tilemap.GetMotorway(replacedMotorwayId);
				if (Diagnostics.Verify(motorway != null, "Unable to find replaced motorway id {0}", motorway))
				{
					if (tile.Coordinates == motorway.StartCoordinates)
					{
						flag = true;
						flag2 = flag2 && Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(motorway.StartDirection, RoadType.Motorway, replacedMotorwayId), RoadState.Mothballed), "Failed to mothball replaced motorway's ({0}) start node.", replacedMotorwayId);
					}
					if (tile.Coordinates == motorway.EndCoordinates)
					{
						flag = true;
						flag2 = flag2 && Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(motorway.EndDirection, RoadType.Motorway, replacedMotorwayId), RoadState.Mothballed), "Failed to mothball replaced motorway's ({0}) end node.", replacedMotorwayId);
					}
					permanence = motorway.PermanenceProgress;
				}
			}
			if (tile.Coordinates == startCoordinates)
			{
				flag = true;
				flag2 = flag2 && Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(startDirection, RoadType.Motorway, newMotorwayId), RoadState.Planned), "Failed to plan a new motorway's start node.");
				tile.SetNodePermanence(startDirection, permanence);
			}
			if (tile.Coordinates == endCoordinates)
			{
				flag = true;
				flag2 = flag2 && Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(endDirection, RoadType.Motorway, newMotorwayId), RoadState.Planned), "Failed to plan a new motorway's end node.");
				tile.SetNodePermanence(endDirection, permanence);
			}
			if (flag && flag2 && tile.UnbuiltMotorwayId == newMotorwayId)
			{
				tile.UnbuiltMotorwayId = -1;
				tile.UnbuiltMotorwayNumber = 0;
			}
			return flag && flag2;
		}

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetOrCreateTile(startCoordinates);
			yield return tilemap.GetOrCreateTile(endCoordinates);
			if (replacedMotorwayId == -1)
			{
				yield break;
			}
			Motorway replacedMotorway = tilemap.GetMotorway(replacedMotorwayId);
			if (Diagnostics.Verify(replacedMotorway != null, "Unable to find replaced motorway id {0}", replacedMotorway))
			{
				if (replacedMotorway.StartCoordinates != startCoordinates && replacedMotorway.StartCoordinates != endCoordinates)
				{
					yield return tilemap.GetTile(replacedMotorway.StartCoordinates);
				}
				if (replacedMotorway.EndCoordinates != startCoordinates && replacedMotorway.EndCoordinates != endCoordinates)
				{
					yield return tilemap.GetTile(replacedMotorway.EndCoordinates);
				}
			}
		}

		public override bool ApplyToAffectedMotorway(Motorway motorway)
		{
			if (motorway.Id == newMotorwayId)
			{
				motorway.SetState(RoadState.Planned);
				motorway.StartCoordinates = startCoordinates;
				motorway.StartDirection = startDirection;
				motorway.EndCoordinates = endCoordinates;
				motorway.EndDirection = endDirection;
				motorway.ConcreteCost = ConcreteCostForNewMotorway;
				if (replacedMotorwayId != -1)
				{
					Motorway motorway2 = motorway.Tilemap.GetMotorway(replacedMotorwayId);
					if (Diagnostics.Verify(motorway2 != null))
					{
						motorway.SetPermanence(motorway2.PermanenceProgress);
					}
				}
				return true;
			}
			if (motorway.Id == replacedMotorwayId)
			{
				motorway.SetState(RoadState.Mothballed);
				int concreteGivenToReplacement = Mathf.Min(ConcreteCostForNewMotorway, motorway.ConcreteCost);
				motorway.ConcreteGivenToReplacement = concreteGivenToReplacement;
				return true;
			}
			return false;
		}

		public override IEnumerable<Motorway> GetAffectedMotorways(ITilemap tilemap)
		{
			Motorway motorway = tilemap.GetMotorway(newMotorwayId);
			if (motorway == null)
			{
				motorway = tilemap.CreateMotorway(newMotorwayId, motorwayNumber, replacedMotorwayId);
			}
			if (Diagnostics.Verify(motorway != null, "Unable to find motorway from new motorway ID {0}", newMotorwayId))
			{
				yield return motorway;
			}
			if (replacedMotorwayId != -1)
			{
				Motorway motorway2 = tilemap.GetMotorway(replacedMotorwayId);
				if (Diagnostics.Verify(motorway2 != null, "Unable to find motorway from replaced motorway ID {0}", replacedMotorwayId))
				{
					yield return motorway2;
				}
			}
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			bool flag = true;
			Motorway motorway = null;
			if (replacedMotorwayId != -1)
			{
				motorway = tilemap.GetMotorway(replacedMotorwayId);
			}
			int concreteCostForNewMotorway = ConcreteCostForNewMotorway;
			int num = 0;
			if (motorway != null)
			{
				num = motorway.ConcreteCost;
			}
			if (concreteCostForNewMotorway > num)
			{
				flag = flag && upgradeDatabase.ConsumeUpgrade(UpgradeType.Concrete, concreteCostForNewMotorway - num);
			}
			else if (concreteCostForNewMotorway < num)
			{
				flag = flag && upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, num - concreteCostForNewMotorway);
			}
			return flag;
		}

		public override void ApplyToSimulation(ISimulation simulation)
		{
			if (replacedMotorwayId == -1)
			{
				simulation.GetModel<TilemapModel>().GetMotorwayModel(newMotorwayId).hasConsumedUpgrade = true;
			}
		}

		public override void Reset()
		{
			base.Reset();
			newMotorwayId = 0;
			replacedMotorwayId = 0;
			motorwayNumber = 0;
			startCoordinates = default(Vector2Int);
			startDirection = TileDirection.None;
			endCoordinates = default(Vector2Int);
			endDirection = TileDirection.None;
		}

		public static AddMotorwayEdit Create(IScope scope, int newMotorwayId, int motorwayNumber, Vector2Int startCoordinates, TileDirection startDirection, Vector2Int endCoordinates, TileDirection endDirection, int replacedMotorwayId)
		{
			AddMotorwayEdit addMotorwayEdit = scope.Get<AddMotorwayEdit>();
			addMotorwayEdit.newMotorwayId = newMotorwayId;
			addMotorwayEdit.startCoordinates = startCoordinates;
			addMotorwayEdit.startDirection = startDirection;
			addMotorwayEdit.endCoordinates = endCoordinates;
			addMotorwayEdit.endDirection = endDirection;
			addMotorwayEdit.replacedMotorwayId = replacedMotorwayId;
			addMotorwayEdit.motorwayNumber = motorwayNumber;
			return addMotorwayEdit;
		}
	}
}
