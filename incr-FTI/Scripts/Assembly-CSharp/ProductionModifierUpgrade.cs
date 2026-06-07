public class ProductionModifierUpgrade : ProductionModifier
{
	public readonly Upgrade upgrade;

	public ProductionModifierUpgrade(Upgrade u)
	{
		upgrade = u;
		multiplier = 1f;
	}

	public override void CalcMultiplier()
	{
		multiplier = upgrade.GetMultiplier();
	}

	public override string DisplayLabel()
	{
		string text = "Upgrade".Localized();
		return "(" + text + ") " + TextDisplay.LabelForUpgrade(upgrade.type) + " " + TextDisplay.GetFormattedLevelAbbreviation(upgrade.numCompleted);
	}
}
