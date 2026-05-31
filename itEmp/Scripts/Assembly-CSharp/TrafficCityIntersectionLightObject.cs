using UnityEngine;

public class TrafficCityIntersectionLightObject : MonoBehaviour
{
	public TrafficCityIntersectionLightComponent TrafficCityIntersectionLightComponent;

	public MeshRenderer LightMesh;

	public Material lightOff;

	public Material lightGreen;

	public Material lightYellow;

	public Material lightRed;

	public void SetLight(TrafficCityIntersectionLight light)
	{
	}

	public TrafficCityIntersectionLight GetCurrentLight()
	{
		return default(TrafficCityIntersectionLight);
	}
}
