using System;
using UnityEngine;

public class PerkState : CountableState
{
	public readonly PerkType type;

	public readonly Perk perk;

	public float pointCost;

	public float initialCost;

	public CountableState cachedPointState;

	public BuildObjectAvailability availability;

	public RequirementGroup unlockRequirements = new RequirementGroup();

	public bool isInAlertState;

	public new Town parentTown;

	public InvalidReason addInvalidReason;

	public InvalidReason removeInvalidReason;

	public PerkState(Perk p)
	{
		type = p.perkType;
		perk = p;
		initialCost = GetInitialCost(p);
	}

	private static float GetInitialCost(Perk p)
	{
		switch (p.perkType)
		{
		case PerkType.Specialization:
			return 4f;
		case PerkType.NaturalResourceCapacity:
		case PerkType.IdleGain:
			return 2f;
		case PerkType.SpecializationCount:
		case PerkType.SpecializationValue:
		case PerkType.SpecializationDemand:
			return 2f;
		default:
			return p.isGlobal ? 5 : 2;
		}
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromPerk(type);
	}

	public override void Reset()
	{
		base.Reset();
		isInAlertState = false;
		availability = BuildObjectAvailability.Locked;
	}

	public void CalcAddRemoveValidity()
	{
		if (currentCount >= maxCount)
		{
			addInvalidReason = InvalidReason.AlreadyAtMaxLevel;
		}
		else if (GameManager.freeMode)
		{
			addInvalidReason = InvalidReason.None;
		}
		else if (availability != BuildObjectAvailability.Available)
		{
			addInvalidReason = InvalidReason.LockedByRequirements;
		}
		else if (!CanAffordPerk())
		{
			addInvalidReason = InvalidReason.CanNotAfford;
		}
		else
		{
			addInvalidReason = InvalidReason.None;
		}
		if (currentCount <= 0.0)
		{
			removeInvalidReason = InvalidReason.AlreadyAtMinLevel;
			return;
		}
		removeInvalidReason = InvalidReason.None;
		if (type == PerkType.MoreStartingLand)
		{
			int startingLandPerkLevel = Mathf.RoundToInt(GameUtility.RoundToFloat(currentCount - 1.0));
			{
				foreach (Town town in CountableState.gm.towns)
				{
					if (town != null)
					{
						double num = town.landState.maxCount;
						float num2 = town.LandCapacityForLevel(town.townLevel, startingLandPerkLevel, town.LevelOfPerk(PerkType.LandCapacity));
						double num3 = num - (double)num2;
						if (town.landState.numAvailable < num3)
						{
							removeInvalidReason = InvalidReason.LandInUse;
							break;
						}
					}
				}
				return;
			}
		}
		if (type == PerkType.LandCapacity)
		{
			int landCapacityPerkLevel = Mathf.RoundToInt(GameUtility.RoundToFloat(currentCount - 1.0));
			double num4 = parentTown.landState.maxCount;
			float num5 = parentTown.LandCapacityForLevel(parentTown.townLevel, GameManager.Instance.LevelOfGlobalPerk(PerkType.MoreStartingLand), landCapacityPerkLevel);
			double num6 = num4 - (double)num5;
			if (parentTown.landState.numAvailable < num6)
			{
				removeInvalidReason = InvalidReason.LandInUse;
			}
			return;
		}
		if (type == PerkType.Specialization)
		{
			if ((float)CountableState.gm.LevelOfGlobalPerk(PerkType.SpecializationCount) > 0f || (float)CountableState.gm.LevelOfGlobalPerk(PerkType.SpecializationDemand) > 0f || (float)CountableState.gm.LevelOfGlobalPerk(PerkType.SpecializationValue) > 0f)
			{
				removeInvalidReason = InvalidReason.RequirementInUse;
				return;
			}
			{
				foreach (Town town2 in CountableState.gm.towns)
				{
					if (town2 != null && town2.numSpecialtiesActive > 0)
					{
						removeInvalidReason = InvalidReason.SpecializationInUse;
						break;
					}
				}
				return;
			}
		}
		if (type == PerkType.SpecializationCount)
		{
			int num7 = CountableState.gm.MaxNumSpecialtiesForPerkLevel(GameUtility.RoundToInt(currentCount) - 1);
			{
				foreach (Town town3 in CountableState.gm.towns)
				{
					if (town3 != null && town3.numSpecialtiesActive > num7)
					{
						removeInvalidReason = InvalidReason.SpecializationInUse;
						break;
					}
				}
				return;
			}
		}
		if (type == PerkType.HousingCapacity)
		{
			foreach (Town town4 in CountableState.gm.towns)
			{
				if (town4 != null)
				{
					int num8 = town4.LevelOfPerk(PerkType.HousingCapacity);
					double num9 = town4.PopulationForHousingCapacityPerkLevel(num8);
					double num10 = town4.PopulationForHousingCapacityPerkLevel(num8 - 1);
					if (num9 - num10 > town4.workerState.numAvailable)
					{
						removeInvalidReason = InvalidReason.WorkersInUse;
						break;
					}
				}
			}
			return;
		}
		if (type == PerkType.ExtraQuestCoins && parentTown != null)
		{
			double num11 = CountableState.gm.questCoinState.numAvailable;
			int num12 = parentTown.LevelOfPerk(PerkType.ExtraQuestCoins);
			float num13 = CountableState.gm.AdjustedMultiplierForPerkLevel(type, num12);
			float num14 = CountableState.gm.AdjustedMultiplierForPerkLevel(type, num12 - 1);
			if ((double)(num13 - num14) > num11)
			{
				removeInvalidReason = InvalidReason.QuestCoinsInUse;
			}
		}
	}

