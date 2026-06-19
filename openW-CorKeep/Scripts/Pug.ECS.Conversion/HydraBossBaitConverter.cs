using Pug.Conversion;

public class HydraBossBaitConverter : SingleAuthoringComponentConverter<HydraBossBaitAuthoring>
{
	protected override void Convert(HydraBossBaitAuthoring authoring)
	{
		EnsureHasComponent<BaitCD>();
		AddComponentData(new HydraBossBaitCD
		{
			attractsHydraType = authoring.attractsHydraType
		});
		EnsureHasComponent<OwnerReferenceCD>();
	}
}
