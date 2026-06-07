using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	public class TrainLineDefinition
	{
		public bool isLoop;

		public bool isValid = true;

		private readonly List<Vector2Int> _trackTilePositions = new List<Vector2Int>();

		private readonly List<Vector2Int> _trainSpawnLocations = new List<Vector2Int>();

		public int TileCount => _trackTilePositions.Count;

		public Vector2Int GetRailTileCoordinates(int tileIndex)
		{
			return _trackTilePositions[tileIndex];
		}

		public RailType GetRailTileType(int tileIndex)
		{
			if (!_trainSpawnLocations.Contains(_trackTilePositions[tileIndex]))
			{
				return RailType.Normal;
			}
			return RailType.TrainOrigin;
		}

		public void AddTrack(Vector2Int trackTilePosition, RailType trackType)
		{
			_trackTilePositions.Add(trackTilePosition);
			if (trackType == RailType.TrainOrigin)
			{
				_trainSpawnLocations.Add(trackTilePosition);
			}
		}
	}
}
