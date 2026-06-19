using UnityEngine;

namespace WorldEnvironment.Islands
{
	public class WorldGridManager
	{
		private readonly WorldParams _worldParams;

		private readonly WorldGridParams _params;

		private readonly Transform _worldCenter;

		public Transform WorldCenter => _worldCenter;

		public WorldGridParams GridParams => _params;

		public WorldGridManager(WorldParams worldParams, WorldGridParams gridParams, Transform worldCenter)
		{
			_worldParams = worldParams;
			_params = gridParams;
			_worldCenter = worldCenter;
		}

		public IslandWorldGrid GetGridAt(int x, int y)
		{
			IslandWorldGrid islandWorldGrid = new IslandWorldGrid(x, y, _params);
			islandWorldGrid.GenerateIslandGrid(_worldParams.Seed);
			return islandWorldGrid;
		}

		public IslandWorldGrid GetGridWithWorldPosition(Vector3 worldPosition)
		{
			Vector2Int gridIndexWithWorldPosition = GetGridIndexWithWorldPosition(worldPosition);
			IslandWorldGrid islandWorldGrid = new IslandWorldGrid(gridIndexWithWorldPosition.x, gridIndexWithWorldPosition.y, _params);
			islandWorldGrid.GenerateIslandGrid(_worldParams.Seed);
			return islandWorldGrid;
		}

		public Vector2Int GetGridIndexWithWorldPosition(Vector3 worldPosition)
		{
			float num = _params.GridSize * _params.ChunkSize;
			float num2 = worldPosition.x - _worldCenter.position.x + num / 2f;
			float num3 = worldPosition.z - _worldCenter.position.z + num / 2f;
			int x = Mathf.FloorToInt(num2 / num);
			int y = Mathf.FloorToInt(num3 / num);
			return new Vector2Int(x, y);
		}
	}
}
