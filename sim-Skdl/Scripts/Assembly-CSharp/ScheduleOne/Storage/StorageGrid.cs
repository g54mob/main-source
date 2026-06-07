using System.Collections.Generic;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage
{
	public class StorageGrid : MonoBehaviour
	{
		public static float gridSize;

		public List<StorageTile> storageTiles;

		[HideInInspector]
		public List<CoordinateStorageTilePair> coordinateStorageTilePairs;

		private int _unoccupiedTileCount;

		private bool _unoccupiedTileCountDirty;

		public int UnoccupiedTileCount => 0;

		private void Awake()
		{
		}

		public void RegisterTile(StorageTile tile)
		{
		}

		public void DeregisterTile(StorageTile tile)
		{
		}

		public Coordinate GetMatchedCoordinate(FootprintTile tileToMatch)
		{
			return null;
		}

		public StorageTile GetTile(Coordinate coord)
		{
			return null;
		}

		public int GetUserEndCapacity()
		{
			return 0;
		}

		public int GetActualY()
		{
			return 0;
		}

		public int GetActualX()
		{
			return 0;
		}

		public int GetTotalFootprintSize()
		{
			return 0;
		}

		public bool TryFitItem(int sizeX, int sizeY, List<Coordinate> lockedCoordinates, out Coordinate originCoordinate, out float rotation)
		{
			originCoordinate = null;
			rotation = default(float);
			return false;
		}

		private int CalculateUnoccupiedTileCount()
		{
			return 0;
		}

		private void TileOccupantChanged()
		{
		}
	}
}
