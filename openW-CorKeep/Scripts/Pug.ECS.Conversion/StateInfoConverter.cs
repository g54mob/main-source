using Pug.Conversion;

public class StateInfoConverter : SingleAuthoringComponentConverter<StateAuthoring>
{
	protected override void Convert(StateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
	}
}
