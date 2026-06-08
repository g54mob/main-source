public class ElementGroupTooltipTarget : TooltipTarget
{
	private ElementGroupSegment segment;

	private void Awake()
	{
		segment = GetComponent<ElementGroupSegment>();
	}

	protected override string GetTooltipText()
	{
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue("tooltip_elementGroup");
		ElementType primaryElementType = segment.ElementGroup.GroupType.primaryElementType;
		localizedValue = localizedValue.Replace("[elements]", "[" + primaryElementType.localizationKey_singular + "]");
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, segment.ElementGroup.Elements[primaryElementType]);
		localizedValue = localizedValue.Replace("[group]", LocalizationManager.Instance.GetLocalizedValue(segment.ElementGroup.GroupType.localizationKey_singular));
		return localizedValue.Replace("[x]", segment.ElementGroup.Elements[primaryElementType].ToString());
	}
}
