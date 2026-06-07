using System.Text;

public class BiomeModifier
{
	public readonly EntityId target;

	public readonly BiomeModifierType effect;

	public readonly bool isNegativeEffect;

	public float baselineMultiplier;

	public float multiplier;

	public BiomeModifier(EntityId target, BiomeModifierType effect, float multiplier, bool isNegative = false)
	{
		this.target = target;
		this.effect = effect;
		baselineMultiplier = multiplier;
		isNegativeEffect = isNegative;
		this.multiplier = baselineMultiplier;
	}

	public string HighlightText()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(TextDisplay.LabelForBiomeModifier(this));
		if (effect != BiomeModifierType.UniqueResource && effect != BiomeModifierType.UniqueBuilding && effect != BiomeModifierType.UniqueRecipe && GameUtility.IsNotZero(multiplier))
		{
			pooledStringBuilder.Append(' ');
			if (multiplier >= 1f)
			{
				pooledStringBuilder.Append("<color=#00FF00>");
				pooledStringBuilder.Append('+');
			}
			else
			{
				pooledStringBuilder.Append("<color=#FF0000>");
			}
			pooledStringBuilder.Append(TextDisplay.Percent(multiplier - 1f));
			pooledStringBuilder.Append("</color>");
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}
}
