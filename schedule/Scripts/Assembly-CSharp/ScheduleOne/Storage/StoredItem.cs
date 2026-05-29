using System.Collections.Generic;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage
{
	public class StoredItem : MonoBehaviour
	{
		[Header("References")]
		public Transform buildPoint;

		public List<CoordinateStorageFootprintTilePair> CoordinateFootprintTilePairs;

		private int footprintX;

		private int footprintY;

		protected List<CoordinatePair> coordinatePairs;

		protected float rotation;

		public int xSize;

		public int ySize;

		public StorableItemInstance item { get; protected set; }

		public bool Destroyed { get; private set; }

		public FootprintTile OriginFootprint => null;

		public int FootprintX => 0;

		public int FootprintY => 0;

		public StorageGrid parentGrid { get; protected set; }

		public List<CoordinatePair> CoordinatePairs => null;

		public float Rotation => 0f;

		public int totalArea => 0;

		protected virtual void Awake()
		{
		}

		public virtual void InitializeStoredItem(StorableItemInstance _item, StorageGrid grid, Vector2 _originCoordinate, float _rotation)
		{
		}

		private void RefreshTransform()
		{
		}

		public virtual void Destroy()
		{
		}

		public void ClearFootprintOccupancy()
		{
		}

		public void SetFootprintTileVisiblity(bool visible)
		{
		}

		public void CalculateFootprintTileIntersections()
		{
		}

		public FootprintTile GetTile(Coordinate coord)
		{
			return null;
		}
	}
}
