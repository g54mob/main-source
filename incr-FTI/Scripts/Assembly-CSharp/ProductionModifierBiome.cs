public class ProductionModifierBiome : ProductionModifier
{
	private readonly BiomeType biomeType;

	private readonly BiomeModifier modifier;

	public ProductionModifierBiome(BiomeType biomeType, BiomeModifier m)
	{
		this.biomeType = biomeType;
		modifier = m;
		multiplier = m.multiplier;
	}

	public override void CalcMultiplier()
	{
		multiplier = modifier.multiplier;
	}

	public override string DisplayLabel()
	{
		return TextDisplay.LabelForBiome(biomeType) + " " + TextDisplay.LabelForBiomeModifier(modifier);
	}
}
