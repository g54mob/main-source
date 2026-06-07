public class ProductionModifierSkill : ProductionModifier
{
	private readonly Skill skill;

	public ProductionModifierSkill(Skill s)
	{
		skill = s;
		multiplier = 1f;
	}

	public override void CalcMultiplier()
	{
		multiplier = skill.ProductionMultiplier();
	}

	public override string DisplayLabel()
	{
		return "Skill".Localized() + " " + TextDisplay.GetFormattedLevelAbbreviation(skill.level);
	}
}
