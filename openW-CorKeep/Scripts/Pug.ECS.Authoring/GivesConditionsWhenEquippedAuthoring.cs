using System.Collections.Generic;
using UnityEngine;

public class GivesConditionsWhenEquippedAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public bool dontCalculateValuesFromLevel;

	public bool givesConditionsWhenHeldInHand;

	public bool isArmor;

	public List<EquipmentCondition> givesConditionsWhenEquipped;

	[HideInInspector]
	public AreaLevelAuthoring level;

	[HideInInspector]
	public ConditionsTable conditionsTable;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (conditionsTable == null)
			{
				conditionsTable = ConditionsTable.GetTable();
			}
			if (conditionsTable.conditionCategories != null && level != null && !dontCalculateValuesFromLevel)
			{
				EntityMonoBehaviourData component = GetComponent<EntityMonoBehaviourData>();
				int num = level.CalculateLevel();
				bool isEnemy = GetComponent<EnemyAuthoring>() != null;
				uint rngSeed = ((component != null) ? ((uint)(component.objectInfo.objectID + 1)) : ((uint)GetComponent<ObjectAuthoring>().objectName.GetHashCode()));
				List<ConditionData> emptyConditionDataList = new List<ConditionData>();
				givesConditionsWhenEquipped = ConditionExtensions.LevelToEquipmentConditionValues(givesConditionsWhenEquipped, emptyConditionDataList, num, rngSeed, givesConditionsWhenHeldInHand, isArmor, isEnemy, conditionsTable);
			}
		}
	}
}
