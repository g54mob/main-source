using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	public class BoatPathLineDefinition
	{
		public bool isLoop;

		public bool isValid = true;

		private readonly List<Vector2Int> _boatPathTilePositions = new List<Vector2Int>();

		private readonly List<Vector2Int> _boatSpawnLocations = new List<Vector2Int>();

		public int TileCount => _boatPathTilePositions.Count;

		public Vector2Int GetBoatPathTileCoordinates(int tileIndex)
		{
			return _boatPathTilePositions[tileIndex];
		}

		public BoatPathType GetBoatPathTileType(int tileIndex)
		{
			if (!_boatSpawnLocations.Contains(_boatPathTilePositions[tileIndex]))
			{
				return BoatPathType.Normal;
			}
			return BoatPathType.BoatOrigin;
		}

		public void AddBoatPath(Vector2Int boatPathTilePosition, BoatPathType boatPathType)
		{
			_boatPathTilePositions.Add(boatPathTilePosition);
			if (boatPathType == BoatPathType.BoatOrigin)
			{
				_boatSpawnLocations.Add(boatPathTilePosition);
			}
		}
	}
}
