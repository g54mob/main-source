using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerBatteryPowerProvider : BatteryPowerProviderBase
{
	public LampControl chargingLamp;

	public AudioClip chargingStartSound;

	public AudioClip chargingFinishedSound;

	public AudioSource chargingLoopSound;

	private HashSet<Battery> batteries = new HashSet<Battery>();

	private bool isCharging;

	private void OnDisable()
	{
		StopAllCoroutines();
		if (chargingLoopSound.isPlaying)
		{
			chargingLoopSound.Stop();
		}
		isCharging = false;
		batteries.Clear();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == null || other.attachedRigidbody == null)
		{
			return;
		}
		Battery component = other.attachedRigidbody.GetComponent<Battery>();
		if (!(component != null))
		{
			return;
		}
		batteries.Add(component);
		if (!isCharging)
		{
			isCharging = true;
			chargingLamp.SetLampState(LampControl.LampState.On);
			chargingStartSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 5f, default(AudioSourceCurves), null, base.transform);
			if (!chargingLoopSound.isPlaying)
			{
				chargingLoopSound.Play();
			}
			StartCoroutine(ChargingStateCheckCoro());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other == null || other.attachedRigidbody == null)
		{
			return;
		}
		Battery component = other.attachedRigidbody.GetComponent<Battery>();
		if (!(component != null))
		{
			return;
		}
		batteries.Remove(component);
		if (batteries.Count <= 0)
		{
			isCharging = false;
			chargingLamp.SetLampState(LampControl.LampState.Off);
			if (chargingLoopSound.isPlaying)
			{
				chargingLoopSound.Stop();
			}
			StopAllCoroutines();
		}
	}

	private IEnumerator ChargingStateCheckCoro()
	{
		int num;
		do
		{
			yield return WaitFor.Seconds(updateInterval);
			float percentToCharge = GenerateBatteryPower() / (float)Mathf.Max(1, batteries.Count);
			num = 0;
			foreach (Battery battery in batteries)
			{
				battery.Charge(percentToCharge);
				if (battery.CurrentPower >= 99f)
				{
					num++;
				}
			}
		}
		while (num < batteries.Count);
		chargingLamp.SetLampState(LampControl.LampState.Off);
		if (chargingLoopSound.isPlaying)
		{
			chargingLoopSound.Stop();
		}
		chargingFinishedSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 5f, default(AudioSourceCurves), null, base.transform);
		isCharging = false;
	}

	protected override float GenerateBatteryPower()
	{
		return updateInterval * outputPerUnitTime;
	}
}
