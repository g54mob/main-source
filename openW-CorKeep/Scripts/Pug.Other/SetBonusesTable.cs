using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/Gameplay/SetBonusesTable", order = 4)]
public class SetBonusesTable : ScriptableObject
{
	[ArrayElementTitle("setBonusID")]
	public List<SetBonusInfo> setBonuses;

	private Dictionary<int, SetBonusID> objectIDToSetBonus;

	private ConditionsTable conditionsTable;

	public SetBonusID GetSetBonusID(ObjectID objectID)
	{
		if (objectIDToSetBonus == null)
		{
			objectIDToSetBonus = new Dictionary<int, SetBonusID>();
			foreach (SetBonusInfo setBonuse in setBonuses)
			{
				foreach (ObjectID availablePiece in setBonuse.availablePieces)
				{
					objectIDToSetBonus.Add((int)availablePiece, setBonuse.setBonusID);
				}
			}
		}
		if (objectIDToSetBonus.ContainsKey((int)objectID))
		{
			return objectIDToSetBonus[(int)objectID];
		}
		return SetBonusID.None;
	}

	public SetBonusInfo GetSetBonusInfo(SetBonusID setBonusID)
	{
		foreach (SetBonusInfo setBonuse in setBonuses)
		{
			if (setBonuse.setBonusID == setBonusID)
			{
				return setBonuse;
			}
		}
		return null;
	}

	public void UpdateSetBonusDatas()
	{
		if (conditionsTable == null)
		{
			conditionsTable = ConditionsTable.GetTable();
		}
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(1337u);
		foreach (SetBonusInfo setBonuse in setBonuses)
		{
			int levelFromAreaLevelAndRarity = LevelScaling.GetLevelFromAreaLevelAndRarity(setBonuse.areaLevel, setBonuse.rarity);
			for (int i = 0; i < setBonuse.setBonusDatas.Count; i++)
			{
				ConditionData conditionData = setBonuse.setBonusDatas[i].conditionData;
				float valueMultiplier = ((conditionData.valueMultiplier == 0f) ? 1f : conditionData.valueMultiplier);
				float randomDeviationMultiplier = random.NextFloat(0.9f, 1.1f);
				ConditionInfo conditionInfo = conditionsTable.GetConditionInfo(conditionData.conditionID);
				setBonuse.setBonusDatas[i] = new SetBonusData
				{
					conditionData = new ConditionData
					{
						conditionID = conditionData.conditionID,
						value = ConditionExtensions.GetConditionValueFromLevel(conditionInfo.effect, conditionInfo.isNegative, levelFromAreaLevelAndRarity, valueMultiplier, randomDeviationMultiplier, 1f, isTemporary: false, isHeldInHand: false, isArmor: false, isEnemy: false, conditionInfo.Id),
						duration = conditionData.duration,
						valueMultiplier = valueMultiplier
					},
					requiredPieces = setBonuse.setBonusDatas[i].requiredPieces
				};
			}
		}
	}
}
