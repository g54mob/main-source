using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERConnectionData
	{
		public ERRoad road;

		public int marker;

		public int connectionIndex;

		public Vector3 position;

		public ERConnectionData(ERRoad rd, int rm, int index)
		{
			road = rd;
			marker = rm;
			connectionIndex = index;
		}
	}
}
