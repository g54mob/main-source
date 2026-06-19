using Pug.Conversion;

public class DrillConverter : SingleAuthoringComponentConverter<DrillAuthoring>
{
	protected override void Convert(DrillAuthoring authoring)
	{
		EnsureHasComponent<DrillCD>();
	}
}
