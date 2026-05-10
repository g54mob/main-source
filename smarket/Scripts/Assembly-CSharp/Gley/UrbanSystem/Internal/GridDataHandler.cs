using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class GridDataHandler
	{
		private readonly GridData _gridData;

		public GridDataHandler(GridData data)
		{
		}

		public int GetCellSize()
		{
			return 0;
		}

		private RowData[] GetGrid()
		{
			return null;
		}

		internal List<Vector2Int> GetCellNeighbors(int row, int column, int depth, bool justEdgeCells)
		{
			return null;
		}

		public CellData GetCell(Vector3 position)
		{
			return null;
		}

		public CellData GetCell(float xPoz, float zPoz)
		{
			return null;
		}

		public Vector3 GetGridCorner()
		{
			return default(Vector3);
		}

		public CellData GetCell(Vector2Int cellIndex)
		{
			return null;
		}

		public int GetGridLength()
		{
			return 0;
		}

		public int GetRowLength(int row)
		{
			return 0;
		}

		public Vector2Int GetCellIndex(Vector3 position)
		{
			return default(Vector2Int);
		}

		public List<SpawnWaypoint> GetPedestrianSpawnWaypointsForCell(Vector2Int cellIndex, int agentType)
		{
			return null;
		}

		internal List<int> GetPedestrianWaypointsAroundPosition(Vector3 position)
		{
			return null;
		}

		internal List<SpawnWaypoint> GetPedestrianSpawnWaypoipointsAroundPosition(Vector3 position, int agentType)
		{
			return null;
		}

		public List<SpawnWaypoint> GetAllPedestrianSpawnWaypoints()
		{
			return null;
		}

		public List<SpawnWaypoint> GetAllTrafficSpawnWaypoints()
		{
			return null;
		}

		public List<int> GetAllPedestrianPlayModeWaypoints()
		{
			return null;
		}

		public List<int> GetAllTrafficPlayModeWaypoints()
		{
			return null;
		}

		public List<SpawnWaypoint> GetTrafficSpawnWaypointsForCell(Vector2Int cellIndex, int agentType)
		{
			return null;
		}

		internal List<SpawnWaypoint> GetTrafficSpawnWaypoipointsAroundPosition(Vector3 position, int agentType)
		{
			return null;
		}

		public List<int> GetAllWaypoints(Vector2Int cellIndex)
		{
			return null;
		}

		public bool HasPedestrianSpawnWaypoints(Vector2Int cellIndex)
		{
			return false;
		}

		public bool HasTrafficSpawnWaypoints(Vector2Int cellIndex)
		{
			return false;
		}

		internal CellData[] GetCells(List<Vector2Int> activeCells)
		{
			return null;
		}

		internal Vector3 GetCellPosition(Vector2Int vector2Int)
		{
			return default(Vector3);
		}

		internal List<int> GetPedestrianWaypointsInArea(Area area)
		{
			return null;
		}

		internal List<int> GetTrafficWaypointsAroundPosition(Vector3 position)
		{
			return null;
		}

		public void AddTrafficWaypoint(CellData cellData, int waypointIndex)
		{
		}

		public void AddTrafficSpawnWaypoint(CellData cellData, int waypointIndex, int[] allowedVehicles, int priority)
		{
		}

		public void AddPedestrianWaypoint(CellData cellData, int waypointIndex)
		{
		}

		public void AddPedestrianSpawnWaypoint(CellData cellData, int waypointIndex, int[] allowedPedestrians, int priority)
		{
		}

		public void AddIntersection(CellData cellData, int intersectionIndex)
		{
		}
	}
}
