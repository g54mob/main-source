using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class AlignDrivewayEdit : TileEdit
	{
		[Serialize(true, null)]
		public Vector2Int HouseCoordinates { get; private set; }

		[Serialize(true, null)]
		public TileDirection PreviousDrivewayDirection { get; private set; }

		[Serialize(true, null)]
		public TileDirection NewDrivewayDirection { get; private set; }

		public Vector2Int PreviousDestinationCoordinates => TileUtilities.GetAdjacentCoordinates(HouseCoordinates, PreviousDrivewayDirection);

		public TileDirection PreviousDestinationToHouseDirection => TileUtilities.GetOppositeDirection(PreviousDrivewayDirection);

		public Vector2Int NewDestinationCoordinates => TileUtilities.GetAdjacentCoordinates(HouseCoordinates, NewDrivewayDirection);

		public TileDirection NewDestinationToHouseDirection => TileUtilities.GetOppositeDirection(NewDrivewayDirection);

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetOrCreateTile(HouseCoordinates);
			yield return tilemap.GetOrCreateTile(NewDestinationCoordinates);
			if (PreviousDrivewayDirection != TileDirection.None)
			{
				Tile tile = tilemap.GetTile(PreviousDestinationCoordinates);
				if (tile != null)
				{
					yield return tile;
				}
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (tile.Coordinates == HouseCoordinates)
			{
				if (PreviousDrivewayDirection != TileDirection.None)
				{
					tile.SetNodeState(new RoadTileNode(PreviousDrivewayDirection, RoadType.Driveway), RoadState.Mothballed);
				}
				if (NewDrivewayDirection != TileDirection.None)
				{
					tile.SetNodeState(new RoadTileNode(NewDrivewayDirection, RoadType.Driveway), RoadState.Pending);
				}
			}
			else if (tile.Coordinates == NewDestinationCoordinates)
			{
				if (Roundabout.IsTileCenterOfRoundabout(tile))
				{
					return true;
				}
				tile.SetNodeState(new RoadTileNode(NewDestinationToHouseDirection), RoadState.Pending);
			}
			else if (PreviousDrivewayDirection != TileDirection.None && tile.Coordinates == PreviousDestinationCoordinates)
			{
				tile.SetNodeState(new RoadTileNode(PreviousDestinationToHouseDirection), RoadState.Mothballed);
			}
			return true;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			return true;
		}

		public override void Reset()
		{
			base.Reset();
			HouseCoordinates = default(Vector2Int);
			PreviousDrivewayDirection = TileDirection.North;
			NewDrivewayDirection = TileDirection.North;
		}

		public override string ToString()
		{
			return $"[AlignDrivewayEdit HouseCoordinates={HouseCoordinates}, PreviousDrivewayDirection={PreviousDrivewayDirection}, NewDrivewayDirection={NewDrivewayDirection}]";
		}

		public static AlignDrivewayEdit Create(IScope scope, ITilemap tilemap, Vector2Int originCoordinates, TileDirection direction)
		{
			Tile tile = tilemap.GetTile(originCoordinates);
			TileDirection drivewayDirection = tile.DrivewayDirection;
			if (direction != drivewayDirection)
			{
				AlignDrivewayEdit alignDrivewayEdit = scope.Get<AlignDrivewayEdit>();
				alignDrivewayEdit.HouseCoordinates = tile.Coordinates;
				alignDrivewayEdit.PreviousDrivewayDirection = drivewayDirection;
				alignDrivewayEdit.NewDrivewayDirection = direction;
				return alignDrivewayEdit;
			}
			return null;
		}
	}
}
