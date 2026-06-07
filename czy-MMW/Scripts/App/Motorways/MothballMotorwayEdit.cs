using System.Collections.Generic;
using Factory;

namespace Motorways
{
	public class MothballMotorwayEdit : TileEdit
	{
		private int _motorwayId;

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			Motorway motorway = tilemap.GetMotorway(_motorwayId);
			yield return tilemap.GetTile(motorway.StartCoordinates);
			yield return tilemap.GetTile(motorway.EndCoordinates);
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			Motorway motorway = tile.Tilemap.GetMotorway(_motorwayId);
			if (tile.Coordinates == motorway.StartCoordinates)
			{
				return tile.SetNodeState(new RoadTileNode(motorway.StartDirection, RoadType.Motorway, _motorwayId), RoadState.Mothballed);
			}
			if (tile.Coordinates == motorway.EndCoordinates)
			{
				return tile.SetNodeState(new RoadTileNode(motorway.EndDirection, RoadType.Motorway, _motorwayId), RoadState.Mothballed);
			}
			return false;
		}

		public override IEnumerable<Motorway> GetAffectedMotorways(ITilemap tilemap)
		{
			Motorway motorway = tilemap.GetMotorway(_motorwayId);
			if (Diagnostics.Verify(motorway != null, "Unable to find motorway from ID {0}", _motorwayId))
			{
				yield return motorway;
			}
		}

		public override bool ApplyToAffectedMotorway(Motorway motorway)
		{
			if (motorway.Id == _motorwayId)
			{
				motorway.SetState(RoadState.Mothballed);
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			return true;
		}

		public override void Reset()
		{
			base.Reset();
			_motorwayId = 0;
		}

		public static MothballMotorwayEdit Create(IScope scope, int motorwayId)
		{
			MothballMotorwayEdit mothballMotorwayEdit = scope.Get<MothballMotorwayEdit>();
			mothballMotorwayEdit._motorwayId = motorwayId;
			return mothballMotorwayEdit;
		}
	}
}
