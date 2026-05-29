using System;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public class TrafficLightsIntersectionData
	{
		public string Name;

		public LightsStopWaypoints[] StopWaypoints;

		public float GreenLightTime;

		public float YellowLightTime;

		public int[] ExitWaypoints;

		public int[] PedestrianWaypoints;

		public int[] DirectionWaypoints;

		public GameObject[] RedLightObjects;

		public GameObject[] GreenLightObjects;

		public float PedestrianGreenLightTime;

		public TrafficLightsIntersectionData(string name, LightsStopWaypoints[] stopWaypoints, float greenLightTime, float yellowLightTime, int[] exitWaypoints)
		{
		}

		public void AddPedestrianWaypoints(int[] pedestrianWaypoints, int[] directionWaypoints, GameObject[] redLightObjects, GameObject[] greenLightObjects, float pedestrianGreenLightTime)
		{
		}
	}
}
