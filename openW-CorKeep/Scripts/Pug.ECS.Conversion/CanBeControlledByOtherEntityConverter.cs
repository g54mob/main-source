using Pug.Conversion;

public class CanBeControlledByOtherEntityConverter : SingleAuthoringComponentConverter<CanBeControlledByOtherEntityAuthoring>
{
	protected override void Convert(CanBeControlledByOtherEntityAuthoring authoring)
	{
		EnsureHasComponent<ControlledByOtherEntityCD>();
		EnsureHasComponent<IndestructibleCD>(componentIsEnabled: false);
	}
}
