public class DrifterTotalExperienceTooltip : Tooltip
{
	private DrifterAttributes _attributes;

	public void Initialize(DrifterAttributes attributes)
	{
		_attributes = attributes;
	}

	public override string ParsedText()
	{
		return string.Format("{0}/{1}", _attributes.Experience.ToString("F0"), ExpertiseManager.ReturnDrifterLevelRequirement(_attributes.Level).ToString("F0"));
	}
}
