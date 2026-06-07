using System.Collections.Generic;
using Factory;
using Motorways.Models;
using UnityEngine;

namespace Motorways
{
	public class ClearTileEdit : TileEdit
	{
		private TileDirectionBitfield _roadDirectionsToMothball;

		private int _concreteToMothball;

		private int _concreteToRelease;

		private Tile.TileChangePermissions _changePermissions;

		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			int x = -1;
			while (x <= 1)
			{
				int num;
				for (int y = -1; y <= 1; y = num)
				{
					Tile tile = tilemap.GetTile(Coordinates + new Vector2Int(x, y));
					if (tile != null && tile.ContentType != TileContentType.House && tile.ContentType != TileContentType.Destination && tile.ContentType != TileContentType.Carpark)
					{
						yield return tile;
					}
					num = y + 1;
				}
				num = x + 1;
				x = num;
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (tile.Coordinates.Equals(Coordinates))
			{
				bool flag = true;
				TileDirectionBitfield.Enumerator enumerator = _roadDirectionsToMothball.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					flag = Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(current), RoadState.Mothballed, _changePermissions), "Failed to mothball two-lane road from {0} headed {1}.", tile, current) && flag;
				}
				return flag;
			}
			TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(tile.Coordinates, Coordinates);
			if (Diagnostics.Verify(directionBetweenAdjacentCoordinates != TileDirection.None, "ClearTileEdit applied between non-adjacent tiles {0} and {1}.", tile.Coordinates, Coordinates))
			{
				if ((tile.GetTwoLaneRoadStateInDirection(directionBetweenAdjacentCoordinates) & RoadState.ActiveOrPending) != RoadState.None)
				{
					tile.SetNodeState(new RoadTileNode(directionBetweenAdjacentCoordinates), RoadState.Mothballed, _changePermissions);
				}
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			if (_concreteToMothball > 0)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, _concreteToMothball);
				if (_concreteToRelease > 0)
				{
					upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Concrete, _concreteToRelease);
				}
			}
			return true;
		}

		private static TileDirectionBitfield GetRoadDirectionsToMothball(Tile tileToClear, ITilemap tilemap, GameBehaviourModel behaviour, Tile.TileChangePermissions changePermissions, out int mothballConcreteCount, out int releaseConcreteCount)
		{
			TileDirectionBitfield result = default(TileDirectionBitfield);
			mothballConcreteCount = 0;
			releaseConcreteCount = 0;
			if (tileToClear.ContentType == TileContentType.House || tileToClear.ContentType == TileContentType.Destination || tileToClear.ContentType == TileContentType.Carpark)
			{
				return result;
			}
			if (tileToClear.IsCenterOfRoundabout && tileToClear.IsRoundaboutPermanent)
			{
				TileDirection[] directions = TileUtilities.Directions;
				foreach (TileDirection direction in directions)
				{
					Tile tile = tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(tileToClear.Coordinates, direction));
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(direction);
					if (tile != null && tile.ContentType != TileContentType.House && tile.ContentType != TileContentType.Destination && tile.ContentType != TileContentType.Carpark && tile.CanSetNodeState(new RoadTileNode(oppositeDirection), RoadState.Mothballed, changePermissions) && tile.HasTwoLaneRoadInDirection(oppositeDirection, RoadState.ActiveOrPending))
					{
						int concreteCostForConnection = behaviour.GetConcreteCostForConnection(tile.Coordinates, tile.ContentType, tileToClear.Coordinates, tileToClear?.ContentType ?? TileContentType.None);
						mothballConcreteCount += concreteCostForConnection;
						if (tileToClear.HasTwoLaneRoadInDirection(oppositeDirection, RoadState.Pending))
						{
							releaseConcreteCount += concreteCostForConnection;
						}
					}
				}
				return result;
			}
			TileDirectionBitfield.Enumerator enumerator = tileToClear.GetTwoLaneRoads(RoadState.ActiveOrPending).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(tileToClear.Coordinates, current);
				Tile tile2 = tileToClear.Tilemap.GetTile(adjacentCoordinates);
				if ((tile2 == null || (tile2.ContentType != TileContentType.House && tile2.ContentType != TileContentType.Destination && tile2.ContentType != TileContentType.Carpark)) && tileToClear.CanSetNodeState(new RoadTileNode(current), RoadState.Mothballed, changePermissions))
				{
					int concreteCostForConnection2 = behaviour.GetConcreteCostForConnection(tileToClear.Coordinates, tileToClear.ContentType, adjacentCoordinates, tile2?.ContentType ?? TileContentType.None);
					mothballConcreteCount += concreteCostForConnection2;
					if (tileToClear.HasTwoLaneRoadInDirection(current, RoadState.Pending))
					{
						releaseConcreteCount += concreteCostForConnection2;
					}
					result[current] = true;
				}
			}
			return result;
		}

		public override void Reset()
		{
			base.Reset();
			Coordinates = default(Vector2Int);
			_roadDirectionsToMothball = TileDirectionBitfield.None;
			_concreteToMothball = 0;
			_concreteToRelease = 0;
			_changePermissions = Tile.TileChangePermissions.Full;
		}

		public static ClearTileEdit Create(IScope scope, Vector2Int coordinates, ITilemap tilemap, Tile.TileChangePermissions changePermissions = Tile.TileChangePermissions.Full)
		{
			Tile tile = tilemap.GetTile(coordinates);
			ClearTileEdit clearTileEdit = scope.Get<ClearTileEdit>();
			clearTileEdit.Coordinates = coordinates;
			clearTileEdit._changePermissions = changePermissions;
			clearTileEdit._roadDirectionsToMothball = GetRoadDirectionsToMothball(tile, tilemap, scope.Get<GameBehaviourModel>(), changePermissions, out clearTileEdit._concreteToMothball, out clearTileEdit._concreteToRelease);
			return clearTileEdit;
		}
	}
}
