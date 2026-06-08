public class QuestTooltipTarget : TooltipTarget
{
	private QuestWatcher questWatcher;

	private void Awake()
	{
		questWatcher = GetComponentInParent<QuestTile>().QuestWatcher;
	}

	protected override string GetTooltipText()
	{
		QuestConditionWatcher conditionWatcher = questWatcher.GetConditionWatcher(0);
		string text = conditionWatcher.Condition.GetTooltipDescription();
		switch (questWatcher.CurrentFulfillmentStatus)
		{
		case FulfillmentStatus.Fulfilled:
			text = LocalizationManager.Instance.GetLocalizedValue("tooltip_questFulfilled");
			break;
		case FulfillmentStatus.Unfulfillable:
			text = LocalizationManager.Instance.GetLocalizedValue("tooltip_questFailed");
			break;
		}
		text = text.Replace("[elements]", "[" + conditionWatcher.ElementType.localizationKey_singular + "]");
		text = text.Replace("[elements_ru]", "[" + conditionWatcher.ElementType.localizationKey_russian + "]");
		text = text.Replace("[elements_pl]", "[" + conditionWatcher.ElementType.localizationKey_polish + "]");
		text = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(text, conditionWatcher.RemainingValue);
		text = text.Replace("[group]", LocalizationManager.Instance.GetLocalizedValue(conditionWatcher.GroupType.localizationKey_singular));
		if (!string.IsNullOrWhiteSpace(replacementInfo.stringToReplace))
		{
			text = text.Replace(replacementInfo.stringToReplace, conditionWatcher.RemainingValue.ToString());
		}
		return text;
	}
}
