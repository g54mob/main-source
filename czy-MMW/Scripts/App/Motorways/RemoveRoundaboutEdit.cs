using System.Collections.Generic;
using Factory;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways
{
	public class RemoveRoundaboutEdit : TileEdit
	{
		[Serialize(true, null)]
		private readonly Dictionary<Vector2Int, TileDirection> _tileCoordinatesToMothball = new Dictionary<Vector2Int, TileDirection>();

		[Serialize(true, null)]
		private Vector2Int _centerCoordinates;

		[Serialize(true, null)]
		private TileDirectionBitfield _centerTileNodeDirectionsToRebuild;

		[Serialize(true, null)]
		private TileDirectionBitfield _centreTileNodeDirectionsToMothball;

		[Serialize(true, null)]
		private readonly List<AdjacentTileConnection> _connectionsToRestore = new List<AdjacentTileConnection>();

		private bool _isRemovingPlannedRoundabout;

		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		public override void Reset()
		{
			base.Reset();
			Coordinates = default(Vector2Int);
			_tileCoordinatesToMothball.Clear();
			_centerCoordinates = default(Vector2Int);
			_centerTileNodeDirectionsToRebuild = default(TileDirectionBitfield);
			_centreTileNodeDirectionsToMothball = default(TileDirectionBitfield);
			_isRemovingPlannedRoundabout = false;
			_connectionsToRestore.Clear();
		}

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			Tile tile = tilemap.GetTile(Coordinates);
			if (tile == null)
			{
				yield break;
			}
			yield return tilemap.GetOrCreateTile(_centerCoordinates);
			foreach (Tile item in Roundabout.GetTilesInRoundabout(tile, RoadState.Planned | RoadState.Active))
			{
				yield return item;
			}
			foreach (Vector2Int key in _tileCoordinatesToMothball.Keys)
			{
				yield return tilemap.GetOrCreateTile(key);
			}
			TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
			foreach (TileDirection direction in diagonalDirections)
			{
				yield return tilemap.GetOrCreateTile(TileUtilities.GetAdjacentCoordinates(_centerCoordinates, direction));
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (!Diagnostics.Verify(tile != null, "Somehow was passed a null tile!"))
			{
				return false;
			}
			if (tile.Coordinates == _centerCoordinates)
			{
				bool flag = true;
				TileDirectionBitfield.Enumerator enumerator = _centerTileNodeDirectionsToRebuild.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					flag = tile.SetNodeState(new RoadTileNode(current), _centreTileNodeDirectionsToMothball[current] ? RoadState.Mothballed : RoadState.Pending) && flag;
				}
				tile.IsCenterOfRoundabout = false;
				return flag & RestoreAnyConnectionsForTile(tile);
			}
			if (_tileCoordinatesToMothball.ContainsKey(tile.Coordinates))
			{
				TileDirection direction = _tileCoordinatesToMothball[tile.Coordinates];
				return (!tile.HasTwoLaneRoadInDirection(direction, RoadState.Planned | RoadState.Active) || tile.SetNodeState(new RoadTileNode(direction), RoadState.Mothballed)) & RestoreAnyConnectionsForTile(tile);
			}
			RoadTileConnection roundaboutConnection = tile.GetRoundaboutConnection(RoadState.Planned | RoadState.Active);
			bool flag2 = TileUtilities.IsDirectionDiagonal(TileUtilities.GetDirectionBetweenAdjacentCoordinates(tile.Coordinates, _centerCoordinates));
			return (!tile.HasRoundabout(RoadState.VisiblyActive) || flag2 || tile.SetRoundaboutState(roundaboutConnection.input.direction, roundaboutConnection.output.direction, RoadState.Mothballed)) & RestoreAnyConnectionsForTile(tile);
		}

		private bool RestoreAnyConnectionsForTile(Tile tile)
		{
			bool flag = true;
			foreach (AdjacentTileConnection item in _connectionsToRestore)
			{
				if (item.DestinationCoordinates == tile.Coordinates)
				{
					RoadTileNode node = new RoadTileNode(item.DestinationDirection);
					if (tile.CanSetNodeState(node, RoadState.Pending))
					{
						flag &= tile.SetNodeState(node, RoadState.Pending);
						tile.SetNodePermanence(item.DestinationDirection, isPermanent: true);
					}
				}
				else if (item.OriginCoordinates == tile.Coordinates)
				{
					RoadTileNode node2 = new RoadTileNode(item.OriginDirection);
					if (tile.CanSetNodeState(node2, RoadState.Pending))
					{
						flag &= tile.SetNodeState(node2, RoadState.Pending);
						tile.SetNodePermanence(item.OriginDirection, isPermanent: true);
					}
				}
			}
			return flag;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			bool flag = upgradeDatabase.MothballUpgrade(UpgradeType.Roundabout);
			if (_isRemovingPlannedRoundabout)
			{
				flag = upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Roundabout) && flag;
			}
			if (_tileCoordinatesToMothball.Keys.Count > 0)
			{
				int num = 0;
				foreach (KeyValuePair<Vector2Int, TileDirection> item in _tileCoordinatesToMothball)
				{
					num += _behaviour.GetConcreteCostForConnection(tilemap, item.Key, TileUtilities.GetAdjacentCoordinates(item.Key, item.Value));
				}
				flag = upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, num) && flag;
			}
			if (_connectionsToRestore.Count > 0)
			{
				int num2 = 0;
				foreach (AdjacentTileConnection item2 in _connectionsToRestore)
				{
					num2 += _behaviour.GetConcreteCostForConnection(tilemap, item2.OriginCoordinates, item2.DestinationCoordinates);
				}
				flag = upgradeDatabase.UnmothballUpgrade(UpgradeType.Concrete, num2) && flag;
			}
			return flag;
		}

		public static RemoveRoundaboutEdit Create(IScope scope, Vector2Int coordinates, ITilemap tilemap, CityDefinition cityDefinition)
		{
			RemoveRoundaboutEdit removeRoundaboutEdit = scope.Get<RemoveRoundaboutEdit>();
			removeRoundaboutEdit.Coordinates = coordinates;
			Tile tile = tilemap.GetTile(coordinates);
			if (Diagnostics.Verify(tile != null))
			{
				RoadTileConnection roundaboutConnection = tile.GetRoundaboutConnection(RoadState.VisiblyActive);
				Vector2Int vector2Int = (Roundabout.IsTileCenterOfRoundabout(tile) ? Roundabout.GetCenterOffset() : Roundabout.GetCoordinatesOffsetForConnection(roundaboutConnection));
				removeRoundaboutEdit._centerCoordinates = coordinates - vector2Int;
				TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
				foreach (TileDirection direction in diagonalDirections)
				{
					Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(removeRoundaboutEdit._centerCoordinates, direction);
					Tile tile2 = tilemap.GetTile(adjacentCoordinates);
					if (tile2 == null)
					{
						continue;
					}
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(direction);
					RoadState twoLaneRoadStateInDirection = tile2.GetTwoLaneRoadStateInDirection(oppositeDirection);
					if (twoLaneRoadStateInDirection == RoadState.None)
					{
						continue;
					}
					if (tile2.ContentType != TileContentType.House && !cityDefinition.TileIsOverWater(adjacentCoordinates) && !cityDefinition.TileIsUnderAMountain(adjacentCoordinates))
					{
						if (twoLaneRoadStateInDirection == RoadState.Active || twoLaneRoadStateInDirection == RoadState.Pending)
						{
							removeRoundaboutEdit._tileCoordinatesToMothball[tile2.Coordinates] = oppositeDirection;
						}
					}
					else
					{
						removeRoundaboutEdit._centerTileNodeDirectionsToRebuild[direction] = true;
						removeRoundaboutEdit._centreTileNodeDirectionsToMothball[direction] = twoLaneRoadStateInDirection == RoadState.Mothballed;
					}
				}
			}
			if (tilemap.GetTile(removeRoundaboutEdit.Coordinates).IsCenterOfRoundabout)
			{
				removeRoundaboutEdit._isRemovingPlannedRoundabout = tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(removeRoundaboutEdit.Coordinates, TileDirection.North)).HasRoundabout(RoadState.Planned);
			}
			else
			{
				removeRoundaboutEdit._isRemovingPlannedRoundabout = tilemap.GetTile(removeRoundaboutEdit.Coordinates).HasRoundabout(RoadState.Planned);
			}
			ISimulation simulation = scope.Get<ISimulation>();
			RoundaboutModel roundaboutModel = null;
			ModelListEnumerator<RoundaboutModel> enumerator = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				RoundaboutModel current = enumerator.Current;
				if (current.OriginCoordinates == removeRoundaboutEdit._centerCoordinates)
				{
					roundaboutModel = current;
					break;
				}
			}
			if (Diagnostics.Verify(roundaboutModel != null, $"We have no roundabout model at {removeRoundaboutEdit._centerCoordinates}."))
			{
				removeRoundaboutEdit._connectionsToRestore.AddRange(roundaboutModel.ReplacedConnections);
			}
			return removeRoundaboutEdit;
		}
	}
}
