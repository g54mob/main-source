using System;
using UnityEngine;

public class TutorialSlowDownZone : MonoBehaviour
{
	public event Action<TrainCar> CarInZone;

	private void OnTriggerEnter(Collider other)
	{
		TrainCar trainCar = TrainCar.Resolve(other.transform.root);
		if ((bool)trainCar)
		{
			this.CarInZone?.Invoke(trainCar);
		}
	}
}
