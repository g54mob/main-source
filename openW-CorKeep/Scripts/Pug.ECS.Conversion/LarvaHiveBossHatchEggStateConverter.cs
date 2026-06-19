using Pug.Conversion;

public class LarvaHiveBossHatchEggStateConverter : SingleAuthoringComponentConverter<LarvaHiveBossHatchEggStateAuthoring>
{
	protected override void Convert(LarvaHiveBossHatchEggStateAuthoring authoring)
	{
		EnsureHasComponent<LarvaHiveBossHatchEggStateCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
