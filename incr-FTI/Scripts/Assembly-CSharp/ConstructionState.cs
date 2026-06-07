using System.Collections.Generic;
using UnityEngine;

public class ConstructionState : StateManager
{
	public readonly BuildingType type;

	public readonly BuildingState parentBuildingState;

	public bool isCostAlreadyPaid;

	public int inputHash = int.MinValue;

	private float lastFullAnimationDelta;

	public ConstructionState(BuildingState buildingState)
	{
		parentBuildingState = buildingState;
		type = buildingState.type;
		isUnitProgressHardCapped = true;
		Initialize();
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		AddModifier(PerkType.ConstructionSpeed);
		if (GameManager.Instance.isExtraActive)
		{
			AddModifier(GameModifier.ExtraActive, 2f);
		}
		else if (GameManager.Instance.isExtraIdle)
		{
			AddModifier(GameModifier.ExtraIdle, 0.5f);
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
		if (isCostAlreadyPaid)
		{
			inputAmountMultiplier = 0.0;
		}
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromBuilding(type);
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		_ = type;
		_ = 63;
		float constructionTime = parentBuildingState.buildingDef.constructionTime;
		float num = Mathf.Log10((float)parentBuildingState.currentCount + 10f);
		float num2 = constructionTime * num;
		if (GameManager.Instance.isExtraActive)
		{
			num2 = constructionTime;
		}
		baseProductionRate = 1f / num2;
		parentBuildingState.tempCost.Clear();
		parentBuildingState.LoadIntoTempCost(parentBuildingState.currentCount);
		foreach (KeyValuePair<ItemType, double> item in parentBuildingState.tempCost.items)
		{
			if (!Item.IsCostTrackedSeparately(item.Key) && parentTown.inventory.TryGetValue(item.Key, out var value))
			{
				ItemRateData itemRateData = new ItemRateData(value, item.Value, baseProductionRate, this);
				itemRateData.displayedAffordabilityState = AffordabilityState.CanFullyProduce;
				AddInput(itemRateData);
			}
		}
		parentBuildingState.tempCost.CalcHashCode();
		inputHash = parentBuildingState.tempCost.storedHash;
		parentBuildingState.dynamicCost.FlagHashStale();
		_ = type;
		_ = 63;
	}

	protected override void OnUnitCompleted()
	{
		base.OnUnitCompleted();
		parentBuildingState.CompleteConstructionGradual();
		if (parentBuildingState.pendingConstructions <= 0)
		{
			StopConstruction();
		}
	}

	public void StopConstruction()
	{
		parentTown.DeactivateState(this);
	}

	public override bool IsWorkerAssignment()
	{
		return false;
	}

	public override string ToString()
	{
		return "Construction State " + AsEntity();
	}

	public float DisplayedDynamicProgress()
	{
		if (false)
		{
			if (parentBuildingState.pendingConstructions <= 0)
			{
				return 0f;
			}
			float num = GameUtility.AsFloat(cumulativeUnitProgressPrev);
			float num2 = GameUtility.AsFloat(cumulativeUnitProgress);
			float num3 = num2 + (num2 - num);
			float progressToNextFixedUpdate = TimeManager.ProgressToNextFixedUpdate;
			float num4 = Mathf.Lerp(num2, num3, progressToNextFixedUpdate);
			_ = type;
			_ = 19;
			if (parentBuildingState.pendingConstructions == 1 && num3 > Mathf.Ceil(num2))
			{
				return 1f;
			}
			return num4 % 1f;
		}
		if (parentBuildingState.pendingConstructions == 0)
		{
			if (!GameUtility.NearlyEquals(cumulativeUnitProgress, cumulativeUnitProgressPrev))
			{
				float num5 = GameUtility.AsTruncatedFloat(cumulativeUnitProgressPrev);
				float num6 = GameUtility.AsTruncatedFloat(cumulativeUnitProgress);
				float progressToNextFixedUpdate2 = TimeManager.ProgressToNextFixedUpdate;
				float num7 = Mathf.Lerp(num5, num5 + lastFullAnimationDelta, progressToNextFixedUpdate2);
				if (num7 > num6)
				{
					return 0f;
				}
				_ = type;
				_ = 97;
				return num7 % 1f;
			}
			return 0f;
		}
		float num8 = GameUtility.AsTruncatedFloat(cumulativeUnitProgressPrev);
		float num9 = GameUtility.AsTruncatedFloat(cumulativeUnitProgress);
		lastFullAnimationDelta = num9 - num8;
		float progressToNextFixedUpdate3 = TimeManager.ProgressToNextFixedUpdate;
		float num10 = Mathf.Lerp(num8, num9, progressToNextFixedUpdate3);
		_ = type;
		_ = 97;
		return num10 % 1f;
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		parentBuildingState.AssignDefaultAutoAssign();
	}
}
