using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class SubdividableTilemap
	{
		private readonly Tilemap _targetTilemap;

		private readonly int _subdivisionSteps;

		public BoundsInt.PositionEnumerator AllPositionsWithin
		{
			get
			{
				BoundsInt cellBounds = _targetTilemap.cellBounds;
				cellBounds.max += new Vector3Int(cellBounds.max.x * (_subdivisionSteps - 1), cellBounds.max.y * (_subdivisionSteps - 1), 0);
				cellBounds.min += new Vector3Int(cellBounds.min.x * (_subdivisionSteps - 1), cellBounds.min.y * (_subdivisionSteps - 1), 0);
				return cellBounds.allPositionsWithin;
			}
		}

		public SubdividableTilemap(Tilemap targetTilemap, int subdivisionSteps)
		{
			_targetTilemap = targetTilemap;
			_subdivisionSteps = subdivisionSteps;
		}

		private Vector3Int TransformPosition(Vector3Int position)
		{
			return Vector3Int.FloorToInt((Vector3)position / (float)_subdivisionSteps);
		}

		public bool Contains(Vector3Int position)
		{
			return _targetTilemap.cellBounds.Contains(TransformPosition(position));
		}

		public bool HasTile(Vector3Int position)
		{
			return _targetTilemap.HasTile(TransformPosition(position));
		}
	}
}