	public bool CanAffordPerk()
	{
		return cachedPointState.numAvailable >= (double)pointCost;
	}

	public void StoreItemStateCache()
	{
		if (perk.isGlobal)
		{
			cachedPointState = CountableState.gm.questCoinState;
		}
		else
		{
			cachedPointState = parentTown.townPerkPointState;
		}
	}

	public void CalcAvailability()
	{
		if (currentCount >= maxCount)
		{
			availability = BuildObjectAvailability.Completed;
		}
		else if (availability == BuildObjectAvailability.Completed)
		{
			if (unlockRequirements.IsMet())
			{
				availability = BuildObjectAvailability.Available;
			}
			else
			{
				availability = BuildObjectAvailability.Locked;
			}
		}
		else if (availability == BuildObjectAvailability.Locked && unlockRequirements.IsMet())
		{
			Unlock();
		}
	}

	public void StoreRequirementCache()
	{
		if (perk.requirements == null)
		{
			return;
		}
		if (parentTown == null)
		{
			foreach (RequirementId requirement in perk.requirements)
			{
				unlockRequirements.AddRequirement(GameManager.Instance.GetCachedWorldRequirement(requirement));
			}
			return;
		}
		foreach (RequirementId requirement2 in perk.requirements)
		{
			unlockRequirements.AddRequirement(parentTown.GetCachedRequirement(requirement2));
		}
	}

	public void Decrement()
	{
		currentCount -= 1.0;
		if (currentCount < 0.0)
		{
			currentCount = 0.0;
		}
		OnModified();
	}

	public void Increment()
	{
		currentCount += 1.0;
		OnModified();
	}

	public void OnModified()
	{
		CalcCost();
		parentTown?.CalcUnassignedPerkPoints();
		CountableState.gm.CalcUnassignedQuestCoins();
		CalcAvailability();
		CalcAddRemoveValidity();
	}

	public void CalcCost()
	{
		int testLevel = ((parentTown == null) ? GameManager.Instance.LevelOfGlobalPerk(type) : parentTown.LevelOfPerk(type));
		pointCost = CostForUpgradingFromLevel(testLevel);
	}

	public float CostForUpgradingFromLevel(int testLevel)
	{
		if (perk.costArray != null && perk.costArray.Length != 0)
		{
			if (testLevel >= perk.costArray.Length)
			{
				return perk.costArray[perk.costArray.Length - 1];
			}
			return perk.costArray[testLevel];
		}
		PerkType perkType = type;
		if (perkType == PerkType.CraftingSpeed || perkType == PerkType.ResearchSpeed || perkType == PerkType.HarvestingSpeed)
		{
			if (testLevel < 5)
			{
				return 2f;
			}
			if (testLevel < 10)
			{
				return 5f;
			}
			if (testLevel < 15)
			{
				return 15f;
			}
			if (testLevel < 20)
			{
				return 40f;
			}
			return 50f;
		}
		float num = GameUtility.ExponentGrowth(initialCost, testLevel, 0.25f);
		if (num < 2.1474836E+09f)
		{
			num = Mathf.CeilToInt(num);
		}
		return num;
	}

	public float TotalCostToReachCurrentLevel()
	{
		if (currentCount <= 0.0)
		{
			return 0f;
		}
		double num = Math.Round(currentCount) - 1.0;
		float num2 = 0f;
		for (int i = 0; (double)i <= num; i++)
		{
			float num3 = CostForUpgradingFromLevel(i);
			num2 += num3;
		}
		return num2;
	}

	public override double DefaultCapacity()
	{
		return perk.maxLevel;
	}

	private void Unlock()
	{
		availability = BuildObjectAvailability.Available;
		CalcAddRemoveValidity();
		if (GameManager.Instance.gameState != GameState.InGame)
		{
			return;
		}
		if (perk.isGlobal || parentTown == null)
		{
			if (CountableState.gm.questCoinState.currentCount >= 10.0)
			{
				isInAlertState = true;
				MenuManager.Instance.OnStateBecameAvailableInActiveTownDuringGame(this);
				GameManager.Instance.TryAddUnlock(AsEntity());
			}
		}
		else if (parentTown.townPerkPointState.currentCount > 0.0)
		{
			isInAlertState = true;
			MenuManager.Instance.OnStateBecameAvailableInActiveTownDuringGame(this);
			GameManager.Instance.TryAddUnlock(AsEntity());
		}
	}

	public int GetLevel()
	{
		return (int)Math.Round(currentCount);
	}

	public override string ToString()
	{
		return "Perk State " + perk.perkType;
	}
}
