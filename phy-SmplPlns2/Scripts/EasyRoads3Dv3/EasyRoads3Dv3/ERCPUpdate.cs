using UnityEngine;

namespace EasyRoads3Dv3
{
	public struct ERCPUpdate
	{
		public ERModularRoad road;

		public ERCrossingPrefabs prefab;

		public int startEnd;

		public int connection;

		public Vector3 cp;

		public ERCPUpdate(ERModularRoad v_road, ERCrossingPrefabs v_prefab, int v_startEnd, int v_connection, Vector3 v_cp)
		{
			road = v_road;
			prefab = v_prefab;
			startEnd = v_startEnd;
			connection = v_connection;
			cp = v_cp;
		}
	}
}
