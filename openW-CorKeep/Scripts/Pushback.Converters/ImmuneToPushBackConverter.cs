using Pug.Conversion;

public class ImmuneToPushBackConverter : SingleAuthoringComponentConverter<ImmuneToPushBackAuthoring>
{
	protected override void Convert(ImmuneToPushBackAuthoring authoring)
	{
		EnsureHasComponent<ImmuneToPushBackCD>();
	}
}
