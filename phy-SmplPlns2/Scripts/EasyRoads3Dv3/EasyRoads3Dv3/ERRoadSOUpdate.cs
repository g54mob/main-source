using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERRoadSOUpdate
	{
		public ERModularRoad road;

		public SideObject so;

		public ERCrossingPrefabs prefab;

		public ERRoadSOUpdate(ERModularRoad _road, SideObject _so, ERCrossingPrefabs _prefab)
		{
			road = _road;
			so = _so;
			prefab = _prefab;
		}
	}
}
