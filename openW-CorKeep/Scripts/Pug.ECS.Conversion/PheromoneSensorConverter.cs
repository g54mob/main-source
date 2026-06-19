using Pug.Conversion;

public class PheromoneSensorConverter : SingleAuthoringComponentConverter<PheromoneSensorAuthoring>
{
	protected override void Convert(PheromoneSensorAuthoring authoring)
	{
		EnsureHasComponent<PheromoneSensorCD>();
	}
}
