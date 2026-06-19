using System;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using UnityEngine;

[DisallowMultipleComponent]
public class SupportsConditionsAuthoring : MonoBehaviour
{
	[Serializable]
	public class ConditionWithRandomChance
	{
		[Range(0f, 1f)]
		public float chance = 1f;

		public ConditionData conditionData;
	}

	public bool cantBeAffectedByAuras;

	public bool cantBeAffectedByEnvironment;

	public bool cantBeAffectedByHealing;

	public bool dontShowStatsTextOnItem;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	[ArrayElementTitle("conditionID")]
	public List<ConditionData> initialConditions = new List<ConditionData>();

	public List<ConditionWithRandomChance> initialConditionsWithRandomChance = new List<ConditionWithRandomChance>();

	[HideInInspector]
	public AreaLevelAuthoring level;

	[HideInInspector]
	public ConditionsTable conditionsTable;

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (level == null || level.gameObject != base.gameObject)
		{
			level = GetComponent<AreaLevelAuthoring>();
		}
		if (conditionsTable == null)
		{
			conditionsTable = ConditionsTable.GetTable();
		}
		EntityMonoBehaviourData component = GetComponent<EntityMonoBehaviourData>();
		if (component != null && level != null)
		{
			int num = level.CalculateLevel();
			bool isEnemy = GetComponent<EnemyAuthoring>() != null;
			uint rngSeed = ((component != null) ? ((uint)(component.objectInfo.objectID + 1)) : ((uint)GetComponent<ObjectAuthoring>().objectName.GetHashCode()));
			ConditionExtensions.LevelToConditionValues(initialConditions, num, rngSeed, isHeldInHand: false, isArmor: false, isEnemy, conditionsTable);
			List<ConditionData> list = initialConditionsWithRandomChance.Select((ConditionWithRandomChance conditionWithChance) => conditionWithChance.conditionData).ToList();
			ConditionExtensions.LevelToConditionValues(list, num, rngSeed, isHeldInHand: false, isArmor: false, isEnemy, conditionsTable);
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				initialConditionsWithRandomChance[num2].conditionData = list[num2];
			}
		}
	}
}
