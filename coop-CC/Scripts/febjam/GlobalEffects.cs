using Aggro.Core;
using UnityEngine;

public class GlobalEffects : EntityBehaviourBase
{
	[Header("Effects")]
	public float stressRate;

	public bool stressImpactAdd;

	[Range(-100f, 100f)]
	public int vehicleSpeedPercentage;

	[Range(-100f, 100f)]
	public int nitroChargePercentage;

	public float GetStressRate()
	{
		return stressRate;
	}

	public bool ShouldAddStressOnImpact()
	{
		return stressImpactAdd;
	}

	public int GetVehicleSpeedPercentage()
	{
		return vehicleSpeedPercentage;
	}

	public int GetNitroChargePercentage()
	{
		return nitroChargePercentage;
	}
}
