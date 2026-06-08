using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestUiComponentLibrary : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public ElementType targetType;

		internal bool _003CCreateElementIcon_003Eb__0(ElementIcon3d x)
		{
			return x.elementType == targetType;
		}

		internal bool _003CCreateElementIcon_003Eb__1(ElementIcon3d x)
		{
			return x.elementType == targetType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public EqualityComparison equalityComparer;

		internal bool _003CCreateComparerIcon_003Eb__0(ComparerIcon x)
		{
			return x.comparisonType == equalityComparer;
		}

		internal bool _003CCreateComparerIcon_003Eb__1(ComparerIcon x)
		{
			return x.comparisonType == equalityComparer;
		}
	}

	[SerializeField]
	private QuestElementIcon lockQuestIcon;

	[SerializeField]
	private List<ElementIcon3d> elementIcons;

	[SerializeField]
	private List<ComparerIcon> comparerIcons;

	[SerializeField]
	private List<QuestBubble> questBubbleByConditionCount;

	[SerializeField]
	private List<QuestBubble> hexBubbleByConditionCount;

	public Sprite flagSprite;

	public QuestBubble CreateQuestBubble(Quest quest)
	{
		return Object.Instantiate(questBubbleByConditionCount[quest.conditions.Count - 1]);
	}

	public QuestElementIcon CreateElementIcon(QuestCondition questCondition)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_0();
		switch (questCondition.conditionType)
		{
		case QuestConditionType.CountElements:
		case QuestConditionType.CountSegments:
			CS_0024_003C_003E8__locals4.targetType = questCondition.elementType;
			if (Enumerable.Count(elementIcons, (ElementIcon3d x) => x.elementType == CS_0024_003C_003E8__locals4.targetType) == 0)
			{
				Debug.LogError($"{this} misses elementIcon for type {CS_0024_003C_003E8__locals4.targetType}");
				return null;
			}
			return Object.Instantiate(Enumerable.First(elementIcons, (ElementIcon3d x) => x.elementType == CS_0024_003C_003E8__locals4.targetType).icon);
		case QuestConditionType.CloseGroup:
			return Object.Instantiate(lockQuestIcon);
		default:
			Debug.LogError($"no element icons for conditionType {questCondition.conditionType}");
			return null;
		}
	}

	public GameObject CreateComparerIcon(EqualityComparison equalityComparer)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals5.equalityComparer = equalityComparer;
		if (CS_0024_003C_003E8__locals5.equalityComparer == EqualityComparison.None)
		{
			return null;
		}
		if (Enumerable.Count(comparerIcons, (ComparerIcon x) => x.comparisonType == CS_0024_003C_003E8__locals5.equalityComparer) == 0)
		{
			Debug.LogError($"{this} misses comparerIcon for type {CS_0024_003C_003E8__locals5.equalityComparer}");
			return null;
		}
		return Object.Instantiate(Enumerable.First(comparerIcons, (ComparerIcon x) => x.comparisonType == CS_0024_003C_003E8__locals5.equalityComparer).icon);
	}
}
