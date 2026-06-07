using System.Collections;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class BatteryConsumer : MonoBehaviour
{
	public float consumptionInterval = 0.1f;

	public float maxOperatingTimeInHours = 12f;

	public Battery battery;

	private bool isConsuming;

	private Coroutine consumptionCoro;

	private void OnDisable()
	{
		TogglePowerConsumption(on: false);
	}

	private IEnumerator PowerConsumption()
	{
		while (!AStartGameData.carsAndJobsLoadingFinished)
		{
			yield return null;
		}
		WeatherPresetManager manager = SingletonBehaviour<WeatherDriver>.Instance.manager;
		float previousTime = manager.timeOfDay;
		while (true)
		{
			yield return WaitFor.Seconds(consumptionInterval);
			float timeOfDay = manager.timeOfDay;
			float num = timeOfDay - previousTime;
			if (num < 0f)
			{
				num += 1f;
			}
			previousTime = timeOfDay;
			float percentToDrain = 2400f / maxOperatingTimeInHours * num;
			battery.Drain(percentToDrain);
		}
	}

	public void TogglePowerConsumption(bool on)
	{
		if (isConsuming != on)
		{
			isConsuming = on;
			if (consumptionCoro != null)
			{
				StopCoroutine(consumptionCoro);
				consumptionCoro = null;
			}
			if (isConsuming)
			{
				consumptionCoro = StartCoroutine(PowerConsumption());
			}
		}
	}
}
