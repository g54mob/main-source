using System;

[Serializable]
public class QuestCondition
{
	public QuestConditionType conditionType;

	public ElementType elementType;

	public GroupType groupType;

	public EqualityComparison equalityComparer = EqualityComparison.MoreThan;

	public int targetValue;

	public string GetTooltipDescription()
	{
		if (conditionType == QuestConditionType.CloseGroup)
		{
			return LocalizationManager.Instance.GetLocalizedValue("tooltip_questCondition_closing");
		}
		if (equalityComparer == EqualityComparison.Exactly)
		{
			return LocalizationManager.Instance.GetLocalizedValue("tooltip_questCondition_exactly");
		}
		return LocalizationManager.Instance.GetLocalizedValue("tooltip_questCondition_atLeast");
	}

	public string GetLabelText()
	{
		string text = "";
		switch (conditionType)
		{
		case QuestConditionType.CloseGroup:
			text = "[currentValue]";
			break;
		case QuestConditionType.CountElements:
		case QuestConditionType.CountSegments:
			switch (equalityComparer)
			{
			case EqualityComparison.Exactly:
				text = "[currentValue]";
				break;
			case EqualityComparison.FewerThan:
				text += "<[targetValue]";
				break;
			case EqualityComparison.MoreThan:
				text += "[currentValue]+";
				break;
			}
			break;
		}
		return text;
	}
}
