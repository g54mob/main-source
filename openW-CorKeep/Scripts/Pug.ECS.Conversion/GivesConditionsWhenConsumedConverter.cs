using System.Collections.Generic;
using Pug.Conversion;

public class GivesConditionsWhenConsumedConverter : SingleAuthoringComponentConverter<GivesConditionsWhenConsumedAuthoring>
{
	private ConditionsTable _cachedConditionsTable;

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

	protected override void Convert(GivesConditionsWhenConsumedAuthoring authoring)
	{
		List<ConditionDataContainer> list = authoring.Values;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
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
			list = ConditionExtensions.LevelToConsumedConditionValues(authoring.Values, component.level, rngSeed, ConditionsTable);
		}
		EnsureHasBuffer<GivesConditionsWhenConsumedBuffer>();
		TableItemLightSourceAuthoring component4;
		bool flag = TryGetActiveComponent<TableItemLightSourceAuthoring>(authoring, out component4);
		foreach (ConditionDataContainer item in list)
		{
			AddToBuffer(new GivesConditionsWhenConsumedBuffer
			{
				conditionDataContainer = item
			});
			if (!flag && ConditionExtensions.IsLightSource(item.conditionData.conditionID))
			{
				AddComponentData(new TableItemLightSourceCD
				{
					Condition = new SimpleConditionData
					{
						conditionID = item.conditionData.conditionID,
						value = item.conditionData.value
					}
				});
				flag = true;
			}
		}
	}
}
