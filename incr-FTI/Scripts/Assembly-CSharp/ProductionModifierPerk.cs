public class ProductionModifierPerk : ProductionModifier
{
	private readonly PerkState perkState;

	public ProductionModifierPerk(PerkState t)
	{
		perkState = t;
		multiplier = 1f;
	}

	public override void CalcMultiplier()
	{
		multiplier = GameManager.Instance.AdjustedMultiplierForPerkLevel(perkState.type, perkState.GetLevel());
	}

	public override string DisplayLabel()
	{
		string text = ((!Perk.IsGlobal(perkState.type)) ? "TownPerks".Localized() : "WorldPerks".Localized());
		return "(" + text + ") " + TextDisplay.LabelForPerk(perkState.type) + " " + TextDisplay.GetFormattedLevelAbbreviation(perkState.GetLevel());
	}
}
