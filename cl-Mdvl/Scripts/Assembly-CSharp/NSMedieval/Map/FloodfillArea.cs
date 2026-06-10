using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Map
{
	public class FloodfillArea
	{
		private readonly int elevation;

		private readonly Vector2Int startPosition;

		private int nodesCount;

		private int nodesCountNonForbidden;

		private readonly List<Vector2Int> points;

		private int waterVoxelsCount;

		public int WaterVoxelsCount => waterVoxelsCount;

		public Vector2Int StartPosition => startPosition;

		public int Elevation => elevation;

		public int NodesCount => nodesCount;

		public int NodesCountNonForbidden => nodesCountNonForbidden;

		public List<Vector2Int> Points => points;

		public FloodfillArea(Vector2Int startPosition, int elevation)
		{
			this.startPosition = startPosition;
			nodesCount = 0;
			this.elevation = elevation;
			points = new List<Vector2Int>();
		}

		public static void DrawGizmos(FloodfillArea area, Vector2 largestSquareBoundsMin, Vector2 largestSquareBoundsMax)
		{
			if (!MonoSingleton<Heightmap>.IsInstantiated())
			{
				return;
			}
			Vector3 size = new Vector3(1f, 0.1f, 1f);
			Gizmos.color = Color.white;
			foreach (Vector2Int point in area.Points)
			{
				if ((float)point.x >= largestSquareBoundsMin.x && (float)point.y >= largestSquareBoundsMin.y && (float)point.x <= largestSquareBoundsMax.x && (float)point.y <= largestSquareBoundsMax.y)
				{
					Gizmos.color = Color.red;
				}
				else
				{
					Gizmos.color = Color.white;
				}
				Gizmos.DrawWireCube(new Vector3(point.x, MonoSingleton<Heightmap>.Instance.GetHeightAt(point.x, point.y) * World.MapBlockHeight, point.y), size);
			}
		}

		public void AddPoint(Vec3Int point3d, VillageMap map)
		{
			nodesCount++;
			if (!GridDataIndexTools.IsForbiddenEdge(point3d.x, point3d.z))
			{
				nodesCountNonForbidden++;
			}
			Points.Add(new Vector2Int(point3d.x, point3d.z));
			if (map.WaterManager.IsWaterAt(point3d))
			{
				waterVoxelsCount++;
			}
		}
	}
}
