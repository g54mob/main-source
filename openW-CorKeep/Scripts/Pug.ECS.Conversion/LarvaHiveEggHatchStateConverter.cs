using Pug.Conversion;

public class LarvaHiveEggHatchStateConverter : SingleAuthoringComponentConverter<LarvaHiveEggHatchStateAuthoring>
{
	protected override void Convert(LarvaHiveEggHatchStateAuthoring authoring)
	{
		AddComponentData(new LarvaHiveEggHatchStateCD
		{
			stateTransitionDuration = authoring.stateTransitionDuration,
			hatchDuration = authoring.hatchDuration
		});
	}
}
