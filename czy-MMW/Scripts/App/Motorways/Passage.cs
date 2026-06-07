using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.Models;
using UnityEngine;

namespace Motorways
{
	[Factory.Serializable(1)]
	public class Passage : IReusable
	{
		private UpgradeType _upgradeType;

		private bool _isComplete;

		private Vector2Int _startCoordinates;

		private Vector2Int _endCoordinates;

		private readonly List<Vector2Int> _crossingCoordinates = new List<Vector2Int>();

		[Dependency]
		private GameBehaviourModel _behaviour;

		public bool IsComplete => _isComplete;

		public Vector2Int StartCoordinates => _startCoordinates;

		public Vector2Int EndCoordinates
		{
			get
			{
				return _endCoordinates;
			}
			set
			{
				_endCoordinates = value;
				_isComplete = true;
			}
		}

		public IList<Vector2Int> CrossingCoordinates => _crossingCoordinates;

		public int Length
		{
			get
			{
				int num = _crossingCoordinates.Count + 1;
				if (IsComplete)
				{
					num++;
				}
				return num;
			}
		}

		public UpgradeType UpgradeType => _upgradeType;

		public void Initialize(UpgradeType upgradeType, Vector2Int startCoordinates, Vector2Int firstCrossingCoordinates)
		{
			_upgradeType = upgradeType;
			_isComplete = false;
			_startCoordinates = startCoordinates;
			_crossingCoordinates.Add(firstCrossingCoordinates);
		}

		public void Reset()
		{
			_upgradeType = UpgradeType.Concrete;
			_isComplete = false;
			_startCoordinates = default(Vector2Int);
			_endCoordinates = default(Vector2Int);
			_crossingCoordinates.Clear();
		}

		public int GetConcreteCost(ITilemap tilemap)
		{
			int num = _behaviour.GetConcreteCostForConnection(tilemap, _startCoordinates, _crossingCoordinates[0]);
			int count = CrossingCoordinates.Count;
			if (!Diagnostics.Verify(count > 0))
			{
				return num;
			}
			for (int i = 1; i < count; i++)
			{
				num += _behaviour.GetConcreteCostForConnection(tilemap, _crossingCoordinates[i - 1], _crossingCoordinates[i]);
			}
			if (_isComplete)
			{
				num += _behaviour.GetConcreteCostForConnection(tilemap, _crossingCoordinates[count - 1], EndCoordinates);
			}
			return num;
		}

		public bool StartsWithConnection(Vector2Int landCoordinates, Vector2Int crossingCoordinate)
		{
			if (!Diagnostics.Verify(_crossingCoordinates.Count > 0))
			{
				return false;
			}
			if (landCoordinates == _startCoordinates && crossingCoordinate == _crossingCoordinates[0])
			{
				return true;
			}
			if (_isComplete && landCoordinates == _endCoordinates && crossingCoordinate == _crossingCoordinates[_crossingCoordinates.Count - 1])
			{
				return true;
			}
			return false;
		}

		public bool OverlapsPassage(Passage otherPassage)
		{
			if (!Diagnostics.Verify(otherPassage._crossingCoordinates.Count > 0))
			{
				return false;
			}
			if (!StartsWithConnection(otherPassage._startCoordinates, otherPassage._crossingCoordinates[0]))
			{
				if (otherPassage.IsComplete)
				{
					return StartsWithConnection(otherPassage._endCoordinates, otherPassage._crossingCoordinates[otherPassage._crossingCoordinates.Count - 1]);
				}
				return false;
			}
			return true;
		}

