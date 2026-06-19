using Pug.Conversion;

public class AlwaysDropOneConverter : SingleAuthoringComponentConverter<AlwaysDropOneAuthoring>
{
	protected override void Convert(AlwaysDropOneAuthoring authoring)
	{
		EnsureHasComponent<AlwaysDropOneCD>();
	}
}
