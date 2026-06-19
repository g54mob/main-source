using System.Collections.Generic;
using Pug.Conversion;

public class GivesConditionsWhenEquippedConverter : SingleAuthoringComponentConverter<GivesConditionsWhenEquippedAuthoring>
{
	private ConditionsTable _cachedConditionsTable;

	private List<ConditionData> _cachedConditionList = new List<ConditionData>();

	private ConditionsTable ConditionsTable
	{
		get
		{
			if (_cachedConditionsTable == null)
			{
				_cachedConditionsTable = ConditionsTable.GetTable();
			}
			return _cachedConditionsTable;
		}
	}

	protected override void Convert(GivesConditionsWhenEquippedAuthoring authoring)
	{
		List<EquipmentCondition> list = authoring.givesConditionsWhenEquipped;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component) && !authoring.dontCalculateValuesFromLevel)
		{
			uint rngSeed = 1u;
			ObjectAuthoring component3;
			if (TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var component2))
			{
				rngSeed = (uint)(component2.objectInfo.objectID + 1);
			}
			else if (TryGetActiveComponent<ObjectAuthoring>(authoring, out component3))
			{
				rngSeed = (uint)component3.objectName.GetHashCode();
			}
			EnemyAuthoring component4;
			bool isEnemy = TryGetActiveComponent<EnemyAuthoring>(authoring, out component4);
			list = ConditionExtensions.LevelToEquipmentConditionValues(list, _cachedConditionList, component.level, rngSeed, authoring.givesConditionsWhenHeldInHand, authoring.isArmor, isEnemy, ConditionsTable);
		}
		TableItemLightSourceAuthoring component5;
		bool flag = TryGetActiveComponent<TableItemLightSourceAuthoring>(authoring, out component5);
		EnsureHasBuffer<GivesConditionsWhenEquippedBuffer>();
		foreach (EquipmentCondition item in list)
		{
			AddToBuffer(new GivesConditionsWhenEquippedBuffer
			{
				equipmentCondition = new EquipmentCondition
				{
					id = item.id,
					value = item.value
				}
			});
			if (!flag && ConditionExtensions.IsLightSource(item.id))
			{
				AddComponentData(new TableItemLightSourceCD
				{
					Condition = new SimpleConditionData
					{
						conditionID = item.id,
						value = item.value
					}
				});
				flag = true;
			}
		}
		if (authoring.givesConditionsWhenHeldInHand)
		{
			EnsureHasComponent<GivesConditionWhenHeldInHand>();
		}
	}
}
