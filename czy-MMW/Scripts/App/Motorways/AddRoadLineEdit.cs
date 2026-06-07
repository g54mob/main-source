using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class AddRoadLineEdit : TileEdit
	{
		private Vector2Int _originCoordinates;

		private Vector2Int _destinationCoordinates;

		private TileDirection _direction;

		private int _length;

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			Vector2Int directionOffset = TileUtilities.GetAdjacencyOffsetForDirection(_direction);
			int tileIndex = 0;
			while (tileIndex <= _length)
			{
				yield return tilemap.GetOrCreateTile(_originCoordinates + directionOffset * tileIndex);
				int num = tileIndex + 1;
				tileIndex = num;
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (tile.Coordinates != _destinationCoordinates)
			{
				tile.SetNodeState(new RoadTileNode(_direction), RoadState.Pending);
			}
			if (tile.Coordinates != _originCoordinates)
			{
				tile.SetNodeState(new RoadTileNode(TileUtilities.GetOppositeDirection(_direction)), RoadState.Pending);
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
			_originCoordinates = default(Vector2Int);
			_destinationCoordinates = default(Vector2Int);
			_direction = TileDirection.North;
			_length = 0;
		}

		public static AddRoadLineEdit Create(IScope scope, Vector2Int originCoordinates, TileDirection direction, int length)
		{
			AddRoadLineEdit addRoadLineEdit = scope.Get<AddRoadLineEdit>();
			addRoadLineEdit._originCoordinates = originCoordinates;
			addRoadLineEdit._destinationCoordinates = originCoordinates + TileUtilities.GetAdjacencyOffsetForDirection(direction) * length;
			addRoadLineEdit._direction = direction;
			addRoadLineEdit._length = length;
			return addRoadLineEdit;
		}
	}
}
