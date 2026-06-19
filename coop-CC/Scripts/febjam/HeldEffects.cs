using Aggro.Core;
using UnityEngine;

public class HeldEffects : EntityBehaviourBase
{
	public PlayerEffectContext context;

	public bool disableWhenBoosting;

	[Header("Effects")]
	public float stressRate;

	public bool stressRateChangeOnlyWhenDrifting;

	public bool stressImpactAdd;

	[Range(-100f, 100f)]
	public int vehicleSpeedPercentage;

	[Range(-100f, 100f)]
	public int nitroCapacityPercentage;

	[Range(-100f, 100f)]
	public int nitroChargePercentage;

	[Header("Tags")]
	public int heavyTagVehicleSpeedPercentage = -50;

	public bool ghost;

	public float GetStressRate(Entity heldBy)
	{
		if (stressRate != 0f && (!stressRateChangeOnlyWhenDrifting || (heldBy.TryGetObject<VehicleController>(out var obj) && obj.drifting)))
		{
			return stressRate;
		}
		return 0f;
	}

	public bool GetGhost()
	{
		return ghost;
	}

	public bool ShouldAddStressOnImpact(Entity heldBy)
	{
		return stressImpactAdd;
	}

	public int GetVehicleSpeedPercentage(Entity heldBy)
	{
		if (base.entity.tags.Has(CCTags.TAG_HEAVY))
		{
			return heavyTagVehicleSpeedPercentage;
		}
		return vehicleSpeedPercentage;
	}

	public int GetNitroCapacityPercentage(Entity heldBy)
	{
		return nitroCapacityPercentage;
	}

	public int GetNitroChargePercentage(Entity heldBy)
	{
		return nitroChargePercentage;
	}
}
