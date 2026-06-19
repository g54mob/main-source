using MyBox;
using UnityEngine;

namespace WorldEnvironment.Islands
{
	public class IslandObjectView : MonoBehaviour
	{
		private const int CellSize = 5;

		private int _chunkX;

		private int _chunkY;

		private int _cellX;

		private int _cellY;

		private Terrain _terrain;

		[SerializeField]
		[ReadOnly(new string[] { })]
		private string _DEBUGCoords;

		public int ChunkX => _chunkX;

		public int ChunkY => _chunkY;

		public int CellX => _cellX;

		public int CellY => _cellY;

		public int GlobalX => _chunkX * 5 + _cellX;

		public int GlobalY => _chunkY * 5 + _cellY;

		public string CoordinatesString => $"[{GlobalX}:{GlobalY}]";

		public Vector3 TerrainCenter { get; private set; }

		public void Init(int chunkX, int chunkY, int cellX, int cellY)
		{
			_terrain = GetComponent<Terrain>();
			_chunkX = chunkX;
			_chunkY = chunkY;
			_cellX = cellX;
			_cellY = cellY;
			_DEBUGCoords = CoordinatesString;
			TerrainCenter = _terrain.transform.position + _terrain.terrainData.size / 2f;
		}
	}
}
