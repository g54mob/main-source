using System;
using System.Collections;
using UnityEngine;

public class TrainStressDebug : MonoBehaviour
{
	public int trainIndex = -1;

	private TrainCar car;

	public event Action<TrainStressFrameData> StressDataSubmitted;

	private void Start()
	{
		car = GetComponent<TrainCar>();
		StartCoroutine(CollectDataCoro());
	}

	private IEnumerator CollectDataCoro()
	{
		while (true)
		{
			yield return WaitFor.FixedUpdate;
			CollectStressData();
		}
	}

	private void CollectStressData()
	{
		this.StressDataSubmitted?.Invoke(car.stress.debugStressData);
		car.stress.debugStressData = default(TrainStressFrameData);
		car.stress.debugStressData.trainIndex = trainIndex;
	}
}
