using System.Collections.Generic;
using Data.Objectives.Validators;
using Data.Statistics;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Create Objective Target Category")]
public class ObjectiveTargetCategorySO : ScriptableObject
{
	public ObjectiveTargetResource Resource;

	public List<ObjectiveTargetItem> Items;

	public List<AbstractObjectiveValidator> Validators;

	public uint XpMultiplier = 1000u;

	[LocaKey]
	public string ModuleNameLocaKey;

	[SerializeField]
	private ObjectiveTargetGenerationSettingsSO _generationSettings;

	[SerializeField]
	private ObjectiveXpRewardFormulaSO objectiveXpRewardFormula;

	[SerializeField]
	private StatisticsSO _statisticsSO;

	public uint DeliveredAmount
	{
		get
		{
			if (Resource.HasResourceData)
			{
				return _statisticsSO.GetDeliveredStatistic(Resource.GetResourceID());
			}
			if (Resource.HasShapeData)
			{
				return _statisticsSO.GetDeliveredShapesStatistic(Resource.GetRotationIndependentHash());
			}
			return 0u;
		}
	}

	public int CurrentTier
	{
		get
		{
			int i;
			for (i = 0; i < Items.Count && DeliveredAmount >= Items[i].RequiredAmount; i++)
			{
			}
			return i;
		}
	}

	public int ClampedCurrentTier => Mathf.Min(CurrentTier, Items.Count - 1);

	public uint DisplayDeliveredInTier => DeliveredAmount - Items[ClampedCurrentTier].AmountStartOffset;

	public uint DisplayDeliveredTotal => DeliveredAmount;

	public uint DisplayRequiredInTier => Items[ClampedCurrentTier].Amount;

	public bool AllTiersClaimed => CurrentTier >= Items.Count;

	public bool IsMetalCompleted => CurrentTier > 0;

	public bool IsSilverCompleted => CurrentTier > 1;

	public bool IsGoldCompleted => CurrentTier > 2;

	[Button("Generate Targets Data List", EButtonEnableMode.Always)]
	public void GenerateTargetsData()
	{
		Items.Clear();
		if (Resource.HasResourceData)
		{
			Items.Capacity = 25;
			uint num = 0u;
			for (uint num2 = 0u; num2 < 25; num2++)
			{
				ObjectiveTargetItem objectiveTargetItem = new ObjectiveTargetItem();
				uint num3 = num2 + 1;
				uint num4;
				switch (num2)
				{
				case 0u:
					num4 = _generationSettings.BotTier1Amount;
					break;
				case 1u:
					num4 = _generationSettings.BotTier2Amount;
					break;
				default:
				{
					num4 = num + (uint)(int)(_generationSettings.TierIncrement * (num3 - 2));
					float num5 = _generationSettings.RoundToNearestMultiple;
					num4 = (uint)(Mathf.Round((float)num4 / num5) * num5);
					break;
				}
				}
				num = num4;
				objectiveTargetItem.Amount = num4;
				objectiveTargetItem.XpReward = num3 * XpMultiplier;
				Items.Add(objectiveTargetItem);
			}
		}
		else if (Resource.HasShapeData)
		{
			Items.Capacity = _generationSettings.ModuleChallengeAmounts.Length;
			for (uint num6 = 0u; num6 < _generationSettings.ModuleChallengeAmounts.Length; num6++)
			{
				ObjectiveTargetItem objectiveTargetItem2 = new ObjectiveTargetItem();
				uint tier = num6 + 1;
				objectiveTargetItem2.Amount = _generationSettings.ModuleChallengeAmounts[num6];
				objectiveTargetItem2.XpReward = objectiveXpRewardFormula.Evaluate(tier, XpMultiplier);
				Items.Add(objectiveTargetItem2);
			}
		}
		GenerateAmountOffsets();
	}

	[Button("Generate Item Start Offsets", EButtonEnableMode.Always)]
	public void GenerateAmountOffsets()
	{
		Items[0].AmountStartOffset = 0u;
		for (int i = 1; i < Items.Count; i++)
		{
			ObjectiveTargetItem objectiveTargetItem = Items[i];
			ObjectiveTargetItem objectiveTargetItem2 = Items[i - 1];
			objectiveTargetItem.AmountStartOffset = objectiveTargetItem2.Amount + objectiveTargetItem2.AmountStartOffset;
		}
	}
}
