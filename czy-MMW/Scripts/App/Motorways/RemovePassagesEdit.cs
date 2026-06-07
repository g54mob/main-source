using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class RemovePassagesEdit : TileEdit, IReleasedFromScopeHandler
	{
		private readonly List<Passage> _passages = new List<Passage>();

		public override void Reset()
		{
			base.Reset();
			_passages.Clear();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (Passage passage in _passages)
			{
				scope.Release(passage);
			}
			_passages.Clear();
		}

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			int passageIndex = 0;
			while (passageIndex < _passages.Count)
			{
				Passage passage = _passages[passageIndex];
				foreach (Vector2Int crossingCoordinate in passage.CrossingCoordinates)
				{
					Tile tile = tilemap.GetTile(crossingCoordinate);
					if (tile != null)
					{
						yield return tile;
					}
				}
				Vector2Int startCoordinates = passage.StartCoordinates;
				bool flag = true;
				Vector2Int endCoordinates = passage.EndCoordinates;
				bool isEndUnique = passage.IsComplete && startCoordinates != endCoordinates;
				for (int i = 0; i < passageIndex; i++)
				{
					Passage passage2 = _passages[i];
					flag &= passage2.StartCoordinates != startCoordinates && (!passage2.IsComplete || passage2.EndCoordinates != startCoordinates);
					isEndUnique &= passage2.StartCoordinates != endCoordinates && (!passage2.IsComplete || passage2.EndCoordinates != endCoordinates);
				}
				if (flag)
				{
					Tile tile2 = tilemap.GetTile(startCoordinates);
					if (tile2 != null)
					{
						yield return tile2;
					}
				}
				if (isEndUnique)
				{
					Tile tile3 = tilemap.GetTile(endCoordinates);
					if (tile3 != null)
					{
						yield return tile3;
					}
				}
				int num = passageIndex + 1;
				passageIndex = num;
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			bool flag = true;
			foreach (Passage passage in _passages)
			{
				if (passage.StartCoordinates == tile.Coordinates)
				{
					if (!tile.IsCenterOfRoundabout)
					{
						TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(passage.StartCoordinates, passage.CrossingCoordinates[0]);
						tile.SetNodeState(new RoadTileNode(directionBetweenAdjacentCoordinates), RoadState.Mothballed);
					}
					flag = false;
				}
				if (passage.IsComplete && passage.EndCoordinates == tile.Coordinates)
				{
					if (!tile.IsCenterOfRoundabout)
					{
						TileDirection directionBetweenAdjacentCoordinates2 = TileUtilities.GetDirectionBetweenAdjacentCoordinates(passage.EndCoordinates, passage.CrossingCoordinates[passage.CrossingCoordinates.Count - 1]);
						tile.SetNodeState(new RoadTileNode(directionBetweenAdjacentCoordinates2), RoadState.Mothballed);
					}
					flag = false;
				}
			}
			if (flag)
			{
				TileDirectionBitfield.Enumerator enumerator2 = tile.GetTwoLaneRoads(RoadState.ActiveOrPending).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TileDirection current2 = enumerator2.Current;
					tile.SetNodeState(new RoadTileNode(current2), RoadState.Mothballed);
				}
			}
			return true;
		}

		public static RemovePassagesEdit Create(IScope scope, ITilemap tilemap, Vector2Int coordinates, CityDefinition cityDefinition, Tile.TileChangePermissions changePermissions)
		{
			RemovePassagesEdit removePassagesEdit = scope.Get<RemovePassagesEdit>();
			foreach (Passage item in Passage.GetPassagesOnTile(scope, cityDefinition, tilemap, coordinates, RoadState.ActiveOrPending))
			{
				if (item.CanBeCleared(tilemap, changePermissions))
				{
					removePassagesEdit._passages.Add(item);
				}
				else
				{
					scope.Release(item);
				}
			}
			return removePassagesEdit;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (Passage passage in _passages)
			{
				switch (passage.UpgradeType)
				{
				case UpgradeType.Bridge:
					num2++;
					break;
				case UpgradeType.Tunnel:
					num3++;
					break;
				default:
					Diagnostics.FailAssert("Passage has unrecognised upgrade type.");
					break;
				}
				num += passage.GetConcreteCost(tilemap);
			}
			if (num > 0)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, num);
			}
			if (num2 > 0)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.Bridge, num2);
			}
			if (num3 > 0)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.Tunnel, num3);
			}
			return true;
		}
	}
}
