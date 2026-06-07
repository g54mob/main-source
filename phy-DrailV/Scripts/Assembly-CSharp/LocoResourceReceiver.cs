using DV.ThingTypes;
using UnityEngine;

public class LocoResourceReceiver : MonoBehaviour
{
	public ResourceType resourceType;

	private TrainCar parentCar;

	public TrainCar ParentCar => parentCar;

	private void Awake()
	{
		parentCar = TrainCar.Resolve(base.gameObject);
	}
}
