using System.Collections.Generic;
using UnityEngine;

public class SafetyDerailer : MonoBehaviour
{
	public List<TrainCar> carsToProcess = new List<TrainCar>();

	public GameObject derailerLeft;

	public GameObject derailerRight;

	private const float SQRDISTANCE_TO_DERAILER_THRESHOLD = 9f;

	private bool derailerActive;

	private void Start()
	{
		if (derailerLeft == null || derailerRight == null)
		{
			Debug.LogError("Derailer references to actual physical derailer objects are not set. Disabling self.", this);
			base.enabled = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		TrainCar trainCar = ((other.transform != PlayerManager.PlayerTransform) ? TrainCar.Resolve(other.transform) : null);
		if (!trainCar)
		{
			return;
		}
		Bogie[] bogies = trainCar.Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			_ = bogies[i];
			if (!carsToProcess.Contains(trainCar))
			{
				carsToProcess.Add(trainCar);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		TrainCar trainCar = ((other.transform != PlayerManager.PlayerTransform) ? TrainCar.Resolve(other.transform) : null);
		if ((bool)trainCar && carsToProcess.Contains(trainCar))
		{
			carsToProcess.Remove(trainCar);
			DisableDerailersIfProcessListIsEmpty();
		}
	}

	private void Update()
	{
		if (carsToProcess.Count <= 0)
		{
			return;
		}
		if (!derailerActive)
		{
			((Vector3.Dot(base.transform.forward, carsToProcess[0].rb.velocity) > 0f) ? derailerRight : derailerLeft).SetActive(value: true);
			derailerActive = true;
		}
		for (int num = carsToProcess.Count - 1; num >= 0; num--)
		{
			Bogie[] bogies = carsToProcess[num].Bogies;
			int num2 = 0;
			for (int i = 0; i < bogies.Length; i++)
			{
				if (bogies[i].HasDerailed)
				{
					num2++;
					continue;
				}
				Vector3 vector = bogies[i].transform.position - base.transform.position;
				vector.y = 0f;
				if (vector.sqrMagnitude < 9f)
				{
					bogies[i].Derail();
					num2++;
				}
				if (num2 == bogies.Length)
				{
					carsToProcess.Remove(carsToProcess[num]);
					DisableDerailersIfProcessListIsEmpty();
				}
			}
		}
	}

	private void DisableDerailersIfProcessListIsEmpty()
	{
		if (carsToProcess.Count <= 0)
		{
			derailerLeft.SetActive(value: false);
			derailerRight.SetActive(value: false);
		}
	}
}
