using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static PlayerStats Instance { get; private set; }

	public float GeneralHitRateModifier { get; private set; }

	public float GeneralToolStrengthModifier { get; private set; }

	public float GeneralAttackStrengthModifier { get; private set; }

	[field: SerializeField]
	public float AutoGeneratorSpeedModifier { get; private set; }

	public float GeneralHarvestHitRateModifier { get; private set; }

	public float GeneralAttackHitRateModifier { get; private set; }

	public float GeneralMineStrengthModifier { get; private set; }

	public float GeneralCraftingRateModifier { get; private set; }

	public float SpecialFuelSpeedModifier { get; private set; }

	public float GeneralEffectiveRadiusModifier { get; private set; }

	public float GeneralTransferSpeedModifier { get; private set; }

	public int GeneralCrafterCapacity { get; private set; }

	public float GeneralHarvestAOE { get; private set; }

	public float GeneralAttackAOE { get; private set; }

	public bool CanTransferToCrafters { get; private set; }

	public event Action<int> AnnounceAddedCrafterCapacity
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate()
	{
	}

	public void AddGeneralHitRateModifier(float rate)
	{
	}

	public void AddGeneralToolStrengthModifier(float rate)
	{
	}

	public void AddGeneralAttackStrengthModifier(float rate)
	{
	}

	public void AddAutoGeneratorSpeedModifier(float rate)
	{
	}

	public void AddGeneralHarvestHitRateModifier(float rate)
	{
	}

	public void AddGeneralAttackHitRateModifier(float rate)
	{
	}

	public void AddGeneralMineStrengthModifier(float rate)
	{
	}

	public void AddGeneralCraftingRateModifier(float rate)
	{
	}

	public void AddSpecialFuelSpeedModifier(float rate)
	{
	}

	public void AddGeneralEffectiveRadiusModifier(float modifier)
	{
	}

	public void AddTransferSpeedModifier(float modifier)
	{
	}

	public void AddGeneralCrafterCapacity(int modifier)
	{
	}

	public void AddGeneralHarvestAOE(float rate)
	{
	}

	public void AddGeneralEnemyAOE(float rate)
	{
	}

	public void UnlockTransferToCrafters()
	{
	}
}
