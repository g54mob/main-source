using System.Collections;
using UnityEngine;

public abstract class BatteryPowerProviderBase : MonoBehaviour
{
	[SerializeField]
	protected float updateInterval = 0.1f;

	[SerializeField]
	protected float outputPerUnitTime = 600f;

	private Coroutine powerGeneratorCoro;

	public Battery battery;

	protected void StartPowerUpdate()
	{
		if (powerGeneratorCoro != null)
		{
			StopCoroutine(powerGeneratorCoro);
		}
		powerGeneratorCoro = StartCoroutine(PowerGenerator());
	}

	protected void StopPowerUpdate()
	{
		if (powerGeneratorCoro != null)
		{
			StopCoroutine(powerGeneratorCoro);
		}
	}

	private IEnumerator PowerGenerator()
	{
		while (true)
		{
			yield return WaitFor.Seconds(updateInterval);
			float num = GenerateBatteryPower();
			if (num > 0f && battery != null)
			{
				battery.Charge(num);
			}
		}
	}

	protected abstract float GenerateBatteryPower();
}
