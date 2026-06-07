using UnityEngine;

public class Car : MonoBehaviour
{
	public TrafficCityRoadV2 InRoad;

	public TrafficCityRoadData Road;

	public int idPoint;

	public TrafficCityPoint nextPoint;

	public float speed;

	public float brake;

	public float brakeCar;

	public float currentBrake;

	public float rotationSpeed;

	public Transform detectPoint;

	public float widthCarOffset;

	public TrafficCityIntersectionLightArea cityIntersectionLightArea;

	private void Reset()
	{
	}

	private void Update()
	{
	}

	private void CheckNextPointSide(Vector3 directionToNextPoint)
	{
	}

	private float speedBrake()
	{
		return 0f;
	}

	private void NextPoint()
	{
	}

	private void FindNextPointInOtherObject()
	{
	}

	private void LightArea()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
