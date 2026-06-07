public class ProductionModifierGameModifier : ProductionModifier
{
	public readonly GameModifier modifier;

	public ProductionModifierGameModifier(GameModifier m, float effect)
	{
		modifier = m;
		multiplier = effect;
	}

	public override void CalcMultiplier()
	{
	}

	public override string DisplayLabel()
	{
		string text = "GameModifier".Localized();
		return "(" + text + ") " + TextDisplay.LabelForGameModifier(modifier);
	}
}
