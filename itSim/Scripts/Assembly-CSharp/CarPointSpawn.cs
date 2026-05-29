using UnityEngine;

public class CarPointSpawn : MonoBehaviour
{
	public class returnFindData
	{
		public TrafficCityRoadV2 trafficCityRoadV2;

		public TrafficCityPoint trafficCityPoint;

		public TrafficCityRoadData trafficCityRoadData;
	}

	public TrafficCityRoadV2 Road;

	public TrafficCityRoadData Lane;

	public TrafficCityPoint FirstPoint;

	public bool EditorModeSelectRoad;

	public static void UpdateReferences()
	{
	}

	public static returnFindData FindPointById(int id)
	{
		return null;
	}
}
