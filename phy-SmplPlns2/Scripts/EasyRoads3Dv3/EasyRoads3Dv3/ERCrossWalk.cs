using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERCrossWalk
	{
		public string name = "";

		public ERCrossWalkType type = ERCrossWalkType.Prefab;

		public float size = 4f;

		public float width = 0.75f;
	}
}
