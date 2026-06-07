using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class PassageModel : IModel, IReusable, IReleasedFromScopeHandler
	{
		private Passage _passage;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private City _city;

		[Dependency]
		private TilemapModel _tilemap;

		public Passage Passage => _passage;

		public RoadState State
		{
			get
			{
				if (!Diagnostics.Verify(_passage.CrossingCoordinates.Count > 0, "PassageModel has no crossing coordinates."))
				{
					return RoadState.None;
				}
				Vector2Int vector2Int = _passage.CrossingCoordinates[0];
				TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(vector2Int, _passage.StartCoordinates);
				if (!Diagnostics.Verify(directionBetweenAdjacentCoordinates != TileDirection.None, "PassageModel has invalid crossing coordinates."))
				{
					return RoadState.None;
				}
				Tile tile = _tilemap.GetTile(vector2Int);
				if (!Diagnostics.Verify(tile != null, "PassageModel has no crossing tile."))
				{
					return RoadState.None;
				}
				return tile.GetTwoLaneRoadStateInDirection(directionBetweenAdjacentCoordinates);
			}
		}

		public void Initialize(UpgradeType upgradeType, Vector2Int startCoordinates, Vector2Int firstCrossingCoordinates)
		{
			_passage = _scope.Get<Passage>();
			_passage.Initialize(upgradeType, startCoordinates, firstCrossingCoordinates);
			ExtendOverActiveConnections();
		}

		public void ExtendOverActiveConnections()
		{
			if (!Diagnostics.Verify(!_passage.IsComplete, "Cannot extend a complete passage."))
			{
				return;
			}
			IList<Vector2Int> crossingCoordinates = _passage.CrossingCoordinates;
			Tile tile = _tilemap.GetTile(crossingCoordinates[crossingCoordinates.Count - 1]);
			if (!Diagnostics.Verify(tile != null, "All of a passage's tiles should exist."))
			{
				return;
			}
			TileDirection direction = TileUtilities.GetDirectionBetweenAdjacentCoordinates(tile.Coordinates, (crossingCoordinates.Count > 1) ? crossingCoordinates[crossingCoordinates.Count - 2] : _passage.StartCoordinates);
			while (tile != null)
			{
				Tile tile2 = null;
				TileDirectionBitfield twoLaneRoads = tile.GetTwoLaneRoads();
				twoLaneRoads[direction] = false;
				if (twoLaneRoads.Count > 0)
				{
					direction = TileUtilities.GetOppositeDirection(twoLaneRoads[0]);
					Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(tile.Coordinates, twoLaneRoads[0]);
					if ((_passage.UpgradeType == UpgradeType.Bridge && _city.Definition.TileIsOverWater(adjacentCoordinates)) || (_passage.UpgradeType == UpgradeType.Tunnel && _city.Definition.TileIsUnderAMountain(adjacentCoordinates)))
					{
						tile2 = _tilemap.GetTile(adjacentCoordinates);
						if (Diagnostics.Verify(tile2 != null, "All of a passage's tiles should exist."))
						{
							crossingCoordinates.Add(adjacentCoordinates);
						}
					}
					else
					{
						_passage.EndCoordinates = adjacentCoordinates;
					}
				}
				tile = tile2;
			}
		}

		public void Reset()
		{
			_passage = null;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_passage != null)
			{
				scope.Release(_passage);
				_passage = null;
			}
		}
	}
}
