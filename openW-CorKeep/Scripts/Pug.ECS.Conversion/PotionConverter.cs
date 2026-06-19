using Pug.Conversion;

public class PotionConverter : SingleAuthoringComponentConverter<PotionAuthoring>
{
	protected override void Convert(PotionAuthoring authoring)
	{
		EnsureHasComponent<PotionCD>();
	}
}
