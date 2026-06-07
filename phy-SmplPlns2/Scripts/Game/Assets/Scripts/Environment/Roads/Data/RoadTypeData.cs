using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	[CreateAssetMenu(fileName = "RoadTypeData", menuName = "Navigation/Road Type Data", order = 1)]
	public class RoadTypeData : ScriptableObject
	{
		[Serializable]
		public class RoadType
		{
			public string id;

			public float lane0;

			public float lane1;

			public float minDistanceBetweenCars;

			public int numLanes;

			public float spawnRaycastHeight;

			public float speedInMph;

			public RoadTypeVehicleListData vehicleList;
		}

		[SerializeField]
		private RoadType[] _roadTypes;

		public RoadType GetRoadType(string id)
		{
			return _roadTypes.Where((RoadType x) => x.id == id).FirstOrDefault();
		}
	}
}
