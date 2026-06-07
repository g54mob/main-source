using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSORoadUpdate
	{
		public ERModularRoad road;

		public ERSORoadExt soData;

		public bool mirrored;

		public ERSORoadUpdate(ERModularRoad _road, ERSORoadExt _soData, bool _mirrored)
		{
			road = _road;
			soData = _soData;
			mirrored = _mirrored;
		}
	}
}
