using System.Collections.Generic;
using UnityEngine;

public class GivesConditionsWhenConsumedAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public List<ConditionDataContainer> Values;

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
			EntityMonoBehaviourData component = GetComponent<EntityMonoBehaviourData>();
			if (level != null)
			{
				int num = level.CalculateLevel();
				uint rngSeed = ((component != null) ? ((uint)(component.objectInfo.objectID + 1)) : ((uint)GetComponent<ObjectAuthoring>().objectName.GetHashCode()));
				Values = ConditionExtensions.LevelToConsumedConditionValues(Values, num, rngSeed, conditionsTable);
			}
		}
	}
}
