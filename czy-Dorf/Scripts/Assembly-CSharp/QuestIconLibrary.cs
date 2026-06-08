using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestIconLibrary : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public QuestCondition condition;

		internal bool _003CGetIcon_003Eb__0(ElementIcon x)
		{
			return x.elementType == condition.elementType;
		}

		internal bool _003CGetIcon_003Eb__1(ElementIcon x)
		{
			return x.elementType == condition.elementType;
		}

		internal bool _003CGetIcon_003Eb__2(GroupIcon x)
		{
			return x.groupType == condition.groupType;
		}

		internal bool _003CGetIcon_003Eb__3(GroupIcon x)
		{
			return x.groupType == condition.groupType;
		}
	}

	public List<ElementIcon> elementIcons;

	public List<GroupIcon> segmentIcons;

	public Sprite lockIcon;

	public Sprite GetIcon(QuestCondition condition)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals13.condition = condition;
		switch (CS_0024_003C_003E8__locals13.condition.conditionType)
		{
		case QuestConditionType.CountElements:
			if (Enumerable.Count(elementIcons, (ElementIcon x) => x.elementType == CS_0024_003C_003E8__locals13.condition.elementType) == 0)
			{
				Debug.LogError($"no quest icon for condition type {CS_0024_003C_003E8__locals13.condition.conditionType} for elementType {CS_0024_003C_003E8__locals13.condition.elementType}");
			}
			return Enumerable.First(elementIcons, (ElementIcon x) => x.elementType == CS_0024_003C_003E8__locals13.condition.elementType).icon;
		case QuestConditionType.CountSegments:
			if (Enumerable.Count(segmentIcons, (GroupIcon x) => x.groupType == CS_0024_003C_003E8__locals13.condition.groupType) == 0)
			{
				Debug.LogError($"no quest icon for condition type {CS_0024_003C_003E8__locals13.condition.conditionType} for groupType {CS_0024_003C_003E8__locals13.condition.groupType}");
			}
			return Enumerable.First(segmentIcons, (GroupIcon x) => x.groupType == CS_0024_003C_003E8__locals13.condition.groupType).icon;
		case QuestConditionType.CloseGroup:
			return lockIcon;
		default:
			Debug.LogError($"no icon found for {CS_0024_003C_003E8__locals13.condition.conditionType} - {CS_0024_003C_003E8__locals13.condition.elementType}, {CS_0024_003C_003E8__locals13.condition.groupType}");
			return null;
		}
	}
}
