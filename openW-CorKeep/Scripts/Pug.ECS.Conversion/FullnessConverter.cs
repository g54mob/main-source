using Pug.Conversion;

public class FullnessConverter : SingleAuthoringComponentConverter<FullnessAuthoring>
{
	protected override void Convert(FullnessAuthoring authoring)
	{
		AddComponentData(new FullnessCD
		{
			maxFullness = authoring.maxFullness
		});
	}
}
