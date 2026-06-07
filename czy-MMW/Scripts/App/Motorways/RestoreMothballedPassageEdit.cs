using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class RestoreMothballedPassageEdit : TileEdit, IReleasedFromScopeHandler
	{
		private Passage _passage;

		public override void Reset()
		{
			base.Reset();
			_passage = null;
		}

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetOrCreateTile(_passage.StartCoordinates);
			foreach (Vector2Int crossingCoordinate in _passage.CrossingCoordinates)
			{
				yield return tilemap.GetOrCreateTile(crossingCoordinate);
			}
			if (_passage.IsComplete && _passage.StartCoordinates != _passage.EndCoordinates)
			{
				yield return tilemap.GetOrCreateTile(_passage.EndCoordinates);
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (tile.Coordinates == _passage.StartCoordinates)
			{
				if (tile.IsCenterOfRoundabout)
				{
					return true;
				}
				TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(_passage.StartCoordinates, _passage.CrossingCoordinates[0]);
				return tile.SetNodeState(new RoadTileNode(directionBetweenAdjacentCoordinates), RoadState.Pending);
			}
			if (_passage.IsComplete && tile.Coordinates == _passage.EndCoordinates)
			{
				if (tile.IsCenterOfRoundabout)
				{
					return true;
				}
				TileDirection directionBetweenAdjacentCoordinates2 = TileUtilities.GetDirectionBetweenAdjacentCoordinates(_passage.EndCoordinates, _passage.CrossingCoordinates[_passage.CrossingCoordinates.Count - 1]);
				return tile.SetNodeState(new RoadTileNode(directionBetweenAdjacentCoordinates2), RoadState.Pending);
			}
			bool flag = true;
			TileDirectionBitfield.Enumerator enumerator = tile.GetTwoLaneRoads(RoadState.Mothballed).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				flag = tile.SetNodeState(new RoadTileNode(current), RoadState.Pending) && flag;
			}
			return flag;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			upgradeDatabase.UnmothballUpgrade(_passage.UpgradeType);
			upgradeDatabase.UnmothballUpgrade(UpgradeType.Concrete, _passage.GetConcreteCost(tilemap));
			return true;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_passage != null)
			{
				scope.Release(_passage);
				_passage = null;
			}
		}

		public static RestoreMothballedPassageEdit Create(IScope scope, ITilemap tilemap, Vector2Int originCoordinates, TileDirection direction, City city)
		{
			List<Passage> list;
			if (city.Definition.TileIsOverWater(originCoordinates) || city.Definition.TileIsUnderAMountain(originCoordinates))
			{
				list = Passage.GetPassagesOnTile(scope, city.Definition, tilemap, originCoordinates, RoadState.Mothballed);
			}
			else
			{
				Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(originCoordinates, direction);
				list = Passage.GetPassagesOnTile(scope, city.Definition, tilemap, adjacentCoordinates, RoadState.Mothballed);
			}
			RestoreMothballedPassageEdit restoreMothballedPassageEdit = null;
			if (Diagnostics.Verify(list != null && list.Count == 1))
			{
				restoreMothballedPassageEdit = scope.Get<RestoreMothballedPassageEdit>();
				restoreMothballedPassageEdit._passage = list[0];
				list = null;
			}
			if (list != null)
			{
				foreach (Passage item in list)
				{
					scope.Release(item);
				}
			}
			return restoreMothballedPassageEdit;
		}
	}
}
