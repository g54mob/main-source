using System.Collections.Generic;
using UnityEngine;

public class TrafficCityIntersectionLightComponent : MonoBehaviour
{
	public TrafficCityIntersectionLightArea BrakeArea;

	public TrafficCityIntersectionLightObject Lights;

	public TrafficCityIntersectionLight Light;

	public List<TrafficCityPoint> pointInCamopnent;

	private void Reset()
	{
	}

	public static void UpdateReferences()
	{
	}
}