		public bool CanBeCleared(ITilemap tilemap, Tile.TileChangePermissions permissions)
		{
			if (permissions != Tile.TileChangePermissions.RespectPermanence)
			{
				return true;
			}
			Vector2Int vector2Int = StartCoordinates;
			foreach (Vector2Int crossingCoordinate in CrossingCoordinates)
			{
				TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(vector2Int, crossingCoordinate);
				if (!tilemap.GetTile(vector2Int).IsNodePermanent(directionBetweenAdjacentCoordinates) || !tilemap.GetTile(crossingCoordinate).IsNodePermanent(TileUtilities.GetOppositeDirection(directionBetweenAdjacentCoordinates)))
				{
					return true;
				}
				vector2Int = crossingCoordinate;
			}
			if (IsComplete)
			{
				TileDirection directionBetweenAdjacentCoordinates2 = TileUtilities.GetDirectionBetweenAdjacentCoordinates(vector2Int, EndCoordinates);
				if (!tilemap.GetTile(vector2Int).IsNodePermanent(directionBetweenAdjacentCoordinates2) || !tilemap.GetTile(EndCoordinates).IsNodePermanent(TileUtilities.GetOppositeDirection(directionBetweenAdjacentCoordinates2)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool WillConnectionStartPassage(CityDefinition cityDefinition, ITilemap tilemap, Vector2Int origin, Vector2Int destination, out UpgradeType passageType)
		{
			if (WillConnectionStartPassage(cityDefinition, UpgradeType.Bridge, tilemap, origin, destination))
			{
				passageType = UpgradeType.Bridge;
				return true;
			}
			if (WillConnectionStartPassage(cityDefinition, UpgradeType.Tunnel, tilemap, origin, destination))
			{
				passageType = UpgradeType.Tunnel;
				return true;
			}
			passageType = UpgradeType.Bridge;
			return false;
		}

		public static bool WillConnectionJoinPassages(CityDefinition cityDefinition, ITilemap tilemap, Vector2Int origin, Vector2Int destination, out UpgradeType passageType)
		{
			if (WillConnectionJoinPassages(cityDefinition, UpgradeType.Bridge, tilemap, origin, destination))
			{
				passageType = UpgradeType.Bridge;
				return true;
			}
			if (WillConnectionJoinPassages(cityDefinition, UpgradeType.Tunnel, tilemap, origin, destination))
			{
				passageType = UpgradeType.Tunnel;
				return true;
			}
			passageType = UpgradeType.Bridge;
			return false;
		}

		public static bool DoesTileHavePassage(CityDefinition cityDefinition, ITilemap tilemap, Vector2Int coordinates, RoadState passageStates)
		{
			if (!DoesTileHavePassage(cityDefinition, UpgradeType.Bridge, tilemap, coordinates, passageStates))
			{
				return DoesTileHavePassage(cityDefinition, UpgradeType.Tunnel, tilemap, coordinates, passageStates);
			}
			return true;
		}

		public static List<Passage> GetPassagesOnTile(IScope scope, CityDefinition cityDefinition, ITilemap tilemap, Vector2Int coordinates, RoadState passageStates)
		{
			List<Passage> passagesOnTile = GetPassagesOnTile(scope, cityDefinition, UpgradeType.Bridge, tilemap, coordinates, passageStates);
			List<Passage> passagesOnTile2 = GetPassagesOnTile(scope, cityDefinition, UpgradeType.Tunnel, tilemap, coordinates, passageStates);
			if (passagesOnTile == null && passagesOnTile2 == null)
			{
				return null;
			}
			List<Passage> list = passagesOnTile;
			if (passagesOnTile2 != null)
			{
				if (list == null)
				{
					list = passagesOnTile2;
				}
				else
				{
					list.AddRange(passagesOnTile2);
				}
			}
			return list;
		}

		private void Initialize(UpgradeType upgradeType, Vector2Int startCoordinates, IEnumerable<Vector2Int> crossingCoordinates)
		{
			_upgradeType = upgradeType;
			_isComplete = false;
			_startCoordinates = startCoordinates;
			_crossingCoordinates.AddRange(crossingCoordinates);
		}

		private void Initialize(UpgradeType upgradeType, Vector2Int startCoordinates, Vector2Int endCoordinates, IEnumerable<Vector2Int> crossingCoordinates)
		{
			_upgradeType = upgradeType;
			_isComplete = true;
			_startCoordinates = startCoordinates;
			_endCoordinates = endCoordinates;
			_crossingCoordinates.AddRange(crossingCoordinates);
		}

		private static bool WillConnectionStartPassage(CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int origin, Vector2Int destination)
		{
			Func<Vector2Int, bool> obstructionDelegate = GetObstructionDelegate(cityDefinition, passageType);
			bool flag = obstructionDelegate(origin);
			bool flag2 = obstructionDelegate(destination);
			Tile tile = tilemap.GetTile(destination);
			if (!flag)
			{
				if (flag2)
				{
					if (tile != null)
					{
						return tile.GetTwoLaneRoadCount() == 0;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		private static bool WillConnectionJoinPassages(CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int origin, Vector2Int destination)
		{
			Func<Vector2Int, bool> obstructionDelegate = GetObstructionDelegate(cityDefinition, passageType);
			bool flag = obstructionDelegate(origin);
			bool flag2 = obstructionDelegate(destination);
			if (flag && flag2)
			{
				Tile tile = tilemap.GetTile(origin);
				Tile tile2 = tilemap.GetTile(destination);
				if (tile != null && tile.GetTwoLaneRoadCount(RoadState.ActiveOrPending) > 0 && tile2 != null)
				{
					return tile2.GetTwoLaneRoadCount(RoadState.ActiveOrPending) > 0;
				}
				return false;
			}
			return false;
		}

		private static bool DoesTileHavePassage(CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int coordinates, RoadState passageStates)
		{
			Tile tile = tilemap.GetTile(coordinates);
			if (tile == null)
			{
				return false;
			}
			Func<Vector2Int, bool> obstructionDelegate = GetObstructionDelegate(cityDefinition, passageType);
			if (obstructionDelegate(coordinates))
			{
				return tile.GetTwoLaneRoadCount(passageStates) > 0;
			}
			TileDirectionBitfield.Enumerator enumerator = tile.GetTwoLaneRoads(passageStates).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(tile.Coordinates, current);
				if (obstructionDelegate(adjacentCoordinates))
				{
					return true;
				}
			}
			return false;
		}

		private static List<Passage> GetPassagesOnTile(IScope scope, CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int coordinates, RoadState passageStates)
		{
			if (GetObstructionDelegate(cityDefinition, passageType)(coordinates))
			{
				Passage passageOnObstructedTile = GetPassageOnObstructedTile(scope, cityDefinition, passageType, tilemap, coordinates, passageStates);
				if (passageOnObstructedTile == null)
				{
					return null;
				}
				return new List<Passage> { passageOnObstructedTile };
			}
			Tile tile = tilemap.GetTile(coordinates);
			if (tile == null)
			{
				return null;
			}
			List<Passage> list = null;
			TileDirectionBitfield tileDirectionBitfield = default(TileDirectionBitfield);
			TileDirectionBitfield.Enumerator enumerator = tile.GetTwoLaneRoads(passageStates).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (tileDirectionBitfield[current])
				{
					continue;
				}
				Passage passageOnLandTile = GetPassageOnLandTile(scope, cityDefinition, passageType, tilemap, coordinates, current, passageStates);
				if (passageOnLandTile != null)
				{
					if (list == null)
					{
						list = new List<Passage>();
					}
					list.Add(passageOnLandTile);
					tileDirectionBitfield[current] = true;
					if (passageOnLandTile.IsComplete && passageOnLandTile.EndCoordinates == passageOnLandTile.StartCoordinates)
					{
						TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(passageOnLandTile.EndCoordinates, passageOnLandTile.CrossingCoordinates[passageOnLandTile.CrossingCoordinates.Count - 1]);
						tileDirectionBitfield[directionBetweenAdjacentCoordinates] = true;
					}
				}
			}
			return list;
		}

		private static Passage GetPassageOnLandTile(IScope scope, CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int startCoordinates, TileDirection startDirection, RoadState passageStates)
		{
			Func<Vector2Int, bool> obstructionDelegate = GetObstructionDelegate(cityDefinition, passageType);
			if (obstructionDelegate(startCoordinates))
			{
				return null;
			}
			TileDirection connectedTileDirection;
			Tile adjacentConnectedTile = tilemap.GetTile(startCoordinates).GetAdjacentConnectedTile(out connectedTileDirection, passageStates, new TileDirectionBitfield(startDirection));
			if (adjacentConnectedTile != null && obstructionDelegate(adjacentConnectedTile.Coordinates))
			{
				Vector2Int endCoordinates = Vector2Int.zero;
				List<Vector2Int> list = new List<Vector2Int> { adjacentConnectedTile.Coordinates };
				bool flag;
				while (true)
				{
					adjacentConnectedTile = adjacentConnectedTile.GetAdjacentConnectedTile(out connectedTileDirection, passageStates, ~new TileDirectionBitfield(TileUtilities.GetOppositeDirection(connectedTileDirection)));
					if (adjacentConnectedTile == null)
					{
						flag = false;
						break;
					}
					if (obstructionDelegate(adjacentConnectedTile.Coordinates))
					{
						list.Add(adjacentConnectedTile.Coordinates);
						continue;
					}
					endCoordinates = adjacentConnectedTile.Coordinates;
					flag = true;
					break;
				}
				Passage passage = scope.Get<Passage>();
				if (flag)
				{
					passage.Initialize(passageType, startCoordinates, endCoordinates, list);
				}
				else
				{
					passage.Initialize(passageType, startCoordinates, list);
				}
				return passage;
			}
			return null;
		}

		private static Passage GetPassageOnObstructedTile(IScope scope, CityDefinition cityDefinition, UpgradeType passageType, ITilemap tilemap, Vector2Int startCoordinates, RoadState passageStates)
		{
			Func<Vector2Int, bool> obstructionDelegate = GetObstructionDelegate(cityDefinition, passageType);
			if (!obstructionDelegate(startCoordinates))
			{
				return null;
			}
			Tile tile = tilemap.GetTile(startCoordinates);
			if (tile == null)
			{
				return null;
			}
			Tile adjacentConnectedTile = tile.GetAdjacentConnectedTile(out var connectedTileDirection, passageStates, TileDirectionBitfield.All);
			if (adjacentConnectedTile != null)
			{
				List<Vector2Int> list = new List<Vector2Int> { tile.Coordinates };
				Tile tile2 = null;
				TileDirection connectedTileDirection2 = connectedTileDirection;
				while (adjacentConnectedTile != null)
				{
					if (!obstructionDelegate(adjacentConnectedTile.Coordinates))
					{
						tile2 = adjacentConnectedTile;
						break;
					}
					list.Insert(0, adjacentConnectedTile.Coordinates);
					adjacentConnectedTile = adjacentConnectedTile.GetAdjacentConnectedTile(out connectedTileDirection2, passageStates, ~new TileDirectionBitfield(TileUtilities.GetOppositeDirection(connectedTileDirection2)));
				}
				Tile tile3 = null;
				adjacentConnectedTile = tile.GetAdjacentConnectedTile(out connectedTileDirection2, passageStates, ~new TileDirectionBitfield(connectedTileDirection));
				if (adjacentConnectedTile != null)
				{
					while (adjacentConnectedTile != null)
					{
						if (!obstructionDelegate(adjacentConnectedTile.Coordinates))
						{
							tile3 = adjacentConnectedTile;
							break;
						}
						list.Add(adjacentConnectedTile.Coordinates);
						adjacentConnectedTile = adjacentConnectedTile.GetAdjacentConnectedTile(out connectedTileDirection2, passageStates, ~new TileDirectionBitfield(TileUtilities.GetOppositeDirection(connectedTileDirection2)));
					}
				}
				Passage passage = scope.Get<Passage>();
				if (tile2 != null && tile3 != null)
				{
					passage.Initialize(passageType, tile2.Coordinates, tile3.Coordinates, list);
				}
				else if (tile2 != null)
				{
					passage.Initialize(passageType, tile2.Coordinates, list);
				}
				else if (Diagnostics.Verify(tile3 != null))
				{
					list.Reverse();
					passage.Initialize(passageType, tile3.Coordinates, list);
				}
				else
				{
					scope.Release(passage);
					passage = null;
				}
				return passage;
			}
			return null;
		}

		private static Func<Vector2Int, bool> GetObstructionDelegate(CityDefinition cityDefinition, UpgradeType passageType)
		{
			Func<Vector2Int, bool> result = null;
			switch (passageType)
			{
			case UpgradeType.Bridge:
				result = cityDefinition.TileIsOverWater;
				break;
			case UpgradeType.Tunnel:
				result = cityDefinition.TileIsUnderAMountain;
				break;
			}
			return result;
		}
	}
}
