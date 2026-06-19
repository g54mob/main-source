using Pug.Conversion;

public class WarmupConverter : SingleAuthoringComponentConverter<WarmupAuthoring>
{
	protected override void Convert(WarmupAuthoring authoring)
	{
		AddComponentData(new WarmupCD
		{
			warmupTime = authoring.warmup
		});
	}
}
