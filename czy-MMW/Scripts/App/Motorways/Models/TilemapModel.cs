using System.Collections.Generic;
using Factory;
using FixMath;
using JetBrains.Annotations;
using Server;
using Unity.Profiling;
using UnityEngine;

namespace Motorways.Models
{
	public class TilemapModel : Model<EmptyModelFrame, IEmptyModelObserver>, ITilemap, TileModel.IObserver, IDeserializedHandler
	{
		public static readonly Fix64 TileWidth = Fix64Consts.Two;

		public static readonly Fix64 HalfTileWidth = TileWidth * Fix64Consts.OneHalf;

		[Dependency]
		private Scope _scope;

		[Dependency]
		private Simulation _simulation;

		[Dependency]
		private City _city;

		private readonly Dictionary<Vector2Int, TileModel> _tiles = new Dictionary<Vector2Int, TileModel>();

		[Serialize(false, null)]
		private readonly HashSet<Vector2Int> _reservedTiles = new HashSet<Vector2Int>();

		private readonly Dictionary<CornerAdjacencyReference, TileCornerModel> _tileCorners = new Dictionary<CornerAdjacencyReference, TileCornerModel>();

		[Serialize(false, null)]
		private readonly HashSet<TileModel> _changedTiles = new HashSet<TileModel>();

		[Serialize(false, null)]
		private readonly HashSet<AdjacentTileConnection> _mothballedTileConnections = new HashSet<AdjacentTileConnection>();

		[Serialize(false, null)]
		private HashSet<AdjacentTileConnection> _pendingTileConnections = new HashSet<AdjacentTileConnection>();

		[Serialize(false, null)]
		private HashSet<AdjacentTileConnection> _blockedTileConnections = new HashSet<AdjacentTileConnection>();

		[Serialize(false, null)]
		private bool _arePendingTileConnectionsLocked;

		private readonly List<LaneModel> _temporaryLanes = new List<LaneModel>();

		[Serialize(false, null)]
		private readonly List<AdjacentTileConnection> _potentialNewPassages = new List<AdjacentTileConnection>();

		private readonly Dictionary<int, MotorwayModel> _motorways = new Dictionary<int, MotorwayModel>();

		private static readonly ProfilerMarker Profiler_ActivateUnblockedPendingLanes = new ProfilerMarker(ProfilerCategory.Scripts, "TilemapModel.ActivateUnblockedPendingLanes()");

		private static readonly ProfilerMarker Profiler_CachePendingTileConnections = new ProfilerMarker(ProfilerCategory.Scripts, "TilemapModel.CachePendingTileConnections()");

		private static readonly ProfilerMarker Profiler_CacheMothballedTileConnections = new ProfilerMarker(ProfilerCategory.Scripts, "TilemapModel.CacheMothballedTileConnections()");

		public IList<LaneModel> TemporaryLanes => _temporaryLanes;

		public IEnumerable<TileModel> ChangedTiles => _changedTiles;

		public IEnumerable<AdjacentTileConnection> MothballedTileConnections => _mothballedTileConnections;

		[CanBeNull]
		public Motorway GetMotorway(int id)
		{
			return GetMotorwayModel(id);
		}

		public Motorway CreateMotorway(int id, int number, int replacedMotorwayId)
		{
			if (Diagnostics.Verify(!_motorways.ContainsKey(id), "Motorway model already created."))
			{
				MotorwayModel motorwayModel = _scope.Get<MotorwayModel>();
				motorwayModel.Initialize(this, id, number);
				_motorways.Add(id, motorwayModel);
				_simulation.AddModel(motorwayModel);
				return motorwayModel;
			}
			return null;
		}

