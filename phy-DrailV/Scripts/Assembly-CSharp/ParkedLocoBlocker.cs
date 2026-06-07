using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

public class ParkedLocoBlocker : MonoBehaviour
{
	public List<GameObject> blockers = new List<GameObject>();

	public TrainCar shunterLoco;

	public HashSet<TrainCar> blockedLocos = new HashSet<TrainCar>();

	[SerializeField]
	private GameObject blockerPrefab;

	public bool blockingAllowed;

	private void OnTriggerEnter(Collider other)
	{
		if (blockingAllowed)
		{
			TrainCar trainCar = TrainCar.Resolve(other.transform);
			if (trainCar != null && trainCar.carType == TrainCarType.LocoShunter && trainCar != shunterLoco && !blockedLocos.Contains(trainCar))
			{
				GameObject gameObject = Object.Instantiate(blockerPrefab, trainCar.transform);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				blockers.Add(gameObject);
				blockedLocos.Add(trainCar);
			}
		}
	}
}