		[CanBeNull]
		public MotorwayModel GetMotorwayModel(int id)
		{
			if (_motorways.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		public bool RemoveMotorwayModel(MotorwayModel motorwayModel)
		{
			if (GetMotorwayModel(motorwayModel.Id) == motorwayModel)
			{
				_motorways.Remove(motorwayModel.Id);
				return true;
			}
			return false;
		}

		[CanBeNull]
		public Tile GetTile(Vector2Int coordinates)
		{
			return GetTileModel(coordinates)?.Tile;
		}

		[NotNull]
		public Tile GetOrCreateTile(Vector2Int coordinates)
		{
			return GetOrCreateTileModel(coordinates)?.Tile;
		}

		[CanBeNull]
		public TileModel GetTileModel(Vector2Int coordinates)
		{
			if (_tiles.TryGetValue(coordinates, out var value))
			{
				return value;
			}
			return null;
		}

		[NotNull]
		public TileModel GetOrCreateTileModel(Vector2Int coordinates)
		{
			TileModel tileModel = GetTileModel(coordinates);
			if (tileModel != null)
			{
				return tileModel;
			}
			tileModel = _scope.Get<TileModel>();
			tileModel.Initialize(coordinates);
			tileModel.Subscribe(this);
			_tiles[coordinates] = tileModel;
			_simulation.AddModel(tileModel);
			return tileModel;
		}

		[CanBeNull]
		public TileCornerModel GetTileCornerModel(CornerAdjacencyReference cornerDefinition)
		{
			if (_tileCorners.TryGetValue(cornerDefinition, out var value))
			{
				return value;
			}
			return null;
		}

		[NotNull]
		public TileCornerModel GetOrCreateTileCornerModel(CornerAdjacencyReference cornerDefinition)
		{
			TileCornerModel tileCornerModel = GetTileCornerModel(cornerDefinition);
			if (tileCornerModel != null)
			{
				return tileCornerModel;
			}
			Vector2Int tileCoordinate = cornerDefinition.tileCoordinate;
			Vector2Int vector2Int = TileUtilities.DirectionToTileAdjacencyOffset[(int)cornerDefinition.cornerDirection];
			List<CornerAdjacencyReference> list = new List<CornerAdjacencyReference>();
			list.Add(cornerDefinition);
			TileDirection closestDirection = TileUtilities.GetClosestDirection(new Vector2Fixed(-vector2Int.x, vector2Int.y));
			CornerAdjacencyReference cornerAdjacencyReference = new CornerAdjacencyReference(tileCoordinate + new Vector2Int(vector2Int.x, 0), closestDirection);
			list.Add(cornerAdjacencyReference);
			TileDirection closestDirection2 = TileUtilities.GetClosestDirection(new Vector2Fixed(vector2Int.x, -vector2Int.y));
			CornerAdjacencyReference cornerAdjacencyReference2 = new CornerAdjacencyReference(tileCoordinate + new Vector2Int(0, vector2Int.y), closestDirection2);
			list.Add(cornerAdjacencyReference2);
			TileDirection closestDirection3 = TileUtilities.GetClosestDirection(new Vector2Fixed(-vector2Int.x, -vector2Int.y));
			CornerAdjacencyReference cornerAdjacencyReference3 = new CornerAdjacencyReference(tileCoordinate + new Vector2Int(vector2Int.x, vector2Int.y), closestDirection3);
			list.Add(cornerAdjacencyReference3);
			tileCornerModel = _scope.Get<TileCornerModel>();
			tileCornerModel.Initialize(GetWorldPositionForCoordinates(tileCoordinate) + new Vector2Fixed(vector2Int) * HalfTileWidth, list);
			_tileCorners[cornerDefinition] = tileCornerModel;
			_tileCorners[cornerAdjacencyReference] = tileCornerModel;
			_tileCorners[cornerAdjacencyReference2] = tileCornerModel;
			_tileCorners[cornerAdjacencyReference3] = tileCornerModel;
			_simulation.AddModel(tileCornerModel);
			return tileCornerModel;
		}

		public void ClearChangedTiles()
		{
			_changedTiles.Clear();
		}

		public void ActivateUnblockedPendingLanes()
		{
			CityDefinition definition = _city.Definition;
			_arePendingTileConnectionsLocked = true;
			bool flag = false;
			bool flag2 = false;
			_potentialNewPassages.Clear();
			_blockedTileConnections.Clear();
			foreach (AdjacentTileConnection pendingTileConnection in _pendingTileConnections)
			{
				Tile tile = GetTile(pendingTileConnection.OriginCoordinates);
				RoadTileNode node = new RoadTileNode(pendingTileConnection.OriginDirection);
				Tile tile2 = GetTile(pendingTileConnection.DestinationCoordinates);
				RoadTileNode node2 = new RoadTileNode(pendingTileConnection.DestinationDirection);
				bool flag3 = true;
				if ((tile.CanSetNodeState(node, RoadState.Active) && tile2.CanSetNodeState(node2, RoadState.Active)) || (tile.CanSetNodeState(node, RoadState.Active) && tile2.StateOfRoadInDirection(node2.direction) == RoadState.Active) || (tile.StateOfRoadInDirection(node.direction) == RoadState.Active && tile2.CanSetNodeState(node2, RoadState.Active)))
				{
					if (!tile.GetTwoLaneRoads()[node.direction])
					{
						tile.SetNodeState(node, RoadState.Active);
					}
					if (!tile2.GetTwoLaneRoads()[node2.direction])
					{
						tile2.SetNodeState(node2, RoadState.Active);
					}
				}
				else if (Roundabout.IsTileCenterOfRoundabout(tile) && tile2.CanSetNodeState(node2, RoadState.Active))
				{
					tile2.SetNodeState(node2, RoadState.Active);
				}
				else if (Roundabout.IsTileCenterOfRoundabout(tile2) && tile.CanSetNodeState(node, RoadState.Active))
				{
					tile.SetNodeState(node, RoadState.Active);
				}
				else
				{
					flag3 = false;
				}
				if (flag3)
				{
					bool flag4 = definition.TileIsOverWater(pendingTileConnection.OriginCoordinates);
					bool flag5 = definition.TileIsOverWater(pendingTileConnection.DestinationCoordinates);
					bool flag6 = definition.TileIsUnderAMountain(pendingTileConnection.OriginCoordinates);
					bool flag7 = definition.TileIsUnderAMountain(pendingTileConnection.DestinationCoordinates);
					if (flag4 || flag5)
					{
						flag = true;
						if (flag4 ^ flag5)
						{
							_potentialNewPassages.Add(pendingTileConnection);
						}
					}
					else if (flag6 || flag7)
					{
						flag2 = true;
						if (flag6 ^ flag7)
						{
							_potentialNewPassages.Add(pendingTileConnection);
						}
					}
				}
				else if (tile.GetTwoLaneRoads(RoadState.Pending)[node.direction] || tile2.GetTwoLaneRoads(RoadState.Pending)[node2.direction])
				{
					_blockedTileConnections.Add(pendingTileConnection);
				}
			}
			_pendingTileConnections.Clear();
			if (_blockedTileConnections.Count > 0)
			{
				HashSet<AdjacentTileConnection> blockedTileConnections = _blockedTileConnections;
				HashSet<AdjacentTileConnection> pendingTileConnections = _pendingTileConnections;
				_pendingTileConnections = blockedTileConnections;
				_blockedTileConnections = pendingTileConnections;
			}
			if (flag || flag2)
			{
				ModelList<PassageModel> models = _simulation.GetModels<PassageModel>();
				for (int i = 0; i < models.Count; i++)
				{
					PassageModel passageModel = models[i];
					Passage passage = passageModel.Passage;
					if (passage.IsComplete || (!flag && passage.UpgradeType == UpgradeType.Bridge) || (!flag2 && passage.UpgradeType == UpgradeType.Tunnel))
					{
						continue;
					}
					bool flag8 = false;
					for (int j = 0; j < i; j++)
					{
						if (models[j].Passage.OverlapsPassage(passage))
						{
							_simulation.RemoveModel(passageModel);
							flag8 = true;
							break;
						}
					}
					if (flag8)
					{
						break;
					}
					passageModel.ExtendOverActiveConnections();
				}
				foreach (AdjacentTileConnection potentialNewPassage in _potentialNewPassages)
				{
					UpgradeType upgradeType;
					Vector2Int vector2Int;
					Vector2Int vector2Int2;
					if (definition.TileIsOverWater(potentialNewPassage.OriginCoordinates))
					{
						upgradeType = UpgradeType.Bridge;
						vector2Int = potentialNewPassage.DestinationCoordinates;
						vector2Int2 = potentialNewPassage.OriginCoordinates;
					}
					else if (definition.TileIsOverWater(potentialNewPassage.DestinationCoordinates))
					{
						upgradeType = UpgradeType.Bridge;
						vector2Int = potentialNewPassage.OriginCoordinates;
						vector2Int2 = potentialNewPassage.DestinationCoordinates;
					}
					else if (definition.TileIsUnderAMountain(potentialNewPassage.OriginCoordinates))
					{
						upgradeType = UpgradeType.Tunnel;
						vector2Int = potentialNewPassage.DestinationCoordinates;
						vector2Int2 = potentialNewPassage.OriginCoordinates;
					}
					else
					{
						if (!definition.TileIsUnderAMountain(potentialNewPassage.DestinationCoordinates))
						{
							Diagnostics.FailAssert("{0} -> {1} was added as a potential new passage, but neither end is over an obstruction.", potentialNewPassage.OriginCoordinates, potentialNewPassage.DestinationCoordinates);
							continue;
						}
						upgradeType = UpgradeType.Tunnel;
						vector2Int = potentialNewPassage.OriginCoordinates;
						vector2Int2 = potentialNewPassage.DestinationCoordinates;
					}
					bool flag9 = false;
					ModelListEnumerator<PassageModel> enumerator3 = _simulation.GetModels<PassageModel>().GetEnumerator();
					while (enumerator3.MoveNext())
					{
						Passage passage2 = enumerator3.Current.Passage;
						if (upgradeType == passage2.UpgradeType && passage2.StartsWithConnection(vector2Int, vector2Int2))
						{
							flag9 = true;
							break;
						}
					}
					if (!flag9)
					{
						PassageModel passageModel2 = _scope.Get<PassageModel>();
						passageModel2.Initialize(upgradeType, vector2Int, vector2Int2);
						_simulation.AddModel(passageModel2);
					}
				}
				_potentialNewPassages.Clear();
			}
			_arePendingTileConnectionsLocked = false;
		}

		public void ReserveTile(Vector2Int coordinates)
		{
			_reservedTiles.Add(coordinates);
		}

		public void UnreserveTile(Vector2Int coordinates)
		{
			_reservedTiles.Remove(coordinates);
		}

		public bool IsTileReserved(Vector2Int coordinates)
		{
			return _reservedTiles.Contains(coordinates);
		}

		public IEnumerable<Vector2Int> GetAllTileCoordinates()
		{
			return _tiles.Keys;
		}

		public void ClearTileReservations()
		{
			_reservedTiles.Clear();
		}

		public static Vector2Fixed GetWorldPositionForCoordinates(Vector2Int coordinates)
		{
			return new Vector2Fixed((Fix64)coordinates.x * TileWidth, (Fix64)coordinates.y * TileWidth);
		}

		public override void Reset()
		{
			base.Reset();
			_tiles.Clear();
			_reservedTiles.Clear();
			_tileCorners.Clear();
			_motorways.Clear();
			_pendingTileConnections.Clear();
			_arePendingTileConnectionsLocked = false;
			_changedTiles.Clear();
			_mothballedTileConnections.Clear();
			_pendingTileConnections.Clear();
			_blockedTileConnections.Clear();
			_potentialNewPassages.Clear();
			_temporaryLanes.Clear();
		}

		public void OnDeserialized(IScope context)
		{
			foreach (TileModel value in _tiles.Values)
			{
				value.Subscribe(this);
				CachePendingTileConnections(value.Tile);
				CacheMothballedTileConnections(value.Tile);
			}
		}

		public void OnTileModelChanged(TileModel model)
		{
			_changedTiles.Add(model);
			if (!_arePendingTileConnectionsLocked)
			{
				CachePendingTileConnections(model.Tile);
			}
			CacheMothballedTileConnections(model.Tile);
		}

		private void CachePendingTileConnections(Tile tile)
		{
			TileDirectionBitfield.Enumerator enumerator = tile.GetTwoLaneRoads(RoadState.Pending).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				_pendingTileConnections.Add(new AdjacentTileConnection(tile.Coordinates, current));
			}
		}

		private void CacheMothballedTileConnections(Tile tile)
		{
			if (_mothballedTileConnections.Count > 0)
			{
				_mothballedTileConnections.RemoveWhere(delegate(AdjacentTileConnection connection)
				{
					if (connection.OriginCoordinates == tile.Coordinates)
					{
						if (!tile.HasTwoLaneRoadInDirection(connection.OriginDirection, RoadState.Mothballed))
						{
							return !(GetTile(connection.DestinationCoordinates)?.HasTwoLaneRoadInDirection(connection.DestinationDirection, RoadState.Mothballed) ?? false);
						}
						return false;
					}
					return connection.DestinationCoordinates == tile.Coordinates && !tile.HasTwoLaneRoadInDirection(connection.DestinationDirection, RoadState.Mothballed) && !(GetTile(connection.OriginCoordinates)?.HasTwoLaneRoadInDirection(connection.OriginDirection, RoadState.Mothballed) ?? false);
				});
			}
			TileDirectionBitfield twoLaneRoads = tile.GetTwoLaneRoads(RoadState.Mothballed);
			if (twoLaneRoads.Count <= 0)
			{
				return;
			}
			CityDefinition definition = _city.Definition;
			if (definition.TileIsOverWater(tile.Coordinates) || definition.TileIsUnderAMountain(tile.Coordinates))
			{
				return;
			}
			TileDirectionBitfield.Enumerator enumerator = twoLaneRoads.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				Vector2Int tileCoordinates = TileUtilities.GetAdjacencyOffsetForDirection(current) + tile.Coordinates;
				if (!definition.TileIsOverWater(tileCoordinates) && !definition.TileIsUnderAMountain(tileCoordinates))
				{
					_mothballedTileConnections.Add(new AdjacentTileConnection(tile.Coordinates, current));
				}
			}
		}

		public TilemapModel()
			: base(1)
		{
		}
	}
}
